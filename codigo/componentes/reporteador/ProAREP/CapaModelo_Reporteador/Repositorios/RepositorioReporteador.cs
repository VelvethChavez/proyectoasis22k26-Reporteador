using CapaModelo_Reporteador.Contratos;
using CapaModelo_Reporteador.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_Reporteador.Repositorios
{
    public class RepositorioReporteador : RepositorioMaestro, IRepositorioReporteador
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public RepositorioReporteador()
        {
            selectAll = "SELECT * FROM tblReporte";

            insert = "INSERT INTO tblReporte " +
                     "(numeroReporte, nombreReporte, rutaReporte, fechaReporte) " +
                     "VALUES (?, ?, ?, ?)";

            update = "UPDATE tblReporte SET " +
                     "nombreReporte=?, rutaReporte=?, fechaReporte=? " +
                     "WHERE numeroReporte=?";

            delete = "DELETE FROM tblReporte " +
                     "WHERE numeroReporte=?";
        }

        public int Agregar(Reporteador entidad)
        {
            var _parametros = new List<OdbcParameter>();

            _parametros.Add(
                new OdbcParameter("p_numeroReporte", entidad.NumeroReporte));

            _parametros.Add(
                new OdbcParameter("p_nombreReporte", entidad.NombreReporte));

            _parametros.Add(
                new OdbcParameter("p_rutaReporte", entidad.RutaReporte));

            _parametros.Add(
                new OdbcParameter("p_fechaReporte", entidad.FechaReporte));

            return EjecucionNonQuery(
                insert,
                _parametros,
                CommandType.Text);
        }

        public int Editar(Reporteador entidad)
        {
            var _parametros = new List<OdbcParameter>();

            _parametros.Add(
                new OdbcParameter("p_nombreReporte", entidad.NombreReporte));

            _parametros.Add(
                new OdbcParameter("p_rutaReporte", entidad.RutaReporte));

            _parametros.Add(
                new OdbcParameter("p_fechaReporte", entidad.FechaReporte));

            _parametros.Add(
                new OdbcParameter("p_numeroReporte", entidad.NumeroReporte));

            return EjecucionNonQuery(
                update,
                _parametros,
                CommandType.Text);
        }

        public int Remover(Reporteador entidad)
        {
            var _parametros = new List<OdbcParameter>();

            _parametros.Add(
                new OdbcParameter("p_numeroReporte", entidad.NumeroReporte));

            return EjecucionNonQuery(
                delete,
                _parametros,
                CommandType.Text);
        }

        public IEnumerable<Reporteador> GetAll()
        {
            var lstReporteador = new List<Reporteador>();

            var tblTabla = EjecucionConsulta(
                selectAll,
                CommandType.Text);

            foreach (DataRow row in tblTabla.Rows)
            {
                var reporteador = new Reporteador();

                reporteador.NumeroReporte =
                    Convert.ToInt32(row[0]);

                reporteador.NombreReporte =
                    row[1].ToString();

                reporteador.RutaReporte =
                    row[2].ToString();

                reporteador.FechaReporte =
                    Convert.ToDateTime(row[3]);

                lstReporteador.Add(reporteador);
            }

            tblTabla.Clear();
            tblTabla = null;

            return lstReporteador;
        }
    }
}