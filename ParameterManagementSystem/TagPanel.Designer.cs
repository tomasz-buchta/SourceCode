namespace ParameterManagementSystem
{
    partial class TagPanel
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
            this.labelDefineTag = new System.Windows.Forms.Label();
            this.textBoxDefineTag = new System.Windows.Forms.TextBox();
            this.buttonRemoveAvailTag = new System.Windows.Forms.Button();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.groupAssignedTags = new System.Windows.Forms.GroupBox();
            this.buttonRemoveAssignTag = new System.Windows.Forms.Button();
            this.listBoxAssignTags = new System.Windows.Forms.ListBox();
            this.groupAvailableTags = new System.Windows.Forms.GroupBox();
            this.listBoxAvailTags = new System.Windows.Forms.ListBox();
            this.buttonAssignTag = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupAssignedTags.SuspendLayout();
            this.groupAvailableTags.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDefineTag
            // 
            this.labelDefineTag.AutoSize = true;
            this.labelDefineTag.Location = new System.Drawing.Point(12, 30);
            this.labelDefineTag.Name = "labelDefineTag";
            this.labelDefineTag.Size = new System.Drawing.Size(79, 13);
            this.labelDefineTag.TabIndex = 17;
            this.labelDefineTag.Text = "Define new tag";
            // 
            // textBoxDefineTag
            // 
            this.textBoxDefineTag.Location = new System.Drawing.Point(15, 46);
            this.textBoxDefineTag.Name = "textBoxDefineTag";
            this.textBoxDefineTag.Size = new System.Drawing.Size(192, 20);
            this.textBoxDefineTag.TabIndex = 0;
            //this.textBoxDefineTag.TextChanged += new System.EventHandler(this.textBoxDefineTag_TextChanged);
            // 
            // buttonRemoveAvailTag
            // 
            this.buttonRemoveAvailTag.Location = new System.Drawing.Point(54, 143);
            this.buttonRemoveAvailTag.Name = "buttonRemoveAvailTag";
            this.buttonRemoveAvailTag.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveAvailTag.TabIndex = 3;
            this.buttonRemoveAvailTag.Text = "Remove";
            this.buttonRemoveAvailTag.UseVisualStyleBackColor = true;
            this.buttonRemoveAvailTag.Click += new System.EventHandler(this.buttonDeleteAvailTag_Click);
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.Location = new System.Drawing.Point(221, 44);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(50, 23);
            this.buttonAddTag.TabIndex = 1;
            this.buttonAddTag.Text = "Add";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            this.buttonAddTag.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // groupAssignedTags
            // 
            this.groupAssignedTags.Controls.Add(this.buttonRemoveAssignTag);
            this.groupAssignedTags.Controls.Add(this.listBoxAssignTags);
            this.groupAssignedTags.Location = new System.Drawing.Point(280, 95);
            this.groupAssignedTags.Name = "groupAssignedTags";
            this.groupAssignedTags.Size = new System.Drawing.Size(192, 171);
            this.groupAssignedTags.TabIndex = 2;
            this.groupAssignedTags.TabStop = false;
            this.groupAssignedTags.Text = "Assigned Tags";
            // 
            // buttonRemoveAssignTag
            // 
            this.buttonRemoveAssignTag.Location = new System.Drawing.Point(56, 142);
            this.buttonRemoveAssignTag.Name = "buttonRemoveAssignTag";
            this.buttonRemoveAssignTag.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveAssignTag.TabIndex = 6;
            this.buttonRemoveAssignTag.Text = "Remove";
            this.buttonRemoveAssignTag.UseVisualStyleBackColor = true;
            this.buttonRemoveAssignTag.Click += new System.EventHandler(this.buttonDeleteAssignTag_Click);
            // 
            // listBoxAssignTags
            // 
            this.listBoxAssignTags.FormattingEnabled = true;
            this.listBoxAssignTags.Location = new System.Drawing.Point(0, 16);
            this.listBoxAssignTags.Name = "listBoxAssignTags";
            this.listBoxAssignTags.Size = new System.Drawing.Size(192, 121);
            this.listBoxAssignTags.TabIndex = 5;
            // 
            // groupAvailableTags
            // 
            this.groupAvailableTags.Controls.Add(this.buttonRemoveAvailTag);
            this.groupAvailableTags.Controls.Add(this.listBoxAvailTags);
            this.groupAvailableTags.Location = new System.Drawing.Point(15, 95);
            this.groupAvailableTags.Name = "groupAvailableTags";
            this.groupAvailableTags.Size = new System.Drawing.Size(192, 171);
            this.groupAvailableTags.TabIndex = 1;
            this.groupAvailableTags.TabStop = false;
            this.groupAvailableTags.Text = "Available Tags";
            // 
            // listBoxAvailTags
            // 
            this.listBoxAvailTags.FormattingEnabled = true;
            this.listBoxAvailTags.Location = new System.Drawing.Point(0, 16);
            this.listBoxAvailTags.Name = "listBoxAvailTags";
            this.listBoxAvailTags.Size = new System.Drawing.Size(192, 121);
            this.listBoxAvailTags.TabIndex = 2;
            // 
            // buttonAssignTag
            // 
            this.buttonAssignTag.Location = new System.Drawing.Point(6, 13);
            this.buttonAssignTag.Name = "buttonAssignTag";
            this.buttonAssignTag.Size = new System.Drawing.Size(59, 23);
            this.buttonAssignTag.TabIndex = 4;
            this.buttonAssignTag.Text = ">>";
            this.buttonAssignTag.UseVisualStyleBackColor = true;
            this.buttonAssignTag.Click += new System.EventHandler(this.buttonAssignTag_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAssignTag);
            this.panel1.Location = new System.Drawing.Point(209, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(70, 49);
            this.panel1.TabIndex = 2;
            // 
            // TagPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupAssignedTags);
            this.Controls.Add(this.labelDefineTag);
            this.Controls.Add(this.textBoxDefineTag);
            this.Controls.Add(this.buttonAddTag);
            this.Controls.Add(this.groupAvailableTags);
            this.Name = "TagPanel";
            this.Size = new System.Drawing.Size(493, 306);
            this.groupAssignedTags.ResumeLayout(false);
            this.groupAvailableTags.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDefineTag;
        private System.Windows.Forms.TextBox textBoxDefineTag;
        private System.Windows.Forms.Button buttonRemoveAvailTag;
        private System.Windows.Forms.Button buttonAddTag;
        private System.Windows.Forms.GroupBox groupAssignedTags;
        private System.Windows.Forms.Button buttonRemoveAssignTag;
        private System.Windows.Forms.ListBox listBoxAssignTags;
        private System.Windows.Forms.GroupBox groupAvailableTags;
        private System.Windows.Forms.ListBox listBoxAvailTags;
        private System.Windows.Forms.Button buttonAssignTag;
        private System.Windows.Forms.Panel panel1;
    }
}
