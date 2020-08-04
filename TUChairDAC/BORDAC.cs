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
        public List<BORVO> GetBORData()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"select BOR_Code, b.Item_Code, Item_Name, b.FacG_Code, FacG_Name, b.Faci_Code, Faci_Name,BOR_TactTime, BOR_Priority, BOR_Yeild, BOR_UseOrNot, BOR_Other
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
                return null;
            }
        }
    }
}
