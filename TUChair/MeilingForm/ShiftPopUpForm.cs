using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;

namespace TUChair
{
    public partial class ShiftPopUpForm : TUChair.POPUPForm3Line
    {
        public List<string> sendlist { get; set; }
        public List<string> sendshiftlist { get; set; }
        public Dictionary<string, string> uptdic { get; set; }
        public string uporInsert { get; set; }
        public ShiftPopUpForm()
        {

            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cboShift.Text == null || txtShiftID.Text == null || txtStartTime.Text == null || txtEndTime.Text == null)
            {
                MessageBox.Show("필수 입력값을 모두 입력해 주세요");
            }

            else if (sendshiftlist.Contains(txtShiftID.Text))
            {
                MessageBox.Show("ShiftID가 중복 되였습니다");
            }
            else
            {
                MeilingService service = new MeilingService();
                service.InsertShiftInfo(txtShiftID.Text, cboShift.SelectedItem.ToString(), txtStartTime.Text, txtEndTime.Text, dtpStartDate.Value, dtpEndDate.Value, Convert.ToInt32(txtPeople.Text), cboUseOrNot.Text, txtModifyName.Text, dtpModifyDate.Value, txtRemark.Text);

            }

        }

        private void ShiftPopUpForm_Load(object sender, EventArgs e)
        {
            string[] UseOrNot = new string[2] { "사용", "미사용" };
            cboShift.Items.AddRange(sendlist.ToArray());
            cboUseOrNot.Items.AddRange(UseOrNot);
            //dtpStartDate.MinDate = DateTime.Now;
            //dtpModifyDate.MinDate = DateTime.Now;
            if (uporInsert == "Update")
            {
                txtShiftID.ReadOnly = true;
                txtShiftID.Text = uptdic["ShiftID"];
                cboShift.SelectedItem = uptdic["설비명"];
                txtStartTime.Text = uptdic["시작시간"];
                txtEndTime.Text = uptdic["종료시간"];
                dtpStartDate.Value = Convert.ToDateTime(uptdic["시작일"]);
                dtpEndDate.Value = Convert.ToDateTime(uptdic["종료일"]);
                txtPeople.Text = uptdic["투입인원"];
                cboUseOrNot.SelectedItem = uptdic["사용유무"];
                txtModifyName.Text = uptdic["수정자"];
                dtpModifyDate.Value = Convert.ToDateTime(uptdic["수정일"]);
                txtRemark.Text = uptdic["비고"];
            }
        }

     

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = dtpStartDate.Value;
        }
        //수정 버튼 클릭
        private void button3_Click(object sender, EventArgs e)
        {
            if (cboShift.Text == null || txtShiftID.Text == null || txtStartTime.Text == null || txtEndTime.Text == null)
            {
                MessageBox.Show("필수 입력값을 모두 입력해 주세요");
            }


            else
            {
                MeilingService service = new MeilingService();
                service.Update(txtShiftID.Text, cboShift.SelectedItem.ToString(), txtStartTime.Text, txtEndTime.Text, dtpStartDate.Value, dtpEndDate.Value, Convert.ToInt32(txtPeople.Text), cboUseOrNot.Text, txtModifyName.Text, dtpModifyDate.Value, txtRemark.Text);
            }
        }
    }
}
