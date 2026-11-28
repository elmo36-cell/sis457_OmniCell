using CadOmnicell;
using ClnOmnicell;
using CpMinerva;
using System;
using System.Windows.Forms;

namespace CpOmnicell
{
    public partial class FrmProveedores : FormOmnicell
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
            if (!Util.Requerido(txtRazonSocial, "Ingrese la razón social del proveedor."))
                return;

            if (!Util.Requerido(txtPais, "Ingrese el país del proveedor."))
                return;

            if (!Util.Requerido(txtContacto, "Ingrese el nombre de la persona de contacto."))
                return;

            if (!Util.Requerido(txtTelefono, "Ingrese el teléfono del proveedor."))
                return;

            try
            {
                Proveedor proveedor = new Proveedor
                {
                    razonSocial = txtRazonSocial.Text.Trim(),
                    pais = txtPais.Text.Trim(),
                    contactoPersona = txtContacto.Text.Trim(),
                    telefono = txtTelefono.Text.Trim()
                };

                if (idProveedor.HasValue)
                {
                    proveedor.id = idProveedor.Value;

                    ProveedorCln.actualizar(proveedor);

                    Util.Informar("Proveedor actualizado correctamente.");
                }
                else
                {
                    proveedor.usuarioRegistro = SesionCln.NombreUsuario;
                    proveedor.fechaRegistro = DateTime.Now;
                    proveedor.estado = (int)Estado.Activo;

                    ProveedorCln.crear(proveedor);

                    Util.Informar("Proveedor registrado correctamente.");
                }

                Close();
            }
            catch (Exception ex)
            {
                Util.MostrarError("Error al guardar el proveedor:\n\n" + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
