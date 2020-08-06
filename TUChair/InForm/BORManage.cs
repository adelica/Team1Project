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

        public BORManage()
        {
            InitializeComponent();
            CommonUtil.InitSettingGridView(dgvBOR);
            

            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "No.", "No", true, 40);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "공정", "FacG_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "공정명", "FacG_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "설비", "Faci_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "설비명", "Faci_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "Tact Time(Sec)", "BOR_TactTime", true,150);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "우선순위", "BOR_Priority", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "수율", "BOR_Yeild", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "사용유무", "BOR_UseOrNot", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "비고", "BOR_Other", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "BOR_Code", "BOR_Code", false);
        }

        private void BORManage_Load(object sender, EventArgs e)
        {
            LoadData();
            CommonUtil.CboSetting(cboFacG_Code);
        }

        private void LoadData()
        {
            BORService service = new BORService();
            list = service.GetBORData();
            dgvBOR.DataSource = list;

            ComboBinding();
        }
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

        private void dgvBOR_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvBOR.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)  //검색조건
        {
            List<BORVO> searchList=null;

            if(txtItem_Code.Text.Trim().Length>0 && cboFacG_Code.Text=="전체" && txtFaci_Code.Text.Trim().Length<1)
            {
                searchList = (from search in list
                              where search.Item_Code.ToUpper().Contains(txtItem_Code.Text.ToUpper())
                              select search).ToList();
            }
            else if(txtItem_Code.Text.Trim().Length > 0 && cboFacG_Code.Text !="전체" && txtFaci_Code.Text.Trim().Length < 1)
            {
                searchList = (from search in list
                              where search.Item_Code.ToUpper().Contains(txtItem_Code.Text.ToUpper()) && search.FacG_Code.ToUpper() == cboFacG_Code.Text.ToUpper()
                              select search).ToList();
            }
            else if (txtItem_Code.Text.Trim().Length > 0 && cboFacG_Code.Text != "전체" && txtFaci_Code.Text.Trim().Length>0)
            {
                searchList = (from search in list
                              where search.Item_Code.ToUpper().Contains(txtItem_Code.Text.ToUpper()) && search.FacG_Code.ToUpper() == cboFacG_Code.Text.ToUpper() &&search.Faci_Code.ToUpper().Contains(txtFaci_Code.Text.ToUpper())
                              select search).ToList();
            }
            else if(txtItem_Code.Text.Trim().Length<1 && cboFacG_Code.Text !="전체" && txtFaci_Code.Text.Trim().Length < 1)
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

        private void txtItem_Code_KeyPress(object sender, KeyPressEventArgs e) // 엔터눌러서 검색
        {
            if(e.KeyChar==13)
            {
                btnSearch.PerformClick();
            }
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
                int code = Convert.ToInt32(row.Cells[12].Value);
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            BORInfoRegi frm = new BORInfoRegi(list);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if(frm.Check)
            {
                LoadData();
            }
        }
    }
}
