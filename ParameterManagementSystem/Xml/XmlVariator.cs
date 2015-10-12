using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParameterManagementSystem.Xml
{
    /// <summary>
    /// Class responsible for variating parameters in xmls
    /// </summary>
    public class XmlVariator
    {
        public List<string> CreateVariation(string name, List<VariedParameter> unvaried_yet,
            XmlFile xmlReference, ref int name_var_cnt, Dictionary<string, XmlFile> xmlFilesList)
        {
            int list_counter = 0;
            string local_name = name;
            List<VariedParameter> locally_unvaried, locally_varied;
            List<string> xmlNames = new List<string>();

            XmlFile xmlCopy;

            locally_unvaried = new List<VariedParameter>(unvaried_yet);

            while (locally_unvaried.Count > 0)
            {
                foreach (string value in locally_unvaried[list_counter].values)
                {
                    xmlReference.SetParam(locally_unvaried[list_counter].group_id,
                        locally_unvaried[list_counter].param_id, value);

                    if (locally_unvaried.Count > 1)
                    {
                        locally_varied = new List<VariedParameter>(locally_unvaried);
                        locally_varied.RemoveAt(list_counter);
                        CreateVariation(local_name, locally_varied, xmlReference,
                            ref name_var_cnt, xmlFilesList);
                    }
                    else
                    {
                        xmlCopy = new XmlFile();
                        xmlCopy.Name = local_name + "_" + name_var_cnt.ToString();
                        xmlCopy.Tag = xmlReference.Tag;
                        xmlCopy.TimeStamp = DateTime.Now;
                        xmlCopy.Content = xmlReference.Content;

                        xmlFilesList.Add(xmlCopy.Name, xmlCopy);
                        xmlNames.Add(xmlCopy.Name);
                        name_var_cnt++;
                    }
                }
                locally_unvaried.RemoveAt(list_counter);
                list_counter++;
                return xmlNames;
            }
            return xmlNames;
        }

        public bool GenerateVariations(string mainName, Dictionary<string, VariedParameter> variedParameters, Dictionary<string, XmlFile> xmlFilesList, XmlFile activeXmlFile)
        {
            int name_var_cnt = 0;
            XmlFile xmlReference = new XmlFile();
            List<VariedParameter> varied_parameters_list;

            if (mainName != "")
            {
                if ((xmlFilesList.ContainsKey(mainName)) ||
                    (xmlFilesList.ContainsKey(mainName + "_0")))
                {
                    return false;
                }
                else
                {
                    xmlReference.Name = activeXmlFile.Name;
                    xmlReference.Tag = activeXmlFile.Tag;
                    xmlReference.TimeStamp = activeXmlFile.TimeStamp;
                    xmlReference.Content = activeXmlFile.Content;

                    varied_parameters_list = new List<VariedParameter>(variedParameters.Values);
                    CreateVariation(mainName, varied_parameters_list, xmlReference,
                        ref name_var_cnt, xmlFilesList);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
