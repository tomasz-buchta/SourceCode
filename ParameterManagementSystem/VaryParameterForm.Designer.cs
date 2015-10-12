namespace ParameterManagementSystem
{
    partial class VaryParameterForm
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.HintLabel = new System.Windows.Forms.Label();
            this.AttributeNameLabel = new System.Windows.Forms.Label();
            this.AttribueHintLabel = new System.Windows.Forms.Label();
            this.ValueBox = new System.Windows.Forms.GroupBox();
            this.ListRemoveButton = new System.Windows.Forms.Button();
            this.ListAddButton = new System.Windows.Forms.Button();
            this.ListAddTextBox = new System.Windows.Forms.TextBox();
            this.ListListBox = new System.Windows.Forms.ListBox();
            this.RangePlaceholder2Label = new System.Windows.Forms.Label();
            this.RangePlaceholder1Label = new System.Windows.Forms.Label();
            this.RangeStepTextBox = new System.Windows.Forms.TextBox();
            this.RangeMaxTextBox = new System.Windows.Forms.TextBox();
            this.RangeMinTextBox = new System.Windows.Forms.TextBox();
            this.SingleTextBox = new System.Windows.Forms.TextBox();
            this.SingleRadioButton = new System.Windows.Forms.RadioButton();
            this.RangeRadioButton = new System.Windows.Forms.RadioButton();
            this.ListRadioButton = new System.Windows.Forms.RadioButton();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.CancelButton_ = new System.Windows.Forms.Button();
            this.ValueBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(10, 5);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // HintLabel
            // 
            this.HintLabel.AutoSize = true;
            this.HintLabel.Location = new System.Drawing.Point(10, 25);
            this.HintLabel.Name = "HintLabel";
            this.HintLabel.Size = new System.Drawing.Size(26, 13);
            this.HintLabel.TabIndex = 1;
            this.HintLabel.Text = "Hint";
            // 
            // AttributeNameLabel
            // 
            this.AttributeNameLabel.AutoSize = true;
            this.AttributeNameLabel.Location = new System.Drawing.Point(60, 5);
            this.AttributeNameLabel.Name = "AttributeNameLabel";
            this.AttributeNameLabel.Size = new System.Drawing.Size(35, 13);
            this.AttributeNameLabel.TabIndex = 2;
            this.AttributeNameLabel.Text = "label3";
            // 
            // AttribueHintLabel
            // 
            this.AttribueHintLabel.AutoSize = true;
            this.AttribueHintLabel.Location = new System.Drawing.Point(60, 25);
            this.AttribueHintLabel.Name = "AttribueHintLabel";
            this.AttribueHintLabel.Size = new System.Drawing.Size(35, 13);
            this.AttribueHintLabel.TabIndex = 3;
            this.AttribueHintLabel.Text = "label4";
            // 
            // ValueBox
            // 
            this.ValueBox.Controls.Add(this.ListRemoveButton);
            this.ValueBox.Controls.Add(this.ListAddButton);
            this.ValueBox.Controls.Add(this.ListAddTextBox);
            this.ValueBox.Controls.Add(this.ListListBox);
            this.ValueBox.Controls.Add(this.RangePlaceholder2Label);
            this.ValueBox.Controls.Add(this.RangePlaceholder1Label);
            this.ValueBox.Controls.Add(this.RangeStepTextBox);
            this.ValueBox.Controls.Add(this.RangeMaxTextBox);
            this.ValueBox.Controls.Add(this.RangeMinTextBox);
            this.ValueBox.Controls.Add(this.SingleTextBox);
            this.ValueBox.Controls.Add(this.SingleRadioButton);
            this.ValueBox.Controls.Add(this.RangeRadioButton);
            this.ValueBox.Controls.Add(this.ListRadioButton);
            this.ValueBox.Location = new System.Drawing.Point(3, 43);
            this.ValueBox.Name = "ValueBox";
            this.ValueBox.Size = new System.Drawing.Size(280, 190);
            this.ValueBox.TabIndex = 4;
            this.ValueBox.TabStop = false;
            this.ValueBox.Text = "Value";
            // 
            // ListRemoveButton
            // 
            this.ListRemoveButton.Location = new System.Drawing.Point(214, 65);
            this.ListRemoveButton.Name = "ListRemoveButton";
            this.ListRemoveButton.Size = new System.Drawing.Size(60, 20);
            this.ListRemoveButton.TabIndex = 10;
            this.ListRemoveButton.Text = "Remove";
            this.ListRemoveButton.UseVisualStyleBackColor = true;
            this.ListRemoveButton.Click += new System.EventHandler(this.ListRemoveButton_Click);
            // 
            // ListAddButton
            // 
            this.ListAddButton.Location = new System.Drawing.Point(171, 65);
            this.ListAddButton.Name = "ListAddButton";
            this.ListAddButton.Size = new System.Drawing.Size(41, 20);
            this.ListAddButton.TabIndex = 9;
            this.ListAddButton.Text = "Add";
            this.ListAddButton.UseVisualStyleBackColor = true;
            this.ListAddButton.Click += new System.EventHandler(this.ListAddButton_Click);
            // 
            // ListAddTextBox
            // 
            this.ListAddTextBox.Location = new System.Drawing.Point(57, 65);
            this.ListAddTextBox.Name = "ListAddTextBox";
            this.ListAddTextBox.Size = new System.Drawing.Size(113, 20);
            this.ListAddTextBox.TabIndex = 8;
            // 
            // ListListBox
            // 
            this.ListListBox.FormattingEnabled = true;
            this.ListListBox.Location = new System.Drawing.Point(58, 91);
            this.ListListBox.Name = "ListListBox";
            this.ListListBox.Size = new System.Drawing.Size(216, 95);
            this.ListListBox.TabIndex = 7;
            this.ListListBox.SelectedIndexChanged += new System.EventHandler(this.ListListBox_SelectedIndexChanged);
            // 
            // RangePlaceholder2Label
            // 
            this.RangePlaceholder2Label.AutoSize = true;
            this.RangePlaceholder2Label.Location = new System.Drawing.Point(183, 42);
            this.RangePlaceholder2Label.Name = "RangePlaceholder2Label";
            this.RangePlaceholder2Label.Size = new System.Drawing.Size(30, 13);
            this.RangePlaceholder2Label.TabIndex = 6;
            this.RangePlaceholder2Label.Text = "step:";
            // 
            // RangePlaceholder1Label
            // 
            this.RangePlaceholder1Label.AutoSize = true;
            this.RangePlaceholder1Label.Location = new System.Drawing.Point(108, 42);
            this.RangePlaceholder1Label.Name = "RangePlaceholder1Label";
            this.RangePlaceholder1Label.Size = new System.Drawing.Size(10, 13);
            this.RangePlaceholder1Label.TabIndex = 5;
            this.RangePlaceholder1Label.Text = "-";
            // 
            // RangeStepTextBox
            // 
            this.RangeStepTextBox.Location = new System.Drawing.Point(224, 39);
            this.RangeStepTextBox.Name = "RangeStepTextBox";
            this.RangeStepTextBox.Size = new System.Drawing.Size(50, 20);
            this.RangeStepTextBox.TabIndex = 4;
            // 
            // RangeMaxTextBox
            // 
            this.RangeMaxTextBox.Location = new System.Drawing.Point(120, 39);
            this.RangeMaxTextBox.Name = "RangeMaxTextBox";
            this.RangeMaxTextBox.Size = new System.Drawing.Size(50, 20);
            this.RangeMaxTextBox.TabIndex = 3;
            // 
            // RangeMinTextBox
            // 
            this.RangeMinTextBox.Location = new System.Drawing.Point(57, 39);
            this.RangeMinTextBox.Name = "RangeMinTextBox";
            this.RangeMinTextBox.Size = new System.Drawing.Size(50, 20);
            this.RangeMinTextBox.TabIndex = 2;
            // 
            // SingleTextBox
            // 
            this.SingleTextBox.Location = new System.Drawing.Point(57, 16);
            this.SingleTextBox.Name = "SingleTextBox";
            this.SingleTextBox.Size = new System.Drawing.Size(216, 20);
            this.SingleTextBox.TabIndex = 1;
            // 
            // SingleRadioButton
            // 
            this.SingleRadioButton.AutoSize = true;
            this.SingleRadioButton.Location = new System.Drawing.Point(4, 19);
            this.SingleRadioButton.Name = "SingleRadioButton";
            this.SingleRadioButton.Size = new System.Drawing.Size(54, 17);
            this.SingleRadioButton.TabIndex = 0;
            this.SingleRadioButton.TabStop = true;
            this.SingleRadioButton.Text = "Single";
            this.SingleRadioButton.UseVisualStyleBackColor = true;
            this.SingleRadioButton.CheckedChanged += new System.EventHandler(this.SingleRadioButton_CheckedChanged);
            // 
            // RangeRadioButton
            // 
            this.RangeRadioButton.AutoSize = true;
            this.RangeRadioButton.Location = new System.Drawing.Point(4, 42);
            this.RangeRadioButton.Name = "RangeRadioButton";
            this.RangeRadioButton.Size = new System.Drawing.Size(57, 17);
            this.RangeRadioButton.TabIndex = 0;
            this.RangeRadioButton.TabStop = true;
            this.RangeRadioButton.Text = "Range";
            this.RangeRadioButton.UseVisualStyleBackColor = true;
            this.RangeRadioButton.CheckedChanged += new System.EventHandler(this.RangeRadioButton_CheckedChanged);
            // 
            // ListRadioButton
            // 
            this.ListRadioButton.AutoSize = true;
            this.ListRadioButton.Location = new System.Drawing.Point(3, 65);
            this.ListRadioButton.Name = "ListRadioButton";
            this.ListRadioButton.Size = new System.Drawing.Size(41, 17);
            this.ListRadioButton.TabIndex = 0;
            this.ListRadioButton.TabStop = true;
            this.ListRadioButton.Text = "List";
            this.ListRadioButton.UseVisualStyleBackColor = true;
            this.ListRadioButton.CheckedChanged += new System.EventHandler(this.ListRadioButton_CheckedChanged);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(33, 235);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(100, 25);
            this.ApplyButton.TabIndex = 5;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CancelButton_
            // 
            this.CancelButton_.Location = new System.Drawing.Point(160, 235);
            this.CancelButton_.Name = "CancelButton_";
            this.CancelButton_.Size = new System.Drawing.Size(100, 25);
            this.CancelButton_.TabIndex = 6;
            this.CancelButton_.Text = "Cancel";
            this.CancelButton_.UseVisualStyleBackColor = true;
            this.CancelButton_.Click += new System.EventHandler(this.CancelButton__Click);
            // 
            // VaryParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.CancelButton_);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.ValueBox);
            this.Controls.Add(this.AttribueHintLabel);
            this.Controls.Add(this.AttributeNameLabel);
            this.Controls.Add(this.HintLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "VaryParameterForm";
            this.Text = "Vary Parameter";
            this.ValueBox.ResumeLayout(false);
            this.ValueBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label HintLabel;
        private System.Windows.Forms.Label AttributeNameLabel;
        private System.Windows.Forms.Label AttribueHintLabel;
        private System.Windows.Forms.GroupBox ValueBox;
        private System.Windows.Forms.RadioButton ListRadioButton;
        private System.Windows.Forms.RadioButton RangeRadioButton;
        private System.Windows.Forms.RadioButton SingleRadioButton;
        private System.Windows.Forms.TextBox SingleTextBox;
        private System.Windows.Forms.Label RangePlaceholder2Label;
        private System.Windows.Forms.Label RangePlaceholder1Label;
        private System.Windows.Forms.TextBox RangeStepTextBox;
        private System.Windows.Forms.TextBox RangeMaxTextBox;
        private System.Windows.Forms.TextBox RangeMinTextBox;
        private System.Windows.Forms.Button ListRemoveButton;
        private System.Windows.Forms.Button ListAddButton;
        private System.Windows.Forms.TextBox ListAddTextBox;
        private System.Windows.Forms.ListBox ListListBox;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button CancelButton_;
    }
}