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
    public partial class FrmEmpleados : Form
    {
        private int? idEmpleado;
        private List<Sucursal> sucursales;

        public FrmEmpleados()
        {
            InitializeComponent();
            idEmpleado = null;
        }
        public FrmEmpleados(int id)
        {
            InitializeComponent();
            idEmpleado = id;
        }
        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            cargarCombos();

            if (idEmpleado.HasValue)
            {
                cargarEmpleado();
            }
            else
            {
                limpiarCampos();
            }
        }
        private void cargarCombos()
        {
            sucursales = EmpleadoCln.listarSucursalCombo();

            cbxSucursal.DataSource = sucursales;
            cbxSucursal.DisplayMember = "nombre";
            cbxSucursal.ValueMember = "id";
            cbxSucursal.SelectedIndex = -1;

            // Configurar buscador
            cbxSucursal.DropDownStyle = ComboBoxStyle.DropDown;
            cbxSucursal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxSucursal.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void limpiarCampos()
        {
            txtNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            txtCi.Clear();
            txtCargo.Clear();
            txtDireccion.Clear();
            txtCelular.Clear();

            cbxSucursal.SelectedIndex = -1;
        }
        private void cargarEmpleado()
        {
            Empleado empleado =
                EmpleadoCln.obtenerUno(idEmpleado.Value);

            if (empleado == null)
            {
                MessageBox.Show("No se encontró el empleado.");
                Close();
                return;
            }

            txtNombre.Text = empleado.nombres;
            txtPrimerApellido.Text = empleado.primerApellido;
            txtSegundoApellido.Text = empleado.segundoApellido;
            txtCi.Text = empleado.ci;
            txtCargo.Text = empleado.cargo;
            txtDireccion.Text = empleado.direccion;
            txtCelular.Text= empleado.celular.ToString();

            cbxSucursal.SelectedValue = empleado.idSucursal;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrimerApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCi.Text) ||
                string.IsNullOrWhiteSpace(txtCargo.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtCelular.Text) ||
                cbxSucursal.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Complete todos los campos obligatorios.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                Empleado empleado = new Empleado
                {
                    nombres = txtNombre.Text.Trim(),
                    primerApellido = txtPrimerApellido.Text.Trim(),
                    segundoApellido = txtSegundoApellido.Text.Trim(),
                    ci = txtCi.Text.Trim(),
                    cargo = txtCargo.Text.Trim(),
                    direccion = txtDireccion.Text.Trim(),
                    celular = Convert.ToInt64(txtCelular.Text.Trim()),
                    idSucursal = Convert.ToInt32(cbxSucursal.SelectedValue),
                    usuarioRegistro = Util.usuario.nombreUsuario
                };

                if (idEmpleado.HasValue)
                {
                    empleado.id = idEmpleado.Value;
                    EmpleadoCln.actualizar(empleado);

                    MessageBox.Show("Empleado actualizado correctamente.");
                }
                else
                {
                    empleado.estado = 1;
                    EmpleadoCln.crear(empleado);

                    MessageBox.Show("Empleado registrado correctamente.");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
