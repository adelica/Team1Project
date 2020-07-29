using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Util;

namespace TUChair
{
    public partial class UnitPriceManager : TUChair.SearchCommomForm
    {
        public UnitPriceManager()
        {
            InitializeComponent();
        }

        private void UnitPriceManager_Load(object sender, EventArgs e)
        {



            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "PriceNO", "PriceNO", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "Com_No", "Com_No", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "시작시간", "Com_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "종료시간", "Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "시작일", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "종료일", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "투입인원", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "사용유무", "Item_Unit", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정자", "Price_Present", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정일", "Price_transfer", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정일", "Price_StartDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정일", "Price_EndDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정일", "Price_UserOrNot", true);


        }
    }
}
