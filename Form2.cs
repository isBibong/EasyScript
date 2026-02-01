using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestProject
{
    public partial class GetPositionForm : Form
    {
        private AsyncTimer getPositionTimer;

        public GetPositionForm()
        {
            InitializeComponent();
        }

        private void GetPositionForm_Load(object sender, EventArgs e)
        {
            InitGetPositionTimer();
        }

        private void GetPositionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            getPositionTimer.Stop();
        }

        private void GetPositionStart_CheckedChanged(object sender, EventArgs e)
        {
            if (GetPositionStart.Checked)
            {
                getPositionTimer.Start();
            }
            else
            {
                getPositionTimer.Stop();
            }
        }

        private void InitGetPositionTimer()
        {
            getPositionTimer = new AsyncTimer(async () =>
            {
                Point cursorPoint = Cursor.Position;

                int x = cursorPoint.X;
                int y = cursorPoint.Y;
                this.Invoke(new Action(() =>
                {
                    ViewPositionX.Text = $"X: {x}";
                    ViewPositionY.Text = $"Y: {y}";
                }));
            }, 10);
        }
    }
}
