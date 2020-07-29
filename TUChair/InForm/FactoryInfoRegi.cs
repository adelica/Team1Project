using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChairVO;

namespace TUChair
{
    public partial class FactoryInfoRegi : TUChair.POPUp2Line
    {
        List<FactoryVO> list;
        public FactoryInfoRegi()
        {
            InitializeComponent();
        }
        public FactoryInfoRegi(List<FactoryVO> list):this()
        {
            this.list = list;
        }

        private void ComboBoxBinding() // 각 콤보박스에 선택지 바인딩
        {
            List<string> cFactGroup = null;
            List<string> cParent = null;
            List<string> cClass = null;
            List<string> cUseOrNot = null;

            

        }
    }
}
