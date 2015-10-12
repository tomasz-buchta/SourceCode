using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParameterManagementSystem
{

    public class BatchExecutor
    {
        #region Private fields

        private string _dir;             // file to batch file 

        #endregion

        #region Public methods

        public BatchExecutor(string newDir)
        {
            _dir = newDir;
        }

        public void ExecuteScript()
        {
            // create new local process
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            // set properties of new process
            proc.StartInfo.FileName = _dir;  // path to batch file
            proc.StartInfo.UseShellExecute = false; // do not use system shell, True crashes application!
            proc.StartInfo.CreateNoWindow = true; // hide cmd window

            string work_dir = _dir.Substring(0, _dir.LastIndexOf('\\'));
            proc.StartInfo.WorkingDirectory = work_dir;

            proc.Start();   // start process
            proc.WaitForExit(); // wait untill process ends
        }

        #endregion
    }
}
