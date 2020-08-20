using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;
using TUChair.WooForm;
using TUChairVO;

namespace TUChair
{
    public partial class AuthoGroupManager : SearchCommomForm
    {
        List<AuthorGroupVO> authorGroups = null;
        List<ComboItemVO> comboItems = null;
        public AuthoGroupManager()
        {
            InitializeComponent();
        }

        private void AuthoGroupManager_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;

            commonService service = new commonService();
            comboItems = service.getCommonCode("AuthorGroup@사용여부");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "AuthorGroup"
                                       select item).ToList();
            CommonUtil.ComboBinding(cboAuthorGroup, cList, "선택");

            cList = (from item in comboItems
                     where item.CodeType == "사용여부"
                     select item).ToList();
            CommonUtil.ReComboBinding(cboUseOrNot, cList, "선택");

            jeansGridView1.IsAllCheckColumnHeader = true;
            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "권한그룹아이디", "AuthorGroup_ID", true, 100, DataGridViewContentAlignment.MiddleRight);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "권한그룹명", "AuthorGroup_Name", true, 200);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "권한그룹설명", "AuthorGroup_Explanation", true, 250);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "권한그룹순서", "AuthorGroup_Order", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "사용여부", "AuthorGroup_UseOrNot", true);

            BindingData();
        }

        private void BindingData()
        {
            AuthorService service1 = new AuthorService();
            authorGroups = service1.GetAllAuthorGroup();
            jeansGridView1.DataSource = null;
            jeansGridView1.DataSource = authorGroups;
        }

        private void Search(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Delete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void New(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                {
                    int cnt = 0;
                    int row = 0;
                    jeansGridView1.EndEdit();
                    for (int i = 0; i < jeansGridView1.Rows.Count; i++)
                    {
                        bool isbool = Convert.ToBoolean(jeansGridView1.Rows[i].Cells["chk"].Value);
                        if (isbool)
                        { cnt++; row = i; }
                    }

                    if (cnt == 0)
                    {
                        AuthorGroupPopUp frm = new AuthorGroupPopUp();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            BindingData();
                        }
                    }
                    else if (cnt > 1)
                    {
                        MessageBox.Show("수정은 하나씩만 가능합니다.");
                        return;
                    }
                    else
                    {
                        AuthorGroupVO pItem = new AuthorGroupVO();
                        pItem.AuthorGroup_ID = Convert.ToInt32(jeansGridView1.Rows[row].Cells[2].Value);
                        pItem.AuthorGroup_Name = jeansGridView1.Rows[row].Cells[10].Value.ToString();
                        pItem.AuthorGroup_Explanation = jeansGridView1.Rows[row].Cells[7].Value.ToString();
                        pItem.AuthorGroup_Order = Convert.ToInt32(jeansGridView1.Rows[row].Cells[13].Value);
                        pItem.AuthorGroup_UseOrNot
                            = jeansGridView1.Rows[row].Cells[3].Value.ToString();

                        //ItemPopUp frm = new ItemPopUp(userID);
                        //frm.Item = pItem;
                        //if (frm.ShowDialog() == DialogResult.OK)
                        //{
                        //    BindingData();
                        //}
                    }
                }
            }
        }
    }
}
