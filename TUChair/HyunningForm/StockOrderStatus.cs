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

namespace TUChair.HyunningForm
{
    public partial class StockOrderStatus : TUChair.SearchCommomForm
    {
        List<CProductOutVO> list;
        public StockOrderStatus()
        {
            InitializeComponent();
            jeansGridView1.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목.", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "납기일", "So_Duedate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "잔여수량", "N_Qty", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "From창고", "Fact_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "From창고재고", "Qty", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "To창고", "ToFact", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "이동수량", "Out_Unit", true);

            DataLoad();
        }
        private void DataLoad()
        {
            JeanProductOut jean = new JeanProductOut();
            list = jean.CProductBinding();
            jeansGridView1.DataSource = list;
        }

        private void StockOrderStatus_Load(object sender, EventArgs e)
        {

        }
    }
}
