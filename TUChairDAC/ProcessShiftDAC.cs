﻿using System;
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

        public bool PSShiftInsert(ProcessShiftVO sht) // 공정이동 프로시저
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_ProcessShift";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@NO", sht.No);
                    cmd.Parameters.AddWithValue("@ThisDate", sht.Insert_Date ?? DBNull.Value.ToString());
                    cmd.Parameters.AddWithValue("@Fact_Code", sht.Fact_Code);



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
                _log.WriteError(e.Message, e);
                throw e;
            }
        }

        public bool PSShiftReturn(ProcessShiftVO sht) //공정이동 취소
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_ReturnProcessShift";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@NO", sht.No);
                    cmd.Parameters.AddWithValue("@ThisDate", sht.Insert_Date);
                    cmd.Parameters.AddWithValue("@Fact_Code", sht.Fact_Code);



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
    }
}