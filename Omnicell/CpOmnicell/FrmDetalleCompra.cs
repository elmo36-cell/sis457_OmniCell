using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadOmnicell;
using ClnOmnicell;

namespace CpOmnicell
{
    public partial class FrmDetalleCompra : Form
    {
        private int idCompra;

        public FrmDetalleCompra(int id)
        {
            InitializeComponent();
            idCompra = id;
        }

        private void FrmDetalleCompra_Load(object sender, EventArgs e)
        {
            try
            {
                cargarCompra();
                cargarDetalles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al consultar la compra",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Close();
            }
        }
        private void cargarCompra()
        {
            Compra compra = CompraCln.obtenerUno(idCompra);

            lblNumeroCompra.Text = compra.id.ToString("D5");
            lblFechaCompra.Text = compra.fechaCompra.ToString("dd/MM/yyyy");
            lblFactura.Text = compra.factura;

            lblProveedor.Text = compra.Proveedor.razonSocial;
            lblPais.Text = compra.Proveedor.pais;
            lblContacto.Text = compra.Proveedor.contactoPersona;
            lblTelefono.Text = compra.Proveedor.telefono;

            lblEmpleado.Text = (
                compra.Empleado.nombres + " " +
                compra.Empleado.primerApellido + " " +
                compra.Empleado.segundoApellido
            ).Trim();

            lblTotal.Text = compra.costoTotal.ToString("N2") + " Bs";
        }
        private void cargarDetalles()
        {
            var detalles = CompraDetalleCln.listarPorCompra(idCompra);

            dgvDetalleCompra.Rows.Clear();

            foreach (var detalle in detalles)
            {
                var pantalla = detalle.Pantalla;

                string marca = "";
                string modelo = "";

                var compatibilidad = pantalla.Compatibilidad
                    .FirstOrDefault(x => x.estado == 1);

                if (compatibilidad != null)
                {
                    modelo = compatibilidad.Modelo.nombre;
                    marca = compatibilidad.Modelo.Marca.nombre;
                }

                dgvDetalleCompra.Rows.Add(
                    pantalla.sku,
                    marca,
                    modelo,
                    pantalla.descripcion,
                    pantalla.calidad,
                    pantalla.tecnologia,
                    detalle.cantidad,
                    detalle.costoUnitario.ToString("N2"),
                    detalle.subtotal.ToString("N2")
                );
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
