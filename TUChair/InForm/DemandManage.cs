using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Util;

namespace TUChair
{
    public partial class DemandManage : TUChair.SearchCommomForm
    {
        public DemandManage()
        {
            InitializeComponent();
            DataLoad();
        }

        public void DataLoad()
        {
            CommonUtil.InitSettingGridView(dgvDemand);
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "No.", "No", true,60);
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "고객사코드", "No", true,90);
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "고객사설비", "No", true);
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "고객사명", "No", true);
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "ModelSuffix", "No", true);
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "고객주문번호", "No", true,150);
            CommonUtil.AddNewColumnToDataGridView(dgvDemand, "품목", "No", true);

        }
            
    }
}
