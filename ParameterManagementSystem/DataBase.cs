using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using ADOX;

namespace ParameterManagementSystem
{
    public class DataBase
    {
        #region Consts
        private const string GET_ALL = "SELECT * FORM {0};";
        private const string DELETE_ALL = "DELETE * FROM {0};";

        private const string NEW_TAG = "INSERT INTO TAGS(TAG_ID, TAG_NAME) VALUES({0}, '{1}');";
        private const string NEW_XML_TAG_RELATION = "INSERT INTO XML_TAG_RELATION(TAG_ID, XML_ID) VALUES({0}, {1});";
        private const string NEW_XML_FILE = "INSERT INTO XML_TABLE(XML_ID, FILE_NAME, XML_FILE, TIME_STAMP) VALUES({0}, '{1}', '{2}', '{3}');";
        #endregion

        #region Private fields

        /// <summary>
        /// Describes database structure
        /// </summary>
        private Catalog _cat;

        /// <summary>
        /// Path to database file
        /// </summary>
        private string _databaseFileName;

        #endregion

        #region Constructors

        /// <summary>
        /// Saves given database file path
        /// </summary>
        /// <param name="name">Database file path</param>
        public DataBase(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
              throw new ArgumentException("Given database file path is empty or null");

            _databaseFileName = name;
        }

        #endregion

        #region Properties
     
        /// <summary>
        /// Provides access to database name
        /// </summary>
        public string Name
        {
            get { return this._databaseFileName; }
        }
        
        #endregion

        #region Public methods

        /// <summary>
        /// Removes all entries from given table
        /// </summary>
        /// <param name="table">Table name</param>
        /// <returns>True if success</returns>
        public bool DeleteAllData(string table)
        {
            string strSQL = string.Format(DELETE_ALL, table);
            ADODB.Connection con = new ADODB.Connection();
            object obj = new object();

            try
            {
                con.Open(GenerateConnectionString(), "", "", 0);
            }
            catch (Exception)
            {
                //TODO: Error logging
                return false;
            }
            
            try
            {
                con.Execute(strSQL, out obj, 0);
            }
            catch (Exception)
            {
                //TODO: Error logging
                con.Close();
                return false;
            }

            con.Close();
            return true;
        }

        /// <summary>
        /// Creates new database file
        /// </summary>
        /// <returns>True if success</returns>
        public bool CreateNewDatabase()
        {
            try
            {
                _cat = new Catalog();
                string strCreateDB = GenerateConnectionString();
                _cat.Create(strCreateDB);
                _cat.let_ActiveConnection(strCreateDB);

                CreateTableXmlTable();
                CreateTableTags();
                CreateTableXmlTagsRelation();
                CreateTableUser();

                return true;
            }
            catch (Exception)
            {
                //TODO: Error logging
                return false;
            }
        }

        /// <summary>
        /// Saves relations between TAGs and XML rows
        /// </summary>
        /// <param name="relationsArray">List with TAG IDs and XML FIELD IDs</param>
        /// <returns>True if success</returns>
        public bool SaveRelations(XmlTagRelation[] relationsArray)
        {
            string strSQL;
            ADODB.Connection con = new ADODB.Connection();
            object obj = new object();

            try
            {
                con.Open(GenerateConnectionString(), "", "", 0);
            }
            catch (Exception)
            {
                //TODO: Error logging
                return false;
            }
            
            for (int i = 0; i < relationsArray.Length; i++)
            {
                strSQL = string.Format(NEW_XML_TAG_RELATION,
                    relationsArray[i].TagID,
                    relationsArray[i].XmlFileID);

                try
                {
                    con.Execute(strSQL, out obj, 0);
                }
                catch (Exception)
                {
                    //TODO: Error logging
                    con.Close();
                    return false;
                }
            }

            con.Close();
            return true;
        }

        /// <summary>
        /// Saves TAGs list into database
        /// </summary>
        /// <param name="tagsArray">List of TAGs</param>
        /// <returns>True if success</returns>
        public bool SaveTags(Tag[] tagsArray)
        {
            string strSQL;
            ADODB.Connection con = new ADODB.Connection();
            object obj = new object();

            try
            {
                con.Open(GenerateConnectionString(), "", "", 0);
            }
            catch (Exception)
            {
                //TODO: Error logging
                return false;
            }
            
            for (int i = 0; i < tagsArray.Length; i++)
            {
                strSQL = string.Format(NEW_TAG,
                    tagsArray[i].Id,
                    tagsArray[i].Name);

                try
                {
                    con.Execute(strSQL, out obj, 0);
                }
                catch (Exception)
                {
                    //TODO: Error logging
                    con.Close();
                    return false;
                }
            }

            con.Close();
            return true;
        }

