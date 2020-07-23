using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using TUChairVO;

namespace TUChaiAPI.DAC
{
    public class UserDAC : IDisposable
    {
        string strConn = string.Empty;
        string strConn1 = string.Empty;
        public UserDAC()
        {

            strConn1 = WebConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            Amhuhua.Amhuhua amhuhua = new Amhuhua.Amhuhua();
            strConn =  amhuhua.Decrypt(strConn1);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string SaveUser(UserVO user)
        {
            string sql = "SaveUser";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Id ", user.Id);
                    cmd.Parameters.AddWithValue("@P_Name", user.Name);
                    cmd.Parameters.AddWithValue("@P_Email", user.Email);
                    cmd.Parameters.AddWithValue("@P_Mobile", user.Mobile);
                    cmd.Parameters.AddWithValue("@P_Address", user.Address);
                    cmd.Parameters.AddWithValue("@P_IsActive", user.IsActive);//"@P_ReturnCode"
                    cmd.Parameters.Add(new SqlParameter("@P_ReturnCode", System.Data.SqlDbType.NVarChar, 5));
                    cmd.Parameters["@P_ReturnCode"].Direction = System.Data.ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    //conn.Close();
                    return cmd.Parameters["@P_ReturnCode"].Value.ToString();
                }
            }

        }
        public List<UserVO> GetAllUsers()
        {
            List<UserVO> list = new List<UserVO>();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandText = @"select [Id], [Name], [Email], [Mobile], [Address], [IsActive] from Users";
                cmd.Connection.Open();
                list = Helper.DataReaderMapToList<UserVO>(cmd.ExecuteReader());
                cmd.Connection.Close();
                return list;
            }
        }


    }
}
