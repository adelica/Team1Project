using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;
using TUChairVO;

namespace TUChair
{
    public partial class FacilityInfoRegi : TUChair.POPUPForm3Line
    {
        public FacilityInfoRegi()
        {
            InitializeComponent();
        }
        private void GetCboData(ComboBox combo) //콤보박스에 바인딩할 데이터 가져오기
        {
            FactoryService service = new FactoryService();
            List<FactoryNameVO> list =  service.GetCboData();
 //------------이부분 해야됨-----
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FacilityInfoRegi_Load(object sender, EventArgs e)
        {
            GetCboData(cboFaci_BadWareHouse);
        }
    }
}
