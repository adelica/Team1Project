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
        List<ComboItemVO> comboItems = null;




        public UnitPricePopUp()
        {
            InitializeComponent();
        }

        private void UnitPricePopUp_Load(object sender, EventArgs e)
        {

            MessageBox.Show(LoginFrm.userName);
            ComboBoxBinding();

          
        }
        private void ComboBoxBinding() // 각 콤보박스에 선택지 바인딩
        {
            commonService service = new commonService();
            comboItems = service.getCommonCode("협력업체@Item@사용여부");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "협력업체"
                                       select item).ToList();
            CommonUtil.ReComboBinding(cboComCode, cList, "선택");

            cList = (from item in comboItems
                     where item.CodeType == "Item"
                     select item).ToList();
            CommonUtil.ReComboBinding(cboItemCode, cList, "선택");

            cList = (from item in comboItems
                     where item.CodeType == "사용여부"
                     select item).ToList();
            CommonUtil.ComboBinding(cboUseOrNot, cList, "선택");





            txtModifier.Text = LoginFrm.userName;
            txtModifierdate.Text = DateTime.Now.ToString();

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cboComCode.SelectedIndex ==0 ||cboItemCode.SelectedIndex == 0 ||  txtPriceP.Text.Trim().Length < 1)
            {
                CommonUtil.RequiredInfo();
                return;
            }



            UnitPriceVO upv = new UnitPriceVO();
            upv.Com_Code = cboComCode.Text.ToString();
            upv.Item_Code = cboItemCode.Text.ToString();
            upv.Price_Present = int.Parse(txtPriceP.Text);
            upv.Price_StartDate = dtpStart.Value.ToShortDateString();
            upv.Modifier = txtModifier.Text;
            upv.ModifierDate = txtModifierdate.Text;
            upv.Unit_Other = txtUnitOther.Text;
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
