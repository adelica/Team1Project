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
    }
}
