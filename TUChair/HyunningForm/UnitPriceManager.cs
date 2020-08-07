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
    public partial class UnitPriceManager : TUChair.SearchCommomForm
    {
        List<ViewUnitPriceVO> list;
        List<ComboItemVO> comboItems = null;

        public UnitPriceManager()
        {
            InitializeComponent();
        }

        private void UnitPriceManager_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;

            jeansGridView1.IsAllCheckColumnHeader = true;
            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "PriceNO", "PriceNO", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "업체코드", "Com_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "업체명", "Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "단위", "Item_Unit", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "현재단가", "Price_Present", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "이전단가", "Price_transfer", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "시작일", "Price_StartDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "종료일", "Price_EndDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "사용유무", "Price_UserOrNot", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정자", "Modifier", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정일", "ModifierDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "비고", "Unit_Other", true);


            commonService service = new commonService();
            comboItems = service.getCommonCode("협력업체");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "협력업체"
                                       select item).ToList();
            CommonUtil.ReComboBinding(cboCompany, cList, "선택");

            DataLoad();



        }
        public void CheckedDelete(string Talk)
        {
            try
            {
                for (int i = 0; i < jeansGridView1.Rows.Count; i++)
                {
                    bool isCellChecked = (bool)jeansGridView1.Rows[i].Cells[0].EditedFormattedValue;
                    if (isCellChecked)
                    {
                        int Primary = (Convert.ToInt32(jeansGridView1.Rows[i].Cells[1].Value));
                        JeanService jsv = new JeanService();
                        jsv.Delete(Primary);
                    }
                    
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            DataLoad();
        }


        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                UnitPricePopUp frm = new UnitPricePopUp();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            DataLoad();
        }
        private void New(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                DataLoad();
        }
        private void Search(object sender, EventArgs e)
        {
            string date;
            if (chbDate.Checked == false)
                date = string.Empty;
            else
                date = dtpDate.Value.ToShortDateString().Trim();
            string cbo;
            if (cboCompany.SelectedIndex == 0)
                cbo = string.Empty;
            else
                cbo = cboCompany.Text;
            string txt = txtItemCode.Text.Trim();

            if (date.ToString().Trim().Length < 1 && txt.ToString().Trim().Length < 1 && cboCompany.SelectedIndex == 0)
                return;
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
               
                
                JeanService service = new JeanService();
                list = service.Search(date,txt,cbo);
                jeansGridView1.DataSource = null;
                jeansGridView1.DataSource = list;
            }
        }
        private void Delete(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                CheckedDelete("삭제할");
        }
        private void Excel(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("엑셀만들어");
        }
     
        private void DataLoad()
        {
            JeanService service = new JeanService();
            list = service.UPBinding();
            

            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = list;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            UnitPricePopUp frm = new UnitPricePopUp();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            DataLoad();
        }


        private void chbDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDate.Checked == true)
            {
                dtpDate.Enabled = true;
                dtpDate.Format = DateTimePickerFormat.Short;
            }
            else
            {
                dtpDate.Enabled = false;
                dtpDate.Format = DateTimePickerFormat.Custom;
                dtpDate.CustomFormat = " ";
            }
        }

    }
}