        /// <summary>
        /// Saves information about XML Files into database
        /// </summary>
        /// <param name="filesArray">List with informations about XML Files</param>
        /// <returns>True if success</returns>
        public bool SaveFiles(XmlFile[] filesArray)
        {
            string strSQL;
            ADODB.Connection con = new ADODB.Connection();
            object obj = new object();

            try
            {
                con.Open(GenerateConnectionString(), "", "", 0);
            }
            catch (Exception)
            {
                return false;
            }

            for (int i = 0; i < filesArray.Length; i++)
            {
                strSQL = string.Format(NEW_XML_FILE,
                    filesArray[i].Id,
                    filesArray[i].Name,
                    filesArray[i].Content,
                    filesArray[i].TimeStamp);

                try
                {
                    con.Execute(strSQL, out obj, 0);
                }
                catch (Exception)
                {
                    //TODO: Error logging
                    con.Close();
                    return false;
                }
            }

            con.Close();
            return true;
        }

        public Tag[] LoadTagsArray()
        {
            string strAccessConn = GenerateConnectionString();
            string strAccessSelect = string.Format(GET_ALL, "TAGS");

            // Create the dataset and add the Categories table to it:
            DataSet myDataSet = new DataSet();
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(strAccessConn);
            }
            catch (Exception)
            {
                return null;
            }

            try
            {
                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "TAGS");
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                myAccessConn.Close();
            }

            DataRowCollection dra = myDataSet.Tables["TAGS"].Rows;
            Tag[] array = new Tag[dra.Count];

