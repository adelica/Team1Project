using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairDAC;
using TUChairVO;

namespace TUChair.Service
{
  public  class commonService
    {
        public List<ComboItemVO> getCommonCode(string condition)
        {
            commonDAC dAC = new commonDAC();
          return dAC.getCommonCode(condition);
        }
    }
}
