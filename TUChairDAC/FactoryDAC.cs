using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChairVO;

namespace TUChairDAC
{
    public class FactoryDAC : ConnectionAccess
    {
        public List<FactoryVO> GetFactoryData()
        {
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"WITH A AS
                                    (   SELECT f.Fact_Name,f.Fact_Code, 0 AS Lvl , convert(varchar(255), Fact_Code) sortOrder
                                         FROM Factory f
                                    	 WHERE f.Fact_parent = '*'
                                         UNION ALL 
                                         SELECT F1.Fact_Name, F1.Fact_Code,  A.Lvl+1 as Lvl , convert(varchar(255), convert(nvarchar,A.sortOrder) + ' > ' + convert(varchar(255), F1.Fact_Code)) sortOrder
                                          FROM A JOIN Factory F1 ON F1.Fact_Parent = A.Fact_Code
                                    )
                                    SELECT CASE WHEN A.Lvl = 0 THEN '▶'
                                                ELSE SUBSTRING ('      ',1,A.LVL * 3) + '└ ' END + B.Fact_Name AS Fact_BOM, b.*
                                         
                                      FROM A JOIN Factory B ON A.Fact_Code = B.Fact_Code order by A.SortOrder";
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<FactoryVO> list = Helper.DataReaderMapToList<FactoryVO>(reader);
                    cmd.Connection.Close();
                    return list;
                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message);
                return null;
            }
        }

        public bool FactoryInfoRegi(string fGroup, string fParent, string fClass, string fCode, string fName, string fModifier, DateTime fModifyDate, string fUseOrNot, string fInfo, string fType)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"insert into factory (Fact_Group, Fact_Class, Fact_Code, Fact_Name, Fact_Parent, Fact_Modifier, Fact_ModifyDate, Fact_UseOrNot,  Fact_Information,Fact_Type)
                                                        values(@fGroup, @fClass, @fCode, @fName, @fParent, @fModifier, @fModifyDate, @fUseOrNot, @fInfo, @fType)";
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Parameters.AddWithValue("@fGroup", fGroup);
                    cmd.Parameters.AddWithValue("@fClass", fClass);
                    cmd.Parameters.AddWithValue("@fCode", fCode);
                    cmd.Parameters.AddWithValue("@fName", fName);
                    cmd.Parameters.AddWithValue("@fParent", fParent);
                    cmd.Parameters.AddWithValue("@fModifier", fModifier);
                    cmd.Parameters.AddWithValue("@fModifyDate", fModifyDate);
                    cmd.Parameters.AddWithValue("@fUseOrNot", fUseOrNot);

                    cmd.Parameters.AddWithValue("@fInfo", fInfo);
                    cmd.Parameters.AddWithValue("@fType", fType);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
                //_log.WriteError(err.Message);               
            }
        }
    }
}
