using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TUChair
{
    public partial class InDTP : UserControl
    {
        public InDTP()
        {
            InitializeComponent();
        }
        bool check = false;
        public DateTime Start
        {
            get { return dtpStart.Value; }
            set { value=dtpStart.Value; }
        }
        public DateTime End
        {
            get { return dtpEnd.Value; }
            set { value=dtpEnd.Value ; }
        }

        public bool DateLimit
        {
            get { return check; }
            set { value=check; }
        }

        public void DateLimitCheck(object sender, EventArgs e)
        {
            if (!check)
            {
                dtpStart.MaxDate = dtpEnd.Value;
                dtpEnd.MinDate = dtpStart.Value;
            }
        }
        public void EndLimitCheck(object sender, EventArgs e)
        {

            if(check)
            {
                if (dtpEnd.MaxDate > dtpEnd.MinDate && dtpEnd.MaxDate > dtpStart.Value)
                {
                    dtpEnd.MinDate = dtpStart.Value;
                    dtpEnd.MaxDate = dtpStart.Value.AddDays(60);
                }
                else if (dtpEnd.MaxDate > dtpEnd.MinDate)
                {
                    dtpEnd.MaxDate = dtpStart.Value.AddDays(60);
                    dtpEnd.MinDate = dtpStart.Value;
                }
            }

        }
        public void StartLimitCheck(object sender, EventArgs e)
        {
            if (check)
            {                
               dtpEnd.MinDate = dtpStart.Value;
              dtpStart.Value = dtpEnd.Value.AddDays(-60);
            }
        }
    }
}
