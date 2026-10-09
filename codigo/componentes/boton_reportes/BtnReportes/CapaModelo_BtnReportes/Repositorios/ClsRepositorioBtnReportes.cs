using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CapaModelo_BtnReportes.Repositorios
{
    /// <summary>
    /// Acceso al archivo .rdlc: localizarlo en disco y leer sus DataSets.
    /// </summary>
    public class ClsRepositorioBtnReportes
    {
        /// <summary>
        /// Busca el .rdlc: tal cual, junto al ejecutable y subiendo por las
        /// carpetas padre (carpeta Reportes incluida). Devuelve null si no existe.
        /// </summary>
        public string BtnReportesMetLocalizarArchivo(string Ruta)
        {
            if (string.IsNullOrWhiteSpace(Ruta))
            {
                return null;
            }

            if (Path.IsPathRooted(Ruta))
            {
                return File.Exists(Ruta) ? Ruta : null;
            }

            string Dir = AppDomain.CurrentDomain.BaseDirectory;

            for (int I = 0; I < 8 && !string.IsNullOrEmpty(Dir); I++)
            {
                string Candidata = Path.Combine(Dir, Ruta);

                if (File.Exists(Candidata))
                {
                    return Candidata;
                }

                Candidata = Path.Combine(Dir, "Reportes", Ruta);

                if (File.Exists(Candidata))
                {
                    return Candidata;
                }

                DirectoryInfo Padre = Directory.GetParent(Dir);
                Dir = Padre != null ? Padre.FullName : null;
            }

            return null;
        }

        /// <summary>Nombres de los DataSet definidos dentro del .rdlc.</summary>
        public List<string> BtnReportesMetObtenerDataSets(string RutaArchivo)
        {
            List<string> Nombres = new List<string>();

            XmlDocument Documento = new XmlDocument();
            Documento.Load(RutaArchivo);

            foreach (XmlNode Nodo in Documento.SelectNodes(
                "//*[local-name()='DataSets']/*[local-name()='DataSet']"))
            {
                XmlAttribute Nombre = Nodo.Attributes["Name"];

                if (Nombre != null)
                {
                    Nombres.Add(Nombre.Value);
                }
            }

            return Nombres;
        }
    }
}
