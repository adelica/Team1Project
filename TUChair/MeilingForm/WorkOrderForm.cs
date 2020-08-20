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
    public partial class WorkOrderForm : TUChair.SearchCommomForm
    {
        List<WoOrderVO> list;
        public WorkOrderForm()
        {
            InitializeComponent();
        }

        private void WorkOrderForm_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
            Setcolumn();
            DataBinding();
            ComboBinding();
            DataBinding();
        }

        private void Excel(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                using (waitFrm frm = new waitFrm(ExportOrderList))
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
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

        private void ComboBinding()
        {
           List<string> ItemList = new List<string>();
            ItemList.Insert(0, "선택");
            for (int i = 0; i < jeansGridView1.RowCount; i++)
            {
                ItemList.Add(jeansGridView1.Rows[i].Cells[4].Value.ToString());
            };
            ItemList = ItemList.Distinct().ToList();
          
            cboItem.Items.AddRange(ItemList.ToArray());
            List<string> PlanIDList = new List<string>();
            PlanIDList.Insert(0, "선택");
            for (int i = 0; i < jeansGridView1.RowCount; i++)
            {
                PlanIDList.Add(jeansGridView1.Rows[i].Cells[10].Value.ToString());
            };
            PlanIDList = PlanIDList.Distinct().ToList();
            
            cboplanID.Items.AddRange(PlanIDList.ToArray());

        }

        private void DataBinding()
        {
            MeilingService service = new MeilingService();
            list = service.WorkOderselect();
            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = list;
        }

        private void Setcolumn()
        {
            jeansGridView1.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "작업지시번호", "WorkOrderID", true);//1
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "생산계획번호", "Pro_ID", true);//2
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템코드", "Item_Code", true);//3
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템이름", "Item_Name", true);//4
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획수량", "Plan_Qty", true);//5
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획일", "Plan_Date", true);//6
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "지시상태", "Wo_State", true);//7
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획시작일", "Plan_StartTime", true);//8
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획마감일", "Plan_EndTime", true);//9
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "PlanID", "Sales_ID", true);//10
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "자재차감여부", "Deduction", true);
            jeansGridView1.Columns["Pro_ID"].Frozen = true;
        }

        private void New(object sender, EventArgs e)
        {           
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                DataBinding();
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                List<string> sb = new List<string>();
                jeansGridView1.EndEdit();
                for (int i = 0; i < jeansGridView1.RowCount; i++)
                {
                    bool isn = Convert.ToBoolean(jeansGridView1.Rows[i].Cells["chk"].Value);
                    if (isn)
                    {
                        sb.Add(jeansGridView1.Rows[i].Cells[1].Value.ToString());
                    }
                }
                if (sb.Count < 1)
                {
                    MessageBox.Show("삭제할 항목을 선택해주세요");
                    return;
                }
                string condition = string.Join("@", sb);
                MeilingService service = new MeilingService();
                if (service.DeleteWorkOrder(condition))
                {
                    MessageBox.Show("삭제되었습니다.");
                }
                else
                    MessageBox.Show("삭제에 실패하였습니다.");

                DataBinding();
            }
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
                List<WoOrderVO> list = service.WorkOderSearch(inDTP1.Start,inDTP1.End, sg);
             
                jeansGridView1.DataSource = null;
                jeansGridView1.DataSource = list;
            }
        }

        private string GetSearchCondition(Panel panel4)
        {
            List<string> sb = new List<string>();
            foreach (Control Pitem in panel4.Controls)
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

        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }

        private void WorkOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save -= Save;
            frm.Search -= Search;
            frm.Delete -= Delete;
            frm.New -= New;
            frm.Excel -= Excel;
        }

        private void button4_Click(object sender, EventArgs e)//작업지시확정
        {
            List<string> sb = new List<string>();
            jeansGridView1.EndEdit();
            for (int i = 0; i < jeansGridView1.RowCount; i++)
            {
                bool isn = Convert.ToBoolean(jeansGridView1.Rows[i].Cells["chk"].Value);
                if (isn)
                {
                    sb.Add(jeansGridView1.Rows[i].Cells[1].Value.ToString());
                }
            }
            if (sb.Count < 1)
            {
                MessageBox.Show("업데이트할 항목을 선택해주세요");
                return;
            }
            string condition = string.Join("@", sb);
            MeilingService service = new MeilingService();
            if (service.UpdateWorkOrder(condition))
            {
                MessageBox.Show("업데이트 되었습니다.");
            }
            else
                MessageBox.Show("업데이트에 실패하였습니다.");

            DataBinding();
        }
    }
}
