using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TUChair.InForm
{
    public partial class POManage : TUChair.CommonForm.SearchCommomForm
    {
        public POManage()
        {
            InitializeComponent();
        }

        private void btnPOUpLoad_Click(object sender, EventArgs e) //영업마스터생성 팝엄
        {
            PORegi frm = new PORegi();
            frm.ShowDialog();
        }

        private void btnSORegi_Click(object sender, EventArgs e) //수요계획생성 팝업
        {
            SORegi frm = new SORegi();
            frm.ShowDialog();
        }
    }
}
