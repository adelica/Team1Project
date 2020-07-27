using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
   public  class ShiftVO
    {
  

        public string Shift_ID { get; set; }
        public string Fac_Code { get; set; }
        public string Shift_StartTime { get; set; }
        public  string Shift_EndTime { get; set; }       
        public DateTime Shift_StartDate { get; set; }
        public DateTime Shift_EndDate { get; set; }
        public int Shift_InputPeople { get; set; }
        public string Shift_UserOrNot { get; set; }
        public string Shift_Modifier { get; set; }
        public DateTime Shift_ModifierDate { get; set; }
        

    }
}
