using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParameterManagementSystem
{
    public class XmlTagRelation
    {
        public int xmlFileID;
        public int tagID;
    }

    public class Tag
    {
        public int id;
        public string name;
        public void GenerateID(Tag[] tagsArray)
        {
            if (tagsArray.Count<Tag>() == 0)
            {
                id = 0;
                return;
            }
            int max_id = tagsArray[0].id;
            foreach (Tag tag in tagsArray)
            {
                if (max_id < tag.id)
                {
                    max_id = tag.id;
                }
            }
            id = max_id + 1;
        }
    }

    public class SearchingParameters
    {
        public SearchingParameters()
        {
            parameters = new List<ParameterSearchValue>();
            SearchingTagsIDs = new List<int>();
        }
        public void AddParameter(ParameterSearchValue param)
        {
            parameters.Add( param );
        }
        public void RemoveParameter(ParameterSearchValue param)
        {
            parameters.Remove(param);
        }
        public void ClearParameterList()
        {
            parameters.Clear();
        }
        public List<ParameterSearchValue> Parameters
        {
            get
            {
                return parameters;
            }
        }
        public List<int> SearchingTagsIDs;
        private List<ParameterSearchValue> parameters;
    }

    public class ParameterSearchValue
    {
        public const int TYPE_INT = 0;
        public const int TYPE_DOUBLE = 1;
        public const int TYPE_BOOL = 2;
        public const int TYPE_TEXT = 3;
        public const string STRING_TYPE_INT = "Int";
        public const string STRING_TYPE_DOUBLE = "Double";
        public const string STRING_TYPE_BOOL = "Bool";
        public const string STRING_TYPE_TEXT = "Text";
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
    }

    public class BatchExecutor
    {
        private string dir;             // file to batch file

        public BatchExecutor(string new_dir)
        {
            dir = new_dir;
        }

        public void execute_script()
        {
            // create new local process
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            // set properties of new process
            proc.StartInfo.FileName = dir;  // path to batch file
            proc.StartInfo.UseShellExecute = false; // do not use system shell, True crashes application!
            proc.StartInfo.CreateNoWindow = true; // hide cmd window

            string work_dir = dir.Substring(0, dir.LastIndexOf('\\'));
            proc.StartInfo.WorkingDirectory = work_dir;

            proc.Start();   // start process
            proc.WaitForExit(); // wait untill process ends
        }
    }

    public class VariedParameter
    {
        public int group_id;
        public int param_id;
        public string param_type;
        public string variation_type;

        public string single;

        public string range_min;
        public string range_max;
        public string range_step;

        public List<string> values;

        public VariedParameter(int new_group_id, int new_param_id, string new_param_type,
            string new_variation_type="single")
        {
            group_id = new_group_id;
            param_id = new_param_id;
            param_type = new_param_type;
            variation_type = new_variation_type;

            values = new List<string>();
        }

        public bool clearList()
        {
            values.Clear();

            return true;
        }

        public bool setSingle(string single_value)
        {
            variation_type = "single";
            clearList();
            single = single_value;
            addParameterValue(single);
            return true;
        }

        public bool setRange(string min, string max, string step)
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
                clearList();
                while (current <= dmax)
                {
                    addParameterValue(current.ToString(CultureInfo.InvariantCulture));
                    current += dstep;
                }
            }
            return true;
        }

        public bool setList()
        {
            if (variation_type != "list")
            {
                variation_type = "list";
                clearList();
            }
            return true;
        }

        public bool addParameterValue(string new_value)
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

    }
}
