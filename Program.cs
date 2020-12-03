using System;
using System.Windows.Forms;

namespace Regalia_Obfuscator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new Window());
        }
    }
}
