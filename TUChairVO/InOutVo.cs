using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
    public class InOutVo
    {
       public string  Shift_date       {get;set;}
       public string  Gubun            {get;set;}
       public string  Category         {get;set;}
       public string  From_Fact        {get;set;}
       public string  Fact_Code        {get;set;}
       public string  Item_Code        {get;set;}
       public string  item_Name        {get;set;}
       public string  Item_Size        {get;set;}
       public string  Item_Type        {get;set;}
       public int  Shift_Qty        {get;set;}
       public int  Price_Present    {get;set;}
       public int  Price            {get;set;}
       public string modifier { get; set; }
    }
}
