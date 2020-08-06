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

namespace TUChair.WooForm
{
    public partial class IpGoCheck : Form
    {
        public IpGoCheck(string massaged)
        {
            InitializeComponent();
            massage = massaged;
        }
        private string massage;

        public string Massage
        {
            get { return massage; }
            set { textBox1.Text = value; }
        }


        private void IpGoCheck_Load(object sender, EventArgs e)
        {
            
        }
        private void Readed_BarCode(object sender, ReadEventArgs e)
        {
            textBox1.Text = e.ReadMsg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 4)
            {
                label1.Text = "";
                int barID = int.Parse(textBox1.Text.Trim().Replace("\r", "").Replace("\n", "").TrimStart('0'));

                ItemService service = new ItemService();

                service.IpGoUpdate(barID);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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
