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
            comboItems = service.getCommonCode("업체");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "업체"
                                       select item).ToList();
            CommonUtil.ReComboBinding(cboCompany, cList, "선택");

            DataLoad();



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
                string sg = GetSearchCondition(panel1);

                MessageBox.Show(sg);
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
        private string GetSearchCondition(Panel panel1)
        {
            List<string> sb = new List<string>();
            foreach (Control Pitem in panel1.Controls)
            {
                foreach (Control item in Pitem.Controls)
                {

                    if (item is ComboBox)
                    {
                        if (item.Text != "선택")
                            sb.Add($"{item.Tag.ToString()}='{((ComboBox)item).Text}'");
                    }
                    else if (item is TextBox)
                    {
                        if (item.Text != "")
                            sb.Add($"{item.Tag.ToString()} like '%{item.Text}%'");
                    }
                    else if (item is DateTimePicker)
                    {
                        if (item.Text != "")
                            sb.Add($"{((DateTimePicker)item).ToString()}");
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return String.Join(" and ", sb);
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
                dateTimePicker1.Enabled = true;
                dateTimePicker1.Format = DateTimePickerFormat.Short;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = " ";
            }
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            JeanService jean = new JeanService();
            List<ViewUnitPriceVO> Searchlist = new List<ViewUnitPriceVO>();
            if (txtItemCode.Text.Length > 0)
            {
                Searchlist = jean.SearchText(txtItemCode.Text);
                jeansGridView1.DataSource = Searchlist;
            }
            else
                jeansGridView1.DataSource = list;
        }
    }
}
