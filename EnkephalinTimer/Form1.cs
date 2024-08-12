using System;
using System.Timers;
using System.Windows.Forms;

namespace EnkephalinTimer
{
    public partial class Form1 : Form
    {
        private int remainingTime;
        private static System.Timers.Timer? countdownTimer;
        private int startValue;
        private int maxValue;

        public Form1()
        {
            InitializeComponent();

            // Set up NotifyIcon
            notifyIcon1.Icon = Properties.Resources.AppIcon;
            notifyIcon1.Visible = false;
            notifyIcon1.Text = "Enkephalin Timer";
            notifyIcon1.MouseClick += NotifyIcon1_MouseClick;
        }

        private void NotifyIcon1_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            else if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipTitle = "Enkephalin Timer";
                notifyIcon1.BalloonTipText = "The application is running in the system tray.";
                notifyIcon1.ShowBalloonTip(2000);
            }
            else
            {
                notifyIcon1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out startValue, out maxValue))
            {
                return;
            }

            // Update the EnCounter label and progress bar
            EnCounter.Text = $"{startValue}/{maxValue}";
            UpdateProgressBar();

            // Reset timer if already running
            if (countdownTimer != null && countdownTimer.Enabled)
            {
                DisposeTimer();
            }

            remainingTime = 360;  // Initialize to 6 minutes
            TimeRemain.Text = FormatTime(remainingTime);

            if (startValue == maxValue)
            {
                return;
            }

            SetTimer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Decrease startValue by 20 but not below 0
            if (startValue >= 20)
            {
                startValue -= 20;
                EnCounter.Text = $"{startValue}/{maxValue}";
                UpdateProgressBar();

                // Start the timer if not running
                if (startValue < maxValue && (countdownTimer == null || !countdownTimer.Enabled))
                {
                    remainingTime = 360;  // Initialize to 6 minutes
                    SetTimer();
                }
            }
            else
            {
                MessageBox.Show("Not enough resources.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetTimer()
        {
            DisposeTimer();
            countdownTimer = new System.Timers.Timer
            {
                Interval = 1000, // 1 second interval
                AutoReset = true,
                Enabled = true
            };
            countdownTimer.Elapsed += OnTimedEvent;
        }

        private void DisposeTimer()
        {
            countdownTimer?.Stop();
            countdownTimer?.Dispose();
            countdownTimer = null;
        }

        private void OnTimedEvent(object? source, ElapsedEventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;
                this.Invoke((MethodInvoker)delegate
                {
                    TimeRemain.Text = FormatTime(remainingTime);
                });
            }
            else
            {
                remainingTime = 360; // Reset to 6 minutes
                startValue++;

                this.Invoke((MethodInvoker)delegate
                {
                    EnCounter.Text = $"{startValue}/{maxValue}";
                    TimeRemain.Text = FormatTime(remainingTime);
                    UpdateProgressBar();
                });

                if (startValue >= maxValue)
                {
                    notifyIcon1.BalloonTipTitle = "Enkephalin Timer";
                    notifyIcon1.BalloonTipText = "Resources are full.";
                    notifyIcon1.ShowBalloonTip(2000);
                    DisposeTimer();
                }
            }
        }

        private string FormatTime(int totalSeconds)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            return $"{minutes:0}:{seconds:00}";
        }

        private void UpdateProgressBar()
        {
            progressBar1.Value = maxValue > 0 ? (int)((float)startValue / maxValue * 100) : 0;
        }

        private bool ValidateInput(out int startValue, out int maxValue)
        {
            startValue = 0;
            maxValue = 0;

            if (string.IsNullOrWhiteSpace(EnStart.Text) || string.IsNullOrWhiteSpace(EnMax.Text))
            {
                MessageBox.Show("Please fill in both Starting and Max values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(EnStart.Text, out startValue) || !int.TryParse(EnMax.Text, out maxValue))
            {
                MessageBox.Show("Please enter valid integer values for Starting and Max.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (startValue > maxValue)
            {
                MessageBox.Show("Starting value cannot be greater than Max value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
