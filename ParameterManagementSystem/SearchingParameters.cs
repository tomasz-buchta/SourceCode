using System.Collections.Generic;

namespace ParameterManagementSystem
{
    public class SearchingParameters
    {
        #region Private fields

        private List<ParameterSearchValue> _parameters;

        #endregion

        #region Constructors

        public SearchingParameters()
        {
            _parameters = new List<ParameterSearchValue>();
            SearchingTagsIDs = new List<int>();
        }

        #endregion

        #region Properties

        public List<ParameterSearchValue> Parameters
        {
            get
            {
                return _parameters;
            }
        }

        public List<int> SearchingTagsIDs { get; set; }

        #endregion

        #region Public methods

        public void AddParameter(ParameterSearchValue param)
        {
            _parameters.Add(param);
        }

        public void RemoveParameter(ParameterSearchValue param)
        {
            _parameters.Remove(param);
        }

        public void ClearParameterList()
        {
            _parameters.Clear();
        }

        #endregion
    }
}
