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
    public class UnitPriceDAC : ConnectionAccess
    {
        public List<UnitPriceVO> UPBinding() // 자재단가 관리 (전체)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select [PriceNO], [Com_No], [Com_Code], [Com_Name], [Item_Code], [Item_ Name], [Item_Size], [Item_Unit], [Price_Present], [Price_transfer], [Price_StartDate],[Price_EndDate],[Price_UserOrNot]  from [dbo].[UnitPrice]";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<UnitPriceVO> list = Helper.MeilingDataReaderMapToList<UnitPriceVO>(reader);
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
        public List<UnitPriceVO> ProductUPBinding() // 영업단가 관리 (완제품)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select [PriceNO], [Com_No], [Com_Code], [Com_Name], [Item_Code], [Item_ Name], [Item_Size], [Item_Unit], [Price_Present], [Price_transfer], [Price_StartDate],[Price_EndDate],[Price_UserOrNot]  from [dbo].[UnitPrice] where [Item_Code] = 'CHAIR_01'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<UnitPriceVO> list = Helper.MeilingDataReaderMapToList<UnitPriceVO>(reader);
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

     \
    }
}
