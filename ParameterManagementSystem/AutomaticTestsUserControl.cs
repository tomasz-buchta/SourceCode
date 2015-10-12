using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

/** yo, 
/** this is some exemplary change in code */


namespace ParameterManagementSystem
{
    public partial class AutomaticTestsUserControl : UserControl
    {
        delegate void SetMinCallback(int value);
        delegate void SetMaxCallback(int value);
        delegate void SetValueCallback(int value);
        delegate void ClearListCallback();
        delegate void AddTextCallback(string text);

        public AutomaticTestsUserControl(Dictionary<string, XmlFile> xmlFilesList, ListBox listBoxXmlFiles)
        {
            InitializeComponent();
            xmlFilesListReference = xmlFilesList;
            listBoxXmlFilesReference = listBoxXmlFiles;

            backgroundWorker1.WorkerSupportsCancellation = true;

            file_dir = "c:\\SE_test";
            batch_dir = "c:\\SE_test\\test_batch.bat";
            executor = new BatchExecutor(batch_dir);
        
        }

        private Dictionary<string, XmlFile> xmlFilesListReference;
        private ListBox listBoxXmlFilesReference;
        private BatchExecutor executor;
        private string batch_dir;
        private string file_dir;
        private DataBase database;

        public DataBase Database
        {
            set
            {
                database = value;

                string res = database.LoadUserItem(0);
                if (res != null)
                {
                    int n = res.Length - 1;
                    while (n > 0 && res[n--] == ' ');
                    if (n >= 0)
                        res = res.Substring(0, n + 2);

                    file_dir = res;
                }
                res = database.LoadUserItem(1);
                if (res != null)
                {
                    int n = res.Length - 1;
                    while (n > 0 && res[n--] == ' ') ;
                    if (n >= 0)
                        res = res.Substring(0, n + 2);

                    batch_dir = res;
                    executor = new BatchExecutor(batch_dir);
                }
            }

        }

        private string get_log_time()
        {
            DateTime log_time = DateTime.Now;
            string format = "{0:s}";
            string log_time_string;

            log_time_string = String.Format(format, log_time);
            return log_time_string;
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            this.file_dir = textBoxDefineTag.Text;
            if (String.IsNullOrEmpty(file_dir)) {
                MessageBox.Show("Please specify test path",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            if (backgroundWorker1.IsBusy == false)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            this.StartStopButton.Enabled = false;
            this.StopButton.Enabled = true;
        }

        private void SetMin(int value)
        {
            if (this.TestProgressBar.InvokeRequired)
            {
                SetMinCallback c = new SetMinCallback(SetMin);
                this.Invoke(c, new object[] { value });

            }
            else
            {
                this.TestProgressBar.Minimum = value;
            }
        }

        private void SetMax(int value)
        {
            if (this.TestProgressBar.InvokeRequired)
            {
                SetMaxCallback c = new SetMaxCallback(SetMax);
                this.Invoke(c, new object[] { value });

            }
            else
            {
                this.TestProgressBar.Maximum = value;
            }
        }

        private void SetValue(int value)
        {
            if (this.TestProgressBar.InvokeRequired)
            {
                SetValueCallback c = new SetValueCallback(SetValue);
                this.Invoke(c, new object[] { value });

            }
            else
            {
                this.TestProgressBar.Value= value;
            }
            this.TestProgressBar.Value = value;
        }

        private void ClearList()
        {
            if (this.LogTextBox.InvokeRequired)
            {
                ClearListCallback c = new ClearListCallback(ClearList);
                this.Invoke(c, new object[] { });

            }
            else
            {
                this.LogTextBox.Clear();
            }
        }

        private void AddText(string text)
        {
            if (this.LogTextBox.InvokeRequired)
            {
            AddTextCallback c = new AddTextCallback(AddText);
            this.Invoke(c, new object[] { text });
            }
            else
            {
                this.LogTextBox.AppendText(text);
            }
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // local copies
            Dictionary<string, XmlFile> xmlFilesListCopy;
            List<string> listBoxXmlNamesCopy;

            xmlFilesListCopy = new Dictionary<string, XmlFile>(xmlFilesListReference);
            listBoxXmlNamesCopy = new List<string>(listBoxXmlFilesReference.Items.Cast<string>());


            int tested_elements = listBoxXmlNamesCopy.Count();
            int test_counter = 1;
            SetValue(0);
            SetMin(0);
            SetMax(tested_elements);

            ClearList();
            foreach (XmlFile item in xmlFilesListCopy.Values)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    MessageBox.Show("Automatic test has been stopped",
                    "Test stopped",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    SetValue(0);
                    return;
                }
                if (listBoxXmlNamesCopy.Contains(item.Name))
                {
                    string fileName = file_dir + "\\temp.xml";
                    item.SaveToFile(fileName);
                    AddText(get_log_time() + ": ");
                    AddText(item.Name + " saved to file " + fileName + "\r\n");

                    AddText(get_log_time() + ": ");
                    AddText(batch_dir + " execution started...\r\n");
                    executor.ExecuteScript();
                    AddText(get_log_time() + ": ");
                    AddText(batch_dir + " execution finished...\r\n");
                    SetValue(test_counter++);                    

                }
            }
            this.StartStopButton.Enabled = true;
            this.StopButton.Enabled = false;
            //SetValue(0);

        }

        private void CLearLogButton_Click(object sender, EventArgs e)
        {
            SetValue(0);
            this.LogTextBox.Clear();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if ((xmlFilesListReference.Count > 0) && (listBoxXmlFilesReference.Items.Count > 0))
            {
                backgroundWorker1.CancelAsync();
            }

            this.StartStopButton.Enabled = true;
            this.StopButton.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = batch_dir;
            dialog.Filter = "Batch Files (*.bat)|*.bat|All Files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                batch_dir = dialog.FileName;
                executor = new BatchExecutor(batch_dir);
                textBox1.Text = batch_dir;

                //database.SaveUserItem(1, batch_dir);
            }

        }

        private void TestFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.SelectedPath = file_dir;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file_dir = dialog.SelectedPath;
                //file_dir += "\\temp.xml";
                textBoxDefineTag.Text = file_dir;

                //database.SaveUserItem(0, file_dir);
            }
        }

        private void textBoxDefineTag_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
