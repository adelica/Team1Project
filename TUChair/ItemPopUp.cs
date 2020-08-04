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

        public ItemVO Item
        {
            get {
                ItemVO pItem = new ItemVO();
                pItem.Item_Code         =           txtitemID.Text;
                pItem.Item_Importins    =      cboIsincom.Text;
                pItem.Item_InWarehouse   =    cboInWare.Text;
                pItem.Item_Manager      =        cboManager.Text;
                pItem.Item_Modifier      =        txtModifier.Text;
                pItem.Item_Name             =           txtItemName.Text;
                pItem.Item_OrderComp        =      cboSellCom.Text;
                pItem.Item_Other            =          textBox3.Text;
                pItem.Item_OutWarehouse     =    cboOutWare.Text;
                pItem.Item_Processins   =     cboIsfact.Text;
                pItem.Item_SafeQuantity  =   (int)numSafeItemQty.Value;
                pItem.Item_Shipmentins  =    cboIsOut.Text;
                pItem.Item_Size             =           txtitemStandard.Text;
                pItem.Item_Type         =           cboItemType.Text;
                pItem.Item_Unit          =           cboUnit.Text;
                pItem.Item_UserOrNot         =      cboUseorNot.Text;
                //pItem.
                return item;
            }
            set {
                item = value;
                txtitemID.Text =                   item.Item_Code              ;      
                cboIsincom.Text            =       item.Item_Importins         ;
                cboInWare.Text             =       item.Item_InWarehouse       ;
                cboManager.Text            =       item.Item_Manager           ;
                txtModifier.Text           =       item.Item_Modifier          ;
                txtItemName.Text           =       item.Item_Name              ;
                cboSellCom.Text            =       item.Item_OrderComp         ;
                textBox3.Text              =       item.Item_Other             ;
                cboOutWare.Text            =       item.Item_OutWarehouse      ;
                cboIsfact.Text             =       item.Item_Processins        ;
                numSafeItemQty.Value  =            item.Item_SafeQuantity      ;
                cboIsOut.Text              =       item.Item_Shipmentins       ;
                txtitemStandard.Text       =       item.Item_Size              ;
                cboItemType.Text           =       item.Item_Type              ;
                cboUnit.Text               =       item.Item_Unit              ;
                cboUseorNot.Text           =       item.Item_UserOrNot;
            }
        }



        public ItemPopUp()
        {
            InitializeComponent();
        }
        private void ItemPopUp_Load(object sender, EventArgs e)
        {
            #region combo바인딩
            commonService service = new commonService();
            comboItems = service.getCommonCode("고객사@창고@User@사용여부@품목유형@단위@협력업체");

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
            #endregion
        }

    }
}
