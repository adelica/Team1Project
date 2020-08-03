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
    public partial class UnitPricePopUp : TUChair.POPUp2Line
    {
       
        List<UnitPriceVO> list;

        public List<string> Comname = new List<string>();
        public List<string> Comicode = new List<string>();
        public List<string> Cominame = new List<string>();


        public Dictionary<string, string> uptdic { get; set; }
        public string uporInsert { get; set; }
        public UnitPricePopUp()
        {
            InitializeComponent();
        }

        private void UnitPricePopUp_Load(object sender, EventArgs e)
        {

            MessageBox.Show(LoginFrm.userName);
            ComboBoxBinding();
            //if (uporInsert == "Update")
            //{
            //    c.Text = uptdic["ShiftID"];
            //    cboShift.SelectedItem = uptdic["설비명"];
            //    txtStartTime.Text = uptdic["시작시간"];
            //    txtEndTime.Text = uptdic["종료시간"];
            //    dtpStartDate.Value = Convert.ToDateTime(uptdic["시작일"]);
            //    dtpEndDate.Value = Convert.ToDateTime(uptdic["종료일"]);
            //    txtPeople.Text = uptdic["투입인원"];
            //    cboUseOrNot.SelectedItem = uptdic["사용유무"];
            //    txtModifyName.Text = uptdic["수정자"];
            //    dtpModifyDate.Value = Convert.ToDateTime(uptdic["수정일"]);
            //    txtRemark.Text = uptdic["비고"];
            //}
        }
        private void ComboBoxBinding() // 각 콤보박스에 선택지 바인딩
        {
            //commonService service = new commonService();
            //List<ComboItemVO> allList = service.getCommonCode("");

            //cList = (from item in allList
            //         where item.CodeType == "Categories"
            //         select item).ToList();
            //CommonUtil.ComboBinding(cboCategories, cList, "선택");


            //JeanService service = new JeanService();
            //list = service.UPBinding();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Comname.Add(list[i].Com_Name);
            //}
            //Comname = Comname.Distinct().ToList();
            //cboComName.Items.AddRange(Comname.ToArray());

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Comicode.Add(list[i].Item_Code);
            //}
            //Comicode = Comicode.Distinct().ToList();
            //cboItemCode.Items.AddRange(Comicode.ToArray());

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Cominame.Add(list[i].Item_Name);
            //}
            //Cominame = Cominame.Distinct().ToList();
            //cboItemName.Items.AddRange(Cominame.ToArray());



            string[] UseOrNot = new string[2] { "사용", "미사용" };



            cboUseOrNot.Items.AddRange(UseOrNot);


            ////CommonUtil.CboSetting(cboComCode);
            //CommonUtil.CboSetting(cboComName);
            ////CommonUtil.CboSetting(cboComno);
            //CommonUtil.CboSetting(cboItemCode);
            //CommonUtil.CboSetting(cboItemName);
            //// CommonUtil.CboSetting(cboItemSize);
            //// CommonUtil.CboSetting(cboItemUnit);
            //CommonUtil.CboSetting(cboUseOrNot);
            txtModifier.Text = LoginFrm.userName;
            txtModifierdate.Text = DateTime.Now.ToString();

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cboComName.Text.Trim().Length < 1 || cboItemCode.Text.Trim().Length < 1 ||  txtPriceP.Text.Trim().Length < 1)
            {
                CommonUtil.RequiredInfo();
                return;
            }



            UnitPriceVO upv = new UnitPriceVO();
            upv.Item_Code = cboItemCode.SelectedItem.ToString();
            upv.Price_Present = int.Parse(txtPriceP.Text);
            upv.Price_StartDate = dtpStart.Value.ToShortDateString();
            upv.Modifier = txtModifier.Text;
            upv.ModifierDate = txtModifierdate.Text;

            JeanService service = new JeanService();
            bool Result = service.InsertOrUpdate(upv);
            if (Result)
            {
                MessageBox.Show("등록되었습니다.", "등록완료");
                this.Close();
            }
        }


        private void txtPriceP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
    }
}
