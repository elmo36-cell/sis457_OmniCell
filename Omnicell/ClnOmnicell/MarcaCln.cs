using CadOmnicell;
using System.Collections.Generic;
using System.Linq;

namespace ClnOmnicell
{
    public class MarcaCln
    {
        public static List<Marca> listar()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Marca.Where(x => x.estado == (int)Estado.Activo).OrderBy(x => x.nombre).ToList();
            }
        }
    }
}
