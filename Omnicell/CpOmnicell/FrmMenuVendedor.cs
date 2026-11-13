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
            gbxVentas.Visible = false;
            gbxCompras.Visible = false;
        }
        private void btnHistorialVentas_Click(object sender, EventArgs e)
        {
            gbxCompras.Visible = false;
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
        private void btnHCompras_Click(object sender, EventArgs e)
        {
            gbxVentas.Visible = false;
            gbxCompras.Visible = true;

            gbxCompras.BringToFront();

            listarCompras();
        }
        //listas

        //lista de ventas
        private void listarVentas()
        {
            dgvListaVentas.DataSource = VentaCln.listarVentas(txtParametro.Text);

            // Crear columna de numeración visual si todavía no existe
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

            // Numeración consecutiva
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarVentas();
        }
        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listarVentas();
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


        //lista de compras
        private void listarCompras()
        {
            dgvListaCompras.DataSource = CompraCln.listarCompras(txtParametro.Text);

            dgvListaCompras.Columns["id"].HeaderText = "N° Compra";
            dgvListaCompras.Columns["fechaCompra"].HeaderText = "Fecha";
            dgvListaCompras.Columns["proveedor"].HeaderText = "Proveedor";
            dgvListaCompras.Columns["pais"].HeaderText = "País";
            dgvListaCompras.Columns["empleado"].HeaderText = "Empleado";
            dgvListaCompras.Columns["factura"].HeaderText = "Factura";
            dgvListaCompras.Columns["costoTotal"].HeaderText = "Costo total (Bs)";
            dgvListaCompras.Columns["fechaCompra"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvListaCompras.Columns["costoTotal"].DefaultCellStyle.Format = "N2";
        }





    }
}
