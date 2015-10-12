using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ParameterManagementSystem.Xml;

namespace ParameterManagementSystem
{
    public partial class TagPanel : UserControl
    {
        public TagPanel()
        {
            InitializeComponent();
            tagList = new Dictionary<int, Tag>();

            _xmlManager.InitRelationsList();
            
            _selectedXmlID = new List<int>();
        }

        public void ClearTagsList()
        {
            tagList.Clear();
            listBoxAvailTags.Items.Clear();
        }

        public void TagList_AddItem(Tag item)
        {
            tagList.Add(item.Id, item);
            listBoxAvailTags.Items.Add(item.Name);
        }

        public void LoadTagsFromDatabase(DataBase dataBase)
        {
            ClearTagsList();
            Tag[] tagsArray = dataBase.LoadTagsArray();
            foreach (Tag item in tagsArray)
            {
                if (!tagList.ContainsKey(item.Id))
                {
                    TagList_AddItem(item);
                }
            }
            ((Form1)(this.ParentForm)).UpdateComboBoxTags();
        }

        public void LoadRelationsFromDatabase(DataBase dataBase)
        {
            _xmlManager.ClearRelationsList();
            _xmlManager.LoadRelationsListFromDatabase(dataBase);
        }

        public void SaveRelations(DataBase dataBase)
        {
            _xmlManager.SaveRelationsToDatabase(dataBase);
        }

        public void SaveTags(DataBase dataBase)
        {
            Tag[] tagsArray = new Tag[tagList.Values.Count];
            tagList.Values.CopyTo(tagsArray, 0);
            dataBase.SaveTags(tagsArray);
        }

        public List<int> SelectedXmlID
        {
            get
            {
                return _selectedXmlID;
            }

            set
            {
                _selectedXmlID = value;

                listBoxAssignTags.Items.Clear();

                if (_selectedXmlID.Count == 0)
                    return;

                List<int> tempTagList = _xmlManager.GetTagIdsForXmls(_selectedXmlID);

                if (tempTagList != null)
                {
                    foreach (int id in tempTagList)
                    {
                        listBoxAssignTags.Items.Add(tagList[id].Name);
                    }   
                }
            }
        }

        public Dictionary<int, Tag> tagList;

        #region Controls Action

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDefineTag.Text))
            {
                return;
            }
            if (listBoxAvailTags.Items.Contains(textBoxDefineTag.Text))
            {
                return;
            }
            listBoxAvailTags.Items.Add(textBoxDefineTag.Text);
            Tag tag = new Tag();

            Tag[] tagsArray = new Tag[tagList.Values.Count];
            tagList.Values.CopyTo(tagsArray, 0);
            tag.GenerateID(tagsArray);
            tag.Name = textBoxDefineTag.Text;
            tagList.Add(tag.Id, tag);
            textBoxDefineTag.Text = "";

            ((Form1)(this.ParentForm)).UpdateComboBoxTags();
        }

        private void buttonAssignTag_Click(object sender, EventArgs e)
        {
            if (listBoxAvailTags.SelectedItem == null || _selectedXmlID.Count == 0)
            {
                return;
            }

            bool exists = listBoxAssignTags.Items.Contains(listBoxAvailTags.SelectedItem);

            if (!exists)
            {
                listBoxAssignTags.Items.Add(listBoxAvailTags.SelectedItem);
            }

            int tagID = GetSelectedTagIndex((string)(listBoxAvailTags.SelectedItem));
            if (tagID != -1)
            {
                _xmlManager.AddRelations(_selectedXmlID, tagID);
            };
        }

        private void buttonDeleteAvailTag_Click(object sender, EventArgs e)
        {
            if( listBoxAvailTags.SelectedItem == null )
            {
                return;
            }

            Tag[] tagsArray = new Tag[tagList.Values.Count];
            tagList.Values.CopyTo(tagsArray, 0);
            foreach (Tag tag in tagsArray)
            {
                if (tag.Name == (string)(listBoxAvailTags.SelectedItem))
                {
                    tagList.Remove(tag.Id);
                    break;
                }
            }
            listBoxAvailTags.Items.Remove(listBoxAvailTags.SelectedItem);
        }

        private void buttonDeleteAssignTag_Click(object sender, EventArgs e)
        {
            if (listBoxAssignTags.SelectedItem == null)
            {
                return;
            }

            int selectedIndex = GetSelectedTagIndex((string)(listBoxAssignTags.SelectedItem));

            _xmlManager.RemoveRelations(_selectedXmlID, selectedIndex);

            listBoxAssignTags.Items.Remove(listBoxAssignTags.SelectedItem);
        }

        private int GetSelectedTagIndex(string value)
        {
            Tag[] tagsArray = new Tag[tagList.Values.Count];
            tagList.Values.CopyTo(tagsArray, 0);
            foreach (Tag tag in tagsArray)
            {
                if (tag.Name == value)
                {
                    return tag.Id;
                }
            }
            return -1;
        }

        #endregion

        private List<int> _selectedXmlID;
        private XmlManager _xmlManager = XmlManager.Instance;
    }
}
