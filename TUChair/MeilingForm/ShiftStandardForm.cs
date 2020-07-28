using JeanForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        List<string> FaciCbolist;
        Dictionary<String, String> updatedic;
        string upInsert;
        private void ShiftStandardForm_Load(object sender, EventArgs e)
        {
            // 폼 로드시 전체 데이타 보여주기

            MeilingService service = new MeilingService();
            list = service.DBConnectionTEST();
            jeansGridView1.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
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
            jeansGridView1.Columns["Shift_ID"].Frozen = true;
            jeansGridView1.DataSource = list;


            //콤보박스에 item넣기
            // 설비코드 FaciCbolist
            FaciCbolist = new List<string>();
            for (int i = 0; i < jeansGridView1.RowCount; i++)
            {
                FaciCbolist.Add(jeansGridView1.Rows[i].Cells[2].Value.ToString());
            };
            comboBox2.Items.AddRange(FaciCbolist.ToArray());
            // shiftID
            shiftCbolist = new List<string>();
            for (int i = 0; i < jeansGridView1.RowCount; i++)
            {
                shiftCbolist.Add(jeansGridView1.Rows[i].Cells[1].Value.ToString());
            };
            cboShiftID.Items.AddRange(shiftCbolist.ToArray());



            //MessageBox.Show("ok");







        }
        // 설비 선택 콤보박스
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //설비콤보박스 값변화시 datagridview binding 할 list
            List<ShiftVO> list2 = (from item in list
                                   where item.Fac_Code == comboBox2.SelectedItem.ToString()
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
            upInsert = "Insert";
            ShiftPopUpForm shiftPop = new ShiftPopUpForm();
            shiftPop.Owner = this;

            shiftPop.sendlist = FaciCbolist;
            shiftPop.sendshiftlist = shiftCbolist;
            shiftPop.uporInsert = upInsert;
            shiftPop.ShowDialog();
        }
        //엑셀 다운로드
        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save as Excel File";
            sfd.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";
            sfd.FileName = "";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                dataGridView_ExportToExcel(sfd.FileName, jeansGridView1);
            }

       
        }

        private void dataGridView_ExportToExcel(string fileName, JeansGridView jeansGridView1)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("엑셀이 설치되지 않았습니다");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbook wb = excelApp.Workbooks.Add(true);
            Microsoft.Office.Interop.Excel._Worksheet workSheet = wb.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel._Worksheet;
            workSheet.Name = "C#";

            if (jeansGridView1.Rows.Count == 0)
            {
                MessageBox.Show("출력할 데이터가 없습니다");
                return;
            }

            // 헤더 출력
            for (int i = 0; i < jeansGridView1.Columns.Count - 1; i++)
            {
                workSheet.Cells[1, i + 1] = jeansGridView1.Columns[i].HeaderText;
            }

            //내용 출력
            for (int r = 0; r < jeansGridView1.Rows.Count; r++)
            {
                for (int i = 0; i < jeansGridView1.Columns.Count - 1; i++)
                {
                    workSheet.Cells[r + 2, i + 1] = jeansGridView1.Rows[r].Cells[i].Value;
                }
            }



            workSheet.Columns.AutoFit(); // 글자 크기에 맞게 셀 크기를 자동으로 조절



      
        }

        //수정 버튼 클릭
        private void button1_Click(object sender, EventArgs e)
        {
            if (jeansGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("수정할 항목을 선택하여 주새요");
            }
            else
            {
                upInsert = "Update";
                ShiftPopUpForm shiftPop = new ShiftPopUpForm();
                shiftPop.Owner = this;
                shiftPop.uptdic = updatedic;
                shiftPop.uporInsert = upInsert;
                shiftPop.sendshiftlist = shiftCbolist;
                shiftPop.sendlist = FaciCbolist;
                shiftPop.ShowDialog();
            }
        }

        private void jeansGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                updatedic = new Dictionary<string, string>()
                {
                    { "ShiftID", jeansGridView1.SelectedRows[0].Cells[1].Value.ToString() },
                    { "설비명", jeansGridView1.SelectedRows[0].Cells[2].Value.ToString() },
                    { "시작시간", jeansGridView1.SelectedRows[0].Cells[3].Value.ToString() },
                    { "종료시간", jeansGridView1.SelectedRows[0].Cells[4].Value.ToString() },
                    { "시작일", jeansGridView1.SelectedRows[0].Cells[5].Value.ToString() },
                    { "종료일", jeansGridView1.SelectedRows[0].Cells[6].Value.ToString() }
                };
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
            if (jeansGridView1.SelectedRows[0].Cells[7].Value.ToString() == null)
            {
                updatedic.Add("투입인원", null);
            }
            else
            {
                updatedic.Add("투입인원", jeansGridView1.SelectedRows[0].Cells[7].Value.ToString());
            }
            if (jeansGridView1.SelectedRows[0].Cells[8].Value == null)
            {
                updatedic.Add("사용유무", null);
            }
            else
            {
                updatedic.Add("사용유무", jeansGridView1.SelectedRows[0].Cells[8].Value.ToString());
            }
            if (jeansGridView1.SelectedRows[0].Cells[9].Value == null)
            {
                updatedic.Add("수정자", null);
            }
            else
            {
                updatedic.Add("수정자", jeansGridView1.SelectedRows[0].Cells[9].Value.ToString());
            }
            if (jeansGridView1.SelectedRows[0].Cells[10].Value == null)
            {
                updatedic.Add("수정일", null);
            }
            else
            {
                updatedic.Add("수정일", jeansGridView1.SelectedRows[0].Cells[10].Value.ToString());
            }
            if (jeansGridView1.SelectedRows[0].Cells[11].Value == null)
            {
                updatedic.Add("비고", null);
            }
            else
            {
                updatedic.Add("비고", jeansGridView1.SelectedRows[0].Cells[11].Value.ToString());
            }
        }

    }
}
