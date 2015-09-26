using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiaAgentInstaller2
{
    public partial class UncompatibleSoftware : Form
    {
        List<KeyValuePair<string, string>> ProcessList = new List<KeyValuePair<string, string>>();

        private string CheckingString;
        private string UncompatibleMessage;
        private string UncompatibleMessageReboot;
        private string UncompatibleCaption;

        public UncompatibleSoftware()
        {
            InitializeComponent();
            InitializeLanguage();
            InitializeProcessList();
            InitializeProgressBar();
            InitializeProcessCheck();
        }

        private void InitializeLanguage()
        {
            CheckingString = "Checking {0}";
            UncompatibleCaption = "Incompatible process detected: {0}";
            UncompatibleMessage = "{0} is running on your system. Please close {0}{1} and restart installer";
            UncompatibleMessageReboot = ", reboot your system";
        }

        private void InitializeProcessCheck()
        {
            int i = 0;
            for (i = 0; i < ProcessList.Count; i++)
            {
                label1.Text = String.Format(CheckingString, ProcessList[i].Value);
                this.UncompatibleApp(ProcessList[i].Key, ProcessList[i].Value, false);
            }
        }
        
        private void UncompatibleApp(string process_name, string Caption, bool needs_reboot)
        {
            Process[] pname = Process.GetProcessesByName(process_name);
            if (pname.Length != 0)
            {
                MessageBox.Show(String.Format(
                    this.UncompatibleMessage, Caption, needs_reboot ? this.UncompatibleMessageReboot : ""),
                    String.Format(this.UncompatibleCaption, Caption),
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
        }

        private void InitializeProgressBar()
        {
            progressBarProcess.Maximum = ProcessList.Count;
            progressBarProcess.Value = 0;
        }

        private void InitializeProcessList()
        {
            this.addProcess("DF6Serv", "Deep Freeze");
        }

        private void addProcess(string name, string label)
        {
            this.ProcessList.Add(new KeyValuePair<string, string>(name, label));
        }
    }
}
