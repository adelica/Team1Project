using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChair.Util;

namespace TUChair.InForm
{
    public partial class POUpLoad : Form
    {
        public POUpLoad()
        {
            InitializeComponent();
            DataLoad();
        }

        public void DataLoad()
        {
            CommonUtil.InitSettingGridView(dgvPO);

            CommonUtil.AddNewColumnToDataGridView(dgvPO, "planDate", "Plan_Date", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "순번", "no", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "WORK-ORDER-ID", "WorkOrderNo", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "업체코드", "Com_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "납품처", "Com_Type", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "MKT", "??", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "발주구분", "??", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "GROUP", "??", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "구분", "??", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "SIZE", "??", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "입고P/NO", "??", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "계획수량합계", "Sales_Qty", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "납기일", "Vo_EndDate", true);
        }

        private void btnPOUpLoad_Click(object sender, EventArgs e)
        {
            PORegi frm = new PORegi();
            frm.ShowDialog();
        }
    }
}
