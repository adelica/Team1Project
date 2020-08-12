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
        public bool PSShiftInsert(int Primary, string fact) //선택공정이동
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSShiftInsert(Primary, fact);
        }
        public bool PSShiftReturn(int Primary,string date, string fact) //선택공정이동
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSShiftReturn(Primary, date, fact);
        }
        public bool PSShiftInsert(string a, string b) //바코드로 공정이동
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSShiftInsert(a,b);
        }
        public List<ProcessShiftVO> ShiftLoad() // 공정이동한 목록표시
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.ShiftLoad();
        }

        public List<ProcessShiftVO> Search(string Fact,string code,string txt)//검색조건
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.Search(Fact, code, txt);
        }





        public List<PSMManager> PSMManager() // 공정이동 현황 바인딩
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSMManager();
        }
        public List<PSMManager> PSMMSearch(string date, string item, string Fact, string txt)// 공정이동 현황검색조건
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.PSMMSearch(date, item, Fact, txt);
        }


        public List<StockShift> StockBinding(string pry)// 공정이동 현황검색조건
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.StockBinding(pry);
        }
        public List<StockShift> ThisIsShift(int Primary, string Item,string Fact, string From_Fact, string Modifier,int Qty)// 공정이동 현황검색조건
        {
            ProcessShiftDAC dac = new ProcessShiftDAC();
            return dac.ThisIsShift(Primary, Item, Fact, From_Fact, Modifier, Qty);
        }
    }
}
