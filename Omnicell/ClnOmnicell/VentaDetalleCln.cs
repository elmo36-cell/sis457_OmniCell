using CadOmnicell;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClnOmnicell
{
    public class VentaDetalleCln
    {
        public static List<VentaDetalle> listarPorVenta(int idVenta)
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.VentaDetalle
                    .Include("Pantalla")
                    .Include("Pantalla.Compatibilidad.Modelo.Marca")
                    .Where(x => x.idVenta == idVenta && x.estado == (int)Estado.Activo)
                    .ToList();
            }
        }
    }
}
