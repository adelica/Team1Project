using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace TUChair
{
    public partial class PORegi : Form
    {
        public PORegi()
        {
            InitializeComponent();
        }
        DataTable poData = null;
        private DataTable btnFileSelect_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel.Worksheet xlWorksheet = null;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel File (*.xlsx)|*.xlsx |Excel File 97 ~ 2003(*.xls)|*.xls|All Files(*.*)|*.*";

            if(ofd.ShowDialog()==DialogResult.OK)
            {
               
                    DataTable dt = new DataTable();

                    xlApp = new Excel.Application();
                    xlWorkbook = xlApp.Workbooks.Open(ofd.FileName);
                    xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

                    Excel.Range range = xlWorksheet.UsedRange;

                    object[,] data = range.Value;

                    for(int i = 1; i<=range.Columns.Count; i++)
                    {
                        dt.Columns.Add(i.ToString(), typeof(string));
                    }

                    for(int r= 1; r< range.Rows.Count; r++)
                    {
                        DataRow dr = dt.Rows.Add();
                        for(int c=1; c<range.Columns.Count; c++)
                        {
                            dr[c - 1] = data[r, c];
                        }
                    }
                    xlWorkbook.Close(true);
                    xlApp.Quit();
                    poData = dt;                  
            }
                return poData;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
