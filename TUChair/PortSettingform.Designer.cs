namespace TUChair
{
    partial class PortSettingform
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbHandShake = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbDataSize = new System.Windows.Forms.ComboBox();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.cbComPort = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(0, 293);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel4.Size = new System.Drawing.Size(410, 181);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel2.Size = new System.Drawing.Size(410, 285);
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInsert.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbHandShake);
            this.groupBox1.Controls.Add(this.cbParity);
            this.groupBox1.Controls.Add(this.cbDataSize);
            this.groupBox1.Controls.Add(this.cbBaudRate);
            this.groupBox1.Controls.Add(this.cbComPort);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(42, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(325, 230);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // cbHandShake
            // 
            this.cbHandShake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHandShake.FormattingEnabled = true;
            this.cbHandShake.Items.AddRange(new object[] {
            "none",
            "Xon/Xoff",
            "request to send",
            "request to send xon/xoff"});
            this.cbHandShake.Location = new System.Drawing.Point(166, 179);
            this.cbHandShake.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbHandShake.Name = "cbHandShake";
            this.cbHandShake.Size = new System.Drawing.Size(138, 28);
            this.cbHandShake.TabIndex = 9;
            // 
            // cbParity
            // 
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Items.AddRange(new object[] {
            "none",
            "odd",
            "even",
            "mark",
            "space"});
            this.cbParity.Location = new System.Drawing.Point(166, 142);
            this.cbParity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(138, 28);
            this.cbParity.TabIndex = 8;
            // 
            // cbDataSize
            // 
            this.cbDataSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataSize.FormattingEnabled = true;
            this.cbDataSize.Items.AddRange(new object[] {
            "8",
            "7",
            "6"});
            this.cbDataSize.Location = new System.Drawing.Point(166, 106);
            this.cbDataSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDataSize.Name = "cbDataSize";
            this.cbDataSize.Size = new System.Drawing.Size(138, 28);
            this.cbDataSize.TabIndex = 7;
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "115200",
            "57600",
            "38400",
            "19200",
            "9600"});
            this.cbBaudRate.Location = new System.Drawing.Point(166, 70);
            this.cbBaudRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(138, 28);
            this.cbBaudRate.TabIndex = 6;
            // 
            // cbComPort
            // 
            this.cbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComPort.FormattingEnabled = true;
            this.cbComPort.Location = new System.Drawing.Point(166, 34);
            this.cbComPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbComPort.Name = "cbComPort";
            this.cbComPort.Size = new System.Drawing.Size(138, 28);
            this.cbComPort.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(26, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "handshake";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(26, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(26, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "parity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(25, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "baudrate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(24, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "data size";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(42, 39);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(324, 118);
            this.textBox1.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(38, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "연결여부 확인 (Receive)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 250);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 24);
            this.button1.TabIndex = 11;
            this.button1.Text = "연결";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PortSettingform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 562);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "PortSettingform";
            this.Text = "바코드세팅";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PortSettingform_FormClosing);
            this.Load += new System.EventHandler(this.PortSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbHandShake;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbDataSize;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.ComboBox cbComPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}