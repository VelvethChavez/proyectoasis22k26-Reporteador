using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CapaControlador_Contabilidad;
using CapaContralador_Enlace_Logistica;

namespace CapaVista_Enlace_Logistica
{
    // Formulario construido por código: no requiere archivo .Designer.cs.
    public class FrmPolizasLogistica : Form
    {
        
        private const string CODIGO_MODULO = "MOD-LOGIS";
        
        private const int ID_PAIS = 1;

        private readonly ClsIntegracionContabilidadControlador _controlador = new ClsIntegracionContabilidadControlador();
        private readonly List<ClsModeloCuentaPolizaContabilidad> _cuentas = new List<ClsModeloCuentaPolizaContabilidad>();
        private readonly List<LineaVista> _lineas = new List<LineaVista>();
        
        private readonly Color _principal = ColorTranslator.FromHtml("#6A2C12");
        private readonly Color _acento = ColorTranslator.FromHtml("#D2632E");
        private readonly Color _etiquetas = ColorTranslator.FromHtml("#3E8A84");
        private readonly Color _fondo = ColorTranslator.FromHtml("#FBF6F2");
        private readonly Color _botones = ColorTranslator.FromHtml("#F2D8C5");
        private DateTimePicker dtFecha;
        private TextBox txtDocumento, txtDescripcion, txtDebe, txtHaber, txtDetalle;
        private ComboBox cmbCuenta;
        private DataGridView dgv;
        private Label lblDebe, lblHaber, lblDiferencia, lblResultado;
        private Button btnEnviar, btnConsultar;

        private class LineaVista
        {
            public string CodigoCuenta { get; set; }
            public string NombreCuenta { get; set; }
            public string Descripcion { get; set; }
            public decimal Debe { get; set; }
            public decimal Haber { get; set; }
        }

        public FrmPolizasLogistica()
        {
            ConstruirInterfaz();
            Load += (s, e) => CargarCuentas();
        }

