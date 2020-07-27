using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;

namespace TUChair.MeilingForm
{
    public partial class ShiftPopUpForm : TUChair.CommonForm.POPUPForm3Line
    {
       public List<string> sendlist { get; set; }
        public ShiftPopUpForm()
        {

            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            MeilingService service = new MeilingService();
            service.InsertShiftInfo(txtShiftID.Text, cboShift.SelectedItem.ToString(), txtStartTime.Text, txtEndTime.Text, dtpStartDate.Value, dtpEndDate.Value);
        }

        private void ShiftPopUpForm_Load(object sender, EventArgs e)
        {
            string[] UseOrNot = new string[2] { "사용", "미사용" };
            cboShift.Items.AddRange(sendlist.ToArray());
            cboUseOrNot.Items.AddRange(UseOrNot);
            dtpStartDate.MinDate = DateTime.Now;
            dtpModifyDate.MinDate = DateTime.Now;
        }

     

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = dtpStartDate.Value;
        }
    }
}
