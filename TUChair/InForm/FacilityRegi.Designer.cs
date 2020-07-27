namespace TUChair.InForm
{
    partial class FacilityRegi
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
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Size = new System.Drawing.Size(255, 165);
            // 
            // panel3
            // 
            this.panel3.Size = new System.Drawing.Size(255, 165);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(3, 174);
            this.panel4.Size = new System.Drawing.Size(761, 202);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(255, 165);
            // 
            // button1
            // 
            this.btnInsert.TabIndex = 0;
            // 
            // button2
            // 
            this.btnCancle.TabIndex = 1;
            // 
            // FacilityRegi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(776, 450);
            this.Name = "FacilityRegi";
            this.Text = "설비";
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
