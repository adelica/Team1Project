namespace TUChair
{
    partial class CompanyManage
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
            this.txtCom_Code = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCom_CorporRegiNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCom_Name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCom_Type = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvCompany = new JeanForm.JeansGridView();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvCompany);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.Text = "≡ 업체코드정의";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel4);
            // 
            // txtCom_Code
            // 
            this.txtCom_Code.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtCom_Code.Location = new System.Drawing.Point(109, 3);
            this.txtCom_Code.Name = "txtCom_Code";
            this.txtCom_Code.Size = new System.Drawing.Size(208, 21);
            this.txtCom_Code.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(5, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 14);
            this.label7.TabIndex = 10;
            this.label7.Text = "◆ 업체 코드";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "◆ 사업자등록번호";
            // 
            // txtCom_CorporRegiNum
            // 
            this.txtCom_CorporRegiNum.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtCom_CorporRegiNum.Location = new System.Drawing.Point(109, 3);
            this.txtCom_CorporRegiNum.Name = "txtCom_CorporRegiNum";
            this.txtCom_CorporRegiNum.Size = new System.Drawing.Size(208, 21);
            this.txtCom_CorporRegiNum.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "◆ 업체명";
            // 
            // txtCom_Name
            // 
            this.txtCom_Name.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtCom_Name.Location = new System.Drawing.Point(88, 3);
            this.txtCom_Name.Name = "txtCom_Name";
            this.txtCom_Name.Size = new System.Drawing.Size(208, 21);
            this.txtCom_Name.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "◆ 업체타입";
            // 
            // cboCom_Type
            // 
            this.cboCom_Type.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.cboCom_Type.FormattingEnabled = true;
            this.cboCom_Type.Location = new System.Drawing.Point(99, 3);
            this.cboCom_Type.Name = "cboCom_Type";
            this.cboCom_Type.Size = new System.Drawing.Size(162, 22);
            this.cboCom_Type.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtCom_Name);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(382, 15);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(299, 27);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cboCom_Type);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Location = new System.Drawing.Point(717, 15);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(274, 27);
            this.panel5.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtCom_CorporRegiNum);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Location = new System.Drawing.Point(11, 58);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(322, 27);
            this.panel6.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtCom_Code);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(11, 15);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(322, 27);
            this.panel7.TabIndex = 0;
            // 
            // dgvCompany
            // 
            this.dgvCompany.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dgvCompany.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompany.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompany.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompany.IsAllCheckColumnHeader = false;
            this.dgvCompany.Location = new System.Drawing.Point(0, 0);
            this.dgvCompany.Name = "dgvCompany";
            this.dgvCompany.RowHeadersWidth = 30;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
            this.dgvCompany.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCompany.RowTemplate.Height = 23;
            this.dgvCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompany.Size = new System.Drawing.Size(1090, 425);
            this.dgvCompany.TabIndex = 0;
            this.dgvCompany.TabStop = false;
            this.dgvCompany.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvCompany_RowPostPaint);
            // 
            // CompanyManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1116, 602);
            this.Name = "CompanyManage";
            this.Text = "업체관리";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CompanyManage_FormClosing);
            this.Load += new System.EventHandler(this.CompanyManage_Load);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompany)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cboCom_Type;
        private System.Windows.Forms.TextBox txtCom_CorporRegiNum;
        private System.Windows.Forms.TextBox txtCom_Name;
        private System.Windows.Forms.TextBox txtCom_Code;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private JeanForm.JeansGridView dgvCompany;
    }
}
