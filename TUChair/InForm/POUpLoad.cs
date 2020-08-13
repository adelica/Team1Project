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
            dgvPO.AutoGenerateColumns = true;
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "planDate", "Plan_Date", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "순번", "순번", true, 70, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "WORK_ORDER_ID", "WORK_ORDER_ID", true, 150, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "업체코드", "업체 CODE", true,130, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "납품처", "납품처", true,100, DataGridViewContentAlignment.MiddleCenter);

            CommonUtil.AddNewColumnToDataGridView(dgvPO, "SIZE", "SIZE", true,130, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "입고P/NO", "입고P/NO", true,120, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "품명", "품명", true,120, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "계획수량합계", "계획수량합계", true,100,DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "납기일", "납기일", true,150, DataGridViewContentAlignment.MiddleCenter);

           
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
