using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Util;
using TUChair.Service;

namespace TUChair
{
    public partial class DemandManage : TUChair.SearchCommomForm
    {
        TUChairMain2 frm = new TUChairMain2();
        public DemandManage()
        {
            InitializeComponent();

            CommonUtil.InitSettingGridView(dgvDemand);
            dgvDemand.AutoGenerateColumns = true;
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "고객사코드", "Com_Code", true, 90, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "고객사명", "Com_Name", true, 100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "고객주문번호", "So_PurchaseOrder", true, 150, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "품목", "Item_Code", true, 100, DataGridViewContentAlignment.MiddleCenter);
        }


        public void LoadData(object sender, EventArgs e)
        {
            if(((TUChairMain2)this.MdiParent).ActiveMdiChild==this)
            {
                string startDate= string.Empty;
                string endDate = string.Empty;

                startDate = dtpDate.Start.ToString();
                endDate = dtpDate.End.ToString();

                DemandManageService service = new DemandManageService();
                DataTable dt = service.GetDemandManage(startDate, endDate);
                //dt.DefaultView.RowFilter ="Item_Code Like '%{txtItme_Code.Text}%'";
                dgvDemand.DataSource = dt;
            }
        }
        private void DemandManage_Load(object sender, EventArgs e)
        {
            frm = (TUChairMain2)this.MdiParent;
            frm.New += LoadData;

        }

        private void DemandManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.New-=LoadData;
        }
    }
}
