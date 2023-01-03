using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace JSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string processName = Process.GetCurrentProcess().ProcessName;
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length > 1)
            {
                MessageBox.Show("程序已打开，请勿重复打开！", "重复打开");
                Environment.Exit(1);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WaitForm waitForm = null;
            new Task(() =>
            {
                waitForm = new WaitForm();
                Application.Run(waitForm);
            }).Start();
            SysController controller = new SysController();
            MainWindow win = new MainWindow(controller);
            waitForm.Invoke(new Action(() => { waitForm.Close(); }));
            Application.Run(win);
        }
    }
}
