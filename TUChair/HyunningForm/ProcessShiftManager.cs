﻿using DevExpress.CodeParser;
using JeanForm;
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
using TUChairDAC;
using TUChairVO;

namespace TUChair
{
    public partial class ProcessShiftManager : TUChair.SearchCommomForm
    {
        List<ProcessShiftVO> list;
        List<ProcessShiftVO> Shiftview;
        List<StockShift> Shiftlist;


        List<EXProcessShiftVO> list1;
        List<ComboItemVO> comboItems = null;
        public ProcessShiftManager()
        {


            InitializeComponent();
            jeansGridView1.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "No.", "No", true,50);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "Item_Code", true,140);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "창고코드", "Fact_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "참고이름", "Fact_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "창고타입", "Fact_Type", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "이동일자", "Insert_Date", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수량", "Qty", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "단위", "Item_Unit", true,50);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "비고", "Stock_Other", true,200);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목타입", "Item_Type", true);

            jeansGridView2.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(jeansGridView2);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "No.", "No", true, 50);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "품목", "Item_Code", true,140);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "품목타입", "Item_Type", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "현재창고", "Fact_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "현재고", "Qty", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "이동창고", "From_Fact", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "이동일자", "Shift_date", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "이동수량", "Shift_Qty", true, 100, DataGridViewContentAlignment.MiddleRight);
            jeansGridView2.SelectionMode = DataGridViewSelectionMode.CellSelect;
            
            jeansGridView2.Columns[10].ReadOnly = false;


            DataLoad();

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

            cList = (from item in comboItems
                     where item.CodeType == "창고"
                     select item).ToList();
            cList.RemoveRange(4, 2);
            CommonUtil.ReComboBinding(cboInsertF, cList, "선택");
        }
        private void btnShift_P_Click(object sender, EventArgs e)
        {
            if (cboInsertF.SelectedIndex == 0)
            {
                MessageBox.Show("창고를 선택해주세요");
                return;
            }
            for (int i = 0; i < jeansGridView2.Rows.Count; i++)
            {
                
                bool isCellChecked = (bool)jeansGridView2.Rows[i].Cells[0].EditedFormattedValue;
                if (isCellChecked)
                {
                    int Primary = (Convert.ToInt32(jeansGridView2.Rows[i].Cells[1].Value));
                    string Item = jeansGridView2.Rows[i].Cells[2].Value.ToString();
                    string Fact = jeansGridView2.Rows[i].Cells[6].Value.ToString();
                    string From_Fact = cboInsertF.Text;
                    string Modifier = LoginFrm.userName;
                    int Qty = (Convert.ToInt32(jeansGridView2.Rows[i].Cells[10].Value));

                    JeanServicePShift shift = new JeanServicePShift();
                    shift.ThisIsShift(Primary, Item, Fact, From_Fact, Modifier, Qty);
                }
                else
                {
                    MessageBox.Show("이동시킬 목록을 체크박스로 선택해주세요");
                    return;
                }
                if (Convert.ToInt32(jeansGridView2.Rows[i].Cells[10].Value) == 0)
                {
                    MessageBox.Show("이동 수량을 입력해주세요");
                    return;
                }
            }
            MessageBox.Show("공정이동이 완료되었습니다.");
            DataLoad();
            jeansGridView2.DataSource = null;
        }
        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("헤헤 수정");

            DataLoad();
        }
        private void New(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                cboFact.SelectedIndex = 0;
                cboItemCode.SelectedIndex = 0;
                DataLoad();
            }
        }
        private void Search(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                string Fact;
                if (cboFact.SelectedIndex == 0)
                    Fact = string.Empty;
                else
                    Fact = cboFact.Text;
                string code;
                if (cboItemCode.SelectedIndex == 0)
                    code = string.Empty;
                else
                    code = cboItemCode.Text;
                string txt = txtItemName.Text.Trim();

                if (cboFact.SelectedIndex == 0 && txt.ToString().Trim().Length < 1 && cboItemCode.SelectedIndex == 0)
                    return;
                if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                {


                    JeanServicePShift service = new JeanServicePShift();
                    list = service.Search(Fact, code, txt);
                    jeansGridView1.DataSource = null;
                    jeansGridView1.DataSource = list;
                }
            }


        }
        private void Delete(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("삭제하던가");

        }
        private void Excel(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("엑셀만들어");
        }
        public void CheckedLine(JeansGridView jeans, string Talk)
        {
            int Primary = 0;
            for (int i = 0; i < jeans.RowCount; i++)
            {
                bool isCellChecked = (bool)jeans.Rows[i].Cells[0].EditedFormattedValue;
                if (isCellChecked)
                {
                    Primary = (Convert.ToInt32(jeans.Rows[i].Cells[1].Value));
                }

            }
            if (Primary == 0)
            {
                MessageBox.Show($"{Talk} 행를 선택해주세요.");
                return;
            }
        }
        public void DataLoad()
        {
            JeanServicePShift service = new JeanServicePShift();
            list = service.PSBinding();



            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = list;


            JeanServicePShift sv = new JeanServicePShift();
            Shiftview = sv.ShiftLoad();
            jeansGridView2.DataSource = null;

        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            JeanServicePShift shift = new JeanServicePShift();

            try
            {
                for (int i = 0; i < jeansGridView1.Rows.Count; i++)
                {
                    bool isCellChecked = (bool)jeansGridView1.Rows[i].Cells[0].EditedFormattedValue;
                    if (isCellChecked)
                    {
                        int Primary = (Convert.ToInt32(jeansGridView1.Rows[i].Cells[1].Value));
                        string fact = jeansGridView1.Rows[i].Cells[4].Value.ToString();

                        shift.PSShiftInsert(Primary, fact); 

                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            DataLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JeanServicePShift service = new JeanServicePShift();
            list1 = service.Bacode();
            DataTable dt = null;
            dt = Helper.ConvertToDataTable<EXProcessShiftVO>(list1);

            HyunningForm.XtraReport2 rpt = new HyunningForm.XtraReport2();
            rpt.DataSource = dt;
            PreviewForm frm = new PreviewForm(rpt);
        }
        private void Readed_BarCode(object sender, ReadEventArgs e)
        {
            textBox1.Text = e.ReadMsg;
            string a = textBox1.Text.Substring(0, 4);
            string b = textBox1.Text.Substring(6, 1);

            ProcessShiftVO sht = new ProcessShiftVO();
            JeanServicePShift shift = new JeanServicePShift();

            bool result = shift.PSShiftInsert(a, b);

            if (result)
            {
                MessageBox.Show("공정이동이 완료되었습니다.", "공정이동");
            }
            DataLoad();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                btnSelect.PerformClick();
            }
        }

        private void ProcessShiftManager_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
            frm.Readed += Readed_BarCode;

        }

        private void btnShiftCancle_Click(object sender, EventArgs e)
        {

            if (jeansGridView2.Rows.Count < 1)
                return;
            else
            {
                List<StockShift> list = (List<StockShift>)jeansGridView2.DataSource;
                for (int i = jeansGridView2.Rows.Count - 1; i > -1; i--)
                {
                    bool isCellChecked = (bool)jeansGridView2.Rows[i].Cells[0].EditedFormattedValue;
                    if (isCellChecked)
                    {
                        //int Primary = (Convert.ToInt32(jeansGridView2.Rows[i].Cells[1].Value));
                        list.RemoveAt(i);
                    }
                }
            }
        }


        private void ProcessShiftManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save -= Save;
            frm.Search -= Search;
            frm.Delete -= Delete;
            frm.New -= New;
            frm.Excel -= Excel;
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            JeanServicePShift shift = new JeanServicePShift();

            List<int> pList = new List<int>();
            for (int i = 0; i < jeansGridView1.Rows.Count; i++)
            {
                bool isCellChecked = (bool)jeansGridView1.Rows[i].Cells[0].EditedFormattedValue;
                if (isCellChecked && (Convert.ToInt32(jeansGridView1.Rows[i].Cells[8].Value) != 0))
                {
                    
                    int Primary = (Convert.ToInt32(jeansGridView1.Rows[i].Cells[1].Value));
                    pList.Add(Primary);
                }
            }
            if (pList.Count > 0)
            {
                Shiftlist = shift.StockBinding(string.Join(",", pList));
                jeansGridView2.DataSource = Shiftlist;
            }
        }



        private void jeansGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)//그리드뷰 키프레스이벤트
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;

            }

        }

        private void jeansGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = jeansGridView2.CurrentRow.Index;
            if ((int)jeansGridView2.Rows[rowIndex].Cells[7].Value < (int)jeansGridView2.Rows[rowIndex].Cells[10].Value)
            {
                MessageBox.Show("이동수량은 현재고를 넘을수 없습니다.");
                jeansGridView2.Rows[rowIndex].Cells[10].Value = 0;
                return;
            }
        }

    
    }
}

