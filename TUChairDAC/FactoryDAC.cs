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
                string sql = @"select Fact_No, Fact_Group, Fact_Class, Fact_Type, Fact_Code, Fact_Name, Fact_Parent, Fact_MatDeducation
                                            , Fact_UseOrNot, Fact_Modifier, Fact_ModifyDate, Fact_Information
                                        from Factory";
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
