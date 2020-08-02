using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChairVO;
using System.Reflection;
using TUChair.Service;

namespace TUChair
{
    public partial class ItemManage : TUChair.SearchCommomForm
    {
        
        List<ItemVO> items = null;
        List<ComboItemVO> comboItems = null;

        public ItemManage()
        {
            InitializeComponent();
        }

        private void ItemManage_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            frm.Excel += Excel;
            commonService service = new commonService();
            comboItems= service.getCommonCode("발주업체@창고@고객사@User@사용여부@품목유형");
            List<ComboItemVO> item = new List<ComboItemVO>();

        }
        private void Save(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("저장이다2.");
        }
        private void New(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("새로고쳐.");
        }
        private void Search(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
            {
                GetSearchCondition();
            }
        }

        private void GetSearchCondition()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Control item in panel1.Controls)
            {
                if (item is TextBox || item is ComboBox)
                {
                    if (item.Text != "")
                        sb.Append($"{item.Tag.ToString()}={item.Text}" + "and");
                }
                else if (item is InDTP)
                {
                    if (item.Text != "")
                        sb.Append($"between{((InDTP)item).Start.ToString()}and {((InDTP)item).End.ToString()}" + "and");
                }
                else
                {
                    continue;
                }
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("지워");
        }
        private void Excel(object sender, EventArgs e)
        {
            if (((TUChairMain2)this.MdiParent).ActiveMdiChild == this)
                MessageBox.Show("엑셀만들어");
        }
        
    }
}
