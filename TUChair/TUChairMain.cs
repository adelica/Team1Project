using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChair.InForm;
using TUChair.MeilingForm;

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
            Slidingmenu(slide4, timer4, ref inteval4, ref pflag4, 157);
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

        public void OpenorCreateForm<T>() where T : Form, new()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(T))
                {

                    form.Activate();

                    form.FormBorderStyle = FormBorderStyle.None;
                    form.Dock = DockStyle.Fill;
                    return;
                }
            }
            T frm = new T();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            frm.Show();
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

        private void 공장관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenorCreateForm<FactoryManage>();
        }

        private void TUChairMain_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
                tabForms.Visible = false;
            else
            {
                //this.ActiveMdiChild.WindowState = FormWindowState.Maximized;

                if (this.ActiveMdiChild.Tag == null)
                {
                    //TabPage 생성자에 Text를 넘길때 공백을 추가로 넣어서 이미지와 붙지 않게
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text + "    ");
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tabForms;
                    tabForms.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);
                }

                if (!tabForms.Visible) tabForms.Visible = true;
            }
        }
        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void tabForms_MouseDown(object sender, MouseEventArgs e)
        {
            for (var i = 0; i < tabForms.TabPages.Count; i++)
            {
                var tabRect = tabForms.GetTabRect(i);
                //tabRect.Inflate(-2, -2);
                var closeImage = Properties.Resources.close_grey;
                var imageRect = new Rectangle(
                    (tabRect.Right - closeImage.Width),
                    tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
                    closeImage.Width,
                    closeImage.Height);
                if (imageRect.Contains(e.Location))
                {
                    this.ActiveMdiChild.Close();
                    //tabForms.TabPages.RemoveAt(i);                    
                    break;
                }
            }
        }

        private void shift기준정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenorCreateForm<ShiftsearchForm>();
        }
    }
}
