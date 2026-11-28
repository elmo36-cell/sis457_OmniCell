using ClnOmnicell;
using CpMinerva;
using System;
using System.Windows.Forms;

namespace CpOmnicell
{
    public partial class FrmLogin : FormOmnicell
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            // Limpiar errores anteriores
            erpUsuario.Clear();
            erpClave.Clear();

            bool valido = true;

            // Validar usuario
            if (string.IsNullOrWhiteSpace(txtUsuarios.Text))
            {
                erpUsuario.SetError(txtUsuarios, "Ingrese su nombre de usuario.");
                valido = false;
            }

            // Validar contraseña
            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                erpClave.SetError(txtClave, "Ingrese su contraseña.");
                valido = false;
            }

            if (!valido)
                return;

            try
            {
                // La capa de negocio cifra la clave y autentica al usuario.
                var usuario = UsuarioCln.iniciarSesion(txtUsuarios.Text, txtClave.Text);

                SesionCln.abrir(usuario);

                Util.Informar(
                    $"Bienvenido a OmniCell, {usuario.nombreUsuario}",
                    "Inicio de sesión"
                );

                // Abrir menú principal
                Hide();

                using (FrmMenuVendedor menu = new FrmMenuVendedor())
                {
                    menu.ShowDialog();
                }

                txtClave.Clear();
                txtUsuarios.Focus();

                Show();
            }
            catch (Exception ex)
            {
                erpUsuario.SetError(txtUsuarios, ex.Message);
                erpClave.SetError(txtClave, ex.Message);

                txtClave.Clear();
                txtClave.Focus();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            erpUsuario.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            erpClave.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            txtClave.UseSystemPasswordChar = true;
        }

        private void txtUsuarios_TextChanged(object sender, EventArgs e)
        {
            erpUsuario.SetError(txtUsuarios, "");
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            erpClave.SetError(txtClave, "");
        }
    }
}
