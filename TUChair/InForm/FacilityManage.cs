using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;

namespace TUChair
{
    public partial class FacilityManage : Form
    {
        DataTable dtFacility = new DataTable();
        DataTable dtFacilityG = new DataTable();
        DataTable dtFacG_code; // 현재 존재하는 설비군 코드
        DataTable dtFaci_code;//현재 존재하는 설비 코드
        bool typeCheck = true;

        public FacilityManage()
        {
            InitializeComponent();

            CommonUtil.InitSettingGridView(dgvFacilityG);
            CommonUtil.InitSettingGridView(dgvFacility);
            dgvFacilityG.AutoGenerateColumns = false;
            dgvFacility.AutoGenerateColumns = false;


            CommonUtil.AddNewColumnToDataGridView(dgvFacilityG, "설비군 코드", "FacG_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFacilityG, "설비군 명", "FacG_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFacilityG, "사용유무", "FacG_UseOrNot", true, 80);
            CommonUtil.AddNewColumnToDataGridView(dgvFacilityG, "정보", "FacG_Information", false);


            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "No.", "no", true, 40, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "설비코드", "Faci_Code", true, 150);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "설비명", "Faci_Name", true, 150);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "소진창고", "Faci_OutWareHouse", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "양품창고", "Faci_InWareHouse", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "불량창고", "Faci_BadWareHouse", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "특이사항", "Faci_Detail", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "비고", "Faci_Others", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "사용유무", "Faci_UseOrNot", true, 80);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "수정자", "Faci_Modifier", true, 80);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "수정시간", "Faci_ModifyDate", true, 150);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "설비군", "FacG_Code", false);
           
        }

        private void FacilityManage_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData() //데이터바인딩
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
        private void btnFGInsert_Click(object sender, EventArgs e) //설비군 등록
        {
            FacilityGroupInfoRegi frm = new FacilityGroupInfoRegi(dtFacG_code);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.Check)
            {
                LoadData();
            }
        }

        private void btnFInsert_Click(object sender, EventArgs e) //설비 등록
        {
            FacilityInfoRegi frm = new FacilityInfoRegi(dtFacG_code,dtFaci_code);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.Check)
            {
                LoadData();
            }
        }

        private void dgvFacility_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) //그리드뷰 맨 앞에 no 자동 생성
        {
            this.dgvFacility.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvFacilityG_CellClick(object sender, DataGridViewCellEventArgs e) //설비군에 등록된 설비 없을 시 안됨
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

        private void dgvFacility_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > dgvFacility.Rows.Count)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                typeCheck = false;
                dgvFacility.Rows[e.RowIndex].Selected = true;
                dgvFacility.CurrentCell = dgvFacility.Rows[e.RowIndex].Cells[0];
                contextMenuStrip1.Show(dgvFacility, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void 수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typeCheck) //설비군 수정
            {
                var row = dgvFacilityG.CurrentRow;

                string facG_Code = row.Cells[0].Value.ToString();
                string facG_Name = row.Cells[1].Value.ToString();
                string facGUseOrNot = row.Cells[2].Value.ToString();
                string facG_Info = row.Cells[3].Value.ToString();

                FacilityGroupInfoRegi frm = new FacilityGroupInfoRegi(facG_Code, facG_Name, facGUseOrNot, facG_Info);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if (frm.Check)
                {
                    LoadData();
                }
            }
            else //설비수정 1~8 11
            {
                var row = dgvFacility.CurrentRow;

                string faci_Code = row.Cells[1].Value.ToString();
                string faci_Name = row.Cells[2].Value.ToString();
                string faci_Out = row.Cells[3].Value.ToString();
                string faci_In = row.Cells[4].Value.ToString();
                string faci_Bad = row.Cells[5].Value.ToString();
                string faci_Detail = row.Cells[6].Value.ToString();
                string faci_Others = row.Cells[7].Value.ToString();
                string faci_UseOrNot = row.Cells[8].Value.ToString();
                string faci_ModifyDate = row.Cells[10].Value.ToString();
                string facG_Code = row.Cells[11].Value.ToString();

                FacilityInfoRegi frm = new FacilityInfoRegi(faci_Code, faci_Name, faci_Out, faci_In, faci_Bad, faci_Detail, faci_Others, faci_UseOrNot, faci_ModifyDate, facG_Code,dtFacG_code, dtFaci_code);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if(frm.Check)
                {
                    LoadData();
                }
            }
        }

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
                    string faci_Code = row.Cells[1].Value.ToString();
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
    }
}
