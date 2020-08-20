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
                    string sql = @"select REPLICATE('0',5-len(convert(nvarchar(20),Vo_ID)))+convert(varchar(20), Vo_ID) as Vo_ID,  V.Vo_ID as ID, c.Com_Name, Materail_Order_State,i.Item_Name, i.Item_Code,i.Item_Size,i.Item_Unit, Vo_Quantity, Vo_EndDate, Vo_StarDate, Vo_InDate
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

        public bool InsertBalzu(List<balzuVO> balzus)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"insert into [dbo].[VendorOrder]([Com_Code], [Materail_Order_State], [Item_Code], [Vo_Quantity], [Vo_EndDate], [Vo_StarDate], [Vo_Price])
			values(
  @Com_Code
, @Materail_Order_State
, @Item_Code
, @Vo_Quantity
, @Vo_EndDate
, getdate()
, @Vo_Price   )  ";
                    int isflag=0; 
                    foreach (var balzu in balzus)
                    {
                        var date =  DateTime.Parse(balzu.Vo_EndDate);
                        cmd.Parameters.AddWithValue("@Com_Code", balzu.Com_Code);
                        cmd.Parameters.AddWithValue("@Materail_Order_State", balzu.Materail_Order_State);
                        cmd.Parameters.AddWithValue("@Item_Code", balzu.Item_Code);
                        cmd.Parameters.AddWithValue("@Vo_Quantity", balzu.Vo_Quantity);
                        cmd.Parameters.AddWithValue("@Vo_EndDate", date);
                        cmd.Parameters.AddWithValue("@Vo_Price", balzu.Vo_Price);

                        cmd.Connection.Open();
                        var rowsAffected = cmd.ExecuteNonQuery();
                         isflag= rowsAffected;
                        cmd.Connection.Close();
                        cmd.Parameters.Clear();
                    }

                    return isflag > 0;
                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message, err);
                throw err;
            }
        }

        public List<PbalzuVO> GetBalzuItemList(string planID)
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"with balzu as (select vb.Item_Code
		,vb.Item_Name
		,vb.Item_Type
		,i.Item_Size
		,s.Com_Code
		,cp.Com_Name
		,cp.Com_CorporRegiNum
		,cp.Com_Type
		,s.So_Price
		,s.So_Qty*vb.BOM_Require Qty

		, (select [dbo].[GetItemDueDate2](s.So_Duedate,s.So_Qty*BOM_Require,vb.Item_Code,vb.Item_Top_Code)) as duedate
		from vm_Bom vb left outer join  (select *from bor where BOR_UseOrNot = '사용') br on vb.Item_Code=br.Item_Code  
inner join (select so.Item_Code,so.So_Price,so.So_Qty,so.So_Duedate,sm.Com_Code from SalesOrder so 
inner join SalesMaster sm on so.Sales_ID=sm.Sales_ID where so.Sales_ID=@planID) s on vb.Item_Top_Code=s.Item_Code 
inner join [dbo].[Company] cp on s.Com_Code=cp.Com_Code 
inner join item i on i.Item_Code = vb.Item_Code
where vb.Item_Type='원자재')

select b.Com_Name,b.Com_Type,b.Item_Name,b.Item_Code,b.Item_Size,b.Qty,b.Com_CorporRegiNum,b.duedate,p.Price_Present,b.Qty*p.Price_Present as Price,case when v.Vo_ID is Null then 'N' else 'Y' end as isbalzu from balzu b left outer join  (select top(1) Price_Present, Item_Code from [dbo].[UnitPrice] order by Price_StartDate desc) p on b.Item_Code=p.Item_Code
						left outer join [dbo].[VendorOrder] v on b.Item_Code=v.Item_Code and b.duedate = v.Vo_EndDate

";
                    cmd.Parameters.AddWithValue("@planID", planID);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<PbalzuVO> list = Helper.MeilingDataReaderMapToList<PbalzuVO>(reader);
                    cmd.Connection.Close();
                    return list;
                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message, err);
                throw err;
            }
        }

        public DataTable GetBalzuItem(string text, DateTime start, DateTime end)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    DataTable dt = new DataTable();
                    string sql = @"SP_ProductSoYoPlan2";
                    string startdt = start.ToString("yyyy-MM-dd");
                    string enddt = end.ToString("yyyy-MM-dd");
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_PLAN_ID", text);
                    cmd.Parameters.AddWithValue("@S_DATE", startdt);
                    cmd.Parameters.AddWithValue("@E_DATE", enddt);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
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
                    string sql = @"select REPLICATE('0',5-len(convert(nvarchar(20),Vo_ID)))+convert(varchar(20), Vo_ID) as Vo_ID,  V.Vo_ID as ID, c.Com_Name, Materail_Order_State,i.Item_Name, i.Item_Code,i.Item_Size,i.Item_Unit, Vo_Quantity, Vo_EndDate, Vo_StarDate, Vo_InDate
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
