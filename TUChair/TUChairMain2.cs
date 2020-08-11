using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Web.Services.Description;
using System.Windows.Forms;
using TUChair.Service;
using TUChairVO;
using Timer = System.Windows.Forms.Timer;

namespace TUChair
{
    public partial class TUChairMain2 : Form
    {       
        public event EventHandler New;      
        public event EventHandler Search;
        public event EventHandler Save;
        public event EventHandler Delete;
        public event EventHandler Excel;

        public delegate void BarCodeReadComplete(object sender, ReadEventArgs e);
        public event BarCodeReadComplete Readed;
        public CUserVO userInfoVO = null;
        List<Panel> uclist = new List<Panel>();
        List<Timer> timers = new List<Timer>();
        List<bool> slideFlags = new List<bool>();
        List<int> intevals = new List<int>();
        List<int> intevalMax = null;
        List<int> menulist = new List<int>();
        List<AuthorVO> author = null;
        List<string> testlist = new List<string>();
        Point point = new Point(0, 0);
        Button pribtn = null;
        SerialPort _port;
        bool bflag = false;

        #region 포트연결 관련
        public SerialPort Port    // 포트 프로퍼티
        {
            get
            {
                if (_port == null)
                {
                    _port = new SerialPort();
                    _port.DataReceived += Port_DataReceived;
                }
                return _port;
            }
        }
        private StringBuilder _strings;  
        public String Strings   //스트링 빌더 프로퍼티
        {
            set
            {
                if (_strings == null)
                    _strings = new StringBuilder(1024);
                _strings.AppendLine(value);

                if (Readed != null)
                {
                    ReadEventArgs args = new ReadEventArgs();
                    args.ReadMsg = _strings.ToString();
                    Readed(this, args);
                }
            }
        }
        private bool _isopen;
        public bool IsOpen
        {
            get { return _isopen; }
            set { _isopen = value; }
        }
        public void Clearstrings()
        {
            _strings.Clear();

        }
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);

