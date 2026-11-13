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
    public partial class FrmClientes : Form
    {
        private int? idCliente;
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
        private void cargarTiposCliente()
        {
            cbxTipoCliente.DataSource =
                ClienteCln.listarTiposClienteCombo();

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
            if (string.IsNullOrWhiteSpace(txtCINit.Text))
            {
                MessageBox.Show("Ingrese el CI/NIT del cliente.");
                txtCINit.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) &&
                string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                MessageBox.Show("Ingrese el nombre o la razón social del cliente.");
                txtNombre.Focus();
                return;
            }

            if (cbxTipoCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de cliente.");
                cbxTipoCliente.Focus();
                return;
            }

            if (Util.usuario == null)
            {
                MessageBox.Show("No se encontró el usuario de sesión.");
                return;
            }

            try
            {
                Cliente cliente = new Cliente();

                cliente.nitCi = txtCINit.Text.Trim();
                cliente.nombres = txtNombre.Text.Trim();
                cliente.primerApellido = txtPrimerApellido.Text.Trim();
                cliente.segundoApellido = txtSegundoApellido.Text.Trim();
                cliente.razonSocial = txtRazonSocial.Text.Trim();
                cliente.tipoCliente = cbxTipoCliente.SelectedItem.ToString();
                cliente.telefono = txtTelefono.Text.Trim();
                cliente.direccion = txtDireccion.Text.Trim();

                if (idCliente.HasValue)
                {
                    cliente.id = idCliente.Value;

                    ClienteCln.actualizar(cliente);

                    MessageBox.Show("Cliente actualizado correctamente.");
                }
                else
                {
                    cliente.usuarioRegistro = Util.usuario.nombreUsuario;
                    cliente.fechaRegistro = DateTime.Now;
                    cliente.estado = 1;

                    ClienteCln.crear(cliente);

                    MessageBox.Show("Cliente registrado correctamente.");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cliente: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
