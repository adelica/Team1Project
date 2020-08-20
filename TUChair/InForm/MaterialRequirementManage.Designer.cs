namespace TUChair
{
    partial class MaterialRequirementManage
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtpMaterialReq = new TUChair.InDTP();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cboPlanID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvMaterialReq = new JeanForm.JeansGridView();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialReq)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvMaterialReq);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Size = new System.Drawing.Size(115, 19);
            this.label1.Text = "≡ 자재소요계획";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dtpMaterialReq);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Location = new System.Drawing.Point(544, 28);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(366, 34);
            this.panel6.TabIndex = 1;
            // 
            // dtpMaterialReq
            // 
            this.dtpMaterialReq.DateLimit = false;
            this.dtpMaterialReq.End = new System.DateTime(2020, 9, 3, 0, 0, 0, 0);
            this.dtpMaterialReq.endCustomfomat = null;
            this.dtpMaterialReq.endfomat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMaterialReq.Location = new System.Drawing.Point(105, 5);
            this.dtpMaterialReq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpMaterialReq.Name = "dtpMaterialReq";
            this.dtpMaterialReq.Size = new System.Drawing.Size(245, 26);
            this.dtpMaterialReq.Start = new System.DateTime(2020, 7, 15, 0, 0, 0, 0);
            this.dtpMaterialReq.startCustomfomat = null;
            this.dtpMaterialReq.startfomat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMaterialReq.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(19, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "◆ Date";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cboPlanID);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(55, 28);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(326, 34);
            this.panel4.TabIndex = 0;
            // 
            // cboPlanID
            // 
            this.cboPlanID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlanID.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.cboPlanID.FormattingEnabled = true;
            this.cboPlanID.Location = new System.Drawing.Point(108, 8);
            this.cboPlanID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboPlanID.Name = "cboPlanID";
            this.cboPlanID.Size = new System.Drawing.Size(208, 22);
            this.cboPlanID.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "◆ PlanID";
            // 
            // dgvMaterialReq
            // 
            this.dgvMaterialReq.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Beige;
            this.dgvMaterialReq.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaterialReq.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMaterialReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMaterialReq.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMaterialReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterialReq.IsAllCheckColumnHeader = false;
            this.dgvMaterialReq.Location = new System.Drawing.Point(0, 0);
            this.dgvMaterialReq.Name = "dgvMaterialReq";
            this.dgvMaterialReq.RowHeadersWidth = 30;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Bisque;
            this.dgvMaterialReq.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMaterialReq.RowTemplate.Height = 23;
            this.dgvMaterialReq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterialReq.Size = new System.Drawing.Size(1090, 425);
            this.dgvMaterialReq.TabIndex = 0;
            // 
            // MaterialRequirementManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1116, 602);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MaterialRequirementManage";
            this.Text = "자재소요계획";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterialRequirementManage_FormClosing);
            this.Load += new System.EventHandler(this.MaterialRequirementManage_Load);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialReq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private InDTP dtpMaterialReq;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cboPlanID;
        private System.Windows.Forms.Label label4;
        private JeanForm.JeansGridView dgvMaterialReq;
    }
}
