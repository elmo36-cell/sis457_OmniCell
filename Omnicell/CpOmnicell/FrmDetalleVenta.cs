using CadOmnicell;
using ClnOmnicell;
using CpMinerva;
using System;
using System.Windows.Forms;

namespace CpOmnicell
{
    public partial class FrmDetalleVenta : FormOmnicell
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
                Util.MostrarError(ex.Message, "Error al consultar la venta");

                Close();
            }
        }

        private void cargarVenta()
        {
            Venta venta = VentaCln.obtenerUno(idVenta);

            lblNumeroVenta.Text = venta.id.ToString(Formatos.NumeroDocumento);
            lblFechaVenta.Text = venta.fechaVenta.ToString(Formatos.FechaHora);
            lblTipoPago.Text = venta.tipoPago;
            lblCliente.Text = venta.Cliente.NombreMostrar();
            lblCiNit.Text = venta.Cliente.nitCi;
            lblVendedor.Text = venta.Empleado.NombreCompleto();
            lblCargo.Text = venta.Empleado.cargo;
            lblSucursal.Text = venta.Sucursal.nombre;
            lblTotal.Text = venta.montoTotal.ToString(Formatos.Monto) + " Bs";
        }

        private void cargarDetalles()
        {
            GrillasOmnicell.ConfigurarDetalle(dgvDetalleVenta);

            dgvDetalleVenta.Rows.Clear();

            foreach (VentaDetalle detalle in VentaDetalleCln.listarPorVenta(idVenta))
            {
                Pantalla pantalla = detalle.Pantalla;

                string marca;
                string modelo;
                CompatibilidadCln.obtenerMarcaModelo(pantalla, out marca, out modelo);

                dgvDetalleVenta.Rows.Add(
                    pantalla.sku,
                    marca,
                    modelo,
                    pantalla.descripcion,
                    pantalla.calidad,
                    pantalla.tecnologia,
                    detalle.cantidad,
                    detalle.precioUnitario.ToString(Formatos.Monto),
                    detalle.subtotal.ToString(Formatos.Monto),
                    detalle.observacionGarantia
                );
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
