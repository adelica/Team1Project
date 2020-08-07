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

namespace TUChair
{
    public partial class UpdateWorkOrder : Form
    {
        public UpdateWorkOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox1.Text.Replace("[RECV] ", ""));
            int QTY1 = Convert.ToInt32(textBox2.Text);
            int QTY2 = Convert.ToInt32(textBox3.Text);
            MeilingService service = new MeilingService();
            service.insertworkOrder(QTY1, QTY2, ID);
            MessageBox.Show("작업지시 등록 성공");
        }

        private void UpdateWorkOrder_Load(object sender, EventArgs e)
        {
            ((TUChairMain2)this.MdiParent).Readed += Readed_BarCode;
        }

        private void Readed_BarCode(object sender, ReadEventArgs e)
        {
            if ((this.MdiParent).ActiveMdiChild == this)
                textBox1.Text = e.ReadMsg;
            ((TUChairMain2)this.MdiParent).Clearstrings();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 4)
            {
                button1.PerformClick();
            }
        }
    }
}
