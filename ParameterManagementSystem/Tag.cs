using System.Linq;

namespace ParameterManagementSystem
{
    public class Tag
    {
        #region Properties

        public int Id { get; set; }

        public string Name { get; set; }

        #endregion

        #region Public methods

        public void GenerateID(Tag[] tagsArray)
        {
            if (tagsArray.Count<Tag>() == 0)
            {
                Id = 0;
                return;
            }
            int max_id = tagsArray[0].Id;
            foreach (Tag tag in tagsArray)
            {
                if (max_id < tag.Id)
                {
                    max_id = tag.Id;
                }
            }
            Id = max_id + 1;
        }

        #endregion
    }
}
