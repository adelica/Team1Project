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
    }
}
