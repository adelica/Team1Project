﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;

namespace TUChairDAC
{
    public class ProductOutDAC : ConnectionAccess
    {
        public List<ProductOutVO> POutBinding() // 자재단가 관리 (전체)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select So_PurchaseOrder,convert(nvarchar ,So_Duedate, 23) So_Duedate ,So_WorkOrderID,  s.Com_Code Com_Code, c.Com_Name Com_Name,
		                              s.Com_Code d_Com_Code, c.Com_Name d_Com_Name, so.Item_Code Item_Code, i.Item_Code d_Item_Code,i.Item_name Item_name,
  	                                  So_Qty, So_ShipQty, 0 as 'Out_Unit'
                                 from  SalesOrder so inner join SalesMaster s on so.Sales_ID=s.Sales_ID
				                                     inner join Company c on s.Com_Code=c.Com_Code
				                                     inner join Item i on so.Item_Code = i.Item_Code
                                where So_Qty =So_ShipQty";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProductOutVO> list = Helper.DataReaderMapToList<ProductOutVO>(reader);
                    cmd.Connection.Close();
                    return list;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);

                return null;
            }
        }

        public List<CProductOutVO> CProductBinding() // 완제품 제품창고로 이동관리
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                string sql = @"select so.Item_Code Item_Code,i.Item_name Item_Name, i.item_size Item_Size, convert(nvarchar ,So_Duedate, 23) So_Duedate , 
  	                                 (So_Qty -So_ShipQty)N_Qty, s.Fact_Code Fact_Code, s.Qty Qty,'WH_M' as ToFact,  0 as 'Out_Unit',So_WorkOrderID
                                from  SalesOrder so inner join SalesMaster sm on so.Sales_ID=sm.Sales_ID					
					                                inner join Item i on so.Item_Code = i.Item_Code
					                                inner join Stock s on so.Item_Code = s.Item_Code  and Fact_Code = 'WH03'
                                where So_Qty <>So_ShipQty";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<CProductOutVO> list = Helper.DataReaderMapToList<CProductOutVO>(reader);
                    cmd.Connection.Close();
                    return list;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);

                return null;
            }
        }

    }
}
