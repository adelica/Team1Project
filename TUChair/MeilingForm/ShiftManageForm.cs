using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;
using TUChairVO;

namespace TUChair
{
    public partial class ShiftManageForm : TUChair.SearchCommomForm
    {
        List<ComboItemVO> comboItems = null;
        List<string> FaciNameList;
        List<string> FaciCodeList;
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
            DataBinding();
            ComboBinding();
           
        }
        private void ComboBinding()
        {
            FaciCodeList = new List<string>();
            FaciCodeList.Insert(0, "");
            for (int i = 0; i < jeansGridView1.RowCount; i++)
            {
                FaciCodeList.Add(jeansGridView1.Rows[i].Cells[1].Value.ToString());

            };
            FaciCodeList = FaciCodeList.Distinct().ToList();
            FaciNameList = new List<string>();
            FaciNameList.Insert(0, "선택");
            for (int i = 0; i < jeansGridView1.RowCount; i++)
            {
                FaciNameList.Add(jeansGridView1.Rows[i].Cells[2].Value.ToString());

            };
            FaciNameList = FaciNameList.Distinct().ToList();
            Dictionary<string, string> ComboDic = new Dictionary<string, string>();
            // ComboDic.Add("선택", "선택");
            ComboDic = FaciNameList.Zip(FaciCodeList, (k, v) => new { k, v }).ToDictionary(a => a.k, a => a.v);
            comboBox2.Items.Clear();
            comboBox2.DataSource =new BindingSource(ComboDic,null);
            comboBox2.DisplayMember = "key";
            comboBox2.ValueMember = "value";
            //comboBox2.SelectedIndex = 0;
            //comboBox2.DataSource = ComboDic;
           // comboBox2.Items.AddRange(FaciCodeList.ToArray());
        }
        private void DataBinding()
        {
            jeansGridView1.IsAllCheckColumnHeader = true;
            jeansGridView1.RowHeadersVisible = false;
            MeilingService service = new MeilingService();
            DataTable dt = new DataTable();
            dt = service.SearchPivot(inDTP1.Start, inDTP1.End);
            jeansGridView1.AutoGenerateColumns = true;
            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = dt;
        }

        private void Excel(object sender, EventArgs e)
        {
           
        }

        private void New(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void Search(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                MessageBox.Show("아이템 코드를 선택하여 주세요");
                return;
            }
            MeilingService service = new MeilingService();
            DataTable dt = new DataTable();
            
            dt = service.SearchPivotFaci(inDTP1.Start, inDTP1.End,comboBox2.SelectedValue.ToString());
            jeansGridView1.AutoGenerateColumns = true;
            jeansGridView1.DataSource = dt;
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
