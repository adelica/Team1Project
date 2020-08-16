using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TUChair.MeilingForm
{
    public partial class MetrialDecountPopUp : TUChair.POPUP1Line
    {
        public int WOId { get; set; }
        public string ItemCode { get; set; }
        public string facicode { get; set; }
        public MetrialDecountPopUp()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
