using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairDAC;
using TUChairVO;

namespace TUChair.Service
{
    public class JeanService
    {
        public List<ViewUnitPriceVO> UPBinding()
        {
            UnitPriceDAC dac = new UnitPriceDAC();
            return dac.UPBinding();
        }
        public List<ViewUnitPriceVO> ProductUPBinding()
        {
            UnitPriceDAC dac = new UnitPriceDAC();
            return dac.ProductUPBinding();
        }
        public bool InsertOrUpdate(UnitPriceVO upv)
        {
            UnitPriceDAC dac = new UnitPriceDAC();
            return dac.InsertOrUpdate(upv);
        }

        #region 검색조건
        public List<ViewUnitPriceVO> SearchText(string txt)
        {
            UnitPriceDAC dac = new UnitPriceDAC();
            return dac.SearchText(txt);
        }

        #endregion
    }
}
