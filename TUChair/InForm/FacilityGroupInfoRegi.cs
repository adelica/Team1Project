using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Util;
using TUChair.Service;

namespace TUChair
{
    public partial class FacilityGroupInfoRegi : TUChair.POPUP1Line
    {
        bool check = false;
        public bool Check { get { return check; } }
        
        public FacilityGroupInfoRegi()
        {
            InitializeComponent();
            txtFacG_Modifier.Enabled = false;
            txtFacG_ModifyDate.Enabled = false;
        }

        private void FacilityGroupInfoRegi_Load(object sender, EventArgs e)
        {
            txtFacG_Modifier.Text = LoginFrm.userName;
            //txtFacG_ModifyDate.Text = DateTime.Now.ToString();
            CommonUtil.CboUseOrNot(cboFacG_UseOrNot);
            CommonUtil.CboSetting(cboFacG_UseOrNot);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(txtFacG_Code.Text.Trim().Length<1 || txtFacG_Name.Text.Trim().Length<1 || txtFacG_Info.Text.Trim().Length<1)
            {
                CommonUtil.RequiredInfo();
                return;
            }
            string facG_Code = txtFacG_Code.Text;
            string facG_Name = txtFacG_Name.Text;
            string facG_UserOrNot = cboFacG_UseOrNot.SelectedItem.ToString();
            string facG_Modifier = txtFacG_Modifier.Text;
            DateTime facG_ModifyDate = DateTime.Now;
            string facG_Info = txtFacG_Info.Text;

            FacilityService service = new FacilityService();
            check = service.FacilityGInfoRegi(facG_Code, facG_Name, facG_UserOrNot, facG_Modifier, facG_ModifyDate, facG_Info);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
