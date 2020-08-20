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
using Excels = Microsoft.Office.Interop.Excel;

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
            comboItems = service.getCommonCode("고객사@창고@User@사용여부@품목유형@공정구분");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "고객사"
                                       select item).ToList();
            CommonUtil.ReComboBinding(cboCompany1, cList, "선택");

            cList = (from item in comboItems
                     where item.CodeType == "창고"
                     select item).ToList();
            CommonUtil.ReComboBinding(cboInWherehouse, cList, "선택");
            cList = (from item in comboItems
                     where item.CodeType == "창고"
                     select item).ToList();
            CommonUtil.ReComboBinding(cboOutWherehouse, cList, "선택");
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
         
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "입고창고", "Item_InWarehouse", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "출고창고", "Item_OutWarehouse", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "안전재고", "Item_SafeQuantity", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수입검사여부", "Item_Importins", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "공정검사여부", "Item_Processins", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "출하검사여부", "Item_Shipmentins", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "담당자", "Item_Manager", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정자", "Item_Modifier", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정일자", "Item_ModiflyDate", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "공정구분", "Item_OutSourcing", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "사용유무", "Item_UserOrNot", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "비고", "Item_Other", true);
            //jeansGridView1.DataSource = items;

            BindingData();
        }

        private void BindingData()
        {
            ItemService service1 = new ItemService();
            items = service1.GetAllItem();
            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = items;
        }

        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
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
                        ItemPopUp frm = new ItemPopUp(userID);
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
                        ItemVO pItem = new ItemVO();
                        pItem.Item_Code = jeansGridView1.Rows[row].Cells[2].Value.ToString();
                        pItem.Item_Importins = jeansGridView1.Rows[row].Cells[10].Value == null ? "" : jeansGridView1.Rows[row].Cells[10].Value.ToString();
                        pItem.Item_InWarehouse = jeansGridView1.Rows[row].Cells[7].Value == null ? "" : jeansGridView1.Rows[row].Cells[7].Value.ToString();
                        pItem.Item_Manager = jeansGridView1.Rows[row].Cells[13].Value == null ? "" : jeansGridView1.Rows[row].Cells[13].Value.ToString();
                        pItem.Item_Name = jeansGridView1.Rows[row].Cells[3].Value == null ? "" : jeansGridView1.Rows[row].Cells[3].Value.ToString();
                        pItem.Item_OrderComp = jeansGridView1.Rows[row].Cells[6].Value == null ? "" : jeansGridView1.Rows[row].Cells[6].Value.ToString();
                        pItem.Item_Other = jeansGridView1.Rows[row].Cells[18].Value == null ? "" : jeansGridView1.Rows[row].Cells[18].Value.ToString();
                        pItem.Item_OutWarehouse = jeansGridView1.Rows[row].Cells[8].Value == null ? "" : jeansGridView1.Rows[row].Cells[8].Value.ToString();
                        pItem.Item_Processins = jeansGridView1.Rows[row].Cells[11].Value == null ? "" : jeansGridView1.Rows[row].Cells[11].Value.ToString();
                        pItem.Item_SafeQuantity = Convert.ToInt32(jeansGridView1.Rows[row].Cells[9].Value);
                        pItem.Item_Shipmentins = jeansGridView1.Rows[row].Cells[12].Value == null ? "" : jeansGridView1.Rows[row].Cells[12].Value.ToString();
                        pItem.Item_Size = jeansGridView1.Rows[row].Cells[4].Value == null ? "" : jeansGridView1.Rows[row].Cells[4].Value.ToString();
                        pItem.Item_Type = jeansGridView1.Rows[row].Cells[1].Value == null ? "" : jeansGridView1.Rows[row].Cells[1].Value.ToString();
                        pItem.Item_Unit = jeansGridView1.Rows[row].Cells[5].Value == null ? "" : jeansGridView1.Rows[row].Cells[5].Value.ToString();
                        pItem.Item_UserOrNot = jeansGridView1.Rows[row].Cells[17].Value == null ? "" : jeansGridView1.Rows[row].Cells[17].Value.ToString();
                        pItem.Item_OutSourcing = jeansGridView1.Rows[row].Cells[16].Value == null ? "" : jeansGridView1.Rows[row].Cells[16].Value.ToString();

                        ItemPopUp frm = new ItemPopUp(userID);
                        frm.Item = pItem;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            BindingData();
                        }
                    }
                }

                }

        }
        private void New(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                BindingData();
        }
        private void Search(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
              string sg =    GetSearchCondition(panel1);
                if (sg.Length < 1)
                    return;
                ItemService service = new ItemService();
                items = service.SearchItem(sg);
                jeansGridView1.DataSource = null;
                jeansGridView1.DataSource = items;

                if (items.Count != 0)
                {
                    foreach (Control Pitem in panel1.Controls)
                    {
                        foreach (Control item in Pitem.Controls)
                        {
                            if (item is ComboBox)
                            {
                                ((ComboBox)item).SelectedValue = "";
                            }
                            else if (item is TextBox)
                            {
                                item.Text = "";
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }
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
                            sb.Add($"{item.Tag.ToString()}='{((ComboBox)item).Text}'");
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
            {
                List<string> sb = new List<string>();
                jeansGridView1.EndEdit();
                for (int i = 0; i < jeansGridView1.RowCount; i++)
                {
                    bool isn = Convert.ToBoolean(jeansGridView1.Rows[i].Cells["chk"].Value);
                    if (isn)
                    {
                        sb.Add(jeansGridView1.Rows[i].Cells[2].Value.ToString());
                    }
                }
                if (sb.Count < 1)
                {
                    MessageBox.Show("삭제할 항목을 선택해주세요");
                    return;
                }
                string condition = string.Join("@", sb);
                ItemService service = new ItemService();
                if (service.DeleteItem(condition))
                {
                    MessageBox.Show("삭제되었습니다.");
                }
                else
                    MessageBox.Show("삭제에 실패하였습니다.");

                BindingData();
            }
        }
        private void Excel(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                Excels.Application xlApp;
                Excels.Workbook xlWorkBook;
                Excels.Worksheet xlWorkSheet;

                saveFileDialog1.Filter = "Excel Files(*.xls)|*.xls";
                saveFileDialog1.Title = "품목 목록 저장";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xlApp = new Excels.Application();
                    xlWorkBook = xlApp.Workbooks.Open(Application.StartupPath + "\\ExcelTemplete\\품목.xls");
                    xlWorkSheet = xlWorkBook.Worksheets.get_Item(1);
                    xlApp.Visible = false;

                    for (int i = 0; i < jeansGridView1.Rows.Count - 1; i++)
                    {
                        for (int k = 0; k < jeansGridView1.Columns.Count; k++)
                        {
                            if (jeansGridView1[0, 0].Visible == false)
                                break;
                            xlWorkSheet.Cells[i + 0, k + 1] = jeansGridView1[k, i].Value.ToString();
                        }
                    }

                    xlWorkBook.SaveAs(saveFileDialog1.FileName, Excels.XlFileFormat.xlWorkbookNormal);
                    xlWorkBook.Close(true);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                }
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void ItemManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save -= Save;
            frm.Search -= Search;
            frm.Delete -= Delete;
            frm.New -= New;
            frm.Excel -= Excel;
        }
    }
}
