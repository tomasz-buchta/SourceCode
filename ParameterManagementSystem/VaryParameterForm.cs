using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ParameterManagementSystem
{
    public partial class VaryParameterForm : Form
    {
        public VaryParameterForm(ElementInfo parameter, int new_group_id, int new_param_id,
            bool is_varied, ref Dictionary<string, VariedParameter> variations_dict)
        {
            InitializeComponent();
            
            param_name = parameter.Name;
            param_hint = parameter.Hint;
            value_type = parameter.Type;

            if ((value_type == "Bool") || (value_type == "Text"))
            {
                this.RangeRadioButton.Enabled = false;
            }

            this.AttributeNameLabel.Text = param_name;
            this.AttribueHintLabel.Text = param_hint;

            varied_parameters = variations_dict;

            varied = is_varied;

            gid = new_group_id;
            pid = new_param_id;

            element_key = gid.ToString() + "_" + pid.ToString();

            if (varied_parameters.ContainsKey(element_key))
            {
                current_variation = varied_parameters[element_key];
            }
            else
            {
                current_variation = new VariedParameter(gid, pid, value_type);
            }

            if (varied_parameters.ContainsKey(element_key))
            {
                switch (current_variation.variation_type)
                {
                    case "single":
                        this.SingleRadioButton.Checked = true;
                        this.SingleTextBox.Text = current_variation.single;
                    break;

                    case "range":
                        this.RangeRadioButton.Checked = true;
                        this.RangeMinTextBox.Text = current_variation.range_min;
                        this.RangeMaxTextBox.Text = current_variation.range_max;
                        this.RangeStepTextBox.Text = current_variation.range_step;
                    break;

                    case "list":
                        this.ListRadioButton.Checked = true;
                        foreach (string item in current_variation.values)
                        {
                            this.ListListBox.Items.Add(item);
                        }
                        
                    break;
                }
            }
            else
            {
                original_value = parameter.Value;
                this.SingleRadioButton.Checked = true;
                this.SingleTextBox.Text = original_value.ToString();
            }
            
        }

        private Dictionary<string, VariedParameter> varied_parameters;
        private VariedParameter current_variation;
        private string param_name;
        private string param_hint;
        private string value_type;
        private object original_value;
        private int gid;
        private int pid;
        private string element_key;
        private bool varied;

        private void disableSingle()
        {
            this.SingleTextBox.Enabled = false;
        }

        private void enableSingle()
        {
            this.SingleTextBox.Enabled = true;
        }

        private void disableRange()
        {
            this.RangeMinTextBox.Enabled = false;
            this.RangeMaxTextBox.Enabled = false;
            this.RangeStepTextBox.Enabled = false;
        }

        private void enableRange()
        {
            this.RangeMinTextBox.Enabled = true;
            this.RangeMaxTextBox.Enabled = true;
            this.RangeStepTextBox.Enabled = true;
        }

        private void disableList()
        {
            this.ListAddTextBox.Enabled = false;
            this.ListListBox.Enabled = false;
            this.ListAddButton.Enabled = false;
            this.ListRemoveButton.Enabled = false;
        }

        private void enableList()
        {
            this.ListAddTextBox.Enabled = true;
            this.ListListBox.Enabled = true;
            this.ListAddButton.Enabled = true;
        }

        private bool validate_variation()
        {
            if ((!varied) && (SingleRadioButton.Checked) &&
                (SingleTextBox.Text == original_value.ToString()))
            {
                return true;
            }

            if (SingleRadioButton.Checked)
            {
                try
                {
                    current_variation.SetSingle(this.SingleTextBox.Text);
                }
                catch
                {
                    MessageBox.Show("One of the added values is not a valid one for current parameter",
                    "Invalid parameters",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
            }
            if (RangeRadioButton.Checked)
            {
                try
                {
                    current_variation.SetRange(this.RangeMinTextBox.Text, this.RangeMaxTextBox.Text,
                        this.RangeStepTextBox.Text);
                }
                catch
                {
                    MessageBox.Show("One of the added values is not a valid one for current parameter",
                    "Invalid parameters",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
            }
            if (ListRadioButton.Checked)
            {
                try
                {
                    current_variation.SetList();
                    foreach (object item in this.ListListBox.Items)
                    {
                        current_variation.AddParameterValue(item.ToString());
                    }
                }
                catch
                {
                    MessageBox.Show("One of the added values is not a valid one for current parameter",
                    "Invalid parameters",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
            }
            if (!varied_parameters.ContainsKey(element_key))
            {
                varied_parameters.Add(element_key, current_variation);
            }
            else
            {
                varied_parameters[element_key] = current_variation;
            }

            return true;
        }

        private void SingleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            disableRange();
            disableList();
            enableSingle();
        }

        private void RangeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            disableSingle();
            disableList();
            enableRange();
        }

        private void ListRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            disableSingle();
            disableRange();
            enableList();
        }

        private void ListListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ListRemoveButton.Enabled = true;
        }

        private void ListAddButton_Click(object sender, EventArgs e)
        {
            this.ListListBox.Items.Add(this.ListAddTextBox.Text.ToString());
        }

        private void ListRemoveButton_Click(object sender, EventArgs e)
        {
            this.ListListBox.Items.Remove(this.ListListBox.SelectedItem);
            if (this.ListListBox.SelectedItems.Count == 0)
            {
                this.ListRemoveButton.Enabled = false;
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (validate_variation())
            {
                this.Close();
            }
        }

        private void CancelButton__Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
