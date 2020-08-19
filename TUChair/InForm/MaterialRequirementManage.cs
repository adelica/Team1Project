using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;

namespace TUChair
{
    public partial class MaterialRequirementManage : TUChair.SearchCommomForm
    {
        TUChairMain2 frm = new TUChairMain2();
        public MaterialRequirementManage()
        {
            InitializeComponent();
        }

        private void MaterialRequirementManage_Load(object sender, EventArgs e)
        {
            frm =(TUChairMain2)this.MdiParent;
            frm.Search += Search;
        }

        private void GetComboBinding()
        {
            MaterialRequirementService service = new MaterialRequirementService();
            //List<string> list = service.GetComboBinding();
        }

        private void Search(object sender, EventArgs e)
        {
           if(((TUChairMain2)this.MdiParent).ActiveMdiChild==this)
            {
                MaterialRequirementService service = new MaterialRequirementService();
                DataTable dt = service.MaterialSoyo(dtpMaterialReq.Start, dtpMaterialReq.End,cboPlanID.Text);
                dgvMaterialReq.DataSource = dt;
            }
        }

        private void MaterialRequirementManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.Search -= Search;
        }
    }
}
