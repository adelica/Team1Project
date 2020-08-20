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
using TUChairVO;

namespace TUChair
{
    public partial class BOMManage : TUChair.SearchCommomForm
    {
        List<BOMVO> BOM = null;
        List<ComboItemVO> comboItems = null;
        public BOMManage()
        {
            InitializeComponent();
        }

        private void BOMManage_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
            commonService service = new commonService();
            comboItems = service.getCommonCode("@사용여부@BOM@Item");




            List<ComboItemVO> cList = (from item in comboItems
                     where item.CodeType == "BOM"
                     select item).ToList();
            CommonUtil.ComboBinding(cboBOMType, cList);

            cList = (from item in comboItems
                     where item.CodeType == "Item"
                     select item).ToList();
            CommonUtil.ComboBinding(cboitem, cList,"");


            dtpDate.Value = DateTime.Now;

            jeansGridView1.IsAllCheckColumnHeader = true;
        
            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "bom번호", "BOM_No", false);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목코드", "Item_Code", false);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "상위코드", "ParentItem_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "INFO", true,200);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "ItemCode", true,200);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "타입", "Item_Type", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "소요량", "BOM_Require", true,60,DataGridViewContentAlignment.MiddleRight);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "레 벨", "Lvl", true,60, DataGridViewContentAlignment.MiddleRight);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "시작일자", "BOM_StartDate", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "완료일자", "BOM_EndDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "사용여부", "BOM_UserOrNot", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정자", "BOM_Modifier", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정일자", "BOM_ModifiyDate", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "자동차감", "BOM_AutoDeducion", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "소요계획", "BOM_RequirePlan", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "비고", "BOM_Others", true);

            BindingData();
        }

        private void BOMManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save -= Save;
            frm.Search -= Search;
            frm.Delete -= Delete;
            frm.New -= New;
            frm.Excel -= Excel;
        }

        private void Excel(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void New(object sender, EventArgs e)
        {
            BindingData();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                List<string> sb = new List<string>();
                jeansGridView1.EndEdit();
                for (int i = 0; i < jeansGridView1.RowCount; i++)
                {
                    bool isn = Convert.ToBoolean(jeansGridView1.Rows[i].Cells["chk"].Value);
                    if (isn)
                    {
                        sb.Add(jeansGridView1.Rows[i].Cells[1].Value.ToString());
                    }
                }
                if (sb.Count < 1)
                {
                    MessageBox.Show("삭제할 항목을 선택해주세요");
                    return;
                }
                string condition = string.Join("@", sb);
                BOMService service = new BOMService();
                if (service.DeleteBOM(condition))
                {
                    MessageBox.Show("삭제되었습니다.");
                }
                else
                    MessageBox.Show("삭제에 실패하였습니다.");

                BindingData();
            }
        }

        private void Search(object sender, EventArgs e)
        {
            if (cboitem.Text.Length < 1)
            {
                MessageBox.Show("품목을 선택해주세요.");
                return;
            }
            BOMService service = new BOMService();
            BOM= service.SearchBOM(dtpDate.Value, cboitem.SelectedValue.ToString(), cboBOMType.SelectedValue.ToString());
            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = BOM;

        }

        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                int cnt = 0;
                int row = 0;
                jeansGridView1.EndEdit();
                for (int i = 0; i < jeansGridView1.Rows.Count; i++)
                {
                    bool isbool = Convert.ToBoolean(jeansGridView1.Rows[i].Cells["chk"].Value);
                    if (isbool)
                    { cnt++; row = i; }
                }
                string userID = ((TUChairMain2)this.MdiParent).userInfoVO.CUser_ID;
                if (cnt == 0)
                {
                    BOMPopUP frm = new BOMPopUP(userID);
                    frm.Tag = 0;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        BindingData();
                    }
                }
                else if (cnt > 1)
                {
                    MessageBox.Show("수정은 하나씩만 가능합니다.");
                    return;
                }
                else
                {
                    BOMVO BOM = new BOMVO();
                   BOM.Item_Code                  = jeansGridView1.Rows[row].Cells[2].Value.ToString();
                   BOM.ParentItem_Code            = jeansGridView1.Rows[row].Cells[3].Value.ToString()   == "*" ? "" : jeansGridView1.Rows[row].Cells[3].Value.ToString();
                    BOM.BOM_Require = Convert.ToInt32(jeansGridView1.Rows[row].Cells[7].Value);
                    BOM.BOM_StartDate = Convert.ToDateTime(jeansGridView1.Rows[row].Cells[9].Value); 
                    BOM.BOM_EndDate                = Convert.ToDateTime(jeansGridView1.Rows[row].Cells[10].Value);
                    BOM.BOM_UserOrNot              = jeansGridView1.Rows[row].Cells[11].Value == null ? "" : jeansGridView1.Rows[row].Cells[11].Value.ToString();
                   BOM.BOM_AutoDeducion           = jeansGridView1.Rows[row].Cells[14].Value == null ? "" : jeansGridView1.Rows[row].Cells[14].Value.ToString();
                   BOM.BOM_RequirePlan            = jeansGridView1.Rows[row].Cells[15].Value == null ? "" : jeansGridView1.Rows[row].Cells[15].Value.ToString();
                   BOM.BOM_Others                 = jeansGridView1.Rows[row].Cells[16].Value == null ? "" : jeansGridView1.Rows[row].Cells[16].Value.ToString();
                    BOM.BOM_No                     =Convert.ToInt32(jeansGridView1.Rows[row].Cells[1].Value);

                    BOMPopUP frm = new BOMPopUP(userID);
                    frm.BomInfo = BOM;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        BindingData();
                    }
                }
            }
        }

        private void BindingData()
        {
            BOMService service1 = new BOMService();
            BOM = service1.getALLBom();
            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = BOM;
        }
    }
}
