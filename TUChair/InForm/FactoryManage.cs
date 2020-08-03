﻿using System;
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
        public FactoryManage()
        {
            InitializeComponent();

            CommonUtil.InitSettingGridView(dgvFactory);

            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "No.", "no.", true, 50, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설군", "Fact_Group", true, 70, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설구분", "Fact_Class", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설타입", "Fact_Type", true, 150);
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
            this.dgvFactory.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }


        private void FactoryManage_Load(object sender, EventArgs e)
        {
            LoadData();
            CboBinding();
        }

        private void LoadData() //전체데이터 바인딩
        {
            FactoryService service = new FactoryService();
            list = service.GetFactoryData();
            dgvFactory.DataSource = list;
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

        private void btnInsert_Click(object sender, EventArgs e) //임시 공장정보등록
        {
            FactoryInfoRegi frm = new FactoryInfoRegi(list);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.Check)
                LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
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

        private void txtFacName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSearch.PerformClick();
        }

        private void 수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = dgvFactory.CurrentRow;

            string facG_Code = row.Cells[1].Value.ToString();
            string fact_Class= row.Cells[2].Value.ToString();
            string fact_Code = row.Cells[4].Value.ToString();
            string fact_Name= row.Cells[5].Value.ToString();
            string fact_Parent= row.Cells[7].Value.ToString();
            string fact_Info = row.Cells[8].Value== null ? "" : row.Cells[8].Value.ToString();
            string UseOrNot= row.Cells[10].Value.ToString();

            FactoryInfoRegi frm = new FactoryInfoRegi(facG_Code, fact_Class, fact_Code, fact_Name, fact_Parent, fact_Info, UseOrNot,list);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if(frm.Check)
            {
                LoadData();
            }

        }

        private void dgvFactory_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 1 || e.RowIndex > dgvFactory.Rows.Count)
                return;
            if (e.Button == MouseButtons.Right)
            {
                dgvFactory.Rows[e.RowIndex].Selected = true;
                dgvFactory.CurrentCell = dgvFactory.Rows[e.RowIndex].Cells[0];
                contextMenuStrip1.Show(dgvFactory, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DialogResult.OK==(MessageBox.Show("정말로 삭제하시겠습니까?","삭제확인",MessageBoxButtons.OKCancel)))
            {
                var row = dgvFactory.CurrentRow;
                string fact_Code = row.Cells[4].Value.ToString();
                FactoryService service = new FactoryService();
                bool check= service.DeleteFactoryInfo(fact_Code);
                if (check)
                {
                    MessageBox.Show("삭제되었습니다.", "삭제완료");
                    LoadData();
                }
            }
            return;


        }
    }
}