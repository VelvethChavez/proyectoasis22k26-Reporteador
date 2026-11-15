
using System.Collections.Generic;
using CapaModelo_Enlace_Logistica.Entidades;

namespace CapaModelo_Enlace_Logistica.Contratos
{
    public interface ClsIRepositorioSolicitudPago
    {
        // Obtener servicios disponibles para solicitar pago.
        IEnumerable<ClsServicioTransporte>
            ObtenerServiciosDisponibles();

        // Generar solicitud de pago y devolver su código.
        string GenerarSolicitudPago(int idServicio);
    }
}
