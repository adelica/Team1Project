using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace TUChairDAC
{
    public class POSODAC:ConnectionAccess
    {
        //콤보박스 바인딩용 아이템코드, 회사코드 받아오기
        public DataSet ItemCode()
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = string.Empty;
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    sql = @"select Item_Code from item";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(ds, "item_Code");
                    sql = @"select Com_Code from Company";
                    da = new SqlDataAdapter(sql, conn);
                    da.Fill(ds, "com_Code");
                    conn.Close();

                    return ds;

                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message);
                return null;
            }
        }
        //엑셀등록한 영업마스터 DB에 등록
        public bool SetPOData(List<UpLoadVO> upList)
        {
            try
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    //cmd.CommandText
                }
                return true;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        public List<string> CheckSalesID()
        {
            try
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"Select Sales_ID from SalesMaster";
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<string> list = Helper.DataReaderMapToList<string>(reader);
                    cmd.Connection.Close();
                    return list;
                }
            }
            catch(Exception err)
            {
                return null;
            }
        }
        //영업마스터 데이터 가져오기
        public List<POVO> GetPOData()
        {
            try
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select So_WorkOrderID, So_PurchaseOrder, so.Com_Code, Com_Name, so.Item_Code, Item_Name, So_Duedate, So_Qty, So_ShipQty
                                                        from SalesOrder so inner join Company c on so.Com_Code=c.Com_Code
				                                                                	inner join Item i on so.Item_Code=i.Item_Code";
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                     List<POVO> list = Helper.DataReaderMapToList<POVO>(reader);
                    cmd.Connection.Close();

                    return list;
                }
            }
            catch(Exception err)
            {
               _log.WriteError(err.Message);
                return null;
            }
        }
        //수요계획 등록, 수정
        public bool SOInfoRegi(SOVO item)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SP_SetSOInfoRegi";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = new SqlConnection(this.ConnectionString);

                    cmd.Parameters.AddWithValue("@so_WorkOrderID", item.So_WorkOrderID);
                    cmd.Parameters.AddWithValue("@so_PurchaseOrder", item.So_PurchaseOrder);
                    cmd.Parameters.AddWithValue("@com_Code", item.Com_Code);
                    cmd.Parameters.AddWithValue("@item_Code", item.Item_Code);
                    cmd.Parameters.AddWithValue("@so_Duedate", item.So_Duedate);
                    cmd.Parameters.AddWithValue("@so_Qty", item.So_Qty);
                    cmd.Parameters.AddWithValue("@so_ShipQty", item.So_ShipQty);
                    cmd.Parameters.AddWithValue("@so_Other", item.So_Other);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return true;
                }
            }
            catch(Exception err)
            {
                _log.WriteError(err.Message);
                return false;
            }
        }
    }
}
