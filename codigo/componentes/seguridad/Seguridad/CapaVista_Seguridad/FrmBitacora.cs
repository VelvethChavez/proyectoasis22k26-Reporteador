using CapaControlador_Seguridad.Objetos_de_valor;
using CapaVista_Seguridad.Ayudas;
using CapaControlador_Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_Seguridad
{
    public partial class FrmBitacora : Form
    {
        ClsModeloBitacora controladorBitacora = new ClsModeloBitacora();

        private ClsPermisoAplicacion _MisPermisos;
        private const int ID_MODULO = 4;
        private const int ID_APLICACION = 12;
        public FrmBitacora()
        {
            InitializeComponent();

            this.Load += FrmBitacora_Load;
            this.SeguridadBtnVerBitacora.Click += new System.EventHandler(this.SeguridadBtnVerBitacora_Click);
            this.SeguridadBtnSalir.Click += new System.EventHandler(this.SeguridadBtnSalir_Click);
        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            var MapaBotones = new Dictionary<Control, TipoPermiso>
            {
                { SeguridadBtnVerBitacora, TipoPermiso.Imprimir }
            };

            _MisPermisos = ClsSeguridadFormHelper.SeguridadMetInicializarSeguridad(
                this, ID_MODULO, ID_APLICACION, MapaBotones);

            if (!_MisPermisos.TieneAcceso)
                return;

            CargarBitacora();
        }
        
        private void CargarBitacora()
        {
            try
            {
                var lista = controladorBitacora.SeguridadMetObtenerTodas();
                SeguridadDgvBitacora.DataSource = null;
                SeguridadDgvBitacora.DataSource = lista;

                if (SeguridadDgvBitacora.Columns.Count > 0)
                {
                    SeguridadDgvBitacora.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la bitácora: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeguridadBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SeguridadBtnVerBitacora_Click(object sender, EventArgs e)
        {
            CargarBitacora();
        }
    }
}