using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairDAC;
using TUChairVO;

namespace TUChair.Service
{
    public class JeanMagamService
    {
        public List<MonthDeadLineVO> AllMagamBind()
        {
            MagamDAC dac = new MagamDAC();
            return dac.AllMagamBind();
        }
        public List<MonthDLDetail> MagamDetail(string pry,string date)// 공정이동 현황검색조건
        {
            MagamDAC dac = new MagamDAC();
            return dac.MagamDetail(pry, date);
        }
    }
}
