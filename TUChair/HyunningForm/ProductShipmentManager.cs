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
    public partial class ProductShipmentManager : TUChair.SearchCommomForm
    {
        List<ProductOutVO> list;
        List<ComboItemVO> comboItems = null;



        public ProductShipmentManager()
        {
            InitializeComponent();

            jeansGridView1.IsAllCheckColumnHeader = true;
            CommonUtil.InitSettingGridView(jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "고객주문번호", "So_PurchaseOrder", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "납기일", "So_Duedate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "작업지시번호", "So_WorkOrderID", true,150);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "고객사코드", "Com_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "고객사", "Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "도착지코드", "Com_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "도착지", "Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "고객사 품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "Item_name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "현재단가", "Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "주문수량", "So_Qty", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "출하된 수량", "So_ProQty", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "출하 수량", "Out_Unit", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "재고 수량", "Fact_Qty", true, 100, DataGridViewContentAlignment.MiddleRight);
            jeansGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;

            jeansGridView1.Columns[14].ReadOnly = false;
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
                list = service.PSMSearch(Ccode, start, end, comno, item);
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
                cboComcode.SelectedIndex = 0;
                txtComNo.Text = string.Empty;
                txtItem.Text = string.Empty;

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
        private void btnShift_Click(object sender, EventArgs e)
        {
            int c = 0;
            for (int i = 0; i < jeansGridView1.Rows.Count; i++)
            {

                bool isCellChecked = (bool)jeansGridView1.Rows[i].Cells[0].EditedFormattedValue;
                if (isCellChecked)
                {
                    string Primary = jeansGridView1.Rows[i].Cells[1].Value.ToString();
                    string Item = jeansGridView1.Rows[i].Cells[9].Value.ToString();
                    string Modifier = LoginFrm.userName;
                    int Price = Convert.ToInt32(jeansGridView1.Rows[i].Cells[11].Value.ToString());
                    int Qty = (Convert.ToInt32(jeansGridView1.Rows[i].Cells[14].Value));

                    JeanServicePShift shift = new JeanServicePShift();
                    shift.OutProduct(Primary, Item, Price, Modifier, Qty);
                    if (Convert.ToInt32(jeansGridView1.Rows[i].Cells[14].Value) == 0)
                    {
                        MessageBox.Show("출하 수량을 입력해주세요.");
                        return;
                    }
                    c++;
                }
            }
            if (c > 0)
            {
                MessageBox.Show("제품 출하가 완료되었습니다.");
                DataLoad();
            }
            else if (c == 0)
                MessageBox.Show("제품 출하할 항목을 선택해주세요");

        }

        private void DataLoad()
        {
            JeanProductOut jean = new JeanProductOut();
            list = jean.POutBinding();
            jeansGridView1.DataSource = list;
        }
        private void jeansGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)//그리드뷰 키프레스이벤트
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

        private void jeansGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = jeansGridView1.CurrentRow.Index;
            if ((int)jeansGridView1.Rows[rowIndex].Cells[12].Value < (int)jeansGridView1.Rows[rowIndex].Cells[13].Value + (int)jeansGridView1.Rows[rowIndex].Cells[14].Value)
            {
                MessageBox.Show("주문수량을 넘었습니다.");
                jeansGridView1.Rows[rowIndex].Cells[14].Value = 0;
                return;
            }
        }

        private void ProductShipmentManager_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
        }

        private void ProductShipmentManager_FormClosing(object sender, FormClosingEventArgs e)
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
