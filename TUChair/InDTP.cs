using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUChair
{
    public partial class InDTP : UserControl
    {
        public InDTP()
        {
            InitializeComponent();          
        }
        
        public DateTime Start
        {
            get { return dtpStart.Value; }
            set { value = dtpStart.Value; }
        }
        public DateTime End
        {
            get { return dtpEnd.Value; }
            set { value = dtpEnd.Value; }
        }

        public void StartDateCheck(object sender, EventArgs e)
        {
            dtpStart.MaxDate = dtpEnd.Value;
            dtpEnd.MinDate = dtpStart.Value;
        }

    }
}
