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
            dataGridView1.DataSource = await service.GetListAsync("api/TUChair/GetAllUser", list);
        }
    }
}
