using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;

namespace TUChairDAC
{
    public class EmpDAC : ConnectionAccess
    {
        public List<EmpVO> EmpBinding() // 자재단가 관리 (전체)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select CUser_ID, u.AuthorGroup_ID AuthorGroup_ID, CUser_Name, 
                                case when CUser_ID is not null then '********' end CUser_PWD, CUser_UseOrNot , AuthorGroup_Explanation
                                from CUser u left join AuthorGroup ag on u.AuthorGroup_ID = ag.AuthorGroup_ID ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<EmpVO> list = Helper.DataReaderMapToList<EmpVO>(reader);
                    cmd.Connection.Close();
                    return list;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);

                return null;
            }
        }
        public List<EmpVO> EmpSearch(string id, string name) // 자재단가 관리 (전체)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_EmpSearch";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", (object)id ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Name", (object)name ?? DBNull.Value);

                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<EmpVO> list = Helper.MeilingDataReaderMapToList<EmpVO>(reader);
                    cmd.Connection.Close();
                    return list;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);

                return null;
            }

        }
        public bool Update(string id, string name, string pwd, string AuthorID, string UseOrNot)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"update cuser set  AuthorGroup_ID = @AuthorID, CUser_Name = @name, CUser_PWD = @pwd ,CUser_UseOrNot = @UseOrNot where CUser_ID = @id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@AuthorID", AuthorID);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@pwd", pwd);
                    cmd.Parameters.AddWithValue("@UseOrNot", UseOrNot);
                    
                    conn.Open();
                    var reac = cmd.ExecuteNonQuery();
                    conn.Close();
                    return reac > 0;
                }


            }
            catch (Exception err)
            {
                _log.WriteError(err.Message, err);
                throw err;
            }
        }
        public bool Insert(string id, string name, string pwd, string AuthorID, string UseOrNot)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"insert into CUser(CUser_ID ,AuthorGroup_ID, CUser_Name,CUser_PWD, CUser_UseOrNot)
			                        values (@id,@AuthorID,@name,@pwd,@UseOrNot)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@AuthorID", AuthorID);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@pwd", pwd);
                    cmd.Parameters.AddWithValue("@UseOrNot", UseOrNot);

                    conn.Open();
                    var reac = cmd.ExecuteNonQuery();
                    conn.Close();
                    return reac > 0;
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
