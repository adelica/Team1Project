using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Util;

namespace TUChair
{
    public partial class CompanyManage : TUChair.CommonForm.SearchCommomForm
    {
        public CompanyManage()
        {
            InitializeComponent();
        }

        private void CompanyManage_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void DataLoad()
        {
            CommonUtil.InitSettingGridView(dgvCompany);

            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "No.", "No", true, 50, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "업체코드", "Com_Code", true, 100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "업체명", "Com_Name", true,150);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "업체타입명", "Com_Type", true, 100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "대표자명", "Com_Owner", true);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "사업자등록번호", "??", true, 150, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "업종", "Com_Sector", true);
            //CommonUtil.AddNewColumnToDataGridView(dgvCompany, "업태", "??", true);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "담당자명", "Com_Manager", true);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "이메일", "Com_Email", true);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "전화번호", "Com_Phone", true);
           // CommonUtil.AddNewColumnToDataGridView(dgvCompany, "팩스", "??", true);
            //CommonUtil.AddNewColumnToDataGridView(dgvCompany, "출하자동입고유무", "??", true, 140, DataGridViewContentAlignment.MiddleCenter);
            //CommonUtil.AddNewColumnToDataGridView(dgvCompany, "출발유무", "??", true, 100, DataGridViewContentAlignment.MiddleCenter);
        }
    }
}
