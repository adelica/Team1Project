﻿namespace TUChair
{
    partial class POManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.inDTP1 = new TUChair.InDTP();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.dtpPlanDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.txtCusNumber = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dgvPO = new JeanForm.JeansGridView();
            this.btnSORegi = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvPO);
            this.panel3.Location = new System.Drawing.Point(12, 199);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Size = new System.Drawing.Size(1092, 391);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(98, 23);
            this.label1.Text = "≡ 영업마스터";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSORegi);
            this.panel2.Location = new System.Drawing.Point(13, 158);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Size = new System.Drawing.Size(1091, 38);
            this.panel2.TabIndex = 1;
            this.panel2.Controls.SetChildIndex(this.label1, 0);
            this.panel2.Controls.SetChildIndex(this.btnSORegi, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Size = new System.Drawing.Size(1092, 140);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.inDTP1);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(17, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(366, 34);
            this.panel4.TabIndex = 0;
            // 
            // inDTP1
            // 
            this.inDTP1.DateLimit = false;
            this.inDTP1.End = new System.DateTime(2020, 9, 3, 0, 0, 0, 0);
            this.inDTP1.endCustomfomat = null;
            this.inDTP1.endfomat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inDTP1.Location = new System.Drawing.Point(105, 2);
            this.inDTP1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inDTP1.Name = "inDTP1";
            this.inDTP1.Size = new System.Drawing.Size(245, 26);
            this.inDTP1.Start = new System.DateTime(2020, 7, 15, 0, 0, 0, 0);
            this.inDTP1.startCustomfomat = null;
            this.inDTP1.startfomat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inDTP1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(19, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "고객납기일";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 5F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(8, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 7);
            this.label8.TabIndex = 14;
            this.label8.Text = "■";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.cboCustomer);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Location = new System.Drawing.Point(405, 25);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(312, 34);
            this.panel8.TabIndex = 1;
            // 
            // cboCustomer
            // 
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(99, 8);
            this.cboCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(208, 20);
            this.cboCustomer.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(19, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "고객사";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 5F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(8, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 7);
            this.label11.TabIndex = 14;
            this.label11.Text = "■";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.txtItem);
            this.panel9.Controls.Add(this.label12);
            this.panel9.Controls.Add(this.label13);
            this.panel9.Location = new System.Drawing.Point(17, 79);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(366, 34);
            this.panel9.TabIndex = 4;
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(110, 7);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(233, 21);
            this.txtItem.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(19, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 13;
            this.label12.Text = "품목";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("굴림", 5F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(8, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(10, 7);
            this.label13.TabIndex = 14;
            this.label13.Text = "■";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.dtpPlanDate);
            this.panel10.Controls.Add(this.label14);
            this.panel10.Controls.Add(this.label15);
            this.panel10.Location = new System.Drawing.Point(405, 79);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(312, 34);
            this.panel10.TabIndex = 7;
            // 
            // dtpPlanDate
            // 
            this.dtpPlanDate.CustomFormat = "yyyy-MM-dd";
            this.dtpPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPlanDate.Location = new System.Drawing.Point(99, 6);
            this.dtpPlanDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpPlanDate.Name = "dtpPlanDate";
            this.dtpPlanDate.Size = new System.Drawing.Size(208, 21);
            this.dtpPlanDate.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(19, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 13;
            this.label14.Text = "등록일";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("굴림", 5F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(8, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(10, 7);
            this.label15.TabIndex = 14;
            this.label15.Text = "■";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.txtCusNumber);
            this.panel12.Controls.Add(this.label18);
            this.panel12.Controls.Add(this.label19);
            this.panel12.Location = new System.Drawing.Point(741, 25);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(335, 34);
            this.panel12.TabIndex = 2;
            // 
            // txtCusNumber
            // 
            this.txtCusNumber.Location = new System.Drawing.Point(121, 7);
            this.txtCusNumber.Name = "txtCusNumber";
            this.txtCusNumber.Size = new System.Drawing.Size(208, 21);
            this.txtCusNumber.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(19, 11);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 12);
            this.label18.TabIndex = 13;
            this.label18.Text = "고객주문번호";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("굴림", 5F);
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(8, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(10, 7);
            this.label19.TabIndex = 14;
            this.label19.Text = "■";
            // 
            // dgvPO
            // 
            this.dgvPO.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Beige;
            this.dgvPO.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPO.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPO.EnableHeadersVisualStyles = false;
            this.dgvPO.IsAllCheckColumnHeader = false;
            this.dgvPO.Location = new System.Drawing.Point(0, 0);
            this.dgvPO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPO.Name = "dgvPO";
            this.dgvPO.RowHeadersWidth = 30;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Bisque;
            this.dgvPO.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPO.RowTemplate.Height = 27;
            this.dgvPO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPO.Size = new System.Drawing.Size(1090, 389);
            this.dgvPO.TabIndex = 0;
            this.dgvPO.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPO_RowPostPaint);
            // 
            // btnSORegi
            // 
            this.btnSORegi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSORegi.Location = new System.Drawing.Point(972, 7);
            this.btnSORegi.Name = "btnSORegi";
            this.btnSORegi.Size = new System.Drawing.Size(102, 23);
            this.btnSORegi.TabIndex = 1;
            this.btnSORegi.Text = "수요계획생성";
            this.btnSORegi.UseVisualStyleBackColor = true;

            // 
            // POManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1116, 602);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "POManage";
            this.Text = "영업마스터";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.POManage_FormClosing);
            this.Load += new System.EventHandler(this.POManage_Load);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DateTimePicker dtpPlanDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TextBox txtCusNumber;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private JeanForm.JeansGridView dgvPO;
        private System.Windows.Forms.Button btnSORegi;
        private InDTP inDTP1;
    }
}
