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
        public static int crear(Pantalla pantalla)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Pantalla.Where(x => x.sku == pantalla.sku).FirstOrDefault();
                if (existe != null) throw new Exception($"La pantalla con SKU {pantalla.sku} ya existe");

                context.Pantalla.Add(pantalla);
                context.SaveChanges();
                return pantalla.id;
            }
        }

        public static int actualizar(Pantalla pantalla)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Pantalla.Find(pantalla.id);
                if (existe == null) throw new Exception($"La pantalla con id {pantalla.id} no existe");

                existe.sku = pantalla.sku;
                existe.descripcion = pantalla.descripcion;
                existe.calidad = pantalla.calidad;
                existe.tecnologia = pantalla.tecnologia;
                existe.precioVenta = pantalla.precioVenta;
                existe.stockTotal = pantalla.stockTotal;
                existe.usuarioRegistro = pantalla.usuarioRegistro;

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Pantalla.Find(id);
                if (existe == null) throw new Exception($"La pantalla con id {id} no existe");

                existe.estado = -1;
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
                return context.Pantalla.Where(x => x.estado == 1).OrderBy(x => x.descripcion).ToList();
            }
        }

        public static List<paPantallaListar_Result> listarPantalla(string parametro)
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.paPantallaListar(parametro != null ? parametro.Trim() : "").ToList();
            }
        }

        public static List<Pantalla> listarPorSucursal(int idSucursal)
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Pantalla
                    .Include("Compatibilidad.Modelo.Marca")
                    .Where(p => p.estado == 1 &&
                        p.Inventario.Any(i =>
                            i.idSucursal == idSucursal &&
                            i.estado == 1 &&
                            i.stockActual > 0))
                    .OrderBy(p => p.descripcion)
                    .ToList();
            }
        }
        public static List<paPantallaListarPorSucursal_Result> listarPorSucursal(
        int idSucursal, string parametro)
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.paPantallaListarPorSucursal(
                    idSucursal, parametro
                ).ToList();
            }
        }
        public static Pantalla obtenerConCompatibilidad(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Pantalla
                    .Include("Compatibilidad.Modelo.Marca")
                    .FirstOrDefault(x => x.id == id && x.estado == 1);
            }
        }


        public static int registrarConCompatibilidad(
            Pantalla pantalla, string nombreMarca, string nombreModelo)
        {
            using (var context = new LabOmnicellEntities())
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
                            estado = 1
                        };

                        context.Marca.Add(marca);
                        context.SaveChanges();
                    }
                    else if (marca.estado != 1)
                    {
                        marca.estado = 1;
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
                            estado = 1
                        };

                        context.Modelo.Add(modelo);
                        context.SaveChanges();
                    }
                    else if (modelo.estado != 1)
                    {
                        modelo.estado = 1;
                        modelo.usuarioRegistro = pantalla.usuarioRegistro;
                    }

                    // Registrar pantalla sin stock
                    pantalla.sku = sku;
                    pantalla.stockTotal = 0;
                    pantalla.fechaRegistro = DateTime.Now;
                    pantalla.estado = 1;

                    context.Pantalla.Add(pantalla);
                    context.SaveChanges();

                    // Registrar compatibilidad
                    Compatibilidad compatibilidad = new Compatibilidad
                    {
                        idPantalla = pantalla.id,
                        idModelo = modelo.id,
                        usuarioRegistro = pantalla.usuarioRegistro,
                        fechaRegistro = DateTime.Now,
                        estado = 1
                    };

                    context.Compatibilidad.Add(compatibilidad);
                    context.SaveChanges();

                    transaccion.Commit();

                    return pantalla.id;
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }


    }
}
