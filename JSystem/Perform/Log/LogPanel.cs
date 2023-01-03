using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JSystem.Perform
{
    public partial class LogPanel : UserControl
    {
        LogManager _manager;

        public LogPanel()
        {
            InitializeComponent();
        }

        public void Init(LogManager manager)
        {
            _manager = manager;
            manager.OnAddLog = ShowLog;
        }

        public void ShowLog(string msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { ShowLog(msg); }));
            }
            else
            {
                try
                {
                    TB_Log.AppendText(msg);
                }
                catch { }
            }
        }

        private void Tab_Log_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tab_Log.SelectedIndex == 1)
            {
                TB_Error_Log.Clear();
                string fileDir = AppDomain.CurrentDomain.BaseDirectory + "JLog";
                foreach (string subDir in Directory.GetDirectories(fileDir))
                {
                    string[] arrayStr = subDir.Split('\\');
                    string filePath = subDir + "\\Error.log";
                    if (!File.Exists(filePath) || arrayStr[arrayStr.Length - 1] == DateTime.Now.ToString("yyyy-MM-dd"))
                        continue;
                    StreamReader sr = new StreamReader(filePath);
                    string allStr = sr.ReadToEnd();
                    string[] arrayStr1 = Regex.Split(allStr, "\r\n");
                    foreach (string str in arrayStr1)
                    {
                        string[] arrayStr2 = str.Split('\t');
                        TB_Error_Log.AppendText(arrayStr2[0] + " " + arrayStr2[arrayStr2.Length - 1] + "\r\n");
                    }
                }
            }
        }
    }
}
