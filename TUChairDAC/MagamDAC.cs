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

    }
}
