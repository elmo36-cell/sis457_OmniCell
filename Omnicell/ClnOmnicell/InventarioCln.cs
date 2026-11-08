using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnOmnicell
{
    public class InventarioCln
    {
        public static int crear(Inventario inventario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Inventario.Where(x => x.idSucursal == inventario.idSucursal && x.idPantalla == inventario.idPantalla).FirstOrDefault();
                if (existe != null) throw new Exception("Ya existe un registro de inventario para esta pantalla en esta sucursal");

                context.Inventario.Add(inventario);
                context.SaveChanges();
                return inventario.id;
            }
        }

        public static int actualizar(Inventario inventario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Inventario.Find(inventario.id);
                if (existe == null) throw new Exception($"El inventario con id {inventario.id} no existe");

                existe.idSucursal = inventario.idSucursal;
                existe.idPantalla = inventario.idPantalla;
                existe.stockActual = inventario.stockActual;
                existe.stockMinimo = inventario.stockMinimo;
                existe.usuarioRegistro = inventario.usuarioRegistro;

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Inventario.Find(id);
                if (existe == null) throw new Exception($"El inventario con id {id} no existe");

                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Inventario obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                var inventario = context.Inventario.Find(id);
                if (inventario == null) throw new Exception($"El inventario con id {id} no existe");
                return inventario;
            }
        }

        public static List<Inventario> listar()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Inventario.Where(x => x.estado == 1).ToList();
            }
        }
    }
}
