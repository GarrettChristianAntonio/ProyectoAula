using Data;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
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
            IDataAccess dataAccess = new DataAccess();
            ILogic logic = new Logic(dataAccess);

            Application.Run(new Login(logic));
        }
    }
}
