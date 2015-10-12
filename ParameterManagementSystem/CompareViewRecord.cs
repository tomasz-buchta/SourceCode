using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParameterManagementSystem
{
    public enum DisplayType : byte { Range, RangeAndOccurences, FullList };

    public partial class CompareViewRecord : UserControl
    {
        private KeyValuePair<ParameterID, Dictionary<String, object>> parameterValues;
        private CompareUserControl owner;

        public CompareViewRecord()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(this.Size.Width, 15);
            this.Dock = DockStyle.Top;
            this.BackColor = System.Drawing.Color.White;
        }
        public CompareViewRecord(KeyValuePair<ParameterID, Dictionary<String, object>> p_parameterValues, CompareUserControl p_owner, DisplayMethod howToDisplay)
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(this.Size.Width, 18);
            this.Dock = DockStyle.Top;
            this.BackColor = System.Drawing.Color.White;
            this.parameterValues = p_parameterValues;

            this.Set(howToDisplay);
            this.owner = p_owner;
        }
        public new void Select()
        {
            this.BackColor = System.Drawing.Color.LightBlue;
        }
        public void Unselect()
        {
            this.BackColor = System.Drawing.Color.White;
        }
        public void Set(DisplayMethod displayType)
        {
            this.labelParameterName.Text = this.parameterValues.Key.Group + "." + this.parameterValues.Key.Name; // possible to change to add group name inside
            switch (displayType)
            {
                case DisplayMethod.RANGE:
                    if (this.parameterValues.Key.IsAString)
                    {
                        // printing only distinct values of parameter
                        foreach (string entry in this.parameterValues.Value.Values.Distinct())
                        {
                            this.labelParameterValues.Text += "\"" + entry + "\";  ";
                        }
                    }
                    else
                    {
                        this.labelParameterValues.Text = "Min: " + this.parameterValues.Value.Values.Min() + ", Max: " + this.parameterValues.Value.Values.Max();
                    }
                    break;
                case DisplayMethod.OCCURENCES:
                    var counts = from entry in this.parameterValues.Value
                                 group entry by entry.Value into distinctValue
                                 select new { ParameterValue = distinctValue.Key, Occurences = distinctValue.Count() };
                    foreach (var entry in counts)
                    {
                        if (this.parameterValues.Key.IsAString)
                        {
                            this.labelParameterValues.Text += System.String.Format("{0} occurrences of \"{1}\"; ", entry.Occurences, entry.ParameterValue);
                        }
                        else
                        {
                            this.labelParameterValues.Text += System.String.Format("{0} occurrences of {1}; ", entry.Occurences, entry.ParameterValue);
                        }
                    }
                    break;
                case DisplayMethod.FULLLIST:
                     foreach (double entry in this.parameterValues.Value.Values)
                        {
                            this.labelParameterValues.Text += System.String.Format("{0}; ", entry);   
                        }              
                 break;
                default:
                    break;
            }
        }

        private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            owner.SelectedItem = this;
        }

        private void tableLayoutPanel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form newForm = new Form();
            newForm.Text = parameterValues.Key.Group + "." + parameterValues.Key.Name;
            newForm.Size = new System.Drawing.Size( 450, 550 );
            newForm.FormBorderStyle = FormBorderStyle.Fixed3D;
            //newForm.MinimumSize = new System.Drawing.Size(450, 550);
            //newForm.MaximumSize = new System.Drawing.Size(450, 550);
            newForm.Show();

            TableLayoutPanel tableLayoutPanelNew = new TableLayoutPanel();
            tableLayoutPanelNew.Size = new System.Drawing.Size(newForm.Width - 10, newForm.Height - 30);

            tableLayoutPanelNew.AutoScroll = true;

            newForm.Controls.Add(tableLayoutPanelNew);
            if (this.parameterValues.Key.IsAString)
	        {
		        foreach (var filenameValuePair in parameterValues.Value)
                {
                    tableLayoutPanelNew.Controls.Add(new CompareViewFileValue(filenameValuePair.Key, filenameValuePair.Value.ToString()));
                }
	        }
                else
	        {
		        foreach (var filenameValuePair in parameterValues.Value)
                {
                    tableLayoutPanelNew.Controls.Add(new CompareViewFileValue(filenameValuePair.Key, (double)filenameValuePair.Value));
                }
	        }
        }
    }
}
