using System.Globalization;
using System.Collections.Generic;

namespace ParameterManagementSystem
{
    public class VariedParameter
    {
        #region Public fields
        // TODO: Get rid of public fields, suggestion: struct member
        public int group_id;
        public int param_id;
        public string param_type;
        public string variation_type;

        public string single;

        public string range_min;
        public string range_max;
        public string range_step;

        public List<string> values;

        #endregion

        #region Public methods

        public VariedParameter(int new_group_id, int new_param_id, string new_param_type,
            string new_variation_type = "single")
        {
            group_id = new_group_id;
            param_id = new_param_id;
            param_type = new_param_type;
            variation_type = new_variation_type;

            values = new List<string>();
        }

        public bool ClearList()
        {
            values.Clear();

            return true;
        }

        public bool SetSingle(string single_value)
        {
            variation_type = "single";
            ClearList();
            single = single_value;
            AddParameterValue(single);
            return true;
        }

        public bool SetRange(string min, string max, string step)
        {
            double dmin;
            double dmax;
            double dstep;
            double current;

            range_min = min;
            range_max = max;
            range_step = step;

            dmin = double.Parse(min, CultureInfo.InvariantCulture);
            dmax = double.Parse(max, CultureInfo.InvariantCulture);
            dstep = double.Parse(step, CultureInfo.InvariantCulture);
            current = dmin;

            if ((param_type == "Bool") || (param_type == "Text"))
            {
                return false;
            }
            else if (dmin > dmax)
            {
                return false;
            }
            else
            {
                variation_type = "range";
                ClearList();
                while (current <= dmax)
                {
                    AddParameterValue(current.ToString(CultureInfo.InvariantCulture));
                    current += dstep;
                }
            }

            return true;
        }

        public bool SetList()
        {
            if (variation_type != "list")
            {
                variation_type = "list";
                ClearList();
            }
            return true;
        }

        public bool AddParameterValue(string new_value)
        {
            switch (param_type)
            {
                case "Int":
                    int.Parse(new_value);
                    break;
                case "Float":
                    float.Parse(new_value, CultureInfo.InvariantCulture);
                    break;
                case "Double":
                    double.Parse(new_value, CultureInfo.InvariantCulture);
                    break;
                case "Bool":
                    bool.Parse(new_value);
                    break;
                default:
                    break;
            }
            values.Add(new_value);
            return true;
        }

        #endregion
    }
}
