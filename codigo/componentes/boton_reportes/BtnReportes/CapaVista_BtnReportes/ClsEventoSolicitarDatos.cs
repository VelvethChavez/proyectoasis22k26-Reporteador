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
