using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;
using TUChairDAC;


namespace TUChair.Service
{
    public class JeanProductOut
    {
        public List<ProductOutVO> POutBinding()
        {
            ProductOutDAC dac = new ProductOutDAC();
            return dac.POutBinding();
        }
        public List<CProductOutVO> CProductBinding()
        {
            ProductOutDAC dac = new ProductOutDAC();
            return dac.CProductBinding();
        }
    }
}
