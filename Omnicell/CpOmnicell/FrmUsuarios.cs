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
    public partial class FrmUsuarios : Form
    {
        private int? idUsuario;
        private List<Empleado> empleados;

        public FrmUsuarios()
        {
            InitializeComponent();
            idUsuario = null;

            cbxNombre.SelectedIndexChanged += cbxNombre_SelectedIndexChanged;
        }

        public FrmUsuarios(int id)
        {
            InitializeComponent();
            idUsuario = id;

            cbxNombre.SelectedIndexChanged += cbxNombre_SelectedIndexChanged;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            cargarCombos();

            if (idUsuario.HasValue)
            {
                cargarUsuario();
            }
            else
            {
                cbxNombre.SelectedIndex = -1;
                cbxRol.SelectedIndex = -1;
                txtCargo.Clear();
                txtNombreUsuario.Clear();
                txtClave.Clear();
            }
        }
        private void cargarCombos()
        {
            // Cargar empleados
            empleados = UsuarioCln.listarEmpleadosCombo();

            cbxNombre.DataSource = empleados.Select(x => new
            {
                id = x.id,
                nombreCompleto = string.Join(" ",
                    new[] { x.nombres, x.primerApellido, x.segundoApellido }
                    .Where(nombre => !string.IsNullOrWhiteSpace(nombre)))
            }).ToList();

            cbxNombre.DisplayMember = "nombreCompleto";
            cbxNombre.ValueMember = "id";
            cbxNombre.SelectedIndex = -1;

            // Cargar roles
            cbxRol.DataSource = UsuarioCln.listarRolesCombo();
            cbxRol.DisplayMember = "nombre";
            cbxRol.ValueMember = "id";
            cbxRol.SelectedIndex = -1;
        }

        private void cbxNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxNombre.SelectedValue == null)
            {
                txtCargo.Clear();
                return;
            }

            if (int.TryParse(cbxNombre.SelectedValue.ToString(), out int id))
            {
                Empleado empleado = empleados.FirstOrDefault(x => x.id == id);

                if (empleado != null)
                {
                    txtCargo.Text = empleado.cargo;
                }
            }
        }
        private void cargarUsuario()
        {
            Usuario usuario = UsuarioCln.obtenerUno(idUsuario.Value);

            cbxNombre.SelectedValue = usuario.idEmpleado;
            cbxRol.SelectedValue = usuario.idRol;

            txtNombreUsuario.Text = usuario.nombreUsuario;

            // Por seguridad, no mostramos la contraseña cifrada.
            txtClave.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxNombre.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un empleado.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxNombre.Focus();
                    return;
                }

                if (cbxRol.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un rol.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxRol.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
                {
                    MessageBox.Show("Ingrese un nombre de usuario.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreUsuario.Focus();
                    return;
                }

                if (!idUsuario.HasValue && string.IsNullOrWhiteSpace(txtClave.Text))
                {
                    MessageBox.Show("Ingrese una contraseña.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClave.Focus();
                    return;
                }

                if (Util.usuario == null)
                {
                    MessageBox.Show("No se encontró la sesión del usuario actual.");
                    return;
                }

                Usuario usuario = new Usuario();

                usuario.idEmpleado = Convert.ToInt32(cbxNombre.SelectedValue);
                usuario.idRol = Convert.ToInt32(cbxRol.SelectedValue);
                usuario.nombreUsuario = txtNombreUsuario.Text.Trim();

                // Solo se cifra la contraseña cuando se introduce una nueva.
                usuario.clave = string.IsNullOrWhiteSpace(txtClave.Text)
                    ? null
                    : Util.Encrypt(txtClave.Text);

                if (idUsuario.HasValue)
                {
                    usuario.id = idUsuario.Value;

                    UsuarioCln.actualizar(usuario);

                    MessageBox.Show("Usuario actualizado correctamente.",
                        "OmniCell", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    usuario.usuarioRegistro = Util.usuario.nombreUsuario;
                    usuario.fechaRegistro = DateTime.Now;
                    usuario.estado = 1;

                    UsuarioCln.crear(usuario);

                    MessageBox.Show("Usuario registrado correctamente.",
                        "OmniCell", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
