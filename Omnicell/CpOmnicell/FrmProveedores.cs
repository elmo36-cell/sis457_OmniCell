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
    public partial class FrmProveedores : Form
    {
        private int? idProveedor;
        public FrmProveedores()
        {
            InitializeComponent();
            idProveedor = null;
        }

        public FrmProveedores(int id)
        {
            InitializeComponent();
            idProveedor = id;
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            if (idProveedor.HasValue)
            {
                cargarProveedor();
            }
            else
            {
                limpiarCampos();
            }
        }
        private void cargarProveedor()
        {
            var proveedor = ProveedorCln.obtenerUno(idProveedor.Value);

            txtRazonSocial.Text = proveedor.razonSocial;
            txtPais.Text = proveedor.pais;
            txtContacto.Text = proveedor.contactoPersona;
            txtTelefono.Text = proveedor.telefono;
        }
        private void limpiarCampos()
        {
            txtRazonSocial.Clear();
            txtPais.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                MessageBox.Show("Ingrese la razón social del proveedor.");
                txtRazonSocial.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPais.Text))
            {
                MessageBox.Show("Ingrese el país del proveedor.");
                txtPais.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContacto.Text))
            {
                MessageBox.Show("Ingrese el nombre de la persona de contacto.");
                txtContacto.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese el teléfono del proveedor.");
                txtTelefono.Focus();
                return;
            }

            if (Util.usuario == null)
            {
                MessageBox.Show("No se encontró el usuario de sesión.");
                return;
            }

            try
            {
                Proveedor proveedor = new Proveedor();

                proveedor.razonSocial = txtRazonSocial.Text.Trim();
                proveedor.pais = txtPais.Text.Trim();
                proveedor.contactoPersona = txtContacto.Text.Trim();
                proveedor.telefono = txtTelefono.Text.Trim();

                if (idProveedor.HasValue)
                {
                    proveedor.id = idProveedor.Value;

                    ProveedorCln.actualizar(proveedor);

                    MessageBox.Show(
                        "Proveedor actualizado correctamente.",
                        "OmniCell",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    proveedor.usuarioRegistro = Util.usuario.nombreUsuario;
                    proveedor.fechaRegistro = DateTime.Now;
                    proveedor.estado = 1;

                    ProveedorCln.crear(proveedor);

                    MessageBox.Show(
                        "Proveedor registrado correctamente.",
                        "OmniCell",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar el proveedor:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
