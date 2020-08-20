namespace TUChair
{
    partial class FacilityInfoRegi
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFaci_Modifier = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModifyDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFaci_Code = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFaci_Name = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboFaci_OutWareHouse = new System.Windows.Forms.ComboBox();
            this.cboFaci_UseOrNot = new System.Windows.Forms.ComboBox();
            this.cboFaci_InWareHouse = new System.Windows.Forms.ComboBox();
            this.cboFaci_BadWareHouse = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtFaci_Detail = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtFaci_Others = new System.Windows.Forms.TextBox();
            this.cboFacG_Code = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cboFaci_BadWareHouse);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.txtFaci_Name);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.txtModifyDate);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel5.Size = new System.Drawing.Size(255, 165);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cboFaci_InWareHouse);
            this.panel3.Controls.Add(this.txtFaci_Code);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtFaci_Modifier);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Size = new System.Drawing.Size(255, 165);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtFaci_Others);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Controls.Add(this.txtFaci_Detail);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Location = new System.Drawing.Point(3, 174);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Size = new System.Drawing.Size(761, 202);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboFacG_Code);
            this.panel2.Controls.Add(this.cboFaci_UseOrNot);
            this.panel2.Controls.Add(this.cboFaci_OutWareHouse);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Size = new System.Drawing.Size(255, 165);
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInsert.TabIndex = 11;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "◆ 설비군코드";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(9, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "◆ 소진창고";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(9, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "◆ 사용유무";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(15, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "◆ 수정자";
            // 
            // txtFaci_Modifier
            // 
            this.txtFaci_Modifier.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtFaci_Modifier.Location = new System.Drawing.Point(90, 121);
            this.txtFaci_Modifier.Name = "txtFaci_Modifier";
            this.txtFaci_Modifier.Size = new System.Drawing.Size(143, 21);
            this.txtFaci_Modifier.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(11, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "◆ 수정시간";
            // 
            // txtModifyDate
            // 
            this.txtModifyDate.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtModifyDate.Location = new System.Drawing.Point(86, 121);
            this.txtModifyDate.Name = "txtModifyDate";
            this.txtModifyDate.Size = new System.Drawing.Size(143, 21);
            this.txtModifyDate.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(15, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "◆ 양품창고";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(15, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "◆ 설비코드";
            // 
            // txtFaci_Code
            // 
            this.txtFaci_Code.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtFaci_Code.Location = new System.Drawing.Point(90, 14);
            this.txtFaci_Code.Name = "txtFaci_Code";
            this.txtFaci_Code.Size = new System.Drawing.Size(143, 21);
            this.txtFaci_Code.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(11, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "◆ 설비명";
            // 
            // txtFaci_Name
            // 
            this.txtFaci_Name.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtFaci_Name.Location = new System.Drawing.Point(86, 14);
            this.txtFaci_Name.Name = "txtFaci_Name";
            this.txtFaci_Name.Size = new System.Drawing.Size(143, 21);
            this.txtFaci_Name.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(11, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "◆ 불량창고";
            // 
            // cboFaci_OutWareHouse
            // 
            this.cboFaci_OutWareHouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFaci_OutWareHouse.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.cboFaci_OutWareHouse.FormattingEnabled = true;
            this.cboFaci_OutWareHouse.Location = new System.Drawing.Point(93, 68);
            this.cboFaci_OutWareHouse.Name = "cboFaci_OutWareHouse";
            this.cboFaci_OutWareHouse.Size = new System.Drawing.Size(143, 22);
            this.cboFaci_OutWareHouse.TabIndex = 3;
            // 
            // cboFaci_UseOrNot
            // 
            this.cboFaci_UseOrNot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFaci_UseOrNot.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.cboFaci_UseOrNot.FormattingEnabled = true;
            this.cboFaci_UseOrNot.Location = new System.Drawing.Point(93, 121);
            this.cboFaci_UseOrNot.Name = "cboFaci_UseOrNot";
            this.cboFaci_UseOrNot.Size = new System.Drawing.Size(143, 22);
            this.cboFaci_UseOrNot.TabIndex = 6;
            // 
            // cboFaci_InWareHouse
            // 
            this.cboFaci_InWareHouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFaci_InWareHouse.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.cboFaci_InWareHouse.FormattingEnabled = true;
            this.cboFaci_InWareHouse.Location = new System.Drawing.Point(90, 68);
            this.cboFaci_InWareHouse.Name = "cboFaci_InWareHouse";
            this.cboFaci_InWareHouse.Size = new System.Drawing.Size(143, 22);
            this.cboFaci_InWareHouse.TabIndex = 4;
            // 
            // cboFaci_BadWareHouse
            // 
            this.cboFaci_BadWareHouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFaci_BadWareHouse.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.cboFaci_BadWareHouse.FormattingEnabled = true;
            this.cboFaci_BadWareHouse.Location = new System.Drawing.Point(86, 68);
            this.cboFaci_BadWareHouse.Name = "cboFaci_BadWareHouse";
            this.cboFaci_BadWareHouse.Size = new System.Drawing.Size(143, 22);
            this.cboFaci_BadWareHouse.TabIndex = 5;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(9, 4);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 14);
            this.label23.TabIndex = 0;
            this.label23.Text = "◆ 특이사항";
            // 
            // txtFaci_Detail
            // 
            this.txtFaci_Detail.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtFaci_Detail.Location = new System.Drawing.Point(93, 3);
            this.txtFaci_Detail.Multiline = true;
            this.txtFaci_Detail.Name = "txtFaci_Detail";
            this.txtFaci_Detail.Size = new System.Drawing.Size(648, 89);
            this.txtFaci_Detail.TabIndex = 9;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label25.Location = new System.Drawing.Point(9, 99);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(43, 14);
            this.label25.TabIndex = 0;
            this.label25.Text = "◆ 비고";
            // 
            // txtFaci_Others
            // 
            this.txtFaci_Others.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtFaci_Others.Location = new System.Drawing.Point(93, 98);
            this.txtFaci_Others.Multiline = true;
            this.txtFaci_Others.Name = "txtFaci_Others";
            this.txtFaci_Others.Size = new System.Drawing.Size(648, 101);
            this.txtFaci_Others.TabIndex = 10;
            // 
            // cboFacG_Code
            // 
            this.cboFacG_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFacG_Code.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.cboFacG_Code.FormattingEnabled = true;
            this.cboFacG_Code.Location = new System.Drawing.Point(93, 14);
            this.cboFacG_Code.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboFacG_Code.Name = "cboFacG_Code";
            this.cboFacG_Code.Size = new System.Drawing.Size(143, 22);
            this.cboFacG_Code.TabIndex = 0;
            // 
            // FacilityInfoRegi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(776, 450);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FacilityInfoRegi";
            this.Text = "설비";
            this.Load += new System.EventHandler(this.FacilityInfoRegi_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cboFaci_BadWareHouse;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFaci_Name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboFaci_InWareHouse;
        private System.Windows.Forms.TextBox txtFaci_Code;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtModifyDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFaci_UseOrNot;
        private System.Windows.Forms.ComboBox cboFaci_OutWareHouse;
        private System.Windows.Forms.TextBox txtFaci_Modifier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFaci_Others;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtFaci_Detail;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cboFacG_Code;
    }
}
