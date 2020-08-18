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
                string sql = @"select [No], s.[Item_Code] [Item_Code], [Item_Name],  s.[Fact_Code] [Fact_Code], [Fact_Name],[Fact_Type], [Insert_Date],
				                        [Qty],[Item_Size],[Item_Unit] ,[Stock_Other],Item_Type
                                from [dbo].[Stock] s left join [dbo].[Item] i on s.[Item_Code] = i.[Item_Code] 
													 left join [dbo].[Factory] f on s.[Fact_Code] = f.[Fact_Code]
                                where [Insert_Date] is null and [Stock_Other] is null and Item_Type <> '완제품'
";
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

                    cmd.Parameters.AddWithValue("@Fact_Code", (object)Fact ?? DBNull.Value);
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
        public List<InOutVo> InOutSearch(string Fact, string Gubun, string Category, string itype, string start, string end, string Icode) // 공정이동 진그리드1 검색조건
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_SearchInOut";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Fact_Code", (object)Fact ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Gubun", (object)Gubun ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Category", (object)Category ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", (object)itype ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Start", (object)start ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@End", (object)end ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Item_Code", (object)Icode ?? DBNull.Value);

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
        public List<ProductOutVO> PSMSearch(string Ccode, string start, string end, string comno, string item) // 제품출하 검색조건
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_ProductOutSearch";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Ccode", (object)Ccode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@start", (object)start ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@end", (object)end ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@comno", (object)comno ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@item", (object)item ?? DBNull.Value);

                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProductOutVO> list = Helper.MeilingDataReaderMapToList<ProductOutVO>(reader);
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
        public List<ProductSatus> PSMSSearch(string Ccode, string start, string end, string comno, string item) // 제품현황 검색조건
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_ProductStatusSearch";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Ccode", (object)Ccode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@start", (object)start ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@end", (object)end ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@comno", (object)comno ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@item", (object)item ?? DBNull.Value);

                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProductSatus> list = Helper.MeilingDataReaderMapToList<ProductSatus>(reader);
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
        public List<ProductClosingVO> ClosingSearch(string Ccode, string start, string end, string comno, string item) // 제품현황 검색조건
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_ClosingSearch";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Ccode", (object)Ccode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@start", (object)start ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@end", (object)end ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@comno", (object)comno ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@item", (object)item ?? DBNull.Value);

                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProductClosingVO> list = Helper.MeilingDataReaderMapToList<ProductClosingVO>(reader);
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

        public List<ProductClosingVO> ClosingStatusSearch(string Ccode, string start, string end, string comno, string item) // 제품현황 검색조건
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_ClosingStatusSearch";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Ccode", (object)Ccode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@start", (object)start ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@end", (object)end ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@comno", (object)comno ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@item", (object)item ?? DBNull.Value);

                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProductClosingVO> list = Helper.MeilingDataReaderMapToList<ProductClosingVO>(reader);
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
                string sql = @"select  s.[Fact_Code] [Fact_Code], [Fact_Name] , s.[Item_Code] [Item_Code],[Item_Name],[Item_Type],[Item_Size],[Qty],[Item_Unit]
                                        ,[Stock_Other] ,convert(nvarchar, [Insert_Date]) [Insert_Date]
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
        public List<PSMManager> PSMMSearch(string item, string Fact, string txt) // 공정이동 진그리드1 검색조건
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_PSMSearch";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

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
                    cmd.Parameters.AddWithValue("@Fact", Fact);
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
                                                ss.Item_Code Item_Code, i.item_Name, i.Item_Size, i.Item_Type, Shift_Qty,
	                                            case when Category = '자재출고' then '0'
                                                     when Category = '자재입고' then '0'
													 when Category = '고객주문별이동' then '0'
                                                     else isnull(u.Price_Present, 0) 
													 end Price_Present,
 	                                            (Shift_Qty * case when Category = '자재출고' then 0
																  when Category = '자재입고' then 0
																  when Category = '고객주문별이동' then 0
                                                     else isnull(u.Price_Present, 0) end ) Price,
	                                            	 ss.modifier modifier
                                        from StockStatus ss left join Item i on ss.Item_Code = i.Item_Code
                                                            left join UnitPrice u on ss.Item_Code = u.Item_Code and Price_EndDate = '3333-12-31'
                                        where 1=1";


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
        public bool ShiftProduct(string Item, string Fact, string Modifier, int Qty, string primary) // 제품공정이동 프로시저
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_ShiftProduct";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@Item_Code", Item);
                    cmd.Parameters.AddWithValue("@Fact_Code", Fact);
                    cmd.Parameters.AddWithValue("@Modifier", Modifier);
                    cmd.Parameters.AddWithValue("@Out_Unit", Qty);
                    cmd.Parameters.AddWithValue("@So_WorkOrderID", primary);




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
        public bool OutProduct(string Primary, string Item, int Price, string Modifier, int Qty) // 제품출하 프로시저
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_OutProdcut";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Primary", Primary);
                    cmd.Parameters.AddWithValue("@Item", Item);
                    cmd.Parameters.AddWithValue("@Price", Price);
                    cmd.Parameters.AddWithValue("@Modifier", Modifier);
                    cmd.Parameters.AddWithValue("@Qty", Qty);


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
        public bool OutProductCancle(string Primary, string Item, string Modifier, int Qty) // 제품출하 프로시저
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_OutProductCancle";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Primary", Primary);
                    cmd.Parameters.AddWithValue("@Item", Item);
                    cmd.Parameters.AddWithValue("@Modifier", Modifier);
                    cmd.Parameters.AddWithValue("@Qty", Qty);


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
        public List<ProductSatus> PSStatus() // 자재단가 관리 (전체)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select So_PurchaseOrder, c.Com_Name Com_Name, c.Com_Name d_Com_Name,  so.Item_Code Item_Code, i.Item_Code d_Item_Code, i.Item_name Item_name, 
		                              convert(nvarchar ,So_Duedate, 23) So_Duedate ,  convert(nvarchar ,So_OutDate, 23) So_OutDate ,so_Price Price , So_Qty,
		                              So_ProQty, so.Modifier
                                from  SalesOrder so inner join SalesMaster sm on so.Sales_ID=sm.Sales_ID
                                		            inner join Company c on sm.Com_Code=c.Com_Code
                                		            inner join Item i on so.Item_Code = i.Item_Code
                                		            inner join Stock s on so.Item_Code = s.Item_Code and Fact_Code = 'WH_M'
                                where So_OutDate is not null and so_deadline = 'n'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProductSatus> list = Helper.DataReaderMapToList<ProductSatus>(reader);
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
