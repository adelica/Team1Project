using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUChair
{
    public partial class FacilityInfo : Form
    {
        public FacilityInfo()
        {
            InitializeComponent();
        }
        public FacilityInfo(DataTable dt)
        {
            if (dt.Rows.Count < 1)
            {
                this.Close();
            }

            InitializeComponent();

            //Faci_Code, f.FacG_Code,FacG_Name, Faci_Name, Faci_OutWareHouse, Faci_InWareHouse, Faci_BadWareHouse, Faci_UseOrNot, Faci_Detail, Faci_Others, Faci_Modifier
            DataRow dr = dt.Rows[0];
            lblFacG_Code.Text = dr["FacG_Code"].ToString();
            lblFacG_Name.Text = dr["FacG_Name"].ToString();
            lblFaci_Code.Text = dr["Faci_Code"].ToString();
            lblFaci_Name.Text = dr["Faci_Name"].ToString();
            lblOut.Text = dr["Faci_OutWareHouse"].ToString();
            lblIn.Text = dr["Faci_InWareHouse"].ToString();
            lblBad.Text = dr["Faci_BadWareHouse"].ToString();
            lblUseOrNot.Text = dr["Faci_UseOrNot"].ToString();
            lblModifier.Text = dr["Faci_Modifier"].ToString();
            txtDetail.Text = dr["Faci_Detail"].ToString(); ;
            txtOther.Text = dr["Faci_Others"].ToString(); ;
        }
    }
}
