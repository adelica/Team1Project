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
           
        }

        private void ComboBinding()
        {
           
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
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "작업지시번호", "WorkOrderID", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "생산계획번호", "Pro_ID", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템코드", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템이름", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획수량", "Plan_Qty", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획일", "Plan_Date", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "지시상태", "Wo_State", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획시작일", "Plan_StartTime", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획마감일", "Plan_EndTime", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "PlanID", "Sales_ID", true);
            jeansGridView1.Columns["Pro_ID"].Frozen = true;
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

        private void WorkOrderForm_FormClosing(object sender, FormClosingEventArgs e)
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
