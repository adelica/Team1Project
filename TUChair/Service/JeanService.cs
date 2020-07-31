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
        public List<UnitPriceVO> UPBinding()
        {
            UnitPriceDAC dac = new UnitPriceDAC();
            return dac.UPBinding();
        }
        public List<UnitPriceVO> ProductUPBinding()
        {
            UnitPriceDAC dac = new UnitPriceDAC();
            return dac.ProductUPBinding();
        }
        

    }
}
