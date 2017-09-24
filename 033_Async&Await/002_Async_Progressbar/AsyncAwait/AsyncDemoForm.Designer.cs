namespace AsyncAwait
{
    partial class AsyncDemoForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsyncDemoForm));
            this.SynchronousButton = new System.Windows.Forms.Button();
            this.AsyncButton = new System.Windows.Forms.Button();
            this.SynchronousLabel = new System.Windows.Forms.Label();
            this.AsyncLabel = new System.Windows.Forms.Label();
            this.CallbackLabel = new System.Windows.Forms.Label();
            this.CallbackButton = new System.Windows.Forms.Button();
            this.workProgressBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SynchronousButton
            // 
            this.SynchronousButton.Location = new System.Drawing.Point(3, 3);
            this.SynchronousButton.Name = "SynchronousButton";
            this.SynchronousButton.Size = new System.Drawing.Size(129, 23);
            this.SynchronousButton.TabIndex = 0;
            this.SynchronousButton.Text = "Synchronous";
            this.SynchronousButton.UseVisualStyleBackColor = true;
            this.SynchronousButton.Click += new System.EventHandler(this.SynchronousButton_Click);
            // 
            // AsyncButton
            // 
            this.AsyncButton.Location = new System.Drawing.Point(273, 3);
            this.AsyncButton.Name = "AsyncButton";
            this.AsyncButton.Size = new System.Drawing.Size(129, 23);
            this.AsyncButton.TabIndex = 2;
            this.AsyncButton.Text = "Async / Await";
            this.AsyncButton.UseVisualStyleBackColor = true;
            this.AsyncButton.Click += new System.EventHandler(this.AsyncButton_Click);
            // 
            // SynchronousLabel
            // 
            this.SynchronousLabel.AutoSize = true;
            this.SynchronousLabel.Location = new System.Drawing.Point(3, 29);
            this.SynchronousLabel.Name = "SynchronousLabel";
            this.SynchronousLabel.Size = new System.Drawing.Size(47, 13);
            this.SynchronousLabel.TabIndex = 6;
            this.SynchronousLabel.Text = "No Time";
            // 
            // AsyncLabel
            // 
            this.AsyncLabel.AutoSize = true;
            this.AsyncLabel.Location = new System.Drawing.Point(270, 29);
            this.AsyncLabel.Name = "AsyncLabel";
            this.AsyncLabel.Size = new System.Drawing.Size(47, 13);
            this.AsyncLabel.TabIndex = 8;
            this.AsyncLabel.Text = "No Time";
            // 
            // CallbackLabel
            // 
            this.CallbackLabel.AutoSize = true;
            this.CallbackLabel.Location = new System.Drawing.Point(135, 29);
            this.CallbackLabel.Name = "CallbackLabel";
            this.CallbackLabel.Size = new System.Drawing.Size(47, 13);
            this.CallbackLabel.TabIndex = 14;
            this.CallbackLabel.Text = "No Time";
            // 
            // CallbackButton
            // 
            this.CallbackButton.Location = new System.Drawing.Point(138, 3);
            this.CallbackButton.Name = "CallbackButton";
            this.CallbackButton.Size = new System.Drawing.Size(129, 23);
            this.CallbackButton.TabIndex = 12;
            this.CallbackButton.Text = "Asynchronous Callback";
            this.CallbackButton.UseVisualStyleBackColor = true;
            this.CallbackButton.Click += new System.EventHandler(this.CallbackButton_Click);
            // 
            // workProgressBar
            // 
            this.workProgressBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.workProgressBar.Location = new System.Drawing.Point(3, 54);
            this.workProgressBar.Name = "workProgressBar";
            this.workProgressBar.Size = new System.Drawing.Size(399, 26);
            this.workProgressBar.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SynchronousButton);
            this.panel1.Controls.Add(this.workProgressBar);
            this.panel1.Controls.Add(this.AsyncButton);
            this.panel1.Controls.Add(this.CallbackLabel);
            this.panel1.Controls.Add(this.SynchronousLabel);
            this.panel1.Controls.Add(this.CallbackButton);
            this.panel1.Controls.Add(this.AsyncLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 87);
            this.panel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(131, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "Processing Data...";
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AsyncDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 129);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AsyncDemoForm";
            this.Text = "Async and Await";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SynchronousButton;
        private System.Windows.Forms.Button AsyncButton;
        private System.Windows.Forms.Label SynchronousLabel;
        private System.Windows.Forms.Label AsyncLabel;
        private System.Windows.Forms.Label CallbackLabel;
        private System.Windows.Forms.Button CallbackButton;
        private System.Windows.Forms.ProgressBar workProgressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}

