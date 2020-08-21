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
   public  class POPDAC : ConnectionAccess
    {
        public int  selectPlanQTY(int WorkOrderID)
        {
            int QTY=0;
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select [Plan_Qty] from [dbo].[WorkOrder] where [WorkOrderID]=240";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        QTY =Convert.ToInt32(reader[0]);
                    }
                    cmd.Connection.Close();
                    return QTY;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return 0;
            }
        }
    }
}
