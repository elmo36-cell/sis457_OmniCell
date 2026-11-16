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
                string.IsNullOrWhiteSpace(txtSegundoApellido.Text) ||
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
                if (cbxSucursal.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione una sucursal válida de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxSucursal.Focus();
                    return;
                }

                if (!long.TryParse(txtCelular.Text.Trim(), out long celularNumero))
                {
                    MessageBox.Show("El celular debe contener solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCelular.Focus();
                    return;
                }

                Empleado empleado = new Empleado
                {
                    nombres = txtNombre.Text.Trim(),
                    primerApellido = txtPrimerApellido.Text.Trim(),
                    segundoApellido = txtSegundoApellido.Text.Trim(),
                    ci = txtCi.Text.Trim(),
                    cargo = txtCargo.Text.Trim(),
                    direccion = txtDireccion.Text.Trim(),
                    celular = celularNumero,
                    idSucursal = Convert.ToInt32(cbxSucursal.SelectedValue),
                    usuarioRegistro = Util.usuario.nombreUsuario,
                    fechaRegistro = DateTime.Now
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
                string detalleError = ex.InnerException?.InnerException?.Message
                                      ?? ex.InnerException?.Message
                                      ?? ex.Message;

                if (detalleError.Contains("UNIQUE") || detalleError.Contains("duplicate"))
                {
                    MessageBox.Show("Ya existe un empleado registrado con ese número de CI.", "CI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(detalleError, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
