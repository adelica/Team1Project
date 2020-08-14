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

namespace TUChair
{
    public partial class ShiftStandardForm : TUChair.SearchCommomForm
    {
        public ShiftStandardForm()
        {
            InitializeComponent();
        }


        List<ShiftVO> list;
        Dictionary<String, String> updatedic;
        string upInsert;
        List<string> FaciNameList;
        private void ShiftStandardForm_Load(object sender, EventArgs e)
        {

            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
            // 폼 로드시 전체 데이타 보여주기



            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            AllBinding();
            DataBinding();
            ComboBinding();
            DataBinding();

            //콤보박스에 item넣기
            // 설비코드 FaciCbolist
            // ComboBinding();



            //MessageBox.Show("ok");
        }

        private void AllBinding()
        {
            jeansGridView1.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "ShitID", "Shift_ID", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "설비코드", "Faci_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "설비명", "Faci_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "시작일", "Shift_StartDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "종료일", "Shift_EndDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "시작시간", "Shift_StartTime", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "종료시간", "Shift_EndTime", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "투입인원", "Shift_InputPeople", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "사용유무", "Shift_UserOrNot", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정자", "Shift_Modifier", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정일", "Shift_ModifierDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "기타", "Shift_Others", true);
            jeansGridView1.Columns["Faci_Code"].Frozen = true;
        }

        private void DataBinding()
        {
            MeilingService service = new MeilingService();
            list = service.DBConnectionTEST();
            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = list;
        }

        private void ComboBinding()
        {
            List<string> FaciCodeList = new List<string>();
            FaciCodeList.Insert(0,"");
            for (int i = 0; i < jeansGridView1.RowCount; i++)
            {
                FaciCodeList.Add(jeansGridView1.Rows[i].Cells[2].Value.ToString());

            };
            FaciCodeList = FaciCodeList.Distinct().ToList();
            FaciNameList = new List<string>();
            FaciNameList.Insert(0, "선택");
            for (int i = 0; i < jeansGridView1.RowCount; i++)
            {
                FaciNameList.Add(jeansGridView1.Rows[i].Cells[3].Value.ToString());

            };
            FaciNameList = FaciNameList.Distinct().ToList();
            Dictionary<string, string> ComboDic = new Dictionary<string, string>();
            // ComboDic.Add("선택", "선택");
            ComboDic = FaciNameList.Zip(FaciCodeList, (k, v) => new { k, v }).ToDictionary(a => a.k, a => a.v);
            comboBox2.Items.Clear();
            comboBox2.DataSource =new BindingSource(ComboDic,null);
            comboBox2.DisplayMember = "key";
            comboBox2.ValueMember = "value";
            //comboBox2.SelectedIndex = 0;
           // comboBox2.Items.AddRange(FaciNameList.ToArray());
        }

      

        private void Excel(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                using (waitFrm frm = new waitFrm(ExportOrderList))
                {
                    frm.ShowDialog(this);
                }
            }
        }
        private void ExportOrderList()
        {
            string sResult = ExcelExportImport.ExportToDataGridView<ShiftVO>(
                (List<ShiftVO>)jeansGridView1.DataSource, "");
            if (sResult.Length > 0)
            {
                MessageBox.Show(sResult);
            }
        }

