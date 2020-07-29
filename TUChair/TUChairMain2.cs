using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChair.Service;
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
        List<int> menulist = new List<int>();
        List<AuthorVO> author = null;
        Point point = new Point(0, 0);
        CUserVO userInfoVO = null;

        public TUChairMain2()
        {
            InitializeComponent();
        }
        private void TUChairMain2_Load(object sender, EventArgs e)
        {
            LoginFrm frm = new LoginFrm();
            this.Hide();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                userInfoVO= frm.userinfo;
                this.Show();
            }
            else
            {
                this.Close();
            }
            LoginService service = new LoginService();
            author = service.GetAuthorInfo(userInfoVO.AuthorGroup_ID);
            var item = (from A in author
                        group A by A.Module_ID
                        ).ToList();
            foreach (var list in item)
            {
                menulist.Add(Convert.ToInt32(list.Key));
            }

            BindingMenu();
            requlUc();
        }
      
        private void BindingMenu()
        {
            for (int i = 0; i < menulist.Count + 1; i++)
            {
                if (i == 0)
                {
                    uclist.Add(panel1);
                }
                else
                {
                    Panel uc = new Panel();
                    uc.Width = 130;
                    uc.Height = 720;
                    uclist.Add(uc);
                }
                if (i == (menulist.Count))
                    continue;

                List<AuthorVO> menus = (from item in author
                                        where item.Module_ID == menulist[i]
                                        select item
                                        ).ToList();

                for (int j = 0; j < menus.Count + 1; j++)
                {
                    uclist[i].ResumeLayout(false);

                    Button btn = new Button();
                    btn.Height = 20;
                    btn.Width = 130;

                    if (j == 0)
                    {
                        btn.Tag = i;
                        btn.Click += button2_Click;
                        btn.Text = menus[0].Module_Name;
                        btn.BackColor = Color.AliceBlue;
                    }
                    else
                    {
                        btn.Tag = menus[j - 1];
                        btn.Click += button3_Click;
                        btn.Text = menus[j - 1].Program_Name;
                    }
                    uclist[i].Controls.Add(btn);
                    btn.Location = new Point(point.X, point.Y + j * 20);
                    btn.BringToFront();
                }
                int interval = 20 * menus.Count;
                intevals.Add(interval);
                bool bflag = true;
                slideFlags.Add(bflag);
                uclist[i].Name = "uc" + i.ToString();
                Timer timer = new Timer();
                timer.Tick += Timer_Tick;
                timer.Interval = 1;
                timers.Add(timer);
            }
            intevalMax = intevals.ToList();
        }
        private void button3_Click(object sender, EventArgs e)
        {
           AuthorVO author =(AuthorVO)((Button)sender).Tag;

            OpenOrCreateForm(author.Program_ID);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //string strTmpNum = Regex.Replace(btn.Text, @"\D", "");
            timers[Convert.ToInt32(btn.Tag)].Tag = Convert.ToInt32(btn.Tag);
            timers[Convert.ToInt32(btn.Tag)].Start();
        }
        private void requlUc()
        {
            for (int i = 0; i < uclist.Count - 1; i++)
            {
                uclist[i].Controls.Add(uclist[i + 1]);
                uclist[i + 1].Location = new Point(point.X, point.Y + 20);
                uclist[i + 1].BringToFront();
            }
        }
        private void OpenOrCreateForm(string progName)
        {
            string AppName = Assembly.GetEntryAssembly().GetName().Name;
            Type frmType = Type.GetType($"{AppName}.{progName}");

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == frmType)
                {
                    form.Activate();
                    return;
                }
            }
            Form frm = (Form)Activator.CreateInstance(frmType);
            //T frm = new T();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            int ntr = Convert.ToInt32(((Timer)sender).Tag);
            Slidingmenu(uclist[ntr + 1], timers[ntr], intevals, slideFlags, intevalMax[ntr], ntr);
        }
        #region TabForm만드는 부분
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
        #endregion
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
        private void ClearMenu()
        {
            panel1.Controls.Clear();
            uclist.Clear();
            timers.Clear();
            slideFlags.Clear();
            intevals.Clear();
            intevalMax.Clear();
        }
        private void ReBindingMenu(object sender, EventArgs e)
        {
            BindingMenu();
            requlUc();
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

    }
}
