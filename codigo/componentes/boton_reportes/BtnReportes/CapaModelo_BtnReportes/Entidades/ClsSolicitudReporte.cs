using System.Collections.Generic;

namespace CapaModelo_BtnReportes.Entidades
{
    /// <summary>
    /// Datos necesarios para abrir un reporte RDLC en el visor.
    /// </summary>
    public class ClsSolicitudReporte
    {
        /// <summary>Ruta (absoluta o relativa) del archivo .rdlc.</summary>
        public string RutaReporte { get; set; }

        /// <summary>
        /// Nombre del DataSet del RDLC que recibe los datos.
        /// Si queda vacio se toma el primer DataSet definido en el .rdlc.
        /// </summary>
        public string NombreDataSource { get; set; }

        /// <summary>Titulo de la ventana del visor.</summary>
        public string Titulo { get; set; }

        /// <summary>Lista de objetos (o DataTable) que llena el reporte.</summary>
        public object Datos { get; set; }

        /// <summary>Parametros del reporte (nombre, valor).</summary>
        public IDictionary<string, string> Parametros { get; set; }

        public ClsSolicitudReporte()
        {
            Parametros = new Dictionary<string, string>();
        }
    }
}
