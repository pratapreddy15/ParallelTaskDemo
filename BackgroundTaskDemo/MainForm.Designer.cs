namespace BackgroundTaskDemo
{
    partial class MainForm
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
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.buttonStopTimer = new System.Windows.Forms.Button();
            this.groupBoxWorker1 = new System.Windows.Forms.GroupBox();
            this.buttonWaitWorker1 = new System.Windows.Forms.Button();
            this.buttonErrWorker1 = new System.Windows.Forms.Button();
            this.progressBarWorker1 = new System.Windows.Forms.ProgressBar();
            this.buttonWorker1 = new System.Windows.Forms.Button();
            this.richTextBoxWorker1 = new System.Windows.Forms.RichTextBox();
            this.groupBoxWorker2 = new System.Windows.Forms.GroupBox();
            this.buttonWaitWorker2 = new System.Windows.Forms.Button();
            this.buttonErrWorker2 = new System.Windows.Forms.Button();
            this.progressBarWorker2 = new System.Windows.Forms.ProgressBar();
            this.buttonWorker2 = new System.Windows.Forms.Button();
            this.richTextBoxWorker2 = new System.Windows.Forms.RichTextBox();
            this.groupBoxWorker3 = new System.Windows.Forms.GroupBox();
            this.buttonErrWorker3 = new System.Windows.Forms.Button();
            this.progressBarWorker3 = new System.Windows.Forms.ProgressBar();
            this.buttonWorker3 = new System.Windows.Forms.Button();
            this.richTextBoxWorker3 = new System.Windows.Forms.RichTextBox();
            this.buttonWaitWorker3 = new System.Windows.Forms.Button();
            this.groupBoxWorker1.SuspendLayout();
            this.groupBoxWorker2.SuspendLayout();
            this.groupBoxWorker3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTime
            // 
            this.textBoxTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTime.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTime.Enabled = false;
            this.textBoxTime.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTime.ForeColor = System.Drawing.SystemColors.Desktop;
            this.textBoxTime.Location = new System.Drawing.Point(13, 13);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(371, 18);
            this.textBoxTime.TabIndex = 0;
            this.textBoxTime.Text = "{{ IN CODE }}";
            this.textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonStopTimer
            // 
            this.buttonStopTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopTimer.Location = new System.Drawing.Point(391, 13);
            this.buttonStopTimer.Name = "buttonStopTimer";
            this.buttonStopTimer.Size = new System.Drawing.Size(75, 25);
            this.buttonStopTimer.TabIndex = 1;
            this.buttonStopTimer.Text = "Stop &Timer";
            this.buttonStopTimer.UseVisualStyleBackColor = true;
            this.buttonStopTimer.Click += new System.EventHandler(this.buttonStopTimer_Click);
            // 
            // groupBoxWorker1
            // 
            this.groupBoxWorker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWorker1.Controls.Add(this.buttonWaitWorker1);
            this.groupBoxWorker1.Controls.Add(this.buttonErrWorker1);
            this.groupBoxWorker1.Controls.Add(this.progressBarWorker1);
            this.groupBoxWorker1.Controls.Add(this.buttonWorker1);
            this.groupBoxWorker1.Controls.Add(this.richTextBoxWorker1);
            this.groupBoxWorker1.Location = new System.Drawing.Point(13, 55);
            this.groupBoxWorker1.Name = "groupBoxWorker1";
            this.groupBoxWorker1.Size = new System.Drawing.Size(453, 176);
            this.groupBoxWorker1.TabIndex = 2;
            this.groupBoxWorker1.TabStop = false;
            this.groupBoxWorker1.Text = " Worker 1";
            // 
            // buttonWaitWorker1
            // 
            this.buttonWaitWorker1.Location = new System.Drawing.Point(224, 19);
            this.buttonWaitWorker1.Name = "buttonWaitWorker1";
            this.buttonWaitWorker1.Size = new System.Drawing.Size(75, 23);
            this.buttonWaitWorker1.TabIndex = 4;
            this.buttonWaitWorker1.Text = "&Pause";
            this.buttonWaitWorker1.UseVisualStyleBackColor = true;
            this.buttonWaitWorker1.Click += new System.EventHandler(this.buttonWaitWorker1_Click);
            // 
            // buttonErrWorker1
            // 
            this.buttonErrWorker1.Location = new System.Drawing.Point(114, 19);
            this.buttonErrWorker1.Name = "buttonErrWorker1";
            this.buttonErrWorker1.Size = new System.Drawing.Size(104, 23);
            this.buttonErrWorker1.TabIndex = 3;
            this.buttonErrWorker1.Text = "Throw &Exception";
            this.buttonErrWorker1.UseVisualStyleBackColor = true;
            this.buttonErrWorker1.Click += new System.EventHandler(this.buttonErrWorker1_Click);
            // 
            // progressBarWorker1
            // 
            this.progressBarWorker1.Location = new System.Drawing.Point(305, 19);
            this.progressBarWorker1.Name = "progressBarWorker1";
            this.progressBarWorker1.Size = new System.Drawing.Size(129, 23);
            this.progressBarWorker1.TabIndex = 2;
            // 
            // buttonWorker1
            // 
            this.buttonWorker1.Location = new System.Drawing.Point(20, 19);
            this.buttonWorker1.Name = "buttonWorker1";
            this.buttonWorker1.Size = new System.Drawing.Size(88, 23);
            this.buttonWorker1.TabIndex = 1;
            this.buttonWorker1.Text = "Start Worker &1";
            this.buttonWorker1.UseVisualStyleBackColor = true;
            this.buttonWorker1.Click += new System.EventHandler(this.buttonWorker1_Click);
            // 
            // richTextBoxWorker1
            // 
            this.richTextBoxWorker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxWorker1.Location = new System.Drawing.Point(20, 48);
            this.richTextBoxWorker1.Name = "richTextBoxWorker1";
            this.richTextBoxWorker1.Size = new System.Drawing.Size(414, 111);
            this.richTextBoxWorker1.TabIndex = 0;
            this.richTextBoxWorker1.Text = "";
            // 
            // groupBoxWorker2
            // 
            this.groupBoxWorker2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWorker2.Controls.Add(this.buttonWaitWorker2);
            this.groupBoxWorker2.Controls.Add(this.buttonErrWorker2);
            this.groupBoxWorker2.Controls.Add(this.progressBarWorker2);
            this.groupBoxWorker2.Controls.Add(this.buttonWorker2);
            this.groupBoxWorker2.Controls.Add(this.richTextBoxWorker2);
            this.groupBoxWorker2.Location = new System.Drawing.Point(13, 255);
            this.groupBoxWorker2.Name = "groupBoxWorker2";
            this.groupBoxWorker2.Size = new System.Drawing.Size(453, 176);
            this.groupBoxWorker2.TabIndex = 3;
            this.groupBoxWorker2.TabStop = false;
            this.groupBoxWorker2.Text = "Worker 2";
            // 
            // buttonWaitWorker2
            // 
            this.buttonWaitWorker2.Location = new System.Drawing.Point(224, 18);
            this.buttonWaitWorker2.Name = "buttonWaitWorker2";
            this.buttonWaitWorker2.Size = new System.Drawing.Size(75, 23);
            this.buttonWaitWorker2.TabIndex = 7;
            this.buttonWaitWorker2.Text = "&Pause";
            this.buttonWaitWorker2.UseVisualStyleBackColor = true;
            this.buttonWaitWorker2.Click += new System.EventHandler(this.buttonWaitWorker2_Click);
            // 
            // buttonErrWorker2
            // 
            this.buttonErrWorker2.Location = new System.Drawing.Point(114, 18);
            this.buttonErrWorker2.Name = "buttonErrWorker2";
            this.buttonErrWorker2.Size = new System.Drawing.Size(104, 23);
            this.buttonErrWorker2.TabIndex = 6;
            this.buttonErrWorker2.Text = "Throw &Exception";
            this.buttonErrWorker2.UseVisualStyleBackColor = true;
            this.buttonErrWorker2.Click += new System.EventHandler(this.buttonErrWorker2_Click);
            // 
            // progressBarWorker2
            // 
            this.progressBarWorker2.Location = new System.Drawing.Point(305, 18);
            this.progressBarWorker2.Name = "progressBarWorker2";
            this.progressBarWorker2.Size = new System.Drawing.Size(128, 23);
            this.progressBarWorker2.TabIndex = 5;
            // 
            // buttonWorker2
            // 
            this.buttonWorker2.Location = new System.Drawing.Point(19, 18);
            this.buttonWorker2.Name = "buttonWorker2";
            this.buttonWorker2.Size = new System.Drawing.Size(88, 23);
            this.buttonWorker2.TabIndex = 4;
            this.buttonWorker2.Text = "Start Worker &2";
            this.buttonWorker2.UseVisualStyleBackColor = true;
            this.buttonWorker2.Click += new System.EventHandler(this.buttonWorker2_Click);
            // 
            // richTextBoxWorker2
            // 
            this.richTextBoxWorker2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxWorker2.Location = new System.Drawing.Point(19, 47);
            this.richTextBoxWorker2.Name = "richTextBoxWorker2";
            this.richTextBoxWorker2.Size = new System.Drawing.Size(414, 111);
            this.richTextBoxWorker2.TabIndex = 3;
            this.richTextBoxWorker2.Text = "";
            // 
            // groupBoxWorker3
            // 
            this.groupBoxWorker3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWorker3.Controls.Add(this.buttonWaitWorker3);
            this.groupBoxWorker3.Controls.Add(this.buttonErrWorker3);
            this.groupBoxWorker3.Controls.Add(this.progressBarWorker3);
            this.groupBoxWorker3.Controls.Add(this.buttonWorker3);
            this.groupBoxWorker3.Controls.Add(this.richTextBoxWorker3);
            this.groupBoxWorker3.Location = new System.Drawing.Point(13, 455);
            this.groupBoxWorker3.Name = "groupBoxWorker3";
            this.groupBoxWorker3.Size = new System.Drawing.Size(453, 176);
            this.groupBoxWorker3.TabIndex = 4;
            this.groupBoxWorker3.TabStop = false;
            this.groupBoxWorker3.Text = "Worker 3";
            // 
            // buttonErrWorker3
            // 
            this.buttonErrWorker3.Location = new System.Drawing.Point(114, 18);
            this.buttonErrWorker3.Name = "buttonErrWorker3";
            this.buttonErrWorker3.Size = new System.Drawing.Size(104, 23);
            this.buttonErrWorker3.TabIndex = 9;
            this.buttonErrWorker3.Text = "Throw &Exception";
            this.buttonErrWorker3.UseVisualStyleBackColor = true;
            this.buttonErrWorker3.Click += new System.EventHandler(this.buttonErrWorker3_Click);
            // 
            // progressBarWorker3
            // 
            this.progressBarWorker3.Location = new System.Drawing.Point(305, 18);
            this.progressBarWorker3.Name = "progressBarWorker3";
            this.progressBarWorker3.Size = new System.Drawing.Size(129, 23);
            this.progressBarWorker3.TabIndex = 8;
            // 
            // buttonWorker3
            // 
            this.buttonWorker3.Location = new System.Drawing.Point(19, 18);
            this.buttonWorker3.Name = "buttonWorker3";
            this.buttonWorker3.Size = new System.Drawing.Size(88, 23);
            this.buttonWorker3.TabIndex = 7;
            this.buttonWorker3.Text = "Start Worker &3";
            this.buttonWorker3.UseVisualStyleBackColor = true;
            this.buttonWorker3.Click += new System.EventHandler(this.buttonWorker3_Click);
            // 
            // richTextBoxWorker3
            // 
            this.richTextBoxWorker3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxWorker3.Location = new System.Drawing.Point(19, 47);
            this.richTextBoxWorker3.Name = "richTextBoxWorker3";
            this.richTextBoxWorker3.Size = new System.Drawing.Size(414, 111);
            this.richTextBoxWorker3.TabIndex = 6;
            this.richTextBoxWorker3.Text = "";
            // 
            // buttonWaitWorker3
            // 
            this.buttonWaitWorker3.Location = new System.Drawing.Point(224, 18);
            this.buttonWaitWorker3.Name = "buttonWaitWorker3";
            this.buttonWaitWorker3.Size = new System.Drawing.Size(75, 23);
            this.buttonWaitWorker3.TabIndex = 10;
            this.buttonWaitWorker3.Text = "&Pause";
            this.buttonWaitWorker3.UseVisualStyleBackColor = true;
            this.buttonWaitWorker3.Click += new System.EventHandler(this.buttonWaitWorker3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 644);
            this.Controls.Add(this.groupBoxWorker3);
            this.Controls.Add(this.groupBoxWorker2);
            this.Controls.Add(this.groupBoxWorker1);
            this.Controls.Add(this.buttonStopTimer);
            this.Controls.Add(this.textBoxTime);
            this.Name = "MainForm";
            this.Text = "Background Task Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxWorker1.ResumeLayout(false);
            this.groupBoxWorker2.ResumeLayout(false);
            this.groupBoxWorker3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Button buttonStopTimer;
        private System.Windows.Forms.GroupBox groupBoxWorker1;
        private System.Windows.Forms.ProgressBar progressBarWorker1;
        private System.Windows.Forms.Button buttonWorker1;
        private System.Windows.Forms.RichTextBox richTextBoxWorker1;
        private System.Windows.Forms.GroupBox groupBoxWorker2;
        private System.Windows.Forms.ProgressBar progressBarWorker2;
        private System.Windows.Forms.Button buttonWorker2;
        private System.Windows.Forms.RichTextBox richTextBoxWorker2;
        private System.Windows.Forms.GroupBox groupBoxWorker3;
        private System.Windows.Forms.ProgressBar progressBarWorker3;
        private System.Windows.Forms.Button buttonWorker3;
        private System.Windows.Forms.RichTextBox richTextBoxWorker3;
        private System.Windows.Forms.Button buttonErrWorker1;
        private System.Windows.Forms.Button buttonErrWorker2;
        private System.Windows.Forms.Button buttonErrWorker3;
        private System.Windows.Forms.Button buttonWaitWorker1;
        private System.Windows.Forms.Button buttonWaitWorker2;
        private System.Windows.Forms.Button buttonWaitWorker3;
    }
}

