namespace TUChair.MeilingForm
{
    partial class ShiftPopUpForm
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
            this.cboShift = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShiftID = new System.Windows.Forms.TextBox();
            this.txtPeople = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dptStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.u = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
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
            this.panel5.Controls.Add(this.textBox6);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.textBox5);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.u);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.txtPeople);
            this.panel5.Controls.Add(this.label3);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtpEndDate);
            this.panel3.Controls.Add(this.dptStartDate);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtShiftID);
            this.panel3.Controls.Add(this.label2);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBox7);
            this.panel4.Controls.Add(this.label11);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtEndTime);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtStartTime);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cboShift);
            this.panel2.Controls.Add(this.label1);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button3);
            this.panel6.Location = new System.Drawing.Point(197, 401);
            this.panel6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel6.Size = new System.Drawing.Size(403, 40);
            this.panel6.Controls.SetChildIndex(this.button2, 0);
            this.panel6.Controls.SetChildIndex(this.button1, 0);
            this.panel6.Controls.SetChildIndex(this.button3, 0);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(292, 8);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "설비코드";
            // 
            // cboShift
            // 
            this.cboShift.FormattingEnabled = true;
            this.cboShift.Location = new System.Drawing.Point(83, 26);
            this.cboShift.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboShift.Name = "cboShift";
            this.cboShift.Size = new System.Drawing.Size(147, 20);
            this.cboShift.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "shiftID";
            // 
            // txtShiftID
            // 
            this.txtShiftID.Location = new System.Drawing.Point(84, 26);
            this.txtShiftID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtShiftID.Name = "txtShiftID";
            this.txtShiftID.Size = new System.Drawing.Size(144, 21);
            this.txtShiftID.TabIndex = 2;
            // 
            // txtPeople
            // 
            this.txtPeople.Location = new System.Drawing.Point(86, 26);
            this.txtPeople.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPeople.Name = "txtPeople";
            this.txtPeople.Size = new System.Drawing.Size(144, 21);
            this.txtPeople.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "투입인원";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(83, 75);
            this.txtStartTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(144, 21);
            this.txtStartTime.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "시작시간";
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(83, 129);
            this.txtEndTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(144, 21);
            this.txtEndTime.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 131);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "완료시간";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "적용시작일";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 131);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "적용완료일";
            // 
            // dptStartDate
            // 
            this.dptStartDate.Location = new System.Drawing.Point(94, 77);
            this.dptStartDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dptStartDate.Name = "dptStartDate";
            this.dptStartDate.Size = new System.Drawing.Size(141, 21);
            this.dptStartDate.TabIndex = 6;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(94, 129);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(141, 21);
            this.dtpEndDate.TabIndex = 7;
            // 
            // u
            // 
            this.u.FormattingEnabled = true;
            this.u.Location = new System.Drawing.Point(87, 82);
            this.u.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.u.Name = "u";
            this.u.Size = new System.Drawing.Size(147, 20);
            this.u.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "사용유무";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(86, 128);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(144, 21);
            this.textBox5.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 133);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "수정일";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(86, 181);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(144, 21);
            this.textBox6.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 187);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "수정자";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(94, 13);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(653, 77);
            this.textBox7.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 21);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "비고";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(167, 8);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "수정";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // ShiftPopUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(776, 450);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ShiftPopUpForm";
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPeople;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShiftID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboShift;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox u;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dptStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button3;
    }
}
