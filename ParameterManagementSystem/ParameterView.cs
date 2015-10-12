using System;
using System.Windows.Forms;

namespace ParameterManagementSystem
{
    public partial class ParameterView : UserControl
    {
        public ParameterView(ParameterViewList _owner, ParameterSearchValue param)
        {
            InitializeComponent();
            owner = _owner;
            this.Size = new System.Drawing.Size(this.Size.Width, 17);
            this.Dock = DockStyle.Top;
            this.BackColor = System.Drawing.Color.White;
            parameter = param;
            Set(param);
        }

        public ParameterSearchValue Parameter
        {
            get
            {
                return parameter;
            }
        }

        public void Set( ParameterSearchValue param ){
            labelGroup.Text = param.group;
            labelParameterName.Text = param.parameterName;
            switch( param.valueType )
            {
                case ParameterSearchValue.TYPE_INT:
                    labelType.Text = ParameterSearchValue.STRING_TYPE_INT;
                    labelValue.Text = Convert.ToString(param.value1_int);
                    if (param.range)
                    {
                        labelValue2.Text = Convert.ToString(param.value2_int);
                    }
                    break;
                case ParameterSearchValue.TYPE_BOOL:
                    labelType.Text = ParameterSearchValue.STRING_TYPE_BOOL;
                    labelValue.Text = Convert.ToString(param.value_bool);
                    break;
                case ParameterSearchValue.TYPE_DOUBLE:
                    labelType.Text = ParameterSearchValue.STRING_TYPE_DOUBLE;
                    labelValue.Text = Convert.ToString(param.value1_double);
                    if (param.range)
                    {
                        labelValue2.Text = Convert.ToString(param.value2_double);
                    }
                    break;
                case ParameterSearchValue.TYPE_TEXT:
                    labelType.Text = ParameterSearchValue.STRING_TYPE_TEXT;
                    labelValue.Text = Convert.ToString(param.value_string);
                    break;
            }
             
        }

        public new void Select()
        {
            this.BackColor = System.Drawing.Color.LightBlue;
        }

        public void Unselect()
        {
            this.BackColor = System.Drawing.Color.White;
        }

        private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            owner.SelectedItem = this;
        }

        private ParameterViewList owner;
        private ParameterSearchValue parameter;

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
