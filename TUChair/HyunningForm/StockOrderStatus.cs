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
    public partial class StockOrderStatus : TUChair.SearchCommomForm
    {
        List<CProductOutVO> list;
        List<ComboItemVO> comboItems = null;

        public StockOrderStatus()
        {
            InitializeComponent();
            jeansGridView1.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "납기일", "So_Duedate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "잔여수량", "N_Qty", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "From창고", "Fact_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "From창고재고", "Qty", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "To창고", "ToFact", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "이동수량", "Out_Unit", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "", "So_WorkOrderID", true);
            jeansGridView1.Columns[9].ReadOnly = false;
            jeansGridView1.Columns[10].Visible = false;
            DataLoad();

            commonService service = new commonService();

            comboItems = service.getCommonCode("완제품");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "완제품"
                                       select item).ToList();
            CommonUtil.ComboBinding(cboItemCode, cList, "선택");
        }
        private void Search(object sender, EventArgs e)
        {

            //string Fact;
            //if (cboFact.SelectedIndex == 0)
            //    Fact = string.Empty;
            //else
            //    Fact = cboFact.Text;



            //if (cboFact.SelectedIndex == 0 && cboItemCode.SelectedIndex == 0 && cboGubun.SelectedIndex == 0 && cboCategory.SelectedIndex == 0 && cboItemtype.SelectedIndex == 0)
            //    return;
            //if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            //{
            //    JeanServicePShift service = new JeanServicePShift();
            //    Inoutlist = service.InOutSearch(Fact, Gubun, Category, itype, start, end, Icode);
            //    jeansGridView1.DataSource = null;
            //    jeansGridView1.DataSource = Inoutlist;
            //}

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
                cboItemCode.SelectedIndex = 0;               
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
        private void DataLoad()
        {
            JeanProductOut jean = new JeanProductOut();
            list = jean.CProductBinding();
            jeansGridView1.DataSource = list;
        }

        private void StockOrderStatus_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
              for (int i = 0; i < jeansGridView1.Rows.Count; i++)
                {

                    bool isCellChecked = (bool)jeansGridView1.Rows[i].Cells[0].EditedFormattedValue;
                    if (isCellChecked)
                    {
                        string Item = jeansGridView1.Rows[i].Cells[1].Value.ToString();
                        string Fact = jeansGridView1.Rows[i].Cells[6].Value.ToString();
                        string Modifier = LoginFrm.userName;
                        string primary = jeansGridView1.Rows[i].Cells[10].Value.ToString();
                        int Qty = (Convert.ToInt32(jeansGridView1.Rows[i].Cells[9].Value));

                        JeanServicePShift shift = new JeanServicePShift();
                        shift.ShiftProduct(Item, Fact, Modifier, Qty, primary);
                    }
                    if (Convert.ToInt32(jeansGridView1.Rows[i].Cells[9].Value) == 0)
                    {
                        MessageBox.Show("이동 수량을 입력해주세요");
                        return;
                    }
                }
                MessageBox.Show("공정이동이 완료되었습니다.");
            
            DataLoad();
        }

        private void jeansGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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
            if ((int)jeansGridView1.Rows[rowIndex].Cells[5].Value < (int)jeansGridView1.Rows[rowIndex].Cells[9].Value)
            {
                MessageBox.Show("이동수량은 현재고를 넘을수 없어");
                jeansGridView1.Rows[rowIndex].Cells[9].Value = 0;
                return;
            }
         
        }

        private void StockOrderStatus_FormClosing(object sender, FormClosingEventArgs e)
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
