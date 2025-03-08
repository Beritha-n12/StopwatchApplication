using System;
using System.Windows.Forms;

namespace StopwatchApp  // ✅ Ensure this matches Program.cs
{
    public partial class MainForm : Form
    {
        // ✅ Initialize fields to avoid nullability warnings
        private Label lblTimer = new Label();
        private Button btnStart = new Button();
        private Button btnPause = new Button();
        private Button btnResume = new Button();
        private Button btnReset = new Button();
        private Button btnStop = new Button();
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private int elapsedSeconds = 0;
        private bool isRunning = false;

        /// <summary>
        /// Initializes the form and its components.
        /// </summary>
        public MainForm()
        {
            InitializeUI(); 
            InitializeStopwatch();
        }

        /// <summary>
        /// Sets up the UI components manually.
        /// </summary>
        private void InitializeUI()
        {
            this.Text = "Stopwatch Application";
            this.Size = new System.Drawing.Size(400, 250);

            lblTimer = new Label()
            {
                Text = "00:00:00",
                Font = new System.Drawing.Font("Arial", 20),
                Location = new System.Drawing.Point(120, 30),
                AutoSize = true
            };

            btnStart = new Button() { Text = "Start", Location = new System.Drawing.Point(50, 100) };
            btnPause = new Button() { Text = "Pause", Location = new System.Drawing.Point(120, 100) };
            btnResume = new Button() { Text = "Resume", Location = new System.Drawing.Point(190, 100) };
            btnReset = new Button() { Text = "Reset", Location = new System.Drawing.Point(260, 100) };
            btnStop = new Button() { Text = "Stop", Location = new System.Drawing.Point(150, 150) };

            // Attach event handlers
            btnStart.Click += btnStart_Click;
            btnPause.Click += btnPause_Click;
            btnResume.Click += btnResume_Click;
            btnReset.Click += btnReset_Click;
            btnStop.Click += btnStop_Click;

            // Set button styles
            btnStart.FlatStyle = FlatStyle.Flat;
            btnPause.FlatStyle = FlatStyle.Flat;
            btnResume.FlatStyle = FlatStyle.Flat;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnStop.FlatStyle = FlatStyle.Flat;

            // Set button colors
            btnStart.BackColor = Color.Green;
            btnPause.BackColor = Color.Yellow;
            btnResume.BackColor = Color.Green;
            btnReset.BackColor = Color.Red;
            btnStop.BackColor = Color.Red;

            // Set button sizes
            btnStart.Size = new System.Drawing.Size(80, 40);
            btnPause.Size = new System.Drawing.Size(80, 40);
            btnResume.Size = new System.Drawing.Size(80, 40);
            btnReset.Size = new System.Drawing.Size(80, 40);
            btnStop.Size = new System.Drawing.Size(80, 40);

            // Set button fonts
            btnStart.Font = new System.Drawing.Font("Arial", 12);
            btnPause.Font = new System.Drawing.Font("Arial", 12);
            btnResume.Font = new System.Drawing.Font("Arial", 12);

            // Add UI elements to the form
            this.Controls.Add(lblTimer);
            this.Controls.Add(btnStart);
            this.Controls.Add(btnPause);
            this.Controls.Add(btnResume);
            this.Controls.Add(btnReset);
            this.Controls.Add(btnStop);
        }

        /// <summary>
        /// Initializes the Stopwatch timer.
        /// </summary>
        private void InitializeStopwatch()
        {
            timer.Interval = 1000; // 1-second interval
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Updates the stopwatch time display every second.
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e) // ✅ Removed nullable `?`
        {
            if (isRunning)
            {
                elapsedSeconds++;
                UpdateTimeLabel();
            }
        }

        /// <summary>
        /// Updates the label to display elapsed time in HH:MM:SS format.
        /// </summary>
        private void UpdateTimeLabel()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedSeconds);
            lblTimer.Text = timeSpan.ToString(@"hh\:mm\:ss");
        }

        /// <summary>
        /// Starts the stopwatch from 00:00:00.
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e) // ✅ Removed nullable `?`
        {
            elapsedSeconds = 0;
            isRunning = true;
            timer.Start();
            UpdateTimeLabel();
        }

        /// <summary>
        /// Pauses the stopwatch.
        /// </summary>
        private void btnPause_Click(object sender, EventArgs e) // ✅ Removed nullable `?`
        {
            isRunning = false;
        }

        /// <summary>
        /// Resumes the stopwatch from the last paused time.
        /// </summary>
        private void btnResume_Click(object sender, EventArgs e) // ✅ Removed nullable `?`
        {
            isRunning = true;
        }

        /// <summary>
        /// Resets the stopwatch to 00:00:00.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e) // ✅ Removed nullable `?`
        {
            timer.Stop();
            elapsedSeconds = 0;
            isRunning = false;
            UpdateTimeLabel();
        }

        /// <summary>
        /// Stops the stopwatch completely.
        /// </summary>
        private void btnStop_Click(object sender, EventArgs e) // ✅ Removed nullable `?`
        {
            timer.Stop();
            isRunning = false;
        }
    }
}
