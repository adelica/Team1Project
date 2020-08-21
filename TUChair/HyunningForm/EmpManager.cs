using DevExpress.Charts.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.HyunningForm;
using TUChair.Service;
using TUChair.Util;
using TUChairVO;

namespace TUChair
{
    public partial class EmpManager : TUChair.SearchCommomForm
    {
        string upInsert;
        public string uporInsert { get; set; }

        public EmpVO Emp { get; set; }
        List<EmpVO> list;
        public EmpManager()
        {
            InitializeComponent();

            jeansGridView1.IsAllCheckColumnHeader = true;
            CommonUtil.InitSettingGridView(jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "사번", "CUser_ID", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "권한 아이디", "AuthorGroup_ID", true,100,DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "이름", "CUser_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "비밀번호", "CUser_PWD", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "사용여부", "CUser_UseOrNot", true);
            DataLoad();
        }

        private void EmpManager_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
        }
        public void DataLoad()
        {
            EmpService jean = new EmpService();
            list = jean.EmpBinding();

            jeansGridView1.DataSource = list;
        }

        private void EmpManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save -= Save;
            frm.Search -= Search;
            frm.Delete -= Delete;
            frm.New -= New;
            frm.Excel -= Excel;
        }
        private void Search(object sender, EventArgs e)
        {
            if (txtID.ToString().Trim().Length < 1 && txtName.ToString().Trim().Length < 1)
                return;
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                EmpService service = new EmpService();
                list = service.EmpSearch(txtID.Text, txtName.Text);
                jeansGridView1.DataSource = null;
                jeansGridView1.DataSource = list;
            }

        }
        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
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
                string userID = ((TUChairMain2)this.MdiParent).userInfoVO.CUser_ID;
                if (cnt == 0)
                {
                    upInsert = "Insert";
                    ShiftPopUpForm frm = new ShiftPopUpForm();
                    frm.Owner = this;
                    //shiftPop.uptdic = updatedic;
                    frm.uporInsert = upInsert;

                    // shiftPop.sendshiftlist = shiftCbolist;
                    // shiftPop.sendlist = FaciCodeList;
                    frm.ShowDialog();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        DataLoad();
                    }
                }
                else if (cnt > 1)
                {
                    MessageBox.Show("수정은 하나씩만 가능합니다.");
                    return;
                }
                else
                {
                    upInsert = "Update";

                    EmpVO shifti = new EmpVO();
                    shifti.CUser_ID = jeansGridView1.Rows[row].Cells[1].Value.ToString();
                    shifti.AuthorGroup_ID = Convert.ToInt32(jeansGridView1.Rows[row].Cells[2].Value);
                    shifti.CUser_Name = jeansGridView1.Rows[row].Cells[3].Value.ToString();
                    shifti.CUser_PWD = jeansGridView1.Rows[row].Cells[4].Value.ToString();
                    shifti.CUser_UseOrNot = jeansGridView1.Rows[row].Cells[5].ToString();

                   

                    EmpManagerPopUp shiftPop = new EmpManagerPopUp();
                    shiftPop.Owner = this;
                    //shiftPop.uptdic = updatedic;
                    shiftPop.uporInsert = upInsert;
                    shiftPop.Emp = shifti;
                    // shiftPop.sendshiftlist = shiftCbolist;
                    // shiftPop.sendlist = FaciCodeList;
                    shiftPop.StartPosition = FormStartPosition.CenterParent;
                    shiftPop.ShowDialog();
                }
            }


            DataLoad();
        }
        private void New(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                DataLoad();
            }
        }
        private void Delete(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("삭제하던가");

        }
        private void Excel(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                using (waitFrm frm = new waitFrm(ExportOrderList))
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog(this);
                }
            }
        }

        private void ExportOrderList()
        {
            string sResult = ExcelExportImport.ExportToDataGridView<EmpVO>(
                (List<EmpVO>)jeansGridView1.DataSource, "");
            if (sResult.Length > 0)
            {
                MessageBox.Show(sResult);
            }
        }
    }
}
