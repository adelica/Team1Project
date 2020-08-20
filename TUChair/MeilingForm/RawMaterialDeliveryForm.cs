using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;
using TUChairVO;

namespace TUChair
{
    public partial class RawMaterialDeliveryForm : TUChair.SearchCommomForm
    {
        public RawMaterialDeliveryForm()
        {
            InitializeComponent();
        }

        private void RawMaterialDeliveryForm_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            //frm.Save += Save;
            frm.Search += Search;
            //frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
            Setcolumn();
            DataBinding();
            ComboBinding();
        }

        private void ComboBinding()
        {
          
      
        }

        private void DataBinding()
        {
            MeilingService service = new MeilingService();
            List<metrailDeductionVO> list = service.MetrailDeduction();
            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = list;
        }

        private void Setcolumn()
        {
            jeansGridView1.IsAllCheckColumnHeader = true;
            CommonUtil.InitSettingGridView(jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "작업지시번호", "WorkOrderID", true);//1
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획시작일", "Plan_StartTime", true);//2
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템코드", "Item_Code", true);//3
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템이름", "Item_Name", true);//4
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템size", "Item_Size", true);//5
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템타입", "Item_Type", true);//6
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "요청창고", "Item_InWarehouse", true);//7
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "불출창고", "Item_OutWarehouse", true);//8
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "재고량", "Qty", true);//9
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획수량", "Plan_Qty", true);//10
            jeansGridView1.Columns["WorkOrderID"].Frozen = true;
        }

        private void Excel(object sender, EventArgs e)
        {
            
        }

        private void New(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void Search(object sender, EventArgs e)
        {
            
        }

        private void RawMaterialDeliveryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            //frm.Save -= Save;
            frm.Search -= Search;
            //frm.Delete -= Delete;
            frm.New -= New;
            frm.Excel -= Excel;
        }

        private void button2_Click(object sender, EventArgs e)//출고 버튼 클릭
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
                if (cnt > 1)
                {
                    MessageBox.Show("하나만 이동할 수 있습니다");
                }
                else if(cnt==0)
                {
                    MessageBox.Show("이동할 자재를 선택하여 주세요");
                }
                else
                {
                    int QTY = Convert.ToInt32(jeansGridView1.Rows[row].Cells[9].Value);
                    int planQTY = Convert.ToInt32(jeansGridView1.Rows[row].Cells[10].Value);
                    string item = jeansGridView1.Rows[row].Cells[3].Value.ToString();
                    string inhouse = jeansGridView1.Rows[row].Cells[7].Value.ToString();
                    string outhouse = jeansGridView1.Rows[row].Cells[8].Value.ToString();
                   
                    if (QTY < planQTY)
                    {
                        MessageBox.Show("재고가 부족합니다");
                        return;
                    }
                    RowMetrialDecountPopUp rowMetrial = new RowMetrialDecountPopUp();
                   
                    rowMetrial.item = item;
                    rowMetrial.planQTY = planQTY;
                    rowMetrial.inhouse = inhouse;
                    rowMetrial.outhouse = outhouse;
                    rowMetrial.ShowDialog();
                    DataBinding();
                }
            }
            
             

        }
    }
}
