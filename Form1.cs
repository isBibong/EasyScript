using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace TestProject
{
    public partial class MainForm : Form
    {
        private bool loop = false;
        private bool _isRunning = false;
        private readonly ManualResetEventSlim _pauseEvent = new ManualResetEventSlim(true);

        private AsyncTimer _scriptTimer;

        /*
         * 
        */
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /*
         * 
        */
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (EasyScript.Properties.Settings.Default.IsFirstRun)
            {
                UserGuideMenuItem_Click(null, EventArgs.Empty);
                EasyScript.Properties.Settings.Default.IsFirstRun = false;
                EasyScript.Properties.Settings.Default.Save();
            }

            richTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
            RegisterHotKey(Handle, 1, 0x0000, (uint)Keys.F8);
            RegisterHotKey(Handle, 3, 0x0000, (uint)Keys.F10);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Shutdown();
            UnregisterHotKey(Handle, 1);
            UnregisterHotKey(Handle, 2);
            UnregisterHotKey(Handle, 3);
        }

        private void RichTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);

                if (!string.IsNullOrEmpty(clipboardText))
                {
                    richTextBox1.SelectedText = clipboardText;
                }
            }
        }

        private void OpenFileMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "文字檔|*.txt|所有檔案|*.*",
                InitialDirectory = Application.StartupPath
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = System.IO.File.ReadAllText(ofd.FileName);
            }
        }
        private void SaveFileMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("內容是空的，沒什麼好存的喔！");
                return;
            }

            // 建立儲存檔案對話框
            SaveFileDialog sfd = new SaveFileDialog();

            // 設定預設副檔名與篩選器
            sfd.Filter = "EasyScript 腳本 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            sfd.FileName = "MyScript.txt"; // 預設檔名

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 將 richTextBox1 的所有文字寫入選定的路徑
                    System.IO.File.WriteAllText(sfd.FileName, richTextBox1.Text);

                    MessageBox.Show("腳本儲存成功！", "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("儲存失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = CheckCloseMessage();

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private async void ExecuteScriptMenuItem_ClickAsync(object sender, EventArgs e)
        {
            if (_isRunning) return;

            Text = "EasyScript (運作中)";
            _isRunning = true;
            _pauseEvent.Set();

            richTextBox1.ReadOnly = true;

            openFileMenuItem.Enabled = false;
            saveFileMenuItem.Enabled = false;
            closeMenuItem.Enabled = false;

            executeScriptMenuItem.Enabled = false;
            stopScriptMenuItem.Enabled = true;
            LoopMenuItem.Enabled = false;

            TemplateMenuItem.Enabled = false;
            GetPositionMenuItem.Enabled = false;

            userGuideMenuItem.Enabled = false;
            aboutMenuItem.Enabled = false;

            // 啟動 Timer
            InitScriptTimer();
            _scriptTimer.Start();
        }
        private void StopScriptMenuItem_Click(object sender, EventArgs e)
        {
            Shutdown();
        }
        private void LoopMenuItem_Click(object sender, EventArgs e)
        {
            loop = !loop;
            if (loop)
            {
                LoopMenuItem.Text = "循環運行(關閉)";
            }
            else
            {
                LoopMenuItem.Text = "循環運行(開啟)";
            }
        }

        private void TemplateMenuItem_Click(object sender, EventArgs e)
        {
            string templateScript = @"#棕2活動自動下一場
#--------------
#右下角
#--------------
mouse,move,1700,1010
other,wait,100
mouse,press,left
#--------------
#間隔
#--------------
other,wait,1000
#--------------
#確認
#--------------
mouse,move,1035,600
other,wait,100
mouse,press,left
#--------------
#等待完場
#--------------
other,wait,30000
";

            richTextBox1.Text = templateScript; // 這次用覆蓋的方式
        }
        private void GetPositionMenuItem_Click(object sender, EventArgs e)
        {
            GetPositionForm getPositionForm = new GetPositionForm();
            getPositionForm.Show();
        }

        private void UserGuideMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"指令:
滑鼠類 --------------
Mouse,Down,<left/right> - 滑鼠按下
Mouse,Up,<left/right> - 滑鼠彈起
Mouse,Press,<left/right> - 滑鼠點擊
Mouse,Move,<xPoint>,<yPoint> - 移動滑鼠

鍵盤類 --------------
Keyboard,Down,<key> - 鍵盤按下
Keyboard,Up,<key> - 鍵盤彈起
Keyboard,Press,<key> - 鍵盤點擊
Keyboard,Msg,<msg> - 輸出訊息
Keyboard,Cut - 組合鍵: Ctrl+X
Keyboard,Copy - 組合鍵: Ctrl+C
Keyboard,Paste - 組合鍵: Ctrl+V

其他類 --------------
Other,Wait,<msTime> - 以毫秒為單位的間隔時間
Other,Fpt,<path>,<findTime> - 找尋類似畫面，持續N秒
# - 註解

小提醒 --------------
1. 指令大小寫不影響執行。
2. 使用Down後一定要使用Up，否則可能要重開腳本。", "說明");
        }
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EasyScript b1.3 簡易腳本工具\n作者: Bibong", "關於");
        }

        /*
         * Check Hotkey
        */
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY)
            {
                int id = m.WParam.ToInt32();
                switch (id)
                {
                    case 1:
                        if (!_isRunning)
                        {
                            ExecuteScriptMenuItem_ClickAsync(null, EventArgs.Empty);
                        }
                        break;

                    case 3:
                        if (stopScriptMenuItem.Enabled)
                        {
                            StopScriptMenuItem_Click(null, EventArgs.Empty);
                        }
                        break;
                }
            }
            base.WndProc(ref m);
        }

        private void InitScriptTimer()
        {
            string[] lines = richTextBox1.Lines;
            List<IScriptCommand> commands = new List<IScriptCommand>();
            foreach (var line in lines)
            {
                var cmd = CommandFactory.Parse(line);
                if (cmd != null && line[0] != '#') commands.Add(cmd);
            }

            _scriptTimer = new AsyncTimer(async () =>
            {
                foreach (var cmd in commands)
                {
                    if (!_scriptTimer.IsRunning) break;

                    if (_scriptTimer.Token.IsCancellationRequested) break;

                    await cmd.ExecuteAsync(_scriptTimer.Token);
                }
            }, 1);

            if (!loop)
            {
                Invoke(new Action(() => Shutdown()));
            }
        }

        public void Shutdown()
        {
            _scriptTimer?.Stop();
            _pauseEvent.Set();

            if (InvokeRequired)
            {
                Invoke(new Action(Shutdown));
                return;
            }

            ScriptStop_ViewController();
            KeyboardController.ReleaseAll();
            KeyboardController._holdingCts?.Cancel();
        }
        private void ScriptStop_ViewController()
        {
            Text = "EasyScript";
            richTextBox1.ReadOnly = false;

            openFileMenuItem.Enabled = true;
            saveFileMenuItem.Enabled = true;
            closeMenuItem.Enabled = true;

            executeScriptMenuItem.Enabled = true;
            stopScriptMenuItem.Enabled = false;
            LoopMenuItem.Enabled = true;

            TemplateMenuItem.Enabled = true;
            GetPositionMenuItem.Enabled = true;

            userGuideMenuItem.Enabled = true;
            aboutMenuItem.Enabled = true;

            _isRunning = false;
        }

        private DialogResult CheckCloseMessage()
        {
            return MessageBox.Show("確定要關閉了嗎? 腳本都保存好了嗎?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}