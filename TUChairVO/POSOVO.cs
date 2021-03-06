﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
    public class POVO
    {
       public string   So_WorkOrderID { get; set; }
        public string   So_PurchaseOrder { get; set; }
        public string   Com_Code { get; set; }
        public string   Com_Name { get; set; }
        public string   Item_Code { get; set; }
        public string   Item_Name { get; set; }
        public DateTime   So_Duedate { get; set; }
        public int   So_Qty { get; set; }
        public int   So_ShipQty { get; set; }
        public DateTime Sales_Plandate { get; set; }
    }
    public class SOVO
    {
        public string So_WorkOrderID { get; set; }
        public string So_PurchaseOrder { get; set; }
        public string Com_Code { get; set; }
        public string Com_Name { get; set; }
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
        public DateTime So_Duedate { get; set; }
        public int So_Qty { get; set; }
        public int So_ShipQty { get; set; }
        public string So_Other { get; set; }
    }
    public class UpLoadVO
    {
      public string  Sales_ID { get; set; }
        public string  Com_Code { get; set; }
        public int  Sales_Qty { get; set; }
        public DateTime Sales_Plandate { get; set; }
        public string  Item_Code { get; set; }
        public string  So_WorkOrderID { get; set; }
        public DateTime So_Duedate { get; set; }
        public string Modifier { get; set; }

    }
    public class SalesIDVO
    {
        public string Sales_ID { get; set; }
    }
}
