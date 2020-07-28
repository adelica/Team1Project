using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChairVO;

namespace TUChair.Util
{
    public class CommonUtil
    {
        static CheckBox headerChk;
        static DataGridView dgv1;
        public static void AddNewColumnToDataGridView(DataGridView dgv, string headerText, string dataPropertyName, bool visibility, int colWidth = 100, DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft, bool fronzen = false)
        {
            DataGridViewTextBoxColumn gridCol = new DataGridViewTextBoxColumn();
            gridCol.Name = dataPropertyName; //추가 속성
            gridCol.HeaderText = headerText;
            gridCol.DataPropertyName = dataPropertyName;
            gridCol.Width = colWidth;
            gridCol.Visible = visibility;
            gridCol.ValueType = typeof(string);
            gridCol.ReadOnly = true;
            gridCol.DefaultCellStyle.Alignment = textAlign;
            gridCol.Frozen = fronzen;  //추가 속성
            dgv.Columns.Add(gridCol);

        }
       
    

     
        public static void InitSettingGridView(DataGridView dgv)
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();

            //dgv.ReadOnly = true;
           // dgv.AutoGenerateColumns = false;        
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = true;
            //dgv.RowHeadersVisible = false;
            dgv.MultiSelect = false;
           dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
           dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

        }
        public static void ComboBinding<T>(ComboBox combo, List<T> list, string Code, string CodeNm)
        {
            if (list == null)
                list = new List<T>();

            combo.DataSource = list;
            combo.DisplayMember = CodeNm;
            combo.ValueMember = Code;
        }
        public static void ComboBinding(ComboBox combo, List<ComboItemVO> list, string blankText)
        {
            if (list == null)
                list = new List<ComboItemVO>();

            list.Insert(0, new ComboItemVO(blankText));
            combo.DataSource = list;
            combo.DisplayMember = "CodeNm";
            combo.ValueMember = "Code";
        }
    }
}
