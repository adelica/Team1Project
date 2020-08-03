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
    public class FacilityService
    {
        //모든 데이터 바인딩
        public DataSet GetFacilityData()
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.GetFacilityData();
        }
        //설비군 등록,수정
        public bool FacilityGInfoRegi(string facG_Code, string facG_Name, string facG_UserOrNot, string facG_Modifier, DateTime facG_ModifyDate, string facG_Info)
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.FacilityGInfoRegi(facG_Code, facG_Name, facG_UserOrNot, facG_Modifier, facG_ModifyDate, facG_Info);
        }
        //설비 등록, 수정
        public bool FacilityInfoRegi(string facG_Code, string faci_Code, string faci_Name, string faci_Modifier, string faci_Detail, string faci_Others, string faci_In, string faci_Out, string faci_Bad, DateTime faci_ModifyDate,string faci_UseOrNot)
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.FacilityInfoRegi(facG_Code, faci_Code, faci_Name, faci_Modifier, faci_Detail, faci_Others, faci_In, faci_Out, faci_Bad, faci_ModifyDate, faci_UseOrNot);
        }
        //설비군 삭제
        public bool DeleteFacilityGInfo(string facG_Code)
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.DeleteFacilityGInfo(facG_Code);
        }
        // 설비삭제
        public bool DeleteFacilityInfo(string faci_Code) 
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.DeleteFacilityInfo(faci_Code);
        }
    }
}
