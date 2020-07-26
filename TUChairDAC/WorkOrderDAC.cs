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
    public class WorkOrderDAC : ConnectionAccess
    {
        public List<ShiftVO> DBConnectionTEST()
        {

            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select [Shift_ID], [Fac_Code], [Shift_StartTime], [Shift_EndTime], [Shift_StartDate], [Shift_EndDate], [Shift_InputPeople], [Shift_UserOrNot], [Shift_Modifier], [Shift_ModifierDate] from [dbo].[Shift]";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ShiftVO> list = Helper.MeilingDataReaderMapToList<ShiftVO>(reader);
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
    }
}
