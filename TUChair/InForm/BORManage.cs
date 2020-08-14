using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Util;
using TUChairVO;
using TUChair.Service;
using System.Linq;

namespace TUChair
{
    public partial class BORManage : TUChair.SearchCommomForm
    {
        List<BORVO> list;
        TUChairMain2 frm = new TUChairMain2();

        public BORManage()
        {
            InitializeComponent();
            CommonUtil.InitSettingGridView(dgvBOR);
            dgvBOR.IsAllCheckColumnHeader=true;

            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "No.", "No", true, 40,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "공정", "FacG_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "공정명", "FacG_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "설비", "Faci_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "설비명", "Faci_Name", true,200);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "Tact Time(Sec)", "BOR_TactTime", true,120, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "우선순위", "BOR_Priority", true,70, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "수율", "BOR_Yeild", true,100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "공정선행일(Day)", "BOR_ProcessLeadDate", true,130,DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "사용유무", "BOR_UseOrNot", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "비고", "BOR_Other", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "BOR_Code", "BOR_Code", false);
        }

        private void BORManage_Load(object sender, EventArgs e)
        {
            LoadData();
            CommonUtil.CboSetting(cboFacG_Code);
            frm = (TUChairMain2)this.MdiParent;

            frm.New += New;
            frm.Search += Search;
            frm.Save += Save;
        }
        //등록, 수정
        private void Save(object sender, EventArgs e)
        {
            List<string> chkList = Check();
            if (chkList.Count < 1)
            {
                BORInfoRegi frm = new BORInfoRegi(list);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if (frm.Check)
                {
                    LoadData();
                }
            }
            else if(chkList.Count==1)
            {
                List<BORVO> borList = (from code in list
                                       where code.BOR_Code == Convert.ToInt32(chkList[0])
                                       select code).ToList();
                BORInfoRegi frm = new BORInfoRegi(borList,list);
            }
            else
            {
                MessageBox.Show("수정할 데이터 하나만 선택해주세요", "수정실패");
                return;
            }
           
        }
        // 검색
        private void Search(object sender, EventArgs e)
        {
            List<BORVO> searchList = null;

            if (txtItem_Code.Text.Trim().Length > 0 && cboFacG_Code.Text == "전체" && txtFaci_Code.Text.Trim().Length < 1)
            {
                searchList = (from search in list
                              where search.Item_Code.ToUpper().Contains(txtItem_Code.Text.ToUpper())
                              select search).ToList();
            }
            else if (txtItem_Code.Text.Trim().Length > 0 && cboFacG_Code.Text != "전체" && txtFaci_Code.Text.Trim().Length < 1)
            {
                searchList = (from search in list
                              where search.Item_Code.ToUpper().Contains(txtItem_Code.Text.ToUpper()) && search.FacG_Code.ToUpper() == cboFacG_Code.Text.ToUpper()
                              select search).ToList();
            }
            else if (txtItem_Code.Text.Trim().Length > 0 && cboFacG_Code.Text != "전체" && txtFaci_Code.Text.Trim().Length > 0)
            {
                searchList = (from search in list
                              where search.Item_Code.ToUpper().Contains(txtItem_Code.Text.ToUpper()) && search.FacG_Code.ToUpper() == cboFacG_Code.Text.ToUpper() && search.Faci_Code.ToUpper().Contains(txtFaci_Code.Text.ToUpper())
                              select search).ToList();
            }
            else if (txtItem_Code.Text.Trim().Length < 1 && cboFacG_Code.Text != "전체" && txtFaci_Code.Text.Trim().Length < 1)
            {
                searchList = (from search in list
                              where search.FacG_Code.ToUpper() == cboFacG_Code.Text.ToUpper()
                              select search).ToList();
            }
            else if (txtItem_Code.Text.Trim().Length < 1 && cboFacG_Code.Text != "전체" && txtFaci_Code.Text.Trim().Length > 0)
            {
                searchList = (from search in list
                              where search.FacG_Code.ToUpper() == cboFacG_Code.Text.ToUpper() && search.Faci_Code.ToUpper().Contains(txtFaci_Code.Text.ToUpper())
                              select search).ToList();
            }
            else if (txtItem_Code.Text.Trim().Length < 1 && cboFacG_Code.Text == "전체" && txtFaci_Code.Text.Trim().Length > 0)
            {
                searchList = (from search in list
                              where search.Faci_Code.ToUpper().Contains(txtFaci_Code.Text.ToUpper())
                              select search).ToList();
            }
            else
            {
                searchList = (from search in list
                              select search).ToList();
            }
            if (searchList.Count < 1)
            {
                MessageBox.Show("조건에 맞는 데이터가 없습니다.", "검색실패");
                dgvBOR.DataSource = list;
                return;
            }
            else
            {
                dgvBOR.DataSource = searchList;
            }
        }
        //전체조회
        private void New(object sender, EventArgs e)
        {
            if(((TUChairMain2)this.MdiParent).ActiveMdiChild==this)
            {
                txtFaci_Code.Text = txtItem_Code.Text = "";
                LoadData();
                cboFacG_Code.SelectedIndex = 0;
            }
        }

