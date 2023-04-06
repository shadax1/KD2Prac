using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TestKD2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] pname = Process.GetProcessesByName("koumajou2");
            if (pname.Length == 0)
            {
                try
                {
                    Process.Start("koumajou2.exe");
                }
                catch (Exception)
                {
                    MessageBox.Show("koumajou2.exe wasn't found, make sure TestKD2.exe and threadstack.exe are both in the same location as koumajou2.exe.", "Location error");
                    Environment.Exit(1);
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestKD2());
        }
    }
}
