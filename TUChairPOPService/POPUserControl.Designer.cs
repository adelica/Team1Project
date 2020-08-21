namespace TUChair
{
    partial class POPUserControl
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnServerStart = new System.Windows.Forms.Button();
            this.btnServerStop = new System.Windows.Forms.Button();
            this.btnClientStart = new System.Windows.Forms.Button();
            this.btnclientStop = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.txtWoID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlanQTY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProQTY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBadQTY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLog = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFaciCode = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblTaskID = new System.Windows.Forms.Label();
            this.lableT = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnServerStart
            // 
            this.btnServerStart.Location = new System.Drawing.Point(21, 134);
            this.btnServerStart.Name = "btnServerStart";
            this.btnServerStart.Size = new System.Drawing.Size(75, 23);
            this.btnServerStart.TabIndex = 0;
            this.btnServerStart.Text = "서버가동";
            this.btnServerStart.UseVisualStyleBackColor = true;
            this.btnServerStart.Click += new System.EventHandler(this.btnServerStart_Click);
            // 
            // btnServerStop
            // 
            this.btnServerStop.Location = new System.Drawing.Point(114, 134);
            this.btnServerStop.Name = "btnServerStop";
            this.btnServerStop.Size = new System.Drawing.Size(75, 23);
            this.btnServerStop.TabIndex = 1;
            this.btnServerStop.Text = "서버중지";
            this.btnServerStop.UseVisualStyleBackColor = true;
            this.btnServerStop.Click += new System.EventHandler(this.btnServerStop_Click);
            // 
            // btnClientStart
            // 
            this.btnClientStart.Location = new System.Drawing.Point(260, 134);
            this.btnClientStart.Name = "btnClientStart";
            this.btnClientStart.Size = new System.Drawing.Size(75, 23);
            this.btnClientStart.TabIndex = 2;
            this.btnClientStart.Text = "연결가동";
            this.btnClientStart.UseVisualStyleBackColor = true;
            this.btnClientStart.Click += new System.EventHandler(this.btnClientStart_Click);
            // 
            // btnclientStop
            // 
            this.btnclientStop.Location = new System.Drawing.Point(355, 134);
            this.btnclientStop.Name = "btnclientStop";
            this.btnclientStop.Size = new System.Drawing.Size(75, 23);
            this.btnclientStop.TabIndex = 3;
            this.btnclientStop.Text = "연결중지";
            this.btnclientStop.UseVisualStyleBackColor = true;
            this.btnclientStop.Click += new System.EventHandler(this.btnclientStop_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(207, 134);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(31, 23);
            this.btnStatus.TabIndex = 4;
            this.btnStatus.UseVisualStyleBackColor = true;
            // 
            // txtWoID
            // 
            this.txtWoID.Location = new System.Drawing.Point(114, 7);
            this.txtWoID.Name = "txtWoID";
            this.txtWoID.Size = new System.Drawing.Size(214, 21);
            this.txtWoID.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "작업지시번호";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "item";
            // 
            // txtPlanQTY
            // 
            this.txtPlanQTY.Location = new System.Drawing.Point(100, 23);
            this.txtPlanQTY.Name = "txtPlanQTY";
            this.txtPlanQTY.Size = new System.Drawing.Size(124, 21);
            this.txtPlanQTY.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "지시량";
            // 
            // txtProQTY
            // 
            this.txtProQTY.Location = new System.Drawing.Point(100, 62);
            this.txtProQTY.Name = "txtProQTY";
            this.txtProQTY.Size = new System.Drawing.Size(124, 21);
            this.txtProQTY.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "생산량";
            // 
            // txtBadQTY
            // 
            this.txtBadQTY.Location = new System.Drawing.Point(100, 98);
            this.txtBadQTY.Name = "txtBadQTY";
            this.txtBadQTY.Size = new System.Drawing.Size(124, 21);
            this.txtBadQTY.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "불량";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "IP:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(389, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "Port:";
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(478, 134);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(75, 23);
            this.btnLog.TabIndex = 19;
            this.btnLog.Text = "화면보기";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(254, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "설비코드";
            // 
            // lblFaciCode
            // 
            this.lblFaciCode.AutoSize = true;
            this.lblFaciCode.Location = new System.Drawing.Point(332, 46);
            this.lblFaciCode.Name = "lblFaciCode";
            this.lblFaciCode.Size = new System.Drawing.Size(53, 12);
            this.lblFaciCode.TabIndex = 21;
            this.lblFaciCode.Text = "설비코드";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(76, 95);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(16, 12);
            this.lblIP.TabIndex = 22;
            this.lblIP.Text = "IP";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(432, 95);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(27, 12);
            this.lblPort.TabIndex = 23;
            this.lblPort.Text = "Port";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(234, 94);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(53, 12);
            this.lblItem.TabIndex = 24;
            this.lblItem.Text = "설비코드";
            // 
            // lblTaskID
            // 
            this.lblTaskID.AutoSize = true;
            this.lblTaskID.Location = new System.Drawing.Point(107, 46);
            this.lblTaskID.Name = "lblTaskID";
            this.lblTaskID.Size = new System.Drawing.Size(44, 12);
            this.lblTaskID.TabIndex = 26;
            this.lblTaskID.Text = "TaskID";
            // 
            // lableT
            // 
            this.lableT.AutoSize = true;
            this.lableT.Location = new System.Drawing.Point(29, 46);
            this.lableT.Name = "lableT";
            this.lableT.Size = new System.Drawing.Size(44, 12);
            this.lableT.TabIndex = 25;
            this.lableT.Text = "TaskID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProQTY);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPlanQTY);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBadQTY);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(657, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 134);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "생산추이";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "지시량 확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // POPUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTaskID);
            this.Controls.Add(this.lableT);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.lblFaciCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWoID);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnclientStop);
            this.Controls.Add(this.btnClientStart);
            this.Controls.Add(this.btnServerStop);
            this.Controls.Add(this.btnServerStart);
            this.Name = "POPUserControl";
            this.Size = new System.Drawing.Size(1114, 163);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnServerStart;
        private System.Windows.Forms.Button btnServerStop;
        private System.Windows.Forms.Button btnClientStart;
        private System.Windows.Forms.Button btnclientStop;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.TextBox txtWoID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlanQTY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProQTY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBadQTY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFaciCode;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblTaskID;
        private System.Windows.Forms.Label lableT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}
