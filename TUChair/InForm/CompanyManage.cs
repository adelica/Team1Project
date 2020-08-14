using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using TUChair.Util;
using TUChair.Service;
using TUChairVO;


namespace TUChair
{
    public partial class CompanyManage : TUChair.SearchCommomForm
    {
        List<CompanyVO> list; //업체 모든 데이터 리스트
        List<ComboItemVO> cList; //업체타입 리스트
        TUChairMain2 frm = new TUChairMain2();

        public CompanyManage()
        {
            InitializeComponent();


            CommonUtil.InitSettingGridView(dgvCompany);
            dgvCompany.IsAllCheckColumnHeader = true;

            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "No.", "No", true, 50, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "업체코드", "Com_Code", true, 150, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "업체명", "Com_Name", true, 150);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "업체타입", "Com_Type", true, 100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "대표자", "Com_Owner", true, 100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "사업자등록번호", "Com_CorporRegiNum", true, 150, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "업종", "Com_Sector", true);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "담당자", "Com_Manager", true, 100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "이메일", "Com_Email", true, 200);
            CommonUtil.AddNewColumnToDataGridView(dgvCompany, "전화번호", "Com_Phone", true, 150);
        }

        private void CompanyManage_Load(object sender, EventArgs e)
        {
            frm = (TUChairMain2)this.MdiParent; //이벤트

            GetComboBinding();
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;

            LoadData();
        }
        private void GetComboBinding()
        {
            commonService service = new commonService();
            List<ComboItemVO> comboItems = service.getCommonCode("업체타입");
            cList = (from item in comboItems
                     where item.CodeType == "업체타입"
                     select item).ToList();
            CommonUtil.ComboBinding(cboCom_Type, cList, "선택");
            CommonUtil.CboSetting(cboCom_Type);
        }
        //전체데이터 조회
        private void LoadData()
        {
            CompanyService service = new CompanyService();
            list = service.GetCompanyInfo();
            dgvCompany.DataSource = list;

        }

        private void dgvCompany_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvCompany.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1);
        }

     

        //등록, 수정
        private void Save(object sender, EventArgs e)
        {
            List<string> codeList = (from code in list
                                     select code.Com_Code).ToList();
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                List<string> chkList = Check();
                bool check=false;
                if (chkList.Count == 1) // 수정
                {
                    List<CompanyVO> updateList = (from com in list
                                                  where com.Com_Code == chkList[0]
                                                  select com).ToList();

                    CompanyInfoRegi frm = new CompanyInfoRegi(cList, codeList, updateList);
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    check = frm.Check;
                }

                else if (chkList.Count == 0) // 신규
                {
                    CompanyInfoRegi frm = new CompanyInfoRegi(cList, codeList);
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    check = frm.Check;
                }
                else //2개 이상 선택
                {
                    MessageBox.Show("수정할 데이터 하나만 선택해주세요", "수정실패");
                    return;
                }
                if (check)
                    LoadData();
            }
        }

        //삭제
        private void Delete(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                List<string> chkList = Check();
                if (chkList.Count == 0)
                {
                    MessageBox.Show("삭제할 데이터를 클릭해주세요.");
                    return;
                }

                if (DialogResult.OK == (MessageBox.Show("정말로 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.OKCancel)))
                {
                    string code = "'" + string.Join("','", chkList) + "'";

                    FactoryService service = new FactoryService();
                    if (service.DeleteFactoryInfo(code))
                    {
                        MessageBox.Show($"{code}이/가 삭제되었습니다.", "삭제완료");
                        LoadData();
                    }
                }
                else
                    return;
            }
        }
        //검색 조건
        private void Search(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                List<CompanyVO> searchList = null;

                if (txtCom_Code.Text.Trim().Length < 1 && txtCom_Name.Text.Trim().Length < 1 && cboCom_Type.SelectedIndex == 0 && txtCom_CorporRegiNum.Text.Trim().Length < 1) // 전체
                {
                    searchList = (from sList in list
                                  select sList).ToList();
                }
                else if (txtCom_Code.Text.Trim().Length > 0 && txtCom_Name.Text.Trim().Length < 1 && cboCom_Type.SelectedIndex == 0 && txtCom_CorporRegiNum.Text.Trim().Length < 1) //1
                {
                    searchList = (from sList in list
                                  where sList.Com_Code.ToUpper().Contains(txtCom_Code.Text.ToUpper())
                                  select sList).ToList();
                }
                else if (txtCom_Code.Text.Trim().Length > 0 && txtCom_Name.Text.Trim().Length > 0 && cboCom_Type.SelectedIndex == 0 && txtCom_CorporRegiNum.Text.Trim().Length < 1)//12
                {
                    searchList = (from sList in list
                                  where sList.Com_Code.ToUpper().Contains(txtCom_Code.Text.ToUpper()) && sList.Com_Name.ToUpper().Contains(txtCom_Name.Text.ToUpper())
                                  select sList).ToList();
                }
                else if (txtCom_Code.Text.Trim().Length > 0 && txtCom_Name.Text.Trim().Length > 0 && cboCom_Type.SelectedIndex != 0 && txtCom_CorporRegiNum.Text.Trim().Length < 1)//123
                {
                    searchList = (from sList in list
                                  where sList.Com_Code.ToUpper().Contains(txtCom_Code.Text.ToUpper()) && sList.Com_Name.ToUpper().Contains(txtCom_Name.Text.ToUpper()) && sList.Com_Type == cboCom_Type.Text
                                  select sList).ToList();
                }
                else if (txtCom_Code.Text.Trim().Length > 0 && txtCom_Name.Text.Trim().Length > 0 && cboCom_Type.SelectedIndex != 0 && txtCom_CorporRegiNum.Text.Trim().Length > 0)//1234
                {
                    searchList = (from sList in list
                                  where sList.Com_Code.ToUpper().Contains(txtCom_Code.Text.ToUpper()) && sList.Com_Name.ToUpper().Contains(txtCom_Name.Text.ToUpper()) && sList.Com_Type == cboCom_Type.Text
                                  && sList.Com_CorporRegiNum.ToUpper().Contains(txtCom_CorporRegiNum.Text.ToUpper())
                                  select sList).ToList();
                }
                else if (txtCom_Code.Text.Trim().Length < 1 && txtCom_Name.Text.Trim().Length > 0 && cboCom_Type.SelectedIndex != 0 && txtCom_CorporRegiNum.Text.Trim().Length > 0)//234
                {
                    searchList = (from sList in list
                                  where sList.Com_Name.ToUpper().Contains(txtCom_Name.Text.ToUpper()) && sList.Com_Type == cboCom_Type.Text && sList.Com_CorporRegiNum.ToUpper().Contains(txtCom_CorporRegiNum.Text.ToUpper())
                                  select sList).ToList();
                }
                else if (txtCom_Code.Text.Trim().Length < 1 && txtCom_Name.Text.Trim().Length < 1 && cboCom_Type.SelectedIndex != 0 && txtCom_CorporRegiNum.Text.Trim().Length > 0)//34
                {
                    searchList = (from sList in list
                                  where sList.Com_Type == cboCom_Type.Text && sList.Com_CorporRegiNum.ToUpper().Contains(txtCom_CorporRegiNum.Text.ToUpper())
                                  select sList).ToList();
                }
                else if (txtCom_Code.Text.Trim().Length < 1 && txtCom_Name.Text.Trim().Length < 1 && cboCom_Type.SelectedIndex == 0 && txtCom_CorporRegiNum.Text.Trim().Length > 0)//4
                {
                    searchList = (from sList in list
                                  where sList.Com_CorporRegiNum.ToUpper().Contains(txtCom_CorporRegiNum.Text.ToUpper())
                                  select sList).ToList();
                }
                else if (txtCom_Code.Text.Trim().Length > 0 && txtCom_Name.Text.Trim().Length < 1 && cboCom_Type.SelectedIndex != 0 && txtCom_CorporRegiNum.Text.Trim().Length < 1) //13
                {
                    searchList = (from sList in list
                                  where sList.Com_Code.ToUpper().Contains(txtCom_Code.Text.ToUpper()) && sList.Com_Type == cboCom_Type.Text
                                  select sList).ToList();
                }
                else if (txtCom_Code.Text.Trim().Length > 0 && txtCom_Name.Text.Trim().Length < 1 && cboCom_Type.SelectedIndex != 0 && txtCom_CorporRegiNum.Text.Trim().Length > 0) //134
                {
                    searchList = (from sList in list
                                  where sList.Com_Code.ToUpper().Contains(txtCom_Code.Text.ToUpper()) && sList.Com_Type == cboCom_Type.Text && sList.Com_CorporRegiNum.ToUpper().Contains(txtCom_CorporRegiNum.Text.ToUpper())
                                  select sList).ToList();
                }
                else if (txtCom_Code.Text.Trim().Length > 0 && txtCom_Name.Text.Trim().Length < 1 && cboCom_Type.SelectedIndex == 0 && txtCom_CorporRegiNum.Text.Trim().Length > 0) //14
                {
                    searchList = (from sList in list
                                  where sList.Com_Code.ToUpper().Contains(txtCom_Code.Text.ToUpper()) && sList.Com_CorporRegiNum.ToUpper().Contains(txtCom_CorporRegiNum.Text.ToUpper())
                                  select sList).ToList();
                }
                else if (txtCom_Code.Text.Trim().Length > 0 && txtCom_Name.Text.Trim().Length > 0 && cboCom_Type.SelectedIndex == 0 && txtCom_CorporRegiNum.Text.Trim().Length > 0)//124
                {
                    searchList = (from sList in list
                                  where sList.Com_Code.ToUpper().Contains(txtCom_Code.Text.ToUpper()) && sList.Com_Name.ToUpper().Contains(txtCom_Name.Text.ToUpper()) && sList.Com_CorporRegiNum.ToUpper().Contains(txtCom_CorporRegiNum.Text.ToUpper())
                                  select sList).ToList();
                }
                else if (txtCom_Code.Text.Trim().Length < 1 && txtCom_Name.Text.Trim().Length > 0 && cboCom_Type.SelectedIndex != 0 && txtCom_CorporRegiNum.Text.Trim().Length < 1)//23
                {
                    searchList = (from sList in list
                                  where sList.Com_Name.ToUpper().Contains(txtCom_Name.Text.ToUpper()) && sList.Com_Type == cboCom_Type.Text
                                  select sList).ToList();
                }
                else if (txtCom_Code.Text.Trim().Length < 1 && txtCom_Name.Text.Trim().Length > 0 && cboCom_Type.SelectedIndex == 0 && txtCom_CorporRegiNum.Text.Trim().Length > 0)//24
                {
                    searchList = (from sList in list
                                  where sList.Com_Name.ToUpper().Contains(txtCom_Name.Text.ToUpper()) && sList.Com_CorporRegiNum.ToUpper().Contains(txtCom_CorporRegiNum.Text.ToUpper())
                                  select sList).ToList();
                }

                else if (txtCom_Code.Text.Trim().Length < 1 && txtCom_Name.Text.Trim().Length > 0 && cboCom_Type.SelectedIndex == 0 && txtCom_CorporRegiNum.Text.Trim().Length < 1)//2
                {
                    searchList = (from sList in list
                                  where sList.Com_Name.ToUpper().Contains(txtCom_Name.Text.ToUpper())
                                  select sList).ToList();
                }

                else if (txtCom_Code.Text.Trim().Length < 1 && txtCom_Name.Text.Trim().Length < 1 && cboCom_Type.SelectedIndex != 0 && txtCom_CorporRegiNum.Text.Trim().Length < 1)//3
                {
                    searchList = (from sList in list
                                  where sList.Com_Type == cboCom_Type.Text
                                  select sList).ToList();
                }
                if (searchList.Count < 1)
                {
                    MessageBox.Show("해당하는 정보가 존재하지 않습니다.", "검색실패");
                    dgvCompany.DataSource = list;
                    return;
                }
                dgvCompany.DataSource = searchList;
            }
        }
        //체크박스 체크확인
        private List<String> Check()
        {
            List<string> chkList = new List<string>();

            for (int i = 0; i < dgvCompany.Rows.Count; i++)
            {
                bool IsCellChecked = (bool)dgvCompany.Rows[i].Cells[0].EditedFormattedValue;
                if (IsCellChecked)
                {
                    chkList.Add(dgvCompany.Rows[i].Cells[2].Value.ToString());
                }
            }
            return chkList;
        }
        //조회
        private void New(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                LoadData();
            }
        }

        private void CompanyManage_FormClosing(object sender, FormClosingEventArgs e)
        {

            frm.Save -= Save;
            frm.Search -= Search;
            frm.Delete -= Delete;
            frm.New -= New;
        }

     
    }
}
