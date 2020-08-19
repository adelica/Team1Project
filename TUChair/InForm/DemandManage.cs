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
using JeanForm;
using DevExpress.DirectX.Common.Direct2D;

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
            dgvDemand.IsAllCheckColumnHeader = true;

            //dgvDemand.ReadOnly = true;

            GetComboBinding();         
            dtpDate.DateLimit = true;
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "고객사코드", "Com_Code", true, 130, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "고객사명", "Com_Name", true, 100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "고객주문번호", "So_PurchaseOrder", true, 150, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "품목", "Item_Code", true, 100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "Plan_ID", "Sales_ID", false);
           
            
            
        }

        //검색
        private void Search(object sender, EventArgs e)
        {
            if(((TUChairMain2)this.MdiParent).ActiveMdiChild==this)
            {
                dgvDemand.DataSource = null;

                CommonUtil.AddNewColumnToDataGridView(dgvDemand, "고객사코드", "Com_Code", true, 130, DataGridViewContentAlignment.MiddleCenter);
                CommonUtil.AddNewColumnToDataGridView(dgvDemand, "고객사명", "Com_Name", true, 100, DataGridViewContentAlignment.MiddleCenter);
                CommonUtil.AddNewColumnToDataGridView(dgvDemand, "고객주문번호", "So_PurchaseOrder", true, 150, DataGridViewContentAlignment.MiddleCenter);
                CommonUtil.AddNewColumnToDataGridView(dgvDemand, "품목", "Item_Code", true, 100, DataGridViewContentAlignment.MiddleCenter);
                CommonUtil.AddNewColumnToDataGridView(dgvDemand, "Plan_ID", "Sales_ID", false);



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
                                                             where order.Field<string>("Item_Code").Contains(txtItem_Code.Text.Trim()) && order.Field<string>("Com_Name")==cboCompany.Text.Trim()
                                                            && order.Field<int>("Sales_ID") ==Convert.ToInt32(cboPlanID.Text)
                                                             select order;
                }
                else if(cboCompany.SelectedIndex ==0 && cboPlanID.SelectedIndex !=0)
                {
                     query = from order in dt.AsEnumerable()
                                                             where order.Field<string>("Item_Code").Contains(txtItem_Code.Text.Trim()) && order.Field<string>("Sales_ID")==cboPlanID.Text.Trim()
                             select order;
                }
                else if (cboCompany.SelectedIndex != 0 && cboPlanID.SelectedIndex == 0)
                {
                    query = from order in dt.AsEnumerable()
                            where order.Field<string>("Item_Code").Contains(txtItem_Code.Text.Trim()) && order.Field<string>("Com_Name")==cboCompany.Text.Trim()
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

                for (int j = 1; j < dgvDemand.Columns.Count; j++)
                {
                    dgvDemand.Columns[j].ReadOnly = true;
                }

            }
        }

        //콤보박스 바인딩
        public void GetComboBinding()
        {
            DemandManageService service = new DemandManageService();
            List<DemandManageVO> list = service.GetComboBinding();
 
            List<string> com = (from code in list
                                where code.Com_Name !=""
                                select code.Com_Name).Distinct().ToList();
            List<string>  id = (from Id in list
                            where Id.Sales_ID !=""
                            select Id.Sales_ID).Distinct().ToList();
            com.Insert(0, "전체");
            id.Insert(0, "전체");
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
            frm.Search += Search;

        }

        private void DemandManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.Search -= Search;
        }

        //체크박스에 체크된 설비 코드
        private List<String> Check()
        {
            List<string> chkList = new List<string>();

            for (int i = 0; i < dgvDemand.Rows.Count; i++)
            {
                bool IsCellChecked = (bool)dgvDemand.Rows[i].Cells[0].EditedFormattedValue;
                if (IsCellChecked)
                {
                    chkList.Add(dgvDemand.Rows[i].Cells[5].Value.ToString());
                }
            }
            return chkList;
        }

        private void btnProductionPlan_Click(object sender, EventArgs e)
        {
            List<string> chkList = Check();
            if (chkList.Count == 1)
            {
                ProductPlanRegi frm = new ProductPlanRegi(chkList[0]);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("등록할 데이터를 하나만 선택하세요", "등록실패");
                return;
            }
        }
    }
}
