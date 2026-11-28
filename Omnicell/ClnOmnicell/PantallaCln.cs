using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ClnOmnicell
{
    public class PantallaCln
    {
        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                // SELECT por id antes de dar de baja.
                var existe = context.Pantalla.Find(id);
                if (existe == null) throw new Exception($"La pantalla con id {id} no existe");

                // Baja lógica: UPDATE estado = -1 (la fila no se borra).
                existe.estado = (int)Estado.Eliminado;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Pantalla obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                var pantalla = context.Pantalla.Find(id);
                if (pantalla == null) throw new Exception($"La pantalla con id {id} no existe");
                return pantalla;
            }
        }

        public static List<Pantalla> listar()
        {
            using (var context = new LabOmnicellEntities())
            {
                // SELECT ... WHERE estado = 1 ORDER BY descripcion.
                return context.Pantalla.Where(x => x.estado == (int)Estado.Activo).OrderBy(x => x.descripcion).ToList();
            }
        }

        public static List<paPantallaListar_Result> listarPantalla(string parametro)
        {
            using (var context = new LabOmnicellEntities())
            {
                // Procedimiento almacenado paPantallaListar: búsqueda por texto.
                return context.paPantallaListar(parametro != null ? (parametro ?? string.Empty).Trim() : "").ToList();
            }
        }

        
        public static List<paPantallaListarPorSucursal_Result> listarPorSucursal(
        int idSucursal, string parametro)
        {
            using (var context = new LabOmnicellEntities())
            {
                // Procedimiento paPantallaListarPorSucursal: filtra por sucursal y texto.
                return context.paPantallaListarPorSucursal(
                    idSucursal, parametro
                ).ToList();
            }
        }
        public static Pantalla obtenerConCompatibilidad(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                // SELECT de la pantalla con sus modelos compatibles (Include = JOIN).
                return context.Pantalla
                    .Include("Compatibilidad.Modelo.Marca")
                    .FirstOrDefault(x => x.id == id && x.estado == (int)Estado.Activo);
            }
        }


        public static int registrarConCompatibilidad(
            Pantalla pantalla, string nombreMarca, string nombreModelo)
        {
            using (var context = new LabOmnicellEntities())
            // BEGIN TRANSACTION: marca, modelo, pantalla y compatibilidad se guardan juntos.
            using (var transaccion = context.Database.BeginTransaction())
            {
                try
                {
                    string sku = pantalla.sku.Trim();
                    nombreMarca = nombreMarca.Trim();
                    nombreModelo = nombreModelo.Trim();

                    // Verificar SKU
                    var existePantalla = context.Pantalla
                        .FirstOrDefault(x => x.sku == sku);

                    if (existePantalla != null)
                        throw new Exception($"La pantalla con SKU {sku} ya existe.");

                    // Buscar marca
                    var marca = context.Marca.FirstOrDefault(x =>
                        x.nombre.ToLower() == nombreMarca.ToLower());

                    if (marca == null)
                    {
                        marca = new Marca
                        {
                            nombre = nombreMarca,
                            usuarioRegistro = pantalla.usuarioRegistro,
                            fechaRegistro = DateTime.Now,
                            estado = (int)Estado.Activo
                        };

                        context.Marca.Add(marca);
                        context.SaveChanges();
                    }
                    else if (marca.estado != (int)Estado.Activo)
                    {
                        marca.estado = (int)Estado.Activo;
                        marca.usuarioRegistro = pantalla.usuarioRegistro;
                    }

                    // Buscar modelo dentro de la marca
                    var modelo = context.Modelo.FirstOrDefault(x =>
                        x.idMarca == marca.id &&
                        x.nombre.ToLower() == nombreModelo.ToLower());

                    if (modelo == null)
                    {
                        modelo = new Modelo
                        {
                            idMarca = marca.id,
                            nombre = nombreModelo,
                            usuarioRegistro = pantalla.usuarioRegistro,
                            fechaRegistro = DateTime.Now,
                            estado = (int)Estado.Activo
                        };

                        context.Modelo.Add(modelo);
                        context.SaveChanges();
                    }
                    else if (modelo.estado != (int)Estado.Activo)
                    {
                        modelo.estado = (int)Estado.Activo;
                        modelo.usuarioRegistro = pantalla.usuarioRegistro;
                    }

                    // Registrar pantalla sin stock
                    pantalla.sku = sku;
                    pantalla.stockTotal = 0;
                    pantalla.fechaRegistro = DateTime.Now;
                    pantalla.estado = (int)Estado.Activo;

                    context.Pantalla.Add(pantalla);
                    context.SaveChanges();

                    // Registrar compatibilidad
                    Compatibilidad compatibilidad = new Compatibilidad
                    {
                        idPantalla = pantalla.id,
                        idModelo = modelo.id,
                        usuarioRegistro = pantalla.usuarioRegistro,
                        fechaRegistro = DateTime.Now,
                        estado = (int)Estado.Activo
                    };

                    context.Compatibilidad.Add(compatibilidad);
                    context.SaveChanges();

                    // COMMIT: confirma todos los INSERT.
                    transaccion.Commit();

                    return pantalla.id;
                }
                catch
                {
                    // ROLLBACK: deshace todo si algo falla.
                    transaccion.Rollback();
                    throw;
                }
            }
        }


    }
}
