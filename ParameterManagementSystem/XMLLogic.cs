using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.XPath;
using System.Globalization;
using System.Text;

namespace ParameterManagementSystem
{
    class XMLLogic
    {
        private Dictionary<string, XPathDocument> XMLsToWorkWith;

        private Dictionary<string, XmlFile> xmlFilesListReference;

        public XMLLogic()
        {
           XMLsToWorkWith = new Dictionary<string, XPathDocument>();
         
        }

        /// <summary>
        /// Function analyzes children of the node recursively
        /// </summary>
        /// <param name="nodeNavigator">current node whose children schould be analyzed</param>
        /// <param name="groupName">currently created sequence of group names to this node</param>
        /// <param name="parameterName">name of the compared parameter</param>
        /// <param name="dictionaryEntry">entry for currently analyzed xml doc</param>
        /// <param name="temp">temporary entry for the parameter to be filled</param>
        public void AnalyzeNodeChildren(XPathNavigator nodeNavigator, string groupName, string parameterName, KeyValuePair<string, XPathDocument> dictionaryEntry, Dictionary<ParameterID, Dictionary<String, object>> temp)
        {
            nodeNavigator.MoveToFirstChild();

            do
            {
                //----comparing param's attributes-----------------

                if (nodeNavigator.HasChildren)
                {
                    // This is a group
                    StringBuilder groupNameNewSB = new StringBuilder();
                    nodeNavigator.MoveToAttribute("NAME", "");

                    groupNameNewSB.Append(groupName);
                    if (groupName != "")
                    {
                        groupNameNewSB.Append(".");
                    }

                    groupNameNewSB.Append(nodeNavigator.Value);

                    nodeNavigator.MoveToParent();
                    AnalyzeNodeChildren(nodeNavigator, groupNameNewSB.ToString(), parameterName, dictionaryEntry, temp);
                }
                else
                {
                    nodeNavigator.MoveToFirstAttribute();

                    do
                    {
                        switch (nodeNavigator.Name)
                        {
                            case "NAME":
                                break;
                            case "HINT":
                                break;
                            case "TYPE":
                                break;
                            case "VALUE": // this can be done better....... but anyways , let's continue :)
                                //paramValue = Convert.ToDouble(thisNavigator.ValueAsDouble);
                                object paramValue = null;
                                double doubleValue;
                                bool paramIsString = false;
                                if (!Double.TryParse(nodeNavigator.Value, NumberStyles.Number, CultureInfo.InvariantCulture/*CultureInfo.CreateSpecificCulture("en-GB")*/, out doubleValue))
                                {
                                    paramValue = nodeNavigator.Value;
                                    paramIsString = true;
                                }

                                //------- move to attribute doesn't work backwards (no idea why)
                                // update: because it cannot go from attribute to attribute with the use of 
                                //MoveToAttribute method (in this case only MoveToNextAttribute can be used)
                                nodeNavigator.MoveToParent();
                                nodeNavigator.MoveToFirstChild();
                                nodeNavigator.MoveToAttribute("NAME", "");

                                //if no match with desired name 'break;' and go to the next one
                                if (!nodeNavigator.Value.Contains(parameterName))
                                {
                                    nodeNavigator.MoveToParent();
                                    nodeNavigator.MoveToFirstChild();
                                    nodeNavigator.MoveToAttribute("VALUE", "");
                                    break;
                                }

                                #region Adding parameter to temp
                                //....add( (fileName, Concatenated String <groupName + , +  parameterName>), parameterValue)
                                if (paramIsString)
                                {
                                    // For this I could have written a function :)
                                    Dictionary<string, object> tempDictionary = new Dictionary<string, object>();

                                    ///if this parameter entry already exists, then only add it's difference entry in its dictionary
                                    if (temp.TryGetValue(new ParameterID(nodeNavigator.Value, groupName, true), out tempDictionary))
                                    //if (temp.ContainsKey(new parameterID(thisNavigator.Value, groupName)))
                                    {
                                        tempDictionary.Add(dictionaryEntry.Key, paramValue);
                                    }
                                    else
                                    {
                                        tempDictionary = new Dictionary<string, object>();
                                        tempDictionary.Add(dictionaryEntry.Key, paramValue);
                                        temp.Add(new ParameterID(nodeNavigator.Value, groupName, true), tempDictionary);
                                        //(DictionaryEntry.Key, groupName + ", " + thisNavigator.Value), paramValue);
                                    }
                                }
                                else
                                {
                                    Dictionary<string, object> tempDictionary = new Dictionary<string, object>();

                                    ///if this parameter entry already exists, then only add it's difference entry in its dictionary
                                    if (temp.TryGetValue(new ParameterID(nodeNavigator.Value, groupName, false), out tempDictionary))
                                    //if (temp.ContainsKey(new parameterID(thisNavigator.Value, groupName)))
                                    {
                                        tempDictionary.Add(dictionaryEntry.Key, doubleValue);
                                    }
                                    else
                                    {
                                        tempDictionary = new Dictionary<string, object>();
                                        tempDictionary.Add(dictionaryEntry.Key, doubleValue);
                                        temp.Add(new ParameterID(nodeNavigator.Value, groupName, false), tempDictionary);
                                        //(DictionaryEntry.Key, groupName + ", " + thisNavigator.Value), paramValue);
                                    }
                                }
                                #endregion

                                //again - doesn't work backwards
                                nodeNavigator.MoveToParent();
                                nodeNavigator.MoveToFirstChild();
                                nodeNavigator.MoveToAttribute("VALUE", "");

                                break;
                            case "LEVEL":
                                break;
                            default:
                                break;
                        }


                    } while (nodeNavigator.MoveToNextAttribute());
                    nodeNavigator.MoveToParent();
                }
            } while (nodeNavigator.MoveToNext());//iteration on params

            nodeNavigator.MoveToParent();
        }
        
