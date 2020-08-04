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
        bool newInsert = true; //신규, 수정 구분
        public bool Check { get { return check; } }
        DataTable dtFacG_Code;
        
        public FacilityGroupInfoRegi()
        {
            InitializeComponent();
            txtFacG_Modifier.Enabled = false;
            txtFacG_ModifyDate.Enabled = false;
            commonService service = new commonService();

            List<ComboItemVO> comboItems = service.getCommonCode("사용여부");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "사용여부"
                                       select item).ToList();
            CommonUtil.ComboBinding(cboFacG_UseOrNot, cList, "선택");
            CommonUtil.CboSetting(cboFacG_UseOrNot);
        }
        public FacilityGroupInfoRegi(DataTable dtFacG_code) :this()
        {
            dtFacG_Code = dtFacG_code;
        }
        public FacilityGroupInfoRegi(string facG_Code, string facG_Name, string facGUseOrNot, string facG_Info):this()
        {
            txtFacG_Code.Enabled = false;
            txtFacG_Code.Text = facG_Code;
            txtFacG_Name.Text = facG_Name;
            cboFacG_UseOrNot.Text = facGUseOrNot;
            txtFacG_Info.Text = facG_Info;
            newInsert = false;
        }

        private void FacilityGroupInfoRegi_Load(object sender, EventArgs e)
        {
            txtFacG_Modifier.Text = LoginFrm.userName;
          
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(txtFacG_Code.Text.Trim().Length<1 || txtFacG_Name.Text.Trim().Length<1 || cboFacG_UseOrNot.SelectedIndex==0)
            {
                CommonUtil.RequiredInfo();
                return;
            }
            if (newInsert)
            {
                DataView dv = dtFacG_Code.DefaultView;
                dv.Sort ="FacG_Code"; //정렬을 할 컬럼 지정
                DataRowView[] rows = dv.FindRows(txtFacG_Code.Text); //Sort속성에서 지정한 컬럼을 대상으로 검색
                if (rows.Length > 0)
                    if (DialogResult.OK == (MessageBox.Show("이미 존재하는 코드입니다. 입력한 정보로 수정하시겠습니까?", "코드중복", MessageBoxButtons.OKCancel)))
                    {
                        Insert();
                    }
                    else
                        return;
                else
                    Insert();
            }
            else
                Insert();
          
            
        }
        private void Insert()
        {
            string facG_Code = txtFacG_Code.Text;
            string facG_Name = txtFacG_Name.Text;
            string facG_UserOrNot = cboFacG_UseOrNot.Text;
            string facG_Modifier = txtFacG_Modifier.Text;
            DateTime facG_ModifyDate = DateTime.Now;
            string facG_Info = txtFacG_Info.Text;

            FacilityService service = new FacilityService();
            check = service.FacilityGInfoRegi(facG_Code, facG_Name, facG_UserOrNot, facG_Modifier, facG_ModifyDate, facG_Info);
            if (check)
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
