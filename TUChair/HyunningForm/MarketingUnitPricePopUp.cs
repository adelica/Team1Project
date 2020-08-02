using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;
using TUChairVO;

namespace TUChair
{
    public partial class MarketingUnitPricePopUp : TUChair.POPUp2Line
    {
        List<UnitPriceVO> list;

        public List<string> Comname;
        public List<string> Comicode;
        public List<string> Cominame;


        public Dictionary<string, string> uptdic { get; set; }
        public string uporInsert { get; set; }
        public MarketingUnitPricePopUp()
        {
            InitializeComponent();
            
        }
        
        private void MarketingUnitPricePopUp_Load(object sender, EventArgs e)
        {
            JeanService service = new JeanService();
            list = service.ProductUPBinding();

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
            for (int i = 0; i < list.Count; i++)
            {
                if (Comname.Contains(list[i].Com_Name))
                    Comname.Add(list[i].Com_Name);
            }
            cboComName.Items.AddRange(Comname.ToArray());

            for (int i = 0; i < list.Count; i++)
            {
                if (Comicode.Contains(list[i].Item_Code))
                    Comicode.Add(list[i].Item_Code);
            }
            cboItemCode.Items.AddRange(Comicode.ToArray());

            for (int i = 0; i < list.Count; i++)
            {
                if (Cominame.Contains(list[i].Item_Name))
                    Cominame.Add(list[i].Item_Name);
            }
            cboItemName.Items.AddRange(Cominame.ToArray());



            string[] UseOrNot = new string[2] { "사용", "미사용" };



            cboUseOrNot.Items.AddRange(UseOrNot);

            //CommonUtil.CboSetting(cboComCode);
            CommonUtil.CboSetting(cboComName);
            //CommonUtil.CboSetting(cboComno);
            CommonUtil.CboSetting(cboItemCode);
            CommonUtil.CboSetting(cboItemName);
           // CommonUtil.CboSetting(cboItemSize);
           // CommonUtil.CboSetting(cboItemUnit);
            //CommonUtil.CboSetting(cboUseOrNot);


        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cboComCode.Text.Trim().Length < 1 || cboItemCode.Text.Trim().Length < 1 || cboItemName.Text.Trim().Length < 1 || txtPriceP.Text.Trim().Length < 1)
            {
                CommonUtil.RequiredInfo();
                return;
            }

           

            UnitPriceVO upv = new UnitPriceVO();
            upv.Com_Code = cboComCode.SelectedItem.ToString();
            upv.Item_Code = cboItemCode.SelectedItem.ToString();
            upv.Item_Name = cboItemName.SelectedItem.ToString();
            upv.Price_Present = int.Parse(txtPriceP.Text);
            upv.Price_StartDate = dtpStart.Value.ToShortDateString();

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
