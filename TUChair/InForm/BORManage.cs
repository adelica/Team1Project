using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Util;

namespace TUChair.InForm
{
    public partial class BORManage : TUChair.CommonForm.SearchCommomForm
    {
        public BORManage()
        {
            InitializeComponent();
        }

        private void BORManage_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void DataLoad()
        {
            CommonUtil.InitSettingGridView(dgvBOR);


            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "No.", "No", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "품명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "공정", "FacG_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "공정명", "FacG_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "설비", "Faci_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "설비명", "Faci_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "Tact Time(Sec)", "BOR_TactTime", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "우선순위", "BOR_Priority", true);
            //CommonUtil.AddNewColumnToDataGridView(dgvBOR, "공정선행일(Day)", "??", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "수율", "BOR_Yeild", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "사용유무", "BOR_UseOrNot", true);
            CommonUtil.AddNewColumnToDataGridView(dgvBOR, "비고", "BOR_Other", true);

        }
    }
}
