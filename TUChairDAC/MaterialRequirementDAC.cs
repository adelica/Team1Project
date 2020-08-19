using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUChairDAC
{
    public class MaterialRequirementDAC:ConnectionAccess
    {
        public DataTable MaterialSoyo(DateTime start, DateTime end, string planID)
        {
            try
            {
                DataTable dt = new DataTable();
                //using (SqlCommand cmd = new SqlCommand())
                //{
                //    cmd.CommandText = "";
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Connection = new SqlConnection(this.ConnectionString);
                //    cmd.Parameters.AddWithValue("@S_DATE	", start);
                //    cmd.Parameters.AddWithValue("@E_DATE	", end);
                //    cmd.Parameters.AddWithValue("@P_PLAN_ID	", planID);

                //    cmd.Connection.Open();
                //    //SqlDataReader reader = cmd.ExecuteReader();
                //    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //    dt.Load(dr);
                //    cmd.Connection.Close();
                //    return dt;
                //}
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))  //----------------프로시져 피봇 해야됨
                {
                    string sql = "SP_ProductSoYoPlan2";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@S_DATE",start);
                    da.SelectCommand.Parameters.AddWithValue("@E_DATE", end);
                    da.SelectCommand.Parameters.AddWithValue("@P_PLAN_ID", planID);
                    da.Fill(dt);

                    conn.Close();
                    return dt;
                }
                
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
                return null;
            }
        }

        //public List<string> GetComboBinding()
        //{
        //   using (SqlCommand cmd = new SqlCommand())
        //    {
        //        cmd.CommandText = "select Sales_ID from SalesMaster";
        //        cmd.Connection = new SqlConnection(this.ConnectionString);
        //        cmd.Connection.Open();
                
        //    }
        //}
    }
}
