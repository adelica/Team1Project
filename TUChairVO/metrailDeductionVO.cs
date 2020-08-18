using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
   public  class metrailDeductionVO
    {
        public int WorkOrderID { get; set; }
        public DateTime   Plan_StartTime { get; set; }
        public string   Item_Code { get; set; }
        public string   Item_Name { get; set; }
        public string   Item_Size { get; set; }
        public string   Item_Type { get; set; }
        public string   Item_OutWarehouse { get; set; }
        public string   Item_InWarehouse { get; set; }
        public int   Qty { get; set; }
        public int   Plan_Qty { get; set; }
    }
}
