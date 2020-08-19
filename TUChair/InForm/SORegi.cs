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
    public partial class SORegi : TUChair.POPUp2Line
    {
        private SOVO item;
        bool check = false;
        public bool Check { get { return check; }}
        public SORegi()
        {
            InitializeComponent();
        
            ComboBinding();
            //dtpDueDate.MinDate = DateTime.Now;
            txtShipQty.Enabled = false;
        }

        public SORegi(List<SOVO> soList) : this()
        {
            SOVO soItem = soList[0];

            txtWorkOrder.Text = soItem.So_WorkOrderID.ToString();
            txtOther.Text = soItem.So_Other==null? "" : soItem.So_Other.ToString();
            txtPurchaseOrder.Text = soItem.So_PurchaseOrder == "" ? "" : soItem.So_PurchaseOrder.ToString();
            cboComCode.Text = soItem.Com_Code;
            dtpDueDate.Value = soItem.So_Duedate;
            txtShipQty.Text = soItem.So_ShipQty == 0 ? "" : soItem.So_ShipQty.ToString();
            cboItemCode.Text = soItem.Item_Code;
            txtQty.Text = soItem.So_Qty.ToString();

            if (txtPurchaseOrder.Text.Trim().Length < 1)
                txtPurchaseOrder.Enabled = true;
            else
                txtPurchaseOrder.Enabled = false;


            txtWorkOrder.Enabled = false;
            cboComCode.Enabled = false;

        }

        public SOVO Item
        {
            get
            {
                SOVO sItem = new SOVO();
                sItem.Com_Code = cboComCode.Text ==""? "": cboComCode.Text;
                sItem.Item_Code = cboItemCode.Text == "" ? "" : cboItemCode.Text;
                sItem.So_Duedate = dtpDueDate.Value.Date;
                sItem.So_Other = txtOther.Text == "" ? "" : txtOther.Text;
                sItem.So_PurchaseOrder = txtPurchaseOrder.Text == "" ? "" : txtPurchaseOrder.Text;
                sItem.So_Qty = Convert.ToInt32(txtQty.Text);
                sItem.So_ShipQty =txtShipQty.Text==""?0: Convert.ToInt32(txtShipQty.Text);
                sItem.So_WorkOrderID = txtWorkOrder.Text;

                item = sItem;
                return item;
            }
            set
            {
                cboComCode.Text = value.Com_Code;
                cboItemCode.Text = value.Item_Code;
                dtpDueDate.Value = value.So_Duedate;
                txtOther.Text = value.So_Other;
                txtPurchaseOrder.Text = value.So_PurchaseOrder;
                txtQty.Text = value.So_Qty.ToString();
                txtShipQty.Text = value.So_ShipQty.ToString();
                txtWorkOrder.Text = value.So_WorkOrderID;

            }
        }
        private void ComboBinding()
        {
            POSOService service = new POSOService();
            DataSet ds = service.ItemCode();

            DataTable dtCom_Code = ds.Tables["com_Code"];
            DataTable dtItem_Code = ds.Tables["item_Code"];
            DataRow dr = dtCom_Code.NewRow();

            cboComCode.DataSource = dtCom_Code;
            cboComCode.DisplayMember = "Com_Code";
            cboComCode.ValueMember = "Com_Code";

            cboItemCode.DataSource = dtItem_Code;
            cboItemCode.DisplayMember = "Item_Code";
            cboItemCode.ValueMember = "Item_Code";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if ( txtWorkOrder.Text.Trim().Length < 1 || txtQty.Text.Trim().Length < 1)
            {
                CommonUtil.RequiredInfo();
                return;
            }
            POSOService service = new POSOService();
            check = service.SOInfoRegi(Item);
            if(check)
            {
                MessageBox.Show("등록되었습니다", "등록완료");
                this.Close();
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }          
        }
    }
}
