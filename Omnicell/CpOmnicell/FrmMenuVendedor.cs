using CadOmnicell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClnOmnicell;
using CpMinerva;
using CpOmnicell.Properties;

namespace CpOmnicell
{
    public partial class FrmMenuVendedor : Form
    {

        //funciones Menu Vendedor

        public FrmMenuVendedor()
        {
            InitializeComponent();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ribbonButton18_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmMenuVendedor_Load(object sender, EventArgs e)
        {
            listarVentas();
            listarCompras();
            listarClientes();
            gbxVentas.Visible = false;
            gbxCompras.Visible = false;
            gbxClientes.Visible = false;
        }


        // SECCION VENTAS

        private void btnHistorialVentas_Click(object sender, EventArgs e)
        {
            gbxCompras.Visible = false;
            gbxClientes.Visible = false;
            gbxVentas.Visible = true;

            gbxVentas.BringToFront();
            listarVentas();
        }
        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            FrmVentas frmVentas = new FrmVentas();
            frmVentas.ShowDialog();

            listarVentas();
        }
        //lista de ventas
        private void listarVentas()
        {
            dgvListaVentas.DataSource = VentaCln.listarVentas(txtParametro.Text);

            if (!dgvListaVentas.Columns.Contains("colNumero"))
            {
                DataGridViewTextBoxColumn columnaNumero = new DataGridViewTextBoxColumn();

                columnaNumero.Name = "colNumero";
                columnaNumero.HeaderText = "N.º de Venta";
                columnaNumero.ReadOnly = true;
                columnaNumero.Width = 50;
                columnaNumero.SortMode = DataGridViewColumnSortMode.NotSortable;
                columnaNumero.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvListaVentas.Columns.Insert(0, columnaNumero);
            }

            // Configurar encabezados
            dgvListaVentas.Columns["id"].HeaderText = "ID Venta";
            dgvListaVentas.Columns["fechaVenta"].HeaderText = "Fecha";
            dgvListaVentas.Columns["cliente"].HeaderText = "Cliente";
            dgvListaVentas.Columns["nitCi"].HeaderText = "CI / NIT";
            dgvListaVentas.Columns["vendedor"].HeaderText = "Vendedor";
            dgvListaVentas.Columns["sucursal"].HeaderText = "Sucursal";
            dgvListaVentas.Columns["tipoPago"].HeaderText = "Tipo de pago";
            dgvListaVentas.Columns["montoTotal"].HeaderText = "Total (Bs)";

            // Formato de columnas
            dgvListaVentas.Columns["fechaVenta"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvListaVentas.Columns["montoTotal"].DefaultCellStyle.Format = "N2";

            int numero = 1;

            foreach (DataGridViewRow fila in dgvListaVentas.Rows)
            {
                if (!fila.IsNewRow)
                {
                    fila.Cells["colNumero"].Value = numero;
                    numero++;
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListaVentas.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una venta para dar de baja.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int id = Convert.ToInt32(
                    dgvListaVentas.CurrentRow.Cells["id"].Value
                );
                DialogResult dialog = MessageBox.Show(
                    $"¿Está seguro que desea dar de baja la venta {id}?",
                    "::: Confirmación - OmniCell :::",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (dialog == DialogResult.Yes)
                {
                    VentaCln.eliminar(id, Util.usuario.nombreUsuario);

                    listarVentas();

                    MessageBox.Show(
                        "Venta dada de baja correctamente.",
                        "::: Mensaje - OmniCell :::",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo dar de baja la venta.\nDetalle: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvListaVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta para editar");
                return;
            }

            int id = Convert.ToInt32(
                dgvListaVentas.CurrentRow.Cells["id"].Value
            );

            FrmVentas formulario = new FrmVentas(id);
            formulario.ShowDialog();

            listarVentas();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarVentas();
        }
        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listarVentas();
        }

        // SECCION COMPRAS
        private void btnHCompras_Click(object sender, EventArgs e)
        {
            gbxVentas.Visible = false;
            gbxClientes.Visible = false;
            gbxCompras.Visible = true;

            gbxCompras.BringToFront();

            listarCompras();
        }
        private void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            FrmCompras frmCompras = new FrmCompras();
            frmCompras.ShowDialog();

            listarCompras();
        }
        //lista de compras
        private void listarCompras()
        {
            dgvListaCompras.DataSource = CompraCln.listarCompras(txtParametro.Text.Trim());

            if (!dgvListaCompras.Columns.Contains("colNumero"))
            {
                DataGridViewTextBoxColumn columnaNumero = new DataGridViewTextBoxColumn();

                columnaNumero.Name = "colNumero";
                columnaNumero.HeaderText = "N.º de Compra";
                columnaNumero.ReadOnly = true;
                columnaNumero.Width = 50;
                columnaNumero.SortMode = DataGridViewColumnSortMode.NotSortable;
                columnaNumero.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvListaCompras.Columns.Insert(0, columnaNumero);
            }

            dgvListaCompras.Columns["id"].HeaderText = "ID De Compra";
            dgvListaCompras.Columns["fechaCompra"].HeaderText = "Fecha";
            dgvListaCompras.Columns["proveedor"].HeaderText = "Proveedor";
            dgvListaCompras.Columns["pais"].HeaderText = "País";
            dgvListaCompras.Columns["empleado"].HeaderText = "Empleado";
            dgvListaCompras.Columns["factura"].HeaderText = "Factura";
            dgvListaCompras.Columns["costoTotal"].HeaderText = "Costo total (Bs)";

            dgvListaCompras.Columns["fechaCompra"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvListaCompras.Columns["costoTotal"].DefaultCellStyle.Format = "N2";

            int numero = 1;

            foreach (DataGridViewRow fila in dgvListaCompras.Rows)
            {
                if (!fila.IsNewRow)
                {
                    fila.Cells["colNumero"].Value = numero;
                    numero++;
                }
            }
        }
        private void btnEliminarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListaCompras.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una compra para dar de baja.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int id = Convert.ToInt32(
                    dgvListaCompras.CurrentRow.Cells["id"].Value
                );
                DialogResult dialog = MessageBox.Show(
                    $"¿Está seguro que desea dar de baja la compra {id}?",
                    "::: Confirmación - OmniCell :::",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (dialog == DialogResult.Yes)
                {
                    CompraCln.eliminar(id, Util.usuario.nombreUsuario);

                    listarCompras();

                    MessageBox.Show(
                        "Compra dada de baja correctamente.",
                        "::: Mensaje - OmniCell :::",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo dar de baja la compra.\nDetalle: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void btnEditarCompras_Click(object sender, EventArgs e)
        {
            if (dgvListaCompras.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una compra para editar");
                return;
            }

            int id = Convert.ToInt32(
                dgvListaCompras.CurrentRow.Cells["id"].Value
            );

            FrmCompras formulario = new FrmCompras(id);
            formulario.ShowDialog();

            listarCompras();
        }
        private void btnBuscarCompras_Click(object sender, EventArgs e)
        {
            listarCompras();
        }

        private void txtBuscarCompras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listarCompras();
        }

        // SECCION CLIENTES

        private void btnClientes_Click(object sender, EventArgs e)
        {
            gbxCompras.Visible = false;
            gbxVentas.Visible = false;
            gbxClientes.Visible = true;

            gbxClientes.BringToFront();
            listarClientes();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();
            frmClientes.ShowDialog();

            listarClientes();
        }

        //lista de clientes
        private void listarClientes()
        {
            dgvListaClientes.DataSource = ClienteCln.listarClientes(txtBuscarCliente.Text.Trim());

            if (!dgvListaClientes.Columns.Contains("colNumero"))
            {
                DataGridViewTextBoxColumn columnaNumero = new DataGridViewTextBoxColumn();

                columnaNumero.Name = "colNumero";
                columnaNumero.HeaderText = "N.º de Cliente";
                columnaNumero.ReadOnly = true;
                columnaNumero.Width = 50;
                columnaNumero.SortMode = DataGridViewColumnSortMode.NotSortable;
                columnaNumero.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvListaClientes.Columns.Insert(0, columnaNumero);
            }

            dgvListaClientes.Columns["id"].HeaderText = "ID De Cliente";
            dgvListaClientes.Columns["nombres"].HeaderText = "Nombre";
            dgvListaClientes.Columns["primerApellido"].HeaderText = "Primer Apellido";
            dgvListaClientes.Columns["segundoApellido"].HeaderText = "Segundo Apellido";
            dgvListaClientes.Columns["razonSocial"].HeaderText = "Razón Social";
            dgvListaClientes.Columns["telefono"].HeaderText = "Teléfono";
            dgvListaClientes.Columns["direccion"].HeaderText = "Dirección";
            dgvListaClientes.Columns["tipoCliente"].HeaderText = "Tipo de Cliente";

            int numero = 1;

            foreach (DataGridViewRow fila in dgvListaClientes.Rows)
            {
                if (!fila.IsNewRow)
                {
                    fila.Cells["colNumero"].Value = numero;
                    numero++;
                }
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListaClientes.CurrentRow == null ||
                    dgvListaClientes.CurrentRow.IsNewRow)
                {
                    MessageBox.Show("Seleccione un cliente.");
                    return;
                }

                int id = Convert.ToInt32(
                    dgvListaClientes.CurrentRow.Cells["id"].Value
                );

                DialogResult dialog = MessageBox.Show(
                    $"¿Está seguro que desea dar de baja al cliente con ID {id}?",
                    "::: Confirmación - OmniCell :::",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialog == DialogResult.Yes)
                {
                    if (Util.usuario == null)
                    {
                        MessageBox.Show("No se encontró el usuario de sesión.");
                        return;
                    }

                    ClienteCln.eliminar(id, Util.usuario.nombreUsuario);

                    MessageBox.Show("Cliente eliminado correctamente.");

                    listarClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar el cliente:\n\n" + ex.ToString(),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (dgvListaClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente.");
                return;
            }

            int id = Convert.ToInt32(
                dgvListaClientes.CurrentRow.Cells["id"].Value
            );

            FrmClientes frmClientes = new FrmClientes(id);

            frmClientes.ShowDialog();

            listarClientes();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            listarClientes();
        }

        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listarVentas();
        }
    }
}
