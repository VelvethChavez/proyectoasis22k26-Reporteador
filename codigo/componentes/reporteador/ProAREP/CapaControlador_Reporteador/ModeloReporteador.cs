using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_Reporteador.Contratos;
using CapaModelo_Reporteador.Entidades;
using CapaModelo_Reporteador.Repositorios;
using System.ComponentModel.DataAnnotations;

namespace CapaControlador_Reporteador
{
    public class ModeloReporteador
    {
        private int _numeroReporte;
        private string _nombreReporte;
        private string _rutaReporte;
        private DateTime _fechaReporte;

        private IRepositorioReporteador RepositorioReporteador;

        public EstadoEntidad Estado { private get; set; }

        private List<ModeloReporteador> ListaReportes;

        public int NumeroReporte
        {
            get => _numeroReporte;
            set => _numeroReporte = value;
        }

        [Required(ErrorMessage = "El campo nombre del reporte es requerido")]
        [StringLength(maximumLength: 150, MinimumLength = 5)]
        public string NombreReporte
        {
            get => _nombreReporte;
            set => _nombreReporte = value;
        }

        [Required(ErrorMessage = "El campo ruta del reporte es requerido")]
        [StringLength(maximumLength: 500)]
        public string RutaReporte
        {
            get => _rutaReporte;
            set => _rutaReporte = value;
        }

        [Required(ErrorMessage = "El campo fecha del reporte es requerido")]
        public DateTime FechaReporte
        {
            get => _fechaReporte;
            set => _fechaReporte = value;
        }

        public ModeloReporteador()
        {
            RepositorioReporteador = new RepositorioReporteador();
        }

        public string GrabarCambios()
        {
            string mensaje = null;

            try
            {
                var modeloDatosReporteador = new Reporteador();

                modeloDatosReporteador.NumeroReporte = _numeroReporte;
                modeloDatosReporteador.NombreReporte = _nombreReporte;
                modeloDatosReporteador.RutaReporte = _rutaReporte;
                modeloDatosReporteador.FechaReporte = _fechaReporte;

                switch (Estado)
                {
                    case EstadoEntidad.Added:
                        RepositorioReporteador.Agregar(modeloDatosReporteador);
                        mensaje = "Grabacion exitosa";
                        break;

                    case EstadoEntidad.Modified:
                        RepositorioReporteador.Editar(modeloDatosReporteador);
                        mensaje = "Actualizacion exitosa";
                        break;

                    case EstadoEntidad.Deleted:
                        RepositorioReporteador.Remover(modeloDatosReporteador);
                        mensaje = "Eliminacion exitosa";
                        break;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }

            return mensaje;
        }

        public List<ModeloReporteador> GetAll()
        {
            var modeloDatosReportes = RepositorioReporteador.GetAll();

            ListaReportes = new List<ModeloReporteador>();

            foreach (Reporteador item in modeloDatosReportes)
            {
                ListaReportes.Add(new ModeloReporteador
                {
                    _numeroReporte = item.NumeroReporte,
                    _nombreReporte = item.NombreReporte,
                    _rutaReporte = item.RutaReporte,
                    _fechaReporte = item.FechaReporte
                });
            }

            return ListaReportes;
        }

        public IEnumerable<ModeloReporteador> FindbyId(string filter)
        {
            return ListaReportes.FindAll(e =>
                e.NumeroReporte.ToString().Contains(filter) ||
                e.NombreReporte.Contains(filter));
        }
    }
}