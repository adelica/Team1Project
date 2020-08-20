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
    public partial class ProductionPlanningForm : TUChair.SearchCommomForm
    {
        public ProductionPlanningForm()
        {
            InitializeComponent();
        }

        private void ProductionPlanningForm_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Search += Search;
            frm.New += New;
            frm.Excel += Excel;
            jeansGridView1.IsAllCheckColumnHeader = true;
            jeansGridView1.RowHeadersVisible = false;
            //inDTP1.startfomat = DateTimePickerFormat.Custom;
            //inDTP1.endfomat = DateTimePickerFormat.Custom;
            //inDTP1.startCustomfomat = " ";
            //inDTP1.endCustomfomat = " ";
            //inDTP1.Start = new DateTime(int.Parse("2020"), int.Parse("07"), int.Parse("15"));
            //inDTP1.End = new DateTime(int.Parse("2020"), int.Parse("09"), int.Parse("03"));
          
            DataBinding();
            ComboBinding(comboBox1,3 );
           
            ComboBinding(cboplanID,5);
        }

        private void ComboBinding(ComboBox comboBox,int a)
        {
            List<string> list= new List<string>();
            list.Insert(0, "선택");
            for (int i = 0; i < jeansGridView1.RowCount; i++)
            {
                list.Add(jeansGridView1.Rows[i].Cells[a].Value.ToString());

            };
            list = list.Distinct().ToList();
            comboBox.Items.AddRange(list.ToArray());
        }

        private void DataBinding()
        {
            
            MeilingService service = new MeilingService();
            DataTable dt = new DataTable();
            
            dt = service.ProductPlanPivot(inDTP1.Start, inDTP1.End);
            jeansGridView1.AutoGenerateColumns = true;
            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = dt;
        }

        private void Excel(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                using (waitFrm frm = new waitFrm(ExportOrderList))
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog(this);
                }
            }
        }
        private void ExportOrderList()
        {
            string sResult = ExcelExportImport.ExportToDataGridView<ShiftVO>(
                (List<ShiftVO>)jeansGridView1.DataSource, "");
            if (sResult.Length > 0)
            {
                MessageBox.Show(sResult);
            }
        }
        private void New(object sender, EventArgs e)
        {
            DataBinding();
            comboBox1.SelectedIndex = 0;
            cboplanID.SelectedIndex = 0;
        }

        private void Search(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                string sg = GetSearchCondition(panel4);
                if (sg.Length < 1)
                    return;
                MeilingService service = new MeilingService();
                DataTable dt = new DataTable();

                dt = service.ProductPlansearchPivot(inDTP1.Start, inDTP1.End, sg);
                jeansGridView1.AutoGenerateColumns = true;
                jeansGridView1.DataSource = null;
                jeansGridView1.DataSource = dt;
            }
        }
        private string GetSearchCondition(Panel panel1)
        {
            List<string> sb = new List<string>();
            foreach (Control Pitem in panel1.Controls)
            {
                foreach (Control item in Pitem.Controls)
                {
                    if (item is ComboBox)
                    {
                        if (item.Text != "선택")
                            sb.Add($"{item.Tag.ToString()}='{((ComboBox)item).Text}'");
                    }
                    else if (item is TextBox)
                    {
                        if (item.Text != "")
                            sb.Add($"{item.Tag.ToString()} like '%{item.Text}%'");
                    }
                    else if (item is InDTP)
                    {
                        if (item.Text != "")
                            sb.Add($"between{((InDTP)item).Start.ToString()}and {((InDTP)item).End.ToString()}");
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            MessageBox.Show(String.Join(" and ", sb));
            return String.Join(" and ", sb);
           
        }
        private void ProductionPlanningForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;

            frm.Search -= Search;

            frm.New -= New;
            frm.Excel -= Excel;
        }
    }
}
