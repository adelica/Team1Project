using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
   public class balzuVO
    {
     public string Com_Code                 {get; set;}
     public string Materail_Order_State     {get; set;}
     public string Item_Name                {get; set;}
     public string Item_Code                {get; set;}
     public string Item_Size                {get; set;}
     public string Vo_ID                    {get; set;}
     public string Item_Unit                {get; set;}
     public string Vo_InDate                  {get; set;}
     public int      Vo_Quantity              {get; set;}
     public string Vo_EndDate                { get; set; }
     public string Vo_StarDate              { get; set; }
     public int    Vo_Price                 { get; set; }
   


    }
    public class PbalzuVO
    {
          public string      Com_Name             {get; set;}
          public string      Com_Type            {get; set;}
          public string      Item_Name           {get; set;}
          public string      Item_Code           {get; set;}
          public string      Item_Size           {get; set;}
          public int         Qty                  {get; set;}
          public DateTime    duedate              {get; set;}
          public string      isbalzu              { get; set; }
          public string      Com_CorporRegiNum    { get; set; }
          public int?        Price_Present            { get; set; }
          public int?        price                   { get; set; }
    
    }
    public class StockVO
    {
        public string  Fact_Code     { get; set; }
        public string  Item_Code     { get; set; }
        public string  Insert_Date   { get; set; }
        public string  Qty           { get; set; }
        public string  Stock_Other   { get; set; }
    }
}         
          