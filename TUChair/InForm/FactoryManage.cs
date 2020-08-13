using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;
using TUChairVO;

namespace TUChair
{
    public partial class FactoryManage : Form
    {
        List<FactoryVO> list;
        TUChairMain2 frm = new TUChairMain2();
        public FactoryManage()
        {
            InitializeComponent();


            CommonUtil.InitSettingGridView(dgvFactory);
            dgvFactory.IsAllCheckColumnHeader = true;

            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "No.", "no.", true, 50, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설군", "Fact_Group", true, 70, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설구분", "Fact_Class", true, 100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설타입", "Fact_Type", true, 150, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설코드", "Fact_Code", true, 230);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설명", "Fact_Name", true, 150);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설명", "Fact_BOM", true, 150);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "상위시설", "Fact_Parent", true, 150);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설설명", "Fact_Information", true, 200);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "자재차감", "Fact_MatDeducation", true, 100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "사용유무", "Fact_UseOrNot", true, 100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "수정자", "Fact_Modifier", true, 100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "수정시간", "Fact_ModifyDate", true, 150, DataGridViewContentAlignment.MiddleCenter);
        }
        private void dgvFactory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // 원하는 칼럼에 자동 번호 매기기
            this.dgvFactory.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }


        private void LoadData() //전체데이터 바인딩
        {
            FactoryService service = new FactoryService();
            list = service.GetFactoryData();
            dgvFactory.DataSource = list;
            txtFacName.Text = "";
            if(cboFacGroup.Items.Count>0)
                 cboFacGroup.SelectedIndex = 0;
        }

        private void CboBinding() //콤보박스 바인딩용
        {
            List<string> cList = null;
            cList = (from cbo in list
                     select cbo.Fact_Group).Distinct().ToList();
            cboFacGroup.Items.Add("전체");
            foreach (var cbo in cList)
            {
                cboFacGroup.Items.Add(cbo);
            }
            cboFacGroup.SelectedIndex = 0;
        }
        //새로고침
        private void LoadD(object sender, EventArgs e)
        {
            LoadData();
        }
        //검색
        private void Search(object sender, EventArgs e)
        {
            List<FactoryVO> groupList = null;
            if (cboFacGroup.SelectedItem.ToString() == "전체" && txtFacName.Text.Trim().Length < 1)
            {
                groupList = (from gList in list
                             select gList).ToList();
                dgvFactory.DataSource = groupList;
            }

            else if (cboFacGroup.SelectedItem.ToString() == "전체" && txtFacName.Text.Trim().Length > 0)
            {
                groupList = (from gList in list
                             where gList.Fact_Name.ToUpper().Contains(txtFacName.Text.ToUpper()) || gList.Fact_Code.Contains(txtFacName.Text.ToUpper())
                             select gList).ToList();
                dgvFactory.DataSource = groupList;
            }
            else
            {
                groupList = (from gList in list
                             where (gList.Fact_Group == cboFacGroup.SelectedItem.ToString()) && (((gList.Fact_Name.ToUpper().Contains(txtFacName.Text.ToUpper()))) || (gList.Fact_Code.ToUpper().Contains(txtFacName.Text.ToUpper())))
                             select gList).ToList();
                dgvFactory.DataSource = groupList;
            }

            if (groupList.Count < 1)
            { MessageBox.Show("검색한 데이터가 존재하지않습니다.", "검색실패"); }
        }
        //등록, 수정
        private void Save(object sender, EventArgs e)
        {
            List<string> codeList = (from code in list
                                     select code.Fact_Code).ToList();

            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                List<string> chkList = Check();
                bool check = false;
                if (chkList.Count == 1) // 수정
                {
                    var row = dgvFactory.CurrentRow;

                    string facG_Code = row.Cells[2].Value.ToString();
                    string fact_Class = row.Cells[3].Value.ToString();
                    string fact_Code = row.Cells[5].Value.ToString();
                    string fact_Name = row.Cells[6].Value.ToString();
                    string fact_Parent = row.Cells[8].Value.ToString();
                    string fact_Info = row.Cells[9].Value == null ? "" : row.Cells[9].Value.ToString();
                    string UseOrNot = row.Cells[11].Value.ToString();

                    FactoryInfoRegi frm = new FactoryInfoRegi(facG_Code, fact_Class, fact_Code, fact_Name, fact_Parent, fact_Info, UseOrNot, list);

                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    check = frm.Check;
                }

                else if (chkList.Count == 0) // 신규
                {
                    FactoryInfoRegi frm = new FactoryInfoRegi(list);
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    check = frm.Check;
                }
                else //2개 이상 선택
                {
                    MessageBox.Show("수정할 데이터 하나만 선택해주세요", "수정실패");
                    return;
                }
                if (check)
                    LoadData();
            }
        }

        #region
        //private void dgvFactory_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.RowIndex < 1 || e.RowIndex > dgvFactory.Rows.Count)
        //        return;
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        dgvFactory.Rows[e.RowIndex].Selected = true;
        //        dgvFactory.CurrentCell = dgvFactory.Rows[e.RowIndex].Cells[1];
        //        contextMenuStrip1.Show(dgvFactory, e.Location);
        //        contextMenuStrip1.Show(Cursor.Position);
        //    }
        //}

        //private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if(DialogResult.OK==(MessageBox.Show("정말로 삭제하시겠습니까?","삭제확인",MessageBoxButtons.OKCancel)))
        //    {
        //        var row = dgvFactory.CurrentRow;
        //        string fact_Code = row.Cells[5].Value.ToString();

        //        List<string> parentCheck = null;
        //        parentCheck = (from pCheck in list
        //                       where pCheck.Fact_Parent == fact_Code
        //                       select pCheck.Fact_Code).Distinct().ToList();

        //        if (parentCheck.Count > 0)
        //        {
        //            MessageBox.Show("하위시설군이 존재합니다.", "삭제실패");
        //            return;
        //        }
        //        else
        //        {
        //            FactoryService service = new FactoryService();
        //            bool check = service.DeleteFactoryInfo(fact_Code);
        //            if (check)
        //            {
        //                MessageBox.Show("삭제되었습니다.", "삭제완료");
        //                LoadData();
        //            }
        //        }
        //    }
        //    return;

        //}
        //------------
        #endregion

        //삭제
        private void Delete(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                List<string> chkList = Check();
                if (chkList.Count == 0)
                {
                    MessageBox.Show("삭제할 데이터를 클릭해주세요.");
                    return;
                }

                if (DialogResult.OK == (MessageBox.Show("정말로 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.OKCancel)))
                {
                    string code = "'" + string.Join("','", chkList) + "'";

                    FactoryService service = new FactoryService();
                    if (service.DeleteFactoryInfo(code))
                    {
                        MessageBox.Show($"{code}이/가 삭제되었습니다.", "삭제완료");
                        LoadData();
                    }

                }
                else
                    return;
            }
        }
        //폼 종료시 이벤트 제거
        private void FactoryManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.Save -= Save;
            frm.Search -= Search;
            frm.Delete -= Delete;
            frm.New -= LoadD;
        }

        //체크박스 체크확인
        private List<String> Check()
        {
            List<string> chkList = new List<string>();

            for (int i = 0; i < dgvFactory.Rows.Count; i++)
            {
                bool IsCellChecked = (bool)dgvFactory.Rows[i].Cells[0].EditedFormattedValue;
                if (IsCellChecked)
                {
                    chkList.Add(dgvFactory.Rows[i].Cells[5].Value.ToString());
                }
            }
            return chkList;
        }


        private void FactoryManage_Load(object sender, EventArgs e)
        {
            frm = (TUChairMain2)this.MdiParent;

            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += LoadD;

            LoadData();
            CboBinding();
        }
    }
}