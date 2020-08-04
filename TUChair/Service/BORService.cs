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
        public List<BORVO> GetBORData()
        {
            BORDAC dac = new BORDAC();
            return dac.GetBORData();
        }
    }
}
