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
        public bool Delete(int Primary)
        {
            UnitPriceDAC dac = new UnitPriceDAC();
            return dac.Delete(Primary);
        }


        #region 검색조건
        public List<ViewUnitPriceVO> Search(string date,string txt,string cbo)
        {
            UnitPriceDAC dac = new UnitPriceDAC();
            return dac.Search(date, txt, cbo);
        }
        public List<ViewUnitPriceVO> Search1(string date, string txt, string cbo)
        {
            UnitPriceDAC dac = new UnitPriceDAC();
            return dac.Search1(date, txt, cbo);
        }
        public List<MonthDeadLineVO> MonthSearch(string date, string type, string com)
        {
            UnitPriceDAC dac = new UnitPriceDAC();
            return dac.MonthSearch(date, type,com );
        }

        #endregion
    }
}
