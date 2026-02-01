namespace TestProject
{
    partial class GetPositionForm
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
            this.GetPositionStart = new System.Windows.Forms.CheckBox();
            this.ViewPositionX = new System.Windows.Forms.Label();
            this.ViewPositionY = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GetPositionStart
            // 
            this.GetPositionStart.AutoSize = true;
            this.GetPositionStart.Font = new System.Drawing.Font("標楷體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GetPositionStart.Location = new System.Drawing.Point(12, 12);
            this.GetPositionStart.Name = "GetPositionStart";
            this.GetPositionStart.Size = new System.Drawing.Size(143, 31);
            this.GetPositionStart.TabIndex = 0;
            this.GetPositionStart.Text = "獲取座標";
            this.GetPositionStart.UseVisualStyleBackColor = true;
            this.GetPositionStart.CheckedChanged += new System.EventHandler(this.GetPositionStart_CheckedChanged);
            // 
            // ViewPositionX
            // 
            this.ViewPositionX.AutoSize = true;
            this.ViewPositionX.Font = new System.Drawing.Font("標楷體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ViewPositionX.Location = new System.Drawing.Point(12, 46);
            this.ViewPositionX.Name = "ViewPositionX";
            this.ViewPositionX.Size = new System.Drawing.Size(54, 27);
            this.ViewPositionX.TabIndex = 1;
            this.ViewPositionX.Text = "X: ";
            // 
            // ViewPositionY
            // 
            this.ViewPositionY.AutoSize = true;
            this.ViewPositionY.Font = new System.Drawing.Font("標楷體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ViewPositionY.Location = new System.Drawing.Point(12, 73);
            this.ViewPositionY.Name = "ViewPositionY";
            this.ViewPositionY.Size = new System.Drawing.Size(54, 27);
            this.ViewPositionY.TabIndex = 2;
            this.ViewPositionY.Text = "Y: ";
            // 
            // GetPositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 106);
            this.Controls.Add(this.ViewPositionY);
            this.Controls.Add(this.ViewPositionX);
            this.Controls.Add(this.GetPositionStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GetPositionForm";
            this.Load += new System.EventHandler(this.GetPositionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox GetPositionStart;
        private System.Windows.Forms.Label ViewPositionX;
        private System.Windows.Forms.Label ViewPositionY;
    }
}