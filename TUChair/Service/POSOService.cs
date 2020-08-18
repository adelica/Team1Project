using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;
using TUChairDAC;
using System.Data;

namespace TUChair.Service
{
    public class POSOService
    {
        //코드가져오기
        internal DataSet ItemCode()
        {
            POSODAC dac = new POSODAC();
            return dac.ItemCode();
        }
        //수요계획 등록, 수정
        internal bool SOInfoRegi(SOVO item)
        {
            POSODAC dac = new POSODAC();
            return dac.SOInfoRegi(item);
        }
        //영업마스터 데이터 가져오기
        internal List<POVO> GetPOData()
        {
            POSODAC dac = new POSODAC();
            return dac.GetPOData();
        }
        //이미 존재하는 계획인지 구분하기 위해 SalesID들을 가져옴
        internal List<string> CheckSalesID()
        {
            POSODAC dac = new POSODAC();
            return dac.CheckSalesID();
        }
        //엑셀등록한 영업마스터 DB에 등록
        internal bool SetPOData(List<UpLoadVO> upList)
        {
            POSODAC dac = new POSODAC();
            return dac.SetPOData(upList);
        }
    }
}
