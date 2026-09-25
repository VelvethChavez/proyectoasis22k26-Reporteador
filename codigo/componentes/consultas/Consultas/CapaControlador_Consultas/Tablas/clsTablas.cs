using System.Data;
using CapaModelo_Consultas;

namespace CapaControlador_Consultas
{
    public class ClsTablas
    {
        private readonly ClsSentenciasTablas _Sentencias =
            new ClsSentenciasTablas();

        public DataTable ConsultasFuncLlenarTabla(
            string NombreTabla,
            int Pagina,
            int RegistrosPorPagina)
        {
            return _Sentencias.ConsultasFuncObtenerTabla(
                NombreTabla,
                Pagina,
                RegistrosPorPagina);
        }

        public DataTable ConsultasFuncObtenerTablas()
        {
            return _Sentencias.ConsultasFuncObtenerTablas();
        }

        public int ConsultasFuncContarRegistros(string NombreTabla)
        {
            return _Sentencias.ConsultasFuncContarRegistros(NombreTabla);
        }
    }
}