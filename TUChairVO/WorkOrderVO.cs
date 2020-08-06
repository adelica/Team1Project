using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
   public  class WorkOrderVO
    {
      public int WorkOrderID { get; set; }
      public  string  So_WorkOrderID { get; set; }
        public  string  Item_Code { get; set; }
        public  int  Plan_Qty { get; set; }
        public  DateTime  Plan_Date { get; set; }
        public DateTime Prd_Date { get; set; }
        public  string  Wo_State { get; set; }
        public  int  Wo_Order { get; set; }
        public DateTime Plan_StartTime { get; set; }
        public DateTime Plan_EndTime { get; set; }
        public  int  In_Qty_Main { get; set; }
        public  int  Out_Qty_Main { get; set; }
        public  int  Prd_Qty { get; set; }
        public  string  Wo_Req_No { get; set; }
        public  string  Remark { get; set; }
        public DateTime Up_Date { get; set; }
        public  string  Up_Emp { get; set; }

    }
}
