using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChairVO;

namespace TUChair.MeilingForm
{
    public partial class Form1 : TUChair.CommonForm.SearchCommomForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MeilingService service = new MeilingService();
           List< ShiftVO > list =  service.DBConnectionTEST();
            jeansGridView1.DataSource = list;
        }
    }
}
