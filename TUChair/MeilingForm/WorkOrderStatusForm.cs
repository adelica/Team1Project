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
            MeilingService service = new MeilingService();
            List<WorkOrderVO> list = service.selectworkOrder();
            jeansGridView1.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "작업지시번호", "WorkOrderID", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "WO", "So_WorkOrderID", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템코드", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획수량", "Plan_Qty", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획일", "Plan_Date", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "생산일자", "Prd_Date", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "지시상태", "Wo_State", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "작업순서", "Wo_Order", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "시작일", "Plan_StartTime", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "완료일", "Plan_EndTime", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "투입수량", "In_Qty_Main", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "산출량", "Out_Qty_Main", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "생산량", "Prd_Qty", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "생산의뢰번호", "Wo_Req_No", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "기타", "Remark", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정일", "Up_Date", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정자", "Up_Emp", true);
            jeansGridView1.Columns["WorkOrderID"].Frozen = true;
            jeansGridView1.DataSource = list;
        }

        private void button3_Click(object sender, EventArgs e)//바코드 출력
        {
            List<int> chkList = new List<int>();

            for (int i = 0; i < jeansGridView1.Rows.Count; i++)
            {
                bool isCellChecked = (bool)jeansGridView1.Rows[i].Cells[0].EditedFormattedValue;
                if (isCellChecked)
                {
                    chkList.Add(Convert.ToInt32(jeansGridView1.Rows[i].Cells[1].Value));
                }
            }
            if (chkList.Count == 0)
            {
                MessageBox.Show("출력할 바코드를 선택해주세요.");
                return;
            }
            string strChkBarCodes = string.Join(",", chkList);
            MeilingService service = new MeilingService();
            List<WorkOrderVO> list = service.SelectBarcode(strChkBarCodes);

          DataTable dt =  Helper.ConvertToDataTable<WorkOrderVO>(list);



            XtraReportBarc rpt = new XtraReportBarc();
                rpt.DataSource = dt;
           // PreviewForm frm = new PreviewForm(rpt);

        }

        private void WorkOrderStatusForm_Activated(object sender, EventArgs e)
        {
            MeilingService service = new MeilingService();
            List<WorkOrderVO> list = service.selectworkOrder();
            jeansGridView1.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "작업지시번호", "WorkOrderID", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "WO", "So_WorkOrderID", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "아이템코드", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획수량", "Plan_Qty", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "계획일", "Plan_Date", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "생산일자", "Prd_Date", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "지시상태", "Wo_State", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "작업순서", "Wo_Order", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "시작일", "Plan_StartTime", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "완료일", "Plan_EndTime", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "투입수량", "In_Qty_Main", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "산출량", "Out_Qty_Main", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "생산량", "Prd_Qty", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "생산의뢰번호", "Wo_Req_No", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "기타", "Remark", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정일", "Up_Date", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정자", "Up_Emp", true);
            jeansGridView1.Columns["WorkOrderID"].Frozen = true;
            jeansGridView1.DataSource = list;
        }
    }
}
