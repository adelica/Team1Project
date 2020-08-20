namespace TUChair
{
    partial class BORInfoRegi
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtYeild = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTactTime = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.cboFaci_Code = new System.Windows.Forms.ComboBox();
            this.cboItem_Code = new System.Windows.Forms.ComboBox();
            this.cboFacG_Code = new System.Windows.Forms.ComboBox();
            this.cboUseOrNot = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProcessLead = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtOther);
            this.panel4.Controls.Add(this.label17);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cboFacG_Code);
            this.panel3.Controls.Add(this.txtProcessLead);
            this.panel3.Controls.Add(this.txtYeild);
            this.panel3.Controls.Add(this.txtTactTime);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboUseOrNot);
            this.panel2.Controls.Add(this.cboItem_Code);
            this.panel2.Controls.Add(this.cboFaci_Code);
            this.panel2.Controls.Add(this.txtPriority);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label3);
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInsert.TabIndex = 9;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(30, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "◆ 품목";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(30, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "◆ 설비";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(15, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "◆ 수율";
            // 
            // txtYeild
            // 
            this.txtYeild.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtYeild.Location = new System.Drawing.Point(151, 153);
            this.txtYeild.Name = "txtYeild";
            this.txtYeild.Size = new System.Drawing.Size(208, 21);
            this.txtYeild.TabIndex = 6;
            this.txtYeild.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIntervalPlus_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(15, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 14);
            this.label10.TabIndex = 6;
            this.label10.Text = "◆ 공정";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(15, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 14);
            this.label11.TabIndex = 6;
            this.label11.Text = "◆ Tact Time (Sec.)";
            // 
            // txtTactTime
            // 
            this.txtTactTime.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTactTime.Location = new System.Drawing.Point(151, 83);
            this.txtTactTime.Name = "txtTactTime";
            this.txtTactTime.Size = new System.Drawing.Size(208, 21);
            this.txtTactTime.TabIndex = 5;
            this.txtTactTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInterval_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(30, 154);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 14);
            this.label13.TabIndex = 6;
            this.label13.Text = "◆ 우선순위";
            // 
            // txtPriority
            // 
            this.txtPriority.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPriority.Location = new System.Drawing.Point(141, 153);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(208, 21);
            this.txtPriority.TabIndex = 2;
            this.txtPriority.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInterval_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(30, 218);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 14);
            this.label15.TabIndex = 6;
            this.label15.Text = "◆ 사용유무";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(30, 5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 14);
            this.label17.TabIndex = 3;
            this.label17.Text = "◆ 비고";
            // 
            // txtOther
            // 
            this.txtOther.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtOther.Location = new System.Drawing.Point(126, 3);
            this.txtOther.Multiline = true;
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(592, 94);
            this.txtOther.TabIndex = 8;
            // 
            // cboFaci_Code
            // 
            this.cboFaci_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFaci_Code.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboFaci_Code.FormattingEnabled = true;
            this.cboFaci_Code.Location = new System.Drawing.Point(141, 83);
            this.cboFaci_Code.Name = "cboFaci_Code";
            this.cboFaci_Code.Size = new System.Drawing.Size(208, 22);
            this.cboFaci_Code.TabIndex = 1;
            // 
            // cboItem_Code
            // 
            this.cboItem_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItem_Code.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboItem_Code.FormattingEnabled = true;
            this.cboItem_Code.Location = new System.Drawing.Point(141, 21);
            this.cboItem_Code.Name = "cboItem_Code";
            this.cboItem_Code.Size = new System.Drawing.Size(208, 22);
            this.cboItem_Code.TabIndex = 0;
            // 
            // cboFacG_Code
            // 
            this.cboFacG_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFacG_Code.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboFacG_Code.FormattingEnabled = true;
            this.cboFacG_Code.Location = new System.Drawing.Point(151, 21);
            this.cboFacG_Code.Name = "cboFacG_Code";
            this.cboFacG_Code.Size = new System.Drawing.Size(208, 22);
            this.cboFacG_Code.TabIndex = 4;
            // 
            // cboUseOrNot
            // 
            this.cboUseOrNot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUseOrNot.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboUseOrNot.FormattingEnabled = true;
            this.cboUseOrNot.Location = new System.Drawing.Point(141, 217);
            this.cboUseOrNot.Name = "cboUseOrNot";
            this.cboUseOrNot.Size = new System.Drawing.Size(208, 22);
            this.cboUseOrNot.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(15, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "◆ 공정선행일(Day)";
            // 
            // txtProcessLead
            // 
            this.txtProcessLead.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProcessLead.Location = new System.Drawing.Point(151, 217);
            this.txtProcessLead.Name = "txtProcessLead";
            this.txtProcessLead.Size = new System.Drawing.Size(208, 21);
            this.txtProcessLead.TabIndex = 7;
            this.txtProcessLead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIntervalPlus_KeyPress);
            // 
            // BORInfoRegi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(774, 450);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BORInfoRegi";
            this.Text = "BillOfResource";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboUseOrNot;
        private System.Windows.Forms.ComboBox cboFacG_Code;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.TextBox txtTactTime;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboItem_Code;
        private System.Windows.Forms.ComboBox cboFaci_Code;
        private System.Windows.Forms.TextBox txtYeild;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProcessLead;
        private System.Windows.Forms.Label label5;
    }
}
