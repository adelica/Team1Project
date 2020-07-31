using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
    public class FacilityVO
    {
        public string Faci_Code { get; set; }
        public string FacG_Code { get; set; }
        public string Faci_Name { get; set; }
        public string Faci_OutWareHouse { get; set; }
        public string Faci_InWareHouse { get; set; }
        public string Faci_BadWareHouse { get; set; }
        public string Faci_UseOrNot { get; set; }
        public string Faci_Modifier { get; set; }
        public DateTime Faci_ModifyDate { get; set; }
        public string Faci_Detail { get; set; }
        public string Faci_Others { get; set; }

    }
    public class FacilityGroupVO
    {
        public string FacG_Code { get; set; }
        public string FacG_Name { get; set; }
        public string FacG_UseOrNot { get; set; }
        public string FacG_Modifier { get; set; }
        public DateTime FacG_ModifyDate { get; set; }
        public string FacG_Information { get; set; }

    }
}
