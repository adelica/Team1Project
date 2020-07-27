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

namespace TUChair.MeilingForm
{
    public partial class ShiftStandardForm : TUChair.CommonForm.SearchCommomForm
    {
        public ShiftStandardForm()
        {
            InitializeComponent();
        }
        List<ShiftVO> list;
        List<string> shiftCbolist;
        private void ShiftStandardForm_Load(object sender, EventArgs e)
        {
            // 폼 로드시 전체 데이타 보여주기
            
            MeilingService service = new MeilingService();
            list = service.DBConnectionTEST();
            CommonUtil.InitSettingGridView(jeansGridView1);
           CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "ShiftID", "Shift_ID", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "설비명", "Fac_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "시작시간", "Shift_StartTime", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "종료시간", "Shift_EndTime", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "시작일", "Shift_StartDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "종료일", "Shift_EndDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "투입인원", "Shift_InputPeople", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "사용유무", "Shift_UserOrNot", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정자", "Shift_Modifier", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정일", "Shift_ModifierDate", true);

            jeansGridView1.DataSource = list;


            //콤보박스에 item넣기
            // 설비코드
            shiftCbolist = new List<string>();
            for (int i = 0; i < jeansGridView1.RowCount; i++)
            {
                shiftCbolist.Add(jeansGridView1.Rows[i].Cells[2].Value.ToString());
            };
            comboBox2.Items.AddRange(shiftCbolist.ToArray());
            // shiftID
            List<string> FaciCbolist = new List<string>();
            for (int i = 0; i < jeansGridView1.RowCount ; i++)
            {
                FaciCbolist.Add(jeansGridView1.Rows[i].Cells[1].Value.ToString());
            };
            cboShiftID.Items.AddRange(FaciCbolist.ToArray());



            //MessageBox.Show("ok");





        }
        // 설비 선택 콤보박스
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //설비콤보박스 값변화시 datagridview binding 할 list
            List<ShiftVO> list2 = (from item in list where item.Fac_Code == comboBox2.SelectedItem.ToString() select new ShiftVO { Shift_ID=item.Shift_ID,
                Fac_Code =item.Fac_Code,
                Shift_StartTime= item.Shift_StartTime,
                Shift_EndTime= item.Shift_EndTime,
                Shift_StartDate = item.Shift_StartDate,
                Shift_EndDate = item.Shift_EndDate,
                Shift_InputPeople = item.Shift_InputPeople,
                Shift_UserOrNot = item.Shift_UserOrNot,
                Shift_Modifier = item.Shift_Modifier,
                Shift_ModifierDate = item.Shift_ModifierDate
            }).ToList();

            jeansGridView1.DataSource = list2;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //shift id에 값 넣고 조회 클릭시 datagridview binding할 list
            if (cboShiftID.SelectedItem != null || comboBox2.SelectedItem != null)
            {
                List<ShiftVO> list2 = (from item in list
                                       where item.Fac_Code == comboBox2.SelectedItem.ToString() &&
                    item.Shift_ID.ToString() == cboShiftID.SelectedItem.ToString()
                                       select new ShiftVO
                                       {
                                           Shift_ID = item.Shift_ID,
                                           Fac_Code = item.Fac_Code,
                                           Shift_StartTime = item.Shift_StartTime,
                                           Shift_EndTime = item.Shift_EndTime,
                                           Shift_StartDate = item.Shift_StartDate,
                                           Shift_EndDate = item.Shift_EndDate,
                                           Shift_InputPeople = item.Shift_InputPeople,
                                           Shift_UserOrNot = item.Shift_UserOrNot,
                                           Shift_Modifier = item.Shift_Modifier,
                                           Shift_ModifierDate = item.Shift_ModifierDate
                                       }).ToList();
                jeansGridView1.DataSource = list2;
            }
            else
            {
                MessageBox.Show("검색 조건을 선택해 주세요");
            }
        }
        // shiftID 값 변할때 
        private void cboShiftID_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ShiftVO> list3 = (from item in list
                                   where item.Shift_ID.ToString() == cboShiftID.SelectedItem.ToString()
                                   select new ShiftVO
                                   {
                                       Shift_ID = item.Shift_ID,
                                       Fac_Code = item.Fac_Code,
                                       Shift_StartTime = item.Shift_StartTime,
                                       Shift_EndTime = item.Shift_EndTime,
                                       Shift_StartDate = item.Shift_StartDate,
                                       Shift_EndDate = item.Shift_EndDate,
                                       Shift_InputPeople = item.Shift_InputPeople,
                                       Shift_UserOrNot = item.Shift_UserOrNot,
                                       Shift_Modifier = item.Shift_Modifier,
                                       Shift_ModifierDate = item.Shift_ModifierDate
                                   }).ToList();

            jeansGridView1.DataSource = list3;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            ShiftPopUpForm shiftPop = new ShiftPopUpForm();
            shiftPop.Owner = this;
            shiftPop.sendlist = shiftCbolist;
            shiftPop.ShowDialog();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }
    }
}
