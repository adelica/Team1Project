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
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboParent = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboUseOrNot = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Size = new System.Drawing.Size(776, 379);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtInformation);
            this.panel4.Controls.Add(this.label17);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Controls.Add(this.txtModifyDate);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.cboUseOrNot);
            this.panel3.Controls.Add(this.cboParent);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label11);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtFact_Code);
            this.panel2.Controls.Add(this.txtModifier);
            this.panel2.Controls.Add(this.cboClass);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboFact_Group);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label9);
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInsert.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInsert.TabIndex = 9;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(29, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "◆ 시설군";
            // 
            // cboFact_Group
            // 
            this.cboFact_Group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFact_Group.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.cboFact_Group.FormattingEnabled = true;
            this.cboFact_Group.Location = new System.Drawing.Point(122, 10);
            this.cboFact_Group.Name = "cboFact_Group";
            this.cboFact_Group.Size = new System.Drawing.Size(208, 22);
            this.cboFact_Group.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(29, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "◆ 시설코드";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(29, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "◆ 시설구분";
            // 
            // cboClass
            // 
            this.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClass.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Location = new System.Drawing.Point(122, 145);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(208, 22);
            this.cboClass.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(41, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "◆ 수정시간";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(29, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "◆ 수정자";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(40, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "◆ 시설명";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(40, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 14);
            this.label13.TabIndex = 0;
            this.label13.Text = "◆ 상위시설";
            // 
            // cboParent
            // 
            this.cboParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParent.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.cboParent.FormattingEnabled = true;
            this.cboParent.Location = new System.Drawing.Point(133, 10);
            this.cboParent.Name = "cboParent";
            this.cboParent.Size = new System.Drawing.Size(208, 22);
            this.cboParent.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(40, 146);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 14);
            this.label15.TabIndex = 0;
            this.label15.Text = "◆ 사용유무";
            // 
            // cboUseOrNot
            // 
            this.cboUseOrNot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUseOrNot.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.cboUseOrNot.FormattingEnabled = true;
            this.cboUseOrNot.Location = new System.Drawing.Point(133, 146);
            this.cboUseOrNot.Name = "cboUseOrNot";
            this.cboUseOrNot.Size = new System.Drawing.Size(208, 22);
            this.cboUseOrNot.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(24, 4);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 14);
            this.label17.TabIndex = 0;
            this.label17.Text = "◆ 시설설명";
            // 
            // txtModifyDate
            // 
            this.txtModifyDate.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtModifyDate.Location = new System.Drawing.Point(133, 210);
            this.txtModifyDate.Name = "txtModifyDate";
            this.txtModifyDate.Size = new System.Drawing.Size(208, 21);
            this.txtModifyDate.TabIndex = 7;
            // 
            // txtModifier
            // 
            this.txtModifier.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtModifier.Location = new System.Drawing.Point(122, 213);
            this.txtModifier.Name = "txtModifier";
            this.txtModifier.Size = new System.Drawing.Size(208, 21);
            this.txtModifier.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtName.Location = new System.Drawing.Point(133, 77);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 21);
            this.txtName.TabIndex = 3;
            // 
            // txtFact_Code
            // 
            this.txtFact_Code.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtFact_Code.Location = new System.Drawing.Point(122, 77);
            this.txtFact_Code.Name = "txtFact_Code";
            this.txtFact_Code.Size = new System.Drawing.Size(208, 21);
            this.txtFact_Code.TabIndex = 2;
            // 
            // txtInformation
            // 
            this.txtInformation.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtInformation.Location = new System.Drawing.Point(117, 6);
            this.txtInformation.Multiline = true;
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.Size = new System.Drawing.Size(602, 91);
            this.txtInformation.TabIndex = 8;
            // 
            // FactoryInfoRegi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(776, 450);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.TextBox txtInformation;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtModifier;
        private System.Windows.Forms.ComboBox cboUseOrNot;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtFact_Code;
        private System.Windows.Forms.TextBox txtModifyDate;
    }
}
