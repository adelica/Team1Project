using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;
using TUChairDAC;
using System.Data;

namespace TUChair.Service
{
    public class POSOService
    {
        internal DataSet ItemCode()
        {
            POSODAC dac = new POSODAC();
            return dac.ItemCode();
        }

        internal bool SOInfoRegi(SOVO item)
        {
            POSODAC dac = new POSODAC();
            return dac.SOInfoRegi(item);
        }

        internal List<POVO> GetPOData()
        {
            POSODAC dac = new POSODAC();
            return dac.GetPOData();
        }
    }
}
