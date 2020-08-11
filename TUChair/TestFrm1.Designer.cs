namespace TUChair
{
    partial class TestFrm1
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
            this.userControl11 = new TUChair.UserControl1();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControl11.ButtenText = "button1";
            this.userControl11.IsOnClick = false;
            this.userControl11.Location = new System.Drawing.Point(68, 78);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(146, 30);
            this.userControl11.TabIndex = 0;
            // 
            // TestFrm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 562);
            this.Controls.Add(this.userControl11);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TestFrm1";
            this.Text = "TestFrm1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestFrm1_FormClosing);
            this.Load += new System.EventHandler(this.TestFrm1_Load);
            this.ResumeLayout(false);

        }


        #endregion

        private UserControl1 userControl11;
    }
}