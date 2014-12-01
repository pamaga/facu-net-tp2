using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI.Desktop
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
            Principal app = new Principal();
            try {
                Application.Run(app);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
             
            }
        }
    }
}
