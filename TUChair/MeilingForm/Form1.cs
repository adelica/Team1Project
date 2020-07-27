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
using TUChairVO;

namespace TUChair.MeilingForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            List<TestVO> list = null;
            ServiceHelp service = new ServiceHelp("");
            list = await service.GetListAsync("api/TUChair/GetAllUser", list);
            CommonUtil.InitSettingGridView(dataGridView1);

           // CommonUtil.DataGridViewCheckBoxSet("", dataGridView1);
            CommonUtil.AddNewColumnToDataGridView(dataGridView1, "a", "a", true);
            CommonUtil.AddNewColumnToDataGridView(dataGridView1, "b", "b", true);
            CommonUtil.AddNewColumnToDataGridView(dataGridView1, "c", "c", true);
            CommonUtil.AddNewColumnToDataGridView(dataGridView1, "d", "d", true);
            CommonUtil.AddNewColumnToDataGridView(dataGridView1, "e", "e", true);
            CommonUtil.AddNewColumnToDataGridView(dataGridView1, "f", "f", true);
            CommonUtil.AddNewColumnToDataGridView(dataGridView1, "g", "g", true);
            CommonUtil.AddNewColumnToDataGridView(dataGridView1, "h", "h", true);
            CommonUtil.AddNewColumnToDataGridView(dataGridView1, "i", "i", true);
            CommonUtil.AddNewColumnToDataGridView(dataGridView1, "j", "j", true);
            CommonUtil.AddNewColumnToDataGridView(dataGridView1, "k", "k", true);

            dataGridView1.DataSource = list;
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

        }
    }
}
