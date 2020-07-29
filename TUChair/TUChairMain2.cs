﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChair.InForm;
using TUChairVO;

namespace TUChair
{
    public partial class TUChairMain2 : Form
    {
        List<Panel> uclist = new List<Panel>();
        List<Timer> timers = new List<Timer>();
        List<bool> slideFlags = new List<bool>();
        List<int> intevals = new List<int>();
        List<int> intevalMax = null;
        List<MainMenu> list = null;
        List<MainMenu> author = null;
        Point point = new Point(0, 0);
        int nTmp;

        public TUChairMain2()
        {
            InitializeComponent();
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
        private void ShowMethod(List<AuthorVO> authors, string programName)
        { 
            

        }
        private void Slidingmenu(Panel slide, Timer timer, List<int> inteval, List<bool> pflag, int intevalMax, int ntmp, int num = 2)
        {
            if (pflag[ntmp])
            {
                if (inteval[ntmp] > 0)
                {
                    slide.Location = new Point(slide.Location.X, slide.Location.Y + num);
                    inteval[ntmp] = inteval[ntmp] - num;
                }
                else
                {
                    pflag[ntmp] = false;
                    timer.Stop();
                }
            }
            else
            {
                if (inteval[ntmp] < intevalMax)
                {
                    slide.Location = new Point(slide.Location.X, slide.Location.Y - num);
                    inteval[ntmp] = inteval[ntmp] + num;
                }
                else
                {
                    pflag[ntmp] = true;
                    timer.Stop();
                }
            }
        }
    }
}
