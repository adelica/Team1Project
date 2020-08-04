using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;

namespace TUChairDAC
{
    public class UnitPriceDAC : ConnectionAccess
    {
        public List<ViewUnitPriceVO> UPBinding() // 자재단가 관리 (전체)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"SELECT [PriceNO], u.[Com_Code] [Com_Code],c.[Com_Name] [Com_Name], u.[Item_Code] [Item_Code], i.[Item_Name] [Item_Name], i.[Item_Size] [Item_Size],
	                             i.[Item_Unit] [Item_Unit], [Price_Present], [Price_transfer],convert(nvarchar, [Price_StartDate],23)[Price_StartDate], convert(nvarchar, [Price_EndDate],23)[Price_EndDate], [Price_UserOrNot], [Modifier], [ModifierDate], [Unit_Other]
                              from [dbo].[UnitPrice] u left join [dbo].[Company] c  on u.Com_Code = c.Com_Code  left join  [dbo].[Item] i on u.Item_Code = i.Item_Code";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ViewUnitPriceVO> list = Helper.DataReaderMapToList<ViewUnitPriceVO>(reader);
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
        public List<ViewUnitPriceVO> ProductUPBinding() // 영업단가 관리 (완제품)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"SELECT [PriceNO], u.[Com_Code] [Com_Code],c.[Com_Name] [Com_Name], u.[Item_Code] [Item_Code], i.[Item_Name] [Item_Name], i.[Item_Size] [Item_Size],
	                             i.[Item_Unit] [Item_Unit], [Price_Present], [Price_transfer],convert(nvarchar, [Price_StartDate],23)[Price_StartDate], convert(nvarchar, [Price_EndDate],23)[Price_EndDate], [Price_UserOrNot], [Modifier], [ModifierDate],[Unit_Other]
                              from [dbo].[UnitPrice] u left join [dbo].[Company] c  on u.Com_Code = c.Com_Code  left join  [dbo].[Item] i on u.Item_Code = i.Item_Code where u.[Item_Code] = 'CHAIR_01'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ViewUnitPriceVO> list = Helper.MeilingDataReaderMapToList<ViewUnitPriceVO>(reader);
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
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    

                    //cmd.Parameters.AddWithValue("@PriceNO", /*(object)upv.PriceNO ??*/ DBNull.Value);
                    cmd.Parameters.AddWithValue("@Com_Code", upv.Com_Code);
                    cmd.Parameters.AddWithValue("@Item_Code", upv.Item_Code.ToString());
                    cmd.Parameters.AddWithValue("@Price_Present", upv.Price_Present);
                    cmd.Parameters.AddWithValue("@Price_transfer", (object)upv.Price_transfer ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Price_StartDate", upv.Price_StartDate);
                    cmd.Parameters.AddWithValue("@Price_EndDate", upv.Price_EndDate ?? DBNull.Value.ToString());
                    cmd.Parameters.AddWithValue("@Price_UserOrNot", (object)upv.Price_UserOrNot ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Modifier", upv.Modifier);
                    cmd.Parameters.AddWithValue("@ModifierDate", upv.ModifierDate);
                    cmd.Parameters.AddWithValue("@Unit_Other", (object)upv.Unit_Other ?? DBNull.Value);







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
        #region 검색조건
        public List<ViewUnitPriceVO> SearchText(string txt) // 영업단가 관리 (완제품)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = $@"SELECT [PriceNO], u.[Com_Code] [Com_Code],c.[Com_Name] [Com_Name], u.[Item_Code] [Item_Code], i.[Item_Name] [Item_Name], i.[Item_Size] [Item_Size],
	                             i.[Item_Unit] [Item_Unit], [Price_Present], [Price_transfer],convert(nvarchar, [Price_StartDate],23)[Price_StartDate], convert(nvarchar, [Price_EndDate],23)[Price_EndDate], [Price_UserOrNot], [Modifier], [ModifierDate],[Unit_Other]
                              from [dbo].[UnitPrice] u left join [dbo].[Company] c  on u.Com_Code = c.Com_Code  left join  [dbo].[Item] i on u.Item_Code = i.Item_Code where u.[Item_Code] like '%{txt}%'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ViewUnitPriceVO> list = Helper.MeilingDataReaderMapToList<ViewUnitPriceVO>(reader);
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
        #endregion

    }
}
