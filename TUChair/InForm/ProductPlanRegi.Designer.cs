namespace TUChair
{
    partial class ProductPlanRegi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlanID = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "◆ planID";
            // 
            // txtPlanID
            // 
            this.txtPlanID.Enabled = false;
            this.txtPlanID.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtPlanID.Location = new System.Drawing.Point(80, 24);
            this.txtPlanID.Name = "txtPlanID";
            this.txtPlanID.Size = new System.Drawing.Size(151, 21);
            this.txtPlanID.TabIndex = 1;
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnInsert.Location = new System.Drawing.Point(33, 64);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "등록";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(141, 64);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "취소";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ProductPlanRegi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 106);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.txtPlanID);
            this.Controls.Add(this.label1);
            this.Name = "ProductPlanRegi";
            this.Text = "생산계획생성";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPlanID;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnClose;
    }
}