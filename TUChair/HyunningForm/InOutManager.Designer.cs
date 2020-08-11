namespace TUChair
{
    partial class InOutManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.jeansGridView1 = new JeanForm.JeansGridView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.cboItemtype = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtItemcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cboGubun = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cboFact = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.inDTP1 = new TUChair.InDTP();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jeansGridView1)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.jeansGridView1);
            this.panel3.Location = new System.Drawing.Point(12, 141);
            this.panel3.Size = new System.Drawing.Size(1092, 449);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(98, 23);
            this.label1.Text = "≡ 입출고현황";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePicker2);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Location = new System.Drawing.Point(12, 97);
            this.panel2.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.panel2.Controls.SetChildIndex(this.label1, 0);
            this.panel2.Controls.SetChildIndex(this.label8, 0);
            this.panel2.Controls.SetChildIndex(this.dateTimePicker2, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Size = new System.Drawing.Size(1092, 80);
            // 
            // jeansGridView1
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Beige;
            this.jeansGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.jeansGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.jeansGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.jeansGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.jeansGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jeansGridView1.IsAllCheckColumnHeader = false;
            this.jeansGridView1.Location = new System.Drawing.Point(0, 0);
            this.jeansGridView1.Name = "jeansGridView1";
            this.jeansGridView1.RowHeadersWidth = 30;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Bisque;
            this.jeansGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.jeansGridView1.RowTemplate.Height = 23;
            this.jeansGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jeansGridView1.Size = new System.Drawing.Size(1090, 447);
            this.jeansGridView1.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.cboItemtype);
            this.panel10.Controls.Add(this.label9);
            this.panel10.Location = new System.Drawing.Point(729, 42);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(357, 33);
            this.panel10.TabIndex = 23;
            // 
            // cboItemtype
            // 
            this.cboItemtype.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemtype.FormattingEnabled = true;
            this.cboItemtype.Location = new System.Drawing.Point(122, 4);
            this.cboItemtype.Name = "cboItemtype";
            this.cboItemtype.Size = new System.Drawing.Size(219, 27);
            this.cboItemtype.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 19);
            this.label9.TabIndex = 6;
            this.label9.Text = "◆ 품목유형";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cboCategory);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(366, 42);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(357, 33);
            this.panel5.TabIndex = 19;
            // 
            // cboCategory
            // 
            this.cboCategory.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(119, 4);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(219, 27);
            this.cboCategory.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "◆ 카테고리";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtItemcode);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Location = new System.Drawing.Point(729, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(357, 33);
            this.panel7.TabIndex = 20;
            // 
            // txtItemcode
            // 
            this.txtItemcode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemcode.Location = new System.Drawing.Point(122, 2);
            this.txtItemcode.Name = "txtItemcode";
            this.txtItemcode.Size = new System.Drawing.Size(219, 27);
            this.txtItemcode.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "◆ 품목";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.cboGubun);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Location = new System.Drawing.Point(3, 42);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(357, 33);
            this.panel8.TabIndex = 21;
            // 
            // cboGubun
            // 
            this.cboGubun.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGubun.FormattingEnabled = true;
            this.cboGubun.Location = new System.Drawing.Point(119, 3);
            this.cboGubun.Name = "cboGubun";
            this.cboGubun.Size = new System.Drawing.Size(219, 27);
            this.cboGubun.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "◆ 입출고유형";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.inDTP1);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(357, 33);
            this.panel4.TabIndex = 18;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(246, 6);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(95, 27);
            this.dateTimePicker2.TabIndex = 10;
            this.dateTimePicker2.Value = new System.DateTime(2020, 7, 22, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(223, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 19);
            this.label8.TabIndex = 9;
            this.label8.Text = "~";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(122, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(95, 27);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.Value = new System.DateTime(2020, 7, 22, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(12, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "◆ 입출고일";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.cboFact);
            this.panel9.Controls.Add(this.label6);
            this.panel9.Location = new System.Drawing.Point(366, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(357, 33);
            this.panel9.TabIndex = 22;
            // 
            // cboFact
            // 
            this.cboFact.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFact.FormattingEnabled = true;
            this.cboFact.Location = new System.Drawing.Point(119, 3);
            this.cboFact.Name = "cboFact";
            this.cboFact.Size = new System.Drawing.Size(219, 27);
            this.cboFact.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "◆ 창고";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.panel9, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1090, 78);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // inDTP1
            // 
            this.inDTP1.DateLimit = false;
            this.inDTP1.End = new System.DateTime(2020, 8, 12, 3, 55, 18, 633);
            this.inDTP1.Location = new System.Drawing.Point(119, 5);
            this.inDTP1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inDTP1.Name = "inDTP1";
            this.inDTP1.Size = new System.Drawing.Size(235, 26);
            this.inDTP1.Start = new System.DateTime(2020, 8, 12, 3, 55, 18, 640);
            this.inDTP1.TabIndex = 7;
            // 
            // InOutManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1116, 602);
            this.Name = "InOutManager";
            this.Text = "≡ 입출고관리";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InOutManager_FormClosing);
            this.Load += new System.EventHandler(this.InOutManager_Load);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jeansGridView1)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private JeanForm.JeansGridView jeansGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ComboBox cboFact;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.ComboBox cboGubun;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtItemcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.ComboBox cboItemtype;
        private System.Windows.Forms.Label label9;
        private InDTP inDTP1;
    }
}
