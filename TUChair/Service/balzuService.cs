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
   public class balzuService
    {
        public DataTable GetBalzuMi()
        {
            balzuDAC dac = new balzuDAC();
          return  dac.GetBalzu();
        }

        internal DataTable GetBalzuReport(string strChkBarCodes)
        {
            balzuDAC dac = new balzuDAC();
            return dac.GetBalzuReport(strChkBarCodes);
        }

        internal DataTable GetBalzuMiip()
        {
            balzuDAC dac = new balzuDAC();
            return dac.GetBalzuMiip();
        }

       
        internal DataTable GetBalzuItem(string text, DateTime start, DateTime end)
        {
            balzuDAC dac = new balzuDAC();
            return dac.GetBalzuItem( text, start, end);
        }

        internal List<PbalzuVO> GetBalzuItemList(string planID)
        {
            balzuDAC dac = new balzuDAC();
            return dac.GetBalzuItemList(planID);
        }
    }
}
