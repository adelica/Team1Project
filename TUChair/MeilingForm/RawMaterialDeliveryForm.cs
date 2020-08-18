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
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획시작일", "Plan_StartTime", true);//10
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템코드", "Item_Code", true);//3
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템이름", "Item_Name", true);//4
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템size", "Item_Size", true);//4
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템타입", "Item_Type", true);//4
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "요청창고", "Item_InWarehouse", true);//4
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "불출창고", "Item_OutWarehouse", true);//4

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "재고량", "Qty", true);//4
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획수량", "Plan_Qty", true);//4

            jeansGridView1.Columns["WorkOrderID"].Frozen = true;

        }

        private void Excel(object sender, EventArgs e)
        {
            
        }

        private void New(object sender, EventArgs e)
        {
           
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

        }
    }
}
