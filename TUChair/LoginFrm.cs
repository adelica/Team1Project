﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    }
}
