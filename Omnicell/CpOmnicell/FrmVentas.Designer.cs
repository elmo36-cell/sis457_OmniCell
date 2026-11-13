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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentas));
            this.gbxDatos = new System.Windows.Forms.GroupBox();
            this.lblTipoPago = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCiNit = new System.Windows.Forms.Label();
            this.nudTotalVenta = new System.Windows.Forms.NumericUpDown();
            this.cbxTipoPago = new System.Windows.Forms.ComboBox();
            this.lblIdEmpleado = new System.Windows.Forms.Label();
            this.lblidSucursal = new System.Windows.Forms.Label();
            this.lblidCliente = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtCINit = new System.Windows.Forms.TextBox();
            this.dtpFechaVenta = new System.Windows.Forms.DateTimePicker();
            this.cbxEmpleado = new System.Windows.Forms.ComboBox();
            this.cbxSucursal = new System.Windows.Forms.ComboBox();
            this.cbxCliente = new System.Windows.Forms.ComboBox();
            this.gbxDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxDatos
            // 
            this.gbxDatos.Controls.Add(this.cbxCliente);
            this.gbxDatos.Controls.Add(this.cbxSucursal);
            this.gbxDatos.Controls.Add(this.cbxEmpleado);
            this.gbxDatos.Controls.Add(this.dtpFechaVenta);
            this.gbxDatos.Controls.Add(this.txtCINit);
            this.gbxDatos.Controls.Add(this.lblTotal);
            this.gbxDatos.Controls.Add(this.lblTipoPago);
            this.gbxDatos.Controls.Add(this.btnGuardar);
            this.gbxDatos.Controls.Add(this.btnCancelar);
            this.gbxDatos.Controls.Add(this.lblFecha);
            this.gbxDatos.Controls.Add(this.lblCiNit);
            this.gbxDatos.Controls.Add(this.nudTotalVenta);
            this.gbxDatos.Controls.Add(this.cbxTipoPago);
            this.gbxDatos.Controls.Add(this.lblIdEmpleado);
            this.gbxDatos.Controls.Add(this.lblidSucursal);
            this.gbxDatos.Controls.Add(this.lblidCliente);
            this.gbxDatos.Location = new System.Drawing.Point(2, 51);
            this.gbxDatos.Name = "gbxDatos";
            this.gbxDatos.Size = new System.Drawing.Size(419, 383);
            this.gbxDatos.TabIndex = 12;
            this.gbxDatos.TabStop = false;
            this.gbxDatos.Text = "Datos";
            // 
            // lblTipoPago
            // 
            this.lblTipoPago.AutoSize = true;
            this.lblTipoPago.Location = new System.Drawing.Point(16, 195);
            this.lblTipoPago.Name = "lblTipoPago";
            this.lblTipoPago.Size = new System.Drawing.Size(74, 13);
            this.lblTipoPago.TabIndex = 11;
            this.lblTipoPago.Text = "Tipo de Pago:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(207, 335);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(101, 42);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(96, 335);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 42);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(16, 159);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 8;
            this.lblFecha.Text = "Fecha";
            // 
            // lblCiNit
            // 
            this.lblCiNit.AutoSize = true;
            this.lblCiNit.Location = new System.Drawing.Point(16, 128);
            this.lblCiNit.Name = "lblCiNit";
            this.lblCiNit.Size = new System.Drawing.Size(43, 13);
            this.lblCiNit.TabIndex = 7;
            this.lblCiNit.Text = "CI/NIT:";
            // 
            // nudTotalVenta
            // 
            this.nudTotalVenta.Location = new System.Drawing.Point(309, 230);
            this.nudTotalVenta.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTotalVenta.Name = "nudTotalVenta";
            this.nudTotalVenta.Size = new System.Drawing.Size(104, 20);
            this.nudTotalVenta.TabIndex = 6;
            this.nudTotalVenta.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // cbxTipoPago
            // 
            this.cbxTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoPago.FormattingEnabled = true;
            this.cbxTipoPago.Location = new System.Drawing.Point(110, 190);
            this.cbxTipoPago.Name = "cbxTipoPago";
            this.cbxTipoPago.Size = new System.Drawing.Size(303, 21);
            this.cbxTipoPago.TabIndex = 3;
            // 
            // lblIdEmpleado
            // 
            this.lblIdEmpleado.AutoSize = true;
            this.lblIdEmpleado.Location = new System.Drawing.Point(18, 95);
            this.lblIdEmpleado.Name = "lblIdEmpleado";
            this.lblIdEmpleado.Size = new System.Drawing.Size(57, 13);
            this.lblIdEmpleado.TabIndex = 2;
            this.lblIdEmpleado.Text = "Empleado:";
            // 
            // lblidSucursal
            // 
            this.lblidSucursal.AutoSize = true;
            this.lblidSucursal.Location = new System.Drawing.Point(18, 61);
            this.lblidSucursal.Name = "lblidSucursal";
            this.lblidSucursal.Size = new System.Drawing.Size(51, 13);
            this.lblidSucursal.TabIndex = 1;
            this.lblidSucursal.Text = "Sucursal:";
            // 
            // lblidCliente
            // 
            this.lblidCliente.AutoSize = true;
            this.lblidCliente.Location = new System.Drawing.Point(18, 20);
            this.lblidCliente.Name = "lblidCliente";
            this.lblidCliente.Size = new System.Drawing.Size(42, 13);
            this.lblidCliente.TabIndex = 0;
            this.lblidCliente.Text = "Cliente:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(149, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(147, 39);
            this.lblTitulo.TabIndex = 27;
            this.lblTitulo.Text = "Omnicell";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(16, 232);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(57, 13);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Total( bs ):";
            // 
            // txtCINit
            // 
            this.txtCINit.Location = new System.Drawing.Point(81, 125);
            this.txtCINit.MaxLength = 30;
            this.txtCINit.Name = "txtCINit";
            this.txtCINit.Size = new System.Drawing.Size(333, 20);
            this.txtCINit.TabIndex = 14;
            // 
            // dtpFechaVenta
            // 
            this.dtpFechaVenta.Location = new System.Drawing.Point(96, 156);
            this.dtpFechaVenta.Name = "dtpFechaVenta";
            this.dtpFechaVenta.Size = new System.Drawing.Size(318, 20);
            this.dtpFechaVenta.TabIndex = 15;
            // 
            // cbxEmpleado
            // 
            this.cbxEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEmpleado.FormattingEnabled = true;
            this.cbxEmpleado.Location = new System.Drawing.Point(81, 92);
            this.cbxEmpleado.Name = "cbxEmpleado";
            this.cbxEmpleado.Size = new System.Drawing.Size(333, 21);
            this.cbxEmpleado.TabIndex = 16;
            // 
            // cbxSucursal
            // 
            this.cbxSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSucursal.FormattingEnabled = true;
            this.cbxSucursal.Location = new System.Drawing.Point(75, 58);
            this.cbxSucursal.Name = "cbxSucursal";
            this.cbxSucursal.Size = new System.Drawing.Size(338, 21);
            this.cbxSucursal.TabIndex = 17;
            // 
            // cbxCliente
            // 
            this.cbxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCliente.FormattingEnabled = true;
            this.cbxCliente.Location = new System.Drawing.Point(66, 17);
            this.cbxCliente.Name = "cbxCliente";
            this.cbxCliente.Size = new System.Drawing.Size(347, 21);
            this.cbxCliente.TabIndex = 18;
            this.cbxCliente.SelectedIndexChanged += new System.EventHandler(this.cbxCliente_SelectedIndexChanged);
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(433, 446);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gbxDatos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: Omnicell - Ventas :::";
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            this.gbxDatos.ResumeLayout(false);
            this.gbxDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxDatos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCiNit;
        private System.Windows.Forms.NumericUpDown nudTotalVenta;
        private System.Windows.Forms.ComboBox cbxTipoPago;
        private System.Windows.Forms.Label lblIdEmpleado;
        private System.Windows.Forms.Label lblidSucursal;
        private System.Windows.Forms.Label lblidCliente;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTipoPago;
        private System.Windows.Forms.DateTimePicker dtpFechaVenta;
        private System.Windows.Forms.TextBox txtCINit;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cbxCliente;
        private System.Windows.Forms.ComboBox cbxSucursal;
        private System.Windows.Forms.ComboBox cbxEmpleado;
    }
}