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

namespace TUChair
{
    public partial class PreviewForm : Form
    {
        public PreviewForm(FacilityReport rpt)
        {
            InitializeComponent();

            using (ReportPrintTool printTool = new ReportPrintTool(rpt))
            {
              
                printTool.ShowRibbonPreviewDialog();
            }
        }

    }
}
