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
    public partial class POPUserControl : UserControl
    {

        BackgroundWorker task;
      

        BackgroundWorker worker;
      
        private string woOderID;

        public string WoOderID
        {
            get { return txtWoID.Text; }
            set { txtWoID.Text = value; }
        }
        private string taskID;

        public string TaskID
        {
            get { return lblTaskID.Text; }
            set { lblTaskID.Text = value; }
        }
        private string faciCode;

        public string FaciCode
        {
            get { return lblFaciCode.Text; }
            set { lblFaciCode.Text = value; }
        }
        private string iP;

        public string IP
        {
            get { return lblIP.Text; }
            set { lblIP.Text = value; }
        }
        private string port;

        public string Port
        {
            get { return lblPort.Text; }
            set { lblPort.Text = value; }
        }
        private string item;

        public string Item
        {
            get { return lblItem.Text; }
            set { lblItem.Text = value; }
        }
        private string palnQTY;

        public string PlanQTY
        {
            get { return txtPlanQTY.Text; }
            set { txtPlanQTY.Text = value; }
        }
        private string proQTY;

        public string ProQTY
        {
            get { return txtProQTY.Text; }
            set { txtProQTY.Text = value; }
        }
        private string badQTY;

        public string BadQTY
        {
            get { return txtBadQTY.Text; }
            set { txtBadQTY.Text = value; }
        }
        public bool IsTaskEnable
        {
            get { return btnServerStop.Enabled; }
            set
            {
                if (value) //task 실행중
                {
                    btnServerStart.Enabled = false;
                    btnServerStop.Enabled = true;
                  
                }
                else
                {
                    btnServerStart.Enabled = true;
                    btnServerStop.Enabled = false;
                   
                }
            }
        }
        public bool IsTask
        {
            get { return btnclientStop.Enabled; }
            set
            {
                if (value)
                {
                    btnClientStart.Enabled = false;
                    btnclientStop.Enabled = true;
                    btnStatus.BackColor = Color.Green;
                }
                else
                {
                    btnClientStart.Enabled = true;
                    btnclientStop.Enabled = false;
                    btnStatus.BackColor = Color.Red;
                }
            }
        }
        public POPUserControl()
        {
            InitializeComponent();
        }

        private void btnServerStart_Click(object sender, EventArgs e)
        {
            try
            {
                task = new BackgroundWorker();
                task.RunWorkerCompleted += Task_RunWorkerCompleted;
                task.RunWorkerAsync();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Task_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
