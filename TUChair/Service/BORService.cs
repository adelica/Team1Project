using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;
using TUChairDAC;

namespace TUChair.Service
{
    public class BORService
    {
        internal List<BORVO> GetBORData()
        {
            BORDAC dac = new BORDAC();
            return dac.GetBORData();
        }

        internal bool DeleteBORInfo(int code)
        {
            BORDAC dac = new BORDAC();
            return dac.DeleteBORInfo(code);
        }

        internal bool BORInfoRegi(string itemCode, string facgCode, string faciCode, int tactT, int priority, decimal yeild,int processLead, string useOrNot, string other)
        {
            BORDAC dac = new BORDAC();
            return dac.BORInfoRegi(itemCode, facgCode, faciCode, tactT, priority, yeild,processLead, useOrNot, other);
        }
    }
}
