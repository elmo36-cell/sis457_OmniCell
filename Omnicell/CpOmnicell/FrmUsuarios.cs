using CadOmnicell;
using ClnOmnicell;
using CpMinerva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CpOmnicell
{
    public partial class FrmUsuarios : FormOmnicell
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
                nombreCompleto = x.NombreCompleto()
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
                    Util.Avisar("Seleccione un empleado.");
                    cbxNombre.Focus();
                    return;
                }

                if (cbxRol.SelectedValue == null)
                {
                    Util.Avisar("Seleccione un rol.");
                    cbxRol.Focus();
                    return;
                }

                if (!Util.Requerido(txtNombreUsuario, "Ingrese un nombre de usuario."))
                    return;

                if (!idUsuario.HasValue && string.IsNullOrWhiteSpace(txtClave.Text))
                {
                    Util.Avisar("Ingrese una contraseña.");
                    txtClave.Focus();
                    return;
                }

                Usuario usuario = new Usuario
                {
                    idEmpleado = Convert.ToInt32(cbxNombre.SelectedValue),
                    idRol = Convert.ToInt32(cbxRol.SelectedValue),
                    nombreUsuario = txtNombreUsuario.Text.Trim(),

                    // Solo se cifra la contraseña cuando se introduce una nueva.
                    clave = string.IsNullOrWhiteSpace(txtClave.Text)
                        ? null
                        : SeguridadCln.cifrar(txtClave.Text)
                };

                if (idUsuario.HasValue)
                {
                    usuario.id = idUsuario.Value;

                    UsuarioCln.actualizar(usuario);

                    Util.Informar("Usuario actualizado correctamente.");
                }
                else
                {
                    usuario.usuarioRegistro = SesionCln.NombreUsuario;
                    usuario.fechaRegistro = DateTime.Now;
                    usuario.estado = (int)Estado.Activo;

                    UsuarioCln.crear(usuario);

                    Util.Informar("Usuario registrado correctamente.");
                }

                Close();
            }
            catch (Exception ex)
            {
                Util.MostrarError(ex.Message, "Error");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
