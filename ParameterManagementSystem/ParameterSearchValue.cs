using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParameterManagementSystem
{

    public class ParameterSearchValue
    {
        #region Public fields

        #region Constants
        // TODO: replace with enums!
        public const int TYPE_INT = 0;
        public const int TYPE_DOUBLE = 1;
        public const int TYPE_BOOL = 2;
        public const int TYPE_TEXT = 3;
        public const string STRING_TYPE_INT = "Int";
        public const string STRING_TYPE_DOUBLE = "Double";
        public const string STRING_TYPE_BOOL = "Bool";
        public const string STRING_TYPE_TEXT = "Text";

        #endregion

        #region Fields
        // TODO: struct member instead of public fields?
        public string group;
        public string parameterName;
        public bool range;
        public double value1_double;
        public double value2_double;
        public int value1_int;
        public int value2_int;
        public bool value_bool;
        public string value_string;
        public int valueType;

        #endregion

        #endregion
    }
}
