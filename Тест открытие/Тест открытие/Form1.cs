using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Тест_открытие
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("devenv.exe");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            auto_run(true,Assembly.GetExecutingAssembly().Location);
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe");
        }
        
        private bool auto_run(bool auto_Run,string path)
        {
            const string name = "Автозапуск";

            string Exepath = path;

            RegistryKey reg;

            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {


                if (auto_Run)
                {
                    reg.SetValue(name, Exepath);
                }
                else
                {
                    reg.DeleteValue(name);
                }
                reg.Flush();
                reg.Close();
            } 
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
