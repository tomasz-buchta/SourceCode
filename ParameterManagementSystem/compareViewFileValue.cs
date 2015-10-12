using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParameterManagementSystem
{
    public partial class CompareViewFileValue : UserControl
    {
        private string filename;
        private string sValue;
        private double dValue;

        public CompareViewFileValue()
        {
            InitializeComponent();
        }
        public CompareViewFileValue(string _filename, string _sValue)
        {
            InitializeComponent();
            this.labelFilename.Text =  filename = _filename;
            this.labelValue.Text = sValue = _sValue;

            this.Size = new System.Drawing.Size(this.Size.Width, 18);
            this.Dock = DockStyle.Top;
            this.BackColor = System.Drawing.Color.White;
        }
        public CompareViewFileValue(string _filename, double _dValue)
        {
            InitializeComponent();
            dValue = _dValue;
            this.labelValue.Text = _dValue.ToString();
            this.labelFilename.Text = filename = _filename;

            this.Size = new System.Drawing.Size(this.Size.Width, 18);
            this.Dock = DockStyle.Top;
            this.BackColor = System.Drawing.Color.White;
        }
    }
}
