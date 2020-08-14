using DevExpress.Utils.Extensions;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;
using TUChairVO;

namespace TUChair
{
    public partial class FacilityManage : Form
    {
        DataTable dtFacility;
        DataTable dtFacilityG;
        DataTable dtFacG_code; // 현재 존재하는 설비군 코드
        DataTable dtFaci_code;//현재 존재하는 설비 코드

        TUChairMain2 frm = new TUChairMain2();
        bool typeCheck = true;

        public FacilityManage()
        {
            InitializeComponent();
        
        
            CommonUtil.InitSettingGridView(dgvFacilityG);
            CommonUtil.InitSettingGridView(dgvFacility);

            dgvFacilityG.AutoGenerateColumns = false;
            dgvFacility.AutoGenerateColumns = false;

            dgvFacility.IsAllCheckColumnHeader = true;

            //설비군 dgv
            CommonUtil.AddNewColumnToDataGridView(dgvFacilityG, "설비군 코드", "FacG_Code", true,110);
            CommonUtil.AddNewColumnToDataGridView(dgvFacilityG, "설비군 명", "FacG_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFacilityG, "사용유무", "FacG_UseOrNot", true, 80);
            CommonUtil.AddNewColumnToDataGridView(dgvFacilityG, "정보", "FacG_Information", false);
            CommonUtil.AddNewColumnToDataGridView(dgvFacilityG, "수정자", "FacG_Modifier", true,80);

            //설비 dgv
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "No.", "no", true, 40, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "설비코드", "Faci_Code", true, 170);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "설비명", "Faci_Name", true, 150);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "소진창고", "Faci_OutWareHouse", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "양품창고", "Faci_InWareHouse", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "불량창고", "Faci_BadWareHouse", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "특이사항", "Faci_Detail", true,150);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "비고", "Faci_Others", true,150);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "사용유무", "Faci_UseOrNot", true, 80);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "수정자", "Faci_Modifier", true, 80);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "수정시간", "Faci_ModifyDate", true, 150);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "설비군", "FacG_Code", false);
        }

        private void FacilityManage_Load(object sender, EventArgs e)
        {
            frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.New += New;
            frm.Delete += Delete;
            frm.Readed += Readed_BarCode;
            LoadData();
        }
        //바코드 찍을 시
        private void Readed_BarCode(object sender, ReadEventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                int barID = int.Parse(e.ReadMsg.Trim().Replace("\r", "").Replace("\n", "").TrimStart('0'));
                ((TUChairMain2)this.MdiParent).Clearstrings();

                FacilityService service = new FacilityService();
                DataTable dt = service.FacilityBarInfo(barID);

                FacilityInfo frm = new FacilityInfo(dt);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }             
        }
        //데이터바인딩
        private void LoadData() 
        {
            FacilityService service = new FacilityService();
            DataSet ds = service.GetFacilityData();
            dtFacility = ds.Tables["facility"];
            dtFacilityG = ds.Tables["facilityGroup"];
            dgvFacility.DataSource = dtFacility;
            dgvFacilityG.DataSource = dtFacilityG;

            dtFacG_code = dtFacilityG.DefaultView.ToTable(false, "FacG_Code");
            dtFaci_code = dtFacility.DefaultView.ToTable(false, "Faci_Code");
        }
        //설비군 등록
        private void btnFGInsert_Click(object sender, EventArgs e) 
        {
            FacilityGroupInfoRegi frm = new FacilityGroupInfoRegi(dtFacG_code);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.Check)
            {
                LoadData();
            }
        }
        //설비 등록
        private void btnFInsert_Click(object sender, EventArgs e) 
        {
            FacilityInfoRegi frm = new FacilityInfoRegi(dtFacG_code,dtFaci_code);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.Check)
            {
                LoadData();
            }
        }
        //그리드뷰 맨 앞에 no 자동 생성
        private void dgvFacility_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvFacility.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }
        //설비군에 등록된 설비 없을 시 안됨
        private void dgvFacilityG_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
            if (e.RowIndex < 0 || e.RowIndex > dgvFacilityG.Rows.Count)
                return;

            string code = dgvFacilityG.Rows[e.RowIndex].Cells[0].Value.ToString();

            var facility = (from fdata in dtFacility.AsEnumerable()
                            where fdata.Field<string>("FacG_Code") == code
                            select fdata);

            if (facility.Count() < 1)
            {
                MessageBox.Show("등록된 설비가 없습니다");
                dgvFacility.DataSource = null;
            }
            else
                dgvFacility.DataSource = facility.CopyToDataTable();

        }

        private void dgvFacilityG_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > dgvFacilityG.Rows.Count)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                typeCheck = true;
                dgvFacilityG.Rows[e.RowIndex].Selected = true;
                dgvFacilityG.CurrentCell = dgvFacilityG.Rows[e.RowIndex].Cells[0];
                contextMenuStrip1.Show(dgvFacilityG, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
        //설비군 삭제
        private void 수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typeCheck) //설비군 수정
            {
                var row = dgvFacilityG.CurrentRow;

                string facG_Code = row.Cells[0].Value.ToString();
                string facG_Name = row.Cells[1].Value.ToString();
                string facGUseOrNot = row.Cells[2].Value.ToString();
                string facG_Info = row.Cells[3].Value.ToString();
                string facG_Modifier = row.Cells[4].Value.ToString();

                FacilityGroupInfoRegi frm = new FacilityGroupInfoRegi(facG_Code, facG_Name, facGUseOrNot, facG_Info, facG_Modifier);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if (frm.Check)
                {
                    LoadData();
                }
            }
            //else //설비수정 2~9 11,12
            //{
            //    var row = dgvFacility.CurrentRow;

            //    string faci_Code = row.Cells[2].Value.ToString();
            //    string faci_Name = row.Cells[3].Value.ToString();
            //    string faci_Out = row.Cells[4].Value.ToString();
            //    string faci_In = row.Cells[5].Value.ToString();
            //    string faci_Bad = row.Cells[6].Value.ToString();
            //    string faci_Detail = row.Cells[7].Value.ToString();
            //    string faci_Others = row.Cells[8].Value.ToString();
            //    string faci_UseOrNot = row.Cells[9].Value.ToString();
            //    string faci_Modifier = row.Cells[10].Value.ToString();
            //    string faci_ModifyDate = row.Cells[11].Value.ToString();
            //    string facG_Code = row.Cells[12].Value.ToString();

            //    FacilityInfoRegi frm = new FacilityInfoRegi(faci_Code, faci_Name, faci_Out, faci_In, faci_Bad, faci_Detail, faci_Others, faci_UseOrNot, faci_Modifier, faci_ModifyDate, facG_Code,dtFacG_code, dtFaci_code);
            //    frm.StartPosition = FormStartPosition.CenterParent;
            //    frm.ShowDialog();
            //    if(frm.Check)
            //    {
            //        LoadData();
            //    }
            //}
        }

        //설비군용 삭제
        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool check;
            if (typeCheck)
            {
                if (DialogResult.OK == (MessageBox.Show("정말 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.OKCancel)))
                {
                    var row = dgvFacilityG.CurrentRow;

                    string facG_Code = row.Cells[0].Value.ToString();

                    var facilityCheck = (from fCheck in dtFacility.AsEnumerable()
                                         where fCheck.Field<string>("FacG_Code") == facG_Code
                                         select fCheck);
                    if (facilityCheck.Count() < 1)
                    {
                        FacilityService service = new FacilityService();
                        check = service.DeleteFacilityGInfo(facG_Code);
                        if (check)
                        {
                            MessageBox.Show("삭제되었습니다.", "삭제완료");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("삭제를 실패하였습니다", "삭제실패");
                        }
                    }
                    else
                    {
                        MessageBox.Show("등록된 설비가 존재합니다.", "삭제실패");
                    }
                }
                return;
            }

            else
            {
                if (DialogResult.OK == (MessageBox.Show("정말 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.OKCancel)))
                {
                    var row = dgvFacility.CurrentRow;
                    string faci_Code = row.Cells[0].Value.ToString();
                    FacilityService service = new FacilityService();
                    check = service.DeleteFacilityInfo(faci_Code);
                    if (check)
                    {
                        MessageBox.Show("삭제되었습니다.", "삭제완료");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("삭제를 실패하였습니다", "삭제실패");
                    }
                }
                return;
            }
        }

        //바코드 생성
        private void btnBar_Click(object sender, EventArgs e)
        {
            List<string> chkList = new List<string>();

            for (int i = 0; i < dgvFacility.Rows.Count; i++)
            {
                bool isCellChecked = (bool)dgvFacility.Rows[i].Cells[0].EditedFormattedValue;
                if (isCellChecked)
                {
                    chkList.Add(dgvFacility.Rows[i].Cells[2].Value.ToString());
                }
            }
            if (chkList.Count == 0)
            {
                MessageBox.Show("출력할 바코드를 선택해주세요.");
                return;
            }

            string strChkBarCodes = "'" + string.Join("','", chkList) + "'";
          
            FacilityService service = new FacilityService();
            DataTable dt = service.FacilityInfoBarCode(strChkBarCodes);

            FacilityReport rpt = new FacilityReport();
            rpt.DataSource = dt;
            PreviewForm frm = new PreviewForm(rpt);
            
        }
        
        //조회
        private void New(object sender, EventArgs e)
        {
           if(((TUChairMain2)this.MdiParent).ActiveMdiChild==this)
            {
                LoadData(); ;
            }
        }

        //설비용 삭제
        private void Delete(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                List<string> chkList = Check();
                if (chkList.Count == 0)
                {
                    MessageBox.Show("삭제할 데이터를 클릭해주세요.");
                    return;
                }

                if (DialogResult.OK == (MessageBox.Show("정말로 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.OKCancel)))
                {
                    string code = "'" + string.Join("','", chkList) + "'";

                    FacilityService service = new FacilityService();
                    if (service.DeleteFacilityInfo(code))
                    {
                        MessageBox.Show("삭제되었습니다.", "삭제완료");
                        LoadData();
                    }

                }
                else
                    return;
            }
        }

        //설비수정
        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                List<string> chkList = Check();
                bool check = false;

                if (chkList.Count == 1) // 수정 chkList  --------------------------------------------
                {
                    string code = chkList[0];
                    List<FacilityVO> convert = ConvertToList<FacilityVO>(dtFacility);
                    List<FacilityVO> list = (from data in convert
                                             where data.Faci_Code == code
                                             select data).ToList();

                    FacilityInfoRegi frm = new FacilityInfoRegi(list, dtFacG_code, dtFaci_code);
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    check = frm.Check;
                }
                else if(chkList.Count>1)
                {
                    MessageBox.Show("수정할 데이터 하나만 선택해주세요", "수정실패");
                    return;
                }
                else
                {
                    MessageBox.Show("수정할 설비를 선택해주세요", "수정실패");
                    return;
                }
                if (check)
                    LoadData();
            }
        }

        public List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pI.PropertyType));
                    }
                }
                return objT;
            }).ToList();
        }

        //체크박스에 체크된 설비 코드
        private List<String> Check()
        {
            List<string> chkList = new List<string>();

            for (int i = 0; i < dgvFacility.Rows.Count; i++)
            {
                bool IsCellChecked = (bool)dgvFacility.Rows[i].Cells[0].EditedFormattedValue;
                if (IsCellChecked)
                {
                    chkList.Add(dgvFacility.Rows[i].Cells[2].Value.ToString());
                }
            }
            return chkList;
        }

        private void FacilityManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.Readed -= Readed_BarCode;
            frm.Delete -= Delete;
            frm.Save -= Save;
            frm.New -= New;
        }
    }
}
