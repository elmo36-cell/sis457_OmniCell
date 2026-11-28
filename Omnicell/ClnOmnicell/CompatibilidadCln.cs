using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnOmnicell
{
    // Marcas y modelos activos que se pueden elegir para una pantalla.
    public class CatalogoCompatibilidad
    {
        public List<Modelo> Modelos { get; private set; }
        public List<Marca> Marcas { get; private set; }

        public CatalogoCompatibilidad(List<Modelo> modelos)
        {
            Modelos = modelos;
            Marcas = modelos
                .Where(modelo => modelo.Marca != null)
                .Select(modelo => modelo.Marca)
                .GroupBy(marca => marca.id)
                .Select(grupo => grupo.First())
                .OrderBy(marca => marca.nombre)
                .ToList();
        }
    }

    public class CompatibilidadCln
    {
        // Marcas y modelos compatibles con la pantalla, sin repetir y ordenados por nombre.
        public static CatalogoCompatibilidad obtenerCatalogo(Pantalla pantalla)
        {
            if (pantalla == null)
                throw new ArgumentNullException(nameof(pantalla));

            IEnumerable<Compatibilidad> compatibilidades =
                pantalla.Compatibilidad ?? Enumerable.Empty<Compatibilidad>();

            List<Modelo> modelos = compatibilidades
                .Where(c => c.estado == (int)Estado.Activo &&
                            c.Modelo != null &&
                            c.Modelo.estado == (int)Estado.Activo)
                .Select(c => c.Modelo)
                .GroupBy(modelo => modelo.id)
                .Select(grupo => grupo.First())
                .OrderBy(modelo => modelo.nombre)
                .ToList();

            return new CatalogoCompatibilidad(modelos);
        }

        // Marca y modelo con los que se registró la pantalla (primera compatibilidad activa).
        public static void obtenerMarcaModelo(Pantalla pantalla, out string marca, out string modelo)
        {
            marca = string.Empty;
            modelo = string.Empty;

            if (pantalla == null || pantalla.Compatibilidad == null)
                return;

            Compatibilidad compatibilidad = pantalla.Compatibilidad
                .FirstOrDefault(c => c.estado == (int)Estado.Activo && c.Modelo != null);

            if (compatibilidad == null)
                return;

            modelo = compatibilidad.Modelo.nombre;
            marca = compatibilidad.Modelo.Marca == null
                ? string.Empty
                : compatibilidad.Modelo.Marca.nombre;
        }
    }
}
