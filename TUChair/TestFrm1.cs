﻿using DevExpress.DataProcessing.InMemoryDataProcessor.GraphGenerator;
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
    public partial class TestFrm1 : Form
    {
        bool bflag=false;
        public TestFrm1()
        {
            InitializeComponent();
        }

       private void TestFrm1_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
            
        }
        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            { MessageBox.Show("저장이다2."); }
        }
        private void New(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("새로고쳐.");
        }
        private void Search(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            { 
                MessageBox.Show("찾는다2"); 
            }
        }
        private void Delete(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            { MessageBox.Show("지워"); }
        }
        private void Excel(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            { MessageBox.Show("엑셀만들어"); }
        }

        private void TestFrm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save -= Save;
            frm.Search -= Search;
            frm.Delete -= Delete;
            frm.New -= New;
            frm.Excel -= Excel;
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_labelClick(object sender, EventArgs e)
        {
            if (bflag)
            {
                bflag = false;
                userControl11.IsOnClick = bflag;
            }
            else
            {
                bflag = true;
                userControl11.IsOnClick = bflag;
            }
        }
    }
}
