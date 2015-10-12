namespace ParameterManagementSystem
{
    partial class FileGeneratorUserControl
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
            this.NewNameLabel = new System.Windows.Forms.Label();
            this.NewNameTextBox = new System.Windows.Forms.TextBox();
            this.FileTreeView = new System.Windows.Forms.TreeView();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.PreviewGroupBox = new System.Windows.Forms.GroupBox();
            this.VarAmountLabel = new System.Windows.Forms.Label();
            this.ModifiyInicatorCheckBox = new System.Windows.Forms.CheckBox();
            this.AttributeLevelLabel = new System.Windows.Forms.Label();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.AttributeValueLabel = new System.Windows.Forms.Label();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.AttributeTypeLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.AttributeHintLabel = new System.Windows.Forms.Label();
            this.HintLabel = new System.Windows.Forms.Label();
            this.AttributeNameLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.EditButton = new System.Windows.Forms.Button();
            this.ClearCurrentButton = new System.Windows.Forms.Button();
            this.ClearAllButton = new System.Windows.Forms.Button();
            this.PreviewGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewNameLabel
            // 
            this.NewNameLabel.AutoSize = true;
            this.NewNameLabel.Location = new System.Drawing.Point(4, 27);
            this.NewNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NewNameLabel.Name = "NewNameLabel";
            this.NewNameLabel.Size = new System.Drawing.Size(78, 17);
            this.NewNameLabel.TabIndex = 0;
            this.NewNameLabel.Text = "New name:";
            // 
            // NewNameTextBox
            // 
            this.NewNameTextBox.Location = new System.Drawing.Point(93, 23);
            this.NewNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.NewNameTextBox.Name = "NewNameTextBox";
            this.NewNameTextBox.Size = new System.Drawing.Size(540, 22);
            this.NewNameTextBox.TabIndex = 1;
            // 
            // FileTreeView
            // 
            this.FileTreeView.Location = new System.Drawing.Point(4, 85);
            this.FileTreeView.Margin = new System.Windows.Forms.Padding(4);
            this.FileTreeView.Name = "FileTreeView";
            this.FileTreeView.Size = new System.Drawing.Size(323, 555);
            this.FileTreeView.TabIndex = 2;
            this.FileTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FileTreeView_AfterSelect);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(381, 516);
            this.GenerateButton.Margin = new System.Windows.Forms.Padding(4);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(200, 37);
            this.GenerateButton.TabIndex = 3;
            this.GenerateButton.Text = "Generate variations";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // PreviewGroupBox
            // 
            this.PreviewGroupBox.Controls.Add(this.VarAmountLabel);
            this.PreviewGroupBox.Controls.Add(this.ModifiyInicatorCheckBox);
            this.PreviewGroupBox.Controls.Add(this.AttributeLevelLabel);
            this.PreviewGroupBox.Controls.Add(this.LevelLabel);
            this.PreviewGroupBox.Controls.Add(this.AttributeValueLabel);
            this.PreviewGroupBox.Controls.Add(this.ValueLabel);
            this.PreviewGroupBox.Controls.Add(this.AttributeTypeLabel);
            this.PreviewGroupBox.Controls.Add(this.TypeLabel);
            this.PreviewGroupBox.Controls.Add(this.AttributeHintLabel);
            this.PreviewGroupBox.Controls.Add(this.HintLabel);
            this.PreviewGroupBox.Controls.Add(this.AttributeNameLabel);
            this.PreviewGroupBox.Controls.Add(this.NameLabel);
            this.PreviewGroupBox.Location = new System.Drawing.Point(336, 85);
            this.PreviewGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.PreviewGroupBox.Name = "PreviewGroupBox";
            this.PreviewGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.PreviewGroupBox.Size = new System.Drawing.Size(303, 258);
            this.PreviewGroupBox.TabIndex = 4;
            this.PreviewGroupBox.TabStop = false;
            this.PreviewGroupBox.Text = "Preview";
            // 
            // VarAmountLabel
            // 
            this.VarAmountLabel.Location = new System.Drawing.Point(159, 183);
            this.VarAmountLabel.Margin = new System.Windows.Forms.Padding(4);
            this.VarAmountLabel.Name = "VarAmountLabel";
            this.VarAmountLabel.Size = new System.Drawing.Size(48, 22);
            this.VarAmountLabel.TabIndex = 8;
            this.VarAmountLabel.Visible = true;
            // 
            // ModifiyInicatorCheckBox
            // 
            this.ModifiyInicatorCheckBox.AutoSize = true;
            this.ModifiyInicatorCheckBox.Location = new System.Drawing.Point(80, 185);
            this.ModifiyInicatorCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.ModifiyInicatorCheckBox.Name = "ModifiyInicatorCheckBox";
            this.ModifiyInicatorCheckBox.Size = new System.Drawing.Size(71, 21);
            this.ModifiyInicatorCheckBox.TabIndex = 10;
            this.ModifiyInicatorCheckBox.Text = "Varied";
            this.ModifiyInicatorCheckBox.UseVisualStyleBackColor = true;
            // 
            // AttributeLevelLabel
            // 
            this.AttributeLevelLabel.AutoSize = true;
            this.AttributeLevelLabel.Location = new System.Drawing.Point(80, 222);
            this.AttributeLevelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AttributeLevelLabel.Name = "AttributeLevelLabel";
            this.AttributeLevelLabel.Size = new System.Drawing.Size(37, 17);
            this.AttributeLevelLabel.TabIndex = 9;
            this.AttributeLevelLabel.Text = "level";
            // 
            // LevelLabel
            // 
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.Location = new System.Drawing.Point(27, 222);
            this.LevelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(42, 17);
            this.LevelLabel.TabIndex = 8;
            this.LevelLabel.Text = "Level";
            // 
            // AttributeValueLabel
            // 
            this.AttributeValueLabel.AutoSize = true;
            this.AttributeValueLabel.Location = new System.Drawing.Point(80, 148);
            this.AttributeValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AttributeValueLabel.Name = "AttributeValueLabel";
            this.AttributeValueLabel.Size = new System.Drawing.Size(42, 17);
            this.AttributeValueLabel.TabIndex = 7;
            this.AttributeValueLabel.Text = "value";
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(27, 148);
            this.ValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(44, 17);
            this.ValueLabel.TabIndex = 6;
            this.ValueLabel.Text = "Value";
            // 
            // AttributeTypeLabel
            // 
            this.AttributeTypeLabel.AutoSize = true;
            this.AttributeTypeLabel.Location = new System.Drawing.Point(80, 111);
            this.AttributeTypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AttributeTypeLabel.Name = "AttributeTypeLabel";
            this.AttributeTypeLabel.Size = new System.Drawing.Size(35, 17);
            this.AttributeTypeLabel.TabIndex = 5;
            this.AttributeTypeLabel.Text = "type";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(27, 111);
            this.TypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(40, 17);
            this.TypeLabel.TabIndex = 4;
            this.TypeLabel.Text = "Type";
            // 
            // AttributeHintLabel
            // 
            this.AttributeHintLabel.AutoSize = true;
            this.AttributeHintLabel.Location = new System.Drawing.Point(80, 74);
            this.AttributeHintLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AttributeHintLabel.Name = "AttributeHintLabel";
            this.AttributeHintLabel.Size = new System.Drawing.Size(31, 17);
            this.AttributeHintLabel.TabIndex = 3;
            this.AttributeHintLabel.Text = "hint";
            // 
            // HintLabel
            // 
            this.HintLabel.AutoSize = true;
            this.HintLabel.Location = new System.Drawing.Point(27, 74);
            this.HintLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HintLabel.Name = "HintLabel";
            this.HintLabel.Size = new System.Drawing.Size(33, 17);
            this.HintLabel.TabIndex = 2;
            this.HintLabel.Text = "Hint";
            // 
            // AttributeNameLabel
            // 
            this.AttributeNameLabel.AutoSize = true;
            this.AttributeNameLabel.Location = new System.Drawing.Point(80, 37);
            this.AttributeNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AttributeNameLabel.Name = "AttributeNameLabel";
            this.AttributeNameLabel.Size = new System.Drawing.Size(43, 17);
            this.AttributeNameLabel.TabIndex = 1;
            this.AttributeNameLabel.Text = "name";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(27, 37);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(45, 17);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Location = new System.Drawing.Point(381, 383);
            this.EditButton.Margin = new System.Windows.Forms.Padding(4);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(200, 37);
            this.EditButton.TabIndex = 5;
            this.EditButton.Text = "Vary";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // ClearCurrentButton
            // 
            this.ClearCurrentButton.Location = new System.Drawing.Point(381, 427);
            this.ClearCurrentButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClearCurrentButton.Name = "ClearCurrentButton";
            this.ClearCurrentButton.Size = new System.Drawing.Size(200, 37);
            this.ClearCurrentButton.TabIndex = 6;
            this.ClearCurrentButton.Text = "Clear curent variation";
            this.ClearCurrentButton.UseVisualStyleBackColor = true;
            this.ClearCurrentButton.Click += new System.EventHandler(this.ClearCurrentButton_Click);
            // 
            // ClearAllButton
            // 
            this.ClearAllButton.Location = new System.Drawing.Point(381, 471);
            this.ClearAllButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClearAllButton.Name = "ClearAllButton";
            this.ClearAllButton.Size = new System.Drawing.Size(200, 37);
            this.ClearAllButton.TabIndex = 7;
            this.ClearAllButton.Text = "Clear all variations";
            this.ClearAllButton.UseVisualStyleBackColor = true;
            this.ClearAllButton.Click += new System.EventHandler(this.ClearAllButton_Click);
            // 
            // FileGeneratorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ClearAllButton);
            this.Controls.Add(this.ClearCurrentButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.PreviewGroupBox);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.FileTreeView);
            this.Controls.Add(this.NewNameTextBox);
            this.Controls.Add(this.NewNameLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FileGeneratorUserControl";
            this.Size = new System.Drawing.Size(639, 645);
            this.PreviewGroupBox.ResumeLayout(false);
            this.PreviewGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NewNameLabel;
        private System.Windows.Forms.TextBox NewNameTextBox;
        private System.Windows.Forms.TreeView FileTreeView;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.GroupBox PreviewGroupBox;
        private System.Windows.Forms.Label AttributeLevelLabel;
        private System.Windows.Forms.Label LevelLabel;
        private System.Windows.Forms.Label AttributeValueLabel;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.Label AttributeTypeLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label AttributeHintLabel;
        private System.Windows.Forms.Label HintLabel;
        private System.Windows.Forms.Label AttributeNameLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.CheckBox ModifiyInicatorCheckBox;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button ClearCurrentButton;
        private System.Windows.Forms.Button ClearAllButton;
        private System.Windows.Forms.Label VarAmountLabel;
    }
}
