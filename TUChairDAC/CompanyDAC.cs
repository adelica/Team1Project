using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TUChairVO;
using System.Data;

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

        public bool DeleteCompanyInfo(string code)
        {
           using(SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"DELETE FROM Company Where Com_Code IN (" + code + ")";

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();


                return true; 
            }
        }

        public bool CompanyInfoRegi(CompanyVO com)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SetCompanyInfo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Com_Code", com.Com_Code);
                    cmd.Parameters.AddWithValue("@Com_Name", com.Com_Name);
                    cmd.Parameters.AddWithValue("@Com_Type", com.Com_Type);
                    cmd.Parameters.AddWithValue("@Com_Owner", com.Com_Owner);
                    cmd.Parameters.AddWithValue("@Com_Sector", com.Com_Sector);
                    cmd.Parameters.AddWithValue("@Com_Manager", com.Com_Manager);
                    cmd.Parameters.AddWithValue("@Com_Email", com.Com_Email);
                    cmd.Parameters.AddWithValue("@Com_Phone", com.Com_Phone);
                    cmd.Parameters.AddWithValue("@Com_UseOrNot", com.Com_UseOrNot);
                    cmd.Parameters.AddWithValue("@Com_Modifier", com.Com_Modifier);
                    cmd.Parameters.AddWithValue("@Com_ModiflyDate", com.Com_ModiflyDate);
                    cmd.Parameters.AddWithValue("@Com_Information", com.Com_Information);
                    cmd.Parameters.AddWithValue("@Com_CorporRegiNum", com.Com_CorporRegiNum);

                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return true;
                }
            }
            catch(Exception err)
            {
                return false;
            }
        }
    }
}
