using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CapaModelo_BtnReportes.Entidades;
using Microsoft.Reporting.WinForms;

namespace CapaVista_BtnReportes
{
    /// <summary>
    /// Visor del reporte: carga el .rdlc, le asigna los datos y lo muestra.
    /// </summary>
    public partial class FrmVisorReportes : Form
    {
        private readonly ClsSolicitudReporte _Solicitud;

        public FrmVisorReportes(ClsSolicitudReporte Solicitud)
        {
            InitializeComponent();

            _Solicitud = Solicitud;
            Text = string.IsNullOrWhiteSpace(Solicitud.Titulo)
                ? "Reporte" : Solicitud.Titulo;
        }

        private void FrmVisorReportes_Load(object Sender, EventArgs E)
        {
            try
            {
                LocalReport Reporte = ReportViewerBtn.LocalReport;

                Reporte.DataSources.Clear();

                using (FileStream Flujo = new FileStream(
                    _Solicitud.RutaReporte, FileMode.Open,
                    FileAccess.Read, FileShare.ReadWrite))
                {
                    Reporte.LoadReportDefinition(Flujo);
                }

                Reporte.DataSources.Add(new ReportDataSource(
                    _Solicitud.NombreDataSource, _Solicitud.Datos));

                if (_Solicitud.Parametros != null &&
                    _Solicitud.Parametros.Count > 0)
                {
                    List<ReportParameter> Parametros =
                        new List<ReportParameter>();

                    foreach (KeyValuePair<string, string> P in
                        _Solicitud.Parametros)
                    {
                        Parametros.Add(new ReportParameter(P.Key, P.Value));
                    }

                    Reporte.SetParameters(Parametros);
                }

                ReportViewerBtn.RefreshReport();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(
                    "Error al cargar el reporte: " + Ex.Message,
                    "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