        private void LoadData()
        {
            BORService service = new BORService();
            list = service.GetBORData();
            dgvBOR.DataSource = list;

            ComboBinding();
        }
        //콤보박스 바인딩
        private void ComboBinding()
        {
            List<string> facG_code = (from code in list
                                      select code.FacG_Code).Distinct().ToList();
            cboFacG_Code.Items.Add("전체");
            foreach (var cbo in facG_code)
            {
                cboFacG_Code.Items.Add(cbo);
            }
            
        }

        //앞에 순번정해주기
        private void dgvBOR_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvBOR.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }


        private void dgvBOR_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > dgvBOR.Rows.Count)
                return;

            if(e.Button==MouseButtons.Right)
            {
                dgvBOR.Rows[e.RowIndex].Selected = true;
                dgvBOR.CurrentCell = dgvBOR.Rows[e.RowIndex].Cells[0];
                contextMenuStrip1.Show(dgvBOR, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DialogResult.OK==(MessageBox.Show("정말로 삭제하시겠습니까?","삭제확인",MessageBoxButtons.OKCancel)))
            {
                var row = dgvBOR.CurrentRow;
                int code = Convert.ToInt32(row.Cells[13].Value);
                BORService service = new BORService();
                bool check = service.DeleteBORInfo(code);
                
                if(check)
                {
                    MessageBox.Show("삭제되었습니다.", "삭제확인");
                    LoadData();
                }
                else
                    MessageBox.Show("삭제를 실패하였습니다.", "삭제실패");
            }
        }

        private void 수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = dgvBOR.CurrentRow;

            string itemC = row.Cells[1].Value.ToString();
            string facgC= row.Cells[3].Value.ToString();
            string faciC= row.Cells[5].Value.ToString();
            int tactT =Convert.ToInt32(row.Cells[7].Value);
            int prio = Convert.ToInt32(row.Cells[8].Value.ToString());
            decimal yei = Convert.ToDecimal(row.Cells[9].Value); //수율, null허용
            int processLead = Convert.ToInt32(row.Cells[10].Value);
            string uOrN= row.Cells[11].Value.ToString();
            string other = row.Cells[12].Value==null?"":row.Cells[11].Value.ToString()  ;

            //BORInfoRegi frm = new BORInfoRegi(itemC, facgC, faciC, tactT, prio, yei, processLead, uOrN, other, list);
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog();
            //if(frm.Check)
            //{
            //    LoadData();
            //}
        }
        //체크박스 체크확인
        private List<String> Check()
        {
            List<string> chkList = new List<string>();

            for (int i = 0; i < dgvBOR.Rows.Count; i++)
            {
                bool IsCellChecked = (bool)dgvBOR.Rows[i].Cells[0].EditedFormattedValue;
                if (IsCellChecked)
                {
                    chkList.Add(dgvBOR.Rows[i].Cells[13].Value.ToString());
                }
            }
            return chkList;
        }

        private void BORManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.New -= New;
            frm.Search -= Search;
        }
    }
}
