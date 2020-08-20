using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChairVO;

namespace TUChair
{
    public partial class ShiftPopUpForm : TUChair.POPUPForm3Line
    {
        public List<string> sendlist { get; set; }
        public List<string> faciNameList { get; set; }
        public Dictionary<string, string> uptdic { get; set; }
        public string uporInsert { get; set; }
        public ShiftVO  Shift { get; set; }

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
            else if(uporInsert == "Update")
            {
               MeilingService service = new MeilingService();
               if(service.Update(txtShiftID.Text, cboShift.SelectedItem.ToString(), txtStartTime.Text, txtEndTime.Text, dtpStartDate.Value, dtpEndDate.Value, Convert.ToInt32(txtPeople.Text), cboUseOrNot.Text, txtModifyName.Text, dtpModifyDate.Value, txtRemark.Text))
                {
                    MessageBox.Show("수정 되였습니다");
                }
                else
                {
                    MessageBox.Show("수정실패");
                }
            }else if (uporInsert == "Insert")
            {
                MeilingService service = new MeilingService();
                if(service.InsertShiftInfo(txtShiftID.Text, cboShift.SelectedItem.ToString(), txtStartTime.Text, txtEndTime.Text, dtpStartDate.Value, dtpEndDate.Value, Convert.ToInt32(txtPeople.Text), cboUseOrNot.Text, txtModifyName.Text, dtpModifyDate.Value, txtRemark.Text))
                {
                    MessageBox.Show("수정 되였습니다");
                }
                else
                {
                    MessageBox.Show("수정실패");
                }
            }
        }
                                                                                                                                                                                                                                                                                                                                                                            
        private void ShiftPopUpForm_Load(object sender, EventArgs e)
        {
            string[] UseOrNot = new string[2] { "사용", "미사용" };
            cboShift.Items.AddRange(faciNameList.ToArray());
            cboUseOrNot.Items.AddRange(UseOrNot);
            //dtpStartDate.MinDate = DateTime.Now;
            //dtpModifyDate.MinDate = DateTime.Now;
            if (uporInsert == "Update")
            {
                txtShiftID.ReadOnly = true;
                txtShiftID.Text =Shift.Shift_ID.ToString();
                cboShift.Items.AddRange(faciNameList.ToArray());
                cboShift.SelectedItem = Shift.Faci_Name;
                txtStartTime.Text = Shift.Shift_StartTime;
                txtEndTime.Text = Shift.Shift_EndTime;
                dtpStartDate.Value = Shift.Shift_StartDate;
                dtpEndDate.Value = Shift.Shift_EndDate;
                txtPeople.Text = Shift.Shift_InputPeople.ToString();
                cboUseOrNot.SelectedItem = Shift.Shift_UserOrNot;
                txtModifyName.Text = Shift.Shift_Modifier;
                dtpModifyDate.Value = Convert.ToDateTime(Shift.Shift_ModifierDate);
                txtRemark.Text = Shift.Shift_Others;
            }
            else if(uporInsert == "Insert")
            {
                txtShiftID.ReadOnly = false;
                
            }
        }

     

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = dtpStartDate.Value;
        }
        //수정 버튼 클릭
        private void button3_Click(object sender, EventArgs e)
        {
          
        }
    }
}
