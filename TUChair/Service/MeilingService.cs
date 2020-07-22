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
        }
}