            string msg = Port.ReadExisting();
            this.Invoke(new EventHandler(delegate
            {
                Strings = msg;
            }));
        }

        private void SerialPortConnecting()
        {
            if (!Port.IsOpen) //연결
            {
                bool bflag = false;
                foreach (var port in SerialPort.GetPortNames())
                {
                    if (port == Properties.Settings.Default.PortName)
                    {
                        bflag = true;
                    }
                }

                if (bflag)
                {
                    Port.PortName = Properties.Settings.Default.PortName;
                    Port.BaudRate = Convert.ToInt32(Properties.Settings.Default.BaudRate);
                    Port.DataBits = Convert.ToInt32(Properties.Settings.Default.DataSize);

                    Parity par = Parity.None;
                    if (Properties.Settings.Default.Parity == "even")
                        par = Parity.Even;
                    else if (Properties.Settings.Default.Parity == "odd")
                        par = Parity.Odd;
                    Port.Parity = par;

                    Handshake hands = Handshake.None;
                    Port.Handshake = hands;

                    try
                    {
                        Port.Open();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
            }
            else
            {
                Port.Close();
            }
            IsOpen = _port.IsOpen;
        }
        #endregion

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
                userInfoVO = frm.userinfo;
                this.Show();
            }
            else
            {
                this.Close();
                return;
            }
            LoginMenuBInding();
            if (Properties.Settings.Default.PortName.Length > 0) //시리얼 포트가 연결되어야 연결
                SerialPortConnecting();

            BindingMenu();
            requlUc();
        }

        private void LoginMenuBInding()
        {
            LoginService service = new LoginService();
            author = service.GetAuthorInfo(userInfoVO.AuthorGroup_ID);
            if (userInfoVO.CUser_Mark != "")
            {
                testlist = userInfoVO.CUser_Mark.Split('@').ToList<string>();
                foreach (var tests in testlist)
                {
                    var AA = (from A in author
                              where A.Program_ID == tests
                              select A).ToList();
                    AuthorVO[] authorVO1 = new AuthorVO[1];

                    AA.CopyTo(authorVO1);
                    AuthorVO authorVO = new AuthorVO();
                    authorVO = authorVO1[0];
                    authorVO.Module_ID = 9;
                    authorVO.Module_Name = "즐겨찾기";
                    authorVO.Program_order = 0;

                    author = (from A in author
                              orderby A.Program_order
                              select A).ToList();
                }
            }

            var item = (from A in author
                        group A by A.Module_ID
                        ).ToList();
            foreach (var list in item)
            {
                menulist.Add(Convert.ToInt32(list.Key));
            }
        }

        #region 메뉴바인딩
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

                    //Button btn = new Button();
                    //btn.Height = 20;
                    //btn.Width = 130;

                    if (j == 0)
                    {
                        Button btn = new Button();
                        btn.Tag = i;
                          btn.Height = 30;
                        btn.Width = 130;
                        btn.Click += button2_Click;
                      
                        btn.Text = menus[0].Module_Name;
                        btn.BackColor = Color.AliceBlue;
                        uclist[i].Controls.Add(btn);
                        btn.Location = new Point(point.X, point.Y + j * 20);
                        btn.BringToFront();
                    }
                    else
                    {
                        UserControl1 btn = new UserControl1();
                       
                        btn.Height = 30;
                        btn.Width = 130;
                        btn.Tag = menus[j - 1];
                        btn.labelClick += Btn_labelClick;
                        btn.buttonClick += button3_Click;
                        if (testlist != null)
                        {
                            foreach (var item in testlist)
                            {
                                if (item == menus[j - 1].Program_ID)
                                    btn.IsOnClick = true;
                            }
                        }
                        btn.ButtenText = menus[j - 1].Program_Name;
                        uclist[i].Controls.Add(btn);
                        btn.Location = new Point(point.X, point.Y + j * 30);
                        btn.BringToFront();
                    }
                  
                }
                int interval = 30 * menus.Count;
                intevals.Add(interval);
                bool bflag = true;
                slideFlags.Add(bflag);
                uclist[i].Name = "uc" + i.ToString();
                Timer timer = new Timer();
                timer.Tick += Timer_Tick;
                timer.Interval = 1;
                timer.Enabled = false;
                timers.Add(timer);
            }
            intevalMax = intevals.ToList();
        }

        private void Btn_labelClick(object sender, EventArgs e)  //즐겨찾기가 눌렸을 때 
        {
            var ctr = (UserControl1)sender;
            string proName = ((AuthorVO)ctr.Tag).Program_ID;
            bflag = ((UserControl1)sender).IsOnClick;
            if (bflag)
            {
                bflag = false;
                ctr.IsOnClick = bflag;
                testlist.Remove(proName);
            }
            else
            {
                if (testlist.Count > 7)
                {
                    MessageBox.Show("즐겨찾기 메뉴는 8개 이상 등록 할 수 없습니다.");
                    return;
                }
                bflag = true;
                ctr.IsOnClick = bflag;
                testlist.Add(proName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           AuthorVO author =(AuthorVO)((UserControl1)sender).Tag;

            OpenOrCreateForm(author.Program_ID);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //string strTmpNum = Regex.Replace(btn.Text, @"\D", "");
            timers[Convert.ToInt32(btn.Tag)].Tag = Convert.ToInt32(btn.Tag);
            if (pribtn == null)
            {
                timers[Convert.ToInt32(btn.Tag)].Enabled = true;
                timers[Convert.ToInt32(btn.Tag)].Start();
                pribtn = btn;
            }
            else if (pribtn != null&&pribtn!=btn)
            {
                if (timers[Convert.ToInt32(pribtn.Tag)].Enabled==true)
                    return;
                timers[Convert.ToInt32(btn.Tag)].Enabled = true;
                timers[Convert.ToInt32(btn.Tag)].Start();

                timers[Convert.ToInt32(pribtn.Tag)].Tag = Convert.ToInt32(pribtn.Tag);
                timers[Convert.ToInt32(pribtn.Tag)].Enabled = true;
                timers[Convert.ToInt32(pribtn.Tag)].Start();
                pribtn = btn;
            }
            else
            {
                pribtn = null;
                timers[Convert.ToInt32(btn.Tag)].Enabled = true;
                timers[Convert.ToInt32(btn.Tag)].Start();
            }
          
            //timers[Convert.ToInt32(btn.Tag)].Tag = Convert.ToInt32(btn.Tag);
            //    timers[Convert.ToInt32(btn.Tag)].Start();
        }
        private void requlUc()
        {
            for (int i = 0; i < uclist.Count - 1; i++)
            {
                uclist[i].Controls.Add(uclist[i + 1]);
                uclist[i + 1].Location = new Point(point.X, point.Y + 30);
                uclist[i + 1].BringToFront();
            }
        }
        private void OpenOrCreateForm(string progName)
        {
            try
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
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            int ntr = Convert.ToInt32(((Timer)sender).Tag);
            Slidingmenu(uclist[ntr + 1], ((Timer)sender), intevals, slideFlags, intevalMax[ntr], ntr);
        }
        #endregion
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
        private void Slidingmenu(Panel slide, Timer timer, List<int> inteval, List<bool> pflag, int intevalMax, int ntmp, int num = 5)
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
                    timer.Enabled = false;
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
                    timer.Enabled = false;
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
            author.Clear();
            menulist.Clear();
            pribtn = null;

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

        private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((tabForms.SelectedTab != null) && (tabForms.SelectedTab.Tag != null))
                (tabForms.SelectedTab.Tag as Form).Select();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (userInfoVO != null)
            {

                foreach (Form form in this.MdiChildren)
                {
                    form.Close();
                }
                ClearMenu();
                userInfoVO = null;
            }
            else
            {
                LoginFrm frm = new LoginFrm();
                
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    userInfoVO = frm.userinfo;
                    this.Show();
                }
                else
                {
                    this.Close();
                }
                LoginMenuBInding();
                BindingMenu();
                requlUc();
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // var type = this.GetType();
            //type.GetMethod("Save") != null;


            var flag = (typeof(TUChair.TestFrm1).GetMethod("Save", BindingFlags.NonPublic | BindingFlags.Instance) != null);
            if (flag)
                MessageBox.Show("있다");
            else
                MessageBox.Show("없다");

        }
        #region Methode 이벤트 발생
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (New != null)
            {
                New(this, null);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Search != null)
            {
                Search(this,null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save != null)
            {
                Save(this, null);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(this, null);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (Excel != null)
            {
                Excel(this, null);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
         
            OpenorCreateForm<TestFrm1>();
            //string AppName = Assembly.GetEntryAssembly().GetName().Name;

            //Type frmType = Type.GetType($"{AppName}.{progName}");

       
            //MethodInfo.
        }
        #endregion

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Port.IsOpen)
                Port.Close();

            PortSettingform frm = new PortSettingform();
            frm.ShowDialog();
            if (Properties.Settings.Default.PortName.Length > 0)
            { SerialPortConnecting(); }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            OpenorCreateForm<UpdateWorkOrder>();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            string UID = userInfoVO.CUser_ID;
            string Marks = string.Join("@", testlist);
          
            LoginService service = new LoginService();
            try
            {
                if (service.InsertMark(Marks, UID))
                {
                    MessageBox.Show("저장되었습니다. 재로그인하셔야 적용됩니다.");
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
    public class ReadEventArgs : EventArgs
    {
        private string msg;

        public string ReadMsg
        {
            get { return msg; }
            set { msg = value; }
        }
    }
}

