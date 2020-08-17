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
    public partial class SalesClosing : TUChair.SearchCommomForm
    {
        List<ProductClosingVO> list = new List<ProductClosingVO>();
        public SalesClosing()
        {
            InitializeComponent();
            
          
            jeansGridView1.IsAllCheckColumnHeader = true;
            CommonUtil.InitSettingGridView(jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "고객주문번호", "So_PurchaseOrder", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "고객사 명", "Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "도착지 명", "d_Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "고객사 품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "d_Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "Item_name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "주문수량", "So_Qty", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "출하수량", "So_ProQty", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "현재단가", "Price", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "매출확정금액", "total", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "마감처리자", "Modifier", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "납기일자", "So_Duedate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "마감일자", "So_OutDate", true);
            DataLoad();
        }
        private void btnPclosing_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < jeansGridView1.Rows.Count; i++)
            {

                bool isCellChecked = (bool)jeansGridView1.Rows[i].Cells[0].EditedFormattedValue;
                if (isCellChecked)
                {
                    string Primary = jeansGridView1.Rows[i].Cells[1].Value.ToString();
                    string Item = jeansGridView1.Rows[i].Cells[9].Value.ToString();
                    string Modifier = LoginFrm.userName;

                    JeanServicePShift shift = new JeanServicePShift();
                    shift.PCDeadline(Primary, Item, Modifier);
                    if (Convert.ToInt32(jeansGridView1.Rows[i].Cells[14].Value) == 0)
                    {
                        MessageBox.Show("출하 수량을 입력해주세요.");
                        return;
                    }
                }
            }
        }

        private void SalesClosing_Load(object sender, EventArgs e)
        {
            
        }
        public void DataLoad()
        {
            JeanServicePShift jeans = new JeanServicePShift();
            list = jeans.PClosing();
            jeansGridView1.DataSource = list;
        }

        
    }
}
