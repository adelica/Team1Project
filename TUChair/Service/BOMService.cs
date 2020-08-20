using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairDAC;
using TUChairVO;

namespace TUChair.Service
{
   public class BOMService
    {
        public List<BOMVO> getALLBom()
        {
            BOMDAC dac = new BOMDAC();
            return dac.getALLBom();
        }

        internal bool SaveBOM(BOMVO bomInfo)
        {
            BOMDAC dac = new BOMDAC();
            return dac.SaveBOM(bomInfo);
        }

        internal bool DeleteBOM(string condition)
        {
            BOMDAC dac = new BOMDAC();
            return dac.DeleteBOM(condition);
        }

        internal List<BOMVO> SearchBOM(DateTime value, string text, string selectedValue)
        {
            BOMDAC dac = new BOMDAC();
            return dac.SearchBOM(value, text, selectedValue);
        }
    }
}
