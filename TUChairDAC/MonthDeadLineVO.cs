using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairDAC
{
    public class MonthDeadLineVO
    {
       public string Com_code           {get;set;}
       public string Com_name           {get;set;}
       public string CorporRegiNum      {get;set;}
     

        public int    ALLPrice           {get;set;}
       public string Type               {get;set;}
       public string YorN               { get; set; }
    }
    public class MonthDLDetail
    {
        public string Com_Name              {get;set;}
        public string Date              {get;set;}
        public string Fact_Name             {get;set;}
        public string Category          {get;set;}
        public string Item_Code     {get;set;}
        public string Item_Name         { get;set;}
        public string Item_Size         { get;set;}
        public int    Qty               {get;set;}
        public int    Price             {get;set;}
        public int    AllPrice      { get; set; }

    }
}
