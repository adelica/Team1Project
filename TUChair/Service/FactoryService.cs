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
    class FactoryService
    {
       
        public List<FactoryVO> GetFactoryData()
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.GetFactoryData();
        }

        public bool FactoryInfoRegi(string fGroup, string fParent, string fClass, string fCode, string fName, string fModifier, DateTime fModifyDate, string fUseOrNot, string fInfo, string fType) //공장정보등록
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.FactoryInfoRegi(fGroup, fParent, fClass, fCode, fName, fModifier, fModifyDate, fUseOrNot, fInfo, fType);
        }

        internal bool DeleteFactoryInfo(string fact_Code)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.DeleteFactoryInfo(fact_Code);
        }
    }
}
