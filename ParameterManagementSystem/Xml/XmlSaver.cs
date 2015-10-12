using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ParameterManagementSystem.Xml
{
    /// <summary>
    /// Class providing output operations on xml
    /// </summary>
    public class XmlSaver
    {
        public void SaveRelationsToDataBase(DataBase dataBase, List<XmlTagRelation> relationsList)
        {
            XmlTagRelation[] relationsArray = new XmlTagRelation[relationsList.Count];
            relationsList.CopyTo(relationsArray, 0);
            dataBase.SaveRelations(relationsArray);
        }

        public void SaveFileListToDatabase(string name, DataBase dataBase, Dictionary<string, XmlFile> xmlFilesList)
        {
            if (File.Exists(name))
            {
                dataBase.DeleteAllData("XML_TAG_RELATION");
                dataBase.DeleteAllData("XML_TABLE");
                dataBase.DeleteAllData("TAGS");
                dataBase.DeleteAllData("USER");
            }
            else if (!dataBase.CreateNewDatabase())
            {
                throw new Exception("Database could not be created!");
            }

            XmlFile[] filesArray = new XmlFile[xmlFilesList.Values.Count];
            xmlFilesList.Values.CopyTo(filesArray, 0);
            dataBase.SaveFiles(filesArray);
        }
    }
}
