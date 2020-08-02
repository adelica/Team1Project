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

        public List<string> Combolist { get; set; }

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
                if (Combolist.Contains(list[i].Com_Name))
                    Combolist.Add(list[i].Com_Name);
            }
            x.Items.AddRange(Combolist.ToArray());
            Combolist.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                if (Combolist.Contains(list[i].Item_Code))
                    Combolist.Add(list[i].Item_Code);
            }
            cboItemCode.Items.AddRange(Combolist.ToArray());
            Combolist.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                if (Combolist.Contains(list[i].Item_Name))
                    Combolist.Add(list[i].Item_Name);
            }
            cboItemName.Items.AddRange(Combolist.ToArray());
            Combolist.Clear();



            string[] UseOrNot = new string[2] { "사용", "미사용" };



            cboUseOrNot.Items.AddRange(UseOrNot);

            CommonUtil.CboSetting(cboComCode);
            CommonUtil.CboSetting(cboComName);
            CommonUtil.CboSetting(cboComno);
            CommonUtil.CboSetting(cboItemCode);
            CommonUtil.CboSetting(cboItemName);
            CommonUtil.CboSetting(cboItemSize);
            CommonUtil.CboSetting(cboItemUnit);
            CommonUtil.CboSetting(cboUseOrNot);


        }

   
    }
}
