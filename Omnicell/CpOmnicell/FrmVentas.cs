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
    public partial class FrmVentas : Form
    {
        private List<Cliente> listaClientes = new List<Cliente>();

        private List<paPantallaListarPorSucursal_Result> listaPantallas =
            new List<paPantallaListarPorSucursal_Result>();

        private int idSucursalSesion;

        public FrmVentas()
        {
            InitializeComponent();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            configurarDgvProductos();
            try
            {
                configurarTipoPago();
                cargarClientes();
                cargarEmpleadoSesion();
                cargarPantallas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al cargar ventas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void configurarTipoPago()
        {
            cbxTipoPago.Items.Clear();

            cbxTipoPago.Items.Add("Efectivo");
            cbxTipoPago.Items.Add("QR");
            cbxTipoPago.Items.Add("Transferencia");

            cbxTipoPago.SelectedIndex = -1;

            gbxEfectivo.Visible = false;

            nudRecibido.Value = 0;
            txtCambio.Text = "0.00";

            cbxTipoPago.SelectedIndexChanged +=
                cbxTipoPago_SelectedIndexChanged;
        }
        private void cbxTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esEfectivo = cbxTipoPago.SelectedItem?.ToString() == "Efectivo";

            gbxEfectivo.Visible = esEfectivo;

            if (!esEfectivo)
            {
                nudRecibido.Value = 0;
                txtCambio.Text = "0.00";
            }
        }
        private void cargarClientes()
        {
            listaClientes = VentaCln.listarClientesCombo();

            if (listaClientes == null)
                listaClientes = new List<Cliente>();

            cbxCiNit.DataSource = null;

            cbxCiNit.DataSource = listaClientes.Select(x => new
            {
                id = x.id,
                nitCi = x.nitCi
            }).ToList();

            cbxCiNit.DisplayMember = "nitCi";
            cbxCiNit.ValueMember = "id";

            cbxCiNit.SelectedIndex = -1;

            txtCliente.Clear();
            txtTelefono.Clear();
        }
        private void cargarEmpleadoSesion()
        {
            if (Util.usuario == null)
                throw new Exception(
                    "No existe un usuario autenticado. Inicie sesión nuevamente."
                );

            int idEmpleado = Util.usuario.idEmpleado;

            Empleado empleado =
                EmpleadoCln.obtenerConSucursal(idEmpleado);

            if (!empleado.idSucursal.HasValue ||
                empleado.Sucursal == null)
            {
                throw new Exception(
                    "El empleado no tiene una sucursal asignada."
                );
            }

            idSucursalSesion = empleado.idSucursal.Value;

            txtEmpleado.Text =
                empleado.nombres + " " +
                empleado.primerApellido + " " +
                empleado.segundoApellido;

            txtSucursal.Text = empleado.Sucursal.nombre;

            txtEmpleado.ReadOnly = true;
            txtSucursal.ReadOnly = true;

            dtpFechaVenta.Value = DateTime.Today;
            dtpFechaVenta.Enabled = false;
        }
        private void cargarPantallas(string parametro = "")
        {
            listaPantallas = PantallaCln.listarPorSucursal(
                idSucursalSesion,
                parametro
            );

            if (listaPantallas == null)
                listaPantallas =
                    new List<paPantallaListarPorSucursal_Result>();

            cbxPantalla.DataSource = null;

            cbxPantalla.DataSource = listaPantallas.Select(x => new
            {
                id = x.id,
                sku = x.sku
            }).ToList();

            cbxPantalla.DisplayMember = "sku";
            cbxPantalla.ValueMember = "id";

            cbxPantalla.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPantalla.SelectedIndex = -1;

            limpiarDatosPantalla();
        }

        private void cbxPantalla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPantalla.SelectedValue == null ||
      !(cbxPantalla.SelectedValue is int))
            {
                return;
            }

            int idPantalla =
                Convert.ToInt32(cbxPantalla.SelectedValue);

            var pantalla = listaPantallas.FirstOrDefault(
                x => x.id == idPantalla
            );

            if (pantalla == null)
                return;

            // Mostrar stock y precio
            txtStock.Text = pantalla.stockActual.ToString("N2");

            txtPrecioVenta.Text =
                pantalla.precioVenta.ToString("N2");

            // Obtener marca y modelos compatibles
            Pantalla pantallaCompleta =
                PantallaCln.obtenerConCompatibilidad(pantalla.id);

            var modelos = pantallaCompleta.Compatibilidad
                .Where(c => c.estado == 1 && c.Modelo != null)
                .Select(c => c.Modelo)
                .Where(m => m.estado == 1)
                .GroupBy(m => m.id)
                .Select(g => g.First())
                .OrderBy(m => m.nombre)
                .ToList();

            cbxModelo.DataSource = null;
            cbxModelo.DisplayMember = "nombre";
            cbxModelo.ValueMember = "id";
            cbxModelo.DataSource = modelos;

            cbxModelo.Enabled = modelos.Count > 0;

            if (modelos.Count == 0)
            {
                txtMarca.Clear();
            }

            // Configurar cantidad máxima según existencias
            nudCantidad.DecimalPlaces = 0;
            nudCantidad.Minimum = 0;

            decimal stockDisponible =
                Math.Floor(pantalla.stockActual);

            nudCantidad.Maximum = Math.Max(1, stockDisponible);

            if (stockDisponible >= 1)
            {
                nudCantidad.Enabled = true;
                nudCantidad.Value = 1;
            }
            else
            {
                nudCantidad.Value = 0;
                nudCantidad.Enabled = false;
            }
        }
        private void cbxCiNit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCiNit.SelectedValue == null ||
     !(cbxCiNit.SelectedValue is int))
            {
                return;
            }

            int idCliente =
                Convert.ToInt32(cbxCiNit.SelectedValue);

            Cliente cliente = listaClientes.FirstOrDefault(
                x => x.id == idCliente
            );

            if (cliente != null)
            {
                txtCliente.Text =
                    string.IsNullOrEmpty(cliente.razonSocial)
                    ? cliente.nombres + " " +
                      cliente.primerApellido + " " +
                      cliente.segundoApellido
                    : cliente.razonSocial;

                txtTelefono.Text = cliente.telefono;
            }
        }

        private void limpiarDatosPantalla()
        {
            txtMarca.Clear();
            txtStock.Clear();
            txtPrecioVenta.Clear();

            nudCantidad.Value = 0;
            nudCantidad.Enabled = false;
        }
        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxPantalla.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione una pantalla.");
                    return;
                }

                if (cbxModelo.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un modelo compatible.");
                    return;
                }

                if (nudCantidad.Value <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida.");
                    return;
                }

                int idPantalla = Convert.ToInt32(cbxPantalla.SelectedValue);
                int idModelo = Convert.ToInt32(cbxModelo.SelectedValue);

                var pantalla = listaPantallas.FirstOrDefault(
                    x => x.id == idPantalla
                );

                if (pantalla == null)
                    throw new Exception("No se encontró la pantalla seleccionada.");

                decimal cantidad = nudCantidad.Value;
                decimal precio = pantalla.precioVenta;

                // Buscar el mismo SKU y modelo
                foreach (DataGridViewRow fila in dgvListaProductos.Rows)
                {
                    if (Convert.ToInt32(fila.Cells["colIdPantalla"].Value) == idPantalla &&
                        Convert.ToInt32(fila.Cells["colIdModelo"].Value) == idModelo)
                    {
                        decimal cantidadActual =
                            Convert.ToDecimal(fila.Cells["colCantidad"].Value);

                        decimal nuevaCantidad = cantidadActual + cantidad;

                        if (nuevaCantidad > pantalla.stockActual)
                        {
                            MessageBox.Show("La cantidad supera el stock disponible.");
                            return;
                        }

                        fila.Cells["colCantidad"].Value = nuevaCantidad;
                        fila.Cells["colSubtotal"].Value = nuevaCantidad * precio;

                        actualizarTotalVenta();
                        return;
                    }
                }

                if (cantidad > pantalla.stockActual)
                {
                    MessageBox.Show("No existe suficiente stock.");
                    return;
                }

                int numero = dgvListaProductos.Rows.Count + 1;

                dgvListaProductos.Rows.Add(
                    numero,
                    pantalla.id,
                    idModelo,
                    pantalla.sku,
                    pantalla.descripcion,
                    txtMarca.Text,
                    cbxModelo.Text,
                    pantalla.calidad,
                    cantidad,
                    precio,
                    cantidad * precio
                );

                actualizarTotalVenta();

                nudCantidad.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al agregar producto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void actualizarTotalVenta()
        {
            decimal total = 0;

            foreach (DataGridViewRow fila in dgvListaProductos.Rows)
            {
                total += Convert.ToDecimal(
                    fila.Cells["colSubtotal"].Value
                );
            }

            nudTotalVenta.Value = total;
        }
        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            if (dgvListaProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto de la lista.");
                return;
            }

            dgvListaProductos.Rows.Remove(
                dgvListaProductos.CurrentRow
            );

            // Actualizar numeración
            for (int i = 0; i < dgvListaProductos.Rows.Count; i++)
            {
                dgvListaProductos.Rows[i].Cells["colNumero"].Value = i + 1;
            }

            actualizarTotalVenta();
        }

        private void configurarDgvProductos()
        {
            dgvListaProductos.Columns.Clear();

            dgvListaProductos.AutoGenerateColumns = false;
            dgvListaProductos.AllowUserToAddRows = false;
            dgvListaProductos.AllowUserToDeleteRows = false;
            dgvListaProductos.ReadOnly = true;
            dgvListaProductos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvListaProductos.MultiSelect = false;
            dgvListaProductos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvListaProductos.Columns.Add("colNumero", "N°");
            dgvListaProductos.Columns.Add("colIdPantalla", "Id Pantalla");
            dgvListaProductos.Columns.Add("colIdModelo", "Id Modelo");
            dgvListaProductos.Columns.Add("colSku", "SKU");
            dgvListaProductos.Columns.Add("colDescripcion", "Descripción");
            dgvListaProductos.Columns.Add("colMarca", "Marca");
            dgvListaProductos.Columns.Add("colModelo", "Modelo");
            dgvListaProductos.Columns.Add("colCalidad", "Calidad");
            dgvListaProductos.Columns.Add("colCantidad", "Cantidad");
            dgvListaProductos.Columns.Add("colPrecio", "Precio unitario");
            dgvListaProductos.Columns.Add("colSubtotal", "Subtotal");

            dgvListaProductos.Columns["colIdPantalla"].Visible = false;
            dgvListaProductos.Columns["colIdModelo"].Visible = false;

            dgvListaProductos.Columns["colCantidad"].DefaultCellStyle.Format = "N0";
            dgvListaProductos.Columns["colPrecio"].DefaultCellStyle.Format = "N2";
            dgvListaProductos.Columns["colSubtotal"].DefaultCellStyle.Format = "N2";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar cliente.
                if (cbxCiNit.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un cliente.");
                    cbxCiNit.Focus();
                    return;
                }

                // Validar productos.
                if (dgvListaProductos.Rows.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos un producto.");
                    return;
                }

                // Validar tipo de pago.
                if (cbxTipoPago.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de pago.");
                    cbxTipoPago.Focus();
                    return;
                }

                // Obtener el empleado y su sucursal.
                var empleado = EmpleadoCln.obtenerConSucursal(
                    Util.usuario.idEmpleado
                );

                if (empleado.idSucursal == null)
                    throw new Exception(
                        "El empleado no tiene una sucursal asignada.");

                // Construir los detalles de la venta.
                List<VentaDetalle> detalles = new List<VentaDetalle>();

                foreach (DataGridViewRow fila in dgvListaProductos.Rows)
                {
                    detalles.Add(new VentaDetalle
                    {
                        idPantalla = Convert.ToInt32(
                            fila.Cells["colIdPantalla"].Value),

                        cantidad = Convert.ToDecimal(
                            fila.Cells["colCantidad"].Value),

                        precioUnitario = Convert.ToDecimal(
                            fila.Cells["colPrecio"].Value),

                        subtotal = Convert.ToDecimal(
                            fila.Cells["colSubtotal"].Value),

                        observacionGarantia = null
                    });
                }

                // Calcular el total.
                decimal total = detalles.Sum(d => d.cantidad * d.precioUnitario);

                // Validar pago en efectivo.
                if (cbxTipoPago.SelectedItem.ToString() == "Efectivo")
                {
                    if (nudRecibido.Value < total)
                    {
                        MessageBox.Show(
                            "El monto recibido es insuficiente.",
                            "Pago incompleto",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        nudRecibido.Focus();
                        return;
                    }
                }

                // Datos ingresados a la venta.
                Venta venta = new Venta
                {
                    idCliente = Convert.ToInt32(cbxCiNit.SelectedValue),
                    idEmpleado = empleado.id,
                    idSucursal = empleado.idSucursal.Value,
                    fechaVenta = dtpFechaVenta.Value,
                    tipoPago = cbxTipoPago.SelectedItem.ToString(),
                    montoTotal = total,
                    usuarioRegistro = Util.usuario.nombreUsuario,
                    fechaRegistro = DateTime.Now,
                    estado = 1
                };

                // Registrar la venta completa.
                int idVenta = VentaCln.registrarVenta(venta, detalles);

                MessageBox.Show(
                    "La venta se registró correctamente.\nN° de venta: " + idVenta,
                    "Venta registrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al registrar la venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void nudRecibido_ValueChanged(object sender, EventArgs e)
        {
            decimal total = nudTotalVenta.Value;
            decimal recibido = nudRecibido.Value;

            decimal cambio = recibido - total;

            txtCambio.Text = cambio >= 0
                ? cambio.ToString("N2")
                : "0.00";
        }

        private void cbxModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxModelo.SelectedItem is Modelo modelo)
            {
                txtMarca.Text = modelo.Marca?.nombre ?? "";
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            FrmClientes formulario = new FrmClientes();
            formulario.ShowDialog();

            cargarClientes();
        }
    }
}
