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
    public partial class ProductShipmentStatus : TUChair.SearchCommomForm
    {
        List<ProductSatus> list = new List<ProductSatus>();
        public ProductShipmentStatus()
        {
            InitializeComponent();

            jeansGridView1.IsAllCheckColumnHeader = true;
            CommonUtil.InitSettingGridView(jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "고객주문번호", "So_PurchaseOrder", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "고객사 명",    "Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "도착지 명",    "Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "고객사 품목",  "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목",        "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명",        "Item_name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "납기일",      "So_Duedate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "출하일자",    "So_OutDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "현재단가",    "Price", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "주문수량",    "So_Qty", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "총 출하 수량", "So_ProQty", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "출하처리자",   "Modifier", true);
            DataLoad();
        }

        public void DataLoad()
        {
            JeanServicePShift jsShift = new JeanServicePShift();
            list = jsShift.PSStatus();
            jeansGridView1.DataSource = list;
        }
    }
}