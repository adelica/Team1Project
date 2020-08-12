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
    public class ProcessShiftDAC : ConnectionAccess
    {
        public List<ProcessShiftVO> PSBinding() // 자재단가 관리 (전체)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select [No], s.[Item_Code] [Item_Code], [Item_Name],  s.[Fact_Code] [Fact_Code], [Fact_Name],[Fact_Type], [Insert_Date], [Qty],[Item_Size],[Item_Unit] ,[Stock_Other]
                                from [dbo].[Stock] s left join [dbo].[Item] i on s.[Item_Code] = i.[Item_Code] left join [dbo].[Factory] f on s.[Fact_Code] = f.[Fact_Code]
                                where [Insert_Date] is null and [Stock_Other] is null";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProcessShiftVO> list = Helper.DataReaderMapToList<ProcessShiftVO>(reader);
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
        public List<EXProcessShiftVO> Bacode()
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select concat(upper(s.[Fact_Code]), '_',No) [No], s.[Item_Code] [Item_Code], [Item_Name],  s.[Fact_Code] [Fact_Code], [Fact_Name],[Fact_Type], [Insert_Date], [Qty],[Item_Size],[Item_Unit] ,[Stock_Other]
                                from [dbo].[Stock] s left join [dbo].[Item] i on s.[Item_Code] = i.[Item_Code] left join [dbo].[Factory] f on s.[Fact_Code] = f.[Fact_Code]
                                where [Insert_Date] is null and [Stock_Other] is null";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<EXProcessShiftVO> list = Helper.DataReaderMapToList<EXProcessShiftVO>(reader);
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
        public List<ProcessShiftVO> ShiftLoad() // 공정이동한 목록 바인딩
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select [No], s.[Item_Code] [Item_Code], [Item_Name],  s.[Fact_Code] [Fact_Code], [Fact_Name],[Fact_Type], convert(nvarchar, [Insert_Date],23)[Insert_Date], [Qty],[Item_Size],[Item_Unit] ,[Stock_Other]
                                from [dbo].[Stock] s left join [dbo].[Item] i on s.[Item_Code] = i.[Item_Code] left join [dbo].[Factory] f on s.[Fact_Code] = f.[Fact_Code]
                                where [Insert_Date] = CONVERT(date,getdate()) and [Stock_Other] = '이동완료'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProcessShiftVO> list = Helper.DataReaderMapToList<ProcessShiftVO>(reader);
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

        public bool PSShiftInsert(int Primary, string fact) // 공정이동 프로시저
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_ProcessShift";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@NO", Primary);
                    //cmd.Parameters.AddWithValue("@ThisDate", DBNull.Value.ToString());
                    cmd.Parameters.AddWithValue("@Fact_Code", fact);



                    cmd.Connection.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception e)
            {
                //_log.WriteError(e.Message, e);
                throw e;
            }
        }
        public bool PSShiftInsert(string a, string b) //바코드로 공정이동
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_ProcessShift";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@NO", b);
                    cmd.Parameters.AddWithValue("@ThisDate", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Fact_Code", a);



                    cmd.Connection.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception e)
            {
                // _log.WriteError(e.Message, e);
                throw e;
            }
        }

        public bool PSShiftReturn(int Primary, string date, string fact) //공정이동 취소
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_ReturnProcessShift";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@NO", Primary);
                    cmd.Parameters.AddWithValue("@ThisDate", date);
                    cmd.Parameters.AddWithValue("@Fact_Code", fact);



                    cmd.Connection.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception e)
            {
                _log.WriteError(e.Message, e);
                throw e;
            }
        }


        public List<ProcessShiftVO> Search(string Fact, string code, string txt) // 공정이동 진그리드1 검색조건
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_PSMSearch";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Fact_Name", (object)Fact ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Item_Code", (object)code ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Item_Name", (object)txt ?? DBNull.Value);

                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProcessShiftVO> list = Helper.MeilingDataReaderMapToList<ProcessShiftVO>(reader);
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

        public List<PSMManager> PSMManager() // 자재단가 관리 (전체)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select  s.[Fact_Code] [Fact_Code], [Fact_Name] , s.[Item_Code] [Item_Code],[Item_Name],[Item_Type],[Item_Size],[Qty],[Item_Unit],[Stock_Other] ,[Insert_Date]
                                 from [dbo].[Stock] s inner join [dbo].[Factory] f on s.Fact_Code = f.Fact_Code
					                                  inner join [dbo].[Item] i on s.Item_Code = i.Item_Code
                                where 1=1";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<PSMManager> list = Helper.DataReaderMapToList<PSMManager>(reader);
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
        public List<PSMManager> PSMMSearch(string date, string item, string Fact, string txt) // 공정이동 진그리드1 검색조건
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_PSMSearch";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ThisDate", (object)date ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Item_Code", (object)item ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Fact_Code", (object)Fact ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Item_name", (object)txt ?? DBNull.Value);

                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<PSMManager> list = Helper.MeilingDataReaderMapToList<PSMManager>(reader);
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
        public List<StockShift> StockBinding(string pry) // 진그리드 2 바인딩
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"select s.no  no, s.Item_Code Item_Code, Item_Name, Item_Size,Item_Type,s.Fact_Code, Qty, 
	                                            null From_Fact ,CONVERT(varchar(10),getdate(), 23) Shift_date , 0 as 'N_HOUR'
	                                            from Stock s left join Item i on s.Item_Code = i.Item_Code
                                        where s.no in(" + pry + ")";                    

                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<StockShift> list = Helper.MeilingDataReaderMapToList<StockShift>(reader);
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
        public List<StockShift> ThisIsShift(int Primary, string Item, string Fact, string From_Fact, string Modifier, int Qty) // 공정이동 진그리드1 검색조건
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_StockStatusInsert";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@No", Primary);
                    cmd.Parameters.AddWithValue("@Item", Item);
                    cmd.Parameters.AddWithValue("@Fact", Fact) ;
                    cmd.Parameters.AddWithValue("@From_Fact", From_Fact);
                    cmd.Parameters.AddWithValue("@Modifier", Modifier);
                    cmd.Parameters.AddWithValue("@Shift_Qty", Qty);

                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<StockShift> list = Helper.MeilingDataReaderMapToList<StockShift>(reader);
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
        public List<InOutVo> InOutBinding() // 입출고현황 바인딩
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"select convert(nvarchar, [Shift_date],23) Shift_date, Gubun , Category , From_Fact, Fact_Code,
                                                ss.Item_Code Item_Code, item_Name, Item_Size, Item_Type, Shift_Qty,
	                                            case when Category = '자재출고' then '0'
                                                     when Category = '자재입고' then '0'
                                                     else isnull(u.Price_Present, 0) end Price_Present,
 	                                            (Shift_Qty * case when Category = '자재출고' then 0
                                                     when Category = '자재입고' then 0
                                                     else isnull(u.Price_Present, 0) end ) Price,
	                                            	 ss.modifier modifier
                                        from StockStatus ss left join Item i on ss.Item_Code = i.Item_Code
                                                            left join UnitPrice u on ss.Item_Code = u.Item_Code
                                        where 1=1 ";

              
                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<InOutVo> list = Helper.MeilingDataReaderMapToList<InOutVo>(reader);
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
