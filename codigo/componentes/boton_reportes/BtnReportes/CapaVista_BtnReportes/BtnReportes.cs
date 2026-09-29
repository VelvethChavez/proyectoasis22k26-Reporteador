using System;
using System.ComponentModel;
using System.Windows.Forms;
using CapaControlador_BtnReportes;
using CapaModelo_BtnReportes.Entidades;

namespace CapaVista_BtnReportes
{
    /// <summary>
    /// Boton reutilizable que abre el visor de reportes (RDLC).
    /// Se arrastra al formulario, se configura RutaReporte y se entregan los
    /// datos con la propiedad Datos o con el evento SolicitarDatos.
    /// </summary>
    [ToolboxItem(true)]
    [DefaultEvent("SolicitarDatos")]
    [Description("Boton que abre el visor de reportes RDLC.")]
    public partial class BtnReportes : UserControl
    {
        private readonly ClsControladorBtnReportes _Controlador;

        public BtnReportes()
        {
            InitializeComponent();

            _Controlador = new ClsControladorBtnReportes();

            BtnAccionReportes.Click += BtnAccionReportes_Click;
        }

        /// <summary>Se dispara al hacer clic, antes de abrir el reporte.</summary>
        [Category("Reportes")]
        [Description("Permite entregar los datos y parametros del reporte al hacer clic.")]
        public event EventHandler<ClsEventoSolicitarDatos> SolicitarDatos;

        [Category("Reportes")]
        [Description("Ruta del archivo .rdlc (absoluta, o relativa al ejecutable / carpeta Reportes).")]
        [DefaultValue("")]
        public string RutaReporte { get; set; }

        [Category("Reportes")]
        [Description("Nombre del DataSet del .rdlc. Vacio = el primero que defina el reporte.")]
        [DefaultValue("")]
        public string NombreDataSource { get; set; }

        [Category("Reportes")]
        [Description("Titulo de la ventana del visor.")]
        [DefaultValue("Reporte")]
        public string TituloReporte { get; set; } = "Reporte";

        [Category("Reportes")]
        [Description("Abrir el visor como ventana modal.")]
        [DefaultValue(false)]
        public bool MostrarModal { get; set; }

        /// <summary>Datos fijos del reporte. Si se atiende SolicitarDatos, este evento los reemplaza.</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Datos { get; set; }

        /// <summary>Abre el reporte por codigo, igual que el clic del boton.</summary>
        public void AbrirReporte()
        {
            BtnReportesMetAbrirReporte();
        }

        private void BtnAccionReportes_Click(object Sender, EventArgs E)
        {
            BtnReportesMetAbrirReporte();
        }

        private void BtnReportesMetAbrirReporte()
        {
            try
            {
                ClsSolicitudReporte Solicitud = new ClsSolicitudReporte
                {
                    RutaReporte = RutaReporte,
                    NombreDataSource = NombreDataSource,
                    Titulo = TituloReporte,
                    Datos = Datos
                };

                if (SolicitarDatos != null)
                {
                    ClsEventoSolicitarDatos Args = new ClsEventoSolicitarDatos
                    {
                        Datos = Datos,
                        RutaReporte = RutaReporte,
                        NombreDataSource = NombreDataSource,
                        Titulo = TituloReporte
                    };

                    SolicitarDatos(this, Args);

                    Solicitud.RutaReporte = Args.RutaReporte;
                    Solicitud.NombreDataSource = Args.NombreDataSource;
                    Solicitud.Titulo = Args.Titulo;
                    Solicitud.Datos = Args.Datos;
                    Solicitud.Parametros = Args.Parametros;
                }

                if (!_Controlador.BtnReportesMetPrepararSolicitud(
                    Solicitud, out string Mensaje))
                {
                    MessageBox.Show(Mensaje, "Reportes",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FrmVisorReportes Visor = new FrmVisorReportes(Solicitud);

                if (MostrarModal)
                {
                    Visor.ShowDialog(FindForm());
                    Visor.Dispose();
                }
                else
                {
                    Visor.FormClosed += (S, Ev) => Visor.Dispose();
                    Visor.Show();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(
                    "Ocurrio un error al abrir el reporte: " + Ex.Message,
                    "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
