using CadOmnicell;
using ClnOmnicell;
using CpMinerva;
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
    public partial class FrmCompras : Form
    {
        private int? idCompra;
        private List<Proveedor> listaProveedores;

        public FrmCompras()
        {
            InitializeComponent();
            idCompra = null;
        }
        public FrmCompras(int id)
        {
            InitializeComponent();
            idCompra = id;
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            cargarCombos();

            if (idCompra.HasValue)
            {
                cargarCompra();
            }
            else
            {
                cbxProveedor.SelectedIndex = -1;
                cbxEmpleado.SelectedIndex = -1;
                txtPais.Clear();
                dtpFechaCompra.Value = DateTime.Now;
                txtFactura.Clear();
                nudTotalCompra.Value = 0;
            }
        }

        private void cargarCombos()
        {
            listaProveedores = CompraCln.listarProveedoresCombo();

            cbxProveedor.DataSource = listaProveedores
                .Select(x => new
                {
                    id = x.id,
                    nombre = x.razonSocial
                }).ToList();

            cbxProveedor.DisplayMember = "nombre";
            cbxProveedor.ValueMember = "id";

            var empleados = CompraCln.listarEmpleadosCombo();

            cbxEmpleado.DataSource = empleados
                .Select(x => new
                {
                    id = x.id,
                    nombre = x.nombres + " " + x.primerApellido
                }).ToList();

            cbxEmpleado.DisplayMember = "nombre";
            cbxEmpleado.ValueMember = "id";

            cbxProveedor.SelectedIndexChanged += cbxProveedor_SelectedIndexChanged;
        }

        private void cbxProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProveedor.SelectedValue == null)
                return;

            if (cbxProveedor.SelectedValue is int idProveedor)
            {
                var proveedor = listaProveedores
                    .FirstOrDefault(x => x.id == idProveedor);

                txtPais.Text = proveedor?.pais ?? "";
            }
        }

        private void cargarCompra()
        {
            var compra = CompraCln.obtenerUno(idCompra.Value);

            cbxProveedor.SelectedValue = compra.idProveedor;
            cbxEmpleado.SelectedValue = compra.idEmpleado;
            dtpFechaCompra.Value = compra.fechaCompra;
            txtFactura.Text = compra.factura;
            nudTotalCompra.Value = compra.costoTotal;

            var proveedor = listaProveedores
                .FirstOrDefault(x => x.id == compra.idProveedor);

            txtPais.Text = proveedor?.pais ?? "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbxProveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un proveedor.");
                cbxProveedor.Focus();
                return;
            }

            if (cbxEmpleado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un empleado.");
                cbxEmpleado.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFactura.Text))
            {
                MessageBox.Show("Ingrese el número de factura.");
                txtFactura.Focus();
                return;
            }

            try
            {
                Compra compra = new Compra();

                compra.idProveedor = Convert.ToInt32(cbxProveedor.SelectedValue);
                compra.idEmpleado = Convert.ToInt32(cbxEmpleado.SelectedValue);
                compra.fechaCompra = dtpFechaCompra.Value;
                compra.factura = txtFactura.Text.Trim();
                compra.costoTotal = nudTotalCompra.Value;

                if (idCompra.HasValue)
                {
                    compra.id = idCompra.Value;
                    CompraCln.actualizar(compra);

                    MessageBox.Show("Compra actualizada correctamente.");
                }
                else
                {
                    if (Util.usuario == null)
                    {
                        MessageBox.Show("No se encontró el usuario de sesión.");
                        return;
                    }

                    compra.usuarioRegistro = Util.usuario.nombreUsuario;
                    compra.fechaRegistro = DateTime.Now;
                    compra.estado = 1;

                    CompraCln.crear(compra);

                    MessageBox.Show("Compra registrada correctamente.");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la compra: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
