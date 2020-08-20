using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUChair
{
    public partial class POPForm : Form
    {
        public POPForm()
        {
            InitializeComponent();
        }

        private void POPForm_Load(object sender, EventArgs e)
        {
          //List<taskItem> tasks = ConfigurationManager.GetSection("taskList") as List<taskItem>;
            string IP = "127.0.0.1";
            int[] Port = { 5000, 5100, 5200, 5300, 5400 };
            string[] taskID = { "task01", "task02","task03","task04","task05" };
            int iCnt = 0;
            for(int i=0;i<5;i++)
            {
                POPUserControl taskcontrol = new POPUserControl();
                taskcontrol.Location = new Point(15, 10 + (200 * iCnt));
                taskcontrol.Size = new Size(1116, 190);
                taskcontrol.Name = $"taskControl{iCnt}";

                taskcontrol.TaskID = taskID[i];
                taskcontrol.IP = IP;
                taskcontrol.Port = Port[i].ToString();
             
                taskcontrol.IsTaskEnable = false;

                panel1.Controls.Add(taskcontrol);
                iCnt++;
            }
        }
    }
}
