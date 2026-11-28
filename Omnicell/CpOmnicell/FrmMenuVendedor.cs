using ClnOmnicell;
using CpMinerva;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CpOmnicell
{
    public partial class FrmMenuVendedor : FormOmnicell
    {
        //funciones Menu Vendedor

        private const int MargenPestanas = 12;
        private const int SeparacionPestanas = 4;

        // Color de cada pestaña para resaltar la sección activa.
        private Dictionary<BotonOmnicell, Color> coloresPestana;

        private Control[] secciones;
        private Panel[] panelesAcciones;

        public FrmMenuVendedor()
        {
            InitializeComponent();
            aplicarEstilos();
        }

        // Secciones que se muestran de a una según la pestaña activa.
        private Control[] Secciones
        {
            get
            {
                if (secciones == null)
                {
                    secciones = new Control[]
                    {
                        panelInicio, gbxVentas, gbxCompras, gbxClientes,
                        gbxProveedores, gbxUsuarios, gbxPantallas, gbxEmpleados
                    };
                }

                return secciones;
            }
        }

        private Panel[] PanelesAcciones
        {
            get
            {
                if (panelesAcciones == null)
                {
                    panelesAcciones = new Panel[]
                    {
                        pnlAccionesInicio, pnlAccionesVentas, pnlAccionesCompras,
                        pnlAccionesInventario, pnlAccionesClientes,
                        pnlAccionesProveedores, pnlAccionesPersonal
                    };
                }

                return panelesAcciones;
            }
        }

        // Uniforma fondo, iconos, colores y tamaños del menú.
        private void aplicarEstilos()
        {
            // Botón Buscar: se pega al borde derecho de su grupo
            Estilos.UbicarBotonBusqueda(btnBuscar, txtParametro);
            Estilos.UbicarBotonBusqueda(btnBuscarCompras, txtBuscarCompras);
            Estilos.UbicarBotonBusqueda(btnBuscarCliente, txtBuscarCliente);
            Estilos.UbicarBotonBusqueda(btnBuscarProveedores, txtBuscarProveedores);
            Estilos.UbicarBotonBusqueda(btnBuscarUsuario, txtBuscarUsuario);
            Estilos.UbicarBotonBusqueda(btnBuscarPantalla, txtBuscarPantalla);
            Estilos.UbicarBotonBusqueda(btnEmpleados, txtBuscarEmpleados);

            // Cada pestaña conserva su color de sección: la activa se pinta
            // más luminosa y con barra inferior, las demás algo más oscuras.
            coloresPestana = new Dictionary<BotonOmnicell, Color>
            {
                { btnTabInicio, btnTabInicio.ColorOmnicell },
                { btnTabVentas, btnTabVentas.ColorOmnicell },
                { btnTabCompras, btnTabCompras.ColorOmnicell },
                { btnTabInventario, btnTabInventario.ColorOmnicell },
                { btnTabClientes, btnTabClientes.ColorOmnicell },
                { btnTabProveedores, btnTabProveedores.ColorOmnicell },
                { btnTabPersonal, btnTabPersonal.ColorOmnicell }
            };

            SeleccionarPestana(btnTabInicio, pnlAccionesInicio);
        }

        // Deja activa una pestaña y muestra solo las acciones de esa sección.
        private void SeleccionarPestana(BotonOmnicell activa, Panel acciones)
        {
            foreach (KeyValuePair<BotonOmnicell, Color> par in coloresPestana)
            {
                par.Key.ColorOmnicell = par.Value;
                par.Key.ActivoOmnicell = par.Key == activa;
            }

            foreach (Panel panel in PanelesAcciones)
                panel.Visible = panel == acciones;
        }

        // Muestra una sola sección (o la portada) y resalta su pestaña.
        private void MostrarSeccion(Control seccion, BotonOmnicell pestana, Panel acciones)
        {
            foreach (Control panel in Secciones)
                panel.Visible = panel == seccion;

            seccion.BringToFront();

            SeleccionarPestana(pestana, acciones);
        }

        private void btnTabInicio_Click(object sender, EventArgs e)
        {
            MostrarSeccion(panelInicio, btnTabInicio, pnlAccionesInicio);
        }

        private void btnTabVentas_Click(object sender, EventArgs e)
        {
            btnHistorialVentas_Click(sender, e);
        }

        private void btnTabCompras_Click(object sender, EventArgs e)
        {
            btnHCompras_Click(sender, e);
        }

        private void btnTabInventario_Click(object sender, EventArgs e)
        {
            btnPantallas_Click(sender, e);
        }

        private void btnTabClientes_Click(object sender, EventArgs e)
        {
            btnClientes_Click(sender, e);
        }

        private void btnTabProveedores_Click(object sender, EventArgs e)
        {
            btnProveedores_Click(sender, e);
        }

        private void btnTabPersonal_Click(object sender, EventArgs e)
        {
            btnUsuarios_Click(sender, e);
        }

        private void btnTabSalir_Click(object sender, EventArgs e)
        {
            btnCerrarSesion_Click_1(sender, e);
        }

        // Las tarjetas de la portada reutilizan los botones del menú.
        private void cardVentaInicio_Click(object sender, EventArgs e)
        {
            btnNuevaVenta_Click(sender, e);
        }

        private void cardHistorialInicio_Click(object sender, EventArgs e)
        {
            btnHistorialVentas_Click(sender, e);
        }

        private void cardClientesInicio_Click(object sender, EventArgs e)
        {
            btnClientes_Click(sender, e);
        }

        private void cardNuevaCompraInicio_Click(object sender, EventArgs e)
        {
            btnNuevaCompra_Click(sender, e);
        }

        private void btnCerrarSesion_Click_1(object sender, EventArgs e)
        {
            SesionCln.cerrar();
            Close();
        }

        //texto en la parte de arriba para saludar al usuario que inisio sesion
        private void UsuarioIngreso()
        {
            string nombre = SesionCln.NombreUsuario;
            string rol = SesionCln.NombreRol;

            lblUsuario.Text = $"Usuario: {nombre} | Modo: {rol}";

            // Portada de bienvenida
            string fecha = DateTime.Now.ToString("dddd, d 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"));
            fecha = char.ToUpper(fecha[0]) + fecha.Substring(1);

            lblHeroTitulo.Text = $"Hola, {nombre}";
            lblHeroSubtitulo.Text = $"Modo {rol} · Sistema de inventario y ventas OmniCell";
            lblHeroFecha.Text = $"{fecha}  ·  {DateTime.Now:HH:mm}";

            // La compra solo está disponible para administradores, igual que la pestaña.
            cardNuevaCompra.Visible = SesionCln.EsAdministrador;
        }

        private void FrmMenuVendedor_Load(object sender, EventArgs e)
        {
            try
            {
                // La sesión siempre arranca en la portada de Inicio.
                MostrarSeccion(panelInicio, btnTabInicio, pnlAccionesInicio);

                UsuarioIngreso();
                listarVentas();
                listarCompras();
                listarClientes();
                listarProveedores();
                listarUsuarios();
                listarPantallas();
                listarEmpleados();
                configurarPermisos();
            }
            catch (Exception ex)
            {
                Util.MostrarError(ex.ToString(), "Error al iniciar el programa");
            }
        }

        private void configurarPermisos()
        {
            bool esAdministrador = SesionCln.EsAdministrador;

            btnTabVentas.Visible = true;
            btnTabClientes.Visible = true;

            btnTabCompras.Visible = esAdministrador;
            btnTabProveedores.Visible = esAdministrador;
            btnTabPersonal.Visible = esAdministrador;
            btnTabInventario.Visible = esAdministrador;

            UbicarPestanas();
        }

        // Acomoda las pestañas visibles para que no queden huecos al ocultarlas.
        private void UbicarPestanas()
        {
            int x = MargenPestanas;

            foreach (BotonOmnicell pestana in new[]
            {
                btnTabInicio, btnTabVentas, btnTabCompras, btnTabInventario,
                btnTabClientes, btnTabProveedores, btnTabPersonal
            })
            {
                if (!pestana.Visible) continue;

                pestana.Left = x;
                x += pestana.Width + SeparacionPestanas;
            }
        }

        // Pide confirmación para dar de baja un registro.
        private bool ConfirmarBaja(string entidad, int id)
        {
            return Util.Confirmar($"¿Está seguro que desea dar de baja {entidad} {id}?");
        }

        // SECCION VENTAS

        private void btnHistorialVentas_Click(object sender, EventArgs e)
        {
            MostrarSeccion(gbxVentas, btnTabVentas, pnlAccionesVentas);

            listarVentas();
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            using (FrmVentas formulario = new FrmVentas())
            {
                formulario.ShowDialog();
            }

            listarVentas();
        }

        //lista de ventas
        private void listarVentas()
        {
            // Un vendedor solo ve las ventas de su sucursal.
            string sucursal = SesionCln.EsVendedor ? SesionCln.NombreSucursal : null;

            dgvListaVentas.DataSource = VentaCln.listarVentas(txtParametro.Text.Trim(), sucursal);

            GrillasOmnicell.Ocultar(dgvListaVentas, "id");

            GrillasOmnicell.Titulo(dgvListaVentas, "fechaVenta", "Fecha", Formatos.FechaHora);
            GrillasOmnicell.Titulo(dgvListaVentas, "cliente", "Cliente");
            GrillasOmnicell.Titulo(dgvListaVentas, "nitCi", "CI / NIT");
            GrillasOmnicell.Titulo(dgvListaVentas, "vendedor", "Vendedor");
            GrillasOmnicell.Titulo(dgvListaVentas, "sucursal", "Sucursal");
            GrillasOmnicell.Titulo(dgvListaVentas, "tipoPago", "Tipo de pago");
            GrillasOmnicell.Titulo(dgvListaVentas, "montoTotal", "Total (Bs)", Formatos.Monto);

            GrillasOmnicell.Numerar(dgvListaVentas, "N.º de Venta");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = GrillasOmnicell.IdSeleccionado(dgvListaVentas);

            if (id < 0)
            {
                Util.Avisar("Seleccione una venta para dar de baja.");
                return;
            }

            if (!ConfirmarBaja("la venta", id))
                return;

            try
            {
                VentaCln.eliminar(id, SesionCln.NombreUsuario);

                listarVentas();

                Util.Informar("Venta dada de baja correctamente.");
            }
            catch (Exception ex)
            {
                Util.MostrarError("No se pudo dar de baja la venta.\nDetalle: " + ex.Message, "Error");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = GrillasOmnicell.IdSeleccionado(dgvListaVentas);

            if (id < 0)
            {
                Util.Avisar("Seleccione una venta.");
                return;
            }

            using (FrmDetalleVenta formulario = new FrmDetalleVenta(id))
            {
                formulario.ShowDialog();
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

        // SECCION COMPRAS

        private void btnHCompras_Click(object sender, EventArgs e)
        {
            MostrarSeccion(gbxCompras, btnTabCompras, pnlAccionesCompras);

            listarCompras();
        }

        private void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            using (FrmCompras formulario = new FrmCompras())
            {
                formulario.ShowDialog();
            }

            listarCompras();
        }

        //lista de compras
        private void listarCompras()
        {
            dgvListaCompras.DataSource = CompraCln.listarCompras(txtBuscarCompras.Text.Trim());

            GrillasOmnicell.Ocultar(dgvListaCompras, "id");

            GrillasOmnicell.Titulo(dgvListaCompras, "fechaCompra", "Fecha de Compra", Formatos.Fecha);
            GrillasOmnicell.Titulo(dgvListaCompras, "proveedor", "Proveedor");
            GrillasOmnicell.Titulo(dgvListaCompras, "pais", "País");
            GrillasOmnicell.Titulo(dgvListaCompras, "empleado", "Empleado");
            GrillasOmnicell.Titulo(dgvListaCompras, "factura", "Factura");
            GrillasOmnicell.Titulo(dgvListaCompras, "costoTotal", "Costo total (Bs)", Formatos.Monto);

            GrillasOmnicell.Numerar(dgvListaCompras, "N.º de Compra");
        }

        private void btnEliminarCompra_Click(object sender, EventArgs e)
        {
            int id = GrillasOmnicell.IdSeleccionado(dgvListaCompras);

            if (id < 0)
            {
                Util.Avisar("Seleccione una compra para dar de baja.");
                return;
            }

            if (!ConfirmarBaja("la compra", id))
                return;

            try
            {
                CompraCln.eliminar(id, SesionCln.NombreUsuario);

                listarCompras();

                Util.Informar("Compra dada de baja correctamente.");
            }
            catch (Exception ex)
            {
                Util.MostrarError("No se pudo dar de baja la compra.\nDetalle: " + ex.Message, "Error");
            }
        }

        private void btnEditarCompras_Click(object sender, EventArgs e)
        {
            int id = GrillasOmnicell.IdSeleccionado(dgvListaCompras);

            if (id < 0)
            {
                Util.Avisar("Seleccione una compra.");
                return;
            }

            using (FrmDetalleCompra formulario = new FrmDetalleCompra(id))
            {
                formulario.ShowDialog();
            }
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
            MostrarSeccion(gbxClientes, btnTabClientes, pnlAccionesClientes);

            listarClientes();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            using (FrmClientes formulario = new FrmClientes())
            {
                formulario.ShowDialog();
            }

            listarClientes();
        }

        //lista de clientes
        private void listarClientes()
        {
            dgvListaClientes.DataSource = ClienteCln.listarClientes(txtBuscarCliente.Text.Trim());

            GrillasOmnicell.Ocultar(dgvListaClientes, "id");

            GrillasOmnicell.Titulo(dgvListaClientes, "nombres", "Nombre");
            GrillasOmnicell.Titulo(dgvListaClientes, "nitCi", "CI/NIT");
            GrillasOmnicell.Titulo(dgvListaClientes, "primerApellido", "Primer Apellido");
            GrillasOmnicell.Titulo(dgvListaClientes, "segundoApellido", "Segundo Apellido");
            GrillasOmnicell.Titulo(dgvListaClientes, "razonSocial", "Razón Social");
            GrillasOmnicell.Titulo(dgvListaClientes, "telefono", "Teléfono");
            GrillasOmnicell.Titulo(dgvListaClientes, "direccion", "Dirección");
            GrillasOmnicell.Titulo(dgvListaClientes, "tipoCliente", "Tipo de Cliente");
            GrillasOmnicell.Titulo(dgvListaClientes, "usuarioRegistro", "Usuario de Registro");

            GrillasOmnicell.Numerar(dgvListaClientes, "N.º de Cliente");
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            int id = GrillasOmnicell.IdSeleccionado(dgvListaClientes);

            if (id < 0)
            {
                Util.Avisar("Seleccione un cliente.");
                return;
            }

            if (!ConfirmarBaja("al cliente", id))
                return;

            try
            {
                ClienteCln.eliminar(id, SesionCln.NombreUsuario);

                Util.Informar("Cliente eliminado correctamente.");

                listarClientes();
            }
            catch (Exception ex)
            {
                Util.MostrarError("Error al eliminar el cliente:\n\n" + ex.Message, "Error");
            }
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            int id = GrillasOmnicell.IdSeleccionado(dgvListaClientes);

            if (id < 0)
            {
                Util.Avisar("Seleccione un cliente.");
                return;
            }

            using (FrmClientes formulario = new FrmClientes(id))
            {
                formulario.ShowDialog();
            }

            listarClientes();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            listarClientes();
        }

        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listarClientes();
        }

        // SECCION PROVEEDORES

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            MostrarSeccion(gbxProveedores, btnTabProveedores, pnlAccionesProveedores);

            listarProveedores();
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            using (FrmProveedores formulario = new FrmProveedores())
            {
                formulario.ShowDialog();
            }

            listarProveedores();
        }

        //lista de proveedores
        private void listarProveedores()
        {
            dgvListaProveedores.DataSource = ProveedorCln.listarProveedores(txtBuscarProveedores.Text.Trim());

            GrillasOmnicell.Ocultar(dgvListaProveedores, "id");

            GrillasOmnicell.Titulo(dgvListaProveedores, "razonSocial", "Razón Social");
            GrillasOmnicell.Titulo(dgvListaProveedores, "pais", "País");
            GrillasOmnicell.Titulo(dgvListaProveedores, "contactoPersona", "Contacto");
            GrillasOmnicell.Titulo(dgvListaProveedores, "telefono", "Teléfono");

            GrillasOmnicell.Numerar(dgvListaProveedores, "N.º de Proveedor");
        }

        private void btnEditarProveedores_Click(object sender, EventArgs e)
        {
            int id = GrillasOmnicell.IdSeleccionado(dgvListaProveedores);

            if (id < 0)
            {
                Util.Avisar("Seleccione un proveedor para editar.");
                return;
            }

            using (FrmProveedores formulario = new FrmProveedores(id))
            {
                formulario.ShowDialog();
            }

            listarProveedores();
        }

        private void btnEliminarProveedores_Click(object sender, EventArgs e)
        {
            int id = GrillasOmnicell.IdSeleccionado(dgvListaProveedores);

            if (id < 0)
            {
                Util.Avisar("Seleccione un proveedor.");
                return;
            }

            if (!ConfirmarBaja("al proveedor", id))
                return;

            try
            {
                ProveedorCln.eliminar(id, SesionCln.NombreUsuario);

                Util.Informar("Proveedor eliminado correctamente.");

                listarProveedores();
            }
            catch (Exception ex)
            {
                Util.MostrarError("Error al eliminar el proveedor:\n\n" + ex.Message, "Error");
            }
        }

        private void btnBuscarProveedores_Click(object sender, EventArgs e)
        {
            listarProveedores();
        }

        private void txtBuscarProveedores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listarProveedores();
        }

        // SECCION  PERSONAL

        // Opcion Usuarios
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            MostrarSeccion(gbxUsuarios, btnTabPersonal, pnlAccionesPersonal);

            listarUsuarios();
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            using (FrmUsuarios formulario = new FrmUsuarios())
            {
                formulario.ShowDialog();
            }

            listarUsuarios();
        }

        //lista de usuarios
        private void listarUsuarios()
        {
            try
            {
                dgvListaUsuarios.DataSource = UsuarioCln.listarUsuarios(txtBuscarUsuario.Text.Trim());

                GrillasOmnicell.Ocultar(dgvListaUsuarios, "id");

                GrillasOmnicell.Titulo(dgvListaUsuarios, "nombres", "Nombre");
                GrillasOmnicell.Titulo(dgvListaUsuarios, "cargo", "Cargo");
                GrillasOmnicell.Titulo(dgvListaUsuarios, "nombre", "Rol");
                GrillasOmnicell.Titulo(dgvListaUsuarios, "nombreUsuario", "Usuario");

                GrillasOmnicell.Numerar(dgvListaUsuarios, "N.º");
            }
            catch (Exception ex)
            {
                Util.MostrarError(ex.ToString(), "Error al listar usuarios");
            }
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            int id = GrillasOmnicell.IdSeleccionado(dgvListaUsuarios);

            if (id < 0)
            {
                Util.Avisar("Seleccione un usuario para editar.");
                return;
            }

            using (FrmUsuarios formulario = new FrmUsuarios(id))
            {
                formulario.ShowDialog();
            }

            listarUsuarios();
        }

        private void btnEliminarUsuarios_Click(object sender, EventArgs e)
        {
            int id = GrillasOmnicell.IdSeleccionado(dgvListaUsuarios);

            if (id < 0)
            {
                Util.Avisar("Seleccione un usuario.");
                return;
            }

            if (!ConfirmarBaja("al usuario", id))
                return;

            try
            {
                UsuarioCln.eliminar(id, SesionCln.NombreUsuario);

                Util.Informar("Usuario eliminado correctamente.");

                listarUsuarios();
            }
            catch (Exception ex)
            {
                Util.MostrarError("Error al eliminar el usuario:\n\n" + ex.Message, "Error");
            }
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            listarUsuarios();
        }

        private void txtBuscarUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listarUsuarios();
        }

        //SECCION INVENTARIO

        private void btnPantallas_Click(object sender, EventArgs e)
        {
            MostrarSeccion(gbxPantallas, btnTabInventario, pnlAccionesInventario);

            listarPantallas();
        }

        private void listarPantallas()
        {
            try
            {
                dgvListaPantallas.DataSource = PantallaCln.listarPantalla(txtBuscarPantalla.Text.Trim());

                GrillasOmnicell.Ocultar(dgvListaPantallas, "id");

                GrillasOmnicell.Titulo(dgvListaPantallas, "sku", "SKU");
                GrillasOmnicell.Titulo(dgvListaPantallas, "descripcion", "Descripción");
                GrillasOmnicell.Titulo(dgvListaPantallas, "calidad", "Calidad");
                GrillasOmnicell.Titulo(dgvListaPantallas, "tecnologia", "Tecnología");
                GrillasOmnicell.Titulo(dgvListaPantallas, "precioVenta", "Precio de Venta", Formatos.Monto);
                GrillasOmnicell.Titulo(dgvListaPantallas, "stockTotal", "Stock Total", Formatos.Monto);

                GrillasOmnicell.Numerar(dgvListaPantallas, "N.º");
            }
            catch (Exception ex)
            {
                Util.MostrarError(ex.ToString(), "Error al listar pantallas");
            }
        }

        private void btnAñadirPantalla_Click(object sender, EventArgs e)
        {
            using (FrmPantalla formulario = new FrmPantalla())
            {
                formulario.ShowDialog();
            }
        }

        private void btnEliminarPantalla_Click(object sender, EventArgs e)
        {
            int id = GrillasOmnicell.IdSeleccionado(dgvListaPantallas);

            if (id < 0)
            {
                Util.Avisar("Seleccione una pantalla.");
                return;
            }

            if (!ConfirmarBaja("a la pantalla", id))
                return;

            try
            {
                PantallaCln.eliminar(id, SesionCln.NombreUsuario);

                Util.Informar("Pantalla eliminada correctamente.");

                listarPantallas();
            }
            catch (Exception ex)
            {
                Util.MostrarError("Error al eliminar la pantalla:\n\n" + ex.Message, "Error");
            }
        }

        private void btnBuscarPantalla_Click(object sender, EventArgs e)
        {
            listarPantallas();
        }

        private void txtBuscarPantalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listarPantallas();
        }

        //Opcion Empleados

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            MostrarSeccion(gbxEmpleados, btnTabPersonal, pnlAccionesPersonal);

            listarEmpleados();
        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            using (FrmEmpleados formulario = new FrmEmpleados())
            {
                formulario.ShowDialog();
            }

            listarEmpleados();
        }

        private void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            int id = GrillasOmnicell.IdSeleccionado(dgvListaEmpleados);

            if (id < 0)
            {
                Util.Avisar("Seleccione un empleado para editar.");
                return;
            }

            using (FrmEmpleados formulario = new FrmEmpleados(id))
            {
                formulario.ShowDialog();
            }

            listarEmpleados();
        }

        private void listarEmpleados()
        {
            try
            {
                dgvListaEmpleados.DataSource = EmpleadoCln.listarEmpleados(txtBuscarEmpleados.Text.Trim());

                GrillasOmnicell.Ocultar(dgvListaEmpleados, "id");

                GrillasOmnicell.Titulo(dgvListaEmpleados, "nombres", "Nombre");
                GrillasOmnicell.Titulo(dgvListaEmpleados, "primerApellido", "Primer Apellido");
                GrillasOmnicell.Titulo(dgvListaEmpleados, "segundoApellido", "Segundo Apellido");
                GrillasOmnicell.Titulo(dgvListaEmpleados, "ci", "CI");
                GrillasOmnicell.Titulo(dgvListaEmpleados, "celular", "Celular");
                GrillasOmnicell.Titulo(dgvListaEmpleados, "direccion", "Direccion");
                GrillasOmnicell.Titulo(dgvListaEmpleados, "cargo", "Cargo");

                GrillasOmnicell.Numerar(dgvListaEmpleados, "N.º");
            }
            catch (Exception ex)
            {
                Util.MostrarError(ex.ToString(), "Error al listar empleados");
            }
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            int id = GrillasOmnicell.IdSeleccionado(dgvListaEmpleados);

            if (id < 0)
            {
                Util.Avisar("Seleccione un empleado.");
                return;
            }

            if (!ConfirmarBaja("al empleado", id))
                return;

            try
            {
                EmpleadoCln.eliminar(id, SesionCln.NombreUsuario);

                Util.Informar("Empleado eliminado correctamente.");

                listarEmpleados();
            }
            catch (Exception ex)
            {
                Util.MostrarError("Error al eliminar el empleado:\n\n" + ex.Message, "Error");
            }
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            listarEmpleados();
        }

        private void txtBuscarEmpleados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listarEmpleados();
        }
    }
}
