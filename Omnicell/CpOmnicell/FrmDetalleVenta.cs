using CadOmnicell;
using ClnOmnicell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpOmnicell
{
    public partial class FrmDetalleVenta : Form
    {
        private int idVenta;

        public FrmDetalleVenta(int id)
        {
            InitializeComponent();
            idVenta = id;
        }

        private void FrmDetalleVenta_Load(object sender, EventArgs e)
        {
            try
            {
                cargarVenta();
                cargarDetalles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al consultar la venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Close();
            }

        }
        private void cargarVenta()
        {
            Venta venta = VentaCln.obtenerUno(idVenta);

            lblNumeroVenta.Text = venta.id.ToString("D5");

            lblFechaVenta.Text =
                venta.fechaVenta.ToString("dd/MM/yyyy HH:mm");

            lblTipoPago.Text = venta.tipoPago;

            lblCliente.Text = (
                venta.Cliente.nombres + " " +
                venta.Cliente.primerApellido + " " +
                venta.Cliente.segundoApellido
            ).Trim();

            if (!string.IsNullOrWhiteSpace(venta.Cliente.razonSocial))
                lblCliente.Text = venta.Cliente.razonSocial;

            lblCiNit.Text = venta.Cliente.nitCi;

            lblVendedor.Text = (
                venta.Empleado.nombres + " " +
                venta.Empleado.primerApellido + " " +
                venta.Empleado.segundoApellido
            ).Trim();

            lblCargo.Text = venta.Empleado.cargo;

            lblSucursal.Text = venta.Sucursal.nombre;

            lblTotal.Text = venta.montoTotal.ToString("N2") + " Bs";
        }
        private void cargarDetalles()
        {
            var detalles = VentaDetalleCln.listarPorVenta(idVenta);

            dgvDetalleVenta.Rows.Clear();

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

                dgvDetalleVenta.Rows.Add(
                    pantalla.sku,
                    marca,
                    modelo,
                    pantalla.descripcion,
                    pantalla.calidad,
                    pantalla.tecnologia,
                    detalle.cantidad,
                    detalle.precioUnitario.ToString("N2"),
                    detalle.subtotal.ToString("N2"),
                    detalle.observacionGarantia
                );
                dgvDetalleVenta.AutoGenerateColumns = false;
                dgvDetalleVenta.AllowUserToAddRows = false;
                dgvDetalleVenta.ReadOnly = true;
                dgvDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvDetalleVenta.MultiSelect = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
