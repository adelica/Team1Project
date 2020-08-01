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

        public DataSet GetFacilityData()
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.GetFacilityData();
        }

        public bool FacilityGInfoRegi(string facG_Code, string facG_Name, string facG_UserOrNot, string facG_Modifier, DateTime facG_ModifyDate, string facG_Info)
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.FacilityGInfoRegi(facG_Code, facG_Name, facG_UserOrNot, facG_Modifier, facG_ModifyDate, facG_Info);
        }
    }
}
