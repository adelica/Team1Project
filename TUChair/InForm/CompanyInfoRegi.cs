using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;
using TUChairVO;

namespace TUChair
{
    public partial class CompanyInfoRegi : TUChair.POPUPForm3Line
    {
        string corpRegiNum = string.Empty;
        bool check = false;
        bool newInsert = true;
        List<string> codeList=null;

        public bool Check
        {
            get { return check; }
        }
        public CompanyInfoRegi()
        {
            InitializeComponent();
        }
        public CompanyInfoRegi(List<ComboItemVO> cList, List<string> codes) //신규등록
        {
            InitializeComponent();
            txtCom_Modifier.Enabled = false;
            txtCom_ModiflyDate.Enabled = false;
            CommonUtil.ComboBinding(cboCom_Type, cList);
            CommonUtil.CboSetting(cboCom_Type);

            commonService service = new commonService();
            List<ComboItemVO> comboItems = service.getCommonCode("사용여부");
            List<ComboItemVO> uList = (from item in comboItems
                     where item.CodeType == "사용여부"
                     select item).ToList();
            CommonUtil.ComboBinding(cboCom_UseOrNot, uList, "선택");

            codeList = codes;
        }

        public CompanyInfoRegi(List<ComboItemVO> cList,List<string> codes, List<CompanyVO> updateList) : this(cList, codes) //수정
        {
            txtCom_Code.Text = updateList[0].Com_Code;
            txtCom_Email.Text = updateList[0].Com_Email;
            txtCom_Information.Text = updateList[0].Com_Information;
            txtCom_Manager.Text = updateList[0].Com_Manager;
            txtCom_Modifier.Text = updateList[0].Com_Modifier;
            txtCom_ModiflyDate.Text = updateList[0].Com_ModiflyDate.ToString();
            txtCom_Name.Text = updateList[0].Com_Name;
            txtCom_Owner.Text = updateList[0].Com_Owner;
            txtCom_Phone.Text = updateList[0].Com_Phone;
            txtCom_Sector.Text = updateList[0].Com_Sector;
            string[] crn = updateList[0].Com_CorporRegiNum.Split('-');
            if(crn.Length<3)
            {
                txtCopRegiNum1.Text = txtCopRegiNum2.Text = txtCopRegiNum3.Text = "";  
            }
            else
            {
                txtCopRegiNum1.Text = crn[0];
                txtCopRegiNum2.Text = crn[1];
                txtCopRegiNum3.Text = crn[2];
            }
         
            cboCom_Type.Text = updateList[0].Com_Type;
            cboCom_UseOrNot.Text = updateList[0].Com_UseOrNot;

            txtCom_Code.Enabled = false;
            newInsert = false;
        }

        private CompanyVO Company
        {
            get
            {
                CompanyVO com = new CompanyVO();
                com.Com_Code = txtCom_Code.Text;
                com.Com_CorporRegiNum = corpRegiNum;
                com.Com_Email = txtCom_Email.Text;
                com.Com_Information = txtCom_Information.Text;
                com.Com_Manager = txtCom_Manager.Text;
                com.Com_Modifier = LoginFrm.userName;
                com.Com_ModiflyDate = DateTime.Now;
                com.Com_Name = txtCom_Name.Text;
                com.Com_Owner = txtCom_Owner.Text;
                com.Com_Phone = txtCom_Phone.Text;
                com.Com_Sector = txtCom_Sector.Text;
                com.Com_Type = cboCom_Type.Text;
                com.Com_UseOrNot = cboCom_UseOrNot.Text;

                return com;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(txtCom_Code.Text.Trim().Length<1 || txtCom_Name.Text.Trim().Length<1|| cboCom_Type.SelectedIndex.Equals(0) || cboCom_UseOrNot.SelectedIndex.Equals(0))
            {
                CommonUtil.RequiredInfo();
                return;
            }

            if ((txtCopRegiNum1.Text.Trim().Length + txtCopRegiNum2.Text.Trim().Length + txtCopRegiNum3.Text.Trim().Length) == 0)
                corpRegiNum = "";
            else
            {
                if(txtCopRegiNum1.Text.Trim().Length<3||txtCopRegiNum2.Text.Trim().Length<2||txtCopRegiNum3.Text.Trim().Length<5)
                {
                    MessageBox.Show("사업자등록번호를 전부 입력하지 않았습니다.", "등록실패");
                    return;
                }
                else
                     corpRegiNum = $"{txtCopRegiNum1.Text}-{txtCopRegiNum2.Text}-{txtCopRegiNum3.Text}";
            }
                

            if (newInsert)
            {
                var codeChk = (from chk in codeList
                              where this.Company.Com_Code == chk
                              select chk).ToList();
               if (codeChk.Count>0)
                {
                    MessageBox.Show("해당 코드가 이미 존재합니다.","등록실패");
                    return;
                }
                else
                {
                    Insert();
                }
               
            }
            else
            {
                Insert();
            }

            
        }
        private void Insert()
        {
            CompanyService service = new CompanyService();
            check = service.CompanyInfoRegi(this.Company);
            if (check)
            {
                MessageBox.Show("등록되었습니다.", "등록완료");
                this.Close();
            }
        }
        private void txtCom_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsDigit(e.KeyChar) ||e.KeyChar==Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
