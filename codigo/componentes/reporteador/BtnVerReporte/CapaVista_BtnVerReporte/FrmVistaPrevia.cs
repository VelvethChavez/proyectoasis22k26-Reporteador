using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace CapaVista_BtnVerReporte
{
    public partial class FrmVistaPrevia : Form
    {
        private ReportDocument _DocumentoReporte;
        private string _RutaReporte;

        public FrmVistaPrevia(string RutaReporte)
        {
            _RutaReporte = RutaReporte;
            InitializeComponent();
        }

        private void FrmVistaPrevia_Load(object sender, EventArgs e)
        {
            try
            {
                _DocumentoReporte = new ReportDocument();
                _DocumentoReporte.Load(_RutaReporte);
                ReporteadorCrvVistaPrevia.ReportSource = _DocumentoReporte;
                ReporteadorCrvVistaPrevia.Refresh();
            }
            catch (Exception ExcepcionCarga)
            {
                MessageBox.Show(
                    "No fue posible abrir el reporte de Crystal Reports. Verifique que SAP Crystal Reports for Visual Studio este instalado y que el archivo .rpt exista.\n" +
                    ExcepcionCarga.Message,
                    "Ocurrió un error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
            }
        }

        private void FrmVistaPrevia_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_DocumentoReporte != null)
            {
                _DocumentoReporte.Close();
                _DocumentoReporte.Dispose();
                _DocumentoReporte = null;
            }
        }
    }
}
