using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairDAC;

namespace TUChair.Service
{
    public class MaterialRequirementService
    {
        internal DataTable MaterialSoyo(DateTime start, DateTime end, string planID)
        {
            MaterialRequirementDAC dac = new MaterialRequirementDAC();
            return dac.MaterialSoyo(start, end, planID);
        }
    }
}