        private void New(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                DataBinding();
                comboBox2.SelectedIndex = 0;
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                List<string> sb = new List<string>();
                jeansGridView1.EndEdit();
                for (int i = 0; i < jeansGridView1.RowCount; i++)
                {
                    bool isn = Convert.ToBoolean(jeansGridView1.Rows[i].Cells["chk"].Value);
                    if (isn)
                    {
                        sb.Add(jeansGridView1.Rows[i].Cells[1].Value.ToString());
                    }
                }
                if (sb.Count < 1)
                {
                    MessageBox.Show("삭제할 항목을 선택해주세요");
                    return;
                }
                string condition = string.Join("@", sb);
                MeilingService service = new MeilingService();
                if (service.DeleteShift(condition))
                {
                    MessageBox.Show("삭제되었습니다.");
                }
                else
                    MessageBox.Show("삭제에 실패하였습니다.");
                DataBinding();
            }
        }

        private void Search(object sender, EventArgs e)
        {
            //MessageBox.Show("조회클릭");
            //shift id에 값 넣고 조회 클릭시 datagridview binding할 list
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this) { 
                if (comboBox2.SelectedIndex != 0)
                {
                    List<ShiftVO> list2 = (from item in list
                                           where item.Faci_Code == comboBox2.SelectedValue.ToString()
                                           select new ShiftVO
                                           {   Shift_ID = item.Shift_ID,
                                               Faci_Code = item.Faci_Code,
                                               Faci_Name = item.Faci_Code,
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
        }

        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {

                int cnt=0;
                int row=0;
                jeansGridView1.EndEdit();
                for (int i = 0; i < jeansGridView1.Rows.Count; i++)
                {
                    bool isbool = Convert.ToBoolean(jeansGridView1.Rows[i].Cells["chk"].Value);
                    if (isbool)
                    { cnt++; row = i; }
                }
                string userID = ((TUChairMain2)this.MdiParent).userInfoVO.CUser_ID;
                if (cnt == 0)
                {
                    upInsert = "Insert";
                    ShiftPopUpForm frm = new ShiftPopUpForm();
                    frm.Owner = this;
                    //shiftPop.uptdic = updatedic;
                    frm.uporInsert = upInsert;

                    frm.faciNameList = FaciNameList;
                    // shiftPop.sendshiftlist = shiftCbolist;
                    // shiftPop.sendlist = FaciCodeList;
                    frm.ShowDialog();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        DataBinding();
                    }
                }
                else if (cnt > 1)
                {
                    MessageBox.Show("수정은 하나씩만 가능합니다.");
                    return;
                }
                else
                {
                    upInsert = "Update";
                   
                    ShiftVO shifti = new ShiftVO();
                    shifti.Shift_ID = jeansGridView1.Rows[row].Cells[1].Value.ToString();
                    shifti.Faci_Code = jeansGridView1.Rows[row].Cells[2].Value.ToString();
                    shifti.Faci_Name = jeansGridView1.Rows[row].Cells[3].Value.ToString();                   
                    shifti.Shift_StartDate = Convert.ToDateTime(jeansGridView1.Rows[row].Cells[4].Value);
                    shifti.Shift_EndDate =Convert.ToDateTime(jeansGridView1.Rows[row].Cells[5].Value);
                    shifti.Shift_StartTime = jeansGridView1.Rows[row].Cells[6].Value.ToString();
                    shifti.Shift_EndTime = jeansGridView1.Rows[row].Cells[7].Value.ToString();
                    shifti.Shift_InputPeople =(jeansGridView1.Rows[row].Cells[8].Value == null) ? 0 : Convert.ToInt32(jeansGridView1.Rows[row].Cells[8].Value);
                    shifti.Shift_UserOrNot = (jeansGridView1.Rows[row].Cells[9].Value == null) ? "" : jeansGridView1.Rows[row].Cells[9].Value.ToString();
                    shifti.Shift_Modifier = (jeansGridView1.Rows[row].Cells[10].Value == null) ? "": jeansGridView1.Rows[row].Cells[10].Value.ToString();
                    
                    if (jeansGridView1.Rows[row].Cells[11].Value != null)
                        shifti.Shift_ModifierDate =  Convert.ToDateTime(jeansGridView1.Rows[row].Cells[11].Value);

                    shifti.Shift_Others = (jeansGridView1.Rows[row].Cells[12].Value == null) ? "" : jeansGridView1.Rows[row].Cells[12].Value.ToString();
                    ShiftPopUpForm shiftPop = new ShiftPopUpForm();
                    shiftPop.Owner = this;
                    //shiftPop.uptdic = updatedic;
                    shiftPop.uporInsert = upInsert;
                    shiftPop.Shift = shifti;
                    shiftPop.faciNameList = FaciNameList;
                    // shiftPop.sendshiftlist = shiftCbolist;
                    // shiftPop.sendlist = FaciCodeList;
                    shiftPop.ShowDialog();
                }
            }
        }

       
          
       
    

        // 설비 선택 콤보박스
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //설비콤보박스 값변화시 datagridview binding 할 list
            //List<ShiftVO> list2 = (from item in list
            //                       where item.Faci_Code == comboBox2.SelectedItem.ToString()
            //                       select new ShiftVO
            //                       {
            //                           Shift_ID = item.Shift_ID,
            //                           Faci_Code = item.Faci_Code,
            //                           Shift_StartTime = item.Shift_StartTime,
            //                           Shift_EndTime = item.Shift_EndTime,
            //                           Shift_StartDate = item.Shift_StartDate,
            //                           Shift_EndDate = item.Shift_EndDate,
            //                           Shift_InputPeople = item.Shift_InputPeople,
            //                           Shift_UserOrNot = item.Shift_UserOrNot,
            //                           Shift_Modifier = item.Shift_Modifier,
            //                           Shift_ModifierDate = item.Shift_ModifierDate
            //                       }).ToList();
            //jeansGridView1.DataSource = list2;
        }     
        // shiftID 값 변할때 
        // 등록버튼 
        private void btnInsert_Click(object sender, EventArgs e)
        {
            upInsert = "Insert";
            ShiftPopUpForm shiftPop = new ShiftPopUpForm();
            shiftPop.Owner = this;

           // shiftPop.sendlist = FaciCbolist;
            //shiftPop.sendshiftlist = shiftCbolist;
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
                 //shiftPop.FaciNameList = faciNameList;
                // shiftPop.sendlist = FaciCbolist;
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
            //if (jeansGridView1.SelectedRows[0].Cells[11].Value == null)
            //{
            //    updatedic.Add("비고", null);
            //}
            //else
            //{
            //    updatedic.Add("비고", jeansGridView1.SelectedRows[0].Cells[11].Value.ToString());
            //}
        }

        private void ShiftStandardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
           frm.Save -= Save;
            frm.Search -= Search;
           frm.Delete -= Delete;
            frm.New -= New;
            frm.Excel -= Excel;
        }
    }
}
