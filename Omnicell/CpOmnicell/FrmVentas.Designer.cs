namespace CpOmnicell
{
    partial class FrmVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentas));
            this.cabeceraOmnicell = new CpOmnicell.CabeceraOmnicell();
            this.gbxDatosVentas = new CpOmnicell.GroupBoxOmnicell();
            this.cbxMarca = new System.Windows.Forms.ComboBox();
            this.cbxModelo = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new CpOmnicell.BotonOmnicell();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnCancelar = new CpOmnicell.BotonOmnicell();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.btnCancelarProducto = new CpOmnicell.BotonOmnicell();
            this.dgvListaProductos = new CpOmnicell.GrillaOmnicell();
            this.btnAñadirProducto = new CpOmnicell.BotonOmnicell();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.lblPago = new System.Windows.Forms.Label();
            this.lblClientesT = new System.Windows.Forms.Label();
            this.lblProductos = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtSucursal = new System.Windows.Forms.TextBox();
            this.btnNuevoCliente = new CpOmnicell.BotonOmnicell();
            this.cbxCiNit = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.cbxPantalla = new System.Windows.Forms.ComboBox();
            this.txtBuscarPantalla = new System.Windows.Forms.TextBox();
            this.lblBuscarPantalla = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblPantallas = new System.Windows.Forms.Label();
            this.cbxTipoPago = new System.Windows.Forms.ComboBox();
            this.dtpFechaVenta = new System.Windows.Forms.DateTimePicker();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTipoPago = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCiNit = new System.Windows.Forms.Label();
            this.nudTotalVenta = new System.Windows.Forms.NumericUpDown();
            this.lblIdEmpleado = new System.Windows.Forms.Label();
            this.lblidCliente = new System.Windows.Forms.Label();
            this.gbxEfectivo = new CpOmnicell.GroupBoxOmnicell();
            this.nudRecibido = new System.Windows.Forms.NumericUpDown();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.lblRecibido = new System.Windows.Forms.Label();
            this.lblCambio = new System.Windows.Forms.Label();
            this.gbxDatosVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalVenta)).BeginInit();
            this.gbxEfectivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecibido)).BeginInit();
            this.SuspendLayout();
            // 
            // cabeceraOmnicell
            // 
            this.cabeceraOmnicell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cabeceraOmnicell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(88)))));
            this.cabeceraOmnicell.IconoOmnicell = CpOmnicell.Icono.Venta;
            this.cabeceraOmnicell.Location = new System.Drawing.Point(0, 0);
            this.cabeceraOmnicell.Name = "cabeceraOmnicell";
            this.cabeceraOmnicell.Size = new System.Drawing.Size(1214, 76);
            this.cabeceraOmnicell.Subtitulo = "Cliente, productos y forma de pago";
            this.cabeceraOmnicell.TabIndex = 0;
            this.cabeceraOmnicell.Titulo = "Nueva venta";
            // 
            // gbxDatosVentas
            // 
            this.gbxDatosVentas.BackColor = System.Drawing.Color.White;
            this.gbxDatosVentas.Controls.Add(this.cbxMarca);
            this.gbxDatosVentas.Controls.Add(this.cbxModelo);
            this.gbxDatosVentas.Controls.Add(this.btnGuardar);
            this.gbxDatosVentas.Controls.Add(this.txtTelefono);
            this.gbxDatosVentas.Controls.Add(this.btnCancelar);
            this.gbxDatosVentas.Controls.Add(this.lblTelefono);
            this.gbxDatosVentas.Controls.Add(this.btnCancelarProducto);
            this.gbxDatosVentas.Controls.Add(this.dgvListaProductos);
            this.gbxDatosVentas.Controls.Add(this.btnAñadirProducto);
            this.gbxDatosVentas.Controls.Add(this.lblEmpleado);
            this.gbxDatosVentas.Controls.Add(this.lblPago);
            this.gbxDatosVentas.Controls.Add(this.lblClientesT);
            this.gbxDatosVentas.Controls.Add(this.lblProductos);
            this.gbxDatosVentas.Controls.Add(this.nudCantidad);
            this.gbxDatosVentas.Controls.Add(this.lblCantidad);
            this.gbxDatosVentas.Controls.Add(this.txtSucursal);
            this.gbxDatosVentas.Controls.Add(this.btnNuevoCliente);
            this.gbxDatosVentas.Controls.Add(this.cbxCiNit);
            this.gbxDatosVentas.Controls.Add(this.lbl);
            this.gbxDatosVentas.Controls.Add(this.cbxPantalla);
            this.gbxDatosVentas.Controls.Add(this.txtBuscarPantalla);
            this.gbxDatosVentas.Controls.Add(this.lblBuscarPantalla);
            this.gbxDatosVentas.Controls.Add(this.txtPrecioVenta);
            this.gbxDatosVentas.Controls.Add(this.txtStock);
            this.gbxDatosVentas.Controls.Add(this.txtCliente);
            this.gbxDatosVentas.Controls.Add(this.lblStock);
            this.gbxDatosVentas.Controls.Add(this.lblPrecio);
            this.gbxDatosVentas.Controls.Add(this.lblModelo);
            this.gbxDatosVentas.Controls.Add(this.lblMarca);
            this.gbxDatosVentas.Controls.Add(this.lblPantallas);
            this.gbxDatosVentas.Controls.Add(this.cbxTipoPago);
            this.gbxDatosVentas.Controls.Add(this.dtpFechaVenta);
            this.gbxDatosVentas.Controls.Add(this.txtEmpleado);
            this.gbxDatosVentas.Controls.Add(this.lblTotal);
            this.gbxDatosVentas.Controls.Add(this.lblTipoPago);
            this.gbxDatosVentas.Controls.Add(this.lblFecha);
            this.gbxDatosVentas.Controls.Add(this.lblCiNit);
            this.gbxDatosVentas.Controls.Add(this.nudTotalVenta);
            this.gbxDatosVentas.Controls.Add(this.lblIdEmpleado);
            this.gbxDatosVentas.Controls.Add(this.lblidCliente);
            this.gbxDatosVentas.Controls.Add(this.gbxEfectivo);
            this.gbxDatosVentas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbxDatosVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.gbxDatosVentas.Location = new System.Drawing.Point(5, 108);
            this.gbxDatosVentas.Name = "gbxDatosVentas";
            this.gbxDatosVentas.Padding = new System.Windows.Forms.Padding(6, 4, 6, 6);
            this.gbxDatosVentas.Size = new System.Drawing.Size(1204, 552);
            this.gbxDatosVentas.TabIndex = 12;
            this.gbxDatosVentas.TabStop = false;
            this.gbxDatosVentas.Text = "Datos de venta";
            // 
            // cbxMarca
            // 
            this.cbxMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMarca.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxMarca.FormattingEnabled = true;
            this.cbxMarca.Location = new System.Drawing.Point(96, 120);
            this.cbxMarca.Name = "cbxMarca";
            this.cbxMarca.Size = new System.Drawing.Size(170, 25);
            this.cbxMarca.TabIndex = 53;
            this.cbxMarca.SelectedIndexChanged += new System.EventHandler(this.cbxMarca_SelectedIndexChanged);
            // 
            // cbxModelo
            // 
            this.cbxModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxModelo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxModelo.FormattingEnabled = true;
            this.cbxModelo.Location = new System.Drawing.Point(356, 120);
            this.cbxModelo.Name = "cbxModelo";
            this.cbxModelo.Size = new System.Drawing.Size(204, 25);
            this.cbxModelo.TabIndex = 51;
            this.cbxModelo.SelectedIndexChanged += new System.EventHandler(this.cbxModelo_SelectedIndexChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconoOmnicell = CpOmnicell.Icono.Guardar;
            this.btnGuardar.Location = new System.Drawing.Point(220, 500);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(200, 40);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtTelefono
            // 
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Location = new System.Drawing.Point(916, 104);
            this.txtTelefono.MaxLength = 30;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(272, 25);
            this.txtTelefono.TabIndex = 50;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.IconoOmnicell = CpOmnicell.Icono.Cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(16, 500);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(196, 40);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblTelefono.Location = new System.Drawing.Point(780, 104);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(91, 25);
            this.lblTelefono.TabIndex = 49;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // btnCancelarProducto
            // 
            this.btnCancelarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(86)))), ((int)(((byte)(33)))));
            this.btnCancelarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarProducto.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelarProducto.ForeColor = System.Drawing.Color.White;
            this.btnCancelarProducto.IconoOmnicell = CpOmnicell.Icono.Cancelar;
            this.btnCancelarProducto.Location = new System.Drawing.Point(378, 180);
            this.btnCancelarProducto.Name = "btnCancelarProducto";
            this.btnCancelarProducto.Size = new System.Drawing.Size(182, 34);
            this.btnCancelarProducto.TabIndex = 47;
            this.btnCancelarProducto.Text = "Quitar producto";
            this.btnCancelarProducto.UseVisualStyleBackColor = false;
            this.btnCancelarProducto.Click += new System.EventHandler(this.btnCancelarProducto_Click);
            // 
            // dgvListaProductos
            // 
            this.dgvListaProductos.AllowUserToAddRows = false;
            this.dgvListaProductos.AllowUserToDeleteRows = false;
            this.dgvListaProductos.AllowUserToResizeColumns = false;
            this.dgvListaProductos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvListaProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListaProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvListaProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaProductos.ColumnHeadersHeight = 36;
            this.dgvListaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaProductos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListaProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListaProductos.EnableHeadersVisualStyles = false;
            this.dgvListaProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvListaProductos.Location = new System.Drawing.Point(16, 222);
            this.dgvListaProductos.MultiSelect = false;
            this.dgvListaProductos.Name = "dgvListaProductos";
            this.dgvListaProductos.ReadOnly = true;
            this.dgvListaProductos.RowHeadersVisible = false;
            this.dgvListaProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaProductos.Size = new System.Drawing.Size(744, 268);
            this.dgvListaProductos.TabIndex = 44;
            // 
            // btnAñadirProducto
            // 
            this.btnAñadirProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnAñadirProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAñadirProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAñadirProducto.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnAñadirProducto.ForeColor = System.Drawing.Color.White;
            this.btnAñadirProducto.IconoOmnicell = CpOmnicell.Icono.Agregar;
            this.btnAñadirProducto.Location = new System.Drawing.Point(200, 180);
            this.btnAñadirProducto.Name = "btnAñadirProducto";
            this.btnAñadirProducto.Size = new System.Drawing.Size(170, 34);
            this.btnAñadirProducto.TabIndex = 43;
            this.btnAñadirProducto.Text = "Añadir producto";
            this.btnAñadirProducto.UseVisualStyleBackColor = false;
            this.btnAñadirProducto.Click += new System.EventHandler(this.btnAñadirProducto_Click);
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpleado.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("lblEmpleado.Image")));
            this.lblEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEmpleado.Location = new System.Drawing.Point(780, 178);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(200, 34);
            this.lblEmpleado.TabIndex = 42;
            this.lblEmpleado.Text = "Empleado";
            this.lblEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPago
            // 
            this.lblPago.BackColor = System.Drawing.Color.Transparent;
            this.lblPago.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblPago.Image = ((System.Drawing.Image)(resources.GetObject("lblPago.Image")));
            this.lblPago.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPago.Location = new System.Drawing.Point(780, 302);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(130, 24);
            this.lblPago.TabIndex = 41;
            this.lblPago.Text = "Pago";
            this.lblPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblClientesT
            // 
            this.lblClientesT.BackColor = System.Drawing.Color.Transparent;
            this.lblClientesT.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblClientesT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblClientesT.Image = ((System.Drawing.Image)(resources.GetObject("lblClientesT.Image")));
            this.lblClientesT.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblClientesT.Location = new System.Drawing.Point(780, 8);
            this.lblClientesT.Name = "lblClientesT";
            this.lblClientesT.Size = new System.Drawing.Size(160, 30);
            this.lblClientesT.TabIndex = 40;
            this.lblClientesT.Text = "Cliente";
            this.lblClientesT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductos
            // 
            this.lblProductos.BackColor = System.Drawing.Color.Transparent;
            this.lblProductos.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblProductos.Image = ((System.Drawing.Image)(resources.GetObject("lblProductos.Image")));
            this.lblProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblProductos.Location = new System.Drawing.Point(16, 24);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(200, 28);
            this.lblProductos.TabIndex = 39;
            this.lblProductos.Text = "Productos";
            this.lblProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(96, 184);
            this.nudCantidad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(90, 25);
            this.nudCantidad.TabIndex = 38;
            this.nudCantidad.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblCantidad.Location = new System.Drawing.Point(16, 184);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(93, 25);
            this.lblCantidad.TabIndex = 37;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtSucursal
            // 
            this.txtSucursal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSucursal.Location = new System.Drawing.Point(916, 246);
            this.txtSucursal.MaxLength = 30;
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.Size = new System.Drawing.Size(272, 25);
            this.txtSucursal.TabIndex = 34;
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnNuevoCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoCliente.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnNuevoCliente.ForeColor = System.Drawing.Color.White;
            this.btnNuevoCliente.IconoOmnicell = CpOmnicell.Icono.Cliente;
            this.btnNuevoCliente.Location = new System.Drawing.Point(780, 136);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(408, 35);
            this.btnNuevoCliente.TabIndex = 33;
            this.btnNuevoCliente.Text = "Añadir Nuevo Cliente";
            this.btnNuevoCliente.UseVisualStyleBackColor = false;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // cbxCiNit
            // 
            this.cbxCiNit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxCiNit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCiNit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxCiNit.FormattingEnabled = true;
            this.cbxCiNit.Location = new System.Drawing.Point(916, 44);
            this.cbxCiNit.Name = "cbxCiNit";
            this.cbxCiNit.Size = new System.Drawing.Size(272, 25);
            this.cbxCiNit.TabIndex = 32;
            this.cbxCiNit.SelectedIndexChanged += new System.EventHandler(this.cbxCiNit_SelectedIndexChanged);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.BackColor = System.Drawing.Color.Transparent;
            this.lbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lbl.Location = new System.Drawing.Point(780, 246);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(88, 25);
            this.lbl.TabIndex = 30;
            this.lbl.Text = "Sucursal:";
            // 
            // cbxPantalla
            // 
            this.cbxPantalla.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxPantalla.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxPantalla.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxPantalla.FormattingEnabled = true;
            this.cbxPantalla.Location = new System.Drawing.Point(96, 88);
            this.cbxPantalla.Name = "cbxPantalla";
            this.cbxPantalla.Size = new System.Drawing.Size(464, 25);
            this.cbxPantalla.TabIndex = 29;
            this.cbxPantalla.SelectedIndexChanged += new System.EventHandler(this.cbxPantalla_SelectedIndexChanged);
            // 
            // txtBuscarPantalla
            // 
            this.txtBuscarPantalla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarPantalla.Location = new System.Drawing.Point(96, 56);
            this.txtBuscarPantalla.MaxLength = 30;
            this.txtBuscarPantalla.Name = "txtBuscarPantalla";
            this.txtBuscarPantalla.Size = new System.Drawing.Size(190, 25);
            this.txtBuscarPantalla.TabIndex = 49;
            this.txtBuscarPantalla.TextChanged += new System.EventHandler(this.txtBuscarPantalla_TextChanged);
            // 
            // lblBuscarPantalla
            // 
            this.lblBuscarPantalla.AutoSize = true;
            this.lblBuscarPantalla.BackColor = System.Drawing.Color.Transparent;
            this.lblBuscarPantalla.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblBuscarPantalla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblBuscarPantalla.Location = new System.Drawing.Point(16, 56);
            this.lblBuscarPantalla.Name = "lblBuscarPantalla";
            this.lblBuscarPantalla.Size = new System.Drawing.Size(75, 25);
            this.lblBuscarPantalla.TabIndex = 48;
            this.lblBuscarPantalla.Text = "Buscar:";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioVenta.Location = new System.Drawing.Point(330, 152);
            this.txtPrecioVenta.MaxLength = 30;
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(120, 25);
            this.txtPrecioVenta.TabIndex = 28;
            // 
            // txtStock
            // 
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.Location = new System.Drawing.Point(96, 152);
            this.txtStock.MaxLength = 30;
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(110, 25);
            this.txtStock.TabIndex = 25;
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Location = new System.Drawing.Point(916, 74);
            this.txtCliente.MaxLength = 30;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(272, 25);
            this.txtCliente.TabIndex = 24;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.BackColor = System.Drawing.Color.Transparent;
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblStock.Location = new System.Drawing.Point(16, 152);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(65, 25);
            this.lblStock.TabIndex = 23;
            this.lblStock.Text = "Stock:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblPrecio.Location = new System.Drawing.Point(216, 152);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(124, 25);
            this.lblPrecio.TabIndex = 22;
            this.lblPrecio.Text = "Precio Venta:";
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.BackColor = System.Drawing.Color.Transparent;
            this.lblModelo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblModelo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblModelo.Location = new System.Drawing.Point(280, 120);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(82, 25);
            this.lblModelo.TabIndex = 21;
            this.lblModelo.Text = "Modelo:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.BackColor = System.Drawing.Color.Transparent;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblMarca.Location = new System.Drawing.Point(16, 120);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(70, 25);
            this.lblMarca.TabIndex = 20;
            this.lblMarca.Text = "Marca:";
            // 
            // lblPantallas
            // 
            this.lblPantallas.AutoSize = true;
            this.lblPantallas.BackColor = System.Drawing.Color.Transparent;
            this.lblPantallas.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPantallas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblPantallas.Location = new System.Drawing.Point(16, 88);
            this.lblPantallas.Name = "lblPantallas";
            this.lblPantallas.Size = new System.Drawing.Size(86, 25);
            this.lblPantallas.TabIndex = 19;
            this.lblPantallas.Text = "Pantalla:";
            // 
            // cbxTipoPago
            // 
            this.cbxTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoPago.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxTipoPago.FormattingEnabled = true;
            this.cbxTipoPago.Location = new System.Drawing.Point(916, 332);
            this.cbxTipoPago.Name = "cbxTipoPago";
            this.cbxTipoPago.Size = new System.Drawing.Size(272, 25);
            this.cbxTipoPago.TabIndex = 16;
            this.cbxTipoPago.SelectedIndexChanged += new System.EventHandler(this.cbxTipoPago_SelectedIndexChanged);
            // 
            // dtpFechaVenta
            // 
            this.dtpFechaVenta.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaVenta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaVenta.Location = new System.Drawing.Point(916, 276);
            this.dtpFechaVenta.Name = "dtpFechaVenta";
            this.dtpFechaVenta.Size = new System.Drawing.Size(272, 25);
            this.dtpFechaVenta.TabIndex = 15;
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpleado.Location = new System.Drawing.Point(916, 216);
            this.txtEmpleado.MaxLength = 30;
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.Size = new System.Drawing.Size(272, 25);
            this.txtEmpleado.TabIndex = 14;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblTotal.Location = new System.Drawing.Point(780, 460);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(102, 25);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Total( bs ):";
            // 
            // lblTipoPago
            // 
            this.lblTipoPago.AutoSize = true;
            this.lblTipoPago.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoPago.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTipoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblTipoPago.Location = new System.Drawing.Point(780, 332);
            this.lblTipoPago.Name = "lblTipoPago";
            this.lblTipoPago.Size = new System.Drawing.Size(129, 25);
            this.lblTipoPago.TabIndex = 11;
            this.lblTipoPago.Text = "Tipo de Pago:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblFecha.Location = new System.Drawing.Point(780, 276);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(61, 25);
            this.lblFecha.TabIndex = 8;
            this.lblFecha.Text = "Fecha";
            // 
            // lblCiNit
            // 
            this.lblCiNit.AutoSize = true;
            this.lblCiNit.BackColor = System.Drawing.Color.Transparent;
            this.lblCiNit.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCiNit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblCiNit.Location = new System.Drawing.Point(780, 44);
            this.lblCiNit.Name = "lblCiNit";
            this.lblCiNit.Size = new System.Drawing.Size(73, 25);
            this.lblCiNit.TabIndex = 7;
            this.lblCiNit.Text = "CI/NIT:";
            // 
            // nudTotalVenta
            // 
            this.nudTotalVenta.Location = new System.Drawing.Point(916, 460);
            this.nudTotalVenta.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTotalVenta.Name = "nudTotalVenta";
            this.nudTotalVenta.Size = new System.Drawing.Size(272, 25);
            this.nudTotalVenta.TabIndex = 6;
            // 
            // lblIdEmpleado
            // 
            this.lblIdEmpleado.AutoSize = true;
            this.lblIdEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.lblIdEmpleado.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblIdEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblIdEmpleado.Location = new System.Drawing.Point(780, 216);
            this.lblIdEmpleado.Name = "lblIdEmpleado";
            this.lblIdEmpleado.Size = new System.Drawing.Size(101, 25);
            this.lblIdEmpleado.TabIndex = 2;
            this.lblIdEmpleado.Text = "Empleado:";
            // 
            // lblidCliente
            // 
            this.lblidCliente.AutoSize = true;
            this.lblidCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblidCliente.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblidCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblidCliente.Location = new System.Drawing.Point(780, 74);
            this.lblidCliente.Name = "lblidCliente";
            this.lblidCliente.Size = new System.Drawing.Size(76, 25);
            this.lblidCliente.TabIndex = 0;
            this.lblidCliente.Text = "Cliente:";
            // 
            // gbxEfectivo
            // 
            this.gbxEfectivo.BackColor = System.Drawing.Color.White;
            this.gbxEfectivo.Controls.Add(this.nudRecibido);
            this.gbxEfectivo.Controls.Add(this.txtCambio);
            this.gbxEfectivo.Controls.Add(this.lblRecibido);
            this.gbxEfectivo.Controls.Add(this.lblCambio);
            this.gbxEfectivo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbxEfectivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.gbxEfectivo.Location = new System.Drawing.Point(780, 362);
            this.gbxEfectivo.Name = "gbxEfectivo";
            this.gbxEfectivo.Padding = new System.Windows.Forms.Padding(6, 4, 6, 6);
            this.gbxEfectivo.Size = new System.Drawing.Size(408, 92);
            this.gbxEfectivo.TabIndex = 52;
            this.gbxEfectivo.TabStop = false;
            this.gbxEfectivo.Text = "Pago Efectivo";
            // 
            // nudRecibido
            // 
            this.nudRecibido.Location = new System.Drawing.Point(132, 29);
            this.nudRecibido.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRecibido.Name = "nudRecibido";
            this.nudRecibido.Size = new System.Drawing.Size(140, 25);
            this.nudRecibido.TabIndex = 46;
            this.nudRecibido.ValueChanged += new System.EventHandler(this.nudRecibido_ValueChanged);
            // 
            // txtCambio
            // 
            this.txtCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCambio.Location = new System.Drawing.Point(132, 57);
            this.txtCambio.MaxLength = 30;
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(140, 25);
            this.txtCambio.TabIndex = 36;
            // 
            // lblRecibido
            // 
            this.lblRecibido.AutoSize = true;
            this.lblRecibido.BackColor = System.Drawing.Color.Transparent;
            this.lblRecibido.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblRecibido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblRecibido.Location = new System.Drawing.Point(16, 30);
            this.lblRecibido.Name = "lblRecibido";
            this.lblRecibido.Size = new System.Drawing.Size(129, 25);
            this.lblRecibido.TabIndex = 45;
            this.lblRecibido.Text = "Recibido (bs):";
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.BackColor = System.Drawing.Color.Transparent;
            this.lblCambio.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCambio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblCambio.Location = new System.Drawing.Point(16, 58);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(119, 25);
            this.lblCambio.TabIndex = 35;
            this.lblCambio.Text = "Cambio (bs):";
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1214, 670);
            this.Controls.Add(this.gbxDatosVentas);
            this.Controls.Add(this.cabeceraOmnicell);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: Omnicell - Ventas :::";
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            this.gbxDatosVentas.ResumeLayout(false);
            this.gbxDatosVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalVenta)).EndInit();
            this.gbxEfectivo.ResumeLayout(false);
            this.gbxEfectivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecibido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CpOmnicell.CabeceraOmnicell cabeceraOmnicell;

        private CpOmnicell.GroupBoxOmnicell gbxDatosVentas;
        private CpOmnicell.BotonOmnicell btnGuardar;
        private CpOmnicell.BotonOmnicell btnCancelar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCiNit;
        private System.Windows.Forms.NumericUpDown nudTotalVenta;
        private System.Windows.Forms.Label lblIdEmpleado;
        private System.Windows.Forms.Label lblidCliente;
        private System.Windows.Forms.DateTimePicker dtpFechaVenta;
        private System.Windows.Forms.Label lblBuscarPantalla;
        private System.Windows.Forms.TextBox txtBuscarPantalla;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cbxTipoPago;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblPantallas;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.ComboBox cbxCiNit;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox cbxPantalla;
        private CpOmnicell.BotonOmnicell btnNuevoCliente;
        private CpOmnicell.BotonOmnicell btnAñadirProducto;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.Label lblClientesT;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.TextBox txtSucursal;
        private System.Windows.Forms.Label lblTipoPago;
        private System.Windows.Forms.Label lblTelefono;
        private CpOmnicell.BotonOmnicell btnCancelarProducto;
        private System.Windows.Forms.NumericUpDown nudRecibido;
        private System.Windows.Forms.Label lblRecibido;
        private CpOmnicell.GrillaOmnicell dgvListaProductos;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.ComboBox cbxModelo;
        private CpOmnicell.GroupBoxOmnicell gbxEfectivo;
        private System.Windows.Forms.ComboBox cbxMarca;
    }
}