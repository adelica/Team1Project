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
        //모든 데이터 가져오기
        public DataSet GetFacilityData()
        {
            try
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
            catch (Exception err)
            {
                _log.WriteError(err.Message);
                return null;
            }
        }
        //설비군 삭제
        public bool DeleteFacilityGInfo(string facG_Code)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"Delete from FacilityGroup where FacG_Code=@facG_Code";
                    cmd.Parameters.AddWithValue("@facG_Code", facG_Code);
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                }
                return true;
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message);
                return false;
            }
        }
        //바코드로 찍은 설비 정보
        public DataTable FacilityBarInfo(int barID)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                DataTable dt = new DataTable();
                string sql = @"select Faci_Code, f.FacG_Code,FacG_Name, Faci_Name, Faci_OutWareHouse, Faci_InWareHouse, Faci_BadWareHouse, Faci_UseOrNot, Faci_Detail, Faci_Others, Faci_Modifier
			from Facility f, FacilityGroup fg
			where f.FacG_Code=fg.FacG_Code and Faci_Bar = @barID";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@barID", barID);
                conn.Open();
                da.Fill(dt);
                conn.Close();
                return dt;

            }
        }
        //바코드 생성
        public DataTable FacilityInfoBarCode(string faci_Codes)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                DataTable dt = new DataTable();
                string sql = @"select Faci_Code, Faci_Name, REPLICATE('0',8-len(cast(Faci_Bar as varchar(8))))+cast(Faci_Bar as varchar(8)) as Faci_Bar
                                    From facility 
                                    where Faci_Code in (" + faci_Codes + " )";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                conn.Close();

                return dt;
            }
        }

        //설비 삭제
        public bool DeleteFacilityInfo(string faci_Code)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"Delete from Facility where Faci_Code=@faci_Code";
                    cmd.Parameters.AddWithValue("@faci_Code", faci_Code);
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                }
                return true;
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message);
                return false;
            }
        }

        //설비등록
        public bool FacilityInfoRegi(string facG_Code, string faci_Code, string faci_Name, string faci_Modifier, string faci_Detail, string faci_Others, string faci_In, string faci_Out, string faci_Bad, DateTime faci_ModifyDate, string faci_UseOrNot)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"SP_SetFacilityInfo";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@faci_Code", faci_Code);
                    cmd.Parameters.AddWithValue("@facG_Code", facG_Code);
                    cmd.Parameters.AddWithValue("@faci_Name", faci_Name);
                    cmd.Parameters.AddWithValue("@faci_Out", faci_Out);
                    cmd.Parameters.AddWithValue("@faci_In", faci_In);
                    cmd.Parameters.AddWithValue("@faci_Bad", faci_Bad);
                    cmd.Parameters.AddWithValue("@faci_UseOrNot", faci_UseOrNot);
                    cmd.Parameters.AddWithValue("@faci_Modifier", faci_Modifier);
                    cmd.Parameters.AddWithValue("@faci_ModifyDate", faci_ModifyDate);
                    cmd.Parameters.AddWithValue("@faci_Detail", faci_Detail);
                    cmd.Parameters.AddWithValue("@faci_Others", faci_Others);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                }
                return true;
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message);
                return false;
            }
        }

        //설비군 등록
        public bool FacilityGInfoRegi(string facG_Code, string facG_Name, string facG_UserOrNot, string facG_Modifier, DateTime facG_ModifyDate, string facG_Info)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_SetFacilityGroupInfo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@facG_Code", facG_Code);
                    cmd.Parameters.AddWithValue("@facG_Name", facG_Name);
                    cmd.Parameters.AddWithValue("@facG_UserOrNot", facG_UserOrNot);
                    cmd.Parameters.AddWithValue("@facG_Modifier", facG_Modifier);
                    cmd.Parameters.AddWithValue("@facG_ModifyDate", facG_ModifyDate);
                    cmd.Parameters.AddWithValue("@facG_Info", facG_Info);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                return true;
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message);
                return false;
            }
        }
    }
}
