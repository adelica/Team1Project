using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
    public class ProductOutVO
    {
        public string So_PurchaseOrder { get; set; }
        public string So_Duedate { get; set; }
        public string So_WorkOrderID { get; set; }
        public string Com_Code { get; set; }
        public string Com_Name { get; set; }
        public string d_Com_Code { get; set; }
        public string d_Com_Name { get; set; }
        public string Item_Code { get; set; }
        public string d_Item_Code { get; set; }

        public string Item_name { get; set; }
        public int    So_Qty { get; set; }
        public int    So_ShipQty { get; set; }
        public int    Out_Unit { get; set; }

    }
}
