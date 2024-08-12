namespace EnkephalinTimer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            EnStart = new TextBox();
            EnMax = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            progressBar1 = new ProgressBar();
            groupBox1 = new GroupBox();
            EnCounter = new Label();
            TimeRemain = new Label();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            exitToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // EnStart
            // 
            EnStart.Location = new Point(155, 22);
            EnStart.Name = "EnStart";
            EnStart.Size = new Size(100, 23);
            EnStart.TabIndex = 0;
            // 
            // EnMax
            // 
            EnMax.Location = new Point(155, 51);
            EnMax.Name = "EnMax";
            EnMax.Size = new Size(100, 23);
            EnMax.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 25);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 2;
            label1.Text = "Starting Enkaphelin";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 54);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 3;
            label2.Text = "Max Enkaphelin";
            // 
            // button1
            // 
            button1.Location = new Point(44, 116);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 4;
            button1.Text = "Start Timer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(167, 116);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 5;
            button2.Text = "Craft Module";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(44, 163);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(223, 26);
            progressBar1.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(EnStart);
            groupBox1.Controls.Add(EnMax);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(280, 89);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Settings";
            // 
            // EnCounter
            // 
            EnCounter.AutoSize = true;
            EnCounter.Font = new Font("Segoe UI", 20F);
            EnCounter.Location = new Point(44, 201);
            EnCounter.Name = "EnCounter";
            EnCounter.Size = new Size(76, 37);
            EnCounter.TabIndex = 8;
            EnCounter.Text = "??/??";
            // 
            // TimeRemain
            // 
            TimeRemain.AutoSize = true;
            TimeRemain.Font = new Font("Segoe UI", 20F);
            TimeRemain.Location = new Point(199, 201);
            TimeRemain.Name = "TimeRemain";
            TimeRemain.Size = new Size(68, 37);
            TimeRemain.TabIndex = 9;
            TimeRemain.Text = "6:00";
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(94, 26);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(93, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 261);
            Controls.Add(TimeRemain);
            Controls.Add(EnCounter);
            Controls.Add(groupBox1);
            Controls.Add(progressBar1);
            Controls.Add(button2);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Enkephalin Timer";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox EnStart;
        private TextBox EnMax;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private ProgressBar progressBar1;
        private GroupBox groupBox1;
        private Label EnCounter;
        private Label TimeRemain;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}
