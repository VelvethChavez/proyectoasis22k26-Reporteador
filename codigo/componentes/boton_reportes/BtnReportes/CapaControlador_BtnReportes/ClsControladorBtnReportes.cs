using System;
using System.Collections;
using System.Data;
using System.Linq;
using CapaModelo_BtnReportes.Entidades;
using CapaModelo_BtnReportes.Repositorios;

namespace CapaControlador_BtnReportes
{
    /// <summary>
    /// Valida la solicitud del boton y la deja lista para el visor.
    /// </summary>
    public class ClsControladorBtnReportes
    {
        private readonly ClsRepositorioBtnReportes _Repositorio;

        public ClsControladorBtnReportes()
        {
            _Repositorio = new ClsRepositorioBtnReportes();
        }

        /// <summary>
        /// Comprueba ruta, extension y datos; resuelve la ruta real del .rdlc
        /// y el nombre del DataSet. Devuelve false con el motivo en Mensaje.
        /// </summary>
        public bool BtnReportesMetPrepararSolicitud(
            ClsSolicitudReporte Solicitud,
            out string Mensaje)
        {
            Mensaje = string.Empty;

            if (Solicitud == null ||
                string.IsNullOrWhiteSpace(Solicitud.RutaReporte))
            {
                Mensaje = "Debe indicar la ruta del reporte " +
                    "(propiedad RutaReporte).";
                return false;
            }

            if (!Solicitud.RutaReporte.EndsWith(
                ".rdlc", StringComparison.OrdinalIgnoreCase))
            {
                Mensaje = "El archivo del reporte debe tener " +
                    "extension .rdlc.";
                return false;
            }

            string Ruta = _Repositorio
                .BtnReportesMetLocalizarArchivo(Solicitud.RutaReporte);

            if (Ruta == null)
            {
                Mensaje = "No se encontro el archivo del reporte: " +
                    Solicitud.RutaReporte + "\r\nVerifique que el .rdlc " +
                    "se copie al directorio de salida.";
                return false;
            }

            Solicitud.RutaReporte = Ruta;

            if (Solicitud.Datos == null)
            {
                Mensaje = "No se recibieron datos para el reporte.\r\n" +
                    "Asigne la propiedad Datos o atienda el evento " +
                    "SolicitarDatos.";
                return false;
            }

            if (!(Solicitud.Datos is IEnumerable) &&
                !(Solicitud.Datos is DataTable))
            {
                Mensaje = "Los datos del reporte deben ser una lista " +
                    "(IEnumerable) o un DataTable.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Solicitud.NombreDataSource))
            {
                string Primero;

                try
                {
                    Primero = _Repositorio
                        .BtnReportesMetObtenerDataSets(Ruta)
                        .FirstOrDefault();
                }
                catch (Exception)
                {
                    Mensaje = "El archivo .rdlc no es valido.";
                    return false;
                }

                if (Primero == null)
                {
                    Mensaje = "El reporte no define ningun DataSet.";
                    return false;
                }

                Solicitud.NombreDataSource = Primero;
            }

            return true;
        }
    }
}
