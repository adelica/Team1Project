using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Util;
using TUChair.Service;
using TUChairVO;
using System.Linq;

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
            GetComboBinding();
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

                //    dt.DefaultView.RowFilter =$"Item_Code Like '%{txtItme_Code.Text}%'";
                EnumerableRowCollection<DataRow> query = from data in dt.AsEnumerable()
                                                         where data.Field<string>("Item_Code").Contains(txtItem_Code.Text)
                                                         select data;

                DataView view = query.AsDataView();
                dgvDemand.DataSource = view;
            }
        }

        private void GetComboBinding() //----------------문제
        {
            DemandManageService service = new DemandManageService();
            List<DemandManageVO> list = service.GetComboBinding();

            List<string> com = (from name in list
                                select name.Com_Name).Distinct().ToList();
            List<int> sales_Id = (from id in list
                                     select id.Sales_ID).Distinct().ToList();

            foreach (var a in com)
                cboCompany.Items.Add(com);
            foreach (var b in sales_Id)
                cboPlanID.Items.Add(sales_Id);

        }

        private void DemandManage_Load(object sender, EventArgs e)
        {
            frm = (TUChairMain2)this.MdiParent;
            frm.Search += LoadData;

        }

        private void DemandManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.Search-=LoadData;
        }
    }
}
