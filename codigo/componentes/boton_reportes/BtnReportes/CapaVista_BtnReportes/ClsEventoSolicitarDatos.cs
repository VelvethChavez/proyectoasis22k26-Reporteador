using System;
using System.Collections.Generic;

namespace CapaVista_BtnReportes
{
    /// <summary>
    /// Argumentos del evento SolicitarDatos: el formulario que usa el boton
    /// asigna aqui los datos (y parametros) justo antes de abrir el reporte.
    /// </summary>
    public class ClsEventoSolicitarDatos : EventArgs
    {
        /// <summary>
        /// Ruta del .rdlc. Llega con el valor de la propiedad RutaReporte;
        /// se puede cambiar para abrir un reporte distinto en cada clic.
        /// </summary>
        public string RutaReporte { get; set; }

        /// <summary>DataSet del .rdlc (vacio = el primero del reporte).</summary>
        public string NombreDataSource { get; set; }

        /// <summary>Titulo de la ventana del visor.</summary>
        public string Titulo { get; set; }

        /// <summary>Lista de objetos o DataTable que llena el reporte.</summary>
        public object Datos { get; set; }

        /// <summary>Parametros del reporte (nombre, valor).</summary>
        public IDictionary<string, string> Parametros { get; private set; }

        public ClsEventoSolicitarDatos()
        {
            Parametros = new Dictionary<string, string>();
        }
    }
}
