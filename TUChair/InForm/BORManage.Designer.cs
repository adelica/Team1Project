namespace TUChair
{
    partial class BORManage
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtItem_Code = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFaci_Code = new System.Windows.Forms.TextBox();
            this.cboFacG_Code = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvBOR = new JeanForm.JeansGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOR)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvBOR);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(150, 23);
            this.label1.Text = "≡ Bill Of Resource";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            // 
            // txtItem_Code
            // 
            this.txtItem_Code.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtItem_Code.Location = new System.Drawing.Point(65, 7);
            this.txtItem_Code.Name = "txtItem_Code";
            this.txtItem_Code.Size = new System.Drawing.Size(208, 21);
            this.txtItem_Code.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(15, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "◆ 품목";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "◆ 공정";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(13, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "◆ 설비";
            // 
            // txtFaci_Code
            // 
            this.txtFaci_Code.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtFaci_Code.Location = new System.Drawing.Point(67, 7);
            this.txtFaci_Code.Name = "txtFaci_Code";
            this.txtFaci_Code.Size = new System.Drawing.Size(208, 21);
            this.txtFaci_Code.TabIndex = 2;
            // 
            // cboFacG_Code
            // 
            this.cboFacG_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFacG_Code.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboFacG_Code.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.cboFacG_Code.FormattingEnabled = true;
            this.cboFacG_Code.Location = new System.Drawing.Point(72, 7);
            this.cboFacG_Code.Name = "cboFacG_Code";
            this.cboFacG_Code.Size = new System.Drawing.Size(180, 22);
            this.cboFacG_Code.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtItem_Code);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(25, 28);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(280, 34);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cboFacG_Code);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(359, 28);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(265, 34);
            this.panel5.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtFaci_Code);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Location = new System.Drawing.Point(688, 28);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(280, 34);
            this.panel6.TabIndex = 2;
            // 
            // dgvBOR
            // 
            this.dgvBOR.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dgvBOR.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBOR.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBOR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBOR.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBOR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBOR.IsAllCheckColumnHeader = false;
            this.dgvBOR.Location = new System.Drawing.Point(0, 0);
            this.dgvBOR.Name = "dgvBOR";
            this.dgvBOR.RowHeadersWidth = 30;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
            this.dgvBOR.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBOR.RowTemplate.Height = 23;
            this.dgvBOR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBOR.Size = new System.Drawing.Size(1090, 425);
            this.dgvBOR.TabIndex = 0;
            this.dgvBOR.TabStop = false;
            this.dgvBOR.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBOR_CellMouseDown);
            this.dgvBOR.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvBOR_RowPostPaint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // 수정ToolStripMenuItem
            // 
            this.수정ToolStripMenuItem.Name = "수정ToolStripMenuItem";
            this.수정ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 삭제ToolStripMenuItem
            // 
            this.삭제ToolStripMenuItem.Name = "삭제ToolStripMenuItem";
            this.삭제ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // BORManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1116, 602);
            this.Name = "BORManage";
            this.Text = "BOR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BORManage_FormClosing);
            this.Load += new System.EventHandler(this.BORManage_Load);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboFacG_Code;
        private System.Windows.Forms.TextBox txtFaci_Code;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtItem_Code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private JeanForm.JeansGridView dgvBOR;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 수정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 삭제ToolStripMenuItem;
    }
}
