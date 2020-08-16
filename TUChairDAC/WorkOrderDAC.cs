using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select s.Shift_ID,s.[Faci_Code],f.[Faci_Name],[Shift_StartDate],[Shift_EndDate],[Shift_StartTime],[Shift_EndTime],
[Shift_InputPeople],[Shift_UserOrNot],[Shift_Modifier],[Shift_ModifierDate],[Shift_Others]
from [dbo].[Shift] s left outer join [dbo].[Facility] f 
on s.Faci_Code = f.Faci_Code";
                    cmd.Connection.Open();
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
        public bool InsertShiftInfo(string Shift_ID, string Fac_Code, string Shift_StartTime, string Shift_EndTime, DateTime Shift_StartDate, DateTime Shift_EndDate, int Shift_InputPeople = 0, string Shift_UserOrNot = null, string Shift_Modifier = null,
            DateTime? Shift_ModifierDate = null, string Shift_Others = null)
        {
            try
            {
                Shift_ModifierDate = DateTime.Now;

                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"insert into [dbo].[Shift]([Shift_ID], [Faci_Code], [Shift_StartTime], [Shift_EndTime], [Shift_StartDate], [Shift_EndDate], [Shift_InputPeople], [Shift_UserOrNot], [Shift_Modifier], [Shift_ModifierDate], [Shift_Others])
                 values (@Shift_ID,(select [Faci_Code] from [dbo].[Facility] where [Faci_Name]=@Faci_Code),@Shift_StartTime,@Shift_EndTime,        @Shift_StartDate,@Shift_EndDate,@Shift_InputPeople,@Shift_UserOrNot,@Shift_Modifier,
                         @Shift_ModifierDate,@Shift_Others) ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Shift_ID", Shift_ID);
                    cmd.Parameters.AddWithValue("@Faci_Code", Fac_Code);
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
                  var reac =  cmd.ExecuteNonQuery();
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
        public bool Update(string Shift_ID, string Fac_Code, string Shift_StartTime, string Shift_EndTime, DateTime Shift_StartDate, DateTime Shift_EndDate, int Shift_InputPeople = 0, string Shift_UserOrNot = null, string Shift_Modifier = null,
            DateTime? Shift_ModifierDate = null, string Shift_Others = null)
        {
            try
            {
                Shift_ModifierDate = DateTime.Now;
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"update [dbo].[Shift] set 
[Faci_Code]=(select[Faci_Code] from [dbo].[Facility] where [Faci_Name] =@Faci_Code), [Shift_StartTime]=@Shift_StartTime, [Shift_EndTime]=@Shift_EndTime, 
[Shift_StartDate]=@Shift_StartDate, [Shift_EndDate]=@Shift_EndDate, 
[Shift_InputPeople]=@Shift_InputPeople, [Shift_UserOrNot]=@Shift_UserOrNot, 
[Shift_Modifier]=@Shift_Modifier, [Shift_ModifierDate]=@Shift_ModifierDate,
[Shift_Others]=@Shift_Others where [Shift_ID]=@Shift_ID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Shift_ID", Shift_ID);
                    cmd.Parameters.AddWithValue("@Faci_Code", Fac_Code);
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
                   var reac =  cmd.ExecuteNonQuery();
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

        public List<WorkOrderVO> selectworkOrder()
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select [WorkOrderID], [So_WorkOrderID], [Item_Code], [Plan_Qty], [Plan_Date], [Prd_Date], [Wo_State], [Wo_Order], [Plan_StartTime], [Plan_EndTime], [In_Qty_Main], [Out_Qty_Main], [Prd_Qty], [Wo_Req_No], [Remark], [Up_Date], [Up_Emp] from [dbo].[WorkOrder]";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<WorkOrderVO> list = Helper.MeilingDataReaderMapToList<WorkOrderVO>(reader);
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
        public List<WorkOrderVO> SelectBarcode(string checklist )
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select [WorkOrderID], [Item_Code],[Out_Qty_Main],[Prd_Qty]from [dbo].[WorkOrder]
                              where WorkOrderID in("+ checklist + ")";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                  
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<WorkOrderVO> list = Helper.MeilingDataReaderMapToList<WorkOrderVO>(reader);

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
        public void insertworkOrder(int Out_Qty_Main, int Prd_Qty, int WorkOrderID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"update [dbo].[WorkOrder] set [Out_Qty_Main]=@Out_Qty_Main ,[Prd_Qty]=@Prd_Qty
where [WorkOrderID]=@WorkOrderID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Out_Qty_Main", Out_Qty_Main);
                    cmd.Parameters.AddWithValue("@Prd_Qty", Prd_Qty);
                    cmd.Parameters.AddWithValue("@WorkOrderID", WorkOrderID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
            catch (Exception err)
            {

                Debug.WriteLine(err.Message);

                //return null;
            }





        }
        public bool DeleteShift(string condition)
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"DeleteShift";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Condition", condition);
                    cmd.Parameters.AddWithValue("@P_Seperator", "@");
                    cmd.Connection.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message, err);
                throw err;
            }
        }
        public DataTable SearchPivot(DateTime firstdate, DateTime enddate)
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"P_ShiftDate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Start_Data", firstdate);
                    cmd.Parameters.AddWithValue("@P_End_Data", enddate);
                    cmd.Connection.Open();
                    using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                   
                   
                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message, err);
                throw err;
            }
        }
        public DataTable SearchPivotFaci(DateTime firstdate, DateTime enddate,string facicode)
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"P_ShiftDateCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Start_Data", firstdate);
                    cmd.Parameters.AddWithValue("@P_End_Data", enddate);
                    cmd.Parameters.AddWithValue("@P_faci_code", facicode);
                    cmd.Connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }


                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message, err);
                throw err;
            }
        }
        public DataTable ProductPlanPivot(DateTime firstdate, DateTime enddate)
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"ProductPlanPivot";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Start_Data", firstdate);
                    cmd.Parameters.AddWithValue("@P_End_Data", enddate);
                    cmd.Connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message, err);
                throw err;
            }
        }
        public DataTable ProductPlansearchPivot(DateTime firstdate, DateTime enddate,string searchmsg)
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"ProductPlansearchPivot";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Start_Data", firstdate);
                    cmd.Parameters.AddWithValue("@P_End_Data", enddate);
                    cmd.Parameters.AddWithValue("@search_col", searchmsg);
                    cmd.Connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message, err);
                throw err;
            }
        }
        public DataTable OutPlanPivot(DateTime firstdate, DateTime enddate)
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"OutPlanPivot";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Start_Data", firstdate);
                    cmd.Parameters.AddWithValue("@P_End_Data", enddate);
                    cmd.Connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message, err);
                throw err;
            }
        }
        public DataTable OutPlansearchPivot(DateTime firstdate, DateTime enddate, string searchmsg)
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"OutPlanSearchPivot";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Start_Data", firstdate);
                    cmd.Parameters.AddWithValue("@P_End_Data", enddate);
                    cmd.Parameters.AddWithValue("@search_col", searchmsg);
                    cmd.Connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message, err);
                throw err;
            }
        }
        public List<WoOrderVO> WorkOderselect()
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select [WorkOrderID], [Pro_ID], wo.[Item_Code],item.Item_Name, [Plan_Qty], [Plan_Date], 
[Wo_State], [Plan_StartTime], [Plan_EndTime],  wo.[Sales_ID],Deduction
from [dbo].[WorkOrder] wo
join [dbo].[Item] item
on item.Item_Code = wo.Item_Code";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<WoOrderVO> list = Helper.MeilingDataReaderMapToList<WoOrderVO>(reader);
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
        public List<WoOrderVO> WorkOderSearch(DateTime firstdate, DateTime enddate, string searchmsg)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
               
                    cmd.CommandText = @"SP_SearchWorkOrder";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@First_date", firstdate);
                    cmd.Parameters.AddWithValue("@end_date", enddate);
                    cmd.Parameters.AddWithValue("@Search_cal", searchmsg);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<WoOrderVO> list = Helper.MeilingDataReaderMapToList<WoOrderVO>(reader);
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
        public bool DeleteWorkOrder(string condition)
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"DeleteworkOrder";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Condition", condition);
                    cmd.Parameters.AddWithValue("@P_Seperator", "@");
                    cmd.Connection.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message, err);
                throw err;
            }
        }
        public bool UpdateWorkOrder(string condition)
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"UpdteworkOrder";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Condition", condition);
                    cmd.Parameters.AddWithValue("@P_Seperator", "@");
                    cmd.Connection.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message, err);
                throw err;
            }
        }
        public List<WoOrderVO> WorkOrderStatus()
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select [WorkOrderID], [Pro_ID], wo.[Item_Code],item.Item_Name,item.Item_InWarehouse,item.Item_OutWarehouse,
[Plan_Qty], [Plan_Date], 
[Wo_State], [Plan_StartTime], [Plan_EndTime],  wo.[Sales_ID],Deduction
from [dbo].[WorkOrder] wo
join [dbo].[Item] item
on item.Item_Code = wo.Item_Code where Wo_State='지시'";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<WoOrderVO> list = Helper.MeilingDataReaderMapToList<WoOrderVO>(reader);
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
        public List<WoOrderVO> SearchWorkOrderstatus(DateTime firstdate, DateTime enddate, string searchmsg)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @"SP_SearchWorkOrderstatus";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@First_date", firstdate);
                    cmd.Parameters.AddWithValue("@end_date", enddate);
                    cmd.Parameters.AddWithValue("@Search_cal", searchmsg);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<WoOrderVO> list = Helper.MeilingDataReaderMapToList<WoOrderVO>(reader);
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
        public List<WoOrderVO> WorkOrderStatus(int WOrderId)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select bom.[Item_Code],item.Item_Name,item.Item_Size, [BOM_Require]*wo.Plan_Qty '소요량',
st.Qty '재고량',st.Fact_Code ,'' '요청일','' '출고수량','' '잔량'  from [dbo].[BOM]  bom
join [dbo].[WorkOrder] wo 
on bom.Item_Code = wo.Item_Code
join [dbo].[Item] item
on wo.Item_Code = item.Item_Code
join [dbo].[Stock] st on item.Item_Code = st.Item_Code
where [WorkOrderID]=@WOrderId and item.Item_Type='반제품'";
                    cmd.Parameters.AddWithValue("@WOrderId", WOrderId);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<WoOrderVO> list = Helper.MeilingDataReaderMapToList<WoOrderVO>(reader);
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
