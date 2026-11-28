using CadOmnicell;
using ClnOmnicell;
using CpMinerva;
using System;
using System.Windows.Forms;

namespace CpOmnicell
{
    public partial class FrmClientes : FormOmnicell
    {
        private int? idCliente;

        // Id del cliente recién registrado, para que el formulario que lo abrió pueda seleccionarlo.
        public int? IdClienteRegistrado { get; private set; }

        public FrmClientes()
        {
            InitializeComponent();
            idCliente = null;
        }

        public FrmClientes(int id)
        {
            InitializeComponent();
            idCliente = id;
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            configurarCINit();
            cargarTiposCliente();

            if (idCliente.HasValue)
            {
                cargarCliente();
            }
            else
            {
                cbxTipoCliente.SelectedIndex = -1;
            }
        }

        // El CI/NIT se escribe solo con números; el filtro se aplica al teclear.
        private void configurarCINit()
        {
            txtCINit.KeyPress -= Util.SoloNumeros;
            txtCINit.KeyPress += Util.SoloNumeros;
        }

        private void cargarTiposCliente()
        {
            cbxTipoCliente.DataSource = ClienteCln.listarTiposClienteCombo();

            cbxTipoCliente.SelectedIndex = -1;
        }

        private void cargarCliente()
        {
            var cliente = ClienteCln.obtenerUno(idCliente.Value);

            txtNombre.Text = cliente.nombres;
            txtPrimerApellido.Text = cliente.primerApellido;
            txtSegundoApellido.Text = cliente.segundoApellido;
            txtCINit.Text = cliente.nitCi;
            txtRazonSocial.Text = cliente.razonSocial;
            cbxTipoCliente.SelectedItem = cliente.tipoCliente;
            txtTelefono.Text = cliente.telefono;
            txtDireccion.Text = cliente.direccion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Util.Requerido(txtCINit, "Ingrese el CI/NIT del cliente."))
                return;

            if (!Util.SoloDigitos(txtCINit.Text.Trim()))
            {
                Util.Avisar("El CI/NIT solo admite números.");
                txtCINit.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) &&
                string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                Util.Avisar("Ingrese el nombre o la razón social del cliente.");
                txtNombre.Focus();
                return;
            }

            if (cbxTipoCliente.SelectedIndex == -1)
            {
                Util.Avisar("Seleccione el tipo de cliente.");
                cbxTipoCliente.Focus();
                return;
            }

            try
            {
                Cliente cliente = new Cliente
                {
                    nitCi = txtCINit.Text.Trim(),
                    nombres = txtNombre.Text.Trim(),
                    primerApellido = txtPrimerApellido.Text.Trim(),
                    segundoApellido = txtSegundoApellido.Text.Trim(),
                    razonSocial = txtRazonSocial.Text.Trim(),
                    tipoCliente = cbxTipoCliente.SelectedItem.ToString(),
                    telefono = txtTelefono.Text.Trim(),
                    direccion = txtDireccion.Text.Trim()
                };

                if (idCliente.HasValue)
                {
                    cliente.id = idCliente.Value;

                    ClienteCln.actualizar(cliente);

                    Util.Informar("Cliente actualizado correctamente.");
                }
                else
                {
                    cliente.usuarioRegistro = SesionCln.NombreUsuario;
                    cliente.fechaRegistro = DateTime.Now;
                    cliente.estado = (int)Estado.Activo;

                    // INSERT del cliente; el id generado queda en IdClienteRegistrado.
                    ClienteCln.crear(cliente);

                    IdClienteRegistrado = cliente.id;

                    Util.Informar("Cliente registrado correctamente.");
                }

                Close();
            }
            catch (Exception ex)
            {
                Util.MostrarError("Error al guardar el cliente: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
