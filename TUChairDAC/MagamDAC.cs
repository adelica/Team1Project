using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairDAC
{
    public class MagamDAC : ConnectionAccess
    {
        public List<MonthDeadLineVO> AllMagamBind() // 자재단가 관리 (전체)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select s.com_code	com_code,c.com_name	com_name,c.Com_CorporRegiNum CorporRegiNum,sum(s.So_Price*s.So_Qty) ALLPrice , '매출' as type, s.So_Deadline YorN
                                from SalesOrder s left join Company c on s.Com_Code = c.Com_Code
                                				   
                                where  So_Deadline = 'y'
                                group by s.com_code	,c.com_name	,c.com_corporreginum, So_Deadline 
                                
                                union all
                                
                                
                                select v.com_code  com_code,c.com_name  com_name,com_corporreginum	CorporRegiNum, sum(vo_price*Vo_Quantity) ALLPrice  ,'매입' as type 
                                     , case when  Materail_Order_State = '입고' then 'Y'
                                			 else '미입고' end YorN 
                                from VendorOrder v left join Company c on v.Com_Code = c.Com_Code			 
                                where  v.Materail_Order_State = '입고'
                                group by  v.com_code,c.com_name,com_corporreginum, 	v.Materail_Order_State";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<MonthDeadLineVO> list = Helper.DataReaderMapToList<MonthDeadLineVO>(reader);
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
        public List<MonthDLDetail> MagamDetail(string pry , string date) // 진그리드 2 바인딩
        {
            //try
            //{
            //    SqlConnection conn = new SqlConnection(this.ConnectionString);
            //    string sql = $@"select  c.Com_Name Com_Name, c.Com_Name Com_Name, So_OutDate Date, '고객사창고' Fact_Name , '정상판매' Category ,so.Item_Code Item_Code
            //                            ,i.Item_Name Item_Name, i.Item_Size Item_Size, So_ProQty Qty,So_Price Price,(So_ProQty * So_Price) AllPrice
            //                      from SalesOrder so left join Company c on so.Com_Code = c.Com_Code
            //                                         left join Item i on so.Item_Code = i.Item_Code
            //                            where So_Deadline = 'y' And so.Com_Code in  (" + pry + ") AND CONVERT(VARCHAR(10), So_OutDate, 23) like  date
            //                            union all
            //                            select c.Com_Name Com_Name, c.Com_Name Com_Name, Vo_InDate  Date, case when i.Item_Code = 'BACK_A_02' then ''반제품창고A''
            //                                                                             else ''원자재창고A''
            //                                                                             end Fact_Name
            //                                         ,''구매입고'' Category , v.Item_Code Item_Code, i.Item_Name Item_Name, i.Item_Size Item_Size, Vo_Quantity Qty ,Vo_Price Price,(Vo_Quantity * Vo_Price) AllPrice
            //                                 from VendorOrder v left join Company c on v.Com_Code = c.Com_Code

            //                                           left join Item i on v.Item_Code = i.Item_Code

            //                            where Materail_Order_State = ''입고'' '+@Month2+' '+@co+''";
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        conn.Open();
            //        SqlDataReader reader = cmd.ExecuteReader();
            //        List<MonthDeadLineVO> list = Helper.DataReaderMapToList<MonthDeadLineVO>(reader);
            //        cmd.Connection.Close();
            //        return list;
            //    }
            //}
            //catch (Exception err)
            //{
            //    Debug.WriteLine(err.Message);

            //    return null;
            //}
            ////string a = "AND CONVERT(VARCHAR(10), So_OutDate, 23) like date%"
            //try
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        cmd.Connection = new SqlConnection(this.ConnectionString);
            //        cmd.CommandText = $@"select  c.Com_Name Com_Name, c.Com_Name Com_Name, So_OutDate Date, '고객사창고' Fact_Name , '정상판매' Category ,so.Item_Code Item_Code
            //           ,i.Item_Name Item_Name, i.Item_Size Item_Size, So_ProQty Qty,So_Price Price,(So_ProQty * So_Price) AllPrice
            //                            from SalesOrder so left join Company c on so.Com_Code = c.Com_Code

            //                                           left join Item i on so.Item_Code = i.Item_Code

            //                            where So_Deadline = 'y' And so.Com_Code in  (" + pry + ") AND CONVERT(VARCHAR(10), So_OutDate, 23) like  date "
            //                            +
            //                            " union all" +



            //                            select c.Com_Name Com_Name, c.Com_Name Com_Name, Vo_InDate  Date, case when i.Item_Code = ''BACK_A_02'' then ''반제품창고A''

            //                                                                             else ''원자재창고A''

            //                                                                             end Fact_Name
            //                                         ,''구매입고'' Category , v.Item_Code Item_Code, i.Item_Name Item_Name, i.Item_Size Item_Size, Vo_Quantity Qty ,Vo_Price Price,(Vo_Quantity * Vo_Price) AllPrice
            //                                 from VendorOrder v left join Company c on v.Com_Code = c.Com_Code

            //                                           left join Item i on v.Item_Code = i.Item_Code

            //                            where Materail_Order_State = ''입고'' '+@Month2+' '+@co+''";
            //        //cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //        //cmd.Parameters.AddWithValue("@CCode", (object)pry ?? DBNull.Value);
            //        //cmd.Parameters.AddWithValue("@ThisMonth", (object)date ?? DBNull.Value);


            //        cmd.Connection.Open();

            //        SqlDataReader reader = cmd.ExecuteReader();
            //        List<MonthDLDetail> list = Helper.MeilingDataReaderMapToList<MonthDLDetail>(reader);
            //        cmd.Connection.Close();
            //        return list;
            //    }
            //}
            //catch (Exception err)
            //{
            //    Debug.WriteLine(err.Message);

            //    return null;
            //}


            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_MonthListDetail";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CCode", pry);
                    cmd.Parameters.AddWithValue("@ThisMonth", (object)date ?? DBNull.Value);


                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<MonthDLDetail> list = Helper.MeilingDataReaderMapToList<MonthDLDetail>(reader);
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
