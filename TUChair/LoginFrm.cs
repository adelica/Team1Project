using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChair.Properties;
using TUChair.Service;
using TUChairVO;

namespace TUChair
{
    public partial class LoginFrm : Form
    {
       public CUserVO userinfo { get; set; }
        public static string userName; //로그인한 사원정보


        public LoginFrm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginService service = new LoginService();
            userinfo = service.GetUserinfo(txtID.Text);
            if (userinfo == null)
            {
                MessageBox.Show("존재하지 않는 사번입니다.");
            }
            else
            {
                if (userinfo.CUser_PWD != txtPwd.Text)
                {
                    MessageBox.Show("비번이 맞지 않습니다.");
                    return;
                }
                else
                {
                    MessageBox.Show($"환영합니다.{userinfo.CUser_Name}님 ");
                    this.DialogResult = DialogResult.OK;
                    userName = userinfo.CUser_Name; //다른 폼에서 수정자 확인위해
                    this.Close();
                }
            }
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                btnLogin.PerformClick();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPwd.PasswordChar = '\0';
            }
            else
            {
                txtPwd.PasswordChar = '*';
            }
        }

        private void LoginFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chkSave.Checked)
            {
                Settings.Default["loginID"] = txtID.Text;
                Settings.Default["IsChk"] = chkSave.Checked;
                Settings.Default.Save();
            }
            else
            {
                Settings.Default["loginID"] = "";
                Settings.Default["IsChk"] = chkSave.Checked;
                Settings.Default.Save();
            }
        }

        private void LoginFrm_Activated(object sender, EventArgs e)
        {
            txtID.Text = Settings.Default["loginID"].ToString();
            chkSave.Checked = Settings.Default.IsChk;
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {

        }

        private void LoginFrm_Deactivate(object sender, EventArgs e)
        {
            if (chkSave.Checked)
            {
                Settings.Default["loginID"] = txtID.Text;
                Settings.Default["IsChk"] = chkSave.Checked;
                Settings.Default.Save();
            }
            else
            {
                Settings.Default["loginID"] = "";
                Settings.Default["IsChk"] = chkSave.Checked;
                Settings.Default.Save();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login_MouseMove(object sender, MouseEventArgs e)
        {
            var s = sender as Panel;
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            s.Parent.Left = this.Left + (e.X - ((Point)s.Tag).X);
            s.Parent.Top = this.Top + (e.Y - ((Point)s.Tag).Y);
        }

        private void login_MouseDown(object sender, MouseEventArgs e)
        {
            var s = sender as Panel;
            s.Tag = new Point(e.X, e.Y);
        }

    }
}
