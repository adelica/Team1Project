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
   public class ProductClosingDAC : ConnectionAccess
    {
        public List<ProductClosingVO> PClosing() // 자재단가 관리 (전체)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select So_PurchaseOrder, c.Com_Name Com_Name, c.Com_Name d_Com_Name,  so.Item_Code Item_Code, i.Item_Code d_Item_Code, i.Item_name Item_name, 
		                             So_Qty, So_ProQty, Price_Present Price , (So_Qty * Price_Present) total,
		                               so.Modifier ,convert(nvarchar ,So_Duedate, 23) So_Duedate ,  convert(nvarchar ,So_OutDate, 23) So_OutDate 
                                from  SalesOrder so inner join SalesMaster sm on so.Sales_ID=sm.Sales_ID
                                		            inner join Company c on sm.Com_Code=c.Com_Code
                                		            inner join Item i on so.Item_Code = i.Item_Code
                                		            inner join UnitPrice u on so.Item_Code = u.Item_Code and Price_EndDate = '3333-12-31'
                                		            inner join Stock s on so.Item_Code = s.Item_Code and Fact_Code = 'WH_M'
                                where So_Qty  = So_ProQty and So_OutDate is not null and so_deadline = 'n'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProductClosingVO> list = Helper.DataReaderMapToList<ProductClosingVO>(reader);
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
        public bool PCDeadline(string Primary, string Item, string Modifier) //프로시저만들어야함
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_ProcessShift";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@NO", Primary);
                    cmd.Parameters.AddWithValue("@ThisDate", Item);
                    cmd.Parameters.AddWithValue("@Fact_Code", Modifier);



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
    }
}
