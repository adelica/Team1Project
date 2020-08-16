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
    public partial class BORInfoRegi : TUChair.POPUp2Line
    {
        List<BORVO> list;
        bool check = false;
        bool newInsert = true;
        public bool Check { get {return check; }}
        public BORInfoRegi()
        {
            InitializeComponent();
        }

        public BORInfoRegi(List<BORVO> borList) : this()
        {
            list = borList;

            List<string> facG = (from code in list
                                 select code.FacG_Code).Distinct().ToList();
            List<string> item = (from code in list
                                 select code.Item_Code).Distinct().ToList();
            List<string> faci = (from code in list
                                 select code.Faci_Code).Distinct().ToList();

            foreach (var cb in facG)
                cboFacG_Code.Items.Add(cb);
            foreach (var cb in item)
                cboItem_Code.Items.Add(cb);
            foreach (var cb in faci)
                cboFaci_Code.Items.Add(cb);
            commonService service = new commonService();

            List<ComboItemVO> comboItems = service.getCommonCode("사용여부");

            List<ComboItemVO> cList = (from uon in comboItems
                                       where uon.CodeType == "사용여부"
                                       select uon).ToList();
            CommonUtil.ComboBinding(cboUseOrNot, cList, "선택");
            CommonUtil.CboSetting(cboUseOrNot);
            CommonUtil.CboSetting(cboFacG_Code);
            CommonUtil.CboSetting(cboItem_Code);
            CommonUtil.CboSetting(cboFaci_Code);
        }

        public BORInfoRegi(List<BORVO> list, List<BORVO> borList) :this(borList)
        {
            cboFacG_Code.Enabled = cboFaci_Code.Enabled = cboItem_Code.Enabled = false;
            BORVO item = list[0];

            cboFacG_Code.Text =item.FacG_Code ;
            cboFaci_Code.Text = item.Faci_Code;
            cboItem_Code.Text = item.Item_Code;
            txtTactTime.Text = item.BOR_TactTime.ToString();
            txtPriority.Text = item.BOR_Priority.ToString();
            txtYeild.Text = item.BOR_Yeild.ToString();
            txtProcessLead.Text = item.BOR_ProcessLeadDate.ToString();
            cboUseOrNot.Text = item.BOR_UseOrNot;
            txtOther.Text = item.BOR_Other;

            newInsert = false;
        }

        private void txtInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        private void txtIntervalPlus_KeyPress(object sender, KeyPressEventArgs e) //숫자와 백스페이스, 마침표를 제외한 나머지를 바로 처리. 점은 한 번만 찍힘
        {

            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || (txtYeild.Text.Trim().Length>0 && e.KeyChar == 46 && !txtYeild.Text.Contains('.'))))
            {  
                e.Handled = true;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(txtTactTime.Text.Trim().Length<1 ||txtPriority.Text.Trim().Length<1 || cboUseOrNot.SelectedIndex==0)
            {
                CommonUtil.RequiredInfo();
                return;
            }
            if (newInsert)
            {
                List<BORVO> check = (from chk in list
                                     where chk.FacG_Code == cboFacG_Code.SelectedItem.ToString() && chk.Faci_Code == cboFaci_Code.SelectedItem.ToString() &&
                                     chk.Item_Code== cboItem_Code.SelectedItem.ToString()
                                     select chk).ToList();
                if (check.Count > 0)
                {
                    if (DialogResult.OK == (MessageBox.Show("이미 존재하는 BOR입니다. 입력한 정보로 수정하시겠습니까?", "코드중복", MessageBoxButtons.OKCancel)))
                    {
                        Insert();
                    }
                    else
                        return;
                }
                else
                    Insert();
            }
            else
                Insert();
        }
        public void Insert()
        {
            string itemCode = cboItem_Code.SelectedItem.ToString();
            string facgCode = cboFacG_Code.SelectedItem.ToString();
            string faciCode = cboFaci_Code.SelectedItem.ToString();
            int tactT = Convert.ToInt32(txtTactTime.Text);
            int priority = Convert.ToInt32(txtPriority.Text);
            decimal yeild = txtYeild.Text=="" ? Convert.ToDecimal(0) : Convert.ToDecimal(txtYeild.Text);
            string useOrNot = cboUseOrNot.Text;
            string other = txtOther.Text;
            int processLead =txtProcessLead.Text==""?0:  Convert.ToInt32(txtProcessLead.Text);

            BORService service = new BORService();
            check = service.BORInfoRegi(itemCode, facgCode, faciCode, tactT, priority, yeild, processLead,useOrNot, other);
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
