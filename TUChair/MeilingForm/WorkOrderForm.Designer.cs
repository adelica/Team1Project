﻿namespace TUChair
{
    partial class WorkOrderForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button4 = new System.Windows.Forms.Button();
            this.jeansGridView1 = new JeanForm.JeansGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.cboplanID = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.inDTP1 = new TUChair.InDTP();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jeansGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.jeansGridView1);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(104, 23);
            this.label1.Text = "작업지시 생성";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.SetChildIndex(this.label1, 0);
            this.panel2.Controls.SetChildIndex(this.button4, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel4);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button4.Location = new System.Drawing.Point(981, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 23);
            this.button4.TabIndex = 29;
            this.button4.Text = "작업지시 확정";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // jeansGridView1
            // 
            this.jeansGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.jeansGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jeansGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.jeansGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.jeansGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.jeansGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.jeansGridView1.IsAllCheckColumnHeader = false;
            this.jeansGridView1.Location = new System.Drawing.Point(3, 3);
            this.jeansGridView1.Name = "jeansGridView1";
            this.jeansGridView1.RowHeadersWidth = 30;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
            this.jeansGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.jeansGridView1.RowTemplate.Height = 23;
            this.jeansGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jeansGridView1.Size = new System.Drawing.Size(1084, 419);
            this.jeansGridView1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel11);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(728, 99);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cboStatus);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(3, 47);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(357, 34);
            this.panel5.TabIndex = 39;
            // 
            // cboStatus
            // 
            this.cboStatus.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "선택",
            "지시",
            "미지시"});
            this.cboStatus.Location = new System.Drawing.Point(119, 5);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(219, 27);
            this.cboStatus.TabIndex = 7;
            this.cboStatus.Tag = "Wo_State";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "◆ 상태";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cboItem);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Location = new System.Drawing.Point(4, 12);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(357, 34);
            this.panel7.TabIndex = 37;
            // 
            // cboItem
            // 
            this.cboItem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(119, 5);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(219, 27);
            this.cboItem.TabIndex = 7;
            this.cboItem.Tag = "item.Item_Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "◆ Item";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.cboplanID);
            this.panel11.Controls.Add(this.label10);
            this.panel11.Location = new System.Drawing.Point(366, 12);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(357, 34);
            this.panel11.TabIndex = 36;
            // 
            // cboplanID
            // 
            this.cboplanID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboplanID.FormattingEnabled = true;
            this.cboplanID.Location = new System.Drawing.Point(119, 5);
            this.cboplanID.Name = "cboplanID";
            this.cboplanID.Size = new System.Drawing.Size(219, 27);
            this.cboplanID.TabIndex = 7;
            this.cboplanID.Tag = "wo.[Sales_ID]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 19);
            this.label10.TabIndex = 6;
            this.label10.Text = "◆ planID";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.inDTP1);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Location = new System.Drawing.Point(732, 10);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(357, 34);
            this.panel8.TabIndex = 39;
            // 
            // inDTP1
            // 
            this.inDTP1.DateLimit = false;
            this.inDTP1.End = new System.DateTime(2020, 9, 3, 0, 0, 0, 0);
            this.inDTP1.endCustomfomat = null;
            this.inDTP1.endfomat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inDTP1.Location = new System.Drawing.Point(81, 4);
            this.inDTP1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inDTP1.Name = "inDTP1";
            this.inDTP1.Size = new System.Drawing.Size(237, 26);
            this.inDTP1.Start = new System.DateTime(2020, 7, 15, 0, 0, 0, 0);
            this.inDTP1.startCustomfomat = null;
            this.inDTP1.startfomat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inDTP1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "◆ 기간";
            // 
            // WorkOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1116, 602);
            this.Name = "WorkOrderForm";
            this.Text = "작업지시 생성";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkOrderForm_FormClosing);
            this.Load += new System.EventHandler(this.WorkOrderForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jeansGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private JeanForm.JeansGridView jeansGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ComboBox cboplanID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel8;
        private InDTP inDTP1;
        private System.Windows.Forms.Label label4;
    }
}
