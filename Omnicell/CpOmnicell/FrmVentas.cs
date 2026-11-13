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
    public partial class FrmVentas : Form
    {
        private List<Cliente> listaClientes = new List<Cliente>();
        private int? idVenta;
        private Venta ventaActual;

        // Para registrar una venta nueva
        public FrmVentas()
        {
            InitializeComponent();
            idVenta = null;
        }

        // Para editar una venta existente
        public FrmVentas(int id)
        {
            InitializeComponent();
            idVenta = id;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {

            cbxTipoPago.Items.Clear();
            cbxTipoPago.Items.Add("Efectivo");
            cbxTipoPago.Items.Add("QR");
            cbxTipoPago.Items.Add("Transferencia");
            cbxTipoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTipoPago.SelectedIndex = 0;
            cargarCombos();

            if (idVenta.HasValue)
            {
                ventaActual = VentaCln.obtenerUno(idVenta.Value);

                cbxCliente.SelectedValue = ventaActual.idCliente;
                cbxEmpleado.SelectedValue = ventaActual.idEmpleado;
                cbxSucursal.SelectedValue = ventaActual.idSucursal;

                dtpFechaVenta.Value = ventaActual.fechaVenta;
                cbxTipoPago.SelectedItem = ventaActual.tipoPago;
                nudTotalVenta.Value = ventaActual.montoTotal;
            }
            else
            {
                cbxCliente.SelectedIndex = -1;
                cbxEmpleado.SelectedIndex = -1;
                cbxSucursal.SelectedIndex = -1;

                txtCINit.Clear();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Venta venta = new Venta();

                if (cbxCliente.SelectedIndex == -1 ||
                    cbxEmpleado.SelectedIndex == -1 ||
                    cbxSucursal.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione el cliente, empleado y sucursal.");
                    return;
                }

                venta.idCliente = Convert.ToInt32(cbxCliente.SelectedValue);
                venta.idEmpleado = Convert.ToInt32(cbxEmpleado.SelectedValue);
                venta.idSucursal = Convert.ToInt32(cbxSucursal.SelectedValue);

                venta.fechaVenta = dtpFechaVenta.Value.Date;
                venta.tipoPago = cbxTipoPago.SelectedItem.ToString();
                venta.montoTotal = nudTotalVenta.Value;

                if (idVenta.HasValue)
                {
                    venta.id = idVenta.Value;
                    VentaCln.actualizar(venta);

                    MessageBox.Show("Venta actualizada correctamente.");
                }
                else
                {
                    if (Util.usuario == null)
                    {
                        MessageBox.Show("No existe un usuario autenticado. Inicie sesión nuevamente.");
                        return;
                    }

                    venta.usuarioRegistro = Util.usuario.nombreUsuario;
                    venta.fechaRegistro = DateTime.Now;
                    venta.estado = 1;

                    VentaCln.crear(venta);

                    MessageBox.Show("Venta registrada correctamente.");
                }

                Close();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                string errores = "";

                foreach (var entidad in ex.EntityValidationErrors)
                {
                    errores += "\nEntidad: " + entidad.Entry.Entity.GetType().Name;

                    foreach (var error in entidad.ValidationErrors)
                    {
                        errores += "\nCampo: " + error.PropertyName;
                        errores += "\nError: " + error.ErrorMessage + "\n";
                    }
                }

                MessageBox.Show(errores, "Errores de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void configurarBuscador(ComboBox combo)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDown;

            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cargarCombos()
        {
            // Cargar clientes
            listaClientes = VentaCln.listarClientesCombo();

            if (listaClientes == null)
                listaClientes = new List<Cliente>();

            cbxCliente.DataSource = listaClientes.Select(x => new
            {
                id = x.id,
                nombre = (string.IsNullOrEmpty(x.razonSocial)
                    ? x.nombres + " " + x.primerApellido
                    : x.razonSocial)
            }).ToList();

            cbxCliente.DisplayMember = "nombre";
            cbxCliente.ValueMember = "id";


            // Cargar empleados
            var empleados = VentaCln.listarEmpleadosCombo();

            cbxEmpleado.DataSource = empleados.Select(x => new
            {
                id = x.id,
                nombre = x.nombres + " " + x.primerApellido
            }).ToList();

            cbxEmpleado.DisplayMember = "nombre";
            cbxEmpleado.ValueMember = "id";


            // Cargar sucursales
            var sucursales = VentaCln.listarSucursalesCombo();

            cbxSucursal.DataSource = sucursales.Select(x => new
            {
                id = x.id,
                nombre = x.nombre
            }).ToList();

            cbxSucursal.DisplayMember = "nombre";
            cbxSucursal.ValueMember = "id";
        }
        private void cbxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCliente.SelectedIndex == -1 ||
                cbxCliente.SelectedValue == null ||
                !(cbxCliente.SelectedValue is int))
            {
                txtCINit.Clear();
                return;
            }

            int idCliente = Convert.ToInt32(cbxCliente.SelectedValue);

            var cliente = listaClientes.FirstOrDefault(x => x.id == idCliente);

            if (cliente != null)
                txtCINit.Text = cliente.nitCi;
            else
                txtCINit.Clear();
        }
    }
}
