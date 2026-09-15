using System;
using System.IO;
using CapaModelo_BtnVerReporte.Repositorios;

namespace CapaControlador_BtnVerReporte
{
    public class ClsControladorBtnVerReporte
    {
        private ClsRepositorioBtnVerReporte _RepositorioBtnVerReporte;

        public ClsControladorBtnVerReporte()
        {
            _RepositorioBtnVerReporte = new ClsRepositorioBtnVerReporte();
        }

        public string BtnVerReporteMetResolverRutaCrystal(string RutaReporte, string NombreReporte)
        {
            string RutaLimpia = BtnVerReporteMetNormalizarTexto(RutaReporte);
            string NombreLimpio = BtnVerReporteMetNormalizarTexto(NombreReporte);

            if (BtnVerReporteFuncEsRutaArchivoCrystal(RutaLimpia))
            {
                return RutaLimpia;
            }

            if (Directory.Exists(RutaLimpia) && !string.IsNullOrWhiteSpace(NombreLimpio))
            {
                string RutaCombinada = BtnVerReporteMetCombinarRutaCarpeta(RutaLimpia, NombreLimpio);

                if (BtnVerReporteFuncEsRutaArchivoCrystal(RutaCombinada))
                {
                    return RutaCombinada;
                }
            }

            if (!string.IsNullOrWhiteSpace(NombreLimpio))
            {
                string RutaEncontrada = _RepositorioBtnVerReporte.BtnVerReporteFuncObtenerRutaPorNombre(NombreLimpio);

                if (BtnVerReporteFuncEsRutaArchivoCrystal(RutaEncontrada))
                {
                    return RutaEncontrada;
                }
            }

            return null;
        }

        public string BtnVerReporteMetValidarArchivoCrystal(string RutaReporte)
        {
            if (string.IsNullOrWhiteSpace(RutaReporte))
            {
                return "Debe indicar la ruta o el nombre de un reporte Crystal Reports (.rpt).";
            }

            if (!BtnVerReporteFuncEsExtensionCrystal(RutaReporte))
            {
                return "El archivo seleccionado no es un reporte de Crystal Reports (.rpt).";
            }

            if (!File.Exists(RutaReporte))
            {
                return "No se encontro el archivo del reporte en la ruta indicada.";
            }

            return null;
        }

        private string BtnVerReporteMetNormalizarTexto(string Valor)
        {
            if (string.IsNullOrWhiteSpace(Valor))
            {
                return string.Empty;
            }

            string ValorLimpio = Valor.Trim();

            if (ValorLimpio.Equals("Ubicacion del archivo", StringComparison.OrdinalIgnoreCase) ||
                ValorLimpio.Equals("Colocar el nombre del reporte", StringComparison.OrdinalIgnoreCase))
            {
                return string.Empty;
            }

            return ValorLimpio;
        }

        private bool BtnVerReporteFuncEsRutaArchivoCrystal(string RutaReporte)
        {
            return !string.IsNullOrWhiteSpace(RutaReporte) &&
                   BtnVerReporteFuncEsExtensionCrystal(RutaReporte) &&
                   File.Exists(RutaReporte);
        }

        private bool BtnVerReporteFuncEsExtensionCrystal(string RutaReporte)
        {
            return Path.GetExtension(RutaReporte)
                .Equals(".rpt", StringComparison.OrdinalIgnoreCase);
        }

        private string BtnVerReporteMetCombinarRutaCarpeta(string RutaCarpeta, string NombreReporte)
        {
            string NombreArchivo = NombreReporte;

            if (!Path.HasExtension(NombreArchivo))
            {
                NombreArchivo = NombreArchivo + ".rpt";
            }

            return Path.Combine(RutaCarpeta, NombreArchivo);
        }
    }
}
