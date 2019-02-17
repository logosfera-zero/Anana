using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Globalization;
using System.Threading;

namespace Cliente_FFMPEG
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string lenguaje = ConfigurationManager.AppSettings["lenguaje"].ToString();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lenguaje);
            Application.Run(new Form1());
        }
    }
}
