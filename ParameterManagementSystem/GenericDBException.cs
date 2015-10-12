using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParameterManagementSystem
{
    /// <summary>
    //for reporting general errors with database saving
    /// </summary>
    class GenericDBException : SystemException
    {
        public string ErrorMessage;

        public GenericDBException(string p)
        {
            ErrorMessage = p;
        }
    };
}
