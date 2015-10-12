using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ParameterManagementSystem
{
    /// <summary>
    /// provides adding xmls from command line functionality
    /// </summary>
    class ConsoleHost
    {

        #region private fields

        private static string[] _argFileNames;
        private static DataBase _dataBase;
        private static List<XmlFile> _xmlList;

        #endregion

        public static void Run(string[] fileNames)
        {
            try
            {
                InitializePrivateFields(fileNames);

                //if the database exists..
                if (File.Exists(_argFileNames[0]))
                {
                    System.Console.WriteLine("\nDATABASE OPENED, ADDING XMLs...");
                    _xmlList = _dataBase.LoadDataBaseContent().ToList();
                    WriteToDatabase();
                }
                //database does not exist
                else
                {
                    System.Console.WriteLine("\nDATABASE DOES NOT EXIST, CREATING NEW ONE...");
                    WriteToDatabase();
                    System.Console.WriteLine("\nDATABASE FILE CREATED");
                }
                System.Console.WriteLine("\nXMLs ADDED SUCCESSFULLY");
            }
            catch (GenericDBException ge)
            {
                System.Console.WriteLine(ge.ErrorMessage);
                return;
            }
            catch (FileNotFoundException missingFile)
            {
                System.Console.WriteLine("\nFILE " + Path.GetFileName(missingFile.FileName) + " DOES NOT EXIST, TERMINATING EXECUTION!");
                return;
            }
            catch (IOException alreadyOpened)
            {
                System.Console.WriteLine(alreadyOpened.Message);
                return;
            }
        }

        #region private methods

        private static void InitializePrivateFields(string[] fileNames)
        {
            _dataBase = new DataBase(fileNames[0]);
            _argFileNames = new string[fileNames.Count()];
            fileNames.CopyTo(_argFileNames, 0);
            _xmlList = new List<XmlFile>();
        }

        private static void WriteToDatabase()
        {
            AddXmlsToList();
            SaveChanges();
        }

        private static void AddXmlsToList()
        {
            //creating list with files content
            for (int i = 1; i < _argFileNames.Count(); ++i)
            {
                XmlFile singleXml = new XmlFile();
                singleXml.Name = Path.GetFileName(_argFileNames[i]);
                if (".xml" != Path.GetExtension(_argFileNames[i]))
                {
                    throw new IOException("THE FILE IS NOT AN .XML FILE (BAD EXTENSION)");
                }
                singleXml.Content = File.ReadAllText(_argFileNames[i]);
                singleXml.TimeStamp = File.GetLastWriteTime(_argFileNames[i]);
                singleXml.GenerateID(_xmlList.ToArray());
                _xmlList.Add(singleXml);
            }            
        }

        private static void SaveChanges()
        {
            _dataBase = new DataBase(_argFileNames[0]);

            if (File.Exists(_argFileNames[0]))
            {
                _dataBase.DeleteAllData("XML_TABLE");
            }
            //error while creating database file
            else if (!_dataBase.CreateNewDatabase())
            {
                throw new GenericDBException("\nERROR CREATING NEW DATABASE!");
            }
            //saves data to the database file
            if (!_dataBase.SaveFiles(_xmlList.ToArray()))
            {
                throw new GenericDBException("\nERROR SAVING DATA TO THE DATABASE!");
            }
        }

        #endregion
    }
}
