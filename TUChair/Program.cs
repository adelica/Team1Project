using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUChair
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] procs = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (procs.Length > 1)
            {
                MessageBox.Show(" 프로그램이 이미 실행되고 있습니다. \n다시 한 번 확인해 주시길 바랍니다.", "실행 중");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TUChairMain2());
        }
    }
}
