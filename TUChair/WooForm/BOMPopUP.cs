using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;
using TUChairVO;

namespace TUChair
{
    public partial class BOMPopUP : POPUp2Line
    {
        List<ComboItemVO> comboItems = null;
        private BOMVO bomInfo;
        public string user
        {
            get { return user; }
            set
            {
                txtModifier.Text = value;
            }
        }
        public BOMVO BomInfo
        {
            get
            {
                BOMVO bom = new BOMVO();
                bom.Item_Code          =         cboItem.Text          ;
                bom.ParentItem_Code    =         cboParentItem.Text    ;
                bom.BOM_Require        =         (int)nmRequied.Value       ;
                bom.BOM_StartDate      =         dtpStart.Value        ;
                bom.BOM_EndDate        =         dtpEnd.Value          ;
                bom.BOM_UserOrNot      =         cboUseOrNot.Text      ;
                bom.BOM_Modifier       =         txtModifier.Text      ;
                bom.BOM_AutoDeducion   =         cboAutoRedution.Text  ;
                bom.BOM_RequirePlan      = cboUsePlan.Text;
                bom.BOM_Others          = txtOther.Text;
                bom.BOM_Modifier = txtModifier.Text;
                bom.BOM_No = Convert.ToInt32(this.Tag);
                bomInfo = bom;
                return bomInfo;
            }
            set
            {
                  cboItem.Text           = value.Item_Code           ;
                  cboParentItem.Text     = value.ParentItem_Code     ;
                  nmRequied.Value        = value.BOM_Require         ;
                  dtpStart.Value         = value.BOM_StartDate       ;
                  dtpEnd.Value           = value.BOM_EndDate         ;
                  cboUseOrNot.Text       = value.BOM_UserOrNot       ;
                  txtModifier.Text       = value.BOM_Modifier        ;
                  cboAutoRedution.Text   = value.BOM_AutoDeducion    ;
                  cboUsePlan.Text        = value.BOM_RequirePlan     ;
                  txtOther.Text          = value.BOM_Others          ;
                  this.Tag               = value.BOM_No              ;
            }
        }
        public BOMPopUP()
        {
            InitializeComponent();
        }
        public BOMPopUP(string user)
        {
            InitializeComponent();
            this.user = user;
            #region combo바인딩
            commonService service = new commonService();
            comboItems = service.getCommonCode("반제품@원자재@사용여부@완제품");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "반제품" || item.CodeType == "완제품" || item.CodeType=="원자재"
                                       orderby item.CodeType
                                       select item).ToList();
            CommonUtil.ReComboBinding(cboItem, cList, "");
            cList = (from item in comboItems
                     where item.CodeType == "반제품" || item.CodeType == "완제품"
                     orderby item.CodeType
                     select item).ToList();
            CommonUtil.ReComboBinding(cboParentItem, cList, "");
            cList = (from item in comboItems
                     where item.CodeType == "사용여부"
                     select item).ToList();
            CommonUtil.ComboBinding(cboUseOrNot, cList, "");
            cList = (from item in comboItems
                     where item.CodeType == "사용여부"
                     select item).ToList();
            CommonUtil.ComboBinding(cboUsePlan, cList, "");
            cList = (from item in comboItems
                     where item.CodeType == "사용여부"
                     select item).ToList();
            CommonUtil.ComboBinding(cboAutoRedution, cList, "");
           
            #endregion
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtModifier.Text == "" || cboAutoRedution.Text == "" || cboItem.Text == "" || cboUsePlan.Text == ""|| cboUseOrNot.Text == "")
            {
                MessageBox.Show("필수항목은 입력하셔야 합니다.");
                return;
            }
            try
            {
                BOMService service = new BOMService();
                if (service.SaveBOM(this.BomInfo))
                {
                    MessageBox.Show("저장되었습니다.");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("저장에 실패하였습니다.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
