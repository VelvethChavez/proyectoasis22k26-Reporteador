using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaControlador_Seguridad;
using CapaControlador_Seguridad.Modelos_de_controladores;

namespace CapaVista_Navegador
{
    // Formulario de ejemplo que usa el Navegador. Es un Form normal: el control Navegador (navegador1)
    // se arrastró desde la caja de herramientas, igual que se haría en cualquier otro formulario.
    // Una sola línea lo configura: tabla, IdModulo e IdAplicacion (con los que Seguridad busca los
    // permisos del usuario en sesión). La ayuda y el usuario no se parametrizan.
    //
    // EJEMPLO BOTON REPORTES: btnReportes1 (CapaVista_BtnReportes.dll) se arrastró igual que el Navegador.
    // Aquí sólo se elige el reporte de Seguridad en el combo y, al hacer clic en el botón, el evento
    // SolicitarDatos entrega el .rdlc y los datos (el mismo método del controlador que usa Seguridad).
    public partial class FrmPrincipal : Form
    {
        // Reporte de Seguridad: título, .rdlc (copiado a la carpeta Reportes de la salida) y cómo traer los datos.
        private class ReporteSeguridad
        {
            public string Titulo;
            public string Rdlc;
            public Func<object> Datos;
            public override string ToString() { return Titulo; }
        }

        public FrmPrincipal()
        {
            InitializeComponent();

            navegador1.NavegadorMetConfigurar("tblusuario", 4, 5);

            cmbReporte.DataSource = new List<ReporteSeguridad>
            {
                new ReporteSeguridad { Titulo = "Bitácora",                        Rdlc = @"Reportes\RpReporteBitacora.rdlc",                       Datos = () => new ClsModeloBitacora().SeguridadMetObtenerTodas() },
                new ReporteSeguridad { Titulo = "Mantenimiento de usuarios",       Rdlc = @"Reportes\RpReporteMantenimientoUsuario.rdlc",           Datos = () => new ClsModeloUsuario().SeguridadMetObtenerTodos() },
                new ReporteSeguridad { Titulo = "Mantenimiento de perfiles",       Rdlc = @"Reportes\RpReporteMantenimientoPerfil.rdlc",            Datos = () => new ClsModeloRoles().SeguridadMetObtenerTodos() },
                new ReporteSeguridad { Titulo = "Mantenimiento de empleados",      Rdlc = @"Reportes\RpReporteMantenimientoEmpleado.rdlc",          Datos = () => new ClsModeloEmpleado().SeguridadMetObtenerTodos() },
                new ReporteSeguridad { Titulo = "Mantenimiento de aplicaciones",   Rdlc = @"Reportes\RpReporteMantenimientoAplicacion.rdlc",        Datos = () => new ClsModeloMantenimientoApp().SeguridadMetObtenerTodos() },
                new ReporteSeguridad { Titulo = "Mantenimiento de módulos",        Rdlc = @"Reportes\RpReporteMantenimientoModulo.rdlc",            Datos = () => new ClsModeloModulo().SeguridadMetObtenerModulosReporte() },
                new ReporteSeguridad { Titulo = "Asignación de perfiles",          Rdlc = @"Reportes\RpReporteAsignacionPerfiles.rdlc",             Datos = () => new ClsModeloAsignacionPerfiles().SeguridadMetObtenerTodos() },
                new ReporteSeguridad { Titulo = "Asignación de aplicación a perfil", Rdlc = @"Reportes\RpReporteAsigAppPerf.rdlc",                   Datos = () => new ClsModeloAsigAppPerf().SeguridadMetObtenerTodos() },
                new ReporteSeguridad { Titulo = "Asignación de aplicación a usuario", Rdlc = @"Reportes\RpReporteAsignacionAplicacionUsuario.rdlc",  Datos = () => new ClsModeloAsigAppUsuario().SeguridadMetObtenerTodos() },
            };
        }

        private void btnReportes1_SolicitarDatos(object sender, CapaVista_BtnReportes.ClsEventoSolicitarDatos e)
        {
            ReporteSeguridad reporte = (ReporteSeguridad)cmbReporte.SelectedItem;

            e.RutaReporte = reporte.Rdlc;
            e.Titulo = "Reporte de " + reporte.Titulo;
            e.Datos = reporte.Datos();
        }
    }
}
