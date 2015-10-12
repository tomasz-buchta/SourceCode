using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace ParameterManagementSystem.Xml
{
    /// <summary>
    /// Class responsible for delivering manager of all actions connected with xml
    /// Implemented according to Singleton pattern
    /// </summary>
    public class XmlManager
    {
        #region Private fields

        private static XmlManager _instance;
        private XmlReader _reader;
        private XmlSaver _saver;
        private XmlVariator _variator;

        private List<XmlTagRelation> _relationsList;
        private Dictionary<string, XmlFile> _xmlFilesList;
        private DataBase _dataBase;
        private XmlFile _activeXmlFile;

        #endregion

        #region Properties

        public static XmlManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new XmlManager();
                }

                return _instance;
            }
        }

        public Dictionary<string, XmlFile> XmlFilesList
        {
            get
            {
                return _xmlFilesList;
            }
        }

        public DataBase DataBase
        {
            get
            {
                return _dataBase;
            }
        }

        #endregion

        #region .Ctr

        private XmlManager()
        {
            _reader = new XmlReader();
            _saver = new XmlSaver();
            _variator = new XmlVariator();
        } 

        #endregion

        #region Public methods

        public List <string> LoadXmlFilesFromFileNames(string[] fileNames)
        {
            return _reader.LoadXmlFilesFromFileNames(fileNames, _xmlFilesList);
        }

        public ElementInfo GetElementInfo(int[] int_array_tag, int n)
        {
            ElementInfo elementInfo = new ElementInfo();
            XmlNode node = null;
            if(n == 1)
            {
                node = _activeXmlFile.GetGroup(int_array_tag[0]);
            }
            else if (n == 2)
            {
                node = _activeXmlFile.GetParam(int_array_tag[0], int_array_tag[1]);
            }

            if (node != null)
            {
                elementInfo = new ElementInfo()
                {
                    Hint = _reader.GetAttributeValue(node, "HINT"),
                    Level = _reader.GetAttributeValue(node, "LEVEL"),
                    Name = _reader.GetAttributeValue(node, "NAME"),
                    Type = _reader.GetAttributeValue(node, "TYPE"),
                    Value = _reader.GetAttributeValue(node, "VALUE")
                };
            }
            
            return elementInfo;
        }

        public void InitXmlFilesList()
        {
            _xmlFilesList = new Dictionary<string, XmlFile>();
        }

        public DateTime GetTimeStampForSelectedFile(string xmlName)
        {
            XmlFile file = _xmlFilesList[xmlName];
            return file.TimeStamp;
        }

        public List<string> GetXmlsAfterSearch(string searchName, SearchingParameters searchingParameters, bool searchNone,
                                                bool searchAfter, bool searchBefore, bool searchBetween, DateTime dateFrom, DateTime dateTo)
        {
            List<string> xmlNames = new List<string>();

            foreach (XmlFile item in _xmlFilesList.Values)
            {
                if (searchName != "")
                {
                    if (item.Name == null || !item.Name.Contains(searchName))
                    {
                        continue;
                    }
                }

                if (searchingParameters.SearchingTagsIDs.Count > 0)
                {
                    bool containsAllTags = true;
                    foreach (int tagId in searchingParameters.SearchingTagsIDs)
                    {
                        bool fileContainsTag;

                        fileContainsTag = XmlManager.Instance.HasTagRelation(item.Id, tagId);

                        if (!fileContainsTag)
                        {
                            containsAllTags = false;
                            break;
                        }
                    }

                    if (!containsAllTags)
                    {
                        continue;
                    }
                }
                if (!searchNone)
                {
                    if (searchAfter && item.TimeStamp < dateFrom)
                    {
                        continue;
                    }
                    if (searchBefore && item.TimeStamp > dateFrom)
                    {
                        continue;
                    }
                    if (searchBetween)
                    {
                        if (item.TimeStamp < dateFrom || item.TimeStamp > dateTo)
                        {
                            continue;
                        }
                    }
                }
                bool fullfillAllParameters = true;
                foreach (ParameterSearchValue param in searchingParameters.Parameters)
                {
                    if (!item.CompareToParameterSearchValue(param))
                    {
                        fullfillAllParameters = false;
                        continue;
                    }
                }
                if (!fullfillAllParameters)
                {
                    continue;
                }
                xmlNames.Add(item.Name);
            }
            return xmlNames;
        }

        public string GetFirstXmlName()
        {
            return _xmlFilesList.Keys.First();
        }

        public string GetTypeOfParameter(string fileName, string searchParamGroup, string searchParamName)
        {
            string type = null;
            XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(_xmlFilesList[fileName].Content);
            XmlNodeList list = doc.GetElementsByTagName("GROUP");
            foreach (XmlNode node in list)
            {
                if (node.Attributes["NAME"] == null)
                {
                    continue;
                }

                if (node.Attributes["NAME"].Value == searchParamGroup)
                {
                    XmlNodeList paramList = ((XmlElement)node).GetElementsByTagName("PARAM");
                    foreach (XmlNode param in paramList)
                    {
                        if (param.Attributes["NAME"].Value == searchParamName)
                        {
                            if (param.Attributes["TYPE"] != null)
                            {
                                type = param.Attributes["TYPE"].Value;
                                if (type.ToLower() == "float")
                                {
                                    type = ParameterSearchValue.STRING_TYPE_DOUBLE;
                                }
                            }
                        }
                    }
                }
            }
            return type;
        }

        public void DeleteFromRelationsList(string xmlName)
        {
            if (_xmlFilesList.ContainsKey(xmlName))
            {
                XmlFile file = _xmlFilesList[xmlName];
                List<XmlTagRelation> relationsToDelete = new List<XmlTagRelation>();
                foreach (XmlTagRelation relation in _relationsList)
                {
                    if (relation.XmlFileID == file.Id)
                    {
                        relationsToDelete.Add(relation);
                    }
                }
                foreach (XmlTagRelation relation in relationsToDelete)
                {
                    _relationsList.Remove(relation);
                }
                _xmlFilesList.Remove(xmlName);
            }
        }

        public void ClearRelationsList()
        {
            _relationsList.Clear();
        }

        public void ClearXmlFilesList()
        {
            _xmlFilesList.Clear();
        }

        public void LoadXmlFilesFromDatabase()
        {
            XmlFile[] array = _reader.GetXmlFilesFromDataBase(_dataBase);

            foreach (XmlFile item in array)
            {
                if (!_xmlFilesList.ContainsKey(item.Name))
                {
                    _xmlFilesList.Add(item.Name, item);
                }
            }
        }

        public bool HasTagRelation(int xmlFileId, int tagId)
        {
            var customerQuery2 = from relation in _relationsList
                                 where relation.XmlFileID == xmlFileId && relation.TagID == tagId
                                 select relation;
            if (customerQuery2.Count() > 0)
            {
                return true;
            }

            return false;
        }

        public void LoadRelationsListFromDatabase(DataBase dataBase)
        {
            _relationsList = _reader.LoadRelationsFromDataBase(dataBase);
        }

        public void SaveRelationsToDatabase(DataBase dataBase)
        {
            _saver.SaveRelationsToDataBase(dataBase, _relationsList);
        }

        public void AddRelations(List<int> selectedXmlID, int tagId)
        {
                foreach (int i in selectedXmlID)
                {
                    XmlTagRelation relation = new XmlTagRelation();
                    relation.TagID = tagId;
                    relation.XmlFileID = i;
                    _relationsList.Add(relation);
                }
        }

        public void InitRelationsList()
        {
            _relationsList = new List<XmlTagRelation>();
        }

        public void SetDataBase(string name)
        {
            _dataBase = new DataBase(name);
        }

        public List<int> GetTagIdsForXmls(List<int> selectedXmlID)
        {
            List<int> tempTagList = new List<int>();

            for (int i = 0; i < selectedXmlID.Count; i++)
            {
                foreach (XmlTagRelation relation in _relationsList)
                {
                    if (relation.XmlFileID == selectedXmlID[i])
                    {
                        bool found = false;
                        //listBoxXmlTags.Items.Add(tagList[relation.tagID].name);
                        foreach (int id in tempTagList)
                        {
                            if (id == relation.TagID)
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                            tempTagList.Add(relation.TagID);
                    }
                }
            }

            return tempTagList;
        }

        /// <summary>
        /// Function removes from the relations list all relations with given tag for a given set of xmls
        /// </summary>
        /// <param name="selectedXmlID">ids of xmls</param>
        /// <param name="selectedIndex">tag id</param>
        public void RemoveRelations(List<int> selectedXmlID, int selectedIndex)
        {
            List<XmlTagRelation> deleted_tags = new List<XmlTagRelation>();
            foreach (XmlTagRelation item in _relationsList)
            {
                if (item.TagID == selectedIndex)
                {
                    foreach (int id_xml in selectedXmlID)
                        if (id_xml == item.XmlFileID)
                            deleted_tags.Add(item);
                }
            }

            foreach (XmlTagRelation item in deleted_tags)
            {
                _relationsList.Remove(item);
            }   
        }

        public void SaveFileListToDatabase(string name)
        {
            _saver.SaveFileListToDatabase(name, _dataBase, _xmlFilesList);
        }

        public List<string> GetXmlTagNames(string fileName, string tagName)
        {
            XmlDocument doc = _reader.OpenXmlDocument(fileName, _xmlFilesList);
            XmlNodeList list = doc.GetElementsByTagName(tagName);
            return GetNodeNames(list);
        }

        public List<string> GetParamNamesForGroupName(string fileName, string groupName)
        {
            XmlDocument doc = _reader.OpenXmlDocument(fileName, _xmlFilesList);
            XmlNodeList groupList = doc.GetElementsByTagName("GROUP");
            List<string> paramNames = null;

            foreach (XmlNode node in groupList)
            {
                if (node.Attributes["NAME"] == null)
                {
                    continue;
                }

                if (node.Attributes["NAME"].Value == groupName)
                {
                    XmlNodeList paramList = ((XmlElement)node).GetElementsByTagName("PARAM");
                    paramNames = GetNodeNames(paramList);
                }
            }
            return paramNames;
        } 

        public void DeleteDataBase()
        {
            _dataBase = null;
        }

        public List<string> CreateVariation(string name, List<VariedParameter> unvaried_yet,
            XmlFile xmlReference, ref int name_var_cnt)
        {
            return _variator.CreateVariation(name, unvaried_yet, xmlReference, ref name_var_cnt, _xmlFilesList);
        }

        public void CreateFileTree(TreeView treeView, string activeName)
        {
            _activeXmlFile = _xmlFilesList[activeName];
            _activeXmlFile.CreateFileTree(treeView);
        }

        public bool GenerateVariations(string mainName, Dictionary<string, VariedParameter> variedParameters)
        {
            return _variator.GenerateVariations(mainName, variedParameters, _xmlFilesList, _activeXmlFile);
        }

        #endregion

        #region Private methods

        private List<string> GetNodeNames(XmlNodeList list)
        {
            List<string> names = new List<string>();

            foreach (XmlNode node in list)
            {
                if (node.Attributes["NAME"] == null)
                {
                    continue;
                }

                names.Add(node.Attributes["NAME"].Value);
            }

            return names;
        }
        
        #endregion
    }
}