        private Label Etiqueta(string texto, int x, int y, int ancho = 150)
        {
            return new Label
            {
                Text = texto,
                Left = x,
                Top = y,
                Width = ancho,
                Height = 23,
                ForeColor = _etiquetas,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
        }

        private Button Boton(string texto, int x, int y, int ancho, EventHandler click, bool principal = false)
        {
            var b = new Button
            {
                Text = texto,
                Left = x,
                Top = y,
                Width = ancho,
                Height = 38,
                BackColor = principal ? _acento : _botones,
                ForeColor = principal ? Color.White : _principal,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            b.FlatAppearance.BorderColor = _principal;
            b.FlatAppearance.BorderSize = 1;
            b.Click += click;
            return b;
        }

        private void ConstruirInterfaz()
        {
            Text = "Pólizas de Logística";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1120, 730);
            MinimumSize = new Size(1140, 770);
            AutoScroll = true;
            Font = new Font("Segoe UI", 9F);
            BackColor = _fondo;

            var encabezado = new Panel
            {
                Left = 12,
                Top = 12,
                Width = 1094,
                Height = 104,
                BackColor = _principal,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            Controls.Add(encabezado);
            var titulo = new Label
            {
                Text = "PÓLIZAS DE LOGÍSTICA",
                Left = 28,
                Top = 18,
                Width = 760,
                Height = 40,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 21F, FontStyle.Bold | FontStyle.Italic)
            };
            encabezado.Controls.Add(titulo);
            encabezado.Controls.Add(new Label
            {
                Text = "Registro y envío de movimientos contables a Contabilidad",
                Left = 30,
                Top = 62,
                Width = 840,
                Height = 26,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F)
            });
            // Imagen opcional: copiar Imagenes/EncabezadoLogistica.png a la salida y activar si se desea.

            var datos = new GroupBox
            {
                Text = "Datos generales",
                Left = 16,
                Top = 132,
                Width = 1088,
                Height = 126,
                ForeColor = _etiquetas,
                BackColor = _fondo,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            Controls.Add(datos);
            datos.Controls.Add(Etiqueta("Fecha", 20, 31));
            dtFecha = new DateTimePicker { Left = 20, Top = 57, Width = 190, Format = DateTimePickerFormat.Short };
            datos.Controls.Add(dtFecha);
            datos.Controls.Add(Etiqueta("Documento de origen", 235, 31, 220));
            txtDocumento = new TextBox { Left = 235, Top = 57, Width = 245, MaxLength = 30 };
            datos.Controls.Add(txtDocumento);
            datos.Controls.Add(Etiqueta("Descripción", 505, 31));
            txtDescripcion = new TextBox { Left = 505, Top = 57, Width = 560, MaxLength = 255 };
            datos.Controls.Add(txtDescripcion);

            var detalle = new GroupBox
            {
                Text = "Detalle de la póliza",
                Left = 16,
                Top = 270,
                Width = 1088,
                Height = 350,
                ForeColor = _etiquetas,
                BackColor = _fondo,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            Controls.Add(detalle);
            detalle.Controls.Add(Etiqueta("Cuenta contable", 18, 29));
            cmbCuenta = new ComboBox
            {
                Left = 18,
                Top = 55,
                Width = 310,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            detalle.Controls.Add(cmbCuenta);
            detalle.Controls.Add(Etiqueta("Debe (Q)", 348, 29, 100));
            txtDebe = new TextBox { Left = 348, Top = 55, Width = 125, Text = "0.00" };
            detalle.Controls.Add(txtDebe);
            detalle.Controls.Add(Etiqueta("Haber (Q)", 493, 29, 100));
            txtHaber = new TextBox { Left = 493, Top = 55, Width = 125, Text = "0.00" };
            detalle.Controls.Add(txtHaber);
            detalle.Controls.Add(Etiqueta("Concepto de línea", 635, 29, 175));
            txtDetalle = new TextBox { Left = 635, Top = 55, Width = 235, MaxLength = 255 };
            detalle.Controls.Add(txtDetalle);
            detalle.Controls.Add(Boton("+ Agregar", 890, 49, 175, (s, e) => AgregarLinea(), true));

            dgv = new DataGridView
            {
                Left = 18,
                Top = 106,
                Width = 1048,
                Height = 175,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                RowHeadersVisible = false
            };
            dgv.ColumnHeadersDefaultCellStyle.BackColor = _principal;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = _principal;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = _principal;
            dgv.DefaultCellStyle.SelectionBackColor = _etiquetas;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = _fondo;
            dgv.GridColor = _botones;
            dgv.EnableHeadersVisualStyles = false;
            dgv.Columns.Add("Codigo", "Código de cuenta");
            dgv.Columns.Add("Nombre", "Nombre de la cuenta");
            dgv.Columns.Add("Concepto", "Concepto");
            dgv.Columns.Add("Debe", "Debe (Q)");
            dgv.Columns.Add("Haber", "Haber (Q)");
            dgv.Columns[0].FillWeight = 17;
            dgv.Columns[1].FillWeight = 28;
            dgv.Columns[2].FillWeight = 30;
            dgv.Columns[3].FillWeight = 12;
            dgv.Columns[4].FillWeight = 13;
            detalle.Controls.Add(dgv);
            detalle.Controls.Add(Boton("Eliminar línea", 18, 293, 145, (s, e) => EliminarLinea()));
            lblDebe = Etiqueta("Debe: Q 0.00", 485, 302, 175);
            lblHaber = Etiqueta("Haber: Q 0.00", 670, 302, 175);
            lblDiferencia = Etiqueta("Diferencia: Q 0.00", 850, 302, 205);
            detalle.Controls.Add(lblDebe); detalle.Controls.Add(lblHaber); detalle.Controls.Add(lblDiferencia);

            var resultado = new GroupBox
            {
                Text = "Resultado de Contabilidad",
                Left = 16,
                Top = 630,
                Width = 1088,
                Height = 83,
                ForeColor = _etiquetas,
                BackColor = _fondo,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            Controls.Add(resultado);
            lblResultado = new Label
            {
                Left = 18,
                Top = 28,
                Width = 610,
                Height = 42,
                Text = "Sin enviar",
                ForeColor = _principal,
                AutoEllipsis = true
            };
            resultado.Controls.Add(lblResultado);
            btnConsultar = Boton("Consultar estado", 640, 27, 145, (s, e) => ConsultarEstado());
            resultado.Controls.Add(btnConsultar);
            resultado.Controls.Add(Boton("Limpiar", 793, 27, 100, (s, e) => Limpiar()));
            btnEnviar = Boton("Enviar a Contabilidad", 901, 27, 170, (s, e) => Enviar(), true);
            resultado.Controls.Add(btnEnviar);
        }

        private void CargarCuentas()
        {
            if (CODIGO_MODULO == "CONFIGURAR_MODULO_LOGISTICA")
            {
                lblResultado.Text = "Configure CODIGO_MODULO e ID_PAIS antes de usar el formulario.";
                btnEnviar.Enabled = false;
                return;
            }
            try
            {
                _cuentas.Clear();
                _cuentas.AddRange(_controlador.ObtenerCuentas(CODIGO_MODULO, ID_PAIS));
                cmbCuenta.DataSource = null;
                cmbCuenta.DataSource = _cuentas;
                cmbCuenta.DisplayMember = "Nombre";
                cmbCuenta.ValueMember = "Codigo";
                btnEnviar.Enabled = _cuentas.Count > 0;
                if (_cuentas.Count == 0) lblResultado.Text = "No hay cuentas permitidas para este módulo/país.";
            }
            catch (Exception ex)
            {
                btnEnviar.Enabled = false;
                MessageBox.Show("No fue posible consultar cuentas: " + ex.Message,
                    "Contabilidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool LeerImporte(string valor, out decimal importe)
        {
            return decimal.TryParse(valor, NumberStyles.Number, CultureInfo.CurrentCulture, out importe)
                || decimal.TryParse(valor, NumberStyles.Number, CultureInfo.InvariantCulture, out importe);
        }

        private void AgregarLinea()
        {
            var cuenta = cmbCuenta.SelectedItem as ClsModeloCuentaPolizaContabilidad;
            if (cuenta == null) { MessageBox.Show("Seleccione una cuenta permitida."); return; }
            decimal debe, haber;
            if (!LeerImporte(txtDebe.Text, out debe) || !LeerImporte(txtHaber.Text, out haber)
                || debe < 0 || haber < 0 || (debe > 0) == (haber > 0))
            { MessageBox.Show("Ingrese un importe positivo en Debe o Haber, no en ambos."); return; }
            _lineas.Add(new LineaVista
            {
                CodigoCuenta = cuenta.Codigo,
                NombreCuenta = cuenta.Nombre,
                Descripcion = txtDetalle.Text.Trim(),
                Debe = debe,
                Haber = haber
            });
            RefrescarTabla();
            txtDebe.Text = "0.00"; txtHaber.Text = "0.00"; txtDetalle.Clear();
        }

        private void EliminarLinea()
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Index < 0 || dgv.CurrentRow.Index >= _lineas.Count) return;
            _lineas.RemoveAt(dgv.CurrentRow.Index);
            RefrescarTabla();
        }

        private void RefrescarTabla()
        {
            dgv.Rows.Clear();
            foreach (var l in _lineas)
                dgv.Rows.Add(l.CodigoCuenta, l.NombreCuenta, l.Descripcion,
                    l.Debe.ToString("N2"), l.Haber.ToString("N2"));
            decimal debe = _lineas.Sum(x => x.Debe), haber = _lineas.Sum(x => x.Haber);
            lblDebe.Text = "Debe: Q " + debe.ToString("N2");
            lblHaber.Text = "Haber: Q " + haber.ToString("N2");
            lblDiferencia.Text = "Diferencia: Q " + (debe - haber).ToString("N2");
            lblDiferencia.ForeColor = debe == haber ? _principal : Color.DarkRed;
        }

        private void Enviar()
        {
            if (MessageBox.Show("¿Enviar esta póliza a Contabilidad?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            var lineas = _lineas.Select(x => new ClsModeloLineaIntegracionContabilidad
            {
                CodigoCuenta = x.CodigoCuenta,
                Descripcion = x.Descripcion,
                Debe = x.Debe,
                Haber = x.Haber
            }).ToList();
            string codigo, estado, mensaje;
            try
            {
                bool ok = _controlador.Enviar(CODIGO_MODULO, ID_PAIS, txtDocumento.Text,
                    dtFecha.Value.Date, txtDescripcion.Text, lineas,
                    out codigo, out estado, out mensaje);
                lblResultado.Text = "Póliza: " + codigo + " | Estado: " + estado + " | " + mensaje;
                MessageBox.Show(mensaje, ok ? "Contabilidad" : "No se pudo enviar",
                    MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (ok) { btnEnviar.Enabled = false; dgv.Enabled = false; }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ConsultarEstado()
        {
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            { MessageBox.Show("Indique el documento de origen."); return; }
            try
            {
                string codigo, estado;
                bool existe = _controlador.Consultar(CODIGO_MODULO, txtDocumento.Text.Trim(), out codigo, out estado);
                lblResultado.Text = existe ? "Póliza: " + codigo + " | Estado: " + estado : "Documento sin póliza registrada.";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Limpiar()
        {
            txtDocumento.Clear(); txtDescripcion.Clear(); txtDetalle.Clear();
            txtDebe.Text = "0.00"; txtHaber.Text = "0.00";
            dtFecha.Value = DateTime.Today;
            _lineas.Clear(); RefrescarTabla();
            dgv.Enabled = true; btnEnviar.Enabled = _cuentas.Count > 0;
            lblResultado.Text = "Sin enviar";
        }
    }
}
