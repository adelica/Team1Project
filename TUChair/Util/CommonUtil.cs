using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        public static void AddNewchkColumnToDataGridView(DataGridView dgv, string headerText, string dataPropertyName, bool visibility, int colWidth = 60)
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = headerText;
            chk.Name = dataPropertyName;
            chk.Width = colWidth;
            chk.ReadOnly = false;
            chk.DataPropertyName = dataPropertyName;
            
        //    chk.ValueType = typeof(bool);
            chk.Visible = visibility;
            dgv.Columns.Add(chk);
        }




        public static void InitSettingGridView(DataGridView dgv)
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();

           // dgv.ReadOnly = true;
            dgv.AutoGenerateColumns = false;        
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.RowHeadersVisible = false;
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
        public static void ReComboBinding(ComboBox combo, List<ComboItemVO> list, string blankText)
        {
            if (list == null)
                list = new List<ComboItemVO>();

            list.Insert(0, new ComboItemVO(blankText,"R"));
            combo.DataSource = list;
            combo.DisplayMember = "Code";
            combo.ValueMember = "CodeNm";
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
          
            combo.SelectedIndex = 0;
        }

        public static void CboUseOrNot(ComboBox combo)
        {
            string[] cUseOrNot = { "사용", "미사용" };
            combo.Items.AddRange(cUseOrNot);
            combo.SelectedIndex = 0;
        }

        public static void RequiredInfo()
        {
            MessageBox.Show("필수 입력사항을 입력해주세요.", "등록실패");
        }
        public static List<AuthorBooltypeVO> ChangeTypeAuthor(List<AuthorVO> author)
        {
            List<AuthorBooltypeVO> authorBooltypes = new List<AuthorBooltypeVO>();
            foreach (var item in author)
            {
                AuthorBooltypeVO authorBool = new AuthorBooltypeVO();
             
               authorBool.Program_ID      = item.Program_ID             ;
               authorBool.Program_Name    = item.Program_Name           ;
               authorBool.Program_order   = item.Program_order          ;
               authorBool.Module_ID       = item.Module_ID              ;
               authorBool.Module_Name     = item.Module_Name            ;
               authorBool.Method_Search   = item.Method_Search =="Y"? true : false          ;
               authorBool.Method_New = item.Method_New == "Y"? true : false         ;
               authorBool.Method_Save     = item.Method_Save   =="Y"? true : false         ;
               authorBool.Method_Delete   = item.Method_Delete =="Y"? true : false         ;
                authorBool.Method_Excel   = item.Method_Excel  == "Y" ? true : false        ;
                authorBooltypes.Add(authorBool);
            }
            return authorBooltypes;
        }
        public static List<AuthorBooltypeVO> ChangeAuthorFromMethode(List<AuthorVO> author)
        {
            List<AuthorBooltypeVO> authorBooltypes = new List<AuthorBooltypeVO>();
            string AppName = Assembly.GetEntryAssembly().GetName().Name;
            foreach (var item in author)
            {
                AuthorBooltypeVO authorBool = new AuthorBooltypeVO();

                authorBool.Program_ID = item.Program_ID;
                authorBool.Program_Name = item.Program_Name;
                authorBool.Program_order = item.Program_order;
                authorBool.Module_ID = item.Module_ID;
                authorBool.Module_Name = item.Module_Name;
                authorBool.Method_Search = item.Method_Search == "Y" ? true : false;
                authorBool.Method_New = item.Method_New == "Y" ? true : false;
                authorBool.Method_Save = item.Method_Save == "Y" ? true : false;
                authorBool.Method_Delete = item.Method_Delete == "Y" ? true : false;
                authorBool.Method_Excel = item.Method_Excel == "Y" ? true : false;

                Type frmType = Type.GetType($"{AppName}.{item.Program_ID}");
                var saveflag=(frmType.GetMethod("Save", BindingFlags.NonPublic | BindingFlags.Instance) != null);
                var deleteflag = (frmType.GetMethod("Delete", BindingFlags.NonPublic | BindingFlags.Instance) != null);
                var newflag = (frmType.GetMethod("New", BindingFlags.NonPublic | BindingFlags.Instance) != null);
                var excelflag = (frmType.GetMethod("Excel", BindingFlags.NonPublic | BindingFlags.Instance) != null);
                var searchflag = (frmType.GetMethod("Search", BindingFlags.NonPublic | BindingFlags.Instance) != null);

                authorBool.Method_Search = (authorBool.Method_Search) & searchflag;
                authorBool.Method_New = (authorBool.Method_New) & newflag;
                authorBool.Method_Save = authorBool.Method_Save & saveflag;
                authorBool.Method_Delete = authorBool.Method_Delete & deleteflag ;
                authorBool.Method_Excel = authorBool.Method_Excel& excelflag;
                authorBooltypes.Add(authorBool);
            }
            return authorBooltypes;
        }
        public static List<AuthorBooltypeVO> ChangeAuthorFromMethode(List<AuthorBooltypeVO> author)
        {
            List<AuthorBooltypeVO> authorBooltypes = new List<AuthorBooltypeVO>();
            string AppName = Assembly.GetEntryAssembly().GetName().Name;
            foreach (var item in author)
            {
                Type frmType = Type.GetType($"{AppName}.{item.Program_ID}");
                var saveflag = (frmType.GetMethod("Save", BindingFlags.NonPublic | BindingFlags.Instance) != null);
                var deleteflag = (frmType.GetMethod("Delete", BindingFlags.NonPublic | BindingFlags.Instance) != null);
                var newflag = (frmType.GetMethod("New", BindingFlags.NonPublic | BindingFlags.Instance) != null);
                var excelflag = (frmType.GetMethod("Excel", BindingFlags.NonPublic | BindingFlags.Instance) != null);
                var searchflag = (frmType.GetMethod("Search", BindingFlags.NonPublic | BindingFlags.Instance) != null);

                item.Method_Search = (item.Method_Search) & searchflag;
                item.Method_New = (item.Method_New) & newflag;
                item.Method_Save = item.Method_Save & saveflag;
                item.Method_Delete = item.Method_Delete & deleteflag;
                item.Method_Excel = item.Method_Excel & excelflag;
                authorBooltypes.Add(item);
            }
            return authorBooltypes;
        }

        public static List<AuthorVO> ReChangeTypeAuthor(List<AuthorBooltypeVO> author)
        {
            List<AuthorVO> authorBooltypes = new List<AuthorVO>();
            foreach (var item in author)
            {
                AuthorVO authorBool = new AuthorVO();
                authorBool.Program_ID       = item.Program_ID;
                authorBool.Program_Name         = item.Program_Name;
                authorBool.Program_order    = item.Program_order;
                authorBool.Module_ID        = item.Module_ID;
                authorBool.Module_Name      = item.Module_Name;
                authorBool.Method_Search     = item.Method_Search ? "Y" : "N";
                authorBool.Method_New = item.Method_New ? "Y" : "N";
                authorBool.Method_Save      = item.Method_Save ? "Y" : "N";
                authorBool.Method_Delete    = item.Method_Delete ? "Y" : "N";
                authorBool.Method_Excel      = item.Method_Excel  ? "Y" : "N";
                authorBooltypes.Add(authorBool);
            }
            return authorBooltypes;
        }



    }
}
