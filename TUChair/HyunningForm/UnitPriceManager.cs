using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TUChair.HyunningForm
{
    public partial class UnitPriceManager : TUChair.CommonForm.SearchCommomForm
    {
        public UnitPriceManager()
        {
            InitializeComponent();
        }

        private void UnitPriceManager_Load(object sender, EventArgs e)
        {
            panel4.Size = new Size(1090, 50);
        }
    }
}
