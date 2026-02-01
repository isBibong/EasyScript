namespace TestProject
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileController = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.腳本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeScriptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopScriptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.LoopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TemplateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetPositionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.幫助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGuideMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = new System.Drawing.Point(1, 25);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(283, 387);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileController,
            this.腳本ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.幫助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(285, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileController
            // 
            this.FileController.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileMenuItem,
            this.saveFileMenuItem,
            this.toolStripMenuItem1,
            this.closeMenuItem});
            this.FileController.Name = "FileController";
            this.FileController.Size = new System.Drawing.Size(43, 20);
            this.FileController.Text = "檔案";
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileMenuItem.Size = new System.Drawing.Size(166, 22);
            this.openFileMenuItem.Text = "開啟";
            this.openFileMenuItem.Click += new System.EventHandler(this.OpenFileMenuItem_Click);
            // 
            // saveFileMenuItem
            // 
            this.saveFileMenuItem.Name = "saveFileMenuItem";
            this.saveFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveFileMenuItem.Size = new System.Drawing.Size(166, 22);
            this.saveFileMenuItem.Text = "儲存";
            this.saveFileMenuItem.Click += new System.EventHandler(this.SaveFileMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 6);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.closeMenuItem.Size = new System.Drawing.Size(166, 22);
            this.closeMenuItem.Text = "關閉程式";
            this.closeMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // 腳本ToolStripMenuItem
            // 
            this.腳本ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeScriptMenuItem,
            this.stopScriptMenuItem,
            this.toolStripMenuItem2,
            this.LoopMenuItem});
            this.腳本ToolStripMenuItem.Name = "腳本ToolStripMenuItem";
            this.腳本ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.腳本ToolStripMenuItem.Text = "腳本";
            // 
            // executeScriptMenuItem
            // 
            this.executeScriptMenuItem.Name = "executeScriptMenuItem";
            this.executeScriptMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.executeScriptMenuItem.Size = new System.Drawing.Size(180, 22);
            this.executeScriptMenuItem.Text = "執行腳本";
            this.executeScriptMenuItem.Click += new System.EventHandler(this.ExecuteScriptMenuItem_ClickAsync);
            // 
            // stopScriptMenuItem
            // 
            this.stopScriptMenuItem.Enabled = false;
            this.stopScriptMenuItem.Name = "stopScriptMenuItem";
            this.stopScriptMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.stopScriptMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stopScriptMenuItem.Text = "停止腳本";
            this.stopScriptMenuItem.Click += new System.EventHandler(this.StopScriptMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // LoopMenuItem
            // 
            this.LoopMenuItem.Name = "LoopMenuItem";
            this.LoopMenuItem.Size = new System.Drawing.Size(180, 22);
            this.LoopMenuItem.Text = "循環運行(開啟)";
            this.LoopMenuItem.Click += new System.EventHandler(this.LoopMenuItem_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TemplateMenuItem,
            this.GetPositionMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // TemplateMenuItem
            // 
            this.TemplateMenuItem.Name = "TemplateMenuItem";
            this.TemplateMenuItem.Size = new System.Drawing.Size(122, 22);
            this.TemplateMenuItem.Text = "使用範本";
            this.TemplateMenuItem.Click += new System.EventHandler(this.TemplateMenuItem_Click);
            // 
            // GetPositionMenuItem
            // 
            this.GetPositionMenuItem.Name = "GetPositionMenuItem";
            this.GetPositionMenuItem.Size = new System.Drawing.Size(122, 22);
            this.GetPositionMenuItem.Text = "獲取座標";
            this.GetPositionMenuItem.Click += new System.EventHandler(this.GetPositionMenuItem_Click);
            // 
            // 幫助ToolStripMenuItem
            // 
            this.幫助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userGuideMenuItem,
            this.aboutMenuItem});
            this.幫助ToolStripMenuItem.Name = "幫助ToolStripMenuItem";
            this.幫助ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.幫助ToolStripMenuItem.Text = "幫助";
            // 
            // userGuideMenuItem
            // 
            this.userGuideMenuItem.Name = "userGuideMenuItem";
            this.userGuideMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.userGuideMenuItem.Size = new System.Drawing.Size(166, 22);
            this.userGuideMenuItem.Text = "使用說明";
            this.userGuideMenuItem.Click += new System.EventHandler(this.UserGuideMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.aboutMenuItem.Size = new System.Drawing.Size(166, 22);
            this.aboutMenuItem.Text = "關於";
            this.aboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(285, 413);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "EasyScript";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileController;
        private System.Windows.Forms.ToolStripMenuItem 腳本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeScriptMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopScriptMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 幫助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userGuideMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TemplateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GetPositionMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem LoopMenuItem;
    }
}

