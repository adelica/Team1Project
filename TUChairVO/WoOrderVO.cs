using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
   public class WoOrderVO
   {
        public int WorkOrderID { get; set; }
        public int Pro_ID { get; set; }
        public string Item_Code { get; set; }
        
             public string Item_Name { get; set; }
        public int Plan_Qty { get; set; }
        public DateTime Plan_Date { get; set; }
        public DateTime Prd_Date { get; set; }
        public string Wo_State { get; set; }
        public string Wo_Order { get; set; }
        public DateTime Plan_StartTime { get; set; }
        public DateTime Plan_EndTime { get; set; }
        public int In_Qty_Main { get; set; }
        public int Out_Qty_Main { get; set; }
        public int Prd_Qty { get; set; }
        public string Sales_ID { get; set; }
        public string Remark { get; set; }
        public DateTime Up_Date { get; set; }
        public string Up_Emp { get; set; }
        public string Item_InWarehouse { get; set; }
        public string Item_OutWarehouse { get; set; }
        
             public string Deduction { get; set; }
    }
}
