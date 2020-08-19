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

namespace TUChair
{
    public partial class ProductPlanRegi : Form
    {
        public ProductPlanRegi()
        {
            InitializeComponent();
        }

        public ProductPlanRegi(string planID):this()
        {
            txtPlanID.Text = planID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(txtPlanID.Text.Trim().Length<1)
            {
                MessageBox.Show("등록된  planID가 없습니다.", "등록실패");
                return;
            }
            POSOService service = new POSOService();
            bool check = service.ProductPlanRegi(txtPlanID.Text);
            if(check)
            {
                MessageBox.Show("등록되었습니다.", "등록완료");
                this.Close();
            }
        }
    }
}
