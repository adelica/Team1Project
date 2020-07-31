using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChair.Util;

namespace TUChair
{
    public partial class FacilityManage : Form
    {
        public FacilityManage()
        {
            InitializeComponent();
        }

        private void FacilityManage_Load(object sender, EventArgs e)
        {
            CommonUtil.InitSettingGridView(dgvFacilityG);
            CommonUtil.InitSettingGridView(dgvFacility);

            CommonUtil.AddNewColumnToDataGridView(dgvFacilityG, "설비군 코드", "FacG_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFacilityG, "설비군 명", "FacG_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFacilityG, "사용유무", "FacG_UseOrNot", true,80);


            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "No.", "no", true,50);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "설비코드", "Faci_Code", true,150);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "설비명", "Faci_Name", true,150);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "소진창고", "Faci_OutWareHouse", true,120);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "양품창고", "Faci_InWareHouse", true,120);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "불량창고", "Faci_BadWareHouse", true,120);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "특이사항", "Faci_Detail", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "비고", "Faci_Others", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "사용유무", "Faci_UseOrNot", true,80);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "수정자", "Faci_Modifier", true,80);
            CommonUtil.AddNewColumnToDataGridView(dgvFacility, "수정시간", "Faci_ModifyDate", true,150);
        }

        private void btnFGInsert_Click(object sender, EventArgs e)
        {
            FacilityGroupInfoRegi frm = new FacilityGroupInfoRegi();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();        
        }

        private void btnFInsert_Click(object sender, EventArgs e)
        {
            FacilityInfoRegi frm = new FacilityInfoRegi();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}
