using System;
using System.Data;
using System.Data.Odbc;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaModelo_Consultas
{
    public class ClsSentenciasTablas
    {
        private readonly ClsConexion _Conexion = new ClsConexion();

        public DataTable ConsultasFuncObtenerTabla(
            string NombreTabla,
            int Pagina,
            int RegistrosPorPagina)
        {
            try
            {
                ConsultasMetValidarNombreTabla(NombreTabla);

                DataTable DtTabla = new DataTable();

                int Inicio = (Pagina - 1) * RegistrosPorPagina;

                string Consulta =
                    "SELECT * FROM " + NombreTabla +
                    " LIMIT ? OFFSET ?;";

                using (OdbcConnection Conexion =
                    _Conexion.ConsultasFuncConexion())
                {
                    using (OdbcCommand Cmd =
                        new OdbcCommand(Consulta, Conexion))
                    {
                        Cmd.Parameters.AddWithValue(
                            "?",
                            RegistrosPorPagina);

                        Cmd.Parameters.AddWithValue(
                            "?",
                            Inicio);

                        using (OdbcDataAdapter DaTabla =
                            new OdbcDataAdapter(Cmd))
                        {
                            DaTabla.Fill(DtTabla);
                        }
                    }
                }

                return DtTabla;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(
                    "Error al cargar la tabla '" +
                    NombreTabla + "'.\n\n" +
                    "Detalle del error:\n" +
                    Ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Environment.Exit(1);

                return null;
            }
        }

        public DataTable ConsultasFuncObtenerTablas()
        {
            try
            {
                DataTable DtTablas = new DataTable();

                string Consulta = "SHOW TABLES;";

                using (OdbcConnection Conexion =
                    _Conexion.ConsultasFuncConexion())
                {
                    using (OdbcCommand Cmd =
                        new OdbcCommand(Consulta, Conexion))
                    {
                        using (OdbcDataAdapter DaTablas =
                            new OdbcDataAdapter(Cmd))
                        {
                            DaTablas.Fill(DtTablas);
                        }
                    }
                }

                return DtTablas;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(
                    "Error al obtener las tablas de la base de datos.\n\n" +
                    "Verifique la conexión con la base de datos.\n\n" +
                    "Detalle del error:\n" +
                    Ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Environment.Exit(1);

                return null;
            }
        }

        public int ConsultasFuncContarRegistros(
            string NombreTabla)
        {
            try
            {
                ConsultasMetValidarNombreTabla(NombreTabla);

                string Consulta =
                    "SELECT COUNT(*) FROM " + NombreTabla + ";";

                using (OdbcConnection Conexion =
                    _Conexion.ConsultasFuncConexion())
                {
                    if (Conexion.State != ConnectionState.Open)
                    {
                        Conexion.Open();
                    }

                    using (OdbcCommand Cmd =
                        new OdbcCommand(Consulta, Conexion))
                    {
                        return Convert.ToInt32(
                            Cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(
                    "Error al contar los registros de la tabla '" +
                    NombreTabla + "'.\n\n" +
                    "Detalle del error:\n" +
                    Ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Environment.Exit(1);

                return 0;
            }
        }

        private void ConsultasMetValidarNombreTabla(
            string NombreTabla)
        {
            if (string.IsNullOrWhiteSpace(NombreTabla))
            {
                throw new ArgumentException(
                    "El nombre de la tabla no puede estar vacío.");
            }

            if (!Regex.IsMatch(
                NombreTabla,
                @"^[A-Za-z_][A-Za-z0-9_]*$"))
            {
                throw new ArgumentException(
                    "El nombre de la tabla contiene caracteres no válidos.");
            }
        }
    }
}