using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairDAC;
using TUChairVO;

namespace TUChair.Service
{
    class MeilingService
    {
        public List<ShiftVO> DBConnectionTEST()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.DBConnectionTEST();
        }
        public void InsertShiftInfo(string Shift_ID, string Fac_Code, string Shift_StartTime, string Shift_EndTime, DateTime Shift_StartDate, DateTime Shift_EndDate, int Shift_InputPeople = 0, string Shift_UserOrNot = null, string Shift_Modifier = null, DateTime Shift_ModifierDate = default(DateTime), string Shift_Others = null)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            dac.InsertShiftInfo(Shift_ID,  Fac_Code,Shift_StartTime,  Shift_EndTime,  Shift_StartDate,  Shift_EndDate, Shift_InputPeople = 0, Shift_UserOrNot = null, Shift_Modifier = null, Shift_ModifierDate = default(DateTime),Shift_Others = null);
        }
    }
}
