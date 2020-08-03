using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
    public class UnitPriceVO
    {

        public int PriceNO { get; set; }
        public string Com_Code { get; set; }
        public string Item_Code { get; set; }
        public int Price_Present { get; set; }
        public int Price_transfer { get; set; }
        public string Price_StartDate { get; set; }
        public string Price_EndDate { get; set; }
        public string Price_UserOrNot { get; set; }
        public string Modifier { get; set; }
        public string ModifierDate { get; set; }
        public string Unit_Other { get; set; }


    }
    public class ViewUnitPriceVO
    {
        public int PriceNO { get; set; }
        public string Com_Code { get; set; }
        public string Com_Name { get; set; }
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
        public string Item_Size { get; set; }
        public string Item_Unit { get; set; }

        public int Price_Present { get; set; }
        public int Price_transfer { get; set; }
        public string Price_StartDate { get; set; }
        public string Price_EndDate { get; set; }
        public string Price_UserOrNot { get; set; }
        public string Modifier { get; set; }
        public string ModifierDate { get; set; }
        public string Unit_Other { get; set; }

    }
}
