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
    public partial class balzuDetail : TUChair.SearchCommomForm
    {
        List<balzuVO> balzus = null;
        List<ComboItemVO> comboItems = null;


        public balzuDetail()
        {
            InitializeComponent();
        }

        private void balzuDetail_Load(object sender, EventArgs e)
        {
            TUChairMain2 frm = (TUChairMain2)this.MdiParent;
            frm.Save += Save;
            frm.Search += Search;
            frm.Delete += Delete;
            frm.New += New;
            
            commonService service = new commonService();
            comboItems = service.getCommonCode("고객사@창고@User@사용여부@품목유형@공정구분");

         
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
