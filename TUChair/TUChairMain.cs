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
    public partial class TUChairMain : Form
    {
        bool pflag1 = true;
        int inteval1 = 60;
        bool pflag2 = true;
        int inteval2 = 118;
        bool pflag3 = true;
        int inteval3 = 118;
        bool pflag4 = true;
        int inteval4 = 157;
        public TUChairMain()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Slidingmenu(slide1, timer1, ref inteval1, ref pflag1, 60);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Slidingmenu(slide2, timer2, ref inteval2, ref pflag2, 118);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Slidingmenu(slide3, timer3, ref inteval3, ref pflag3, 118);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Slidingmenu(slide4, timer4, ref inteval4, ref pflag4,157);
        }
        private void Slidingmenu(Panel slide, Timer timer, ref int inteval, ref bool pflag, int intevalMax, int num = 2)
        {
            if (pflag)
            {
                if (inteval > 0)
                {
                    slide.Location = new Point(slide.Location.X, slide.Location.Y + num);
                    inteval = inteval - num;
                }
                else
                {
                    pflag = false;
                    timer.Stop();
                }
            }
            else
            {
                if (inteval < intevalMax)
                {
                    slide.Location = new Point(slide2.Location.X, slide.Location.Y - num);
                    inteval = inteval + num;
                }
                else
                {
                    pflag = true;
                    timer.Stop();
                }
            }
        }

       

      
       

       

      

      

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            timer4.Start();
        }
    }
}
