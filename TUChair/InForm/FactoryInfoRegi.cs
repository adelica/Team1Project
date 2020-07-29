using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TUChairVO;
using TUChair.Util;
using TUChair.Service;

namespace TUChair
{
    public partial class FactoryInfoRegi : TUChair.POPUp2Line
    {
        List<FactoryVO> list;
        bool check = false;
        public bool Check 
        {
            get {return check; }
        }
        public FactoryInfoRegi()
        {
            InitializeComponent();
        }
        public FactoryInfoRegi(List<FactoryVO> list) : this()
        {
            this.list = list;
        }

        private void ComboBoxBinding() // 각 콤보박스에 선택지 바인딩
        {

            string[] cFactGroup = { "회사", "공장", "창고" }; //설비군
            string[] cClass = { "공장", "자재팀창고", "생산팀창고", "영업팀창고", "외주창고", "품질팀창고", "고객사창고" }; //시설구분
            string[] cUseOrNot = { "사용", "미사용" }; //사용유무
            List<string> cParent=null;  //상위시설
            cParent = (from cp in list
                       where cp.Fact_Group != "창고"
                       select cp.Fact_Group).ToList();

            cboFact_Group.Items.AddRange(cFactGroup);
            cboClass.Items.AddRange(cClass);
            cboUseOrNot.Items.AddRange(cUseOrNot);
            foreach (var cp in cParent)
            {
                cboParent.Items.Add(cp);
            }
            CommonUtil.ComboSetting(cboFact_Group);
            CommonUtil.ComboSetting(cboClass);
            CommonUtil.ComboSetting(cboUseOrNot);
            CommonUtil.ComboSetting(cboParent);
        }

        private void FactoryInfoRegi_Load(object sender, EventArgs e)
        {
            txtModifier.Enabled = false;
            txtModifyDate.Enabled = false;
            txtModifyDate.Text = DateTime.Now.ToString();
            txtModifier.Text = LoginFrm.userName;
            ComboBoxBinding();

        }

        private void btnInsert_Click(object sender, EventArgs e) //정보등록
        {
            if(txtFact_Code.Text.Trim().Length<1 || txtName.Text.Trim().Length<1)
            {
                MessageBox.Show("필수 입력사항을 입력해주세요.", "등록실패");
                return;
            }
            string fGroup = cboFact_Group.SelectedItem.ToString();
            string fParent = cboParent.SelectedItem.ToString();
            string fClass = cboClass.SelectedItem.ToString();
            string fCode = txtFact_Code.Text;
            string fName = txtName.Text;
            string fModifier= txtModifier.Text;
            DateTime fModifyDate = DateTime.Now;
            string fUseOrNot = cboUseOrNot.SelectedItem.ToString();
            string fInfo = txtInformation.Text;


            InService service = new InService();
            check = service.FactoryInfoRegi(fGroup, fParent, fClass, fCode, fName, fModifier, fModifyDate, fUseOrNot, fInfo);
           }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
