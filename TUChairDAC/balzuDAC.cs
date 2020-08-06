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
    public class balzuDAC : ConnectionAccess
    {
        public DataTable GetBalzu()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    DataTable dt = new DataTable();
                    string sql = @"select REPLICATE('0',5-len(convert(nvarchar(20),Vo_ID)))+convert(varchar(20), Vo_ID) as Vo_ID,  V.Vo_ID as ID, c.Com_Name, Materail_Order_State,i.Item_Name, i.Item_Code,i.Item_Size,i.Item_Unit,i.Item_Importins, Vo_Quantity, Vo_EndDate, Vo_StarDate, Vo_InDate
from VendorOrder V inner join Company c on v.Com_Code=c.Com_Code inner join Item i on v.Item_Code=i.Item_Code
where Vo_StarDate >= 2020-06-01 and   Materail_Order_State ='미입고'";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataTable GetBalzuMiip()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    DataTable dt = new DataTable();
                    string sql = @"select REPLICATE('0',5-len(convert(nvarchar(20),Vo_ID)))+convert(varchar(20), Vo_ID) as Vo_ID,  V.Vo_ID as ID, c.Com_Name, Materail_Order_State,i.Item_Name, i.Item_Code,i.Item_Size,i.Item_Unit,i.Item_Importins, Vo_Quantity, Vo_EndDate, Vo_StarDate, Vo_InDate
from VendorOrder V inner join Company c on v.Com_Code=c.Com_Code inner join Item i on v.Item_Code=i.Item_Code
where Vo_StarDate >= 2020-06-01 and   Materail_Order_State ='입고'";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }

            catch (Exception err)
            {
                throw err;
            }
        }


        public DataTable GetBalzuReport(string strChkBarCodes)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    DataTable dt = new DataTable();
                    string sql = @"select REPLICATE('0',5-len(convert(nvarchar(20),Vo_ID)))+convert(varchar(20), Vo_ID) as Vo_ID, c.Com_Name, Materail_Order_State,i.Item_Name, i.Item_Code,i.Item_Size,i.Item_Unit,i.Item_Importins, Vo_Quantity, Vo_EndDate, Vo_StarDate, Vo_InDate
from VendorOrder V inner join Company c on v.Com_Code=c.Com_Code inner join Item i on v.Item_Code=i.Item_Code
where Vo_StarDate >= 2020-06-01 and   Materail_Order_State ='미입고' and v.Vo_ID in ("+strChkBarCodes+")";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
    
}
