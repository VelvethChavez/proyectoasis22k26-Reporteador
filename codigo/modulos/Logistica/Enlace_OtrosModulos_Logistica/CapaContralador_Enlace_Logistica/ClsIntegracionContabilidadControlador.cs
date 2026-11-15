using System;
using System.Collections.Generic;
using System.Linq;
using CapaControlador_Contabilidad;

namespace CapaContralador_Enlace_Logistica
{
    public class ClsIntegracionContabilidadControlador
    {
        private readonly ClsControladorIntegracionContabilidad _contabilidad = new ClsControladorIntegracionContabilidad();

        public List<ClsModeloCuentaPolizaContabilidad> ObtenerCuentas(string modulo, int pais)
        {
            return _contabilidad.ContabilidadFuncCuentasPermitidas(modulo, pais);
        }

        public bool Enviar(string modulo, int pais, string documento, DateTime fecha,
            string descripcion, List<ClsModeloLineaIntegracionContabilidad> lineas,
            out string codigo, out string estado, out string mensaje)
        {
            codigo = estado = mensaje = "";
            if (string.IsNullOrWhiteSpace(modulo)) { mensaje = "Configure el código de módulo de Logística."; return false; }
            if (string.IsNullOrWhiteSpace(documento) || documento.Trim().Length > 30)
            { mensaje = "Documento de origen obligatorio (máximo 30 caracteres)."; return false; }
            if (descripcion != null && descripcion.Trim().Length > 255)
            { mensaje = "La descripción no puede superar 255 caracteres."; return false; }
            if (lineas == null || lineas.Count < 2 || lineas.Any(x => x == null))
            { mensaje = "Se requieren al menos dos líneas válidas."; return false; }
            if (lineas.Any(x => x.Debe < 0 || x.Haber < 0 || (x.Debe > 0) == (x.Haber > 0)))
            { mensaje = "Cada línea debe tener un importe positivo en Debe o Haber, pero no ambos."; return false; }
            if (lineas.Sum(x => x.Debe) != lineas.Sum(x => x.Haber))
            { mensaje = "La póliza no cuadra."; return false; }
            return _contabilidad.ContabilidadFuncRecibirPoliza(modulo, pais, documento.Trim(),
                fecha, descripcion, lineas, out codigo, out estado, out mensaje);
        }

        public bool Consultar(string modulo, string documento, out string codigo, out string estado)
        {
            return _contabilidad.ContabilidadFuncEstadoDocumento(modulo, documento, out codigo, out estado);
        }
    }
}
