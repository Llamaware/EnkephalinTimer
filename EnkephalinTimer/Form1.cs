using System.Timers;

namespace EnkephalinTimer
{
    public partial class Form1 : Form
    {
        private DateTime timerStartTime;
        private static System.Timers.Timer? countdownTimer;
        private int startValue;
        private int maxValue;

        public Form1()
        {
            InitializeComponent();

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
                //notifyIcon1.BalloonTipTitle = "Enkephalin Timer";
                //notifyIcon1.BalloonTipText = "The application is running in the system tray.";
                //notifyIcon1.ShowBalloonTip(2000);
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

            EnCounter.Text = $"{startValue}/{maxValue}";
            UpdateProgressBar();

            DisposeTimer();

            timerStartTime = DateTime.Now;

            TimeRemain.Text = FormatTime(360);

            if (startValue == maxValue)
            {
                return;
            }

            SetTimer();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (startValue >= 20)
            {
                startValue -= 20;
                EnCounter.Text = $"{startValue}/{maxValue}";
                UpdateProgressBar();

                if (startValue < maxValue && (countdownTimer == null || !countdownTimer.Enabled))
                {
                    timerStartTime = DateTime.Now;
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
                Interval = 250, // 0.25 second interval
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
            TimeSpan elapsed = DateTime.Now - timerStartTime;

            int elapsedSeconds = (int)elapsed.TotalSeconds;
            int increments = elapsedSeconds / 360;

            if (increments > 0)
            {
                startValue += increments;
                if (startValue > maxValue)
                {
                    startValue = maxValue;
                }

                timerStartTime = DateTime.Now - TimeSpan.FromSeconds(elapsedSeconds % 360);
            }

            this.Invoke((MethodInvoker)delegate
            {
                EnCounter.Text = $"{startValue}/{maxValue}";
                if (startValue >= maxValue)
                {
                    TimeRemain.Text = FormatTime(360);
                }
                else
                {
                    TimeRemain.Text = FormatTime(360 - (elapsedSeconds % 360));
                }
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
