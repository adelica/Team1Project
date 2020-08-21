using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChairVO;

namespace TUChair.HyunningForm
{
    public partial class EmpManagerPopUp : TUChair.POPUP1Line
    {
        public EmpVO Emp { get; set; }
        public string uporInsert { get; set; }

        public EmpManagerPopUp()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtID.Text == null || txtName.Text == null || txtPWD.Text == null || cboAuthorID.Text == null || cboUseOrNot.Text == null)
            {
                MessageBox.Show("필수 입력값을 모두 입력해 주세요");
            }
            else if (uporInsert == "Update")
            {
                EmpService service = new EmpService();
                if (service.Update(txtID.Text, txtName.Text,txtPWD.Text, cboAuthorID.Text,cboUseOrNot.Text))
                {
                    MessageBox.Show("수정 되였습니다");
                }
                else
                {
                    MessageBox.Show("수정실패");
                }
            }
            else if (uporInsert == "Insert")
            {
                EmpService service = new EmpService();
                if (service.Insert(txtID.Text, txtName.Text, txtPWD.Text, cboAuthorID.Text, cboUseOrNot.Text))
                {
                    MessageBox.Show("수정 되였습니다");
                }
                else
                {
                    MessageBox.Show("수정실패");
                }
            }
        }

        private void EmpManagerPopUp_Load(object sender, EventArgs e)
        {
            if (uporInsert == "Update")
            {
                txtID.ReadOnly = true;
                txtID.Text = Emp.CUser_ID.ToString();
                txtName.Text = Emp.CUser_Name.ToString();
                txtPWD.Text = string.Empty;
                cboUseOrNot.SelectedItem = Emp.CUser_UseOrNot;
                cboAuthorID.Text = Emp.AuthorGroup_ID.ToString();
            }
            else if (uporInsert == "Insert")
            {
                txtID.ReadOnly = false;

            }
        }
    }
}
