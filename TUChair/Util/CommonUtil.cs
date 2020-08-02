using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using TUChairVO;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TUChair.Util
{
    public class CommonUtil
    {

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
        public static void ComboBinding(ComboBox combo, List<ComboItemVO> list)
        {
            combo.ValueMember = "Code";
            combo.DisplayMember = "CodeNm";
            combo.DataSource = list;
        }
        //---------------------------------------------------------
        public static void CboSetting(ComboBox combo) //콤보박스 기본설정
        {

            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.FlatStyle = FlatStyle.Flat;
            combo.SelectedIndex = 0;
        }

        public static void CboUseOrNot(ComboBox combo)
        {
            string[] cUseOrNot = { "사용", "미사용" };
            combo.Items.AddRange(cUseOrNot);
        }

        public static void RequiredInfo()
        {
            MessageBox.Show("필수 입력사항을 입력해주세요.", "등록실패");
        }
    }
}
