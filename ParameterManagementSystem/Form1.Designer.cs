namespace ParameterManagementSystem
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDatabaseAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxXmlFiles = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTimestamp = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonDeleteSearchingTag = new System.Windows.Forms.Button();
            this.listBoxSearchingTags = new System.Windows.Forms.ListBox();
            this.comboBoxSearchingTags = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.parameterViewList = new ParameterManagementSystem.ParameterViewList();
            this.Type = new System.Windows.Forms.Label();
            this.labelSearchParameterType = new System.Windows.Forms.Label();
            this.buttonSearchDeleteParameter = new System.Windows.Forms.Button();
            this.buttonSearchAddParameter = new System.Windows.Forms.Button();
            this.comboBoxSearchParameterName = new System.Windows.Forms.ComboBox();
            this.comboBoxSearchParameterGroup = new System.Windows.Forms.ComboBox();
            this.textBoxSearchParameterValue2 = new System.Windows.Forms.TextBox();
            this.textBoxSearchParameterValue1 = new System.Windows.Forms.TextBox();
            this.radioButtonSearchParameterRange = new System.Windows.Forms.RadioButton();
            this.radioButtonSearchParameterValue = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonAddSearchingTags = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonSearchBefore = new System.Windows.Forms.RadioButton();
            this.radioButtonSearchNone = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerSearchTo = new System.Windows.Forms.DateTimePicker();
            this.radioButtonSearchAfter = new System.Windows.Forms.RadioButton();
            this.dateTimePickerSearchFrom = new System.Windows.Forms.DateTimePicker();
            this.radioButtonSearchBetween = new System.Windows.Forms.RadioButton();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearchName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tagPanel1 = new ParameterManagementSystem.TagPanel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.buttonReloadFileList = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(755, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDatabaseToolStripMenuItem,
            this.openDatabaseToolStripMenuItem,
            this.saveDatabaseAsToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newDatabaseToolStripMenuItem
            // 
            this.newDatabaseToolStripMenuItem.Name = "newDatabaseToolStripMenuItem";
            this.newDatabaseToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.newDatabaseToolStripMenuItem.Text = "New database";
            this.newDatabaseToolStripMenuItem.Click += new System.EventHandler(this.newDatabaseToolStripMenuItem_Click);
            // 
            // openDatabaseToolStripMenuItem
            // 
            this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
            this.openDatabaseToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.openDatabaseToolStripMenuItem.Text = "Open database";
            this.openDatabaseToolStripMenuItem.Click += new System.EventHandler(this.openDatabaseToolStripMenuItem_Click);
            // 
            // saveDatabaseAsToolStripMenuItem
            // 
            this.saveDatabaseAsToolStripMenuItem.Name = "saveDatabaseAsToolStripMenuItem";
            this.saveDatabaseAsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.saveDatabaseAsToolStripMenuItem.Text = "Save as";
            this.saveDatabaseAsToolStripMenuItem.Click += new System.EventHandler(this.saveDatabaseAsToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // listBoxXmlFiles
            // 
            this.listBoxXmlFiles.FormattingEnabled = true;
            this.listBoxXmlFiles.HorizontalScrollbar = true;
            this.listBoxXmlFiles.Location = new System.Drawing.Point(0, 58);
            this.listBoxXmlFiles.Name = "listBoxXmlFiles";
            this.listBoxXmlFiles.ScrollAlwaysVisible = true;
            this.listBoxXmlFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxXmlFiles.Size = new System.Drawing.Size(255, 511);
            this.listBoxXmlFiles.TabIndex = 1;
            this.listBoxXmlFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxXmlFiles_SelectedIndexChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(0, 31);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(124, 21);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add files";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(131, 31);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(124, 21);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Remove files";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 597);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Time stamp:";
            // 
            // labelTimestamp
            // 
            this.labelTimestamp.AutoSize = true;
            this.labelTimestamp.Location = new System.Drawing.Point(81, 597);
            this.labelTimestamp.Name = "labelTimestamp";
            this.labelTimestamp.Size = new System.Drawing.Size(0, 13);
            this.labelTimestamp.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(261, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(494, 587);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonDeleteSearchingTag);
            this.tabPage1.Controls.Add(this.listBoxSearchingTags);
            this.tabPage1.Controls.Add(this.comboBoxSearchingTags);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.buttonAddSearchingTags);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.buttonClear);
            this.tabPage1.Controls.Add(this.buttonSearch);
            this.tabPage1.Controls.Add(this.textBoxSearchName);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(486, 561);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Search";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteSearchingTag
            // 
            this.buttonDeleteSearchingTag.Location = new System.Drawing.Point(199, 38);
            this.buttonDeleteSearchingTag.Name = "buttonDeleteSearchingTag";
            this.buttonDeleteSearchingTag.Size = new System.Drawing.Size(69, 22);
            this.buttonDeleteSearchingTag.TabIndex = 33;
            this.buttonDeleteSearchingTag.Text = "Delete tag";
            this.buttonDeleteSearchingTag.UseVisualStyleBackColor = true;
            this.buttonDeleteSearchingTag.Click += new System.EventHandler(this.buttonDeleteSearchingTag_Click);
            // 
            // listBoxSearchingTags
            // 
            this.listBoxSearchingTags.FormattingEnabled = true;
            this.listBoxSearchingTags.Location = new System.Drawing.Point(274, 11);
            this.listBoxSearchingTags.Name = "listBoxSearchingTags";
            this.listBoxSearchingTags.Size = new System.Drawing.Size(197, 69);
            this.listBoxSearchingTags.TabIndex = 32;
            // 
            // comboBoxSearchingTags
            // 
            this.comboBoxSearchingTags.FormattingEnabled = true;
            this.comboBoxSearchingTags.Location = new System.Drawing.Point(48, 11);
            this.comboBoxSearchingTags.Name = "comboBoxSearchingTags";
            this.comboBoxSearchingTags.Size = new System.Drawing.Size(143, 21);
            this.comboBoxSearchingTags.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.parameterViewList);
            this.panel2.Controls.Add(this.Type);
            this.panel2.Controls.Add(this.labelSearchParameterType);
            this.panel2.Controls.Add(this.buttonSearchDeleteParameter);
            this.panel2.Controls.Add(this.buttonSearchAddParameter);
            this.panel2.Controls.Add(this.comboBoxSearchParameterName);
            this.panel2.Controls.Add(this.comboBoxSearchParameterGroup);
            this.panel2.Controls.Add(this.textBoxSearchParameterValue2);
            this.panel2.Controls.Add(this.textBoxSearchParameterValue1);
            this.panel2.Controls.Add(this.radioButtonSearchParameterRange);
            this.panel2.Controls.Add(this.radioButtonSearchParameterValue);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(0, 211);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 315);
            this.panel2.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(414, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "To";
            this.label9.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "From";
            this.label1.Visible = false;
            // 
            // parameterViewList
            // 
            this.parameterViewList.AutoScroll = true;
            this.parameterViewList.AutoSize = true;
            this.parameterViewList.BackColor = System.Drawing.Color.White;
            this.parameterViewList.Location = new System.Drawing.Point(10, 106);
            this.parameterViewList.Margin = new System.Windows.Forms.Padding(4);
            this.parameterViewList.Name = "parameterViewList";
            this.parameterViewList.SelectedItem = null;
            this.parameterViewList.Size = new System.Drawing.Size(461, 214);
            this.parameterViewList.TabIndex = 40;
            // 
            // Type
            // 
            this.Type.AutoSize = true;
            this.Type.Location = new System.Drawing.Point(287, 30);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(31, 13);
            this.Type.TabIndex = 39;
            this.Type.Text = "Type";
            // 
            // labelSearchParameterType
            // 
            this.labelSearchParameterType.Location = new System.Drawing.Point(331, 22);
            this.labelSearchParameterType.Name = "labelSearchParameterType";
            this.labelSearchParameterType.Size = new System.Drawing.Size(140, 21);
            this.labelSearchParameterType.TabIndex = 38;
            // 
            // buttonSearchDeleteParameter
            // 
            this.buttonSearchDeleteParameter.Location = new System.Drawing.Point(199, 79);
            this.buttonSearchDeleteParameter.Name = "buttonSearchDeleteParameter";
            this.buttonSearchDeleteParameter.Size = new System.Drawing.Size(75, 20);
            this.buttonSearchDeleteParameter.TabIndex = 36;
            this.buttonSearchDeleteParameter.Text = "Delete";
            this.buttonSearchDeleteParameter.UseVisualStyleBackColor = true;
            this.buttonSearchDeleteParameter.Click += new System.EventHandler(this.buttonSearchDeleteParameter_Click);
            // 
            // buttonSearchAddParameter
            // 
            this.buttonSearchAddParameter.Location = new System.Drawing.Point(199, 56);
            this.buttonSearchAddParameter.Name = "buttonSearchAddParameter";
            this.buttonSearchAddParameter.Size = new System.Drawing.Size(75, 20);
            this.buttonSearchAddParameter.TabIndex = 35;
            this.buttonSearchAddParameter.Text = "Add";
            this.buttonSearchAddParameter.UseVisualStyleBackColor = true;
            this.buttonSearchAddParameter.Click += new System.EventHandler(this.buttonSearchAddParameter_Click);
            // 
            // comboBoxSearchParameterName
            // 
            this.comboBoxSearchParameterName.Location = new System.Drawing.Point(9, 75);
            this.comboBoxSearchParameterName.Name = "comboBoxSearchParameterName";
            this.comboBoxSearchParameterName.Size = new System.Drawing.Size(134, 21);
            this.comboBoxSearchParameterName.TabIndex = 34;
            this.comboBoxSearchParameterName.TextChanged += new System.EventHandler(this.comboBoxSearchParameterName_SelectedIndexChanged);
            this.comboBoxSearchParameterName.Click += new System.EventHandler(this.comboBoxSearchParameterName_Click);
            // 
            // comboBoxSearchParameterGroup
            // 
            this.comboBoxSearchParameterGroup.Location = new System.Drawing.Point(10, 33);
            this.comboBoxSearchParameterGroup.Name = "comboBoxSearchParameterGroup";
            this.comboBoxSearchParameterGroup.Size = new System.Drawing.Size(133, 21);
            this.comboBoxSearchParameterGroup.TabIndex = 33;
            this.comboBoxSearchParameterGroup.Click += new System.EventHandler(this.comboBoxSearchParameterGroup_Click);
            // 
            // textBoxSearchParameterValue2
            // 
            this.textBoxSearchParameterValue2.Location = new System.Drawing.Point(414, 79);
            this.textBoxSearchParameterValue2.Name = "textBoxSearchParameterValue2";
            this.textBoxSearchParameterValue2.Size = new System.Drawing.Size(57, 20);
            this.textBoxSearchParameterValue2.TabIndex = 32;
            this.textBoxSearchParameterValue2.Visible = false;
            // 
            // textBoxSearchParameterValue1
            // 
            this.textBoxSearchParameterValue1.Location = new System.Drawing.Point(353, 79);
            this.textBoxSearchParameterValue1.Name = "textBoxSearchParameterValue1";
            this.textBoxSearchParameterValue1.Size = new System.Drawing.Size(118, 20);
            this.textBoxSearchParameterValue1.TabIndex = 31;
            // 
            // radioButtonSearchParameterRange
            // 
            this.radioButtonSearchParameterRange.AutoSize = true;
            this.radioButtonSearchParameterRange.Location = new System.Drawing.Point(290, 79);
            this.radioButtonSearchParameterRange.Name = "radioButtonSearchParameterRange";
            this.radioButtonSearchParameterRange.Size = new System.Drawing.Size(57, 17);
            this.radioButtonSearchParameterRange.TabIndex = 30;
            this.radioButtonSearchParameterRange.TabStop = true;
            this.radioButtonSearchParameterRange.Text = "Range";
            this.radioButtonSearchParameterRange.UseVisualStyleBackColor = true;
            this.radioButtonSearchParameterRange.CheckedChanged += new System.EventHandler(this.radioButtonSearchParameterRange_CheckedChanged);
            // 
            // radioButtonSearchParameterValue
            // 
            this.radioButtonSearchParameterValue.AutoSize = true;
            this.radioButtonSearchParameterValue.Location = new System.Drawing.Point(290, 56);
            this.radioButtonSearchParameterValue.Name = "radioButtonSearchParameterValue";
            this.radioButtonSearchParameterValue.Size = new System.Drawing.Size(52, 17);
            this.radioButtonSearchParameterValue.TabIndex = 29;
            this.radioButtonSearchParameterValue.TabStop = true;
            this.radioButtonSearchParameterValue.Text = "Value";
            this.radioButtonSearchParameterValue.UseVisualStyleBackColor = true;
            this.radioButtonSearchParameterValue.CheckedChanged += new System.EventHandler(this.radioButtonSearchParameterValue_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Parameter group:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Parameter name:";
            // 
            // buttonAddSearchingTags
            // 
            this.buttonAddSearchingTags.Location = new System.Drawing.Point(199, 11);
            this.buttonAddSearchingTags.Name = "buttonAddSearchingTags";
            this.buttonAddSearchingTags.Size = new System.Drawing.Size(69, 21);
            this.buttonAddSearchingTags.TabIndex = 31;
            this.buttonAddSearchingTags.Text = "Add tag";
            this.buttonAddSearchingTags.UseVisualStyleBackColor = true;
            this.buttonAddSearchingTags.Click += new System.EventHandler(this.buttonAddSearchingTags_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonSearchBefore);
            this.panel1.Controls.Add(this.radioButtonSearchNone);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dateTimePickerSearchTo);
            this.panel1.Controls.Add(this.radioButtonSearchAfter);
            this.panel1.Controls.Add(this.dateTimePickerSearchFrom);
            this.panel1.Controls.Add(this.radioButtonSearchBetween);
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 101);
            this.panel1.TabIndex = 25;
            // 
            // radioButtonSearchBefore
            // 
            this.radioButtonSearchBefore.AutoSize = true;
            this.radioButtonSearchBefore.Location = new System.Drawing.Point(87, 29);
            this.radioButtonSearchBefore.Name = "radioButtonSearchBefore";
            this.radioButtonSearchBefore.Size = new System.Drawing.Size(56, 17);
            this.radioButtonSearchBefore.TabIndex = 8;
            this.radioButtonSearchBefore.Text = "Before";
            this.radioButtonSearchBefore.UseVisualStyleBackColor = true;
            this.radioButtonSearchBefore.CheckedChanged += new System.EventHandler(this.radioButtonSearchBefore_CheckedChanged);
            // 
            // radioButtonSearchNone
            // 
            this.radioButtonSearchNone.AutoSize = true;
            this.radioButtonSearchNone.Checked = true;
            this.radioButtonSearchNone.Location = new System.Drawing.Point(87, 77);
            this.radioButtonSearchNone.Name = "radioButtonSearchNone";
            this.radioButtonSearchNone.Size = new System.Drawing.Size(51, 17);
            this.radioButtonSearchNone.TabIndex = 24;
            this.radioButtonSearchNone.TabStop = true;
            this.radioButtonSearchNone.Text = "None";
            this.radioButtonSearchNone.UseVisualStyleBackColor = true;
            this.radioButtonSearchNone.CheckedChanged += new System.EventHandler(this.radioButtonSearchNone_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Time stamp:";
            // 
            // dateTimePickerSearchTo
            // 
            this.dateTimePickerSearchTo.CustomFormat = "yyyy MM dd       HH:mm:ss";
            this.dateTimePickerSearchTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSearchTo.Location = new System.Drawing.Point(184, 63);
            this.dateTimePickerSearchTo.Name = "dateTimePickerSearchTo";
            this.dateTimePickerSearchTo.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSearchTo.TabIndex = 23;
            this.dateTimePickerSearchTo.Visible = false;
            // 
            // radioButtonSearchAfter
            // 
            this.radioButtonSearchAfter.AutoSize = true;
            this.radioButtonSearchAfter.Cursor = System.Windows.Forms.Cursors.Default;
            this.radioButtonSearchAfter.Location = new System.Drawing.Point(87, 5);
            this.radioButtonSearchAfter.Name = "radioButtonSearchAfter";
            this.radioButtonSearchAfter.Size = new System.Drawing.Size(47, 17);
            this.radioButtonSearchAfter.TabIndex = 7;
            this.radioButtonSearchAfter.Text = "After";
            this.radioButtonSearchAfter.UseVisualStyleBackColor = true;
            this.radioButtonSearchAfter.CheckedChanged += new System.EventHandler(this.radioButtonSearchAfter_CheckedChanged);
            // 
            // dateTimePickerSearchFrom
            // 
            this.dateTimePickerSearchFrom.CustomFormat = "yyyy MM dd       HH:mm:ss";
            this.dateTimePickerSearchFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSearchFrom.Location = new System.Drawing.Point(184, 22);
            this.dateTimePickerSearchFrom.Name = "dateTimePickerSearchFrom";
            this.dateTimePickerSearchFrom.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSearchFrom.TabIndex = 20;
            this.dateTimePickerSearchFrom.Visible = false;
            this.dateTimePickerSearchFrom.ValueChanged += new System.EventHandler(this.dateTimePickerSearchFrom_ValueChanged);
            // 
            // radioButtonSearchBetween
            // 
            this.radioButtonSearchBetween.AutoSize = true;
            this.radioButtonSearchBetween.Location = new System.Drawing.Point(87, 53);
            this.radioButtonSearchBetween.Name = "radioButtonSearchBetween";
            this.radioButtonSearchBetween.Size = new System.Drawing.Size(67, 17);
            this.radioButtonSearchBetween.TabIndex = 9;
            this.radioButtonSearchBetween.Text = "Between";
            this.radioButtonSearchBetween.UseVisualStyleBackColor = true;
            this.radioButtonSearchBetween.CheckedChanged += new System.EventHandler(this.radioButtonSearchBetween_CheckedChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(246, 532);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(240, 28);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Clear filter conditions";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(0, 532);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(240, 28);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Apply filters";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearchName
            // 
            this.textBoxSearchName.Location = new System.Drawing.Point(68, 188);
            this.textBoxSearchName.Name = "textBoxSearchName";
            this.textBoxSearchName.Size = new System.Drawing.Size(403, 20);
            this.textBoxSearchName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tags:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "File name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(486, 561);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tests";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(486, 561);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Generator";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tagPanel1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(486, 561);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tags";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tagPanel1
            // 
            this.tagPanel1.Location = new System.Drawing.Point(3, 2);
            this.tagPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tagPanel1.Name = "tagPanel1";
            this.tagPanel1.SelectedXmlID = ((System.Collections.Generic.List<int>)(resources.GetObject("tagPanel1.SelectedXmlID")));
            this.tagPanel1.Size = new System.Drawing.Size(475, 400);
            this.tagPanel1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(486, 561);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Compare";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // buttonReloadFileList
            // 
            this.buttonReloadFileList.Location = new System.Drawing.Point(62, 573);
            this.buttonReloadFileList.Name = "buttonReloadFileList";
            this.buttonReloadFileList.Size = new System.Drawing.Size(124, 21);
            this.buttonReloadFileList.TabIndex = 10;
            this.buttonReloadFileList.Text = "Reload files list";
            this.buttonReloadFileList.UseVisualStyleBackColor = true;
            this.buttonReloadFileList.Click += new System.EventHandler(this.buttonReloadFileList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(755, 609);
            this.Controls.Add(this.buttonReloadFileList);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelTimestamp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxXmlFiles);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Parameter Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDatabaseAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxXmlFiles;

        public System.Windows.Forms.ListBox ListBoxXmlFiles
        {
            get { return listBoxXmlFiles; }
            set { listBoxXmlFiles = value; }
        }

        private System.Windows.Forms.Button buttonReloadFileList;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTimestamp;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearchName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonSearchBefore;
        private System.Windows.Forms.RadioButton radioButtonSearchAfter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerSearchTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerSearchFrom;
        private System.Windows.Forms.RadioButton radioButtonSearchBetween;
        private System.Windows.Forms.RadioButton radioButtonSearchNone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButtonSearchParameterRange;
        private System.Windows.Forms.RadioButton radioButtonSearchParameterValue;
        private System.Windows.Forms.ComboBox comboBoxSearchParameterName;
        private System.Windows.Forms.ComboBox comboBoxSearchParameterGroup;
        private System.Windows.Forms.TextBox textBoxSearchParameterValue2;
        private System.Windows.Forms.TextBox textBoxSearchParameterValue1;
        private System.Windows.Forms.Button buttonSearchDeleteParameter;
        private System.Windows.Forms.Button buttonSearchAddParameter;
        private System.Windows.Forms.Label Type;
        private System.Windows.Forms.Label labelSearchParameterType;
        private ParameterViewList parameterViewList;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private TagPanel tagPanel1;
        private System.Windows.Forms.ListBox listBoxSearchingTags;
        private System.Windows.Forms.Button buttonAddSearchingTags;
        private System.Windows.Forms.ComboBox comboBoxSearchingTags;
        private System.Windows.Forms.Button buttonDeleteSearchingTag;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.TabPage tabPage2;
    }
}

