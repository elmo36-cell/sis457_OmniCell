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
    public partial class FrmCompras : Form
    {
        private List<Proveedor> listaProveedores;
        private List<Pantalla> listaPantallas;
        private int idSucursalSesion;

        public FrmCompras()
        {
            InitializeComponent();
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            try
            {
                configurarDgvProductos();
                limpiarDatosPantalla();

                configurarTipoPago();
                configurarBuscadores();

                cargarProveedores();
                cargarEmpleadoSesion();
                cargarPantallas();

                dtpFechaCompra.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al cargar compras",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validarCompra())
                    return;

                // Preparar cabecera
                Compra compra = new Compra
                {
                    idProveedor = Convert.ToInt32(cbxProveedor.SelectedValue),
                    idEmpleado = Util.usuario.idEmpleado,
                    fechaCompra = DateTime.Today,
                    factura = txtFactura.Text.Trim(),
                    costoTotal = nudTotalCompra.Value,
                    usuarioRegistro = Util.usuario.nombreUsuario
                };

                // Preparar detalles desde el DataGridView
                List<CompraDetalle> detalles = new List<CompraDetalle>();

                foreach (DataGridViewRow fila in dgvListarProductos.Rows)
                {
                    CompraDetalle detalle = new CompraDetalle
                    {
                        idPantalla = Convert.ToInt32(
                            fila.Cells["colIdPantalla"].Value),

                        cantidad = Convert.ToDecimal(
                            fila.Cells["colCantidad"].Value),

                        costoUnitario = Convert.ToDecimal(
                            fila.Cells["colPrecio"].Value),

                        subtotal = Convert.ToDecimal(
                            fila.Cells["colSubtotal"].Value),

                        usuarioRegistro = Util.usuario.nombreUsuario
                    };

                    detalles.Add(detalle);
                }

                // Registrar compra e incrementar inventario
                int idCompra = CompraCln.registrarCompra(
                    compra,
                    detalles,
                    idSucursalSesion
                );

                MessageBox.Show(
                    "Compra registrada correctamente. N.º de compra: " + idCompra,
                    "Compra registrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Limpiar formulario
                dgvListarProductos.Rows.Clear();
                nudTotalCompra.Value = 0;
                txtFactura.Clear();

                cbxProveedor.SelectedIndex = -1;
                cbxPantalla.SelectedIndex = -1;
                cbxTipoPago.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al registrar compra",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool validarCompra()
        {
            if (cbxProveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un proveedor.");
                cbxProveedor.Focus();
                return false;
            }

            if (dgvListarProductos.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto a la compra.");
                cbxPantalla.Focus();
                return false;
            }

            if (cbxTipoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de pago.");
                cbxTipoPago.Focus();
                return false;
            }

            if (nudTotalCompra.Value <= 0)
            {
                MessageBox.Show("El total de la compra debe ser mayor a cero.");
                return false;
            }
            return true;
        }


        //Seccion Proveedores
        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            FrmProveedores frmProveedores = new FrmProveedores();
            frmProveedores.ShowDialog();
        }
        private void cargarProveedores()
        {
            listaProveedores = ProveedorCln.listar();

            cbxProveedor.DataSource = null;
            cbxProveedor.DisplayMember = "razonSocial";
            cbxProveedor.ValueMember = "id";
            cbxProveedor.DataSource = listaProveedores;
            cbxProveedor.SelectedIndex = -1;
        }
        private void cbxProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProveedor.SelectedItem is Proveedor proveedor)
            {
                txtContacto.Text = proveedor.contactoPersona;
                txtPais.Text = proveedor.pais;
                txtTelefono.Text = proveedor.telefono;
            }
            else
            {
                txtContacto.Clear();
                txtPais.Clear();
                txtTelefono.Clear();
            }
        }

        //Seccion Empleado
        private void cargarEmpleadoSesion()
        {
            try
            {
                if (Util.usuario == null)
                    throw new Exception("No existe un usuario autenticado.");

                int idEmpleado = Util.usuario.idEmpleado;

                Empleado empleado = EmpleadoCln.obtenerConSucursal(idEmpleado);

                if (!empleado.idSucursal.HasValue) throw new Exception("El empleado no tiene una sucursal asignada.");

                idSucursalSesion = empleado.idSucursal.Value;

                txtEmpleado.Text = empleado.nombres + " " + empleado.primerApellido;

                txtSucursal.Text = empleado.Sucursal.nombre;

                dtpFechaCompra.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al cargar empleado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        //Seccion Producto(Pantallas)
        private void cargarPantallas()
        {
            listaPantallas = PantallaCln.listar();

            cbxPantalla.DataSource = null;
            cbxPantalla.DisplayMember = "sku";
            cbxPantalla.ValueMember = "id";
            cbxPantalla.DataSource = listaPantallas;
            cbxPantalla.SelectedIndex = -1;
        }
        private void cbxPantalla_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(cbxPantalla.SelectedItem is Pantalla pantallaSeleccionada))
                {
                    limpiarDatosPantalla();
                    return;
                }

                int idPantalla = pantallaSeleccionada.id;

                // Obtener la pantalla con sus modelos compatibles y marcas.
                Pantalla pantalla = PantallaCln.obtenerConCompatibilidad(idPantalla);

                nudPrecioCompra.Value = Math.Min(
                    pantalla.precioVenta,
                    nudPrecioCompra.Maximum
                );

                if (pantalla == null)
                    throw new Exception("No se encontró la pantalla seleccionada.");

                // Mostrar información de la pantalla.
                txtCalidad.Text = pantalla.calidad;
                txtTecnologia.Text = pantalla.tecnologia;

                // Obtener el stock actual de la sucursal.
                decimal stock = InventarioCln.obtenerStock(
                    idSucursalSesion,
                    idPantalla
                );

                txtStock.Text = stock.ToString("N2");

                // Cargar modelos compatibles.
                var modelos = pantalla.Compatibilidad
                    .Where(c => c.estado == 1 && c.Modelo != null)
                    .Select(c => c.Modelo)
                    .Where(m => m.estado == 1)
                    .GroupBy(m => m.id)
                    .Select(g => g.First())
                    .OrderBy(m => m.nombre)
                    .ToList();

                // Obtener las marcas de los modelos compatibles.
                var marcas = modelos
                    .Where(m => m.Marca != null)
                    .Select(m => m.Marca.nombre)
                    .Distinct()
                    .ToList();

                // Mostrar la marca cuando solo existe una.
                if (marcas.Count == 1)
                {
                    txtMarca.Text = marcas.First();
                }
                else
                {
                    txtMarca.Clear();
                }

                cbxModelo.DataSource = null;
                cbxModelo.DisplayMember = "nombre";
                cbxModelo.ValueMember = "id";
                cbxModelo.DataSource = modelos;
                cbxModelo.SelectedIndex = -1;

                cbxModelo.Enabled = modelos.Count > 0;

                if (modelos.Count == 0)
                {
                    MessageBox.Show(
                        "Esta pantalla no tiene modelos compatibles registrados.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al seleccionar pantalla",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void limpiarDatosPantalla()
        {
            txtMarca.Clear();
            txtCalidad.Clear();
            txtTecnologia.Clear();
            txtStock.Clear();
            nudPrecioCompra.Value = 0;

            cbxModelo.DataSource = null;
            cbxModelo.Enabled = false;
        }
        private void cbxModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxModelo.SelectedItem is Modelo modelo)
            {
                txtMarca.Text = modelo.Marca?.nombre ?? "";
            }
            else
            {
                txtMarca.Clear();
            }
        }
        private void configurarDgvProductos()
        {
            dgvListarProductos.DataSource = null;
            dgvListarProductos.Rows.Clear();
            dgvListarProductos.Columns.Clear();

            dgvListarProductos.AutoGenerateColumns = false;
            dgvListarProductos.AllowUserToAddRows = false;
            dgvListarProductos.ReadOnly = true;
            dgvListarProductos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvListarProductos.MultiSelect = false;
            dgvListarProductos.RowHeadersVisible = false;
            dgvListarProductos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvListarProductos.Columns.Add("colNumero", "N.º");

            dgvListarProductos.Columns.Add("colIdPantalla", "ID Pantalla");
            dgvListarProductos.Columns["colIdPantalla"].Visible = false;

            dgvListarProductos.Columns.Add("colIdModelo", "ID Modelo");
            dgvListarProductos.Columns["colIdModelo"].Visible = false;

            dgvListarProductos.Columns.Add("colSku", "SKU");
            dgvListarProductos.Columns.Add("colDescripcion", "Descripción");
            dgvListarProductos.Columns.Add("colMarca", "Marca");
            dgvListarProductos.Columns.Add("colModelo", "Modelo");
            dgvListarProductos.Columns.Add("colCalidad", "Calidad");
            dgvListarProductos.Columns.Add("colCantidad", "Cantidad");
            dgvListarProductos.Columns.Add("colPrecio", "Costo unitario");
            dgvListarProductos.Columns.Add("colSubtotal", "Subtotal");

            dgvListarProductos.Columns["colPrecio"].DefaultCellStyle.Format = "N2";
            dgvListarProductos.Columns["colSubtotal"].DefaultCellStyle.Format = "N2";
        }
        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar pantalla.
                if (cbxPantalla.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione una pantalla.");
                    cbxPantalla.Focus();
                    return;
                }

                // Validar modelo.
                if (cbxModelo.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un modelo compatible.");
                    cbxModelo.Focus();
                    return;
                }

                // Validar cantidad.
                if (nudCantidad.Value <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida.");
                    nudCantidad.Focus();
                    return;
                }

                // Validar costo de compra.
                if (nudPrecioCompra.Value <= 0)
                {
                    MessageBox.Show("Ingrese un costo de compra válido.");
                    nudPrecioCompra.Focus();
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
                decimal precio = nudPrecioCompra.Value;

                // Buscar si el producto ya está agregado.
                foreach (DataGridViewRow fila in dgvListarProductos.Rows)
                {
                    if (Convert.ToInt32(fila.Cells["colIdPantalla"].Value) == idPantalla &&
                        Convert.ToInt32(fila.Cells["colIdModelo"].Value) == idModelo)
                    {
                        decimal cantidadActual =
                            Convert.ToDecimal(fila.Cells["colCantidad"].Value);

                        decimal nuevaCantidad = cantidadActual + cantidad;

                        // Acumular cantidades.
                        fila.Cells["colCantidad"].Value = nuevaCantidad;

                        // Actualizar costo y subtotal.
                        fila.Cells["colPrecio"].Value = precio;
                        fila.Cells["colSubtotal"].Value = nuevaCantidad * precio;

                        actualizarTotalCompra();

                        nudCantidad.Value = 1;
                        nudPrecioCompra.Value = 0;

                        MessageBox.Show("Cantidad del producto actualizada.");
                        return;
                    }
                }

                // Agregar nuevo producto.
                int numero = dgvListarProductos.Rows.Count + 1;

                dgvListarProductos.Rows.Add(
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

                actualizarTotalCompra();

                // Limpiar campos de ingreso.
                nudCantidad.Value = 1;
                nudPrecioCompra.Value = 0;

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
        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            if (dgvListarProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto de la lista.");
                return;
            }

            dgvListarProductos.Rows.Remove(
                dgvListarProductos.SelectedRows[0]
            );

            // Actualizar numeración.
            for (int i = 0; i < dgvListarProductos.Rows.Count; i++)
            {
                dgvListarProductos.Rows[i].Cells["colNumero"].Value = i + 1;
            }

            actualizarTotalCompra();
        }

        //Configuraciones de controles
        private void configurarBuscadores()
        {
            configurarComboBuscador(cbxProveedor);
            configurarComboBuscador(cbxPantalla);
            configurarComboBuscador(cbxModelo);
        }
        private void configurarComboBuscador(ComboBox combo)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDown;
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        //Pago
        private void configurarTipoPago()
        {
            cbxTipoPago.Items.Clear();

            cbxTipoPago.Items.Add("Efectivo");
            cbxTipoPago.Items.Add("QR");
            cbxTipoPago.Items.Add("Transferencia");

            cbxTipoPago.SelectedIndex = -1;
        }
        private void actualizarTotalCompra()
        {
            decimal total = 0;

            foreach (DataGridViewRow fila in dgvListarProductos.Rows)
            {
                total += Convert.ToDecimal(fila.Cells["colSubtotal"].Value);
            }
            nudTotalCompra.Value = Math.Min(total,nudTotalCompra.Maximum);
        }        

    }
}
