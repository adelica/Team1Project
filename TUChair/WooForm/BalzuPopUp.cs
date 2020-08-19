using DevExpress.Office.Utils;
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
using TUChairVO;

namespace TUChair
{
    public partial class BalzuPopUp : Form
    {
        List<PbalzuVO> listbalzu = null;
        public string planID { get; set; }
        public BalzuPopUp()
        {
            InitializeComponent();
        }
        public BalzuPopUp(string planID)
        {
            InitializeComponent();
            this.planID = planID;
        }

        private void BalzuPopUp_Load(object sender, EventArgs e)
        {
            commonService service = new commonService();
            List<ComboItemVO> comboItems = service.getCommonCode("@사용여부@협력업체");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "협력업체"
                                       orderby item.CodeNm descending
                                       select item).ToList();

            CommonUtil.InitSettingGridView(dgvcom);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(dgvcom, "업체코드", "Code", true);
            CommonUtil.AddNewColumnToDataGridView(dgvcom, "업체명", "CodeNm", true);
            CommonUtil.AddNewColumnToDataGridView(dgvcom, "업체타입", "CodeType", true);
            dgvcom.DataSource = cList;

            dgvbalzu.IsAllCheckColumnHeader = true;

            CommonUtil.InitSettingGridView(dgvbalzu);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(dgvbalzu, "회사명", "Com_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvbalzu, "회사타입", "Com_Type", true);
            CommonUtil.AddNewColumnToDataGridView(dgvbalzu, "사업자등록번호", "Com_CorporRegiNum", true);
            CommonUtil.AddNewColumnToDataGridView(dgvbalzu, "품목명", "Item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(dgvbalzu, "품목", "Item_Code", true, 200);
            CommonUtil.AddNewColumnToDataGridView(dgvbalzu, "규격", "Item_Size", true, 200);
            CommonUtil.AddNewColumnToDataGridView(dgvbalzu, "수량", "Qty", true);
            CommonUtil.AddNewColumnToDataGridView(dgvbalzu, "납기일", "duedate", true);
            CommonUtil.AddNewColumnToDataGridView(dgvbalzu, "단가", "Price_Present", true);
            CommonUtil.AddNewColumnToDataGridView(dgvbalzu, "총금액", "Price", true);

            CommonUtil.AddNewColumnToDataGridView(dgvbalzu, "발주여부", "isbalzu", true);

            balzuService service1 = new balzuService();
            listbalzu= service1.GetBalzuItemList(this.planID);
            List<PbalzuVO> list = (from item in listbalzu
                                   where item.isbalzu == "N"
                                   select item).ToList();


            dgvbalzu.DataSource = list;


        }

        private void btnFInsert_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            int row = 0;
            dgvbalzu.EndEdit();
            for (int i = 0; i < dgvbalzu.Rows.Count; i++)
            {
                bool isbool = Convert.ToBoolean(dgvbalzu.Rows[i].Cells["chk"].Value);
                if (isbool)
                { cnt++; row = i; }
            }
            string userID = ((TUChairMain2)this.MdiParent).userInfoVO.CUser_ID;
             if (cnt > 1)
            {
                MessageBox.Show("수정은 하나씩만 가능합니다.");
                return;
            }
            else
            {
                //balzuVO pItem = new balzuVO();
                //pItem.Item_Code = dgvbalzu.Rows[row].Cells[2].Value.ToString();
                //pItem.Item_Importins = dgvbalzu.Rows[row].Cells[10].Value == null ? "" : dgvbalzu.Rows[row].Cells[10].Value.ToString();
                //pItem.Item_InWarehouse = dgvbalzu.Rows[row].Cells[7].Value == null ? "" : dgvbalzu.Rows[row].Cells[7].Value.ToString();
                //pItem.Item_Manager = dgvbalzu.Rows[row].Cells[13].Value == null ? "" : dgvbalzu.Rows[row].Cells[13].Value.ToString();
                //pItem.Item_Name = dgvbalzu.Rows[row].Cells[3].Value == null ? "" : dgvbalzu.Rows[row].Cells[3].Value.ToString();
                //pItem.Item_OrderComp = dgvbalzu.Rows[row].Cells[6].Value == null ? "" : dgvbalzu.Rows[row].Cells[6].Value.ToString();
                //pItem.Item_Other = dgvbalzu.Rows[row].Cells[18].Value == null ? "" : dgvbalzu.Rows[row].Cells[18].Value.ToString();
                //pItem.Item_OutWarehouse = dgvbalzu.Rows[row].Cells[8].Value == null ? "" : dgvbalzu.Rows[row].Cells[8].Value.ToString();
                //pItem.Item_Processins = dgvbalzu.Rows[row].Cells[11].Value == null ? "" : dgvbalzu.Rows[row].Cells[11].Value.ToString();
                //pItem.Item_SafeQuantity = Convert.ToInt32(dgvbalzu.Rows[row].Cells[9].Value);
                //pItem.Item_Shipmentins = dgvbalzu.Rows[row].Cells[12].Value == null ? "" : dgvbalzu.Rows[row].Cells[12].Value.ToString();
                //pItem.Item_Size = dgvbalzu.Rows[row].Cells[4].Value == null ? "" : dgvbalzu.Rows[row].Cells[4].Value.ToString();
                //pItem.Item_Type = dgvbalzu.Rows[row].Cells[1].Value == null ? "" : dgvbalzu.Rows[row].Cells[1].Value.ToString();
                //pItem.Item_Unit = dgvbalzu.Rows[row].Cells[5].Value == null ? "" : dgvbalzu.Rows[row].Cells[5].Value.ToString();
                //pItem.Item_UserOrNot = dgvbalzu.Rows[row].Cells[17].Value == null ? "" : dgvbalzu.Rows[row].Cells[17].Value.ToString();
                //pItem.Item_OutSourcing = dgvbalzu.Rows[row].Cells[16].Value == null ? "" : dgvbalzu.Rows[row].Cells[16].Value.ToString();

                //ItemPopUp frm = new ItemPopUp(userID);
                //frm.Item = pItem;

                //Com_Name
                //Com_Type
                //Item_Name
                //Item_Code
                //Item_Size

                //Qty
                //duedate
                //isbalzu
                //Com_CorporRegiNum
                //Price_Present
                //price


            }
        }
    }
}
