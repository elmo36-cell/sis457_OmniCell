using CadOmnicell;
using ClnOmnicell;
using CpMinerva;
using System;
using System.Windows.Forms;

namespace CpOmnicell
{
    public partial class FrmDetalleCompra : FormOmnicell
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
                Util.MostrarError(ex.Message, "Error al consultar la compra");

                Close();
            }
        }

        private void cargarCompra()
        {
            Compra compra = CompraCln.obtenerUno(idCompra);

            lblNumeroCompra.Text = compra.id.ToString(Formatos.NumeroDocumento);
            lblFechaCompra.Text = compra.fechaCompra.ToString(Formatos.Fecha);
            lblFactura.Text = compra.factura;

            lblProveedor.Text = compra.Proveedor.razonSocial;
            lblPais.Text = compra.Proveedor.pais;
            lblContacto.Text = compra.Proveedor.contactoPersona;
            lblTelefono.Text = compra.Proveedor.telefono;

            lblEmpleado.Text = compra.Empleado.NombreCompleto();
            lblTotal.Text = compra.costoTotal.ToString(Formatos.Monto) + " Bs";
        }

        private void cargarDetalles()
        {
            GrillasOmnicell.ConfigurarDetalle(dgvDetalleCompra);

            dgvDetalleCompra.Rows.Clear();

            foreach (CompraDetalle detalle in CompraDetalleCln.listarPorCompra(idCompra))
            {
                Pantalla pantalla = detalle.Pantalla;

                string marca;
                string modelo;
                CompatibilidadCln.obtenerMarcaModelo(pantalla, out marca, out modelo);

                dgvDetalleCompra.Rows.Add(
                    pantalla.sku,
                    marca,
                    modelo,
                    pantalla.descripcion,
                    pantalla.calidad,
                    pantalla.tecnologia,
                    detalle.cantidad,
                    detalle.costoUnitario.ToString(Formatos.Monto),
                    detalle.subtotal.ToString(Formatos.Monto)
                );
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
