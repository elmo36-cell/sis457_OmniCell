namespace CpOmnicell
{
    partial class FrmDetalleVenta
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
            this.cabeceraOmnicell = new CpOmnicell.CabeceraOmnicell();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetalleVenta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxDatosDeVenta = new CpOmnicell.GroupBoxOmnicell();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblNumeroVenta = new System.Windows.Forms.Label();
            this.dgvDetalleVenta = new CpOmnicell.GrillaOmnicell();
            this.colSku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTegnologia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblProductosVendidos = new System.Windows.Forms.Label();
            this.lblTipoPago = new System.Windows.Forms.Label();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.btnCerrar = new CpOmnicell.BotonOmnicell();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblCiNit = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblFechaVenta = new System.Windows.Forms.Label();
            this.gbxDatosDeVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxDatosDeVenta
            // 
            this.gbxDatosDeVenta.Controls.Add(this.pictureBox1);
            this.gbxDatosDeVenta.Controls.Add(this.label10);
            this.gbxDatosDeVenta.Controls.Add(this.label9);
            this.gbxDatosDeVenta.Controls.Add(this.label8);
            this.gbxDatosDeVenta.Controls.Add(this.label6);
            this.gbxDatosDeVenta.Controls.Add(this.label5);
            this.gbxDatosDeVenta.Controls.Add(this.label4);
            this.gbxDatosDeVenta.Controls.Add(this.label3);
            this.gbxDatosDeVenta.Controls.Add(this.label2);
            this.gbxDatosDeVenta.Controls.Add(this.label1);
            this.gbxDatosDeVenta.Controls.Add(this.lblCargo);
            this.gbxDatosDeVenta.Controls.Add(this.lblNumeroVenta);
            this.gbxDatosDeVenta.Controls.Add(this.dgvDetalleVenta);
            this.gbxDatosDeVenta.Controls.Add(this.lblTotal);
            this.gbxDatosDeVenta.Controls.Add(this.lblProductosVendidos);
            this.gbxDatosDeVenta.Controls.Add(this.lblTipoPago);
            this.gbxDatosDeVenta.Controls.Add(this.lblSucursal);
            this.gbxDatosDeVenta.Controls.Add(this.btnCerrar);
            this.gbxDatosDeVenta.Controls.Add(this.lblVendedor);
            this.gbxDatosDeVenta.Controls.Add(this.lblCiNit);
            this.gbxDatosDeVenta.Controls.Add(this.lblCliente);
            this.gbxDatosDeVenta.Controls.Add(this.lblFechaVenta);
            this.gbxDatosDeVenta.Location = new System.Drawing.Point(5, 108);
            this.gbxDatosDeVenta.Name = "gbxDatosDeVenta";
            this.gbxDatosDeVenta.Size = new System.Drawing.Size(1041, 482);
            this.gbxDatosDeVenta.TabIndex = 37;
            this.gbxDatosDeVenta.TabStop = false;
            this.gbxDatosDeVenta.Text = "Información General";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(764, 435);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 39);
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(622, 150);
            this.label10.Name = "label10";
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.label10.Size = new System.Drawing.Size(86, 20);
            this.label10.TabIndex = 50;
            this.label10.Text = "Nº Venta:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(9, 149);
            this.label9.Name = "label9";
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.label9.Size = new System.Drawing.Size(119, 20);
            this.label9.TabIndex = 49;
            this.label9.Text = "Tipo de Pago:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(9, 74);
            this.label8.Name = "label8";
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 48;
            this.label8.Text = "CI/NIT:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(646, 112);
            this.label6.Name = "label6";
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 46;
            this.label6.Text = "Cargo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(624, 74);
            this.label5.Name = "label5";
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 45;
            this.label5.Text = "Sucursal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(803, 444);
            this.label4.Name = "label4";
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "Total (bs):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(616, 36);
            this.label3.Name = "label3";
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "Vendedor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "Cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 115);
            this.label1.Name = "label1";
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Fecha de Venta:";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCargo.Location = new System.Drawing.Point(714, 112);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblCargo.Size = new System.Drawing.Size(56, 20);
            this.lblCargo.TabIndex = 40;
            this.lblCargo.Text = "Cargo:";
            // 
            // lblNumeroVenta
            // 
            this.lblNumeroVenta.AutoSize = true;
            this.lblNumeroVenta.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblNumeroVenta.Location = new System.Drawing.Point(714, 150);
            this.lblNumeroVenta.Name = "lblNumeroVenta";
            this.lblNumeroVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblNumeroVenta.Size = new System.Drawing.Size(77, 20);
            this.lblNumeroVenta.TabIndex = 38;
            this.lblNumeroVenta.Text = "Nº Venta:";
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.AllowUserToAddRows = false;
            this.dgvDetalleVenta.AllowUserToDeleteRows = false;
            this.dgvDetalleVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSku,
            this.colMarca,
            this.colModelo,
            this.colDescripcion,
            this.colCalidad,
            this.colTegnologia,
            this.colCantidad,
            this.colPrecio,
            this.colSubtotal});
            this.dgvDetalleVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleVenta.AllowUserToResizeColumns = false;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(6, 213);
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleVenta.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetalleVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleVenta.Size = new System.Drawing.Size(1029, 198);
            this.dgvDetalleVenta.TabIndex = 36;
            // 
            // colSku
            // 
            this.colSku.HeaderText = "SKU";
            this.colSku.Name = "colSku";
            this.colSku.FillWeight = 70F;
            // 
            // colMarca
            // 
            this.colMarca.HeaderText = "Marca";
            this.colMarca.Name = "colMarca";
            this.colMarca.FillWeight = 85F;
            // 
            // colModelo
            // 
            this.colModelo.HeaderText = "Modelo";
            this.colModelo.Name = "colModelo";
            this.colModelo.FillWeight = 85F;
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.FillWeight = 220F;
            // 
            // colCalidad
            // 
            this.colCalidad.HeaderText = "Calidad";
            this.colCalidad.Name = "colCalidad";
            this.colCalidad.FillWeight = 80F;
            // 
            // colTegnologia
            // 
            this.colTegnologia.HeaderText = "Tecnología";
            this.colTegnologia.Name = "colTegnologia";
            this.colTegnologia.FillWeight = 90F;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cant.";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.FillWeight = 70F;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "P. unitario";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.FillWeight = 95F;
            // 
            // colSubtotal
            // 
            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.FillWeight = 95F;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(918, 443);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblTotal.Size = new System.Drawing.Size(40, 20);
            this.lblTotal.TabIndex = 34;
            this.lblTotal.Text = "(bs):";
            // 
            // lblProductosVendidos
            // 
            this.lblProductosVendidos.AutoSize = true;
            this.lblProductosVendidos.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblProductosVendidos.Location = new System.Drawing.Point(9, 186);
            this.lblProductosVendidos.Name = "lblProductosVendidos";
            this.lblProductosVendidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblProductosVendidos.Size = new System.Drawing.Size(168, 20);
            this.lblProductosVendidos.TabIndex = 33;
            this.lblProductosVendidos.Text = "Pantallas Vendidas:";
            // 
            // lblTipoPago
            // 
            this.lblTipoPago.AutoSize = true;
            this.lblTipoPago.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTipoPago.Location = new System.Drawing.Point(134, 150);
            this.lblTipoPago.Name = "lblTipoPago";
            this.lblTipoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblTipoPago.Size = new System.Drawing.Size(106, 20);
            this.lblTipoPago.TabIndex = 29;
            this.lblTipoPago.Text = "Tipo de Pago:";
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblSucursal.Location = new System.Drawing.Point(714, 74);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblSucursal.Size = new System.Drawing.Size(75, 20);
            this.lblSucursal.TabIndex = 25;
            this.lblSucursal.Text = "Sucursal:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(6, 432);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.btnCerrar.IconoOmnicell = CpOmnicell.Icono.Cancelar;
            this.btnCerrar.Size = new System.Drawing.Size(103, 42);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblVendedor.Location = new System.Drawing.Point(714, 36);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblVendedor.Size = new System.Drawing.Size(83, 20);
            this.lblVendedor.TabIndex = 7;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // lblCiNit
            // 
            this.lblCiNit.AutoSize = true;
            this.lblCiNit.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCiNit.Location = new System.Drawing.Point(80, 74);
            this.lblCiNit.Name = "lblCiNit";
            this.lblCiNit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblCiNit.Size = new System.Drawing.Size(58, 20);
            this.lblCiNit.TabIndex = 2;
            this.lblCiNit.Text = "CI/NIT:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCliente.Location = new System.Drawing.Point(80, 36);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblCliente.Size = new System.Drawing.Size(62, 20);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblFechaVenta
            // 
            this.lblFechaVenta.AutoSize = true;
            this.lblFechaVenta.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblFechaVenta.Location = new System.Drawing.Point(163, 115);
            this.lblFechaVenta.Name = "lblFechaVenta";
            this.lblFechaVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblFechaVenta.Size = new System.Drawing.Size(127, 20);
            this.lblFechaVenta.TabIndex = 0;
            this.lblFechaVenta.Text = "Fecha de Venta:";
            // 
            // 
            // cabeceraOmnicell
            // 
            this.cabeceraOmnicell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cabeceraOmnicell.IconoOmnicell = CpOmnicell.Icono.Detalles;
            this.cabeceraOmnicell.Location = new System.Drawing.Point(0, 0);
            this.cabeceraOmnicell.Name = "cabeceraOmnicell";
            this.cabeceraOmnicell.Size = new System.Drawing.Size(1051, 76);
            this.cabeceraOmnicell.Subtitulo = "Cliente, productos y totales de la venta";
            this.cabeceraOmnicell.TabIndex = 0;
            this.cabeceraOmnicell.Titulo = "Detalle de venta";
            // FrmDetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1051, 604);
            this.Controls.Add(this.gbxDatosDeVenta);
            this.Controls.Add(this.cabeceraOmnicell);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmDetalleVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: Omnicell - Detalle De la Venta :::";
            this.Load += new System.EventHandler(this.FrmDetalleVenta_Load);
            this.gbxDatosDeVenta.ResumeLayout(false);
            this.gbxDatosDeVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CpOmnicell.CabeceraOmnicell cabeceraOmnicell;

        private CpOmnicell.GroupBoxOmnicell gbxDatosDeVenta;
        private System.Windows.Forms.Label lblTipoPago;
        private System.Windows.Forms.Label lblSucursal;
        private CpOmnicell.BotonOmnicell btnCerrar;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblCiNit;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblFechaVenta;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblProductosVendidos;
        private CpOmnicell.GrillaOmnicell dgvDetalleVenta;
        private System.Windows.Forms.Label lblNumeroVenta;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSku;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTegnologia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}