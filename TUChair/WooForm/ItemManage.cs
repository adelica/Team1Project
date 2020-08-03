using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChairVO;
using System.Reflection;
using TUChair.Service;
using TUChair.Util;

namespace TUChair
{
    public partial class ItemManage : TUChair.SearchCommomForm
    {
        
        List<ItemVO> items = null;
        List<ComboItemVO> comboItems = null;

        public ItemManage()
        {
            InitializeComponent();
        }

        private void ItemManage_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
            commonService service = new commonService();
            comboItems= service.getCommonCode("고객사@창고@User@사용여부@품목유형");

            List<ComboItemVO> cList = (from item in comboItems
                                    where item.CodeType == "고객사"
                                       select item).ToList();
            CommonUtil.ReComboBinding(cboCompany1, cList, "선택");

            cList = (from item in comboItems
                     where item.CodeType == "창고"
                     select item).ToList();
            CommonUtil.ComboBinding(cboInWherehouse, cList, "선택");
            cList = (from item in comboItems
                     where item.CodeType == "창고"
                     select item).ToList();
            CommonUtil.ComboBinding(cboOutWherehouse, cList, "선택");
            cList = (from item in comboItems
                     where item.CodeType == "User"
                     select item).ToList();
            CommonUtil.ReComboBinding(cboUser, cList, "선택");
            cList = (from item in comboItems
                     where item.CodeType == "사용여부"
                     select item).ToList();
            CommonUtil.ComboBinding(cboUseOrNot, cList, "선택");
            cList = (from item in comboItems
                     where item.CodeType == "품목유형"
                     select item).ToList();
            CommonUtil.ComboBinding(cboItemType, cList, "선택");

            jeansGridView1.IsAllCheckColumnHeader = true;
            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목유형", "Item_Type", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "단위", "Item_Unit", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "발주업체", "Item_OrderComp", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "설비코드", "Faci_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "입고창고", "Item_InWarehouse", true);
            
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "출고창고", "Item_OutWarehouse", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "안전재고", "Item_SafeQuantity", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수입검사여부", "Item_Importins", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "공정검사여부", "Item_Processins", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "출하검사여부", "Item_Shipmentins", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "담당자", "Item_Manager", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정자", "Item_Modifier", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정일자", "Item_ModiflyDate", true);
            
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "종료일", "Item_Modifier", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "사용유무", "Price_UserOrNot", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "비고", "Item_Other", true);
            //jeansGridView1.DataSource = items;

            ItemService service1 = new ItemService();
           items= service1.GetAllItem();
            jeansGridView1.DataSource = items;
        }
        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("저장이다2.");
        }
        private void New(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("새로고쳐.");
        }
        private void Search(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
              string sg =    GetSearchCondition(panel1);

                ItemService service = new ItemService();
              items  =  service.SearchItem(sg);
            }
            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = items;

        }

        private string GetSearchCondition(Panel panel1)
        {
            List<string> sb = new List<string>();
            foreach (Control Pitem in panel1.Controls)
            {
                foreach (Control item in Pitem.Controls)
                {

                    if (item is ComboBox)
                    {
                        if (item.Text !="선택")
                            sb.Add($"{item.Tag.ToString().Trim()}='{((ComboBox)item).Text.Trim()}'");
                    }
                    else if (item is TextBox)
                    {
                        if (item.Text != "")
                            sb.Add($"{item.Tag.ToString()} like '%{item.Text}%'");
                    }
                    else if (item is InDTP)
                    {
                        if (item.Text != "")
                            sb.Add($"between{((InDTP)item).Start.ToString()}and {((InDTP)item).End.ToString()}");
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return String.Join(" and ", sb);
        }
        private void Delete(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("지워");
        }
        private void Excel(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("엑셀만들어");
        }

       
    }
}
