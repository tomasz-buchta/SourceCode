namespace ParameterManagementSystem
{
    partial class CompareUserControl
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
            this.parameterNameTextBox = new System.Windows.Forms.TextBox();
            this.compareButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contentsPanel = new System.Windows.Forms.Panel();
            this.radioButtonShowRange = new System.Windows.Forms.RadioButton();
            this.radioButtonShowOccurences = new System.Windows.Forms.RadioButton();
            this.checkBoxShowOnlyDifferences = new System.Windows.Forms.CheckBox();
            this.radioButtonShowAll = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // parameterNameTextBox
            // 
            this.parameterNameTextBox.Location = new System.Drawing.Point(93, 24);
            this.parameterNameTextBox.Name = "parameterNameTextBox";
            this.parameterNameTextBox.Size = new System.Drawing.Size(171, 20);
            this.parameterNameTextBox.TabIndex = 0;
            // 
            // compareButton
            // 
            this.compareButton.Location = new System.Drawing.Point(270, 22);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(75, 23);
            this.compareButton.TabIndex = 1;
            this.compareButton.Text = "Compare";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Parameter Name:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.contentsPanel, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 95);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(476, 426);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(87, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Parameter";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(334, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Values";
            // 
            // contentsPanel
            // 
            this.contentsPanel.AutoScroll = true;
            this.contentsPanel.AutoScrollMinSize = new System.Drawing.Size(900, 0);
            this.contentsPanel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.contentsPanel, 2);
            this.contentsPanel.Location = new System.Drawing.Point(3, 23);
            this.contentsPanel.MinimumSize = new System.Drawing.Size(470, 435);
            this.contentsPanel.Name = "contentsPanel";
            this.contentsPanel.Size = new System.Drawing.Size(470, 435);
            this.contentsPanel.TabIndex = 2;
            // 
            // radioButtonShowRange
            // 
            this.radioButtonShowRange.AutoSize = true;
            this.radioButtonShowRange.Checked = true;
            this.radioButtonShowRange.Location = new System.Drawing.Point(351, 0);
            this.radioButtonShowRange.Name = "radioButtonShowRange";
            this.radioButtonShowRange.Size = new System.Drawing.Size(87, 17);
            this.radioButtonShowRange.TabIndex = 4;
            this.radioButtonShowRange.TabStop = true;
            this.radioButtonShowRange.Text = "Show ranges";
            this.radioButtonShowRange.UseVisualStyleBackColor = true;
            // 
            // radioButtonShowOccurences
            // 
            this.radioButtonShowOccurences.AutoSize = true;
            this.radioButtonShowOccurences.Location = new System.Drawing.Point(351, 24);
            this.radioButtonShowOccurences.Name = "radioButtonShowOccurences";
            this.radioButtonShowOccurences.Size = new System.Drawing.Size(114, 17);
            this.radioButtonShowOccurences.TabIndex = 5;
            this.radioButtonShowOccurences.Text = "Show occurrences";
            this.radioButtonShowOccurences.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowOnlyDifferences
            // 
            this.checkBoxShowOnlyDifferences.AutoSize = true;
            this.checkBoxShowOnlyDifferences.Location = new System.Drawing.Point(349, 70);
            this.checkBoxShowOnlyDifferences.Name = "checkBoxShowOnlyDifferences";
            this.checkBoxShowOnlyDifferences.Size = new System.Drawing.Size(130, 17);
            this.checkBoxShowOnlyDifferences.TabIndex = 6;
            this.checkBoxShowOnlyDifferences.Text = "Show only differences";
            this.checkBoxShowOnlyDifferences.UseVisualStyleBackColor = true;
            // 
            // radioButtonShowAll
            // 
            this.radioButtonShowAll.AutoSize = true;
            this.radioButtonShowAll.Location = new System.Drawing.Point(351, 47);
            this.radioButtonShowAll.Name = "radioButtonShowAll";
            this.radioButtonShowAll.Size = new System.Drawing.Size(99, 17);
            this.radioButtonShowAll.TabIndex = 7;
            this.radioButtonShowAll.Text = "Show all values";
            this.radioButtonShowAll.UseVisualStyleBackColor = true;
            // 
            // CompareUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioButtonShowAll);
            this.Controls.Add(this.checkBoxShowOnlyDifferences);
            this.Controls.Add(this.radioButtonShowOccurences);
            this.Controls.Add(this.radioButtonShowRange);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.parameterNameTextBox);
            this.Name = "CompareUserControl";
            this.Size = new System.Drawing.Size(479, 524);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox parameterNameTextBox;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel contentsPanel;
        private System.Windows.Forms.RadioButton radioButtonShowRange;
        private System.Windows.Forms.RadioButton radioButtonShowOccurences;
        private System.Windows.Forms.CheckBox checkBoxShowOnlyDifferences;
        private System.Windows.Forms.RadioButton radioButtonShowAll;
    }
}
