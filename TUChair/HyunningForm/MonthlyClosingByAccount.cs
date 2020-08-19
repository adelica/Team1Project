using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;
using TUChairDAC;
using TUChairVO;

namespace TUChair
{
    public partial class MonthlyClosingByAccount : TUChair.SearchCommomForm
    {
        List<MonthDeadLineVO> list;
        List<ComboItemVO> comboItems = null;
        List<StockShift> Shiftlist;

        public MonthlyClosingByAccount()
        {
            InitializeComponent();
            jeansGridView1.IsAllCheckColumnHeader = true;
            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "업체코드", "Com_code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "업체명", "Com_name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "사업자번호", "CorporRegiNum", true);
            //CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "금액", "ALLPrice", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "매출 or 매입", "Type", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "마감", "YorN", true);
            jeansGridView1.Columns[6].Visible = false;


            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "업체명", "Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "납품업체명(도착지)", "Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "입출고일", "Date", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "창고", "Fact_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "카테고리", "Category", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "수불량", "Qty", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "단가", "Price", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "금액", "AllPrice", true);

            dataLoad();
            string[] year = new string[25];
            year[0] = "==선택==";
            for (int i = 1; i < year.Length; i++)
            {
                year[i] = DateTime.Now.AddMonths(-i+1).ToString("yyyy-MM");
            }
            
            cboDate.DataSource = year;
            cboDate.SelectedIndex = 0;
        }

        public void dataLoad()
        {
            JeanMagamService service = new JeanMagamService();
            list = service.AllMagamBind();
            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = list;
        }

        
        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("저장할게없지롱");
           
        }
        private void New(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("새로고침 할게없지롱");
        }
        private void Search(object sender, EventArgs e)
        {
            
            string date;
            if (cboDate.SelectedIndex == 0)
                date = string.Empty;
            else
                date = cboDate.Text;
            string com;
            if (cboCom.SelectedIndex == 0)
                com = string.Empty;
            else
                com = cboCom.Text;
            string type;
            if (cboType.SelectedIndex == 0)
                type = string.Empty;
            else
                type = cboType.Text;

            if (cboDate.SelectedIndex == 0 && cboCom.SelectedIndex == 0 && cboType.SelectedIndex == 0)
                return;
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {


                JeanService service = new JeanService();
                list = service.MonthSearch(date, type, com);
                jeansGridView1.DataSource = null;
                jeansGridView1.DataSource = list;

            }
        }
        private void Delete(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("삭제할");
        }
        private void Excel(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("엑셀만들어");
        }

        private void MonthlyClosingByAccount_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;

        }

        private void MonthlyClosingByAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save -= Save;
            frm.Search -= Search;
            frm.Delete -= Delete;
            frm.New -= New;
            frm.Excel -= Excel;
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            JeanServicePShift shift = new JeanServicePShift();

            List<string> pList = new List<string>();
            for (int i = 0; i < jeansGridView1.Rows.Count; i++)
            {
                bool isCellChecked = (bool)jeansGridView1.Rows[i].Cells[0].EditedFormattedValue;
                if (isCellChecked)
                {

                    string Primary = jeansGridView1.Rows[i].Cells[1].Value.ToString();
                    pList.Add(Primary);
                }
            }
            if (pList.Count > 0)
            {
                //Shiftlist = shift.StockBinding(string.Join(",", pList));
                //jeansGridView2.DataSource = Shiftlist;
            }
        }
    }
}
