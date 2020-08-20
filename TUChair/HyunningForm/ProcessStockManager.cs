using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;
using TUChairVO;

namespace TUChair
{
    public partial class ProcessStockManager : TUChair.SearchCommomForm
    {
        List<PSMManager> list;
        List<ComboItemVO> comboItems = null;

        public ProcessStockManager()
        {
            InitializeComponent();

   


            jeansGridView1.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "창고코드", "Fact_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "창고", "Fact_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "Item_Code", true,140);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목타입", "Item_Type", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "재고", "Qty", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "단위", "Item_Unit", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "비고", "Stock_Other", true,200);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "이동날자", "Insert_Date", true,200);


            commonService service = new commonService();
            comboItems = service.getCommonCode("창고@Item");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "창고"
                                       select item).ToList();
            CommonUtil.ReComboBinding(cboFact, cList, "선택");
            cList = (from item in comboItems
                     where item.CodeType == "Item"
                     select item).ToList();
            CommonUtil.ReComboBinding(cboItemCode, cList, "선택");
        }
        private void ProcessStockManager_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
            DataLoad();
        }

        public void DataLoad()
        {
            JeanServicePShift service = new JeanServicePShift();
            list = service.PSMManager();

            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = list;
        }

        private void ProcessStockManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save -= Save;
            frm.Search -= Search;
            frm.Delete -= Delete;
            frm.New -= New;
            frm.Excel -= Excel;
        }
       

        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("저장할게 없지롱");

        }
        private void New(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                cboFact.SelectedIndex = 0;
                cboItemCode.SelectedIndex = 0;
                txtItemCode.Text = "";
                DataLoad();
            }
        }
        private void Search(object sender, EventArgs e)
        {
           
            string item;
            if (cboItemCode.SelectedIndex == 0)
                item = string.Empty;
            else
                item = cboItemCode.Text;
            string Fact;
            if (cboFact.SelectedIndex == 0)
                Fact = string.Empty;
            else
                Fact = cboFact.Text;
            string txt = txtItemCode.Text.Trim();

            if (/*date.ToString().Trim().Length < 1 &&*/ txt.ToString().Trim().Length < 1 && cboItemCode.SelectedIndex == 0 && cboFact.SelectedIndex == 0)
                return;
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {


                JeanServicePShift service = new JeanServicePShift();
                list = service.PSMMSearch( item, Fact, txt);
                jeansGridView1.DataSource = null;
                jeansGridView1.DataSource = list;
            }
        }
        private void Delete(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("솩줴");

        }
        private void Excel(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("엑셀만들어");

        }
    }
}
