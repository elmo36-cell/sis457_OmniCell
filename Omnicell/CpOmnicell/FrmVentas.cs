using CadOmnicell;
using ClnOmnicell;
using CpMinerva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CpOmnicell
{
    public partial class FrmVentas : FormOmnicell
    {
        private const decimal CantidadMinima = 1M;
        private const decimal TotalCero = 0M;

        private List<Cliente> listaClientes = new List<Cliente>();
        private List<Modelo> modelosPantallaActual = new List<Modelo>();

        private List<paPantallaListarPorSucursal_Result> listaPantallas = new List<paPantallaListarPorSucursal_Result>();

        private int idSucursalSesion;
        private decimal cantidadAntesDeEditar;

        public FrmVentas()
        {
            InitializeComponent();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            configurarDgvProductos();

            // El buscador de clientes acepta el CI/NIT o el nombre.
            cbxCiNit.KeyDown += cbxCiNit_KeyDown;

            try
            {
                configurarTipoPago();
                configurarCamposSoloLectura();
                cargarClientes();
                cargarEmpleadoSesion();
                cargarPantallas();
            }
            catch (Exception ex)
            {
                Util.MostrarError(ex.Message, "Error al cargar ventas");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxCiNit.SelectedIndex == -1)
                {
                    Util.Avisar("Seleccione un cliente.");
                    cbxCiNit.Focus();
                    return;
                }

                if (dgvListaProductos.Rows.Count == 0)
                {
                    Util.Avisar("Debe agregar al menos un producto.");
                    return;
                }

                if (cbxTipoPago.SelectedIndex == -1)
                {
                    Util.Avisar("Seleccione un tipo de pago.");
                    cbxTipoPago.Focus();
                    return;
                }

                Empleado empleado = SesionCln.empleadoConSucursal();

                List<VentaDetalle> detalles = CarritoOmnicell.LeerDetallesVenta(dgvListaProductos);

                decimal total = detalles.Sum(detalle => detalle.cantidad * detalle.precioUnitario);

                if (esEfectivo() && nudRecibido.Value < total)
                {
                    Util.Avisar("El monto recibido es insuficiente.", "Pago incompleto");
                    nudRecibido.Focus();
                    return;
                }

                Venta venta = new Venta
                {
                    idCliente = Convert.ToInt32(cbxCiNit.SelectedValue),
                    idEmpleado = empleado.id,
                    idSucursal = empleado.idSucursal.Value,
                    fechaVenta = DateTime.Now,
                    tipoPago = cbxTipoPago.SelectedItem.ToString(),
                    montoTotal = total,
                    usuarioRegistro = SesionCln.NombreUsuario,
                    fechaRegistro = DateTime.Now,
                    estado = (int)Estado.Activo
                };

                int idVenta = VentaCln.registrarVenta(venta, detalles);

                Util.Informar(
                    "La venta se registró correctamente.\nN° de venta: " + idVenta,
                    "Venta registrada"
                );

                Close();
            }
            catch (Exception ex)
            {
                Util.MostrarError(ex.Message, "Error al registrar la venta");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Seccion Clientes
        private void cbxCiNit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cbxCiNit.SelectedValue is int idCliente))
                return;

            Cliente cliente = listaClientes.FirstOrDefault(x => x.id == idCliente);

            if (cliente == null)
                return;

            txtCliente.Text = cliente.NombreMostrar();
            txtTelefono.Text = cliente.telefono;
        }

        // Con Enter se busca por CI/NIT o por nombre y queda seleccionado el cliente
        // único que coincide, para que se rellenen sus datos.
        private void cbxCiNit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;

            string texto = cbxCiNit.Text.Trim();

            if (texto.Length == 0)
                return;

            List<Cliente> coincidencias = listaClientes
                .Where(x => (x.nitCi ?? string.Empty).IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            x.NombreMostrar().IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (coincidencias.Count == 0)
            {
                Util.Avisar("No se encontró ningún cliente con «" + texto + "».");
                return;
            }

            if (coincidencias.Count > 1)
            {
                Util.Avisar("Hay varios clientes que coinciden. Elija uno de la lista.");
                cbxCiNit.DroppedDown = true;
                return;
            }

            cbxCiNit.SelectedValue = coincidencias[0].id;
        }

        private void cargarClientes(int? idClienteSeleccionar = null)
        {
            listaClientes = ClienteCln.listarClientesCombo() ?? new List<Cliente>();

            // Se muestran el CI/NIT y el nombre para poder buscar por cualquiera de los dos.
            cbxCiNit.DataSource = listaClientes.Select(x => new
            {
                id = x.id,
                busqueda = x.nitCi + " · " + x.NombreMostrar()
            }).ToList();

            cbxCiNit.DisplayMember = "busqueda";
            cbxCiNit.ValueMember = "id";

            cbxCiNit.SelectedIndex = -1;

            txtCliente.Clear();
            txtTelefono.Clear();

            // Si se acaba de registrar un cliente, se selecciona automáticamente.
            if (idClienteSeleccionar.HasValue)
                cbxCiNit.SelectedValue = idClienteSeleccionar.Value;
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            using (FrmClientes formulario = new FrmClientes())
            {
                formulario.ShowDialog(this);

                // Deja seleccionado el cliente recién registrado.
                cargarClientes(formulario.IdClienteRegistrado);
            }
        }

        //Seccion Empleados
        private void cargarEmpleadoSesion()
        {
            Empleado empleado = SesionCln.empleadoConSucursal();

            idSucursalSesion = empleado.idSucursal.Value;

            txtEmpleado.Text = empleado.NombreCompleto();
            txtSucursal.Text = empleado.Sucursal.nombre;

            txtEmpleado.ReadOnly = true;
            txtSucursal.ReadOnly = true;

            // La fecha de venta incluye la hora en que se registra.
            // BUG: si el formulario queda abierto, la hora mostrada deja de coincidir
            // con la que se guarda (btnGuardar usa DateTime.Now).
            dtpFechaVenta.Value = DateTime.Now;
            dtpFechaVenta.Enabled = false;
        }

        //Seccion Productos(Pantallas)
        private void cargarPantallas(string parametro = "")
        {
            // SELECT por sucursal (procedimiento paPantallaListarPorSucursal) con el texto buscado.
            listaPantallas = PantallaCln.listarPorSucursal(idSucursalSesion, parametro)
                ?? new List<paPantallaListarPorSucursal_Result>();

            cbxPantalla.SelectedIndexChanged -= cbxPantalla_SelectedIndexChanged;

            cbxPantalla.DataSource = listaPantallas.Select(x => new
            {
                id = x.id,
                sku = x.sku
            }).ToList();

            cbxPantalla.DisplayMember = "sku";
            cbxPantalla.ValueMember = "id";

            cbxPantalla.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPantalla.SelectedIndex = -1;

            cbxPantalla.SelectedIndexChanged += cbxPantalla_SelectedIndexChanged;

            limpiarDatosPantalla();

            // Si el filtro deja una sola pantalla, se selecciona automáticamente.
            if (listaPantallas.Count == 1)
                cbxPantalla.SelectedIndex = 0;
        }

        private void txtBuscarPantalla_TextChanged(object sender, EventArgs e)
        {
            if (idSucursalSesion == 0)
                return;

            try
            {
                cargarPantallas(txtBuscarPantalla.Text.Trim());
            }
            catch (Exception ex)
            {
                Util.MostrarError(ex.Message, "Error al buscar pantallas");
            }
        }

        private void configurarCamposSoloLectura()
        {
            // Los datos del producto solo se muestran, nunca se editan.
            txtStock.ReadOnly = true;
            txtPrecioVenta.ReadOnly = true;
            txtCliente.ReadOnly = true;
            txtTelefono.ReadOnly = true;
        }

        private void limpiarCamposProducto()
        {
            // Recarga la lista sin filtro y deja los campos listos para el siguiente producto.
            if (txtBuscarPantalla.Text.Length > 0)
                txtBuscarPantalla.Clear();
            else
                cargarPantallas();

            txtBuscarPantalla.Focus();
        }

        private void cbxModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxModelo.SelectedItem is Modelo modelo)
            {
                cbxMarca.Text = modelo.Marca?.nombre ?? "";
            }
        }

        private void cbxPantalla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cbxPantalla.SelectedValue is int idPantalla))
                return;

            var pantalla = listaPantallas.FirstOrDefault(x => x.id == idPantalla);

            if (pantalla == null)
                return;

            txtStock.Text = pantalla.stockActual.ToString(Formatos.Monto);
            txtPrecioVenta.Text = pantalla.precioVenta.ToString(Formatos.Monto);

            // Marcas y modelos compatibles de la pantalla seleccionada.
            Pantalla pantallaCompleta = PantallaCln.obtenerConCompatibilidad(pantalla.id);
            CatalogoCompatibilidad catalogo = CompatibilidadCln.obtenerCatalogo(pantallaCompleta);

            modelosPantallaActual = catalogo.Modelos;

            cargarMarcas(catalogo.Marcas);
            limpiarModelos();

            // La pantalla ya está registrada con su marca y modelo, así que se
            // rellenan solos; el vendedor puede cambiarlos si hay más de uno.
            if (catalogo.Marcas.Count > 0)
                cbxMarca.SelectedIndex = 0;

            configurarCantidad(pantalla.stockActual);
        }

        private void cargarMarcas(List<Marca> marcas)
        {
            cbxMarca.SelectedIndexChanged -= cbxMarca_SelectedIndexChanged;
            cbxMarca.DataSource = null;
            cbxMarca.DisplayMember = "nombre";
            cbxMarca.ValueMember = "id";
            cbxMarca.DataSource = marcas;
            cbxMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMarca.SelectedIndex = -1;
            cbxMarca.Enabled = marcas.Count > 0;
            cbxMarca.SelectedIndexChanged += cbxMarca_SelectedIndexChanged;
        }

        private void limpiarModelos()
        {
            cbxModelo.DataSource = null;
            cbxModelo.Items.Clear();
            cbxModelo.Enabled = false;
        }

        // Ajusta el rango de cantidad al stock disponible (siempre entero).
        private void configurarCantidad(decimal stockActual)
        {
            nudCantidad.DecimalPlaces = 0;
            nudCantidad.Minimum = 0;

            decimal stockDisponible = Math.Floor(stockActual);

            nudCantidad.Maximum = Math.Max(CantidadMinima, stockDisponible);
            nudCantidad.Enabled = stockDisponible >= CantidadMinima;
            nudCantidad.Value = nudCantidad.Enabled ? CantidadMinima : 0;
        }

        private void limpiarDatosPantalla()
        {
            modelosPantallaActual.Clear();

            cbxMarca.DataSource = null;
            cbxMarca.Items.Clear();
            cbxMarca.Enabled = false;

            limpiarModelos();

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
                    Util.Avisar("Seleccione una pantalla.");
                    return;
                }

                if (cbxModelo.SelectedIndex == -1)
                {
                    Util.Avisar("Seleccione un modelo compatible.");
                    return;
                }

                if (nudCantidad.Value < CantidadMinima)
                {
                    Util.Avisar("Ingrese una cantidad válida.");
                    return;
                }

                int idPantalla = Convert.ToInt32(cbxPantalla.SelectedValue);
                int idModelo = Convert.ToInt32(cbxModelo.SelectedValue);

                var pantalla = listaPantallas.FirstOrDefault(x => x.id == idPantalla);

                if (pantalla == null)
                    throw new Exception("No se encontró la pantalla seleccionada.");

                decimal cantidad = nudCantidad.Value;
                decimal precio = pantalla.precioVenta;

                // Cantidad que ya está en el carrito para esta pantalla.
                decimal cantidadEnCarrito = CarritoOmnicell.CantidadEnCarrito(dgvListaProductos, idPantalla);

                if (cantidadEnCarrito + cantidad > pantalla.stockActual)
                {
                    Util.Avisar("No existe suficiente stock para la cantidad solicitada.");
                    return;
                }

                DataGridViewRow fila = CarritoOmnicell.Buscar(dgvListaProductos, idPantalla, idModelo);

                if (fila != null)
                {
                    // Mismo SKU y modelo: se acumula la cantidad.
                    decimal nuevaCantidad = CarritoOmnicell.Cantidad(fila) + cantidad;
                    CarritoOmnicell.Actualizar(fila, nuevaCantidad, precio);
                }
                else
                {
                    CarritoOmnicell.Agregar(dgvListaProductos, new LineaCarrito
                    {
                        IdPantalla = pantalla.id,
                        IdModelo = idModelo,
                        Sku = pantalla.sku,
                        Descripcion = pantalla.descripcion,
                        Marca = cbxMarca.Text,
                        Modelo = cbxModelo.Text,
                        Calidad = pantalla.calidad,
                        Cantidad = cantidad,
                        Precio = precio
                    });
                }

                actualizarTotalVenta();
                limpiarCamposProducto();
            }
            catch (Exception ex)
            {
                Util.MostrarError(ex.Message, "Error al agregar producto");
            }
        }

        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            if (dgvListaProductos.CurrentRow == null)
            {
                Util.Avisar("Seleccione un producto de la lista.");
                return;
            }

            dgvListaProductos.Rows.Remove(dgvListaProductos.CurrentRow);

            CarritoOmnicell.Renumerar(dgvListaProductos);
            actualizarTotalVenta();
        }

        private void configurarDgvProductos()
        {
            CarritoOmnicell.Configurar(dgvListaProductos, TipoCarrito.Venta);

            dgvListaProductos.CellBeginEdit += dgvListaProductos_CellBeginEdit;
            dgvListaProductos.CellEndEdit += dgvListaProductos_CellEndEdit;
        }

        private void dgvListaProductos_CellBeginEdit(
            object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvListaProductos.Columns[e.ColumnIndex].Name != CarritoOmnicell.ColCantidad)
            {
                e.Cancel = true;
                return;
            }

            cantidadAntesDeEditar = CarritoOmnicell.Cantidad(dgvListaProductos.Rows[e.RowIndex]);
        }

        private void dgvListaProductos_CellEndEdit(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                dgvListaProductos.Columns[e.ColumnIndex].Name != CarritoOmnicell.ColCantidad)
                return;

            DataGridViewRow fila = dgvListaProductos.Rows[e.RowIndex];

            int idPantalla = Convert.ToInt32(fila.Cells[CarritoOmnicell.ColIdPantalla].Value);

            var pantalla = listaPantallas.FirstOrDefault(x => x.id == idPantalla);

            decimal cantidad;

            if (!decimal.TryParse(Convert.ToString(fila.Cells[CarritoOmnicell.ColCantidad].Value), out cantidad))
                cantidad = 0;

            cantidad = Math.Truncate(cantidad);

            // Cantidad que ya ocupan otras filas de la misma pantalla.
            decimal cantidadOtrasFilas =
                CarritoOmnicell.CantidadEnCarrito(dgvListaProductos, idPantalla, e.RowIndex);

            if (pantalla == null ||
                cantidad < CantidadMinima ||
                cantidad + cantidadOtrasFilas > pantalla.stockActual)
            {
                Util.Avisar(
                    cantidad < CantidadMinima
                        ? "La cantidad debe ser mayor a cero."
                        : "La cantidad supera el stock disponible.",
                    "Cantidad no válida"
                );

                fila.Cells[CarritoOmnicell.ColCantidad].Value = cantidadAntesDeEditar;
                return;
            }

            fila.Cells[CarritoOmnicell.ColCantidad].Value = cantidad;
            fila.Cells[CarritoOmnicell.ColSubtotal].Value =
                cantidad * CarritoOmnicell.Precio(fila);

            actualizarTotalVenta();
        }

        //Seccion Pago
        private void actualizarTotalVenta()
        {
            // BUG: nudTotalVenta tiene Maximum 10000, así que un total mayor lanza excepción
            // (lo mismo pasa con nudRecibido al cobrar en efectivo).
            nudTotalVenta.Value = CarritoOmnicell.Total(dgvListaProductos);
        }

        private bool esEfectivo()
        {
            return cbxTipoPago.SelectedItem != null &&
                   cbxTipoPago.SelectedItem.ToString() == TipoPagoCln.Efectivo;
        }

        private void cbxTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbxEfectivo.Visible = esEfectivo();

            if (!esEfectivo())
            {
                nudRecibido.Value = TotalCero;
                txtCambio.Text = TotalCero.ToString(Formatos.Monto);
            }
        }

        private void nudRecibido_ValueChanged(object sender, EventArgs e)
        {
            decimal cambio = nudRecibido.Value - nudTotalVenta.Value;

            txtCambio.Text = cambio >= 0
                ? cambio.ToString(Formatos.Monto)
                : TotalCero.ToString(Formatos.Monto);
        }

        private void configurarTipoPago()
        {
            cbxTipoPago.Items.Clear();
            cbxTipoPago.Items.AddRange(TipoPagoCln.listar().ToArray());

            cbxTipoPago.SelectedIndex = -1;

            gbxEfectivo.Visible = false;

            nudRecibido.Value = TotalCero;
            txtCambio.Text = TotalCero.ToString(Formatos.Monto);

            cbxTipoPago.SelectedIndexChanged += cbxTipoPago_SelectedIndexChanged;
        }

        private void cbxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarModelos();

            if (!(cbxMarca.SelectedValue is int idMarca))
                return;

            List<Modelo> modelosFiltrados = modelosPantallaActual
                .Where(modelo => modelo.idMarca == idMarca)
                .OrderBy(modelo => modelo.nombre)
                .ToList();

            cbxModelo.DisplayMember = "nombre";
            cbxModelo.ValueMember = "id";
            cbxModelo.DataSource = modelosFiltrados;
            cbxModelo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxModelo.SelectedIndex = modelosFiltrados.Count > 0 ? 0 : -1;
            cbxModelo.Enabled = modelosFiltrados.Count > 0;
        }
    }
}
