using CadOmnicell;
using ClnOmnicell;
using CpMinerva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CpOmnicell
{
    public partial class FrmCompras : FormOmnicell
    {
        // Rangos de los controles numéricos del formulario.
        private const decimal CantidadMaxima = 10000M;
        private const decimal CostoMaximo = 1000000M;
        private const decimal TotalMaximo = 10000000M;
        private const decimal CantidadMinima = 1M;
        private const decimal MontoCero = 0M;

        private List<Proveedor> listaProveedores;
        private List<Pantalla> listaPantallas;
        private List<Modelo> modelosPantallaActual = new List<Modelo>();
        private int idSucursalSesion;

        public FrmCompras()
        {
            InitializeComponent();
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            try
            {
                configurarMontos();

                // El total se actualiza en tiempo real al cargar el producto.
                nudCantidad.ValueChanged += (s, ev) => actualizarTotalCompra();
                nudPrecioCompra.ValueChanged += (s, ev) => actualizarTotalCompra();

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
                Util.MostrarError(ex.Message, "Error al cargar compras");
            }
        }

        private void configurarMontos()
        {
            nudPrecioCompra.DecimalPlaces = 2;
            nudPrecioCompra.Maximum = CostoMaximo;

            nudTotalCompra.DecimalPlaces = 2;
            nudTotalCompra.Maximum = TotalMaximo;

            nudCantidad.Maximum = CantidadMaxima;
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
                    idEmpleado = SesionCln.IdEmpleado,
                    fechaCompra = dtpFechaCompra.Value,
                    factura = txtFactura.Text.Trim(),
                    costoTotal = nudTotalCompra.Value,
                    usuarioRegistro = SesionCln.NombreUsuario
                };

                // Preparar detalles desde la grilla del carrito.
                List<CompraDetalle> detalles =
                    CarritoOmnicell.LeerDetallesCompra(dgvListarProductos);

                // Registrar compra e incrementar inventario
                int idCompra = CompraCln.registrarCompra(compra, detalles, idSucursalSesion);

                Util.Informar(
                    "Compra registrada correctamente. N.º de compra: " + idCompra,
                    "Compra registrada"
                );

                limpiarCompra();
            }
            catch (Exception ex)
            {
                Util.MostrarError(ex.Message, "Error al registrar compra");
            }
        }

        // Deja el formulario listo para registrar otra compra.
        private void limpiarCompra()
        {
            dgvListarProductos.Rows.Clear();
            txtFactura.Clear();

            cbxProveedor.SelectedIndex = -1;
            cbxPantalla.SelectedIndex = -1;
            cbxTipoPago.SelectedIndex = -1;

            limpiarDatosPantalla();

            dtpFechaCompra.Value = DateTime.Now;
            actualizarTotalCompra();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool validarCompra()
        {
            if (cbxProveedor.SelectedIndex == -1)
            {
                Util.Avisar("Seleccione un proveedor.");
                cbxProveedor.Focus();
                return false;
            }

            if (dgvListarProductos.Rows.Count == 0)
            {
                Util.Avisar("Agregue al menos un producto a la compra.");
                cbxPantalla.Focus();
                return false;
            }

            if (cbxTipoPago.SelectedIndex == -1)
            {
                Util.Avisar("Seleccione un tipo de pago.");
                cbxTipoPago.Focus();
                return false;
            }

            if (nudTotalCompra.Value <= MontoCero)
            {
                Util.Avisar("El total de la compra debe ser mayor a cero.");
                return false;
            }

            return true;
        }

        //Seccion Proveedores
        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            using (FrmProveedores formulario = new FrmProveedores())
            {
                formulario.ShowDialog();
            }

            cargarProveedores();
        }

        private void cargarProveedores()
        {
            listaProveedores = ProveedorCln.listar() ?? new List<Proveedor>();

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
                Empleado empleado = SesionCln.empleadoConSucursal();

                idSucursalSesion = empleado.idSucursal.Value;

                txtEmpleado.Text = empleado.NombreCompleto();
                txtSucursal.Text = empleado.Sucursal.nombre;
                dtpFechaCompra.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                Util.MostrarError(ex.Message, "Error al cargar empleado");
            }
        }

        //Seccion Producto(Pantallas)
        private void cargarPantallas()
        {
            listaPantallas = PantallaCln.listar() ?? new List<Pantalla>();

            cbxPantalla.SelectedIndexChanged -= cbxPantalla_SelectedIndexChanged;

            cbxPantalla.DataSource = null;
            cbxPantalla.DisplayMember = "sku";
            cbxPantalla.ValueMember = "id";
            cbxPantalla.DataSource = listaPantallas;
            cbxPantalla.SelectedIndex = -1;

            cbxPantalla.SelectedIndexChanged += cbxPantalla_SelectedIndexChanged;
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

                Pantalla pantalla = PantallaCln.obtenerConCompatibilidad(pantallaSeleccionada.id);

                if (pantalla == null)
                    throw new Exception("No se encontró la pantalla seleccionada.");

                nudPrecioCompra.Value = Math.Min(pantalla.precioVenta, nudPrecioCompra.Maximum);
                txtCalidad.Text = pantalla.calidad;
                txtTecnologia.Text = pantalla.tecnologia;

                decimal stock = InventarioCln.obtenerStock(idSucursalSesion, pantalla.id);
                txtStock.Text = stock.ToString(Formatos.Monto);

                // Marcas y modelos compatibles de la pantalla seleccionada.
                CatalogoCompatibilidad catalogo = CompatibilidadCln.obtenerCatalogo(pantalla);
                modelosPantallaActual = catalogo.Modelos;

                cargarMarcas(catalogo.Marcas);
                limpiarModelos();

                // La pantalla ya está registrada con su marca y modelo, así que se
                // rellenan solos; el usuario puede cambiarlos si hay más de uno.
                if (catalogo.Marcas.Count > 0)
                    cbxMarca.SelectedIndex = 0;

                actualizarTotalCompra();
            }
            catch (Exception ex)
            {
                Util.MostrarError(ex.Message, "Error al seleccionar pantalla");
            }
        }

        private void cargarMarcas(List<Marca> marcas)
        {
            cbxMarca.SelectedIndexChanged -= cbxMarca_SelectedIndexChanged;

            cbxMarca.DataSource = null;
            cbxMarca.DisplayMember = "nombre";
            cbxMarca.ValueMember = "id";
            cbxMarca.DataSource = marcas;
            cbxMarca.SelectedIndex = -1;
            cbxMarca.Enabled = marcas.Count > 0;

            cbxMarca.SelectedIndexChanged += cbxMarca_SelectedIndexChanged;
        }

        private void limpiarModelos()
        {
            cbxModelo.SelectedIndexChanged -= cbxModelo_SelectedIndexChanged;

            cbxModelo.DataSource = null;
            cbxModelo.Items.Clear();
            cbxModelo.Enabled = false;

            cbxModelo.SelectedIndexChanged += cbxModelo_SelectedIndexChanged;
        }

        private void limpiarDatosPantalla()
        {
            modelosPantallaActual.Clear();

            cbxMarca.SelectedIndexChanged -= cbxMarca_SelectedIndexChanged;
            cbxMarca.DataSource = null;
            cbxMarca.Items.Clear();
            cbxMarca.Enabled = false;
            cbxMarca.SelectedIndexChanged += cbxMarca_SelectedIndexChanged;

            limpiarModelos();

            txtCalidad.Clear();
            txtTecnologia.Clear();
            txtStock.Clear();

            nudCantidad.Value = 0;
            nudPrecioCompra.Value = 0;

            actualizarTotalCompra();
        }

        private void cbxModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // La marca ya se elige primero; el modelo solo se muestra.
        }

        private void configurarDgvProductos()
        {
            CarritoOmnicell.Configurar(dgvListarProductos, TipoCarrito.Compra);
        }

        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxPantalla.SelectedIndex == -1)
                {
                    Util.Avisar("Seleccione una pantalla.");
                    cbxPantalla.Focus();
                    return;
                }

                if (cbxMarca.SelectedIndex == -1)
                {
                    Util.Avisar("Seleccione una marca.");
                    cbxMarca.Focus();
                    return;
                }

                if (cbxModelo.SelectedIndex == -1)
                {
                    Util.Avisar("Seleccione un modelo compatible.");
                    cbxModelo.Focus();
                    return;
                }

                if (nudCantidad.Value < CantidadMinima)
                {
                    Util.Avisar("Ingrese una cantidad válida.");
                    nudCantidad.Focus();
                    return;
                }

                if (nudPrecioCompra.Value <= MontoCero)
                {
                    Util.Avisar("Ingrese un costo de compra válido.");
                    nudPrecioCompra.Focus();
                    return;
                }

                int idPantalla = Convert.ToInt32(cbxPantalla.SelectedValue);
                int idModelo = Convert.ToInt32(cbxModelo.SelectedValue);

                var pantalla = listaPantallas.FirstOrDefault(x => x.id == idPantalla);

                if (pantalla == null)
                    throw new Exception("No se encontró la pantalla seleccionada.");

                decimal cantidad = nudCantidad.Value;
                decimal precio = nudPrecioCompra.Value;

                DataGridViewRow fila = CarritoOmnicell.Buscar(dgvListarProductos, idPantalla, idModelo);

                if (fila != null)
                {
                    // Acumular cantidades y actualizar el costo del producto repetido.
                    decimal nuevaCantidad = CarritoOmnicell.Cantidad(fila) + cantidad;
                    CarritoOmnicell.Actualizar(fila, nuevaCantidad, precio);

                    nudCantidad.Value = CantidadMinima;
                    nudPrecioCompra.Value = MontoCero;
                    actualizarTotalCompra();

                    Util.Informar("Cantidad del producto actualizada.");
                    return;
                }

                CarritoOmnicell.Agregar(dgvListarProductos, new LineaCarrito
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

                // Limpiar campos de ingreso.
                nudCantidad.Value = CantidadMinima;
                nudPrecioCompra.Value = MontoCero;
                actualizarTotalCompra();
            }
            catch (Exception ex)
            {
                Util.MostrarError(ex.Message, "Error al agregar producto");
            }
        }

        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            if (dgvListarProductos.CurrentRow == null)
            {
                Util.Avisar("Seleccione un producto de la lista.");
                return;
            }

            dgvListarProductos.Rows.Remove(dgvListarProductos.CurrentRow);

            CarritoOmnicell.Renumerar(dgvListarProductos);
            actualizarTotalCompra();
        }

        //Configuraciones de controles
        private void configurarBuscadores()
        {
            configurarComboBuscador(cbxProveedor);
            configurarComboBuscador(cbxPantalla);

            cbxMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxModelo.DropDownStyle = ComboBoxStyle.DropDownList;
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
            cbxTipoPago.Items.AddRange(TipoPagoCln.listar().ToArray());

            cbxTipoPago.SelectedIndex = -1;
        }

        private void actualizarTotalCompra()
        {
            // BUG: la vista previa (cantidad × costo de lo que aún no se agregó) entra en el
            // total, y ese total es el costoTotal que se guarda; no suma igual que los detalles.
            decimal vistaPreviaActual = nudCantidad.Value * nudPrecioCompra.Value;
            decimal totalGeneral = CarritoOmnicell.Total(dgvListarProductos) + vistaPreviaActual;

            nudTotalCompra.Value = Math.Min(totalGeneral, nudTotalCompra.Maximum);
        }

        private void cbxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarModelos();

                if (!(cbxMarca.SelectedItem is Marca marcaSeleccionada))
                    return;

                List<Modelo> modelosFiltrados = modelosPantallaActual
                    .Where(modelo => modelo.idMarca == marcaSeleccionada.id)
                    .OrderBy(modelo => modelo.nombre)
                    .ToList();

                cbxModelo.DisplayMember = "nombre";
                cbxModelo.ValueMember = "id";
                cbxModelo.DataSource = modelosFiltrados;
                cbxModelo.SelectedIndex = modelosFiltrados.Count > 0 ? 0 : -1;
                cbxModelo.Enabled = modelosFiltrados.Count > 0;
            }
            catch (Exception ex)
            {
                Util.MostrarError(ex.Message, "Error al seleccionar marca");
            }
        }
    }
}
