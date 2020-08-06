using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;
using TUChairVO;

namespace TUChair
{
    public partial class ProcessShiftManager : TUChair.SearchCommomForm
    {
        List<ProcessShiftVO> list;
        List<ComboItemVO> comboItems = null;
        public ProcessShiftManager()
        {
            InitializeComponent();
            jeansGridView1.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "No.", "No", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "창고코드", "Fact_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "참고이름", "Fact_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "창고타입", "Fact_Type", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "이동일자", "Insert_Date", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수량", "Qty", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "단위", "Item_Unit", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "비고", "Stock_Ohter", true);
            
            DataLoad();

            commonService service = new commonService();
            comboItems = service.getCommonCode("창고@Item");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "창고"
                                       select item).ToList();
            CommonUtil.ComboBinding(cboFact, cList, "선택");
                               cList = (from item in comboItems
                                       where item.CodeType == "Item"
                                       select item).ToList();
            CommonUtil.ComboBinding(cboItemCode, cList, "선택");

        }
        public void DataLoad()
        {
            JeanServicePShift service = new JeanServicePShift();
            list = service.PSBinding();



            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = list;
        }
    }
}
