using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChair.CommonForm;
using TUChair.Service;
using TUChair.Util;
using TUChairVO;

namespace TUChair
{
    public partial class AuthorManager : SearchTwoGridLeftRightFrom
    {
        List<ComboItemVO> comboItems = null;
        List<ProgramVO> progs = null;
        List<AuthorBooltypeVO> authority = null;
        List<AuthorVO> author = null;
        public AuthorManager()
        {
            InitializeComponent();
        }

        private void AuthorManager_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            commonService service = new commonService();
            comboItems = service.getCommonCode("User@사용여부@AuthorGroup");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "AuthorGroup"
                                       select item).ToList();
            CommonUtil.ComboBinding(cboauthgroup, cList, "선택");

            jeansGridView1.IsAllCheckColumnHeader = true;
            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "모듈아이디", "Module_ID", false);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "상위메뉴", "Module_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "메뉴아이디", "Program_ID", true,200);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "메뉴명", "Program_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "메뉴설명", "Program_Explanation", true,200);
            BindingProg();


            jeansGridView2.IsAllCheckColumnHeader = true;
            CommonUtil.InitSettingGridView(jeansGridView2);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "메뉴아이디", "Program_ID", true,200);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "메뉴명", "Program_Name", true);

            //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            //chk.HeaderText = "";
            //chk.Name = "chk";
            //chk.Width = 30;
            //chk.ReadOnly = false;
            //this.Columns.Add(chk);



            CommonUtil.AddNewchkColumnToDataGridView(jeansGridView2, "새로고침", "Method_New", true);
            CommonUtil.AddNewchkColumnToDataGridView(jeansGridView2, "조회", "Method_Search", true);
            CommonUtil.AddNewchkColumnToDataGridView(jeansGridView2, "저장", "Method_Save", true);
            CommonUtil.AddNewchkColumnToDataGridView(jeansGridView2, "삭제", "Method_Delete", true);
            CommonUtil.AddNewchkColumnToDataGridView(jeansGridView2, "엑셀", "Method_Excel", true);

        }
        private void BindingProg()
        {
            commonService service1 = new commonService();
            progs = service1.GetAllMenu();
            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = progs;
        }

        private void New(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Delete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Search(object sender, EventArgs e)
        {
           

            
        }

        private void Save(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cboauthgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboauthgroup.Text == "선택")
                return;
            commonService service1 = new commonService();
            author = service1.Getauthor(Convert.ToInt32(cboauthgroup.SelectedValue));

            authority = CommonUtil.ChangeAuthorFromMethode(author);

            jeansGridView2.DataSource = null;
            jeansGridView2.DataSource = authority;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (jeansGridView2.DataSource == null)
                return;
            
            List<string> sb = new List<string>();
            jeansGridView1.EndEdit();
            for (int i = 0; i < jeansGridView1.RowCount; i++)
            {
                bool isn = Convert.ToBoolean(jeansGridView1.Rows[i].Cells["chk"].Value);
                if (isn)
                {
                    sb.Add(jeansGridView1.Rows[i].Cells[2].Value.ToString());
                }
            }

            
        }
    }
}
