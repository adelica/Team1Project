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
    public partial class BOMManage : TUChair.SearchCommomForm
    {
        List<BOMVO> BOM = null;
        List<ComboItemVO> comboItems = null;
        public BOMManage()
        {
            InitializeComponent();
        }

        private void BOMManage_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
            commonService service = new commonService();
            comboItems = service.getCommonCode("@사용여부@BOM");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "사용여부"
                                       select item).ToList();
            CommonUtil.ComboBinding(cboUseOrNot, cList, "선택");
       
            cList = (from item in comboItems
                     where item.CodeType == "BOM"
                     select item).ToList();
            CommonUtil.ComboBinding(cboBOMType, cList, "선택");

            dtpDate.Value = DateTime.Now;

            jeansGridView1.IsAllCheckColumnHeader = true;
            
            CommonUtil.InitSettingGridView(jeansGridView1);
            // CommonUtil.DataGridViewCheckBoxSet("", jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "bom번호", "BOM_No", false);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "상위코드", "ParentItem_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "INFO", true,200);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "ItemCode", true,200);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "타입", "Item_Type", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "소요량", "BOM_Require", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "레벨", "Lvl", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "시작일자", "BOM_StartDate", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "완료일자", "BOM_EndDate", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "사용여부", "BOM_UserOrNot", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정자", "BOM_Modifier", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수정일자", "BOM_ModifiyDate", true);

            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "자동차감", "BOM_AutoDeducion", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "소요계획", "BOM_RequirePlan", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "비고", "BOM_Others", true);

            BOMService service1 = new BOMService();
            BOM = service1.getALLBom();

            jeansGridView1.DataSource = BOM;


        }

        private void BOMManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save -= Save;
            frm.Search -= Search;
            frm.Delete -= Delete;
            frm.New -= New;
            frm.Excel -= Excel;
        }

        private void Excel(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        private void Save(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