            for (int i = 0; i < dra.Count; i++)
            {
                DataRow dr = dra[i];
                array[i] = new Tag();
                array[i].Id = (int)(dr.ItemArray[0]);
                array[i].Name = ((string)(dr.ItemArray[1])).Trim();
            }
            return array;
        }

        public List<XmlTagRelation> LoadRelationArray()
        {
            string strAccessConn = GenerateConnectionString();
            string strAccessSelect = "SELECT * FROM XML_TAG_RELATION";

            // Create the dataset and add the Categories table to it:
            DataSet myDataSet = new DataSet();
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(strAccessConn);
            }
            catch (Exception)
            {
                return null;
            }

            try
            {
                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "XML_TAG_RELATION");
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                myAccessConn.Close();
            }

            DataRowCollection dra = myDataSet.Tables["XML_TAG_RELATION"].Rows;
            List<XmlTagRelation> array = new List<XmlTagRelation>();

            for (int i = 0; i < dra.Count; i++)
            {
                DataRow dr = dra[i];
                XmlTagRelation item = new XmlTagRelation();
                item.TagID = (int)(dr.ItemArray[0]);
                item.XmlFileID = (int)(dr.ItemArray[1]);
                array.Add(item);
            }
            return array;
        }

        public XmlFile[] LoadDataBaseContent()
        {
            string strAccessConn = GenerateConnectionString();
            string strAccessSelect = "SELECT * FROM XML_TABLE";

            // Create the dataset and add the Categories table to it:
            DataSet myDataSet = new DataSet();
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(strAccessConn);
            }
            catch (Exception)
            {
                return null;
            }

            try
            {
                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "XML_TABLE");
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                myAccessConn.Close();
            }

            DataRowCollection dra = myDataSet.Tables["XML_TABLE"].Rows;
            XmlFile[] array = new XmlFile[dra.Count];

            for (int i = 0; i < dra.Count; i++)
            {
                DataRow dr = dra[i];
                array[i] = new XmlFile();
                array[i].Id = (int)(dr.ItemArray[0]);
                array[i].Name = ((string)(dr.ItemArray[1])).Trim();
                array[i].Content = ((string)(dr.ItemArray[2])).Trim();
                array[i].TimeStamp = (DateTime)(dr.ItemArray[3]);
            }
            return array;
        }

        public string LoadUserItem(int id)
        {
            string strAccessConn = GenerateConnectionString();
            string strAccessSelect = "SELECT * FROM USER_VALS WHERE ITEM_ID=" + id;

            // Create the dataset and add the Categories table to it:
            DataSet myDataSet = new DataSet();
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(strAccessConn);
            }
            catch (Exception)
            {
                return null;
            }

            try
            {
                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "USER_VALS");
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                myAccessConn.Close();
            }

            DataRowCollection dra = myDataSet.Tables["USER_VALS"].Rows;
            if (dra.Count == 1)
                return dra[0].ItemArray[1].ToString();

            return null;
        } 

        #endregion

        #region Private methods

        private bool CreateTableXmlTable()
        {
            try
            {
                ADOX.Table objTable = new ADOX.Table();

                //Create the table
                objTable.Name = "XML_TABLE";

                //Create and Append a new field to the "Test_Table" Columns Collection
                objTable.Columns.Append("XML_ID", DataTypeEnum.adInteger);
                objTable.Columns.Append("FILE_NAME", DataTypeEnum.adWChar);
                objTable.Columns.Append("XML_FILE", DataTypeEnum.adLongVarWChar);
                objTable.Columns.Append("TIME_STAMP", DataTypeEnum.adDate);

                //Create and Append a new key. Note that we are merely passing
                //the "PimaryKey_Field" column as the source of the primary key. This
                //new Key will be Appended to the Keys Collection of "Test_Table"
                objTable.Keys.Append("PrimaryKey", KeyTypeEnum.adKeyPrimary, "XML_ID");

                //Append the newly created table to the Tables Collection
                _cat.Tables.Append(objTable);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool CreateTableTags()
        {
            try
            {
                ADOX.Table objTable = new ADOX.Table();

                //Create the table
                objTable.Name = "TAGS";

                //Create and Append a new field to the "Test_Table" Columns Collection
                objTable.Columns.Append("TAG_ID", DataTypeEnum.adInteger);
                objTable.Columns.Append("TAG_NAME", DataTypeEnum.adWChar);

                //Create and Append a new key. Note that we are merely passing
                //the "PimaryKey_Field" column as the source of the primary key. This
                //new Key will be Appended to the Keys Collection of "Test_Table"
                objTable.Keys.Append("PrimaryKey", KeyTypeEnum.adKeyPrimary, "TAG_ID");

                //Append the newly created table to the Tables Collection
                _cat.Tables.Append(objTable);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool CreateTableXmlTagsRelation()
        {
            try
            {
                ADOX.Table objTable = new ADOX.Table();

                //Create the table
                objTable.Name = "XML_TAG_RELATION";

                //Create and Append a new field to the "Test_Table" Columns Collection
                objTable.Columns.Append("TAG_ID", DataTypeEnum.adInteger);
                objTable.Columns.Append("XML_ID", DataTypeEnum.adInteger);

                //Create and Append a new key. Note that we are merely passing
                //the "PimaryKey_Field" column as the source of the primary key. This
                //new Key will be Appended to the Keys Collection of "Test_Table"
                objTable.Keys.Append("ForeignKey1", KeyTypeEnum.adKeyForeign, "XML_ID", "XML_TABLE", "XML_ID");
                objTable.Keys.Append("ForeignKey2", KeyTypeEnum.adKeyForeign, "TAG_ID", "TAGS", "TAG_ID");

                //Append the newly created table to the Tables Collection
                _cat.Tables.Append(objTable);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string GenerateConnectionString()
        {
            string strCreateDB = "Provider=Microsoft.Jet.OLEDB.4.0;";
            strCreateDB += "Data Source=" + _databaseFileName + ";";
            strCreateDB += "Jet OLEDB:Engine Type=5";

            return strCreateDB;
        }

        private bool CreateTableUser()
        {
            try
            {
                ADOX.Table objTable = new ADOX.Table();

                //Create the table
                objTable.Name = "USER_VALS";

                //Create and Append a new field to the "Test_Table" Columns Collection
                objTable.Columns.Append("ITEM_ID", DataTypeEnum.adInteger);
                objTable.Columns.Append("ITEM_VAL", DataTypeEnum.adWChar);

                //Create and Append a new key. Note that we are merely passing
                //the "PimaryKey_Field" column as the source of the primary key. This
                //new Key will be Appended to the Keys Collection of "Test_Table"
                objTable.Keys.Append("PrimaryKey", KeyTypeEnum.adKeyPrimary, "ITEM_ID");

                //Append the newly created table to the Tables Collection
                _cat.Tables.Append(objTable);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
