using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace ParameterManagementSystem.Xml
{
    /// <summary>
    /// Class providing input operations on xml
    /// </summary>
    public class XmlReader
    {
        #region Public methods

        public string GetAttributeValue(XmlNode node, string attributeName)
        {
            XmlAttribute attribute = node.Attributes[attributeName];

            if (attribute != null)
            {
                return attribute.Value;
            }
            else
            {
                return "";
            }
        }

        public List<string> LoadXmlFilesFromFileNames(string[] fileNames, Dictionary<string, XmlFile> xmlFilesList)
        {
            List<string> xmlNames = new List<string>();
            foreach (string fileName in fileNames)
            {
                if (!File.Exists(fileName))
                {
                    continue;
                }

                XmlFile[] filesArray = new XmlFile[xmlFilesList.Values.Count];
                xmlFilesList.Values.CopyTo(filesArray, 0);

                XmlFile item = new XmlFile();
                item.GenerateID(filesArray);
                item.Name = Path.GetFileName(fileName);
                item.Content = File.ReadAllText(fileName);
                item.TimeStamp = File.GetLastWriteTime(fileName);

                if (!xmlFilesList.ContainsKey(item.Name))
                {
                    xmlFilesList.Add(item.Name, item);
                    xmlNames.Add(item.Name);
                }
            }

            return xmlNames;
        }

        public XmlFile[] GetXmlFilesFromDataBase(DataBase dataBase)
        {
            return dataBase.LoadDataBaseContent();
        }

        public List <XmlTagRelation> LoadRelationsFromDataBase(DataBase dataBase)
        {
            return dataBase.LoadRelationArray();
        }

        public XmlDocument OpenXmlDocument(string fileName, Dictionary<string, XmlFile> xmlFilesList)
        {
            XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(xmlFilesList[fileName].Content);
            return doc;
        }

        #endregion
    }
}
