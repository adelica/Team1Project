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
    public partial class BalzuManager : TUChair.SearchCommomForm
    {
        List<BOMVO> BOM = null;
        List<ComboItemVO> comboItems = null;
        DataTable dt=null;
        public BalzuManager()
        {
            InitializeComponent();
        }

        private void BalzuManager_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
            commonService service = new commonService();
            comboItems = service.getCommonCode("@PlanID@사용여부");

            List<ComboItemVO> cList = (from item in comboItems
                                       where item.CodeType == "PlanID"
                                       orderby item.CodeNm ascending
                                       select item).ToList();
            CommonUtil.ComboBinding(cboplanID, cList);
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
            if (cboplanID.Text.Length <= 0)
            {
                MessageBox.Show("조회할 PlanID를 선택해주세요");
                  return;
            }
            balzuService service = new balzuService();
            dt = service.GetBalzuItem(cboplanID.Text,inDTP1.Start,inDTP1.End);
            dataGridView1.DataSource = dt;
        }

        private void Save(object sender, EventArgs e)
        {
            BalzuPopUp frm = new BalzuPopUp(cboplanID.Text);
            
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }

        }
    }
}
