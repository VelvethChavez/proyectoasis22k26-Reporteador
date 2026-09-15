using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo_BtnVerReporte.Repositorios
{
    public class ClsRepositorioBtnVerReporte : ClsRepositorio
    {
        private string _ConsultaPorNombre;

        public ClsRepositorioBtnVerReporte()
        {
            _ConsultaPorNombre = "SELECT * FROM tblReporte WHERE nombreReporte=?";
        }

        public string BtnVerReporteFuncObtenerRutaPorNombre(string NombreReporte)
        {
            List<OdbcParameter> Parametros = new List<OdbcParameter>();

            Parametros.Add(
                new OdbcParameter("p_nombreReporte", NombreReporte));

            DataTable TablaResultado = BtnVerReporteMetEjecucionConsulta(
                _ConsultaPorNombre,
                Parametros,
                CommandType.Text);

            if (TablaResultado == null || TablaResultado.Rows.Count == 0)
            {
                return null;
            }

            return TablaResultado.Rows[0][2].ToString();
        }

        public DataTable BtnVerReporteMetEjecucionConsulta(
            string ComandoTexto,
            CommandType ComandoTipo)
        {
            return BtnVerReporteMetEjecucionConsulta(ComandoTexto, null, ComandoTipo);
        }

        public DataTable BtnVerReporteMetEjecucionConsulta(
            string ComandoTexto,
            List<OdbcParameter> Parametros,
            CommandType ComandoTipo)
        {
            DataTable TablaDatos = new DataTable();

            using (OdbcConnection Conexion = BtnVerReporteMetObtenerConexion())
            {
                Conexion.Open();

                using (OdbcCommand Comando = new OdbcCommand())
                {
                    Comando.Connection = Conexion;
                    Comando.CommandText = ComandoTexto;
                    Comando.CommandType = ComandoTipo;

                    if (Parametros != null)
                    {
                        Comando.Parameters.AddRange(Parametros.ToArray());
                    }

                    using (OdbcDataReader Lector = Comando.ExecuteReader())
                    {
                        TablaDatos.Load(Lector);
                    }
                }

                return TablaDatos;
            }
        }
    }
}
