using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Util;

namespace TUChair.InForm
{
    public partial class POManage : TUChair.CommonForm.SearchCommomForm
    {
        public POManage()
        {
            InitializeComponent();
            DataLoad();
        }

        private void DataLoad()
        {
            CommonUtil.InitSettingGridView(dgvPO);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "No.", "No", true,50);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "고객 WO", "So_WorkOrderID", true,150);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "고객주문번호", "So_PurchaseOrder", true,120);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "고객사코드", "Com_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "고객사명", "Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "도착지코드", "Com_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "도착지명", "Com_Name", true);
            //CommonUtil.AddNewColumnToDataGridView(dgvPO, "고객주문유형", "?", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "고객사라인", "?", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "생산납기일", "So_Duedate", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "주문수량", "So_Qty", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "출고수량", "So_ShipQty", true);
          
        }

        private void btnPOUpLoad_Click(object sender, EventArgs e) //영업마스터생성 팝엄
        {
            PORegi frm = new PORegi();
            frm.ShowDialog();
        }

        private void btnSORegi_Click(object sender, EventArgs e) //수요계획생성 팝업
        {
            SORegi frm = new SORegi();
            frm.ShowDialog();
        }
    }
}
