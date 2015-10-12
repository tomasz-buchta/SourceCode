namespace ParameterManagementSystem
{
    partial class AutomaticTestsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.StartStopButton = new System.Windows.Forms.Button();
            this.TestProgressBar = new System.Windows.Forms.ProgressBar();
            this.StopButton = new System.Windows.Forms.Button();
            this.CLearLogButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.TestFolder = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDefineTag = new System.Windows.Forms.Label();
            this.textBoxDefineTag = new System.Windows.Forms.TextBox();
            this.groupAvailableTags = new System.Windows.Forms.GroupBox();
            this.groupAvailableTags.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogTextBox
            // 
            this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTextBox.Location = new System.Drawing.Point(7, 19);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(445, 160);
            this.LogTextBox.TabIndex = 0;
            this.LogTextBox.WordWrap = false;
            // 
            // StartStopButton
            // 
            this.StartStopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartStopButton.Location = new System.Drawing.Point(3, 346);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(80, 25);
            this.StartStopButton.TabIndex = 1;
            this.StartStopButton.Text = "Start";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // TestProgressBar
            // 
            this.TestProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TestProgressBar.Location = new System.Drawing.Point(-13, 315);
            this.TestProgressBar.Name = "TestProgressBar";
            this.TestProgressBar.Size = new System.Drawing.Size(473, 25);
            this.TestProgressBar.TabIndex = 2;
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(89, 346);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(80, 25);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // CLearLogButton
            // 
            this.CLearLogButton.Location = new System.Drawing.Point(371, 185);
            this.CLearLogButton.Name = "CLearLogButton";
            this.CLearLogButton.Size = new System.Drawing.Size(80, 25);
            this.CLearLogButton.TabIndex = 4;
            this.CLearLogButton.Text = "Clear log";
            this.CLearLogButton.UseVisualStyleBackColor = true;
            this.CLearLogButton.Click += new System.EventHandler(this.CLearLogButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestFolder
            // 
            this.TestFolder.Location = new System.Drawing.Point(375, 20);
            this.TestFolder.Name = "TestFolder";
            this.TestFolder.Size = new System.Drawing.Size(85, 25);
            this.TestFolder.TabIndex = 6;
            this.TestFolder.Text = "Browse";
            this.TestFolder.UseVisualStyleBackColor = true;
            this.TestFolder.Click += new System.EventHandler(this.TestFolder_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(366, 20);
            this.textBox1.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Script path:";
            // 
            // labelDefineTag
            // 
            this.labelDefineTag.AutoSize = true;
            this.labelDefineTag.Location = new System.Drawing.Point(0, 4);
            this.labelDefineTag.Name = "labelDefineTag";
            this.labelDefineTag.Size = new System.Drawing.Size(92, 13);
            this.labelDefineTag.TabIndex = 34;
            this.labelDefineTag.Text = "Destination folder:";
            // 
            // textBoxDefineTag
            // 
            this.textBoxDefineTag.Location = new System.Drawing.Point(3, 20);
            this.textBoxDefineTag.Name = "textBoxDefineTag";
            this.textBoxDefineTag.Size = new System.Drawing.Size(366, 20);
            this.textBoxDefineTag.TabIndex = 31;
            this.textBoxDefineTag.TextChanged += new System.EventHandler(this.textBoxDefineTag_TextChanged);
            // 
            // groupAvailableTags
            // 
            this.groupAvailableTags.Controls.Add(this.LogTextBox);
            this.groupAvailableTags.Controls.Add(this.CLearLogButton);
            this.groupAvailableTags.Location = new System.Drawing.Point(3, 93);
            this.groupAvailableTags.Name = "groupAvailableTags";
            this.groupAvailableTags.Size = new System.Drawing.Size(457, 216);
            this.groupAvailableTags.TabIndex = 32;
            this.groupAvailableTags.TabStop = false;
            this.groupAvailableTags.Text = "Log";
            // 
            // AutomaticTestsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TestFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDefineTag);
            this.Controls.Add(this.textBoxDefineTag);
            this.Controls.Add(this.groupAvailableTags);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.TestProgressBar);
            this.Controls.Add(this.StartStopButton);
            this.Name = "AutomaticTestsUserControl";
            this.Size = new System.Drawing.Size(463, 385);
            this.groupAvailableTags.ResumeLayout(false);
            this.groupAvailableTags.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.ProgressBar TestProgressBar;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button CLearLogButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button TestFolder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDefineTag;
        private System.Windows.Forms.TextBox textBoxDefineTag;
        private System.Windows.Forms.GroupBox groupAvailableTags;
    }
}
