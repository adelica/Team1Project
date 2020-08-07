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
    public partial class CompanyInfoRegi : TUChair.POPUPForm3Line
    {
        public CompanyInfoRegi()
        {
            InitializeComponent();
        }
        public CompanyInfoRegi(List<ComboItemVO> cList)
        {
            InitializeComponent();
            txtCom_Modifier.Enabled = false;
            txtCom_ModiflyDate.Enabled = false;
            CommonUtil.ComboBinding(cboCom_Type, cList, "선택");
            CommonUtil.CboSetting(cboCom_Type);

            commonService service = new commonService();
            List<ComboItemVO> comboItems = service.getCommonCode("사용여부");
            List<ComboItemVO> uList = (from item in comboItems
                     where item.CodeType == "사용여부"
                     select item).ToList();
            CommonUtil.ComboBinding(cboCom_UseOrNot, uList, "선택");
        }
    }
}
