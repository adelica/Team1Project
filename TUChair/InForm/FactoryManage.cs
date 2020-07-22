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

namespace TUChair.InForm
{
    public partial class FactoryManage : Form
    {
        public FactoryManage()
        {
            InitializeComponent();
        }

        private void FactoryManage_Load(object sender, EventArgs e)
        {
            CommonUtil.InitSettingGridView(dgvFactory);

            CommonUtil.DgvCheckBox(dgvFactory);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "no", "number", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설군", "Fact_Group", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설구분", "Fact_Class", true);
            CommonUtil.AddNewColumnToDataGridView(dgvFactory, "시설코드", "Fact_Code", true);
        }
      
    }
}