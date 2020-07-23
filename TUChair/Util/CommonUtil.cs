using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUChair.Util
{
    public class CommonUtil
    {
        static CheckBox headerChk;
        static DataGridView dgv1;
        public static void AddNewColumnToDataGridView(DataGridView dgv, string headerText, string dataPropertyName, bool visibility, int colWidth = 100, DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft)
        {
            dgv1 = dgv;
            DataGridViewTextBoxColumn gridCol = new DataGridViewTextBoxColumn();
            gridCol.HeaderText = headerText;
            gridCol.DataPropertyName = dataPropertyName;
            gridCol.Width = colWidth;
            gridCol.Visible = visibility;
            gridCol.ValueType = typeof(string);
            gridCol.ReadOnly = true;
            gridCol.DefaultCellStyle.Alignment = textAlign;
            dgv.Columns.Add(gridCol);

        }
        public static int DataGridViewCheckBoxSet(string headerText, DataGridView dgv)
        {
            DataGridViewCheckBoxColumn chb1 = new DataGridViewCheckBoxColumn();
            chb1.HeaderText = headerText;
            chb1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            chb1.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            chb1.FlatStyle = FlatStyle.Flat;
            return dgv.Columns.Add(chb1);
        }
        public static void DgvCheckBox(DataGridView dgv)
        {
            
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Width = 30;
                chk.Name = "";
                dgv.Columns.Add(chk); //0 - checkbox

                //데이터그리드뷰의 헤더에 위치할 체크박스
                headerChk = new CheckBox();

                Point headerCell = dgv.GetCellDisplayRectangle(0, -1, true).Location;

                headerChk.Location = new Point(headerCell.X + 8, headerCell.Y + 2);
                headerChk.Size = new Size(18, 18);
                headerChk.BackColor = Color.White;
                headerChk.Click += HeaderChk_Clicked;
                dgv.Controls.Add(headerChk);
        }

        private static void HeaderChk_Clicked(object sender, EventArgs e)
        {

            dgv1.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["chk"];
                chk.Value = headerChk.Checked;
            }
        }

        public static void InitSettingGridView(DataGridView dgv)
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();

            //dgv.ReadOnly = true;
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.MultiSelect = false;
           dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
           dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

        }
    }
}
