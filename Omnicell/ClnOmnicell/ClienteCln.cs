using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnOmnicell
{
    public class ClienteCln
    {
        public static int crear(Cliente cliente)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Cliente.Where(x => x.nitCi == cliente.nitCi).FirstOrDefault();
                if (existe != null) throw new Exception($"El cliente con NIT/CI {cliente.nitCi} ya existe");

                context.Cliente.Add(cliente);
                context.SaveChanges();
                return cliente.id;
            }
        }

        public static int actualizar(Cliente cliente)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Cliente.Find(cliente.id);
                if (existe == null) throw new Exception($"El cliente con id {cliente.id} no existe");

                existe.nitCi = cliente.nitCi;
                existe.nombres = cliente.nombres;
                existe.primerApellido = cliente.primerApellido;
                existe.segundoApellido = cliente.segundoApellido;
                existe.razonSocial = cliente.razonSocial;
                existe.telefono = cliente.telefono;
                existe.direccion = cliente.direccion;
                existe.tipoCliente = cliente.tipoCliente;

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Cliente.Find(id);
                if (existe == null) throw new Exception($"El cliente con id {id} no existe");

                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Cliente obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                var cliente = context.Cliente.Find(id);
                if (cliente == null) throw new Exception($"El cliente con id {id} no existe");
                return cliente;
            }
        }

        public static List<Cliente> listar()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Cliente.Where(x => x.estado == 1).OrderBy(x => x.nitCi).ToList();
            }
        }

        public static List<paClienteListar_Result> listarClientes(string parametro)
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.paClienteListar(parametro != null ? parametro.Trim() : "").ToList();
            }
        }

        public static List<string> listarTiposClienteCombo()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Cliente
                    .Where(x => x.estado == 1 && x.tipoCliente != null && x.tipoCliente != "")
                    .Select(x => x.tipoCliente)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();
            }
        }
    }
}
