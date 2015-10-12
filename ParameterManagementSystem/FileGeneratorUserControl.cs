using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ParameterManagementSystem.Xml;
using System.Drawing;

namespace ParameterManagementSystem
{
    public partial class FileGeneratorUserControl : UserControl
    {
        public FileGeneratorUserControl(ListBox listBoxXmlFiles)
        {
            _variedParameters = new Dictionary<string, VariedParameter>();
            InitializeComponent();
            clearLabels();
            _listBoxXmlFilesReference = listBoxXmlFiles;
            this.ModifiyInicatorCheckBox.Enabled = false;
            this.ClearCurrentButton.Enabled = false;
            this.ClearAllButton.Enabled = false;
            this.GenerateButton.Enabled = false;
        }

        private ListBox _listBoxXmlFilesReference;
        private ElementInfo _activeXmlElement;
        private int _activeGroupId;
        private int _activeParamId;
        private Dictionary<string, VariedParameter> _variedParameters;
        private XmlManager _xmlManager = XmlManager.Instance;

        public void recreateFileTree()
        {
            _variedParameters.Clear();
            clearLabels();
            this.FileTreeView.Nodes.Clear();
            string activeXMLFileName;
            activeXMLFileName = _listBoxXmlFilesReference.SelectedItem.ToString();
            _xmlManager.CreateFileTree(this.FileTreeView, activeXMLFileName);
        }

        public void clearFileTree()
        {
            this.FileTreeView.Nodes.Clear();
            clearLabels();
            _variedParameters.Clear();
        }

        private void fillLabels()
        {
            object raw_tree_tag;
            int int_tag;
            int[] int_array_tag;
            
            ElementInfo currentElement;
            string current_key;
            if (_variedParameters.Count == 0)
            {
                ClearAllButton.Enabled = false;
                GenerateButton.Enabled = false;
            }
            else
            {
                ClearAllButton.Enabled = true;
                GenerateButton.Enabled = true;
            }
            raw_tree_tag = this.FileTreeView.SelectedNode.Tag;

            if (raw_tree_tag.ToString() == "-1")
            {
                // if it is "PARAMETERS"
                clearLabels();
            }
            else if(raw_tree_tag is Array) //selected field is single parameter
            {
                this.EditButton.Enabled = true;
                int_array_tag = (int[])raw_tree_tag;
                int tagArrayLength = 2;
                currentElement = _xmlManager.GetElementInfo(int_array_tag, tagArrayLength);

                SetAttributeLabelsTexts(currentElement);

                // Getting group and parameter id from the node tag
                _activeGroupId = int_array_tag[0];
                _activeParamId = int_array_tag[1];

                _activeXmlElement = currentElement;

                current_key = _activeGroupId.ToString() + "_" + _activeParamId.ToString();
                if (_variedParameters.ContainsKey(current_key))
                {
                    this.ModifiyInicatorCheckBox.Checked = true;
                    this.VarAmountLabel.Text = _variedParameters[current_key].values.Count.ToString();
                    this.FileTreeView.SelectedNode.ForeColor = Color.Blue;
                    this.ClearCurrentButton.Enabled = true;
                    this.GenerateButton.Enabled = true;
                }
                else
                {
                    this.ModifiyInicatorCheckBox.Checked = false;
                    this.VarAmountLabel.Text = "0";
                    this.ClearCurrentButton.Enabled = false;
                    if (_variedParameters.Count == 0)
                    {
                        this.ClearAllButton.Enabled = false;
                        this.GenerateButton.Enabled = false;
                    }
                    else
                    {
                        ClearAllButton.Enabled = true;
                        GenerateButton.Enabled = true;
                    }
                }
            }
            else //selected field is group
            {
                this.EditButton.Enabled = false;
                int_tag = (int)raw_tree_tag;
                int tagArrayLength = 1;
                currentElement = _xmlManager.GetElementInfo(new int[] { int_tag }, tagArrayLength);

                SetAttributeLabelsTexts(currentElement);

                this.ModifiyInicatorCheckBox.Checked = false;
                this.ClearCurrentButton.Enabled = false;
                if (_variedParameters.Count == 0)
                {
                    this.ClearAllButton.Enabled = false;
                    this.GenerateButton.Enabled = false;
                    this.VarAmountLabel.Text = "0";
                }
                else
                {
                    this.VarAmountLabel.Text = CalculateGroupVariationsAmount(int_tag).ToString();
                    ClearAllButton.Enabled = true;
                    GenerateButton.Enabled = true;
                }
            }
        }

