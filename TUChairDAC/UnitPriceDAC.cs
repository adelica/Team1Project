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
        public List<UnitPriceVO> UPBinding()
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select [PriceNO], [Com_No], [Com_Code], [Com_Name], [Item_Code], [Item_Name], [Item_Size], [Item_Unit], [Price_Present], [Price_transfer], [Price_StartDate],[Price_EndDate],[Price_UserOrNot]  from [dbo].[Shift]";
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
    }
}
