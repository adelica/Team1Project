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
                    cmd.CommandText = @"select [INFO], [Item_Type], [BOM_No], [ItemCode], [ParentItem_Code], [BOM_Require], [Lvl], [BOM_StartDate], [BOM_EndDate], [BOM_UserOrNot], [BOM_Modifier], [BOM_ModifiyDate], [BOM_AutoDeducion], [BOM_RequirePlan], [BOM_Others]
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
    }
}
