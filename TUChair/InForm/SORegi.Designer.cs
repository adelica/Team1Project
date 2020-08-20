namespace TUChair
{
    partial class SORegi
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
            this.label3 = new System.Windows.Forms.Label();
            this.cboComCode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtShipQty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtWorkOrder = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPurchaseOrder = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cboItemCode = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.None;
            this.panel1.Location = new System.Drawing.Point(9, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Size = new System.Drawing.Size(757, 391);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtOther);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Location = new System.Drawing.Point(5, 283);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Size = new System.Drawing.Size(747, 100);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtQty);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.txtPurchaseOrder);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.cboItemCode);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Location = new System.Drawing.Point(380, 10);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Size = new System.Drawing.Size(373, 267);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpDueDate);
            this.panel2.Controls.Add(this.txtWorkOrder);
            this.panel2.Controls.Add(this.txtShipQty);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.cboComCode);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(5, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Size = new System.Drawing.Size(372, 267);
            // 
            // btnInsert
            // 
            this.btnInsert.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInsert.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInsert.TabIndex = 14;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(32, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 19;
            this.label1.Text = "◆ 고객 WO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(32, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 19;
            this.label3.Text = "◆ 고객사";
            // 
            // cboComCode
            // 
            this.cboComCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComCode.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.cboComCode.FormattingEnabled = true;
            this.cboComCode.Location = new System.Drawing.Point(152, 88);
            this.cboComCode.Name = "cboComCode";
            this.cboComCode.Size = new System.Drawing.Size(208, 22);
            this.cboComCode.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(32, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 14);
            this.label7.TabIndex = 19;
            this.label7.Text = "◆ 납기일";
            // 
            // txtShipQty
            // 
            this.txtShipQty.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtShipQty.Location = new System.Drawing.Point(152, 214);
            this.txtShipQty.Name = "txtShipQty";
            this.txtShipQty.Size = new System.Drawing.Size(208, 21);
            this.txtShipQty.TabIndex = 4;
            this.txtShipQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(32, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 14);
            this.label10.TabIndex = 22;
            this.label10.Text = "◆ 출고수량";
            // 
            // txtWorkOrder
            // 
            this.txtWorkOrder.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtWorkOrder.Location = new System.Drawing.Point(152, 24);
            this.txtWorkOrder.Name = "txtWorkOrder";
            this.txtWorkOrder.Size = new System.Drawing.Size(208, 21);
            this.txtWorkOrder.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(26, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 14);
            this.label15.TabIndex = 28;
            this.label15.Text = "◆ 고객주문번호";
            // 
            // txtPurchaseOrder
            // 
            this.txtPurchaseOrder.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtPurchaseOrder.Location = new System.Drawing.Point(138, 18);
            this.txtPurchaseOrder.Name = "txtPurchaseOrder";
            this.txtPurchaseOrder.Size = new System.Drawing.Size(208, 21);
            this.txtPurchaseOrder.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(26, 90);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 14);
            this.label19.TabIndex = 28;
            this.label19.Text = "◆ 품목";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtQty.Location = new System.Drawing.Point(138, 151);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(208, 21);
            this.txtQty.TabIndex = 10;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label21.Location = new System.Drawing.Point(26, 154);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 14);
            this.label21.TabIndex = 19;
            this.label21.Text = "◆ 주문수량";
            // 
            // cboItemCode
            // 
            this.cboItemCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemCode.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.cboItemCode.FormattingEnabled = true;
            this.cboItemCode.Location = new System.Drawing.Point(138, 88);
            this.cboItemCode.Name = "cboItemCode";
            this.cboItemCode.Size = new System.Drawing.Size(208, 22);
            this.cboItemCode.TabIndex = 9;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(26, 4);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(43, 14);
            this.label27.TabIndex = 28;
            this.label27.Text = "◆ 비고";
            // 
            // txtOther
            // 
            this.txtOther.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.txtOther.Location = new System.Drawing.Point(147, 3);
            this.txtOther.Multiline = true;
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(577, 94);
            this.txtOther.TabIndex = 13;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDueDate.Font = new System.Drawing.Font("나눔고딕", 8.999999F);
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(152, 156);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(208, 21);
            this.dtpDueDate.TabIndex = 24;
            // 
            // SORegi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(774, 450);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SORegi";
            this.Text = "S/O";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cboComCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtPurchaseOrder;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboItemCode;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtWorkOrder;
        private System.Windows.Forms.TextBox txtShipQty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
    }
}
