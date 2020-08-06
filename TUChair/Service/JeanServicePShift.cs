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
        public List<EXProcessShiftVO> Bacode()
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.Bacode();
        }
        public bool PSShiftInsert(ProcessShiftVO sht)
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSShiftInsert(sht);
        }
        public bool PSShiftInsert(string a, string b, string c)
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSShiftInsert(a,b,c);
        }
    }
}
