using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
    public class BORVO
    {
        public int BOR_Code { get; set; }
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
        public string FacG_Code { get; set; }
        public string FacG_Name { get; set; }
        public string Faci_Code { get; set; }
        public string Faci_Name { get; set; }
        public int BOR_TactTime { get; set; }
        public int BOR_Priority { get; set; }
        public decimal BOR_Yeild { get; set; }
        public string BOR_UseOrNot { get; set; }
        public string BOR_Other { get; set; }
        public int BOR_ProcessLeadDate { get; set; }
    }
}
