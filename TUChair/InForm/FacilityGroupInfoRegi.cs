using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Util;
using TUChair.Service;
using TUChairVO;
using System.Linq;

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

            commonService service = new commonService();

            List<ComboItemVO> comboItems = service.getCommonCode("사용여부");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "사용여부"
                                       select item).ToList();
            CommonUtil.ComboBinding(cboFacG_UseOrNot, cList, "선택");
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
            string facG_UserOrNot = cboFacG_UseOrNot.Text;
            string facG_Modifier = txtFacG_Modifier.Text;
            DateTime facG_ModifyDate = DateTime.Now;
            string facG_Info = txtFacG_Info.Text;

            FacilityService service = new FacilityService();
            check = service.FacilityGInfoRegi(facG_Code, facG_Name, facG_UserOrNot, facG_Modifier, facG_ModifyDate, facG_Info);
            if(check)
            {
                MessageBox.Show("등록되었습니다.", "등록완료");
                this.Close();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
