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

        public bool InsertOrUpdate(UnitPriceVO upv)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_InsertUnitPrice";

                    cmd.Parameters.AddWithValue("@PriceNO", (object)upv.PriceNO ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Com_No", (object)upv.Com_No ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Com_Code", (object)upv.Com_Code ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Com_Name", upv.Com_Name);
                    cmd.Parameters.AddWithValue("@Item_Code", upv.Item_Code);
                    cmd.Parameters.AddWithValue("@Item_Name", upv.Item_Name);
                    cmd.Parameters.AddWithValue("@Item_Size", (object)upv.Item_Size ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Item_Unit", (object)upv.Item_Unit ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Price_Present", upv.Price_Present);
                    cmd.Parameters.AddWithValue("@Price_transfer", upv.Price_transfer);
                    cmd.Parameters.AddWithValue("@Price_StartDate", upv.Price_StartDate);
                    cmd.Parameters.AddWithValue("@Price_EndDate", (object)upv.Price_EndDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Price_UserOrNot", (object)upv.Price_UserOrNot ?? DBNull.Value);




                    
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
