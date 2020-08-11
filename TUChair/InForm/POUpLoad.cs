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


namespace TUChair
{
    public partial class POUpLoad : Form//------------하는 중
    {
        DataTable poData = null;

        public POUpLoad()
        {
            InitializeComponent();
            CommonUtil.InitSettingGridView(dgvPO);

            CommonUtil.AddNewColumnToDataGridView(dgvPO, "planDate", "Plan_Date", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "순번", "no", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "WORK-ORDER-ID", "WorkOrderNo", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "업체코드", "Com_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "납품처", "Com_Name", true);

            CommonUtil.AddNewColumnToDataGridView(dgvPO, "SIZE", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "입고P/NO", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "계획수량합계", "Sales_Qty", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "납기일", "Vo_EndDate", true);

           
        }

        private void btnPOUpLoad_Click(object sender, EventArgs e)
        {
            PORegi frm = new PORegi();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if(frm.Check)
            {
                MessageBox.Show("등록되었습니다.", "등록완료");
                poData = frm.POUpLoad;
                dgvPO.DataSource = poData;
            }
        }

        private void POUpLoad_Load(object sender, EventArgs e)
        {
            dgvPO.DataSource = poData;
        }
    }
}
