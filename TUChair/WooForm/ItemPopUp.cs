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
    public partial class ItemPopUp : POPUPForm3Line
    {
       

        List<ComboItemVO> comboItems = null;
        private ItemVO item;
        public string user
        {
            get { return user; }
            set {
                 txtModifier.Text = value;
                } 
        }
        public ItemVO Item
        {
            get {
                ItemVO pItem = new ItemVO();
                pItem.Item_Code          =           txtitemID.Text;
                pItem.Item_Importins     =      cboIsincom.Text;
                pItem.Item_InWarehouse     =    cboInWare.Text;
                pItem.Item_Manager        =        cboManager.Text;
                pItem.Item_Modifier       =        txtModifier.Text;
                pItem.Item_Name             =           txtItemName.Text;
                pItem.Item_OrderComp         =      cboSellCom.Text;
                pItem.Item_Other            =          textBox3.Text;
                pItem.Item_OutWarehouse     =    cboOutWare.Text;
                pItem.Item_Processins    =     cboIsfact.Text;
                pItem.Item_SafeQuantity    =   (int)numSafeItemQty.Value;
                pItem.Item_Shipmentins   =    cboIsOut.Text;
                pItem.Item_Size             =           txtitemStandard.Text;
                pItem.Item_Type          =           cboItemType.Text;
                pItem.Item_Unit          =           cboUnit.Text;
                pItem.Item_UserOrNot         =      cboUseorNot.Text;
                pItem.Item_OutSourcing   = cboOutsorching.Text;
         

                //pItem.
                item = pItem;
                return item;
            }
            set {
                item = value;
                txtitemID.Text =                   item.Item_Code              ;      
               ((ComboItemVO)cboIsincom.SelectedItem).CodeNm    =       item.Item_Importins         ;
                ((ComboItemVO)cboInWare.SelectedItem).CodeNm =       item.Item_InWarehouse       ;
                ((ComboItemVO)cboManager.SelectedItem).CodeNm =       item.Item_Manager           ;
                txtModifier.Text                              =       item.Item_Modifier          ;
                txtItemName.Text                              =       item.Item_Name              ;
                ((ComboItemVO)cboSellCom.SelectedItem).CodeNm =       item.Item_OrderComp         ;
                textBox3.Text                                =       item.Item_Other             ;
                 ((ComboItemVO)cboOutWare.SelectedItem).CodeNm =       item.Item_OutWarehouse      ;
                ((ComboItemVO)cboIsfact.SelectedItem).CodeNm =       item.Item_Processins        ;
                numSafeItemQty.Value                        =            item.Item_SafeQuantity      ;
                ((ComboItemVO)cboIsOut.SelectedItem).CodeNm =       item.Item_Shipmentins       ;
                txtitemStandard.Text                       =       item.Item_Size              ;
                 ((ComboItemVO)cboItemType.SelectedItem).CodeNm =       item.Item_Type              ;
                 ((ComboItemVO)cboUnit.SelectedItem).CodeNm =       item.Item_Unit              ;
                 ((ComboItemVO)cboUseorNot.SelectedItem).CodeNm =       item.Item_UserOrNot         ;
                ((ComboItemVO)cboOutsorching.SelectedItem).CodeNm = item.Item_OutSourcing;
            }
        }
        public ItemPopUp()
        {
            InitializeComponent();
        }
        public ItemPopUp(string user)
        {
            InitializeComponent();
            this.user = user;
        }
        private void ItemPopUp_Load(object sender, EventArgs e)
        {
            #region combo바인딩
            commonService service = new commonService();
            comboItems = service.getCommonCode("고객사@창고@User@사용여부@품목유형@단위@협력업체@공정구분");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "고객사"
                                       select item).ToList();
            CommonUtil.ReComboBinding(cboSellCom, cList,"");
             cList = (from item in comboItems
                                       where item.CodeType == "품목유형"
                                       select item).ToList();
            CommonUtil.ComboBinding(cboItemType, cList, "");
            cList = (from item in comboItems
                     where item.CodeType == "협력업체"
                     select item).ToList();
            CommonUtil.ReComboBinding(cboBuyCom, cList, "");
            cList = (from item in comboItems
                     where item.CodeType == "창고"
                     select item).ToList();
            CommonUtil.ComboBinding(cboInWare, cList, "");
            cList = (from item in comboItems
                     where item.CodeType == "창고"
                     select item).ToList();
            CommonUtil.ComboBinding(cboOutWare, cList, "");
            cList = (from item in comboItems
                     where item.CodeType == "User"
                     select item).ToList();
            CommonUtil.ReComboBinding(cboManager, cList, "");
            cList = (from item in comboItems
                     where item.CodeType == "사용여부"
                     select item).ToList();
            CommonUtil.ComboBinding(cboIsfact, cList, "");
            cList = (from item in comboItems
                     where item.CodeType == "사용여부"
                     select item).ToList();
            CommonUtil.ComboBinding(cboIsincom, cList, "");
            cList = (from item in comboItems
                     where item.CodeType == "사용여부"
                     select item).ToList();
            CommonUtil.ComboBinding(cboIsOut, cList, "");
            cList = (from item in comboItems
                     where item.CodeType == "사용여부"
                     select item).ToList();
            CommonUtil.ComboBinding(cboUseorNot, cList, "");
            cList = (from item in comboItems
                     where item.CodeType == "단위"
                     select item).ToList();
            CommonUtil.ComboBinding(cboUnit, cList, "");
            cList = (from item in comboItems
                     where item.CodeType == "공정구분"
                     select item).ToList();
            CommonUtil.ComboBinding(cboOutsorching, cList, "");


            #endregion
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtitemID.Text == "" || txtItemName.Text == "" || cboUnit.Text == "" || cboItemType.Text == "" || cboIsfact.Text == "" || cboIsincom.Text == "" || cboIsOut.Text == "" || cboUseorNot.Text == "")
            {
                MessageBox.Show("필수항목은 입력하셔야 합니다.");
                return;
            }
            try
            {
                ItemService service = new ItemService();
                if (service.SaveItem(this.Item))
                {
                    MessageBox.Show("저장되었습니다.");
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
