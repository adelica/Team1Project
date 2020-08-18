namespace TUChair
{
    partial class RowMetrialDecountPopUp
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
            this.txtitem = new System.Windows.Forms.TextBox();
            this.txtplanQTY = new System.Windows.Forms.TextBox();
            this.txtoutQTY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBox4);
            this.panel4.Controls.Add(this.label4);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtoutQTY);
            this.panel2.Controls.Add(this.txtplanQTY);
            this.panel2.Controls.Add(this.txtitem);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "원자재";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "계획수량";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "출고량";
            // 
            // txtitem
            // 
            this.txtitem.Location = new System.Drawing.Point(111, 49);
            this.txtitem.Name = "txtitem";
            this.txtitem.Size = new System.Drawing.Size(168, 21);
            this.txtitem.TabIndex = 3;
            // 
            // txtplanQTY
            // 
            this.txtplanQTY.Location = new System.Drawing.Point(111, 114);
            this.txtplanQTY.Name = "txtplanQTY";
            this.txtplanQTY.Size = new System.Drawing.Size(168, 21);
            this.txtplanQTY.TabIndex = 4;
            // 
            // txtoutQTY
            // 
            this.txtoutQTY.Location = new System.Drawing.Point(111, 191);
            this.txtoutQTY.Name = "txtoutQTY";
            this.txtoutQTY.Size = new System.Drawing.Size(168, 21);
            this.txtoutQTY.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "비고";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(111, 23);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(216, 74);
            this.textBox4.TabIndex = 6;
            // 
            // RowMetrialDecountPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(359, 450);
            this.Name = "RowMetrialDecountPopUp";
            this.Load += new System.EventHandler(this.RowMetrialDecountPopUp_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtoutQTY;
        private System.Windows.Forms.TextBox txtplanQTY;
        private System.Windows.Forms.TextBox txtitem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
