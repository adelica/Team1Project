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
                    cmd.CommandText = @"select Item_Code, Item_Name, Item_Size, Item_Type
     , Item_OrderComp, Item_InWarehouse, Item_OutWarehouse, Item_SafeQuantity
     , Item_Unit, Item_Importins, Item_Processins, Item_Shipmentins
    , Item_Manager, Item_Modifier, Item_ModiflyDate, Item_UserOrNot, Item_Other,Item_OutSourcing
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
				_log.WriteError(err.Message, err);
				throw err;

            }
        }

		public void IpGoUpdate(int barID)
		{
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = new SqlConnection(this.ConnectionString);
				cmd.CommandText = @"update VendorOrder set Materail_Order_State='입고', Vo_InDate= getdate() where Vo_ID=@barID";
				cmd.Parameters.AddWithValue("@barID", barID);

				cmd.Connection.Open();
				var rowsAffected = cmd.ExecuteNonQuery();
				cmd.Connection.Close();

			}
		}
		public bool DeleteItem(string condition)
		{
			try
			{
				SqlConnection strConn = new SqlConnection(this.ConnectionString);

				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.Connection = strConn;
					cmd.CommandText = @"DeleteItem";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@P_Condition", condition);
					cmd.Parameters.AddWithValue("@P_Seperator", "@");
					cmd.Connection.Open();
					var rowsAffected = cmd.ExecuteNonQuery();
					cmd.Connection.Close();

					return rowsAffected > 0;
				}
			}
			catch (Exception err)
			{
				_log.WriteError(err.Message, err);
				throw err;
			}
		}

		public bool SaveItem(ItemVO item)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"Merge Item As T
Using(
	select     @Item_Code                 As Item_Code
	        ,  @Item_Name           as	Item_Name         
			,  @Item_Size            as	Item_Size		  
			,  @Item_Type            as	Item_Type		
			,  @Item_Modifier   as Item_Modifier
			,  @Item_OrderComp       as	Item_OrderComp	  
			,  @Item_InWarehouse     as	Item_InWarehouse  
			,  @Item_OutWarehouse    as	Item_OutWarehouse 
			,  @Item_SafeQuantity    as	Item_SafeQuantity 
			,  @Item_Unit            as	Item_Unit
			,  @Item_Importins       as	Item_Importins	
			,  @Item_Processins      as	Item_Processins	  
			,  @Item_Shipmentins     as	Item_Shipmentins  
			,  @Item_Manager         as	Item_Manager	
			,  @Item_UserOrNot       as	Item_UserOrNot	  
			,  @Item_Other           as	Item_Other		  
			,  @Item_OutSourcing    as	Item_OutSourcing  )
as S
on (T.Item_Code=S.Item_Code)
When matched Then 
	update set 
	      T.Item_Name          =    s.Item_Name       
		, T.Item_Size		   =	s.Item_Size		
		, T.Item_Type		   =	s.Item_Type	

		, T.Item_OrderComp	   =	s.Item_OrderComp	
		, T.Item_InWarehouse   =	s.Item_InWarehouse
		, T.Item_OutWarehouse  =	s.Item_OutWarehouse
		, T.Item_SafeQuantity  =	s.Item_SafeQuantity
		, T.Item_Unit		   =	s.Item_Unit		
		, T.Item_Importins	   =	s.Item_Importins	
		, T.Item_Processins	   =	s.Item_Processins	
		, T.Item_Shipmentins   =	s.Item_Shipmentins
		, T.Item_Manager	   =	s.Item_Manager	
		, T.Item_Modifier	   =	s.Item_Modifier	
		, T.Item_ModiflyDate   =	getdate()
		, T.Item_UserOrNot	   =	s.Item_UserOrNot	
		, T.Item_Other		   =	s.Item_Other		
		, T.Item_OutSourcing   =	s.Item_OutSourcing
when not matched then
 insert  (
		 item_Code	
		,item_Name         
		,Item_Size		  
		,Item_Type		
		,Item_OrderComp	  
		,Item_InWarehouse  
		,Item_OutWarehouse 
		,Item_SafeQuantity 
		,Item_Unit		  
		,Item_Importins	  
		,Item_Processins	  
		,Item_Shipmentins  
		,Item_Manager	  
		,Item_Modifier	  
		,Item_ModiflyDate
		,Item_UserOrNot	  
		,Item_Other		  
		,Item_OutSourcing )
	values 
	(  
	   s.Item_Code
	,  s.Item_Name         
	 , s.Item_Size		  
	 , s.Item_Type	
	 , s.Item_OrderComp	  
	,  s.Item_InWarehouse  
	 , s.Item_OutWarehouse 
	 , s.Item_SafeQuantity 
	 , s.Item_Unit		  
	 , s.Item_Importins	  
	 , s.Item_Processins	  
	 , s.Item_Shipmentins  
	 , s.Item_Manager	  
	 , s.Item_Modifier	
	 ,getdate()
	 , s.Item_UserOrNot	  
	 , s.Item_Other		  
	 , s.Item_OutSourcing ); ";
                    cmd.Parameters.AddWithValue("@Item_Code",            item.Item_Code    );
                    cmd.Parameters.AddWithValue("@Item_Name",            item.Item_Name           );
                    cmd.Parameters.AddWithValue("@Item_Size",            item.Item_Size		    );
					cmd.Parameters.AddWithValue("@Item_Type",			 item.Item_Type	);
					cmd.Parameters.AddWithValue("@Item_OrderComp",       item.Item_OrderComp	  	);
					cmd.Parameters.AddWithValue("@Item_InWarehouse",     item.Item_InWarehouse 	);
					cmd.Parameters.AddWithValue("@Item_OutWarehouse",    item.Item_OutWarehouse	);
					cmd.Parameters.AddWithValue("@Item_SafeQuantity",    item.Item_SafeQuantity	);
					cmd.Parameters.AddWithValue("@Item_Unit",			 item.Item_Unit		  	);
					cmd.Parameters.AddWithValue("@Item_Importins",       item.Item_Importins	  	);
					cmd.Parameters.AddWithValue("@Item_Processins",      item.Item_Processins		);
					cmd.Parameters.AddWithValue("@Item_Shipmentins",     item.Item_Shipmentins 	);
					cmd.Parameters.AddWithValue("@Item_Manager",		 item.Item_Manager	  	);
					cmd.Parameters.AddWithValue("@Item_Modifier",        item.Item_Modifier	  	);
					cmd.Parameters.AddWithValue("@Item_UserOrNot",       item.Item_UserOrNot	  	);
					cmd.Parameters.AddWithValue("@Item_Other",			 item.Item_Other		  	);
					cmd.Parameters.AddWithValue("@Item_OutSourcing",	 item.Item_OutSourcing);
					cmd.Connection.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return rowsAffected > 0;
                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message, err);
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
				_log.WriteError(err.Message, err);
				throw err;
            }

        }
    }
}
