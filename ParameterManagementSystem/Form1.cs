using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ParameterManagementSystem.Xml;

namespace ParameterManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            _xmlManager.InitXmlFilesList();
            autoTestCtrl = new AutomaticTestsUserControl(_xmlManager.XmlFilesList, listBoxXmlFiles);
            fileGeneratorControl = new FileGeneratorUserControl(listBoxXmlFiles);
            tabPage2.Controls.Add(autoTestCtrl);
            tabPage3.Controls.Add(fileGeneratorControl);
            searchingParameters = new SearchingParameters();
            compareUserControl = new CompareUserControl(_xmlManager.XmlFilesList, listBoxXmlFiles);
            tabPage5.Controls.Add(compareUserControl);
            FileInfo configFile = new FileInfo("config.ini");
            if (configFile.Exists)
            {
                string path;
                using (StreamReader sr = File.OpenText(configFile.ToString()))
                {
                    path = sr.ReadLine();
                }
                if (!"".Equals(path))
                {
                    SetNewDatabase(path);
                    ClearXmlFilesList();
                    listBoxXmlFiles.SuspendLayout();
                    _xmlManager.LoadXmlFilesFromDatabase();
                    ReloadListBox();

                    listBoxXmlFiles.ResumeLayout();
                    listBoxXmlFiles.PerformLayout();

                    tagPanel1.LoadTagsFromDatabase(_xmlManager.DataBase);
                    tagPanel1.LoadRelationsFromDatabase(_xmlManager.DataBase);
                }
            }
            if (_xmlManager.XmlFilesList.Count == 0)
            {
                tabControl1.Enabled = false;
            }
        }

        public void UpdateComboBoxTags()
        {
            comboBoxSearchingTags.Items.Clear();
            foreach (Tag item in tagPanel1.tagList.Values)
            {
                comboBoxSearchingTags.Items.Add(item.Name);
            }
        }

        private void newDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteDatabase();
            ClearXmlFilesList();
        }

        private void ClearXmlFilesList()
        {
            _xmlManager.ClearXmlFilesList();
            listBoxXmlFiles.Items.Clear();
            fileGeneratorControl.clearFileTree();
    
        }

        private void DeleteDatabase()
        {
            this.Text = "Parameter Manager";
            _xmlManager.DeleteDataBase();
            tabControl1.Enabled = false;
        }

        private void SetNewDatabase(string name)
        {
             
            _xmlManager.SetDataBase(name);
            this.Text = "Parameter Manager: " + Path.GetFileName(name);
            autoTestCtrl.Database = _xmlManager.DataBase;
            string path = "config.ini";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(name);
            }
            if (_xmlManager.XmlFilesList.Count > 0)
            {
                tabControl1.Enabled = true;
            }
        }
        

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Filter = "xml files (*.xml)|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                

                List<string> xmlNames = _xmlManager.LoadXmlFilesFromFileNames(dialog.FileNames);
                if (xmlNames != null)
                {
                    listBoxXmlFiles.Items.AddRange(xmlNames.ToArray());
                }
            }
            if (_xmlManager.XmlFilesList.Count > 0)
            {
                tabControl1.Enabled = true;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Object[] selectedItems = new Object[listBoxXmlFiles.SelectedItems.Count];
            listBoxXmlFiles.SelectedItems.CopyTo(selectedItems, 0);
            foreach (Object item in selectedItems)
            {
                if (item != null && item is string)
                {
                    _xmlManager.DeleteFromRelationsList((string)item);
                    listBoxXmlFiles.Items.Remove((string)item);
                }
            }

            if( (listBoxXmlFiles.Items.Count == 0) || (listBoxXmlFiles.SelectedItems.Count == 0))
            {
                fileGeneratorControl.clearFileTree();
                tabControl1.Enabled = false;
            }

        }

        private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "mdb files (*.mdb)|*.mdb";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(dialog.FileName))
                {
                    return;
                }

                SetNewDatabase(dialog.FileName);
                ClearXmlFilesList();
                listBoxXmlFiles.SuspendLayout();
                _xmlManager.LoadXmlFilesFromDatabase();
                ReloadListBox();

                listBoxXmlFiles.ResumeLayout();
                listBoxXmlFiles.PerformLayout();

                tagPanel1.LoadTagsFromDatabase(_xmlManager.DataBase);
                tagPanel1.LoadRelationsFromDatabase(_xmlManager.DataBase);
            }
        }

        private void saveDatabaseAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "mdb files (*.mdb)|*.mdb";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileListToDatabase(dialog.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (_xmlManager.DataBase != null)
            {
                SaveFileListToDatabase(_xmlManager.DataBase.Name);
            }
            else
            {
                saveDatabaseAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void SaveFileListToDatabase(string name)
        {
            SetNewDatabase(name);
            
            try
            {
                _xmlManager.SaveFileListToDatabase(name);
            }
            catch(Exception e)
            {
                MessageBox.Show("Database " + Path.GetFileName(name) + " could not be created",
                        "Error creating new database",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                DeleteDatabase();
                return;
            }

            DataBase dataBase = _xmlManager.DataBase;

            tagPanel1.SaveTags(dataBase);
            tagPanel1.SaveRelations(dataBase);
        }

        private void listBoxXmlFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxXmlFiles.SelectedItem == null)
            {
                buttonDelete.Enabled = false;
                comboBoxSearchParameterGroup.Items.Clear();
                comboBoxSearchParameterGroup.ResetText();
                comboBoxSearchParameterName.Items.Clear();
                comboBoxSearchParameterName.ResetText();            
                return;
            }
            comboBoxSearchParameterGroup.Items.Clear();
            comboBoxSearchParameterGroup.ResetText();
            comboBoxSearchParameterName.Items.Clear();
            comboBoxSearchParameterName.ResetText();
            buttonDelete.Enabled = true;

            tabControl1.Enabled = true;

            string xmlName = (string)listBoxXmlFiles.SelectedItem;

            labelTimestamp.Text = _xmlManager.GetTimeStampForSelectedFile(xmlName).ToString();

            fileGeneratorControl.recreateFileTree();

            ListBox.SelectedIndexCollection indices = listBoxXmlFiles.SelectedIndices;

            List<int> id_list = new List<int>();
            foreach (int i in indices)
            {
                id_list.Add(i);
            }
            tagPanel1.SelectedXmlID = id_list;

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxSearchName.Text = "";
            radioButtonSearchNone.Checked = true;
            parameterViewList.ClearParameterList();
            searchingParameters.Parameters.Clear();
            searchingParameters.SearchingTagsIDs.Clear();
            listBoxSearchingTags.Items.Clear();
            ReloadListBox();
            ClearSearchParameterTextBoxes();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            ReloadListBox();
 
        }

        private void ReloadListBox()
        {
            listBoxXmlFiles.Items.Clear();
            
            List<string> xmlNames = _xmlManager.GetXmlsAfterSearch(textBoxSearchName.Text, searchingParameters,
                    radioButtonSearchNone.Checked, radioButtonSearchAfter.Checked, radioButtonSearchBefore.Checked, radioButtonSearchBetween.Checked,
                    dateTimePickerSearchFrom.Value, dateTimePickerSearchTo.Value);

            listBoxXmlFiles.Items.AddRange(xmlNames.ToArray());
        }

        private void radioButtonSearchAfter_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerSearchFrom.Visible = true;
            dateTimePickerSearchTo.Visible = false;
            dateTimePickerSearchFrom.Location = new System.Drawing.Point(184, 43);
        }

        private void radioButtonSearchBefore_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonSearchAfter_CheckedChanged(sender, e);
        }

        private void radioButtonSearchBetween_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerSearchFrom.Visible = true;
            dateTimePickerSearchTo.Visible = true;
            dateTimePickerSearchFrom.Location = new System.Drawing.Point(184, 22);
            dateTimePickerSearchTo.Location = new System.Drawing.Point(184, 63);
            dateTimePickerSearchTo.MinDate = dateTimePickerSearchFrom.Value;
        }

        private void radioButtonSearchNone_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerSearchFrom.Visible = false;
            dateTimePickerSearchTo.Visible = false;
        }

        private void dateTimePickerSearchFrom_ValueChanged(object sender, EventArgs e)
        {
            if (radioButtonSearchBetween.Checked)
            {
                dateTimePickerSearchTo.MinDate = dateTimePickerSearchFrom.Value;
            }
        }

        private void ClearSearchParameterTextBoxes()
        {
            comboBoxSearchParameterGroup.Text = "";
            comboBoxSearchParameterName.Text = "";
            textBoxSearchParameterValue1.Text = "";
            textBoxSearchParameterValue2.Text = "";
        }

        private void buttonSearchAddParameter_Click(object sender, EventArgs e)
        {
            ParameterSearchValue param = new ParameterSearchValue();
            param.group = comboBoxSearchParameterGroup.Text;
            param.parameterName = comboBoxSearchParameterName.Text;
            param.range = radioButtonSearchParameterRange.Checked;

            string selectedType = (string)labelSearchParameterType.Text;
            if ((string)selectedType == ParameterSearchValue.STRING_TYPE_INT)
            {
                param.valueType = ParameterSearchValue.TYPE_INT;
                try
                {
                    param.value1_int = Convert.ToInt32(textBoxSearchParameterValue1.Text);
                    if (radioButtonSearchParameterRange.Checked)
                    {
                        param.value2_int = Convert.ToInt32(textBoxSearchParameterValue2.Text);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("One or both values are not integers", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            else if ((string)selectedType == ParameterSearchValue.STRING_TYPE_DOUBLE)
            {
                param.valueType = ParameterSearchValue.TYPE_DOUBLE;
                try
                {
                    param.value1_double = Convert.ToDouble(textBoxSearchParameterValue1.Text);
                    if (radioButtonSearchParameterRange.Checked)
                    {
                        param.value2_double = Convert.ToDouble(textBoxSearchParameterValue2.Text);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("One or both values are not floating point numbers", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            else if ((string)selectedType == ParameterSearchValue.STRING_TYPE_BOOL)
            {
                param.valueType = ParameterSearchValue.TYPE_BOOL;
                try
                {
                    param.value_bool = Convert.ToBoolean(textBoxSearchParameterValue1.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Value is not of boolean type", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            else if ((string)selectedType == ParameterSearchValue.STRING_TYPE_TEXT)
            {
                param.valueType = ParameterSearchValue.TYPE_TEXT;
                param.value_string = textBoxSearchParameterValue1.Text;
            }

            ClearSearchParameterTextBoxes();

            this.parameterViewList.AddParameterView(param);
            searchingParameters.AddParameter(param);
        }

        private void buttonSearchDeleteParameter_Click(object sender, EventArgs e)
        {
            if (parameterViewList.SelectedItem == null)
            {
                return;
            }
            searchingParameters.RemoveParameter(parameterViewList.SelectedItem.Parameter);
            parameterViewList.RemoveSelectedParameterView();
        }

        private void comboBoxSearchParameterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileName;
            

            if (listBoxXmlFiles.Items.Count == 0)
            {
                return;
            }
            if (listBoxXmlFiles.SelectedItem == null)
            {
                fileName = _xmlManager.GetFirstXmlName();
            }
            else
            {
                fileName = (string)(listBoxXmlFiles.SelectedItem);
            }

            string text = _xmlManager.GetTypeOfParameter(fileName, comboBoxSearchParameterGroup.Text, comboBoxSearchParameterName.Text);
            if (text != null)
            {
                labelSearchParameterType.Text = text;
            }

            radioButtonSearchParameterValue.Checked = true;
            if (labelSearchParameterType.Text == ParameterSearchValue.STRING_TYPE_INT || labelSearchParameterType.Text == ParameterSearchValue.STRING_TYPE_DOUBLE)
            {
                radioButtonSearchParameterRange.Visible = true;
            }
            else 
            {
                radioButtonSearchParameterRange.Visible = false;
            }
        }

        private void radioButtonSearchParameterValue_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSearchParameterValue.Checked)
            {
                textBoxSearchParameterValue2.Visible = false;
                textBoxSearchParameterValue1.Size = new System.Drawing.Size(118, 20);
                label1.Visible = false;
                label9.Visible = false;
            }
        }

        private void radioButtonSearchParameterRange_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSearchParameterRange.Checked)
            {
                textBoxSearchParameterValue2.Visible = true;
                textBoxSearchParameterValue1.Size = new System.Drawing.Size(57, 20);
                label1.Visible = true;
                label9.Visible = true;
            }
        }

        private void buttonAddSearchingTags_Click(object sender, EventArgs e)
        {
            if (comboBoxSearchingTags.SelectedItem == null || listBoxSearchingTags.Items.Contains(comboBoxSearchingTags.SelectedItem))
            {
                return;
            }

            foreach (Tag item in tagPanel1.tagList.Values)
            {
                if (item.Name == (string)(comboBoxSearchingTags.SelectedItem))
                {
                    searchingParameters.SearchingTagsIDs.Add(item.Id);
                    break;
                }
            }
            listBoxSearchingTags.Items.Add(comboBoxSearchingTags.SelectedItem);
        }

        private void buttonDeleteSearchingTag_Click(object sender, EventArgs e)
        {
            if (listBoxSearchingTags.SelectedItem == null)
            {
                return;
            }

            foreach (Tag item in tagPanel1.tagList.Values)
            {
                if (item.Name == (string)(listBoxSearchingTags.SelectedItem))
                {
                    searchingParameters.SearchingTagsIDs.Remove(item.Id);
                    break;
                }
            }
            listBoxSearchingTags.Items.Remove(listBoxSearchingTags.SelectedItem);
        }

        private void comboBoxSearchParameterGroup_Click(object sender, EventArgs e)
        {
            comboBoxSearchParameterGroup.Items.Clear();
            

            string fileName;
            if( listBoxXmlFiles.Items.Count == 0 )
            {
                return;
            }
            if (listBoxXmlFiles.SelectedItem == null)
            {
                fileName = _xmlManager.GetFirstXmlName();
            }
            else
            {
                fileName = (string)( listBoxXmlFiles.SelectedItem );
            }


            comboBoxSearchParameterGroup.Items.AddRange(_xmlManager.GetXmlTagNames(fileName, "GROUP").ToArray());
        }

        private void comboBoxSearchParameterName_Click(object sender, EventArgs e)
        {
            comboBoxSearchParameterName.Items.Clear();
            

            string fileName;
            if (listBoxXmlFiles.Items.Count == 0)
            {
                return;
            }
            if (listBoxXmlFiles.SelectedItem == null)
            {
                fileName = _xmlManager.GetFirstXmlName();
            }
            else
            {
                fileName = (string)(listBoxXmlFiles.SelectedItem);
            }

            if (string.IsNullOrEmpty(comboBoxSearchParameterGroup.Text))
            {
                return;
            }
            List <string> paramNames = _xmlManager.GetParamNamesForGroupName(fileName, comboBoxSearchParameterGroup.Text);
            if (paramNames != null)
            {
                comboBoxSearchParameterName.Items.AddRange(paramNames.ToArray());
            }
        }

        #region Private fields

        private XmlManager _xmlManager = XmlManager.Instance;
        private SearchingParameters searchingParameters;
        private FileGeneratorUserControl fileGeneratorControl;
        private CompareUserControl compareUserControl;
        private AutomaticTestsUserControl autoTestCtrl;

        #endregion

        private void buttonReloadFileList_Click(object sender, EventArgs e)
        {
            ReloadListBox();
        }
    }
}
