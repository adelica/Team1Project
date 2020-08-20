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
    public partial class SalesClosing : TUChair.SearchCommomForm
    {
        List<ProductClosingVO> list = new List<ProductClosingVO>();

        List<ComboItemVO> comboItems = null;

        public SalesClosing()
        {
            InitializeComponent();


            jeansGridView1.IsAllCheckColumnHeader = true;
            CommonUtil.InitSettingGridView(jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "고객주문번호", "So_PurchaseOrder", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "고객사 명", "Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "도착지 명", "d_Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "고객사 품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "d_Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "Item_name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "주문수량", "So_Qty", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "출하수량", "So_ProQty", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "현재단가", "Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "매출확정금액", "total", true, 140, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "마감처리자", "Modifier", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "납기일자", "So_Duedate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "마감일자", "So_OutDate", true);
            DataLoad();

            commonService service = new commonService();

            comboItems = service.getCommonCode("고객사");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "고객사"
                                       select item).ToList();
            CommonUtil.ComboBinding(cboComcode, cList, "선택");
        }
        private void Search(object sender, EventArgs e)
        {

            string Ccode;
            if (cboComcode.SelectedIndex == 0)
                Ccode = string.Empty;
            else
                Ccode = cboComcode.Text;

            string start = inDTP1.Start.ToShortDateString();
            string end = inDTP1.End.ToShortDateString();

            string comno = txtComNo.Text.Trim();
            string item = txtItem.Text.Trim();


            if (cboComcode.SelectedIndex == 0 && comno.ToString().Trim().Length < 1 && item.ToString().Trim().Length < 1)
                return;
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                JeanServicePShift service = new JeanServicePShift();
                list = service.ClosingSearch(Ccode, start, end, comno, item);
                jeansGridView1.DataSource = null;
                jeansGridView1.DataSource = list;
            }

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
                //cboFact.SelectedIndex = 0;
                //cboItemCode.SelectedIndex = 0;
                //cboGubun.SelectedIndex = 0;
                //cboCategory.SelectedIndex = 0;
                //cboItemtype.SelectedIndex = 0;


                DataLoad();
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
        private void btnPclosing_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < jeansGridView1.Rows.Count; i++)
            {
                bool isCellChecked = (bool)jeansGridView1.Rows[i].Cells[0].EditedFormattedValue;
                if (isCellChecked)
                {
                    string Primary = jeansGridView1.Rows[i].Cells[1].Value.ToString();
                    string Item = jeansGridView1.Rows[i].Cells[4].Value.ToString();
                    int Qty = Convert.ToInt32(jeansGridView1.Rows[i].Cells[8].Value.ToString());

                    string Modifier = LoginFrm.userName;

                    JeanServicePShift shift = new JeanServicePShift();
                    shift.PCDeadline(Primary, Item, Qty, Modifier);

                }
            }
            DataLoad();
        }
        private void SalesClosing_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
        }
        public void DataLoad()
        {
            JeanServicePShift jeans = new JeanServicePShift();
            list = jeans.PClosing();
            jeansGridView1.DataSource = list;
        }

        private void SalesClosing_FormClosing(object sender, FormClosingEventArgs e)
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
