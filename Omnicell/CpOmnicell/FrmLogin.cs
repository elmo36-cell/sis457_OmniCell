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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnInicioCliente_Click(object sender, EventArgs e)
        {
            FrmMenuCliente frmMenuCliente = new FrmMenuCliente();
            frmMenuCliente.Show();
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
                // Encriptar contraseña
                string claveEncriptada = Util.Encrypt(txtClave.Text);

                // Autenticar usuario
                Usuario usuario = UsuarioCln.autenticar(
                    txtUsuarios.Text.Trim(),
                    claveEncriptada
                );

                // Guardar usuario en sesión
                Util.usuario = usuario;

                MessageBox.Show(
                    $"Bienvenido a OmniCell, {usuario.nombreUsuario}",
                    "Inicio de sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Abrir menú principal
                this.Hide();

                FrmMenuVendedor menu = new FrmMenuVendedor();
                menu.ShowDialog();

                this.Close();
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

        private void restablecerClaveAdmin()
        {
            Usuario usuario = UsuarioCln.obtenerUno(1);

            usuario.clave = Util.Encrypt("Admin123");

            usuario.usuarioRegistro = "admin";

            UsuarioCln.actualizar(usuario);

            MessageBox.Show("Contraseña restablecida correctamente.");
        }
    }
}
