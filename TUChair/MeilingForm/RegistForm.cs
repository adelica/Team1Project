using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChairVO;

namespace TUChair
{ 
    public partial class RegistForm : TUChair.SearchCommomForm
    {
        public RegistForm()
        {
            InitializeComponent();
        }

        private void RegistForm_Load(object sender, EventArgs e)
        {
            //selectWorkorder
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            //frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
           // Setcolumn();
            DataBinding();
           
            ComboBinding();
            DataBinding();
          
        }

        private void ComboBinding()
        {
           
        }

        private void DataBinding()
        {
            jeansGridView1.IsAllCheckColumnHeader = true;
            jeansGridView1.RowHeadersVisible = false;
            MeilingService service = new MeilingService();
           
            List<WoOrderVO> list = service.selectWorkorder();
            jeansGridView1.AutoGenerateColumns = true;
            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = list;
        }

        private void Search(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Excel(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void New(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Save(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RegistForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;

            frm.Search -= Search;
            frm.Save -= Save;
            frm.New -= New;
            frm.Excel -= Excel;
        }
    }
}
