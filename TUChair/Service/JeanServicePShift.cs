using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairDAC;
using TUChairVO;

namespace TUChair.Service
{
    public class JeanServicePShift
    {
        public List<ProcessShiftVO> PSBinding()
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSBinding();
        }
        public bool PSShiftInsert(ProcessShiftVO sht)
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSShiftInsert(sht);
        }
    }
}
