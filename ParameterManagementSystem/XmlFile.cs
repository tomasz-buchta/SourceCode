using System;
using System.Linq;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace ParameterManagementSystem
{
    public class XmlFile
    {
        #region Properties
        // Change: 28-10-2012 Properties instead of public fields
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Content { get; set; }
        #endregion
        #region .Ctr

        public XmlFile() { }

        public XmlFile(XmlFile[] filesArray, string name, string content, DateTime timeStamp)
        {
            this.GenerateID(filesArray);
            this.Name = name;
            this.Content = content;
            this.TimeStamp = timeStamp;
        }

        #endregion

        #region Public methods

        public void GenerateID(XmlFile[] filesArray)
        {
            if (filesArray.Count<XmlFile>() == 0)
            {
                Id = 0;
                return;
            }
            int max_id = filesArray[0].Id;
            foreach (XmlFile file in filesArray)
            {
                if (max_id < file.Id)
                {
                    max_id = file.Id;
                }
            }
            Id = max_id + 1;
        }

        public bool CompareToParameterSearchValue(ParameterSearchValue param)
        {
            XmlDocument doc = new XmlDocument();
            doc.InnerXml = Content;
            XmlNodeList xmlList = doc.DocumentElement.GetElementsByTagName("GROUP");

            foreach (XmlNode node in xmlList)
            {
                string groupName = ((XmlElement)node).GetAttribute("NAME");

                if (groupName == null || !groupName.Contains(param.group))
                {
                    continue;
                }

                XmlNodeList paramList = ((XmlElement)node).GetElementsByTagName("PARAM");
                foreach (XmlNode parameter in paramList)
                {
                    string parameterName = ((XmlElement)parameter).GetAttribute("NAME");

                    if (parameterName == null || !parameterName.Contains(param.parameterName))
                    {
                        continue;
                    }

                    string value = ((XmlElement)parameter).GetAttribute("VALUE");

                    if (value == null)
                    {
                        continue;
                    }

                    switch (param.valueType)
                    {
                        case (ParameterSearchValue.TYPE_INT):
                            int value_int;
                            try
                            {
                                value_int = Convert.ToInt32(value);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            if (param.range)
                            {
                                if (value_int > param.value1_int && value_int < param.value2_int)
                                {
                                    return true;
                                }
                            }
                            else if (value_int == param.value1_int)
                            {
                                return true;
                            }
                            break;
                        case (ParameterSearchValue.TYPE_DOUBLE):
                            double value_double;
                            try
                            {
                                value_double = Convert.ToDouble(value.Replace(".", ","));
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            if (param.range)
                            {
                                if (value_double > param.value1_double && value_double < param.value2_double)
                                {
                                    return true;
                                }
                            }
                            else if (value_double == param.value1_double)
                            {
                                return true;
                            }
                            break;
                        case (ParameterSearchValue.TYPE_BOOL):
                            bool value_bool;
                            try
                            {
                                value_bool = Convert.ToBoolean(value);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            if (value_bool == param.value_bool)
                            {
                                return true;
                            }
                            break;
                        case (ParameterSearchValue.TYPE_TEXT):
                            if (value == param.value_string)
                            {
                                return true;
                            }
                            break;
                    }
                }
            }
            return false;
        }

        public bool SaveToFile(string file)
        {
            StreamWriter writer = new StreamWriter(file);
            writer.Write(Content);
            writer.Close();
            return true;
        }

        public bool CreateFileTree(TreeView FileTreeView)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.InnerXml = Content;
                XmlNodeList nodesList = doc.ChildNodes;

                _groupCounter = 0;

                if (nodesList.Count > 0)
                {
                    TreeNode treeRoot = new TreeNode(nodesList.Item(0).Name);
                    treeRoot.Tag = -1;
                    FileTreeView.Nodes.Add(treeRoot);
                    FillTreeViewForChildNodes(treeRoot, nodesList.Item(0), _groupCounter);
                    return true;
                }
                else
                {
                    // file empty or not valid
                    return false;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Selected file has been changed during program runtime, please reload it","Error");
                return false;
            }
        }

        public XmlNode GetParam(int groupId, int paramId)
        {
            XmlNode searched_group;
            XmlNode searched_param;

            XmlDocument doc = new XmlDocument();
            doc.InnerXml = Content;
            XmlNodeList xmlList = doc.DocumentElement.GetElementsByTagName("GROUP");
            searched_group = xmlList[groupId];

            XmlNodeList paramList = ((XmlElement)searched_group).GetElementsByTagName("PARAM");
            searched_param = paramList[paramId];

            return searched_param;
        }

        public XmlNode GetGroup(int groupId)
        {
            XmlNode searched_group;

            XmlDocument doc = new XmlDocument();
            doc.InnerXml = Content;
            XmlNodeList xmlList = doc.DocumentElement.GetElementsByTagName("GROUP");
            searched_group = xmlList[groupId];

            return searched_group;
        }

        public bool SetParam(int groupId, int paramId, string newValue)
        {
            XmlNode searched_group;
            XmlNode searched_param;

            XmlDocument doc = new XmlDocument();
            doc.InnerXml = Content;
            XmlNodeList xmlList = doc.DocumentElement.GetElementsByTagName("GROUP");
            searched_group = xmlList[groupId];

            XmlNodeList paramList = ((XmlElement)searched_group).GetElementsByTagName("PARAM");
            searched_param = paramList[paramId];

            ((XmlElement)searched_param).SetAttribute("VALUE", newValue);
            Content = doc.InnerXml;

            return true;
        }

        #endregion

        #region Private methods

        private int FillTreeViewForChildNodes(TreeNode parentTreeNode, XmlNode node, int groupNumber)
        {
            TreeNode treeNode;
            XmlNodeList nodesList = node.ChildNodes;

            int paramCounter = 0;
            foreach (XmlNode n in nodesList)
            {
                treeNode = new TreeNode();

                if (n.Name == global::ParameterManagementSystem.Properties.Resources.NAME_GROUP)
                {
                    treeNode.Text = n.Name + " NAME = "
                        + ((XmlElement)n).GetAttribute(global::ParameterManagementSystem.Properties.Resources.ATTRIBUTE_NAME);
                    treeNode.Tag = _groupCounter;
                    paramCounter += FillTreeViewForChildNodes(treeNode, n, _groupCounter++);
                }
                else
                    if (n.Name == global::ParameterManagementSystem.Properties.Resources.NAME_PARAMETER)
                    {
                        treeNode.Text = n.Name + " NAME = "
                        + ((XmlElement)n).GetAttribute(global::ParameterManagementSystem.Properties.Resources.ATTRIBUTE_NAME);
                        treeNode.Tag = new int[] { groupNumber, paramCounter };
                        paramCounter++;
                    }
                    else
                    {
                        treeNode.Text = n.Name;
                    }
                parentTreeNode.Nodes.Add(treeNode);
            }
            return paramCounter;
        }

        #endregion

        #region Private fields

        private int _groupCounter;

        #endregion
    }
}
