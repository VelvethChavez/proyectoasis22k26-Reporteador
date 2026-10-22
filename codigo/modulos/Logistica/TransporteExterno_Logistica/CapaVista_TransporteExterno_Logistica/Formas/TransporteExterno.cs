using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_TransporteExterno_Logistica.Formas
{
    public partial class TransporteExterno : Form
    {
        public TransporteExterno()
        {
            InitializeComponent();
        }

        private void LogisticaBtnRegistroTransporte_Click(object sender, EventArgs e)
        {
            RegistroTransporteExterno frm = new RegistroTransporteExterno();
            frm.ShowDialog();
        }

        private void LogisticaBtnRutaSeguimiento_Click(object sender, EventArgs e)
        {
            RutaYSeguimiento frm = new RutaYSeguimiento();
            frm.ShowDialog();
        }

        private void LogisticaBtnProductosCarga_Click(object sender, EventArgs e)
        {
            ProductosATrasladar frm = new ProductosATrasladar();
            frm.ShowDialog();
        }

        private void LogisticaBtnCostosPagos_Click(object sender, EventArgs e)
        {
            CostosYPagosDelServicio frm = new CostosYPagosDelServicio();
            frm.ShowDialog();
        }

        private void LogisticaBtnIncidenciasEHistorial_Click(object sender, EventArgs e)
        {
            IncidenciasEHistorial frm = new IncidenciasEHistorial();
            frm.ShowDialog();
        }

        private void LogisticaBtnListadoTransporteExterno_Click(object sender, EventArgs e)
        {
            ListadoTransporteExterno frm = new ListadoTransporteExterno();
            frm.ShowDialog();
        }
    }
}