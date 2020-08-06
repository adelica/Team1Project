﻿using System;
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
    public partial class MarketingUnitPriceManger : TUChair.SearchCommomForm
    {
        List<ViewUnitPriceVO> list;
        List<ComboItemVO> comboItems = null;

        public MarketingUnitPriceManger()
        {
            InitializeComponent();
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
            comboItems = service.getCommonCode("고객사");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "고객사"
                                       select item).ToList();
            CommonUtil.ReComboBinding(cboCompany, cList, "선택");


            DataLoad();
        }
        

        private void MarketingUnitPriceManger_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
        }
        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("저장이다2.");
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
                list = service.Search1(date, txt, cbo);
                jeansGridView1.DataSource = null;
                jeansGridView1.DataSource = list;

            }
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
        private void DataLoad()
        {

           
            JeanService service = new JeanService();
            list = service.ProductUPBinding();



            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = list;
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
                MarketingUnitPricePopUp frm = new MarketingUnitPricePopUp();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();

                DataLoad();
            
        }

        
    }
}
