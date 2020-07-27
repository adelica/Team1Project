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
        public void InsertShiftInfo(string Shift_ID, string Fac_Code, string Shift_StartTime, string Shift_EndTime, DateTime Shift_StartDate, DateTime Shift_EndDate, int Shift_InputPeople = 0, string Shift_UserOrNot = null, string Shift_Modifier = null, 
            DateTime? Shift_ModifierDate=null, string Shift_Others=null)
        {
            try
            {
                Shift_ModifierDate = DateTime.Now;

                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"insert into [dbo].[Shift]([Shift_ID], [Fac_Code], [Shift_StartTime], [Shift_EndTime], [Shift_StartDate], [Shift_EndDate], [Shift_InputPeople], [Shift_UserOrNot], [Shift_Modifier], [Shift_ModifierDate], [Shift_Others])
                 values (@Shift_ID,@Fac_Code,@Shift_StartTime,@Shift_EndTime,
                         @Shift_StartDate,@Shift_EndDate,@Shift_InputPeople,@Shift_UserOrNot,@Shift_Modifier,
                         @Shift_ModifierDate,@Shift_Others) ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {                    
                    cmd.Parameters.AddWithValue("@Shift_ID", Shift_ID);
                    cmd.Parameters.AddWithValue("@Fac_Code", Fac_Code);
                    cmd.Parameters.AddWithValue("@Shift_StartTime", Shift_StartTime);
                    cmd.Parameters.AddWithValue("@Shift_EndTime", Shift_EndTime);
                    cmd.Parameters.AddWithValue("@Shift_StartDate", Shift_StartDate);
                    cmd.Parameters.AddWithValue("@Shift_EndDate", Shift_EndDate);
                    cmd.Parameters.AddWithValue("@Shift_InputPeople", Shift_InputPeople);
                    cmd.Parameters.AddWithValue("@Shift_UserOrNot", (Shift_UserOrNot == null) ? DBNull.Value : (object)Shift_UserOrNot);
                    cmd.Parameters.AddWithValue("@Shift_Modifier", (Shift_Modifier == null) ? DBNull.Value : (object)Shift_Modifier);
                    cmd.Parameters.AddWithValue("@Shift_ModifierDate", (Shift_ModifierDate == null) ? DBNull.Value : (object)Shift_ModifierDate);
                    cmd.Parameters.AddWithValue("@Shift_Others", (Shift_Others == null) ? DBNull.Value : (object)Shift_Others);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception err)
            {
                Debug.WriteLine(err.Message);

               
            }
        }
    }
}
