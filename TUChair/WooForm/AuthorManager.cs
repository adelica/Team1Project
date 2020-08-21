using DevExpress.Utils.Extensions;
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
        int authorgropID = 0;
        public AuthorManager()
        {
            InitializeComponent();
        }

        private void AuthorManager_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            
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
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "메뉴아이디", "Program_ID", true,210);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView2, "메뉴명", "Program_Name", true,110);

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
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                jeansGridView2.DataSource = null;
                authorgropID = 0;
                cboauthgroup.SelectedIndex = 0;
                author = null;
            }
        }

        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                if (authorgropID == 0)
                {
                    MessageBox.Show("권한그룹을 선택하여 주세요.");
                    return;
                }
                if (jeansGridView2.DataSource == null)
                {
                    MessageBox.Show("선택된 메뉴가 없습니다.");
                    return;
                }
                try
                {
                    jeansGridView2.EndEdit();
                    List<AuthorBooltypeVO> authorBooltypes = new List<AuthorBooltypeVO>();
                    LoginService service = new LoginService();
                    for (int i = 0; i < jeansGridView2.RowCount; i++)
                    {
                        AuthorBooltypeVO authorVO = new AuthorBooltypeVO();
                        authorVO.Program_ID = jeansGridView2.Rows[i].Cells[1].Value.ToString();
                        authorVO.Program_Name = jeansGridView2.Rows[i].Cells[2].Value.ToString();
                        authorVO.Module_ID = authorgropID;
                        authorVO.Method_New = (bool)jeansGridView2.Rows[i].Cells[3].Value;
                        authorVO.Method_Save = (bool)jeansGridView2.Rows[i].Cells[5].Value;
                        authorVO.Method_Search = (bool)jeansGridView2.Rows[i].Cells[4].Value;
                        authorVO.Method_Delete = (bool)jeansGridView2.Rows[i].Cells[6].Value;
                        authorVO.Method_Excel = (bool)jeansGridView2.Rows[i].Cells[7].Value;
                        authorBooltypes.Add(authorVO);
                    }
                    author = CommonUtil.ReChangeTypeAuthor(authorBooltypes);
                    if (service.InsertAuthor(author))
                    {
                        MessageBox.Show("저장되었습니다.");
                        author = null;
                        BindAuthor();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void cboauthgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (authorgropID == 0)
                return;
            jeansGridView2.EndEdit();
            List<string> sb = new List<string>();
            for (int i = 0; i < jeansGridView2.RowCount; i++)
            {
                bool isn = Convert.ToBoolean(jeansGridView2.Rows[i].Cells["chk"].Value);
                if (isn)
                {
                    string programID = jeansGridView2.Rows[i].Cells[1].Value.ToString();
                    sb.Add(programID);
                }
            }
            foreach (var item in sb)
            {
                authority.Remove(x => x.Program_ID == item);
            }
            jeansGridView2.DataSource = null;
            jeansGridView2.DataSource = authority;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (jeansGridView2.DataSource == null)
                return;
            
            List<AuthorBooltypeVO> sb = new List<AuthorBooltypeVO>();
            jeansGridView1.EndEdit();
            for (int i = 0; i < jeansGridView1.RowCount; i++)
            {
                bool isn = Convert.ToBoolean(jeansGridView1.Rows[i].Cells["chk"].Value);
                if (isn)
                {
                    string programID =  jeansGridView1.Rows[i].Cells[3].Value.ToString();
                    string programName = jeansGridView1.Rows[i].Cells[4].Value.ToString();
                    var authoritem = authority.FindAll(x => x.Program_ID == programID).ToList();
                    if (authoritem.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        AuthorBooltypeVO authorVO = new AuthorBooltypeVO();
                            authorVO.Program_ID      = programID;
                        authorVO.Program_Name           = programName;
                        authorVO.Module_ID              = authorgropID;
                        authorVO.Method_New             = true;
                        authorVO.Method_Save            =true  ;
                        authorVO.Method_Search          =true  ;
                        authorVO.Method_Delete          =true  ;
                        authorVO.Method_Excel           = true;
                        sb.Add(authorVO);
                    }
                }
            }
            sb= CommonUtil.ChangeAuthorFromMethode(sb);
            authority.AddRange(sb);

            jeansGridView2.DataSource = null;
            jeansGridView2.DataSource = authority;

        }

        private void cboauthgroup_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboauthgroup.SelectedIndex < 1)
                return;
            else if (cboauthgroup.SelectedValue.ToString() == "")
            {
                jeansGridView2.DataSource = null;
                authorgropID = 0;
                return;

             }
            else
            {
                string num = cboauthgroup.SelectedValue.ToString();
                authorgropID = (int.Parse(num));
                BindAuthor();
            }
        }

        private void BindAuthor()
        {
            commonService service1 = new commonService();
            author = service1.Getauthor(authorgropID);

            authority = CommonUtil.ChangeAuthorFromMethode(author);

            jeansGridView2.DataSource = null;
            jeansGridView2.DataSource = authority;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void AuthorManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save -= Save;
            frm.New -= New;
        }
    }
}
