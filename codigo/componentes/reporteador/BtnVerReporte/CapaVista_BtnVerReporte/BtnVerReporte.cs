using System;
using System.ComponentModel;
using System.Windows.Forms;
using CapaControlador_BtnVerReporte;

namespace CapaVista_BtnVerReporte
{
    [ToolboxItem(true)]
    [Description("Boton reutilizable para visualizar reportes de Crystal Reports.")]
    public partial class BtnVerReporte : UserControl
    {
        private ClsControladorBtnVerReporte _Controlador;

        public event EventHandler SolicitarDatosReporte;

        public string RutaReporte { get; set; }

        public string NombreReporte { get; set; }

        public BtnVerReporte()
        {
            InitializeComponent();
            _Controlador = new ClsControladorBtnVerReporte();
            RutaReporte = string.Empty;
            NombreReporte = string.Empty;
        }

        private void ReporteadorBtnVerReporte_Click(object sender, EventArgs e)
        {
            if (SolicitarDatosReporte != null)
            {
                SolicitarDatosReporte(this, EventArgs.Empty);
            }

            string RutaResuelta = _Controlador.BtnVerReporteMetResolverRutaCrystal(
                RutaReporte,
                NombreReporte);

            string MensajeError = _Controlador.BtnVerReporteMetValidarArchivoCrystal(RutaResuelta);

            if (!string.IsNullOrEmpty(MensajeError))
            {
                MessageBox.Show(
                    MensajeError,
                    "Ocurrió un error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            BtnVerReporteProcMostrarVistaPrevia(RutaResuelta);
        }

        private void BtnVerReporteProcMostrarVistaPrevia(string RutaReporte)
        {
            using (FrmVistaPrevia FormularioVistaPrevia = new FrmVistaPrevia(RutaReporte))
            {
                FormularioVistaPrevia.ShowDialog();
            }
        }
    }
}
