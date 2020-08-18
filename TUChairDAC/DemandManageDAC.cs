using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TUChairVO;

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

        public List<DemandManageVO> GetComboBinding()
        {
            try
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select Com_Name, isnull(Sales_ID,0) as Sales_ID from SalesMaster m right outer join Company C on m.Com_Code=c.Com_Code";
                    cmd.Connection = new SqlConnection(this.ConnectionString);

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<DemandManageVO> list = Helper.DataReaderMapToList<DemandManageVO>(reader);
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
