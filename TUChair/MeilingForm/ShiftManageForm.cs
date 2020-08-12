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
    public partial class ShiftManageForm : TUChair.SearchCommomForm
    {
        public ShiftManageForm()
        {
            InitializeComponent();
        }

        private void ShiftManageForm_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
           
            frm.Search += Search;
           
            frm.New += New;
            frm.Excel += Excel;

            MeilingService service = new MeilingService();
           // List<ShiftVO> list = service.SearchPivot();
            jeansGridView1.DataSource = null;
           // jeansGridView1.DataSource = list;
        }

        private void Excel(object sender, EventArgs e)
        {
           
        }

        private void New(object sender, EventArgs e)
        {
           
        }

        private void Search(object sender, EventArgs e)
        {
            
        }

        private void ShiftManageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
           
            frm.Search -= Search;
            
            frm.New -= New;
            frm.Excel -= Excel;
        }
    }
}
