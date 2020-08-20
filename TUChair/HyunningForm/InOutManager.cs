using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;
using TUChairVO;

namespace TUChair
{
    public partial class InOutManager : TUChair.SearchCommomForm
    {

        List<InOutVo> Inoutlist;
        List<ComboItemVO> comboItems = null;

        public InOutManager()
        {
            InitializeComponent();

            jeansGridView1.IsAllCheckColumnHeader = true;
            CommonUtil.InitSettingGridView(jeansGridView1);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "입출고일", "Shift_date", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "구분", "Gubun", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "카테고리", "Category", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "From창고", "From_Fact", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "창고", "Fact_Code", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목", "Item_Code", true,160);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품명", "item_Name", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "규격", "Item_Size", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "품목형태", "Item_Type", true);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "수불량", "Shift_Qty", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "단가", "Price_Present", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "금액", "Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddNewColumnToDataGridView(jeansGridView1, "등록자", "Modifier", true);



            commonService service = new commonService();

            comboItems = service.getCommonCode("창고@재고상태@품목유형@Item");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "창고"
                                       select item).ToList();
            CommonUtil.ReComboBinding(cboFact, cList, "선택");
            cList = (from item in comboItems
                     where item.CodeType == "재고상태"
                     select item).ToList();
            cList = cList.Distinct().ToList();
            CommonUtil.ReComboBinding(cboGubun, cList, "선택");
            cList = (from item in comboItems
                     where item.CodeType == "재고상태"
                     select item).ToList();
            CommonUtil.ComboBinding(cboCategory, cList, "선택");

            cList = (from item in comboItems
                     where item.CodeType == "품목유형"
                     select item).ToList();
            CommonUtil.ComboBinding(cboItemtype, cList, "선택");
            
            cList = (from item in comboItems
                     where item.CodeType == "Item"
                     select item).ToList();
            CommonUtil.ReComboBinding(cboItemCode, cList, "선택");


            DataLoad();
        }
        private void Search(object sender, EventArgs e)
        {
          
                string Fact;
                if (cboFact.SelectedIndex == 0)
                    Fact = string.Empty;
                else
                    Fact = cboFact.Text;
                string Gubun;
                if (cboGubun.SelectedIndex == 0)
                    Gubun = string.Empty;
                else
                    Gubun = cboGubun.Text;
                string Category;
                if (cboCategory.SelectedIndex == 0)
                    Category = string.Empty;
                else
                    Category = cboCategory.Text;
                string itype;
                if (cboItemtype.SelectedIndex == 0)
                    itype = string.Empty;
                else
                    itype = cboItemtype.Text;
                string start = inDTP1.Start.ToShortDateString();
                string end = inDTP1.End.ToShortDateString();

                string Icode;
                if (cboItemCode.SelectedIndex == 0)
                   Icode = string.Empty;
                else
                    Icode = cboItemCode.Text;


                if (cboFact.SelectedIndex == 0 && cboItemCode.SelectedIndex == 0 && cboGubun.SelectedIndex == 0 && cboCategory.SelectedIndex == 0 && cboItemtype.SelectedIndex == 0)
                    return;
                if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                {
                    JeanServicePShift service = new JeanServicePShift();
                    Inoutlist = service.InOutSearch(Fact, Gubun , Category, itype, start, end, Icode);
                    jeansGridView1.DataSource = null;
                    jeansGridView1.DataSource = Inoutlist;
                }
            
        }
        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("헤헤 수정");

            DataLoad();
        }
        private void New(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                cboFact.SelectedIndex = 0;
                cboItemCode.SelectedIndex = 0;
                cboGubun.SelectedIndex = 0;
                cboCategory.SelectedIndex = 0;
                cboItemtype.SelectedIndex = 0;


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
                MessageBox.Show("엑셀만들어");
        }

        private void InOutManager_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
        }

        private void DataLoad()
        {
            JeanServicePShift jean = new JeanServicePShift();
            Inoutlist = jean.InOutBinding();

            jeansGridView1.DataSource = Inoutlist;
        }

        private void InOutManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save -= Save;
            frm.Search -= Search;
            frm.Delete -= Delete;
            frm.New -= New;
            frm.Excel -= Excel;
        
        }
            
    }
}
