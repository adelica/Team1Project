using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUChair
{
    public partial class waitFrm : Form
    {
        public Action Worker { get; set; }
        public waitFrm(Action worker)
        {
            InitializeComponent();
            Worker = worker;
        }

        private void waitFrm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
