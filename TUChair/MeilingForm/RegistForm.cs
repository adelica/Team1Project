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
    public partial class RegistForm : TUChair.SearchCommomForm
    {
        public RegistForm()
        {
            InitializeComponent();
        }

        private void RegistForm_Load(object sender, EventArgs e)
        {
            //selectWorkorder
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
           // frm.Save += Save;
            frm.Search += Search;
            //frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
           Setcolumn();
            DataBinding();
           
            ComboBinding();
            DataBinding();
          
        }

        private void Setcolumn()
        {
            jeansGridView1.IsAllCheckColumnHeader = true;

        CommonUtil.InitSettingGridView(jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "작업지시번호", "WorkOrderID", true);//1
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "생산계획번호", "Pro_ID", true);//2
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템코드", "Item_Code", true);//3
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템타입", "Item_Type", true);//3
            //CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템이름", "Item_Name", true);//4
            //CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "소진창고", "Item_InWarehouse", true);//5
            //CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "양품창고", "Item_OutWarehouse", true);//6
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획수량", "Plan_Qty", true);//7
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획일", "Plan_Date", true);//8
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "생산일", "Prd_Date", true);//8
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "지시상태", "Wo_State", true);//9
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획시작일", "Plan_StartTime", true);//10
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획마감일", "Plan_EndTime", true);//11
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "투입수량", "In_Qty_Main", true);//11
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "산출수량", "Out_Qty_Main", true);//11
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "생산수량", "Prd_Qty", true);//11
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "PlanID", "Sales_ID", true);//12
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "비고", "Remark", true);//13
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정일", "Up_Date", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정자", "Up_Emp", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "자재차감여부", "Deduction", true);
            jeansGridView1.Columns["Pro_ID"].Frozen = true;
        }

        private void ComboBinding()
        {
            List<string> ItemList = new List<string>();
            ItemList.Insert(0, "선택");
            for (int i = 0; i < jeansGridView1.RowCount; i++)
            {
                ItemList.Add(jeansGridView1.Rows[i].Cells[3].Value.ToString());
            };
            ItemList = ItemList.Distinct().ToList();

            cboItem.Items.AddRange(ItemList.ToArray());
            List<string> PlanIDList = new List<string>();
            PlanIDList.Insert(0, "선택");
            for (int i = 0; i < jeansGridView1.RowCount; i++)
            {
                PlanIDList.Add(jeansGridView1.Rows[i].Cells[13].Value.ToString());
            };
            PlanIDList = PlanIDList.Distinct().ToList();

            cboplanID.Items.AddRange(PlanIDList.ToArray());
        }

        private void DataBinding()
        {
            //jeansGridView1.IsAllCheckColumnHeader = true;
            jeansGridView1.RowHeadersVisible = false;
            MeilingService service = new MeilingService();
           
            List<WoOrderVO> list = service.selectWorkorder();
           // jeansGridView1.AutoGenerateColumns = true;
            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = list;

         
        }

        private void Search(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                //jeansGridView1.Columns.Clear();

                //Setcolumn();
                string sg = GetSearchCondition(panel4);
                if (sg.Length < 1)
                    return;
                MeilingService service = new MeilingService();
                List<WoOrderVO> list = service.SearchWorkOrderstatus(inDTP1.Start, inDTP1.End, sg);

                jeansGridView1.DataSource = null;
                jeansGridView1.DataSource = list;
            }
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
                    //else if (item is InDTP)
                    //{
                    //    if (item.Text != "")
                    //        sb.Add($"between{((InDTP)item).Start.ToString()}and {((InDTP)item).End.ToString()}");
                    //}
                    else
                    {
                        continue;
                    }
                }
            }
            MessageBox.Show(String.Join(" and ", sb));
            return String.Join(" and ", sb);
        }

        private void Excel(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                using (waitFrm frm = new waitFrm(ExportOrderList))
                {
                    frm.ShowDialog(this);
                }
            }
        }
        private void ExportOrderList()
        {
            string sResult = ExcelExportImport.ExportToDataGridView<ShiftVO>(
                (List<ShiftVO>)jeansGridView1.DataSource, "");
            if (sResult.Length > 0)
            {
                MessageBox.Show(sResult);
            }
        }
        private void New(object sender, EventArgs e)
        {
            DataBinding();
        }

        //private void Save(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void RegistForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;

            frm.Search -= Search;
           // frm.Save -= Save;
            frm.New -= New;
            frm.Excel -= Excel;
        }

        private void button1_Click(object sender, EventArgs e)//작업실적등록
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
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
                string userID = ((TUChairMain2)this.MdiParent).userInfoVO.CUser_ID;
                if (cnt == 1)
                {

                    RegistFormPopUp frm = new RegistFormPopUp();
                    frm.Owner = this;
                    //shiftPop.uptdic = updatedic;
                    int ID = Convert.ToInt32(jeansGridView1.Rows[row].Cells[1].Value);
                    frm.WorkOrderId = ID;
                    string itemtype = jeansGridView1.Rows[row].Cells[4].Value.ToString();
                    frm.itemType = itemtype;

                    frm.ShowDialog();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        DataBinding();
                    }
                }
                else if (cnt > 1)
                {
                    MessageBox.Show("수정은 하나씩만 가능합니다.");
                    return;
                }
            }
        }
    }
}
