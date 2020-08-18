using DevExpress.DirectX.Common.Direct2D;
using DevExpress.XtraReports.Design.Snapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;
using TUChairVO;

namespace TUChair
{
    public partial class POManage : TUChair.SearchCommomForm
    {
        List<POVO> list;
        List<SOVO> sList;
        TUChairMain2 frm = new TUChairMain2();

        public POManage()
        {
            InitializeComponent();
            CommonUtil.InitSettingGridView(dgvPO);
            dgvPO.IsAllCheckColumnHeader = true;

            CommonUtil.AddNewColumnToDataGridView(dgvPO, "No.", "No", true, 50,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "고객 WO", "So_WorkOrderID", true, 200,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "고객주문번호", "So_PurchaseOrder", true, 200, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "고객사코드", "Com_Code", true,120, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "고객사명", "Com_Name", true,100, DataGridViewContentAlignment.MiddleCenter);

            CommonUtil.AddNewColumnToDataGridView(dgvPO, "품목", "Item_Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "품명", "Item_Name", true,100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "생산납기일", "So_Duedate", true,150, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "주문수량", "So_Qty", true,100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "출고수량", "So_ShipQty", true,100, DataGridViewContentAlignment.MiddleRight);

            LoadData();
        }

        private void LoadData()
        {
            POSOService service = new POSOService();
            list = service.GetPOData();
            sList = service.GetSOData();
            dgvPO.DataSource = list;
        }

        //영업마스터생성 팝업
        private void btnPOUpLoad_Click(object sender, EventArgs e) 
        {
            PORegi frm = new PORegi();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        //수요계획생성 팝업
        private void btnSORegi_Click(object sender, EventArgs e)
        {
            SORegi frm = new SORegi();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if(frm.Check)
            {
                LoadData();
            }
        }
        private void GetComboBinding()
        {
            List<string> cboList = (from code in list
                                    select code.Com_Code).Distinct().ToList();
            cboCustomer.Items.Add("전체");
            foreach(var list in cboList)
            {
                cboCustomer.Items.Add(list);
            }
            CommonUtil.CboSetting(cboCustomer);
        }

        //두 번째 줄에 번호주기
        private void dgvPO_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvPO.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }

        //체크박스에 체크된 설비 코드
        private List<String> Check()
        {
            List<string> chkList = new List<string>();

            for (int i = 0; i < dgvPO.Rows.Count; i++)
            {
                bool IsCellChecked = (bool)dgvPO.Rows[i].Cells[0].EditedFormattedValue;
                if (IsCellChecked)
                {
                    chkList.Add(dgvPO.Rows[i].Cells[2].Value.ToString());
                }
            }
            return chkList;
        }

        private void POManage_Load(object sender, EventArgs e)
        {
            GetComboBinding();
            frm = (TUChairMain2)this.MdiParent;
            frm.New += New;
            frm.Delete += Delete;
            frm.Save += Save;
        }

        private void Save(object sender, EventArgs e)
        {
            List<string> chkList = Check();
            if(chkList.Count<1)
            {
                MessageBox.Show("수정할 데이터를 선택하여주세요", "수정실패");
                return;
            }
            else if(chkList.Count==1)
            {
                POSOService service = new POSOService();
                List<SOVO> soList = (from sL in sList
                                     where sL.So_WorkOrderID == chkList[0]
                                     select sL).ToList();
                SORegi frm = new SORegi(soList);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if(frm.Check)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("데이터를  하나만 선택하여주세요", "수정실패");
                return;
            }
        }

        //삭제
        private void Delete(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                List<string> chkList = Check();
                if(chkList.Count<1)
                {
                    MessageBox.Show("삭제할 데이터를 선택하여 주세요", "삭제실패");
                    return;
                }
                if(DialogResult.OK==(MessageBox.Show("정말 삭제하시겠습니까?","삭제확인",MessageBoxButtons.OKCancel)))
                {
                    string code = "'" + string.Join("','", chkList) + "'";
                    POSOService service = new POSOService();
                    if(service.DeleteSOInfo(code))
                    {
                        MessageBox.Show($"{code}이/가 삭제되었습니다.", "삭제완료");
                        LoadData();
                    }
                }
            }
        }

        //조회
        private void New(object sender, EventArgs e)
        {
          if(((TUChairMain2)this.MdiParent).ActiveMdiChild==this)
            {
                LoadData();
            }
        }

        private void POManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.New -= New;
            frm.Delete -= Delete;
            frm.Save -= Save;
        }
    }
}
