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
    public class BOMDAC : ConnectionAccess
    {
        public List<BOMVO> getALLBom()
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"select [INFO], [Item_Type], [BOM_No], [ItemCode],[Item_Code], [ParentItem_Code], [BOM_Require], [Lvl], [BOM_StartDate], [BOM_EndDate], [BOM_UserOrNot], [BOM_Modifier], [BOM_ModifiyDate], [BOM_AutoDeducion], [BOM_RequirePlan], [BOM_Others]
from [dbo].[vm_Bom2] order by [sortOrder] ";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<BOMVO> list = Helper.MeilingDataReaderMapToList<BOMVO>(reader);
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

        public List<BOMVO> SearchBOM(DateTime value, string text, string selectedValue)
        {
			try
			{
				SqlConnection strConn = new SqlConnection(this.ConnectionString);

				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.Connection = strConn;
					cmd.CommandText = @"SP_SearchBOM";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@P_Item_Code", text);
					cmd.Parameters.AddWithValue("@P_DateT", value);
					cmd.Parameters.AddWithValue("@P_BOMType", selectedValue);
					cmd.Connection.Open();
					SqlDataReader reader = cmd.ExecuteReader();
					List<BOMVO> list = Helper.MeilingDataReaderMapToList<BOMVO>(reader);
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

        public bool DeleteBOM(string condition)
		{
			try
			{
				SqlConnection strConn = new SqlConnection(this.ConnectionString);

				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.Connection = strConn;
					cmd.CommandText = @"DeleteBOM";
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
        public bool SaveBOM(BOMVO bomInfo)
        {
			try
			{
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.Connection = new SqlConnection(this.ConnectionString);
					cmd.CommandText = @"Merge BOM As T
Using(
select
    @BOM_No                   As        BOM_No
  , @ParentItem_Code		  as	    ParentItem_Code
  , @Item_Code				  as	    Item_Code
  , @BOM_Require			  as	    BOM_Require
  , @BOM_StartDate			  as        BOM_StartDate
  , @BOM_EndDate			  as	    BOM_EndDate
  , @BOM_UserOrNot			  as	    BOM_UserOrNot
  , @BOM_Modifier			  AS	    BOM_Modifier
  , @BOM_AutoDeducion		  as	    BOM_AutoDeducion
  , @BOM_RequirePlan		  as	    BOM_RequirePlan
  , @BOM_Others				  as	    BOM_Others
  
 )
as S
on (T.BOM_No=S.BOM_No)
When matched Then 
	update set 
		  T.ParentItem_Code		  =		S.ParentItem_Code	
		, T.Item_Code			  =		S.Item_Code		
		, T.BOM_Require			=		S.BOM_Require		
		, T.BOM_StartDate		 =		S.BOM_StartDate	
		, T.BOM_EndDate				=	S.BOM_EndDate
		, T.BOM_UserOrNot			=	S.BOM_UserOrNot
		, T.BOM_Modifier			=	S.BOM_Modifier
		, T.BOM_ModifiyDate			 =	getdate()
		, T.BOM_AutoDeducion	 =		S.BOM_AutoDeducion
		, T.BOM_RequirePlan		=		S.BOM_RequirePlan
		, T.BOM_Others			=		S.BOM_Others
		
when not matched then
 insert  (
		  ParentItem_Code	 
		, Item_Code		
		, BOM_Require		
		, BOM_StartDate	
		, BOM_EndDate		 
		, BOM_UserOrNot	 
		, BOM_Modifier	 
		, BOM_ModifiyDate	
		, BOM_AutoDeducion
		, BOM_RequirePlan	  
		, BOM_Others	
		)
	values 
	(  
	   s.ParentItem_Code	 
	,  s.Item_Code		
	 , s.BOM_Require		
	 , s.BOM_StartDate	
	 , s.BOM_EndDate		 
	 , s.BOM_UserOrNot	 
	 , s.BOM_Modifier	 
	 , getdate()	
	 , s.BOM_AutoDeducion
	 , s.BOM_RequirePlan	  
	 , s.BOM_Others	
		); ";
					cmd.Parameters.AddWithValue("@BOM_No",				bomInfo.BOM_No				 );
					cmd.Parameters.AddWithValue("@ParentItem_Code",		bomInfo.ParentItem_Code		 );
					cmd.Parameters.AddWithValue("@Item_Code",			bomInfo.Item_Code			 );
					cmd.Parameters.AddWithValue("@BOM_Require",			bomInfo.BOM_Require			 );
					cmd.Parameters.AddWithValue("@BOM_StartDate",		bomInfo.BOM_StartDate		 );
					cmd.Parameters.AddWithValue("@BOM_UserOrNot",		bomInfo.BOM_UserOrNot		 );
					cmd.Parameters.AddWithValue("@BOM_EndDate",			bomInfo.BOM_EndDate			 );
					cmd.Parameters.AddWithValue("@BOM_AutoDeducion",	bomInfo.BOM_AutoDeducion	 );
					cmd.Parameters.AddWithValue("@BOM_RequirePlan",		bomInfo.BOM_RequirePlan		 );
					cmd.Parameters.AddWithValue("@BOM_Others",			bomInfo.BOM_Others			 );
					cmd.Parameters.AddWithValue("@BOM_Modifier", bomInfo.BOM_Modifier);

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
    }
}
