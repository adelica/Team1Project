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

namespace TUChair.InForm
{
    public partial class FactoryManage : Form
    {
        List<FactoryVO> list;
        public FactoryManage()
        {
            InitializeComponent();

            CommonUtil.InitSettingGridView(dgvFactory);

            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "No.", "no.", true, 50, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설군", "Fact_Group", true,70,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설구분", "Fact_Class", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설타입", "Fact_Type", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설코드", "Fact_Code", true,200);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설명", "Fact_Name", true,150);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설명", "Fact_BOM", true,150);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "상위시설", "Fact_Parent", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설설명", "Fact_Information", true,200);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "자재차감", "Fact_MatDeducation", true,100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "사용유무", "Fact_UseOrNot", true,100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "수정자", "Fact_Modifier", true,100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "수정시간", "Fact_ModifyDate", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "no", "Fact_No", false, 60);
        }
        private void dgvFactory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // 원하는 칼럼에 자동 번호 매기기
            this.dgvFactory.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }


        private void FactoryManage_Load(object sender, EventArgs e)
        {
            DataLoad();
            CboBinding();
        }
        
        private void DataLoad() //전체데이터 바인딩
        {
            InService service = new InService();
            list = service.FactoryInfo();
            dgvFactory.DataSource = list;
        }

        private void CboBinding() //콤보박스 바인딩용
        {
            List<string> cboList =null;
            cboList = (from cbo in list
                       select cbo.Fact_Group).Distinct().ToList();
            cboFacGroup.Items.Add("전체");
            foreach(var cbo in cboList)
            {
                cboFacGroup.Items.Add(cbo);
            }
            cboFacGroup.SelectedIndex = 0; 
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            FactoryInfoRegi frm = new FactoryInfoRegi();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<FactoryVO> groupList = null;
            if (cboFacGroup.SelectedItem.ToString() == "전체" && txtFacName.Text.Trim().Length < 1)
                dgvFactory.DataSource = list;

            else if (cboFacGroup.SelectedItem.ToString() == "전체" && txtFacName.Text.Trim().Length > 0)
            {
                groupList = (from gList in list
                             where gList.Fact_Name.Contains(txtFacName.Text) || gList.Fact_Code.Contains(txtFacName.Text)
                             select gList).ToList();
                dgvFactory.DataSource = groupList;
            }
            else
            {
                groupList = (from gList in list
                             where (gList.Fact_Group == cboFacGroup.SelectedItem.ToString()) && ((gList.Fact_Name.Contains(txtFacName.Text)) || (gList.Fact_Code.Contains(txtFacName.Text)))
                             select gList).ToList();
                dgvFactory.DataSource = groupList;
            }
        }
    }
}