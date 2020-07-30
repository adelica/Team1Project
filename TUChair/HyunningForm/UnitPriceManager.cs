﻿using System;
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
    public partial class UnitPriceManager : TUChair.SearchCommomForm
    {
        List<UnitPriceVO> list;
        public UnitPriceManager()
        {
            InitializeComponent();
        }

        private void UnitPriceManager_Load(object sender, EventArgs e)
        {
            JeanService service = new JeanService();
            list = service.UPBinding();

            jeansGridView1.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "PriceNO", "PriceNO", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "업체고유번호", "Com_No", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "업체코드", "Com_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "업체명", "Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "단위", "Item_Unit", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "현재단가", "Price_Present", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "이전단가", "Price_transfer", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "시작일", "Price_StartDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "종료일", "Price_EndDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "사용유무", "Price_UserOrNot", true);

        }
    }
}
