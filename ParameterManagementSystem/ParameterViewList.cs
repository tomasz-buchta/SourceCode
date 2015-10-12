using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ParameterManagementSystem
{
    public partial class ParameterViewList : UserControl
    {
        #region Public methods
        
        public ParameterViewList()
        {
            InitializeComponent();
            selectedItem = null;
            parameterViewsList = new List<ParameterView>();
        }

        public void AddParameterView(ParameterSearchValue param)
        {
            ParameterView parameterView = new ParameterView(this, param);
            this.panel1.Controls.Add(parameterView);
            if (this.panel1.Controls.Count * 17 + 18 > this.Size.Height)
            {
                this.tableLayoutPanel1.ColumnStyles[5].Width = 20F;
            }
            parameterViewsList.Add(parameterView);
        }

        public void RemoveSelectedParameterView()
        {
            if (selectedItem == null)
            {
                return;
            }
            this.panel1.Controls.Remove(selectedItem);
            selectedItem = null;
            if (this.panel1.Controls.Count * 17 + 18 <= this.Size.Height)
            {
                this.tableLayoutPanel1.ColumnStyles[5].Width = 0F;
            }
            parameterViewsList.Remove(selectedItem);
        }

        public void ClearParameterList()
        {
            foreach (ParameterView parameterView in parameterViewsList)
            {
                this.panel1.Controls.Remove(parameterView);
            }
            Predicate<ParameterView> predicate = new Predicate<ParameterView>(func);
            parameterViewsList.RemoveAll(predicate);
        }

        public ParameterView SelectedItem
        {
            set
            {
                if (selectedItem != null)
                {
                    selectedItem.Unselect();
                }
                selectedItem = value;
                if (selectedItem != null)
                {
                    selectedItem.Select();
                }
            }
            get
            {
                return selectedItem;
            }
        } 
        
        #endregion
        
        #region Private fields

        private bool func(ParameterView item) { return true; }
        private ParameterView selectedItem;
        private List<ParameterView> parameterViewsList; 
        
        #endregion
    }
}
