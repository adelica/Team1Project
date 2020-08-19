using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;

namespace TUChair
{
    public partial class RowMetrialDecountPopUp : TUChair.POPUP1Line
    {
        public string item { get; set; }
        public string outhouse { get; set; }
        public string inhouse { get; set; }
        public int planQTY { get; set; }
        public RowMetrialDecountPopUp()
        {
            InitializeComponent();
        }

        private void RowMetrialDecountPopUp_Load(object sender, EventArgs e)
        {
            txtitem.Text = item;
            txtplanQTY.Text =planQTY.ToString();

        }

        private void btnInsert_Click(object sender, EventArgs e)//저장
        {
            MeilingService service = new MeilingService();
           if(service.rowMetrailDecount(item, inhouse, outhouse, Convert.ToInt32(txtoutQTY.Text)))
            {
                MessageBox.Show("이동성공");
            }
            else
            {
                MessageBox.Show("이동실패");
            }
        }
    }
}
