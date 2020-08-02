using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;

namespace TUChairDAC
{
    public class commonDAC : ConnectionAccess
    {
        public List<ComboItemVO> getCommonCode(string codeTypes)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string seperator = "@";
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "GetCodeInfoByCodeTypes";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_CodeTypes", codeTypes);
                cmd.Parameters.AddWithValue("@P_Seperator", seperator);

                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ComboItemVO> list = Helper.DataReaderMapToList<ComboItemVO>(reader);
                cmd.Connection.Close();

                return list;
            }

        }
    }
}
