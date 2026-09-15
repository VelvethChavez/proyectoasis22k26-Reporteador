using System.Data.Odbc;

namespace CapaModelo_BtnVerReporte.Repositorios
{
    public abstract class ClsRepositorio
    {
        private readonly string _CadenaConexion;

        public ClsRepositorio()
        {
            _CadenaConexion = "Dsn=dbreporteador";
        }

        protected OdbcConnection BtnVerReporteMetObtenerConexion()
        {
            return new OdbcConnection(_CadenaConexion);
        }
    }
}
