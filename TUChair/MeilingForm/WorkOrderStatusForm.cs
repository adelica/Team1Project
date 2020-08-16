using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.HyunningForm;
using TUChair.Service;
using TUChair.Util;
using TUChairDAC;
using TUChairVO;

namespace TUChair
{
    public partial class WorkOrderStatusForm : TUChair.SearchCommomForm
    {
        public WorkOrderStatusForm()
        {
            InitializeComponent();
        }
       
        private void WorkOrderStatusForm_Load(object sender, EventArgs e)
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
            
        }

        private void New(object sender, EventArgs e)
        {
            
        }

        private void Delete(object sender, EventArgs e)
        {
           
        }

        private void Search(object sender, EventArgs e)
        {
           
        }

        private void Save(object sender, EventArgs e)
        {
          
        }

        private void ComboBinding()
        {

        }

        private void DataBinding()
        {
            MeilingService service = new MeilingService();
            List<WoOrderVO> list = service.WorkOrderStatus();
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
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "소진창고", "Item_InWarehouse", true);//5
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "양품창고", "Item_OutWarehouse", true);//6
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획수량", "Plan_Qty", true);//7
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획일", "Plan_Date", true);//8
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "지시상태", "Wo_State", true);//9
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획시작일", "Plan_StartTime", true);//10
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획마감일", "Plan_EndTime", true);//11
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "PlanID", "Sales_ID", true);//12
            jeansGridView1.Columns["Pro_ID"].Frozen = true;
        }

        private void WorkOrderStatusForm_FormClosed(object sender, FormClosedEventArgs e)
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
