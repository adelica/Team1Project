namespace TUChair
{
    partial class FactoryInfoRegi
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboFact_Group = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboParent = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cboUseOrNot = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtModifyDate = new System.Windows.Forms.TextBox();
            this.txtModifier = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtFact_Code = new System.Windows.Forms.TextBox();
            this.txtInformation = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Size = new System.Drawing.Size(887, 473);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.txtInformation);
            this.panel4.Controls.Add(this.label17);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Controls.Add(this.txtModifier);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.cboUseOrNot);
            this.panel3.Controls.Add(this.cboParent);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label9);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtFact_Code);
            this.panel2.Controls.Add(this.txtModifyDate);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cboClass);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboFact_Group);
            this.panel2.Controls.Add(this.label1);
            // 
            // btnInsert
            // 
            this.btnInsert.TabIndex = 9;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.TabIndex = 10;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(37, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "시설군";
            // 
            // cboFact_Group
            // 
            this.cboFact_Group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFact_Group.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFact_Group.FormattingEnabled = true;
            this.cboFact_Group.Location = new System.Drawing.Point(139, 12);
            this.cboFact_Group.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboFact_Group.Name = "cboFact_Group";
            this.cboFact_Group.Size = new System.Drawing.Size(237, 23);
            this.cboFact_Group.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Font = new System.Drawing.Font("굴림", 5F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(24, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 9);
            this.label2.TabIndex = 2;
            this.label2.Text = "■";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(37, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "시설코드";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Font = new System.Drawing.Font("굴림", 5F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(24, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 9);
            this.label4.TabIndex = 2;
            this.label4.Text = "■";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(37, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "시설구분";
            // 
            // cboClass
            // 
            this.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Location = new System.Drawing.Point(139, 181);
            this.cboClass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(237, 23);
            this.cboClass.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Font = new System.Drawing.Font("굴림", 5F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(24, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 9);
            this.label6.TabIndex = 2;
            this.label6.Text = "■";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "수정시간";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 5F);
            this.label8.Location = new System.Drawing.Point(24, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 9);
            this.label8.TabIndex = 2;
            this.label8.Text = "■";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "수정자";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 5F);
            this.label10.Location = new System.Drawing.Point(37, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 9);
            this.label10.TabIndex = 2;
            this.label10.Text = "■";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(49, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "시설명";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label12.Font = new System.Drawing.Font("굴림", 5F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(37, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 9);
            this.label12.TabIndex = 2;
            this.label12.Text = "■";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(49, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "상위시설";
            // 
            // cboParent
            // 
            this.cboParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboParent.FormattingEnabled = true;
            this.cboParent.Location = new System.Drawing.Point(152, 12);
            this.cboParent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboParent.Name = "cboParent";
            this.cboParent.Size = new System.Drawing.Size(237, 23);
            this.cboParent.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label14.Font = new System.Drawing.Font("굴림", 5F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(37, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 9);
            this.label14.TabIndex = 2;
            this.label14.Text = "■";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(49, 269);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "사용유무";
            // 
            // cboUseOrNot
            // 
            this.cboUseOrNot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUseOrNot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboUseOrNot.FormattingEnabled = true;
            this.cboUseOrNot.Location = new System.Drawing.Point(152, 266);
            this.cboUseOrNot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboUseOrNot.Name = "cboUseOrNot";
            this.cboUseOrNot.Size = new System.Drawing.Size(237, 23);
            this.cboUseOrNot.TabIndex = 7;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label16.Font = new System.Drawing.Font("굴림", 5F);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(37, 272);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(13, 9);
            this.label16.TabIndex = 2;
            this.label16.Text = "■";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(31, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 15);
            this.label17.TabIndex = 0;
            this.label17.Text = "시설설명";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("굴림", 5F);
            this.label18.Location = new System.Drawing.Point(18, 11);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(13, 9);
            this.label18.TabIndex = 2;
            this.label18.Text = "■";
            // 
            // txtModifyDate
            // 
            this.txtModifyDate.Location = new System.Drawing.Point(139, 265);
            this.txtModifyDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtModifyDate.Name = "txtModifyDate";
            this.txtModifyDate.Size = new System.Drawing.Size(237, 25);
            this.txtModifyDate.TabIndex = 6;
            // 
            // txtModifier
            // 
            this.txtModifier.Location = new System.Drawing.Point(152, 181);
            this.txtModifier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtModifier.Name = "txtModifier";
            this.txtModifier.Size = new System.Drawing.Size(237, 25);
            this.txtModifier.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(152, 96);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(237, 25);
            this.txtName.TabIndex = 3;
            // 
            // txtFact_Code
            // 
            this.txtFact_Code.Location = new System.Drawing.Point(139, 96);
            this.txtFact_Code.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFact_Code.Name = "txtFact_Code";
            this.txtFact_Code.Size = new System.Drawing.Size(237, 25);
            this.txtFact_Code.TabIndex = 2;
            // 
            // txtInformation
            // 
            this.txtInformation.Location = new System.Drawing.Point(134, 8);
            this.txtInformation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInformation.Multiline = true;
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.Size = new System.Drawing.Size(687, 113);
            this.txtInformation.TabIndex = 8;
            // 
            // FactoryInfoRegi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(887, 562);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FactoryInfoRegi";
            this.Text = "공장정보";
            this.Load += new System.EventHandler(this.FactoryInfoRegi_Load);
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

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboParent;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFact_Group;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtInformation;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtModifier;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboUseOrNot;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtFact_Code;
        private System.Windows.Forms.TextBox txtModifyDate;
    }
}
