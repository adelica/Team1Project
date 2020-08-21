using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using TUChairDAC;

namespace TUChair
{
    public partial class POPUserControl : UserControl
    {
        BackgroundWorker task;
        int task_proc_id;

        BackgroundWorker worker;
        frmATLTask frm;
     
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
                   // btnServerStart.Enabled = false;
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
                   // btnClientStart.Enabled = false;
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
            IsTask = false;
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
            string path = $"WinServerTask{TaskID.Replace("task", "")}.exe";

            try
            {
                Process proc = Process.Start(path, $"{TaskID} {IP} {Port}"); // 던질 파라미터
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                task_proc_id = proc.Id;
                IsTask = true;
            }
            catch (Exception err)
            {
                foreach (var process in Process.GetProcesses())
                {
                    if (process.ProcessName == path)
                        process.Kill();
                }
                MessageBox.Show(err.Message);
            }
        }

        private void btnServerStop_Click(object sender, EventArgs e)
        {
            string path = $"WinServerTask{TaskID.Replace("task", "")}";
            foreach (var process in Process.GetProcesses())
            {
                if (process.Id == task_proc_id)
                {
                    process.Kill();
                    IsTask = false;
                }
            }
        }

        private void btnClientStart_Click(object sender, EventArgs e)
        {
            try
            {
                worker = new BackgroundWorker();
                worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
                worker.RunWorkerAsync();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            frm = new frmATLTask(TaskID, IP, Port);
            frm.Show();
            IsTaskEnable = true;
            frm.Hide();
            frm.ReadData += ReadDataDisplay;       
        }

        private void ReadDataDisplay(object sender, ReadDataEventAgrs e)
        {
            string[] datas = e.Data.Split('|');

            if (datas.Length < 5)
                return;

            txtProQTY.Text = (int.Parse(txtProQTY.Text == "" ? "0" : txtProQTY.Text) + int.Parse(datas[3])).ToString();
            txtBadQTY.Text = (int.Parse(txtBadQTY.Text == "" ? "0" : txtBadQTY.Text) + int.Parse(datas[4])).ToString();
        }

        private void btnclientStop_Click(object sender, EventArgs e)
        {
            frm.bExit = true;
            frm.Close();
            worker.Dispose();
            IsTaskEnable = false;
        }

        private void btnLog_Click(object sender, EventArgs e)//화면보기
        {
            try
            {
                frm.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)//지시량 확인 
        {
            POPDAC dac = new POPDAC();
            PlanQTY =   dac.selectPlanQTY(Convert.ToInt32(240)).ToString();
        }
    }
}
