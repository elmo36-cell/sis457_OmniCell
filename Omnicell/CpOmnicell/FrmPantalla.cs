using CadOmnicell;
using ClnOmnicell;
using CpMinerva;
using System;
using System.Windows.Forms;

namespace CpOmnicell
{
    public partial class FrmPantalla : FormOmnicell
    {
        // Rangos de los controles numéricos del formulario.
        private const decimal PrecioMaximo = 1000000M;
        private const decimal StockMaximo = 1000000M;

        private int? idPantalla;

        public FrmPantalla()
        {
            InitializeComponent();
            idPantalla = null;
        }

        public FrmPantalla(int id)
        {
            InitializeComponent();
            idPantalla = id;
        }

        private void FrmPantalla_Load(object sender, EventArgs e)
        {
            configurarLimites();
            cargarMarcas();

            if (idPantalla.HasValue)
            {
                cargarPantalla();
            }
            else
            {
                limpiarCampos();
            }
        }

        // El diseñador deja el máximo en 100, así que una pantalla con un precio
        // o un stock mayor no se podía abrir ni guardar.
        private void configurarLimites()
        {
            nudPrecioVenta.DecimalPlaces = 2;
            nudPrecioVenta.Maximum = PrecioMaximo;

            nudStockTotal.Maximum = StockMaximo;
        }

        private void cargarMarcas()
        {
            cbxMarca.DataSource = null;
            cbxMarca.DisplayMember = "nombre";
            cbxMarca.ValueMember = "id";
            cbxMarca.DataSource = MarcaCln.listar();

            cbxMarca.SelectedIndex = -1;

            cbxMarca.DropDownStyle = ComboBoxStyle.DropDown;
            cbxMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxMarca.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cargarPantalla()
        {
            var pantalla = PantallaCln.obtenerUno(idPantalla.Value);

            txtSku.Text = pantalla.sku;
            txtCalidad.Text = pantalla.calidad;
            txtDescripcion.Text = pantalla.descripcion;
            txtTecnologia.Text = pantalla.tecnologia;
            nudPrecioVenta.Value = pantalla.precioVenta;
            nudStockTotal.Value = pantalla.stockTotal;
        }

        private void limpiarCampos()
        {
            txtSku.Clear();
            txtDescripcion.Clear();
            txtCalidad.Clear();
            txtTecnologia.Clear();

            nudPrecioVenta.Value = 0;
            nudStockTotal.Value = 0;
            nudStockTotal.Enabled = false;

            cbxMarca.SelectedIndex = -1;
            cbxMarca.Text = "";

            txtModelo.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Util.Requerido(txtSku, "Ingrese el SKU de la pantalla."))
                return;

            if (!Util.Requerido(txtDescripcion, "Ingrese la descripción de la pantalla."))
                return;

            if (!Util.Requerido(txtCalidad, "Ingrese la calidad de la pantalla."))
                return;

            if (!Util.Requerido(txtTecnologia, "Ingrese la tecnología de la pantalla."))
                return;

            if (!Util.Requerido(cbxMarca, "Seleccione o escriba una marca."))
                return;

            if (!Util.Requerido(txtModelo, "Ingrese el modelo de la pantalla."))
                return;

            if (nudPrecioVenta.Value <= 0)
            {
                Util.Avisar("El precio de venta debe ser mayor a cero.");
                nudPrecioVenta.Focus();
                return;
            }

            try
            {
                Pantalla pantalla = new Pantalla
                {
                    sku = txtSku.Text.Trim(),
                    descripcion = txtDescripcion.Text.Trim(),
                    calidad = txtCalidad.Text.Trim(),
                    tecnologia = txtTecnologia.Text.Trim(),
                    precioVenta = nudPrecioVenta.Value,
                    stockTotal = 0,
                    usuarioRegistro = SesionCln.NombreUsuario
                };

                // La capa de negocio registra pantalla, marca, modelo y compatibilidad.
                PantallaCln.registrarConCompatibilidad(pantalla, cbxMarca.Text, txtModelo.Text);

                Util.Informar(
                    "Pantalla registrada correctamente.\nStock inicial: 0",
                    "Registro exitoso"
                );

                limpiarCampos();
                Close();
            }
            catch (Exception ex)
            {
                Util.MostrarError(ex.Message, "Error al registrar pantalla");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
