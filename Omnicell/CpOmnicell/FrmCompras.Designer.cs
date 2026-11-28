namespace CpOmnicell
{
    partial class FrmCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompras));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cabeceraOmnicell = new CpOmnicell.CabeceraOmnicell();
            this.gbxDatosCompra = new CpOmnicell.GroupBoxOmnicell();
            this.cbxMarca = new System.Windows.Forms.ComboBox();
            this.nudPrecioCompra = new System.Windows.Forms.NumericUpDown();
            this.btnNuevoProveedor = new CpOmnicell.BotonOmnicell();
            this.txtTecnologia = new System.Windows.Forms.TextBox();
            this.txtCalidad = new System.Windows.Forms.TextBox();
            this.lblCalidad = new System.Windows.Forms.Label();
            this.lblTecnologia = new System.Windows.Forms.Label();
            this.lblPago = new System.Windows.Forms.Label();
            this.cbxTipoPago = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudTotalCompra = new System.Windows.Forms.NumericUpDown();
            this.cbxModelo = new System.Windows.Forms.ComboBox();
            this.btnCancelarProducto = new CpOmnicell.BotonOmnicell();
            this.btnAñadirProducto = new CpOmnicell.BotonOmnicell();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.cbxPantalla = new System.Windows.Forms.ComboBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblPantallas = new System.Windows.Forms.Label();
            this.lblProductos = new System.Windows.Forms.Label();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.txtSucursal = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.lblContacto = new System.Windows.Forms.Label();
            this.dgvListarProductos = new CpOmnicell.GrillaOmnicell();
            this.btnGuardar = new CpOmnicell.BotonOmnicell();
            this.btnCancelar = new CpOmnicell.BotonOmnicell();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.cbxProveedor = new System.Windows.Forms.ComboBox();
            this.dtpFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.lblTipoPago = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblIdEmpleado = new System.Windows.Forms.Label();
            this.lblidProveedor = new System.Windows.Forms.Label();
            this.lblProveedores = new System.Windows.Forms.Label();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.gbxDatosCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // cabeceraOmnicell
            // 
            this.cabeceraOmnicell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cabeceraOmnicell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(88)))));
            this.cabeceraOmnicell.IconoOmnicell = CpOmnicell.Icono.Compra;
            this.cabeceraOmnicell.Location = new System.Drawing.Point(0, 0);
            this.cabeceraOmnicell.Name = "cabeceraOmnicell";
            this.cabeceraOmnicell.Size = new System.Drawing.Size(1081, 76);
            this.cabeceraOmnicell.Subtitulo = "Proveedor, factura y productos de la compra";
            this.cabeceraOmnicell.TabIndex = 0;
            this.cabeceraOmnicell.Titulo = "Nueva compra";
            // 
            // gbxDatosCompra
            // 
            this.gbxDatosCompra.BackColor = System.Drawing.Color.White;
            this.gbxDatosCompra.Controls.Add(this.cbxMarca);
            this.gbxDatosCompra.Controls.Add(this.nudPrecioCompra);
            this.gbxDatosCompra.Controls.Add(this.btnNuevoProveedor);
            this.gbxDatosCompra.Controls.Add(this.txtTecnologia);
            this.gbxDatosCompra.Controls.Add(this.txtCalidad);
            this.gbxDatosCompra.Controls.Add(this.lblCalidad);
            this.gbxDatosCompra.Controls.Add(this.lblTecnologia);
            this.gbxDatosCompra.Controls.Add(this.lblPago);
            this.gbxDatosCompra.Controls.Add(this.cbxTipoPago);
            this.gbxDatosCompra.Controls.Add(this.lblTotal);
            this.gbxDatosCompra.Controls.Add(this.label1);
            this.gbxDatosCompra.Controls.Add(this.nudTotalCompra);
            this.gbxDatosCompra.Controls.Add(this.cbxModelo);
            this.gbxDatosCompra.Controls.Add(this.btnCancelarProducto);
            this.gbxDatosCompra.Controls.Add(this.btnAñadirProducto);
            this.gbxDatosCompra.Controls.Add(this.nudCantidad);
            this.gbxDatosCompra.Controls.Add(this.lblCantidad);
            this.gbxDatosCompra.Controls.Add(this.cbxPantalla);
            this.gbxDatosCompra.Controls.Add(this.txtStock);
            this.gbxDatosCompra.Controls.Add(this.lblStock);
            this.gbxDatosCompra.Controls.Add(this.lblPrecio);
            this.gbxDatosCompra.Controls.Add(this.lblModelo);
            this.gbxDatosCompra.Controls.Add(this.lblMarca);
            this.gbxDatosCompra.Controls.Add(this.lblPantallas);
            this.gbxDatosCompra.Controls.Add(this.lblProductos);
            this.gbxDatosCompra.Controls.Add(this.txtEmpleado);
            this.gbxDatosCompra.Controls.Add(this.txtSucursal);
            this.gbxDatosCompra.Controls.Add(this.lbl);
            this.gbxDatosCompra.Controls.Add(this.txtTelefono);
            this.gbxDatosCompra.Controls.Add(this.lblTelefono);
            this.gbxDatosCompra.Controls.Add(this.txtContacto);
            this.gbxDatosCompra.Controls.Add(this.lblContacto);
            this.gbxDatosCompra.Controls.Add(this.dgvListarProductos);
            this.gbxDatosCompra.Controls.Add(this.btnGuardar);
            this.gbxDatosCompra.Controls.Add(this.btnCancelar);
            this.gbxDatosCompra.Controls.Add(this.txtFactura);
            this.gbxDatosCompra.Controls.Add(this.cbxProveedor);
            this.gbxDatosCompra.Controls.Add(this.dtpFechaCompra);
            this.gbxDatosCompra.Controls.Add(this.txtPais);
            this.gbxDatosCompra.Controls.Add(this.lblTipoPago);
            this.gbxDatosCompra.Controls.Add(this.lblFecha);
            this.gbxDatosCompra.Controls.Add(this.lblPais);
            this.gbxDatosCompra.Controls.Add(this.lblIdEmpleado);
            this.gbxDatosCompra.Controls.Add(this.lblidProveedor);
            this.gbxDatosCompra.Controls.Add(this.lblProveedores);
            this.gbxDatosCompra.Controls.Add(this.lblEmpleado);
            this.gbxDatosCompra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbxDatosCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.gbxDatosCompra.Location = new System.Drawing.Point(5, 108);
            this.gbxDatosCompra.Name = "gbxDatosCompra";
            this.gbxDatosCompra.Padding = new System.Windows.Forms.Padding(6, 4, 6, 6);
            this.gbxDatosCompra.Size = new System.Drawing.Size(1071, 518);
            this.gbxDatosCompra.TabIndex = 28;
            this.gbxDatosCompra.TabStop = false;
            this.gbxDatosCompra.Text = "Datos de Compra";
            // 
            // cbxMarca
            // 
            this.cbxMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMarca.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxMarca.FormattingEnabled = true;
            this.cbxMarca.Location = new System.Drawing.Point(567, 80);
            this.cbxMarca.Name = "cbxMarca";
            this.cbxMarca.Size = new System.Drawing.Size(180, 25);
            this.cbxMarca.TabIndex = 99;
            this.cbxMarca.SelectedIndexChanged += new System.EventHandler(this.cbxMarca_SelectedIndexChanged);
            // 
            // nudPrecioCompra
            // 
            this.nudPrecioCompra.DecimalPlaces = 2;
            this.nudPrecioCompra.Location = new System.Drawing.Point(900, 143);
            this.nudPrecioCompra.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPrecioCompra.Name = "nudPrecioCompra";
            this.nudPrecioCompra.Size = new System.Drawing.Size(165, 25);
            this.nudPrecioCompra.TabIndex = 98;
            // 
            // btnNuevoProveedor
            // 
            this.btnNuevoProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnNuevoProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoProveedor.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnNuevoProveedor.ForeColor = System.Drawing.Color.White;
            this.btnNuevoProveedor.IconoOmnicell = CpOmnicell.Icono.Proveedor;
            this.btnNuevoProveedor.Location = new System.Drawing.Point(18, 195);
            this.btnNuevoProveedor.Name = "btnNuevoProveedor";
            this.btnNuevoProveedor.Size = new System.Drawing.Size(404, 34);
            this.btnNuevoProveedor.TabIndex = 97;
            this.btnNuevoProveedor.Text = "Añadir proveedor";
            this.btnNuevoProveedor.UseVisualStyleBackColor = false;
            this.btnNuevoProveedor.Click += new System.EventHandler(this.btnNuevoProveedor_Click);
            // 
            // txtTecnologia
            // 
            this.txtTecnologia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTecnologia.Location = new System.Drawing.Point(896, 111);
            this.txtTecnologia.MaxLength = 30;
            this.txtTecnologia.Name = "txtTecnologia";
            this.txtTecnologia.ReadOnly = true;
            this.txtTecnologia.Size = new System.Drawing.Size(169, 25);
            this.txtTecnologia.TabIndex = 96;
            // 
            // txtCalidad
            // 
            this.txtCalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCalidad.Location = new System.Drawing.Point(567, 112);
            this.txtCalidad.MaxLength = 30;
            this.txtCalidad.Name = "txtCalidad";
            this.txtCalidad.ReadOnly = true;
            this.txtCalidad.Size = new System.Drawing.Size(180, 25);
            this.txtCalidad.TabIndex = 95;
            // 
            // lblCalidad
            // 
            this.lblCalidad.AutoSize = true;
            this.lblCalidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCalidad.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCalidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblCalidad.Location = new System.Drawing.Point(463, 112);
            this.lblCalidad.Name = "lblCalidad";
            this.lblCalidad.Size = new System.Drawing.Size(80, 25);
            this.lblCalidad.TabIndex = 94;
            this.lblCalidad.Text = "Calidad:";
            // 
            // lblTecnologia
            // 
            this.lblTecnologia.AutoSize = true;
            this.lblTecnologia.BackColor = System.Drawing.Color.Transparent;
            this.lblTecnologia.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTecnologia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblTecnologia.Location = new System.Drawing.Point(763, 112);
            this.lblTecnologia.Name = "lblTecnologia";
            this.lblTecnologia.Size = new System.Drawing.Size(109, 25);
            this.lblTecnologia.TabIndex = 93;
            this.lblTecnologia.Text = "Tecnologia:";
            // 
            // lblPago
            // 
            this.lblPago.BackColor = System.Drawing.Color.Transparent;
            this.lblPago.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblPago.Image = ((System.Drawing.Image)(resources.GetObject("lblPago.Image")));
            this.lblPago.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPago.Location = new System.Drawing.Point(18, 365);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(130, 26);
            this.lblPago.TabIndex = 91;
            this.lblPago.Text = "Pago";
            this.lblPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxTipoPago
            // 
            this.cbxTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoPago.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxTipoPago.FormattingEnabled = true;
            this.cbxTipoPago.Location = new System.Drawing.Point(158, 397);
            this.cbxTipoPago.Name = "cbxTipoPago";
            this.cbxTipoPago.Size = new System.Drawing.Size(264, 25);
            this.cbxTipoPago.TabIndex = 90;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblTotal.Location = new System.Drawing.Point(18, 429);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(102, 25);
            this.lblTotal.TabIndex = 89;
            this.lblTotal.Text = "Total( bs ):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.label1.Location = new System.Drawing.Point(18, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 88;
            this.label1.Text = "Tipo de Pago:";
            // 
            // nudTotalCompra
            // 
            this.nudTotalCompra.Location = new System.Drawing.Point(158, 429);
            this.nudTotalCompra.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTotalCompra.Name = "nudTotalCompra";
            this.nudTotalCompra.Size = new System.Drawing.Size(264, 25);
            this.nudTotalCompra.TabIndex = 87;
            // 
            // cbxModelo
            // 
            this.cbxModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxModelo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxModelo.FormattingEnabled = true;
            this.cbxModelo.Location = new System.Drawing.Point(896, 79);
            this.cbxModelo.Name = "cbxModelo";
            this.cbxModelo.Size = new System.Drawing.Size(169, 25);
            this.cbxModelo.TabIndex = 86;
            this.cbxModelo.SelectedIndexChanged += new System.EventHandler(this.cbxModelo_SelectedIndexChanged);
            // 
            // btnCancelarProducto
            // 
            this.btnCancelarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(86)))), ((int)(((byte)(33)))));
            this.btnCancelarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarProducto.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelarProducto.ForeColor = System.Drawing.Color.White;
            this.btnCancelarProducto.IconoOmnicell = CpOmnicell.Icono.Cancelar;
            this.btnCancelarProducto.Location = new System.Drawing.Point(886, 175);
            this.btnCancelarProducto.Name = "btnCancelarProducto";
            this.btnCancelarProducto.Size = new System.Drawing.Size(179, 34);
            this.btnCancelarProducto.TabIndex = 85;
            this.btnCancelarProducto.Text = "Cancelar Producto";
            this.btnCancelarProducto.UseVisualStyleBackColor = false;
            this.btnCancelarProducto.Click += new System.EventHandler(this.btnCancelarProducto_Click);
            // 
            // btnAñadirProducto
            // 
            this.btnAñadirProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnAñadirProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAñadirProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAñadirProducto.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnAñadirProducto.ForeColor = System.Drawing.Color.White;
            this.btnAñadirProducto.IconoOmnicell = CpOmnicell.Icono.Agregar;
            this.btnAñadirProducto.Location = new System.Drawing.Point(720, 176);
            this.btnAñadirProducto.Name = "btnAñadirProducto";
            this.btnAñadirProducto.Size = new System.Drawing.Size(160, 34);
            this.btnAñadirProducto.TabIndex = 84;
            this.btnAñadirProducto.Text = "Añadir Producto";
            this.btnAñadirProducto.UseVisualStyleBackColor = false;
            this.btnAñadirProducto.Click += new System.EventHandler(this.btnAñadirProducto_Click);
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(567, 176);
            this.nudCantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(90, 25);
            this.nudCantidad.TabIndex = 82;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblCantidad.Location = new System.Drawing.Point(463, 176);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(93, 25);
            this.lblCantidad.TabIndex = 81;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // cbxPantalla
            // 
            this.cbxPantalla.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxPantalla.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxPantalla.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxPantalla.FormattingEnabled = true;
            this.cbxPantalla.Location = new System.Drawing.Point(567, 48);
            this.cbxPantalla.Name = "cbxPantalla";
            this.cbxPantalla.Size = new System.Drawing.Size(443, 25);
            this.cbxPantalla.TabIndex = 80;
            this.cbxPantalla.SelectedIndexChanged += new System.EventHandler(this.cbxPantalla_SelectedIndexChanged);
            // 
            // txtStock
            // 
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.Location = new System.Drawing.Point(567, 144);
            this.txtStock.MaxLength = 30;
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(120, 25);
            this.txtStock.TabIndex = 77;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.BackColor = System.Drawing.Color.Transparent;
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblStock.Location = new System.Drawing.Point(463, 144);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(65, 25);
            this.lblStock.TabIndex = 76;
            this.lblStock.Text = "Stock:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblPrecio.Location = new System.Drawing.Point(713, 143);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(141, 25);
            this.lblPrecio.TabIndex = 75;
            this.lblPrecio.Text = "Precio Compra:";
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.BackColor = System.Drawing.Color.Transparent;
            this.lblModelo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblModelo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblModelo.Location = new System.Drawing.Point(763, 80);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(82, 25);
            this.lblModelo.TabIndex = 74;
            this.lblModelo.Text = "Modelo:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.BackColor = System.Drawing.Color.Transparent;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblMarca.Location = new System.Drawing.Point(463, 80);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(70, 25);
            this.lblMarca.TabIndex = 73;
            this.lblMarca.Text = "Marca:";
            // 
            // lblPantallas
            // 
            this.lblPantallas.AutoSize = true;
            this.lblPantallas.BackColor = System.Drawing.Color.Transparent;
            this.lblPantallas.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPantallas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblPantallas.Location = new System.Drawing.Point(463, 48);
            this.lblPantallas.Name = "lblPantallas";
            this.lblPantallas.Size = new System.Drawing.Size(86, 25);
            this.lblPantallas.TabIndex = 72;
            this.lblPantallas.Text = "Pantalla:";
            // 
            // lblProductos
            // 
            this.lblProductos.BackColor = System.Drawing.Color.Transparent;
            this.lblProductos.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblProductos.Image = ((System.Drawing.Image)(resources.GetObject("lblProductos.Image")));
            this.lblProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblProductos.Location = new System.Drawing.Point(463, 14);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(200, 34);
            this.lblProductos.TabIndex = 69;
            this.lblProductos.Text = "Productos";
            this.lblProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpleado.Location = new System.Drawing.Point(158, 271);
            this.txtEmpleado.MaxLength = 30;
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(264, 25);
            this.txtEmpleado.TabIndex = 68;
            // 
            // txtSucursal
            // 
            this.txtSucursal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSucursal.Location = new System.Drawing.Point(158, 303);
            this.txtSucursal.MaxLength = 30;
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.ReadOnly = true;
            this.txtSucursal.Size = new System.Drawing.Size(264, 25);
            this.txtSucursal.TabIndex = 67;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.BackColor = System.Drawing.Color.Transparent;
            this.lbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lbl.Location = new System.Drawing.Point(18, 303);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(88, 25);
            this.lbl.TabIndex = 66;
            this.lbl.Text = "Sucursal:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Location = new System.Drawing.Point(158, 131);
            this.txtTelefono.MaxLength = 30;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(264, 25);
            this.txtTelefono.TabIndex = 65;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblTelefono.Location = new System.Drawing.Point(18, 131);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(91, 25);
            this.lblTelefono.TabIndex = 64;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtContacto
            // 
            this.txtContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContacto.Location = new System.Drawing.Point(158, 99);
            this.txtContacto.MaxLength = 30;
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(264, 25);
            this.txtContacto.TabIndex = 63;
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.BackColor = System.Drawing.Color.Transparent;
            this.lblContacto.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblContacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblContacto.Location = new System.Drawing.Point(18, 99);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(94, 25);
            this.lblContacto.TabIndex = 62;
            this.lblContacto.Text = "Contacto:";
            // 
            // dgvListarProductos
            // 
            this.dgvListarProductos.AllowUserToAddRows = false;
            this.dgvListarProductos.AllowUserToDeleteRows = false;
            this.dgvListarProductos.AllowUserToResizeColumns = false;
            this.dgvListarProductos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvListarProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListarProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListarProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvListarProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListarProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvListarProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListarProductos.ColumnHeadersHeight = 36;
            this.dgvListarProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListarProductos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListarProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListarProductos.EnableHeadersVisualStyles = false;
            this.dgvListarProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvListarProductos.Location = new System.Drawing.Point(431, 215);
            this.dgvListarProductos.MultiSelect = false;
            this.dgvListarProductos.Name = "dgvListarProductos";
            this.dgvListarProductos.ReadOnly = true;
            this.dgvListarProductos.RowHeadersVisible = false;
            this.dgvListarProductos.RowHeadersWidth = 51;
            this.dgvListarProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListarProductos.Size = new System.Drawing.Size(634, 290);
            this.dgvListarProductos.TabIndex = 61;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconoOmnicell = CpOmnicell.Icono.Guardar;
            this.btnGuardar.Location = new System.Drawing.Point(222, 463);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(200, 40);
            this.btnGuardar.TabIndex = 54;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.IconoOmnicell = CpOmnicell.Icono.Cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(18, 463);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(196, 40);
            this.btnCancelar.TabIndex = 55;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtFactura
            // 
            this.txtFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFactura.Location = new System.Drawing.Point(76, 335);
            this.txtFactura.MaxLength = 30;
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(74, 25);
            this.txtFactura.TabIndex = 18;
            // 
            // cbxProveedor
            // 
            this.cbxProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProveedor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxProveedor.FormattingEnabled = true;
            this.cbxProveedor.Location = new System.Drawing.Point(158, 67);
            this.cbxProveedor.Name = "cbxProveedor";
            this.cbxProveedor.Size = new System.Drawing.Size(264, 25);
            this.cbxProveedor.TabIndex = 17;
            this.cbxProveedor.SelectedIndexChanged += new System.EventHandler(this.cbxProveedor_SelectedIndexChanged);
            // 
            // dtpFechaCompra
            // 
            this.dtpFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCompra.Location = new System.Drawing.Point(214, 335);
            this.dtpFechaCompra.Name = "dtpFechaCompra";
            this.dtpFechaCompra.Size = new System.Drawing.Size(168, 25);
            this.dtpFechaCompra.TabIndex = 15;
            // 
            // txtPais
            // 
            this.txtPais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPais.Location = new System.Drawing.Point(158, 163);
            this.txtPais.MaxLength = 30;
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(264, 25);
            this.txtPais.TabIndex = 14;
            // 
            // lblTipoPago
            // 
            this.lblTipoPago.AutoSize = true;
            this.lblTipoPago.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoPago.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTipoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblTipoPago.Location = new System.Drawing.Point(18, 335);
            this.lblTipoPago.Name = "lblTipoPago";
            this.lblTipoPago.Size = new System.Drawing.Size(79, 25);
            this.lblTipoPago.TabIndex = 11;
            this.lblTipoPago.Text = "Factura:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblFecha.Location = new System.Drawing.Point(158, 335);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(66, 25);
            this.lblFecha.TabIndex = 8;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.BackColor = System.Drawing.Color.Transparent;
            this.lblPais.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPais.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblPais.Location = new System.Drawing.Point(18, 163);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(51, 25);
            this.lblPais.TabIndex = 7;
            this.lblPais.Text = "Pais:";
            // 
            // lblIdEmpleado
            // 
            this.lblIdEmpleado.AutoSize = true;
            this.lblIdEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.lblIdEmpleado.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblIdEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblIdEmpleado.Location = new System.Drawing.Point(18, 271);
            this.lblIdEmpleado.Name = "lblIdEmpleado";
            this.lblIdEmpleado.Size = new System.Drawing.Size(101, 25);
            this.lblIdEmpleado.TabIndex = 2;
            this.lblIdEmpleado.Text = "Empleado:";
            // 
            // lblidProveedor
            // 
            this.lblidProveedor.AutoSize = true;
            this.lblidProveedor.BackColor = System.Drawing.Color.Transparent;
            this.lblidProveedor.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblidProveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblidProveedor.Location = new System.Drawing.Point(18, 67);
            this.lblidProveedor.Name = "lblidProveedor";
            this.lblidProveedor.Size = new System.Drawing.Size(106, 25);
            this.lblidProveedor.TabIndex = 1;
            this.lblidProveedor.Text = "Proveedor:";
            // 
            // lblProveedores
            // 
            this.lblProveedores.BackColor = System.Drawing.Color.Transparent;
            this.lblProveedores.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblProveedores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblProveedores.Image = ((System.Drawing.Image)(resources.GetObject("lblProveedores.Image")));
            this.lblProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblProveedores.Location = new System.Drawing.Point(18, 33);
            this.lblProveedores.Name = "lblProveedores";
            this.lblProveedores.Size = new System.Drawing.Size(200, 34);
            this.lblProveedores.TabIndex = 70;
            this.lblProveedores.Text = "Proveedor";
            this.lblProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpleado.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("lblEmpleado.Image")));
            this.lblEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEmpleado.Location = new System.Drawing.Point(18, 235);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(200, 34);
            this.lblEmpleado.TabIndex = 71;
            this.lblEmpleado.Text = "Empleado";
            this.lblEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1081, 640);
            this.Controls.Add(this.gbxDatosCompra);
            this.Controls.Add(this.cabeceraOmnicell);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: Omnicell - Compras :::";
            this.Load += new System.EventHandler(this.FrmCompras_Load);
            this.gbxDatosCompra.ResumeLayout(false);
            this.gbxDatosCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CpOmnicell.CabeceraOmnicell cabeceraOmnicell;
        private CpOmnicell.GroupBoxOmnicell gbxDatosCompra;
        private System.Windows.Forms.ComboBox cbxProveedor;
        private System.Windows.Forms.DateTimePicker dtpFechaCompra;
        private System.Windows.Forms.Label lblTipoPago;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblIdEmpleado;
        private System.Windows.Forms.Label lblidProveedor;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.TextBox txtFactura;
        private CpOmnicell.BotonOmnicell btnGuardar;
        private CpOmnicell.BotonOmnicell btnCancelar;
        private CpOmnicell.GrillaOmnicell dgvListarProductos;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.TextBox txtSucursal;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Label lblProveedores;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.ComboBox cbxModelo;
        private CpOmnicell.BotonOmnicell btnCancelarProducto;
        private CpOmnicell.BotonOmnicell btnAñadirProducto;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.ComboBox cbxPantalla;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblPantallas;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.ComboBox cbxTipoPago;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudTotalCompra;
        private System.Windows.Forms.TextBox txtTecnologia;
        private System.Windows.Forms.TextBox txtCalidad;
        private System.Windows.Forms.Label lblCalidad;
        private System.Windows.Forms.Label lblTecnologia;
        private CpOmnicell.BotonOmnicell btnNuevoProveedor;
        private System.Windows.Forms.NumericUpDown nudPrecioCompra;
        private System.Windows.Forms.ComboBox cbxMarca;
    }
}