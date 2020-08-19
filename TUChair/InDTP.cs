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
            set { dtpStart.Value = value; }
        }
        public DateTime End
        {
            get { return dtpEnd.Value; }
            set { dtpEnd.Value= value; }
        }
        public DateTimePickerFormat startfomat
        {
            get { return dtpStart.Format; }
            set { dtpStart.Format= value; }
        }
        public DateTimePickerFormat endfomat
        {
            get { return dtpEnd.Format; }
            set {  dtpEnd.Format= value; }
        }
        public string startCustomfomat
        {
            get { return dtpStart.CustomFormat; }
            set {  dtpStart.CustomFormat= value ; }
        }
        public string endCustomfomat
        {
            get { return dtpEnd.CustomFormat; }
            set { dtpEnd.CustomFormat = value; }
        }
        public bool DateLimit
        {
            get { return check; }
            set { check=value; }
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
                if(dtpEnd.Value>dtpStart.Value.AddDays(60))
                     dtpStart.Value = dtpEnd.Value.AddDays(-60);
            }
        }
    }
}
