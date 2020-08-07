using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TUChairVO;

namespace TUChairDAC
{
    public class CompanyDAC:ConnectionAccess
    {
        public List<CompanyVO> GetCompanyInfo()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"select Com_Code, Com_Name, Com_Type, Com_Owner, Com_Sector, Com_Manager, Com_Email, Com_Phone, Com_UseOrNot, Com_Modifier, Com_ModiflyDate,
                                                    Com_Information, isnull(Com_CorporRegiNum,'') as Com_CorporRegiNum
                                                    from Company";

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();                  
                    List<CompanyVO> list = Helper.DataReaderMapToList<CompanyVO>(reader);
                    cmd.Connection.Close();

                    return list;
                }
            }
            catch(Exception err)
            {
                _log.WriteError(err.Message);
                return null;
            }
        }
    }
}
