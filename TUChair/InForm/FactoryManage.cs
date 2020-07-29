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
        List<FactoryVO> list = null;
        public FactoryManage()
        {
            InitializeComponent();

            CommonUtil.InitSettingGridView(dgvFactory);


            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "no", "Fact_No", true,60);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설군", "Fact_Group", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설구분", "Fact_Class", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설타입", "Fact_Type", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설코드", "Fact_Code", true,200);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설명", "Fact_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설명", "Fact_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "상위시설", "Fact_Parent", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설설명", "Fact_Information", true,200);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "자재차감", "Fact_MatDeducation", true, 200);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "사용유무", "Fact_UseOrNot", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "수정자", "Fact_Modifier", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "수정시간", "Fact_ModifyDate", true);
        }

        private void FactoryManage_Load(object sender, EventArgs e)
        {
            DataLoad();
        }
        
        private void DataLoad()
        {
            InService service = new InService();
            list = service.FactoryInfo();
            dgvFactory.DataSource = list;
        }
    }
}