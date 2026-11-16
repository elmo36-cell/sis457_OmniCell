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
    public partial class FrmPantalla : Form
    {
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
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(txtSku.Text))
                {
                    MessageBox.Show("Ingrese el SKU de la pantalla.");
                    txtSku.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    MessageBox.Show("Ingrese la descripción de la pantalla.");
                    txtDescripcion.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCalidad.Text))
                {
                    MessageBox.Show("Ingrese la calidad de la pantalla.");
                    txtCalidad.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTecnologia.Text))
                {
                    MessageBox.Show("Ingrese la tecnología de la pantalla.");
                    txtTecnologia.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(cbxMarca.Text))
                {
                    MessageBox.Show("Seleccione o escriba una marca.");
                    cbxMarca.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtModelo.Text))
                {
                    MessageBox.Show("Ingrese el modelo de la pantalla.");
                    txtModelo.Focus();
                    return;
                }

                if (nudPrecioVenta.Value <= 0)
                {
                    MessageBox.Show("El precio de venta debe ser mayor a cero.");
                    nudPrecioVenta.Focus();
                    return;
                }

                // Crear objeto pantalla
                Pantalla pantalla = new Pantalla
                {
                    sku = txtSku.Text.Trim(),
                    descripcion = txtDescripcion.Text.Trim(),
                    calidad = txtCalidad.Text.Trim(),
                    tecnologia = txtTecnologia.Text.Trim(),
                    precioVenta = nudPrecioVenta.Value,
                    stockTotal = 0,
                    usuarioRegistro = Util.usuario.nombreUsuario
                };

                // Registrar pantalla, marca, modelo y compatibilidad
                int id = PantallaCln.registrarConCompatibilidad(
                    pantalla,
                    cbxMarca.Text,
                    txtModelo.Text
                );

                MessageBox.Show(
                    "Pantalla registrada correctamente.\nStock inicial: 0",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                limpiarCampos();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al registrar pantalla",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
