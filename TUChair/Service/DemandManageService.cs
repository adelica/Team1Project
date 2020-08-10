using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairDAC;

namespace TUChair.Service
{
    class DemandManageService
    {
        internal DataTable GetDemandManage(string startDate, string endDate)
        {
            DemandManageDAC dac = new DemandManageDAC();
            return dac.GetDemandManage(startDate, endDate);
        }
    }
}
