﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TUChair.Service;

namespace TUChair
{
    public partial class RegistFormPopUp : TUChair.POPUPForm3Line
    {
        public int WorkOrderId { get; set; }
        public string  itemType { get; set; }
        public RegistFormPopUp()
        {
            InitializeComponent();
        }

        private void RegistFormPopUp_Load(object sender, EventArgs e)
        {
            textBox2.Text = WorkOrderId.ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int QTY = Convert.ToInt32(textBox5.Text);
            int ProQTY = Convert.ToInt32(textBox6.Text);
            int BadQTY = QTY - ProQTY;

            MeilingService service = new MeilingService();
            if (itemType == "반제품") {
                if (service.UpdateWorkOrder(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text), textBox4.Text))
                {
                    MessageBox.Show("수정 되였습니다");
                }
                else
                {
                    MessageBox.Show("수정실패");
                }
            }
            else if(itemType == "완제품")
            {
             
                if (service.itemDecount2(WorkOrderId, Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text), textBox4.Text))
                {
                    MessageBox.Show("수정 되였습니다");
                }
                else
                {
                    MessageBox.Show("수정실패");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)//취소 버튼
        {
            this.Close();
        }
    }
}
