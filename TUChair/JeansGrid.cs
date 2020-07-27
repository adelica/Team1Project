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
        CheckBox headerCheckBox = new CheckBox();

        public CheckBox HeaderCheckBox { get { return headerCheckBox; } }

        private bool _allCheckHeader;

        public bool IsAllCheckColumnHeader
        {
            get { return _allCheckHeader; }
            set
            {
                _allCheckHeader = value;
                DrawCheckColumn();
            }
        }
        public JeansGridView()
        {
            InitializeComponent();
           JeanGridDrawing();
        }
        public void JeanGridDrawing()
        {
            this.DefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Bold);

           // this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.RowHeadersWidth = 30;
            //this.EnableHeadersVisualStyles = false;
            //this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ColumnHeadersHeight = 30;

            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 52, 52);
            this.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.Info;
            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 52, 52);
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;

            //this.ReadOnly = true;
            this.DefaultCellStyle.BackColor = Color.White;
            this.DefaultCellStyle.ForeColor = Color.FromArgb(52, 52, 52);
            this.DefaultCellStyle.SelectionBackColor = Color.Gray;
            this.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;

            this.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

        }
        private void DrawCheckColumn()
        {
            if (_allCheckHeader == true)
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.HeaderText = "";
                chk.Name = "chk";
                chk.Width = 30;
                this.Columns.Add(chk);

                Point headerCellLocation = this.GetCellDisplayRectangle(0, -1, true).Location;

                headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 2);
                headerCheckBox.BackColor = Color.White;
                headerCheckBox.Size = new Size(18, 18);
                headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
                this.Controls.Add(headerCheckBox);

                this.Columns[0].Frozen = true;
            }
        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            this.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in this.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["chk"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        
    }
}
