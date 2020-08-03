using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChairVO;
using TUChair.Util;
using System.Linq;

namespace TUChair
{
    public partial class FacilityInfoRegi : TUChair.POPUPForm3Line
    {
        List<ComboItemVO> comboItems = null;
        bool check=false;
        public bool Check{ get { return check; } }
        public FacilityInfoRegi()
        {
            InitializeComponent();     
        }
        public FacilityInfoRegi(DataTable dt):this()
        {
            txtFaci_Modifier.Enabled = false;
            txtFaci_Modifier.Text = LoginFrm.userName;
            txtModifyDate.Enabled = false;
            cboFacG_Code.DisplayMember = "FacG_Code";
            cboFacG_Code.ValueMember = "FacG_Code";
            cboFacG_Code.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e) //등록
        {
            if (txtFaci_Code.Text.Trim().Length < 1 || txtFaci_Name.Text.Trim().Length < 1)
            {
                CommonUtil.RequiredInfo();
                return;
            }
            else if (cboFaci_InWareHouse.SelectedIndex == 0 || cboFaci_OutWareHouse.SelectedIndex == 0||cboFaci_UseOrNot.SelectedIndex==0)
            {
                MessageBox.Show("필수 입력사항을 선택해주세요", "등록실패");
                return;
            }
            string facG_Code = cboFacG_Code.SelectedValue.ToString();
            string faci_Code = txtFaci_Code.Text;
            string faci_Name = txtFaci_Name.Text;
            string faci_Modifier = txtFaci_Modifier.Text;
            string faci_Detail = txtFaci_Detail.Text;
            string faci_Others = txtFaci_Others.Text;
            string faci_In = cboFaci_InWareHouse.Text;
            string faci_Out = cboFaci_OutWareHouse.Text;
            string faci_Bad= cboFaci_BadWareHouse.Text;
            string faci_UseOrNot = cboFaci_UseOrNot.Text;
            if (cboFaci_BadWareHouse.SelectedIndex == 0)
            {
                faci_Bad = string.Empty;
            }
            else
            {
                faci_Bad = cboFaci_BadWareHouse.SelectedValue.ToString();
            }
            DateTime faci_ModifyDate = DateTime.Now;
            FacilityService service = new FacilityService();
            check = service.FacilityInfoRegi(facG_Code, faci_Code, faci_Name, faci_Modifier, faci_Detail, faci_Others, faci_In, faci_Out, faci_Bad, faci_ModifyDate, faci_UseOrNot);
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

        private void FacilityInfoRegi_Load(object sender, EventArgs e)
        {
            CommonUtil.CboSetting(cboFacG_Code);


            commonService service = new commonService();
           
            comboItems = service.getCommonCode("사용여부@시설");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "사용여부"
                                       select item).ToList();
            CommonUtil.ComboBinding(cboFaci_UseOrNot, cList, "선택");
             cList = (from item in comboItems
                     where item.CodeType == "시설"
                      select item).ToList();
            CommonUtil.ComboBinding(cboFaci_BadWareHouse, cList, "선택");
            cList = (from item in comboItems
                     where item.CodeType == "시설"
                     select item).ToList();
            CommonUtil.ComboBinding(cboFaci_InWareHouse, cList, "선택");
            cList = (from item in comboItems
                     where item.CodeType == "시설"
                     select item).ToList();
            CommonUtil.ComboBinding(cboFaci_OutWareHouse, cList, "선택");


        }
    }
}
