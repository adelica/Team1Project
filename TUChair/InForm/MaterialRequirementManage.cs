using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChair.Util;

namespace TUChair
{
    public partial class MaterialRequirementManage : TUChair.SearchCommomForm
    {
        TUChairMain2 frm = new TUChairMain2();
        public MaterialRequirementManage()
        {
            InitializeComponent();
            CommonUtil.InitSettingGridView(dgvMaterialReq);
            dgvMaterialReq.AutoGenerateColumns = true;
        }

        private void MaterialRequirementManage_Load(object sender, EventArgs e)
        {
            GetComboBinding();
            CommonUtil.CboSetting(cboPlanID);
            frm =(TUChairMain2)this.MdiParent;
            frm.Search += Search;
        }

        private void GetComboBinding()
        {
            MaterialRequirementService service = new MaterialRequirementService();
            List<string> list = service.GetComboBinding();
            foreach(var li in list)
            {
                cboPlanID.Items.Add(li);
            }
        }
        //검색
        private void Search(object sender, EventArgs e)
        {
            if(((TUChairMain2)this.MdiParent).ActiveMdiChild==this)
            {
                
                MaterialRequirementService service = new MaterialRequirementService();
                DataTable dt = service.MaterialSoyo(dtpMaterialReq.Start.ToShortDateString(), dtpMaterialReq.End.ToShortDateString(), cboPlanID.Text);
                dgvMaterialReq.DataSource = dt;
            }
        }

        private void MaterialRequirementManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.Search -= Search;
        }
    }
}
