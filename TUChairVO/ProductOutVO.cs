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
        public int Price { get; set; }

        public int So_Qty { get; set; }
        public int So_ProQty { get; set; }
        public int Out_Unit { get; set; }
        public int Fact_Qty { get; set; }


    }

    public class CProductOutVO
    {
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
        public string Item_Size { get; set; }
        public string So_Duedate { get; set; }
        public int N_Qty { get; set; }
        public string Fact_Code { get; set; }
        public int Qty { get; set; }
        public string ToFact { get; set; }
        public int Out_Unit { get; set; }
        public string So_WorkOrderID { get; set; }
    }
}
