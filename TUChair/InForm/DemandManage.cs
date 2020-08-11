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
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "Plan_ID", "Sales_ID", false);

            GetComboBinding();
            
            dtpDate.DateLimit = true;
        }


        public void LoadData(object sender, EventArgs e)
        {
            if(((TUChairMain2)this.MdiParent).ActiveMdiChild==this)
            {
                string startDate= string.Empty;
                string endDate = string.Empty;

                startDate = dtpDate.Start.ToString();
                endDate = dtpDate.End.ToString();

                EnumerableRowCollection<DataRow> query;

                DemandManageService service = new DemandManageService();
                DataTable dt = service.GetDemandManage(startDate, endDate);

                if (cboCompany.SelectedIndex != 0 && cboPlanID.SelectedIndex !=0)
                {
                     query = from order in dt.AsEnumerable()
                                                             where order.Field<string>("Item_Code").Contains(txtItem_Code.Text.Trim()) && order.Field<string>("Com_Name").Contains(cboCompany.Text.Trim())
                                                            && order.Field<int>("Sales_ID") ==Convert.ToInt32(cboPlanID.Text)
                                                             select order;
                }
                else if(cboCompany.SelectedIndex ==0 && cboPlanID.SelectedIndex !=0)
                {
                     query = from order in dt.AsEnumerable()
                                                             where order.Field<string>("Item_Code").Contains(txtItem_Code.Text.Trim()) && order.Field<string>("Sales_ID").Contains(cboPlanID.Text.Trim())
                             select order;
                }
                else if (cboCompany.SelectedIndex != 0 && cboPlanID.SelectedIndex == 0)
                {
                    query = from order in dt.AsEnumerable()
                            where order.Field<string>("Item_Code").Contains(txtItem_Code.Text.Trim()) && order.Field<string>("Com_Name").Contains(cboCompany.Text.Trim())
                            select order;
                }
                else
                {
                    query = from order in dt.AsEnumerable()
                            where order.Field<string>("Item_Code").Contains(txtItem_Code.Text.Trim())
                            select order;
                }
                
                DataView view = query.AsDataView();

                dgvDemand.DataSource = view;
      
            }
        }

        public void GetComboBinding()
        {
            DemandManageService service = new DemandManageService();
            List<DemandManageVO> list = service.GetComboBinding();
 
            List<string> com = (from code in list
                                select code.Com_Name).Distinct().ToList();
            List<string>  id = (from Id in list
                            where Id.Sales_ID !="0"
                            select Id.Sales_ID).Distinct().ToList();
            com.Insert(0, "전체");
            id.Insert(0, "전체");
            ///id.Add("전체");
            foreach (string c in com)
                cboCompany.Items.Add(c);
            foreach (string i in id)
                cboPlanID.Items.Add(i);

            CommonUtil.CboSetting(cboCompany);
            CommonUtil.CboSetting(cboPlanID);

        }
        private void DemandManage_Load(object sender, EventArgs e)
        {
            frm = (TUChairMain2)this.MdiParent;
            frm.Search += LoadData;

        }

        private void DemandManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.Search -= LoadData;
        }
    }
}
