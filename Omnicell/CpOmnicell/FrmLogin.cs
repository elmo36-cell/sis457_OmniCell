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

        private void FrmLogin_Load(object sender, EventArgs e)
        {

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
            FrmMenuVendedor frmMenuVendedor = new FrmMenuVendedor();
            frmMenuVendedor.Show();
        }
    }
}
