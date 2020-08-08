using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;
using TUChairDAC;

namespace TUChair.Service
{
    class CompanyService
    {
        internal List<CompanyVO> GetCompanyInfo()
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.GetCompanyInfo();
        }

        internal bool CompanyInfoRegi(CompanyVO company)
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.CompanyInfoRegi(company);
        }

        internal bool DeleteCompanyInfo(string code)
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.DeleteCompanyInfo(code);
        }
    }
}
