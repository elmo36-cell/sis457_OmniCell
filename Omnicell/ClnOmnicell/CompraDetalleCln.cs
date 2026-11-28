using CadOmnicell;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClnOmnicell
{
    public class CompraDetalleCln
    {
        public static List<CompraDetalle> listarPorCompra(int idCompra)
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.CompraDetalle
                    .Include("Pantalla")
                    .Include("Pantalla.Compatibilidad.Modelo.Marca")
                    .Where(x => x.idCompra == idCompra && x.estado == (int)Estado.Activo)
                    .ToList();
            }
        }
    }
}
