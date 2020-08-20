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
    public class AuthorDAC : ConnectionAccess
    {
        public List<AuthorGroupVO> GetAllAuthorGroup()
        {

            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = strConn;
                    cmd.CommandText = @"select [AuthorGroup_ID], [AuthorGroup_Name], [AuthorGroup_Explanation], [AuthorGroup_Order], [AuthorGroup_UseOrNot] from [dbo].[AuthorGroup]";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<AuthorGroupVO> list = Helper.MeilingDataReaderMapToList<AuthorGroupVO>(reader);
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

        public bool SaveAuthorGroup(AuthorGroupVO author)
        {
			try
			{
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.Connection = new SqlConnection(this.ConnectionString);
					cmd.CommandText = @"Merge AuthorGroup As T
Using(
	select    
			   @AuthorGroup_ID						as   AuthorGroup_ID
			,  @AuthorGroup_Name                   As    AuthorGroup_Name             
	        ,  @AuthorGroup_Explanation            as	 AuthorGroup_Explanation      
			,  @AuthorGroup_Order                  as	 AuthorGroup_Order       		
			,  @AuthorGroup_UseOrNot               as	 AuthorGroup_UseOrNot    		
												
		
	)
as S
on (T.AuthorGroup_ID=S.AuthorGroup_ID)
When matched Then 
	update set 
	      T.AuthorGroup_Name             =      s.AuthorGroup_Name          
		, T.AuthorGroup_Explanation    =	    s.AuthorGroup_Explanation 
		, T.AuthorGroup_Order          =	    s.AuthorGroup_Order       
		, T.AuthorGroup_UseOrNot    	   =	s.AuthorGroup_UseOrNot   
when not matched then
 insert  (
		 AuthorGroup_Name        
		,AuthorGroup_Explanation        
		,AuthorGroup_Order       	  
		,AuthorGroup_UseOrNot   
)
	values 
	(  
	   s.AuthorGroup_Name        
	,  s.AuthorGroup_Explanation        
	 , s.AuthorGroup_Order       	  
	 , s.AuthorGroup_UseOrNot   
	 ); ";
					cmd.Parameters.AddWithValue("@AuthorGroup_ID", author.AuthorGroup_ID);
					cmd.Parameters.AddWithValue("@AuthorGroup_Name", author.AuthorGroup_Name);
					cmd.Parameters.AddWithValue("@AuthorGroup_Explanation", author.AuthorGroup_Explanation);
					cmd.Parameters.AddWithValue("@AuthorGroup_Order", author.AuthorGroup_Order);
					cmd.Parameters.AddWithValue("@AuthorGroup_UseOrNot", author.AuthorGroup_UseOrNot);
					
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