        public Dictionary<ParameterID, Dictionary<String, object>> GetAllByName(String parameterName)
        {
            Dictionary<ParameterID, Dictionary<String, object>> temp = new Dictionary<ParameterID, Dictionary<String, object>>();

              foreach (KeyValuePair<string, XPathDocument> DictionaryEntry in XMLsToWorkWith)
            {
                XPathNavigator thisNavigator = DictionaryEntry.Value.CreateNavigator();

                thisNavigator.MoveToRoot();
                thisNavigator.MoveToFirstChild();
                                
                AnalyzeNodeChildren(thisNavigator, "", parameterName, DictionaryEntry, temp);
            }

            return temp;
        }

        public Dictionary<string, XmlFile> XmlFilesListReference{
            set
            {
                xmlFilesListReference = value;
            }
            get
            {
                return xmlFilesListReference;
            }
        }
        public void LoadXMLs(string fileName)
        {
            if (!XMLsToWorkWith.ContainsKey(fileName))
            {
                XmlFile l_xmlFile = new XmlFile();
                if (xmlFilesListReference.TryGetValue(fileName, out l_xmlFile))
                {
                    StringReader strReader = new StringReader(l_xmlFile.Content);
                    XMLsToWorkWith.Add(fileName, new XPathDocument(strReader));
                }
            }
        }

        private string ConstructNestedGroupString(XPathNavigator navigator)
        {
            StringBuilder sB = new StringBuilder();

            while (navigator.HasChildren) ;
            

            return sB.ToString();
        }

        private void printAllParamatersToFile(String fileName, Dictionary<ParameterID, Dictionary<String, object>> parameterValuesDictionary)
        {
            using (StreamWriter fileWriter = new StreamWriter(fileName))
            {
                foreach (KeyValuePair<ParameterID, Dictionary<string, object>> entry in parameterValuesDictionary)
                {
                    fileWriter.WriteLine(System.String.Format("\nparameter {0} from group {1} have these values: ", entry.Key.Name, entry.Key.Group));
                    Dictionary<string, object> tempDict = new Dictionary<string, object>();
                    if (parameterValuesDictionary.TryGetValue(entry.Key, out tempDict))
                    {
                        foreach (KeyValuePair<string, object> difference in tempDict)
                        {
                            fileWriter.WriteLine("\t difference in file {0} , with value {1}", difference.Key, difference.Value);
                        }
                        fileWriter.WriteLine("\n");
                    }
                }
            }
        }

    }
}
