using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Validation;

namespace TUChair
{
    public partial class PreviewForm : Form
    {
        public PreviewForm(IReport rpt)
        {
            InitializeComponent();

            using (ReportPrintTool printTool = new ReportPrintTool(rpt))
            {
              
                printTool.ShowRibbonPreviewDialog();
            }
        }

        private void PreviewForm_Load(object sender, EventArgs e)
        {

        }
    }
}
