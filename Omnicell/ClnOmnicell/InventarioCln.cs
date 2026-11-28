using CadOmnicell;
using System.Linq;

namespace ClnOmnicell
{
    public class InventarioCln
    {
        public static decimal obtenerStock(int idSucursal, int idPantalla)
        {
            using (var context = new LabOmnicellEntities())
            {
                var inventario = context.Inventario.FirstOrDefault(i =>
                    i.idSucursal == idSucursal &&
                    i.idPantalla == idPantalla &&
                    i.estado == (int)Estado.Activo
                );

                return inventario != null ? inventario.stockActual : 0;
            }
        }
    }
}
