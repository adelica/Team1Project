using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;
using System.Data.SqlClient;
using System.Data;

namespace TUChairDAC
{
    public class BORDAC:ConnectionAccess
    {
        public List<BORVO> GetBORData() // BOR 데이터 바인딩
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"select BOR_Code, b.Item_Code, Item_Name, b.FacG_Code, FacG_Name, b.Faci_Code, Faci_Name,BOR_TactTime, BOR_Priority, BOR_Yeild, BOR_UseOrNot, BOR_Other,BOR_ProcessLeadDate
from BOR b left outer join FacilityGroup fg on b.FacG_Code=fg.FacG_Code
		left outer join Facility f on  b.Faci_Code=f.Faci_Code
		left outer join Item i on  b.Item_Code=i.Item_Code
";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<BORVO> list = Helper.DataReaderMapToList<BORVO>(reader);
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

     

        public bool BORInfoRegi(string itemCode, string facgCode, string faciCode, int tactT, int priority, decimal yeild, int processLead,string useOrNot, string other)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SP_SetBORInfo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Parameters.AddWithValue("@itemCode", itemCode);
                    cmd.Parameters.AddWithValue("@facgCode", facgCode);
                    cmd.Parameters.AddWithValue("@faciCode", faciCode);
                    cmd.Parameters.AddWithValue("@tactT", tactT);
                    cmd.Parameters.AddWithValue("@priority", priority);
                    cmd.Parameters.AddWithValue("@yeild", yeild);
                    cmd.Parameters.AddWithValue("@useOrNot", useOrNot);
                    cmd.Parameters.AddWithValue("@other", other);
                    cmd.Parameters.AddWithValue("@processLead", processLead);

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

        public bool DeleteBORInfo(string code) //BOR정보 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"Delete from BOR where BOR_Code in  ( "+ code + ")";
                    cmd.Parameters.AddWithValue("@code", code);

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
