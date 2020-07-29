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
        public List<FactoryVO> FactoryInfo()
        {
            try
            {
                SqlConnection strConn = new SqlConnection(this.ConnectionString);
                string sql = @"WITH A AS
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
                using (SqlCommand cmd = new SqlCommand(sql,strConn))
                {
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<FactoryVO> list = Helper.DataReaderMapToList<FactoryVO>(reader);
                    cmd.Connection.Close();
                    return list;
                }
            }
            catch(Exception err)
            {
               MessageBox.Show(err.Message);
                return null;
            }
        }
    }
}
