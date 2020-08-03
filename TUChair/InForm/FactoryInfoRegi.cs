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
            ComboBoxBinding();
        }

        public FactoryInfoRegi(string facG_Code, string fact_Class, string fact_Code, string fact_Name, string fact_Parent, string fact_Info, string useOrNot, List<FactoryVO> list):this()
        {
            txtFact_Code.Enabled = false;
            this.list = list;
            ComboBoxBinding();
            cboFact_Group.Text= facG_Code;
            cboClass.Text= fact_Class;
            txtFact_Code.Text = fact_Code;
            txtName.Text = fact_Name;;
           cboParent.Text = fact_Parent;
           txtInformation.Text = fact_Info;
            cboUseOrNot.Text = useOrNot;

          
        }

        private void ComboBoxBinding() // 각 콤보박스에 선택지 바인딩
        {

            string[] cFactGroup = { "공장", "창고" }; //설비군
            string[] cClass = {"공장", "자재팀창고",  "생산팀창고",  "영업팀창고", "외주창고",  "품질팀창고",  "고객사창고" }; //시설구분
          
            List<string> cParent=null;  //상위시설
            cParent = (from cp in list
                       where cp.Fact_Group != "창고"
                       select cp.Fact_Code).ToList();

            cboFact_Group.Items.AddRange(cFactGroup);
            cboClass.Items.AddRange(cClass);

            commonService service = new commonService();

            List<ComboItemVO> comboItems = service.getCommonCode("사용여부");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "사용여부"
                                       select item).ToList();
            CommonUtil.ComboBinding(cboUseOrNot, cList, "선택");

            foreach (var cp in cParent)
            {
                cboParent.Items.Add(cp);
            }
            CommonUtil.CboSetting(cboFact_Group);
            CommonUtil.CboSetting(cboClass);
            CommonUtil.CboSetting(cboUseOrNot);
            CommonUtil.CboSetting(cboParent);
        }

        private void FactoryInfoRegi_Load(object sender, EventArgs e)
        {
            txtModifier.Enabled = false;
            txtModifyDate.Enabled = false;
            //txtModifyDate.Text = DateTime.Now.ToString();
            txtModifier.Text = LoginFrm.userName;
           

        }

        private void btnInsert_Click(object sender, EventArgs e) //정보등록
        {
            if(txtFact_Code.Text.Trim().Length<1 || txtName.Text.Trim().Length<1||cboUseOrNot.SelectedIndex==0)
            {
                CommonUtil.RequiredInfo();
                return;
            }

            string fGroup = cboFact_Group.SelectedItem.ToString();
            string fParent = cboParent.SelectedItem.ToString();
            string fClass = cboClass.SelectedItem.ToString();
            string fCode = txtFact_Code.Text;
            string fName = txtName.Text;
            string fModifier= txtModifier.Text;
            DateTime fModifyDate = DateTime.Now;
            string fUseOrNot = cboUseOrNot.Text;
            string fInfo = txtInformation.Text;
            string fType;
            switch (fClass)
            {
                case "공장":
                    fType = "FAC100";
                    break;
                case "자재팀창고":
                    fType = "FAC200";
                    break;
                case "생산팀창고":
                    fType = "FAC300";
                    break;
                case "영업팀창고":
                    fType = "FAC400";
                    break;
                case "외주창고":
                    fType = "FAC500";
                    break;
                case "품질팀창고":
                    fType = "FAC600";
                    break;
                case "고객사창고":
                    fType = "FAC700";
                    break;
                default:
                    fType = null;
                    break;
            }


            FactoryService service = new FactoryService();
            check = service.FactoryInfoRegi(fGroup, fParent, fClass, fCode, fName, fModifier, fModifyDate, fUseOrNot, fInfo, fType);
            if (check)
            {
                MessageBox.Show("등록되었습니다.", "등록완료");
                this.Close();
            }
            }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
