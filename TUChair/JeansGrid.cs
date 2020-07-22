using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeanForm
{
    public partial class JeansGridView : DataGridView
    {
        public JeansGridView()
        {
            InitializeComponent();
             this.DefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Bold);
            
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            this.RowHeadersWidth = 30;
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ColumnHeadersHeight = 30;

            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 52, 52);
            this.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.Info;
            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 52, 52);
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;

            this.ReadOnly = true;
            this.DefaultCellStyle.BackColor = Color.White;
            this.DefaultCellStyle.ForeColor = Color.FromArgb(52, 52, 52);
            this.DefaultCellStyle.SelectionBackColor = Color.Gray;
            this.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;

            this.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.AlternatingRowsDefaultCellStyle.BackColor =Color.Beige;

        }
        

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        
    }
}
