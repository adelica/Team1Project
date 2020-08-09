using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;
using TUChairVO;

namespace TUChair
{
    public partial class ProcessStockManager : TUChair.SearchCommomForm
    {
        List<PSMManager> list;

        public ProcessStockManager()
        {
            InitializeComponent();

            jeansGridView1.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "창고코드", "Fact_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "창고", "Fact_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목타입", "Item_Type", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "재고", "Qty", true,100,DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "단위", "Item_Unit", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "비고", "Stock_Other", true);
            DataLoad();
        }

        public void DataLoad()
        {
            JeanServicePShift service = new JeanServicePShift();
            list = service.PSMManager();



            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = list;
        }
    }
}
