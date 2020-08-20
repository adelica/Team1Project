using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;

namespace TUChairDAC
{
    public class commonDAC : ConnectionAccess
    {
        public List<ComboItemVO> getCommonCode(string codeTypes)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string seperator = "@";
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "GetCodeInfoByCodeTypes";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_CodeTypes", codeTypes);
                cmd.Parameters.AddWithValue("@P_Seperator", seperator);

                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ComboItemVO> list = Helper.DataReaderMapToList<ComboItemVO>(reader);
                cmd.Connection.Close();

                return list;
            }

        }

        public List<AuthorVO> Getauthor(int authorityGroupNum)
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"select AuthorGroup_ID, Program_ID, Program_Name, Program_order, Module_ID, Module_Name, Module_order, Method_Search, Method_Save, Method_New, Method_Delete, Method_Excel from vm_AuthorbyAuthGroup where AuthorGroup_ID = @authorGroup_ID order by Module_order,[Program_order]";
                    cmd.Parameters.AddWithValue("@authorGroup_ID", authorityGroupNum);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<AuthorVO> list = Helper.MeilingDataReaderMapToList<AuthorVO>(reader);
                    cmd.Connection.Close();
                    return list;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<ProgramVO> GetAllMenu()
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"select 
	                                          m.Module_Name
	                                        , m.Module_ID
	                                         ,[Program_ID]
	                                        , [Program_Name]
	                                        , [Program_Explanation]
	                                        , [Program_order]
                                          from [dbo].[Program] p inner join module m on p.Module_ID=m.Module_ID
	                                      order by m.Module_order";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProgramVO> list = Helper.MeilingDataReaderMapToList<ProgramVO>(reader);
                    cmd.Connection.Close();

                    return list;
                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message, err);
                throw err;

            }
        }
    }
}
