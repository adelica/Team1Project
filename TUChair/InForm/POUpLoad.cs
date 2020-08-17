using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChair.Util;
using TUChairVO;
using TUChair.Service;


namespace TUChair
{
    public partial class POUpLoad : Form//------------하는 중
    {
        DataTable poData = null;
        List<string> salesID;

        public POUpLoad()
        {
            InitializeComponent();
            CommonUtil.InitSettingGridView(dgvPO);
            dgvPO.AutoGenerateColumns = true;
            dgvPO.IsAllCheckColumnHeader = true;

            CommonUtil.AddNewColumnToDataGridView(dgvPO, "planDate", "planDate", true, 150, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "순번", "순번", true, 70, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "WORK_ORDER_ID", "WORK_ORDER_ID", true, 200, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "업체코드", "업체 CODE", true, 150, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "납품처", "납품처", true, 100, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "SIZE", "SIZE", true, 130, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "품명", "품명", true, 120, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "계획수량합계", "계획수량합계", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "납기일", "납기일", true, 150, DataGridViewContentAlignment.MiddleCenter);

            CommonUtil.AddNewColumnToDataGridView(dgvPO, "Sales_ID", "Sales_ID", false);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "입고P/NO", "입고P/NO", false, 120, DataGridViewContentAlignment.MiddleCenter);

        }

        private void btnPOUpLoad_Click(object sender, EventArgs e)
        {

        }

        private void POUpLoad_Load(object sender, EventArgs e)
        {
            CheckSalesID();
            dgvPO.DataSource = poData;
        }
        //파일 다운로드
        private bool FileDownload(String url, String path)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("ContentType", "application/vnd.ms-excel");
                webClient.DownloadFile(url, path);
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "다운로드 실패");
                return false;
            }

        }
        //발주서 양식 다운로드
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == (MessageBox.Show("양식을 다운로드하시겠습니까?", "다운로드 확인", MessageBoxButtons.OKCancel)))
            {
                string url = @"http://www.anypoint.co.kr/TUChair.xlsx";
                string path = "\\TUChair.xlsx";
                if (FileDownload(url, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + path))
                {
                    MessageBox.Show("다운로드를 완료하였습니다.", "다운로드 완료");
                }
            }
            else
                return;
        }
        //체크확인
        private List<String> Check()
        {
            List<string> chkList = new List<string>();

            for (int i = 0; i < dgvPO.Rows.Count; i++)
            {
                bool IsCellChecked = (bool)dgvPO.Rows[i].Cells[0].EditedFormattedValue;
                if (IsCellChecked)
                {
                    chkList.Add(dgvPO.Rows[i].Cells[3].Value.ToString());
                }
            }
            return chkList;
        }

        //SalesID 중복확인용
        private void CheckSalesID()
        {
            POSOService service = new POSOService();
            salesID = service.CheckSalesID();
        }

        private bool CheckSalesID(string id)
        {
            List<string> chk = (from check in salesID
                                where check == id
                                select check).ToList();
            if (chk.Count > 0)
                return true;
            else
                return false;
        }

        //Excel 등록
        private void btnExcel_Click(object sender, EventArgs e)
        {
            PORegi frm = new PORegi();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.Check)
            {
                MessageBox.Show("등록되었습니다.", "등록완료");
                poData = frm.POUpLoad;
                dgvPO.DataSource = poData;
            }
        }

        //영업마스터 생성
        private void btnPOUpLoad_Click_1(object sender, EventArgs e)
        {
            if (dgvPO.Rows.Count < 1)
            {
                MessageBox.Show("업로드할 발주서를 등록해주세요.", "업로드 실패");
                return;
            }

            List<UpLoadVO> upList = new List<UpLoadVO>();
            if (CheckSalesID(dgvPO.Rows[0].Cells[10].Value.ToString()))
            {
                if (DialogResult.OK == (MessageBox.Show("이미 존재하는 계획입니다. 덮어씌우겠습니까?", "중복확인", MessageBoxButtons.OKCancel)))
                {
                    for (int i = 0; i < dgvPO.Rows.Count; i++)
                    {
                        upList[i].Sales_Plandate = Convert.ToDateTime(dgvPO.Rows[i].Cells[1].Value);
                        upList[i].So_WorkOrderID = dgvPO.Rows[i].Cells[3].Value.ToString();
                        upList[i].Com_Code = dgvPO.Rows[i].Cells[4].Value.ToString();
                        upList[i].Item_Code = dgvPO.Rows[i].Cells[7].Value.ToString();
                        upList[i].Sales_Qty = Convert.ToInt32(dgvPO.Rows[i].Cells[8].Value);
                        upList[i].So_Duedate = Convert.ToDateTime(dgvPO.Rows[i].Cells[9].Value);
                        upList[i].Sales_ID = dgvPO.Rows[i].Cells[10].Value.ToString();
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                for (int i = 0; i < dgvPO.Rows.Count; i++)
                {
                    upList[i].Sales_Plandate = Convert.ToDateTime(dgvPO.Rows[i].Cells[1].Value);
                    upList[i].So_WorkOrderID = dgvPO.Rows[i].Cells[3].Value.ToString();
                    upList[i].Com_Code = dgvPO.Rows[i].Cells[4].Value.ToString();
                    upList[i].Item_Code = dgvPO.Rows[i].Cells[7].Value.ToString();
                    upList[i].Sales_Qty = Convert.ToInt32(dgvPO.Rows[i].Cells[8].Value);
                    upList[i].So_Duedate = Convert.ToDateTime(dgvPO.Rows[i].Cells[9].Value);
                    upList[i].Sales_ID = dgvPO.Rows[i].Cells[10].Value.ToString();
                }
            }
            POSOService service = new POSOService();
            bool check = service.SetPOData(upList);
        }
    }
}
