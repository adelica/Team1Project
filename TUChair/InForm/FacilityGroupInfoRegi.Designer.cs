namespace TUChair
{
    partial class FacilityGroupInfoRegi
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
            this.txtFacG_Code = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFacG_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFacG_Modifier = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFacG_ModifyDate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFacG_Info = new System.Windows.Forms.TextBox();
            this.cboFacG_UseOrNot = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Size = new System.Drawing.Size(403, 481);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtFacG_Info);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Dock = System.Windows.Forms.DockStyle.None;
            this.panel4.Location = new System.Drawing.Point(8, 336);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel4.Size = new System.Drawing.Size(395, 145);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboFacG_UseOrNot);
            this.panel2.Controls.Add(this.txtFacG_ModifyDate);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtFacG_Modifier);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtFacG_Name);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtFacG_Code);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.None;
            this.panel2.Location = new System.Drawing.Point(8, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel2.Size = new System.Drawing.Size(395, 318);
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInsert.TabIndex = 6;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtFacG_Code
            // 
            this.txtFacG_Code.Location = new System.Drawing.Point(125, 21);
            this.txtFacG_Code.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFacG_Code.Name = "txtFacG_Code";
            this.txtFacG_Code.Size = new System.Drawing.Size(237, 25);
            this.txtFacG_Code.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 5F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(10, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 9);
            this.label8.TabIndex = 8;
            this.label8.Text = "■";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(22, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "설비군 코드";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(22, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "설비군 명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 5F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(10, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 9);
            this.label2.TabIndex = 8;
            this.label2.Text = "■";
            // 
            // txtFacG_Name
            // 
            this.txtFacG_Name.Location = new System.Drawing.Point(125, 85);
            this.txtFacG_Name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFacG_Name.Name = "txtFacG_Name";
            this.txtFacG_Name.Size = new System.Drawing.Size(237, 25);
            this.txtFacG_Name.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(22, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "사용유무";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 5F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(10, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 9);
            this.label4.TabIndex = 8;
            this.label4.Text = "■";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "수정자";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 5F);
            this.label6.Location = new System.Drawing.Point(10, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 9);
            this.label6.TabIndex = 8;
            this.label6.Text = "■";
            // 
            // txtFacG_Modifier
            // 
            this.txtFacG_Modifier.Location = new System.Drawing.Point(125, 211);
            this.txtFacG_Modifier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFacG_Modifier.Name = "txtFacG_Modifier";
            this.txtFacG_Modifier.Size = new System.Drawing.Size(237, 25);
            this.txtFacG_Modifier.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 280);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "수정시간";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 5F);
            this.label10.Location = new System.Drawing.Point(10, 282);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 9);
            this.label10.TabIndex = 8;
            this.label10.Text = "■";
            // 
            // txtFacG_ModifyDate
            // 
            this.txtFacG_ModifyDate.Location = new System.Drawing.Point(125, 275);
            this.txtFacG_ModifyDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFacG_ModifyDate.Name = "txtFacG_ModifyDate";
            this.txtFacG_ModifyDate.Size = new System.Drawing.Size(237, 25);
            this.txtFacG_ModifyDate.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 15);
            this.label11.TabIndex = 7;
            this.label11.Text = "시설설명";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("굴림", 5F);
            this.label12.Location = new System.Drawing.Point(10, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 9);
            this.label12.TabIndex = 8;
            this.label12.Text = "■";
            // 
            // txtFacG_Info
            // 
            this.txtFacG_Info.Location = new System.Drawing.Point(10, 24);
            this.txtFacG_Info.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFacG_Info.Multiline = true;
            this.txtFacG_Info.Name = "txtFacG_Info";
            this.txtFacG_Info.Size = new System.Drawing.Size(373, 113);
            this.txtFacG_Info.TabIndex = 5;
            // 
            // cboFacG_UseOrNot
            // 
            this.cboFacG_UseOrNot.FormattingEnabled = true;
            this.cboFacG_UseOrNot.Location = new System.Drawing.Point(125, 149);
            this.cboFacG_UseOrNot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboFacG_UseOrNot.Name = "cboFacG_UseOrNot";
            this.cboFacG_UseOrNot.Size = new System.Drawing.Size(237, 23);
            this.cboFacG_UseOrNot.TabIndex = 2;
            // 
            // FacilityGroupInfoRegi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(410, 562);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FacilityGroupInfoRegi";
            this.Text = "설비군";
            this.Load += new System.EventHandler(this.FacilityGroupInfoRegi_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFacG_Code;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFacG_Info;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboFacG_UseOrNot;
        private System.Windows.Forms.TextBox txtFacG_ModifyDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFacG_Modifier;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFacG_Name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}
