﻿using System;
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
using TUChair.WooForm;
using TUChairVO;

namespace TUChair
{
    public partial class IpGoWaiting : TUChair.SearchTwoGridForm
    {

        List<balzuVO> blazus = null;
        List<ComboItemVO> comboItems = null;

        public IpGoWaiting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> chkList = new List<int>();

            for (int i = 0; i < jeansGridView1.Rows.Count; i++)
            {
                bool isCellChecked = (bool)jeansGridView1.Rows[i].Cells[0].EditedFormattedValue;
                if (isCellChecked)
                {
                    chkList.Add(Convert.ToInt32(jeansGridView1.Rows[i].Cells[1].Value));
                }
            }
            if (chkList.Count == 0)
            {
                MessageBox.Show("출력할 바코드를 선택해주세요.");
                return;
            }

            string strChkBarCodes = string.Join(",", chkList);
            balzuService service = new balzuService();
            DataTable dt = service.GetBalzuReport(strChkBarCodes);

            IpGoReport2 rpt = new IpGoReport2();
            rpt.DataSource = dt;
            IpGoPreveiw frm = new IpGoPreveiw(rpt);
        }
        private void Readed_BarCode(object sender, ReadEventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                textBox1.Text = e.ReadMsg;
                ((TUChairMain2)this.MdiParent).Clearstrings();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 5)
            {
              int  barID = int.Parse(textBox1.Text.Trim().Replace("\r", "").Replace("\n", "").TrimStart('0'));
                
                string modifier = ((TUChairMain2)this.MdiParent).userInfoVO.CUser_ID;
                ItemService service1 = new ItemService();
                if (service1.IpGoUpdate(barID, modifier))
                {
                    MessageBox.Show("입고완료되었습니다.");
                }
                bindbalzu();
            }
        }
        private void IpGoWaiting_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
          
            
            commonService service = new commonService();
            comboItems = service.getCommonCode("협력사@User@사용여부@반제품@원자재");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "협력사"
                                       select item).ToList();
            CommonUtil.ComboBinding(cboCom, cList, "선택");

            cList = (from item in comboItems
                     where item.CodeType == "반제품" || item.CodeType=="원자재"
                     select item).ToList();
            CommonUtil.ReComboBinding(cboItem, cList, "선택");

            ((TUChairMain2)this.MdiParent).Readed += Readed_BarCode;
            jeansGridView1.IsAllCheckColumnHeader = true;
            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이디", "ID", false);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "발주아이디", "Vo_ID", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "발주일자", "Vo_StarDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "발주업체", "Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "단위", "Item_Unit", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수량", "Vo_Quantity", true,60, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "가격", "Vo_Price", true,100,DataGridViewContentAlignment.MiddleRight);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "발주상태", "Materail_Order_State", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "납기일자", "Vo_EndDate", true);

            CommonUtil.InitSettingGridView(jeansGridView2);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "아이디", "ID", false);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "발주아이디", "Vo_ID", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "발주일자", "Vo_StarDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "발주업체", "Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "단위", "Item_Unit", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "수량", "Vo_Quantity", true,60, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "가격", "Vo_Price", true,100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "발주상태", "Materail_Order_State", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "납기일자", "Vo_EndDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "입고일자", "Vo_InDate", true);

            bindbalzu();
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
           

            int barID = 0;
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
                barID = Convert.ToInt32(jeansGridView1.Rows[row].Cells[1].Value);
                string modifier = ((TUChairMain2)this.MdiParent).userInfoVO.CUser_ID;
                if (cnt > 1)
                {
                    MessageBox.Show("입고처리는 하나씩만 가능합니다.");
                    return;
                }
                else
                {
                    ItemService service1 = new ItemService();
                   if( service1.IpGoUpdate(barID, modifier))
                    {
                        MessageBox.Show("입고완료되었습니다.");
                    }
                    bindbalzu();
                }
            }
        }
        private void bindbalzu()
        {
            balzuService service = new balzuService();
            DataTable dt = service.GetBalzuMiip();
            jeansGridView2.DataSource = null;
            jeansGridView2.DataSource = dt;

            DataTable dt2 = service.GetBalzuMi();
            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = dt2;
        }

        private void IpGoWaiting_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((TUChairMain2)this.MdiParent).Readed -= Readed_BarCode;
        }
    }
}
