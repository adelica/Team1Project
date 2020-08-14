
using System;
using System.Collections.Generic;
using System.Data;
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
        public bool InsertShiftInfo(string Shift_ID, string Fac_Code, string Shift_StartTime, string Shift_EndTime, DateTime Shift_StartDate, DateTime Shift_EndDate, int Shift_InputPeople = 0, string Shift_UserOrNot = null, string Shift_Modifier = null, DateTime Shift_ModifierDate = default(DateTime), string Shift_Others = null)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
           return dac.InsertShiftInfo(Shift_ID, Fac_Code, Shift_StartTime, Shift_EndTime, Shift_StartDate, Shift_EndDate, Shift_InputPeople, Shift_UserOrNot, Shift_Modifier, Shift_ModifierDate, Shift_Others);
        }
        public bool Update(string Shift_ID, string Fac_Code, string Shift_StartTime, string Shift_EndTime, DateTime Shift_StartDate, DateTime Shift_EndDate, int Shift_InputPeople = 0, string Shift_UserOrNot = null, string Shift_Modifier = null,
            DateTime? Shift_ModifierDate = null, string Shift_Others = null)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
           return dac.Update(Shift_ID, Fac_Code, Shift_StartTime, Shift_EndTime, Shift_StartDate, Shift_EndDate, Shift_InputPeople, Shift_UserOrNot, Shift_Modifier, Shift_ModifierDate, Shift_Others);
        }
        public List<WorkOrderVO> selectworkOrder()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
           return dac.selectworkOrder();
        }
        public List<WorkOrderVO> SelectBarcode(string checklist)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.SelectBarcode(checklist);
        }
        public void insertworkOrder(int Out_Qty_Main, int Prd_Qty, int WorkOrderID)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            dac.insertworkOrder(Out_Qty_Main, Prd_Qty, WorkOrderID);
        }
        public bool DeleteShift(string condition)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.DeleteShift(condition);
        }
        public DataTable SearchPivot(DateTime firstdate, DateTime enddate)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.SearchPivot(firstdate,enddate);
        }
        public DataTable SearchPivotFaci(DateTime firstdate, DateTime enddate, string facicode)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.SearchPivotFaci(firstdate, enddate, facicode);
        }
    }
}
