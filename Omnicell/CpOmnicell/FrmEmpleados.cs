using CadOmnicell;
using ClnOmnicell;
using CpMinerva;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CpOmnicell
{
    public partial class FrmEmpleados : FormOmnicell
    {
        private const string ErrorClaveDuplicada = "UNIQUE";
        private const string ErrorDuplicadoSql = "duplicate";

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
            Empleado empleado = EmpleadoCln.obtenerUno(idEmpleado.Value);

            if (empleado == null)
            {
                Util.Avisar("No se encontró el empleado.");
                Close();
                return;
            }

            txtNombre.Text = empleado.nombres;
            txtPrimerApellido.Text = empleado.primerApellido;
            txtSegundoApellido.Text = empleado.segundoApellido;
            txtCi.Text = empleado.ci;
            txtCargo.Text = empleado.cargo;
            txtDireccion.Text = empleado.direccion;
            txtCelular.Text = empleado.celular.ToString();

            cbxSucursal.SelectedValue = empleado.idSucursal;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Util.Requerido(txtNombre, "Ingrese los nombres del empleado."))
                return;

            if (!Util.Requerido(txtPrimerApellido, "Ingrese el primer apellido del empleado."))
                return;

            if (!Util.Requerido(txtSegundoApellido, "Ingrese el segundo apellido del empleado."))
                return;

            if (!Util.Requerido(txtCi, "Ingrese el CI del empleado."))
                return;

            if (!Util.Requerido(txtCargo, "Ingrese el cargo del empleado."))
                return;

            if (!Util.Requerido(txtDireccion, "Ingrese la dirección del empleado."))
                return;

            if (!Util.Requerido(txtCelular, "Ingrese el celular del empleado."))
                return;

            if (cbxSucursal.SelectedIndex == -1 || cbxSucursal.SelectedValue == null)
            {
                Util.Avisar("Seleccione una sucursal válida de la lista.");
                cbxSucursal.Focus();
                return;
            }

            if (!long.TryParse(txtCelular.Text.Trim(), out long celularNumero))
            {
                Util.Avisar("El celular debe contener solo números.");
                txtCelular.Focus();
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
                    celular = celularNumero,
                    idSucursal = Convert.ToInt32(cbxSucursal.SelectedValue),
                    usuarioRegistro = SesionCln.NombreUsuario,
                    fechaRegistro = DateTime.Now
                };

                if (idEmpleado.HasValue)
                {
                    empleado.id = idEmpleado.Value;
                    EmpleadoCln.actualizar(empleado);

                    Util.Informar("Empleado actualizado correctamente.");
                }
                else
                {
                    empleado.estado = (int)Estado.Activo;
                    EmpleadoCln.crear(empleado);

                    Util.Informar("Empleado registrado correctamente.");
                }

                Close();
            }
            catch (Exception ex)
            {
                string detalleError = ex.InnerException?.InnerException?.Message
                                      ?? ex.InnerException?.Message
                                      ?? ex.Message;

                if (detalleError.IndexOf(ErrorClaveDuplicada, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    detalleError.IndexOf(ErrorDuplicadoSql, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Util.Avisar("Ya existe un empleado registrado con ese número de CI.", "CI Duplicado");
                }
                else
                {
                    Util.MostrarError(detalleError, "Error al guardar");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
