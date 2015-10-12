using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ParameterManagementSystem.Xml;

namespace ParameterManagementSystem
{
    public enum DisplayMethod : byte { RANGE, OCCURENCES, FULLLIST };

    public partial class CompareUserControl : UserControl
    {
         
        private ListBox listBoxXmlFilesReference;

        private CompareViewRecord selectedItem;
        public CompareViewRecord SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (SelectedItem != null)
                {
                    SelectedItem.Unselect();
                }
                selectedItem = value;
                if (SelectedItem != null)
                {
                    SelectedItem.Select();
                }
            }
        }

        public CompareUserControl(Dictionary<string, XmlFile> xmlFilesList, ListBox listBoxXmlFiles)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Here all the comparison takes place
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void compareButton_Click(object sender, EventArgs e)
        {
            XMLLogic xmlLogic;   
            xmlLogic = new XMLLogic();
            ///this is a dictionary holding entries with values of all parameters with associated filename and value(if any)
            Dictionary<ParameterID, Dictionary<String, object>> parameterValuesDictionary = new Dictionary<ParameterID, Dictionary<String, object>>();

             var form = Form.ActiveForm as Form1;		
	            if (form != null)		
	            {		
	                listBoxXmlFilesReference = form.ListBoxXmlFiles;
                    xmlLogic.XmlFilesListReference = XmlManager.Instance.XmlFilesList;
	            }
            #region loading of all/selected XMLs to the XPathDocList
            
            Dictionary<string, XmlFile> xmlFilesListReference = xmlLogic.XmlFilesListReference;
            if (listBoxXmlFilesReference.SelectedIndices.Count < 2)// all elements
            {
                foreach (string fileName in xmlFilesListReference.Keys)
                {
                    if (listBoxXmlFilesReference.Items.Contains(fileName))
                    {
                        xmlLogic.LoadXMLs(fileName);
                    }
                }
            }
            else//selected elements
            {
                foreach (string fileName in listBoxXmlFilesReference.SelectedItems)
                {
                    if (listBoxXmlFilesReference.Items.Contains(fileName))
                    {
                        xmlLogic.LoadXMLs(fileName);
                    }
                }
            }
            #endregion
            
            String parameterName = this.parameterNameTextBox.Text;
            
            parameterValuesDictionary = xmlLogic.GetAllByName(parameterName);

            #region Do the house-keeping

            this.contentsPanel.Controls.Clear();

            if (checkBoxShowOnlyDifferences.Checked)
            {
                for (int i = parameterValuesDictionary.Count - 1; i >= 0; i--)
                {
                    if (parameterValuesDictionary.ElementAt(i).Value.Values.Distinct().Count() == 1)
                    {
                        parameterValuesDictionary.Remove(parameterValuesDictionary.ElementAt(i).Key);
                    }
                }
            }
            // I'm confused how shuld it work

            /*if (checkBoxShowOnlyDifferences.Checked)
            {
                for (int i = parameterValuesDictionary.Count - 1; i >= 0; i--)
                {
                    for (int j = 0; j < parameterValuesDictionary.ElementAt(i).Value.Count ; j++)
                    {
                        for (int k = j + 1; k < parameterValuesDictionary.ElementAt(i).Value.Count; k++)
                        {
                            if (parameterValuesDictionary.ElementAt(i).Value.ElementAt(j).Value.Equals(parameterValuesDictionary.ElementAt(i).Value.ElementAt(k).Value))
                            {
                                parameterValuesDictionary.ElementAt(i).Value.Remove(parameterValuesDictionary.ElementAt(i).Value.ElementAt(k).Key);
                            }
                        }
                    }
                }
            }*/

            #endregion

            //Add new records according to display type
            if (this.radioButtonShowRange.Checked)
            {
                updateControlWithParametersDictionary(parameterValuesDictionary, DisplayMethod.RANGE);
            }
            else if (this.radioButtonShowOccurences.Checked)
            {
                updateControlWithParametersDictionary(parameterValuesDictionary, DisplayMethod.OCCURENCES);
            }
            else if (this.radioButtonShowAll.Checked)
            {
                updateControlWithParametersDictionary(parameterValuesDictionary, DisplayMethod.FULLLIST);
            }
            else
            {
                updateControlWithParametersDictionary(parameterValuesDictionary, DisplayMethod.RANGE);
            } 

        }

        /// <summary>
        /// Helpful function to list all the parameters to the <paramref name="fileName"/>
        /// </summary>
        /// <param name="fileName">Name of a file to which we save the parameters</param>
        /// <param name="parameterValuesDictionary">Dictionary with paramters</param>
       
        private bool updateControlWithParametersDictionary(Dictionary<ParameterID, Dictionary<String, object>> parameterValuesDictionary, DisplayMethod howToDisplay)
        {
            foreach (KeyValuePair<ParameterID, Dictionary<String, object>> entry in parameterValuesDictionary)
            {
                this.contentsPanel.Controls.Add(new CompareViewRecord(entry, this, howToDisplay));
            }
            return true;
        }
    }


    public class ParameterID : IEquatable<ParameterID>
    {
        #region Properties
        public String Group
        {
            get { return parameterGroup; }
            set { parameterGroup = value; }
        }
        public String Name
        {
            get { return parameterName; }
            set { parameterName = value; }
        }
        public bool IsAString
        {
            get { return parameterIsString; }
            set { parameterIsString = value; }
        } 
        #endregion

        #region Constructors
        /// <summary>
        /// constructor that creates a parameterID with set parameterName and parameterGroup
        /// </summary>
        /// <param name="parameterName">Name of the parameter from the xml file.</param>
        /// <param name="parameterGroup">Group name in which the paramters resides.</param>
        public ParameterID(String parameterName, String parameterGroup, bool isAString)
        {
            this.parameterName = parameterName;
            this.parameterGroup = parameterGroup;
            this.IsAString = isAString;
        }
        #endregion

        #region Public methods
        //these 3 methods allow to use TryGetValue and Contain methods on this class
        public bool Equals(ParameterID other)
        {
            return other != null && parameterName == other.parameterName && parameterGroup == other.parameterGroup;
        }
        public override bool Equals(object other)
        {
            return Equals(other as ParameterID);// base.Equals(other);
        }
        public override int GetHashCode()
        {
            int fHash = parameterName.GetHashCode();
            return ((fHash << 16) | (fHash >> 16)) ^ parameterGroup.GetHashCode();
            //return base.GetHashCode();
        } 
        #endregion

        #region Private fields
        private String parameterName;
        private String parameterGroup;
        private bool parameterIsString;//when at least one of its values is String 
        #endregion
    }
}
