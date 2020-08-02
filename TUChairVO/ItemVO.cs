using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
   public class ItemVO
    {
      public string  Item_Code              {get; set;}
      public string  Item_Name              {get; set;}
      public string  Item_Size              {get; set;}
      public string  Item_Type              {get; set;}
      public int     Item_Qty               {get; set;}
      public string  Faci_Code              {get; set;}
      public string  Item_OrderComp         {get; set;}
      public string  Item_InWarehouse       {get; set;}
      public string  Item_OutWarehouse      {get; set;}
      public int     Item_MinOrderQuantity  {get; set;}
      public int     Item_SafeQuantity      {get; set;}
      public string  Item_Unit              {get; set;}
      public string  Item_Importins         {get; set;}
      public string  Item_Processins        {get; set;}
      public string  Item_Shipmentins       {get; set;}
      public string  Item_Grade             {get; set;}
      public string  Item_Manager           {get; set;}
      public string  Item_Modifier          {get; set;}
      public string  Item_ModiflyDate       {get; set;}
      public string  Item_UserOrNot         {get; set;}
      public string  Item_OrderMethod       {get; set;}
        public string Item_Other              {get; set;} 
    }
}
