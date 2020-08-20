using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;

namespace TUChairDAC
{
    public class AuthorDAC : ConnectionAccess
    {
        public List<AuthorGroupVO> GetAllAuthorGroup()
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"select [AuthorGroup_ID], [AuthorGroup_Name], [AuthorGroup_Explanation], [AuthorGroup_Order], [AuthorGroup_UseOrNot] from [dbo].[AuthorGroup]";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<AuthorGroupVO> list = Helper.MeilingDataReaderMapToList<AuthorGroupVO>(reader);
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
