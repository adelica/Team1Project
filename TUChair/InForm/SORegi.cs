using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChairVO;

namespace TUChair
{
    public partial class SORegi : TUChair.POPUp2Line
    {
        private SOVO item;

        public SORegi()
        {
            InitializeComponent();
        }
        SOVO Item
        {
            get
            {
                SOVO sItem = new SOVO();
                sItem.Com_Code = cboComCode.Text;
                sItem.Item_Code = cboItemCode.Text;
                sItem.So_Duedate = Convert.ToDateTime(txtDueDate.Text);
                sItem.So_Other = txtOther.Text;
                sItem.So_PurchaseOrder = txtPurchaseOrder.Text;
                sItem.So_Qty  =Convert.ToInt32(txtQty.Text);
                sItem.So_ShipQty = Convert.ToInt32(txtShipQty.Text);
                sItem.So_WorkOrderID = txtWorkOrder.Text;

                item = sItem;
                return item;
            }
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
           
        }
    }
}
