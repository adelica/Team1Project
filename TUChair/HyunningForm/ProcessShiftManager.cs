using DevExpress.CodeParser;
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

        List<EXProcessShiftVO> list1;
        List<ComboItemVO> comboItems = null;
        public  ProcessShiftManager()
        {
            

            InitializeComponent();
            jeansGridView1.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "No.", "No", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "창고코드", "Fact_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "참고이름", "Fact_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "창고타입", "Fact_Type", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "이동일자", "Insert_Date", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수량", "Qty", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "단위", "Item_Unit", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "비고", "Stock_Other", true);

            jeansGridView2.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(jeansGridView2);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "No.", "No", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "창고코드", "Fact_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "참고이름", "Fact_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "창고타입", "Fact_Type", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "이동일자", "Insert_Date", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "수량", "Qty", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "단위", "Item_Unit", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "비고", "Stock_Other", true);

            DataLoad();

            commonService service = new commonService();
            comboItems = service.getCommonCode("창고@Item");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "창고"
                                       select item).ToList();
            CommonUtil.ComboBinding(cboFact, cList, "선택");
            cList = (from item in comboItems
                     where item.CodeType == "Item"
                     select item).ToList();
            CommonUtil.ReComboBinding(cboItemCode, cList, "선택");

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
                DataLoad();
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
        public void CheckedLine(JeansGridView jeans,string Talk)
        {
            int Primary = 0;
            for (int i=0;  i < jeans.RowCount; i++)
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
            jeansGridView2.DataSource = Shiftview;

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

                       shift.PSShiftInsert(Primary,fact);

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

            bool result = shift.PSShiftInsert(a,b);

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
                btnShift.PerformClick();
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
            ProcessShiftVO sht = new ProcessShiftVO();
            JeanServicePShift shift = new JeanServicePShift();

            for (int i = 0; i < jeansGridView2.Rows.Count; i++)
            {
                bool isCellChecked = (bool)jeansGridView2.Rows[i].Cells[0].EditedFormattedValue;
                if (isCellChecked)
                {
                    int Primary = (Convert.ToInt32(jeansGridView2.Rows[i].Cells[1].Value));
                    string fact = jeansGridView2.Rows[i].Cells[4].Value.ToString();
                    string date = jeansGridView2.Rows[i].Cells[7].Value.ToString();
                    shift.PSShiftReturn(Primary, date, fact);

                }

            }
            //if (result)
            //{
            //    MessageBox.Show("공정이동이 완료되었습니다.", "공정이동");
            //}
            DataLoad();
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
    }
}

