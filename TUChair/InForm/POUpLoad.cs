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


namespace TUChair
{
    public partial class POUpLoad : Form//------------하는 중
    {
        DataTable poData = null;

        public POUpLoad()
        {
            InitializeComponent();
           CommonUtil.InitSettingGridView(dgvPO);
            dgvPO.AutoGenerateColumns = true;
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "planDate", "planDate", true,150,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "순번", "순번", true, 70, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "WORK_ORDER_ID", "WORK_ORDER_ID", true, 200, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "업체코드", "업체 CODE", true,150, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "납품처", "납품처", true,100, DataGridViewContentAlignment.MiddleCenter);

            CommonUtil.AddNewColumnToDataGridView(dgvPO, "SIZE", "SIZE", true,130, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "입고P/NO", "입고P/NO", true,120, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "품명", "품명", true,120, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "계획수량합계", "계획수량합계", true,100,DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "납기일", "납기일", true,150, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddNewColumnToDataGridView(dgvPO, "Sales_ID", "Sales_ID", false);


        }

        private void btnPOUpLoad_Click(object sender, EventArgs e)
        {
            PORegi frm = new PORegi();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if(frm.Check)
            {
                MessageBox.Show("등록되었습니다.", "등록완료");
                poData = frm.POUpLoad;
                dgvPO.DataSource = poData;
            }
        }

        private void POUpLoad_Load(object sender, EventArgs e)
        {
            dgvPO.DataSource = poData;
        }

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
                MessageBox.Show(err.Message,"다운로드 실패");

                return false;
            }

        }

        private void btnDownload_Click(object sender, EventArgs e)//---------------안됨
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
    }
}