        private int CalculateGroupVariationsAmount(int groupId)
        {
            int amount = 1;
            bool isVaried = false;
            string current_key;

            int paramCount = this.FileTreeView.SelectedNode.GetNodeCount(false);

            for (int i = 0; i < paramCount; i++)
            {
                current_key = groupId + "_" + i.ToString();
                if (_variedParameters.ContainsKey(current_key))
                {
                    amount *= _variedParameters[current_key].values.Count;
                    isVaried = true;
                }
            }

            if (amount == 1 && !isVaried)
                amount = 0;

            return amount;

        }

        private void SetAttributeLabelsTexts(ElementInfo currentElement)
        {
            this.AttributeNameLabel.Text = currentElement.Name;
            this.AttributeHintLabel.Text = currentElement.Hint;
            this.AttributeTypeLabel.Text = currentElement.Type;
            this.AttributeValueLabel.Text = currentElement.Value;
            this.AttributeLevelLabel.Text = currentElement.Level;
        }

        private void clearLabels()
        {
            this.EditButton.Enabled = false;
            this.AttributeNameLabel.Text = "";
            this.AttributeHintLabel.Text = "";
            this.AttributeTypeLabel.Text = "";
            this.AttributeValueLabel.Text = "";
            this.AttributeLevelLabel.Text = "";
            this.ModifiyInicatorCheckBox.Checked = false;
            this.ClearCurrentButton.Enabled = false;
            this.VarAmountLabel.Text = "";
            if (_variedParameters.Count == 0)
            {
                this.ClearAllButton.Enabled = false;
                this.GenerateButton.Enabled = false;
            }
            else
            {
                ClearAllButton.Enabled = true;
                GenerateButton.Enabled = true;
            }
        }

        private void FileTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            fillLabels();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            string current_key;
            bool varied = this.ModifiyInicatorCheckBox.Checked;

            using (VaryParameterForm VaryDialog = new VaryParameterForm(_activeXmlElement, _activeGroupId,
                _activeParamId, varied, ref _variedParameters))
            {
                VaryDialog.ShowDialog();
            }
            current_key = _activeGroupId.ToString() + "_" + _activeParamId.ToString();
            if (_variedParameters.ContainsKey(current_key))
            {
                this.ModifiyInicatorCheckBox.Checked = true;
                this.VarAmountLabel.Text = _variedParameters[current_key].values.Count.ToString();
                this.FileTreeView.SelectedNode.ForeColor = Color.Blue;
                this.ClearAllButton.Enabled = true;
                this.ClearCurrentButton.Enabled = true;
                this.GenerateButton.Enabled = true;
            }
            else
            {
                this.ModifiyInicatorCheckBox.Checked = false;
                this.ClearCurrentButton.Enabled = false;
                if (_variedParameters.Count == 0)
                {
                    this.ClearAllButton.Enabled = false;
                    this.GenerateButton.Enabled = false;
                }
                else
                {
                    ClearAllButton.Enabled = true;
                    GenerateButton.Enabled = true;
                }
            }
        }


        private void ClearColoringOfTreeView(TreeNode tree)
        {
            foreach (TreeNode node in tree.Nodes)
            {
                if (node.Nodes.Count != 0)
                {
                    ClearColoringOfTreeView(node);
                }
                node.ForeColor = Color.Black;
            }
        }

        private void GenerateVariations()
        {
            if (!_xmlManager.GenerateVariations(this.NewNameTextBox.Text, _variedParameters))
            {
                MessageBox.Show("File with provided name already exists, please enter new name",
                    "Invalid name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (this.NewNameTextBox.Text != "")
            {
                GenerateVariations();
                foreach (TreeNode rootNode in this.FileTreeView.Nodes)
                {
                    ClearColoringOfTreeView(rootNode);
                }
                _variedParameters.Clear();
            }
            else
            {
                MessageBox.Show("No file name provided, variatons cannot be generated",
                "No file name",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            _variedParameters.Clear();
            this.ModifiyInicatorCheckBox.Checked = false;
            this.VarAmountLabel.Text = "0";
            this.ClearCurrentButton.Enabled = false;
            this.GenerateButton.Enabled = false;
        }

        private void ClearCurrentButton_Click(object sender, EventArgs e)
        {
            string current_key;
            current_key = _activeGroupId.ToString() + "_" + _activeParamId.ToString();
            _variedParameters.Remove(current_key);
            this.ModifiyInicatorCheckBox.Checked = false;
            this.ClearCurrentButton.Enabled = false;
            if (_variedParameters.Count == 0)
            {
                this.ClearAllButton.Enabled = false;
                this.GenerateButton.Enabled = false;
            }
            else
            {
                ClearAllButton.Enabled = true;
                GenerateButton.Enabled = true;
            }
        }
    }
}
