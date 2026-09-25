using System;
using System.Windows.Forms;

namespace Ejecucion_Consultas
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CapaVista_Consultas.FrmConsultasSimples("tblConsulta"));
        }
    }
}
