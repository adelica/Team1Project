using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairDAC
{
    public class FacilityDAC : ConnectionAccess
    {
        public DataSet GetFacilityData()
        {
            DataSet ds = new DataSet();
            string sql = string.Empty;
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                sql = @"select FacG_Code, FacG_Name, FacG_UseOrNot, FacG_Modifier, FacG_ModifyDate, FacG_Information from FacilityGroup";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "facilityGroup");
                sql = @"select Faci_Code, FacG_Code, Faci_Name, Faci_OutWareHouse, Faci_InWareHouse, Faci_BadWareHouse, Faci_UseOrNot, Faci_Modifier, Faci_ModifyDate, Faci_Detail, Faci_Others
                            from Facility";
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "facility");
                conn.Close();
            }
            return ds;
        }
    }
}
