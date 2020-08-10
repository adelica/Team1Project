using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TUChairDAC
{
    public class DemandManageDAC:ConnectionAccess
    {
        public DataTable GetDemandManage(string startDate, string endDate)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand())
                {
                   cmd.CommandText=@"SP_DemandPlanPivot";
                    cmd.Parameters.AddWithValue("@Start", startDate);
                    cmd.Parameters.AddWithValue("@End", endDate);
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandType = CommandType.StoredProcedure;
                 
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    return dt;
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
