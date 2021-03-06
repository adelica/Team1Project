﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
    public class ProcessShiftVO
    {
        public int No { get; set; }
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
        public string Fact_Code { get; set; }
        public string Fact_Name { get; set; }
        public string Fact_Type { get; set; }
        public string Insert_Date { get; set; }
        public int Qty { get; set; }
        public string Item_Size { get; set; }
        public string Item_Unit { get; set; }
        public string Stock_Other { get; set; }

        public string Item_Type { get; set; }

    }
    public class EXProcessShiftVO
    {
        public string No { get; set; }
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
        public string Fact_Code { get; set; }
        public string Fact_Name { get; set; }
        public string Fact_Type { get; set; }
        public string Insert_Date { get; set; }
        public int Qty { get; set; }
        public string Item_Size { get; set; }
        public string Item_Unit { get; set; }
        public string Stock_Other { get; set; }

    }
    public class PSMManager
    {

        public string Fact_Code { get; set; }
        public string Fact_Name { get; set; }
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
        public string Item_Type { get; set; }
        public string Item_Size { get; set; }
        public int Qty { get; set; }
        public string Item_Unit { get; set; }
        public string Stock_Other { get; set; }
        public string Insert_Date { get; set; }

    }


    public class StockShift
    {
        public int No { get; set; }
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
        public string Item_Size { get; set; }
        public string Item_Type { get; set; }
        public string Fact_Code { get; set; }
        
        public int Qty { get; set; }

        public string From_Fact { get; set; }

        public string Shift_date { get; set; }
        public int Shift_Qty { get; set; }
 
    }
}
