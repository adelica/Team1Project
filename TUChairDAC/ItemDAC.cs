using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;

namespace TUChairDAC
{
    public class ItemDAC :ConnectionAccess
    {
        public List<ItemVO> GetAllItem()
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"select Item_Code, Item_Name, Item_Size, Item_Type, Item_Qty, ISNULL(Faci_Code,'')
     , Item_OrderComp, Item_InWarehouse, Item_OutWarehouse, Item_SafeQuantity
     , Item_Unit, Item_Importins, Item_Processins, Item_Shipmentins
    , Item_Manager, Item_Modifier, Item_ModiflyDate, Item_UserOrNot, Item_Other
from
Item";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ItemVO> list = Helper.MeilingDataReaderMapToList<ItemVO>(reader);
                    cmd.Connection.Close();

                    return list;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<ItemVO> SearchItem(string sg)
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"SearchItem";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Condition", sg);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ItemVO> list = Helper.MeilingDataReaderMapToList<ItemVO>(reader);
                    cmd.Connection.Close();

                    return list;
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }
    }
}
