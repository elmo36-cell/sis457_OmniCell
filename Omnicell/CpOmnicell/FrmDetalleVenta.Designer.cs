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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetalleVenta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDetalleVenta = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbxDatosDeVenta = new System.Windows.Forms.GroupBox();
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
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblCiNit = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblFechaVenta = new System.Windows.Forms.Label();
            this.gbxDatosDeVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDetalleVenta
            // 
            this.lblDetalleVenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetalleVenta.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleVenta.Image = ((System.Drawing.Image)(resources.GetObject("lblDetalleVenta.Image")));
            this.lblDetalleVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDetalleVenta.Location = new System.Drawing.Point(173, 31);
            this.lblDetalleVenta.Name = "lblDetalleVenta";
            this.lblDetalleVenta.Size = new System.Drawing.Size(317, 36);
            this.lblDetalleVenta.TabIndex = 39;
            this.lblDetalleVenta.Text = "Detalles de la Venta";
            this.lblDetalleVenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(-1, -1);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(81, 22);
            this.lblTitulo.TabIndex = 38;
            this.lblTitulo.Text = "Omnicell";
            // 
            // gbxDatosDeVenta
            // 
            this.gbxDatosDeVenta.BackColor = System.Drawing.Color.CornflowerBlue;
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
            this.gbxDatosDeVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDatosDeVenta.Location = new System.Drawing.Point(12, 86);
            this.gbxDatosDeVenta.Name = "gbxDatosDeVenta";
            this.gbxDatosDeVenta.Size = new System.Drawing.Size(653, 482);
            this.gbxDatosDeVenta.TabIndex = 37;
            this.gbxDatosDeVenta.TabStop = false;
            this.gbxDatosDeVenta.Text = "Información General";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(404, 435);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 39);
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(322, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 20);
            this.label10.TabIndex = 50;
            this.label10.Text = "Nº Venta:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 20);
            this.label9.TabIndex = 49;
            this.label9.Text = "Tipo de Pago:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 48;
            this.label8.Text = "CI/NIT:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(346, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 46;
            this.label6.Text = "Cargo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(324, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 45;
            this.label5.Text = "Sucursal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(443, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "Total (bs):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(316, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "Vendedor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "Cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Fecha de Venta:";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.Location = new System.Drawing.Point(414, 112);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(56, 20);
            this.lblCargo.TabIndex = 40;
            this.lblCargo.Text = "Cargo:";
            // 
            // lblNumeroVenta
            // 
            this.lblNumeroVenta.AutoSize = true;
            this.lblNumeroVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroVenta.Location = new System.Drawing.Point(414, 150);
            this.lblNumeroVenta.Name = "lblNumeroVenta";
            this.lblNumeroVenta.Size = new System.Drawing.Size(77, 20);
            this.lblNumeroVenta.TabIndex = 38;
            this.lblNumeroVenta.Text = "Nº Venta:";
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.AllowUserToAddRows = false;
            this.dgvDetalleVenta.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalleVenta.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.dgvDetalleVenta.Size = new System.Drawing.Size(641, 198);
            this.dgvDetalleVenta.TabIndex = 36;
            // 
            // colSku
            // 
            this.colSku.HeaderText = "SKU";
            this.colSku.Name = "colSku";
            // 
            // colMarca
            // 
            this.colMarca.HeaderText = "Marca";
            this.colMarca.Name = "colMarca";
            // 
            // colModelo
            // 
            this.colModelo.HeaderText = "Modelo";
            this.colModelo.Name = "colModelo";
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            // 
            // colCalidad
            // 
            this.colCalidad.HeaderText = "Calidad";
            this.colCalidad.Name = "colCalidad";
            // 
            // colTegnologia
            // 
            this.colTegnologia.HeaderText = "Tecnología";
            this.colTegnologia.Name = "colTegnologia";
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio Unitario";
            this.colPrecio.Name = "colPrecio";
            // 
            // colSubtotal
            // 
            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.Name = "colSubtotal";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(558, 443);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(40, 20);
            this.lblTotal.TabIndex = 34;
            this.lblTotal.Text = "(bs):";
            // 
            // lblProductosVendidos
            // 
            this.lblProductosVendidos.AutoSize = true;
            this.lblProductosVendidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductosVendidos.Location = new System.Drawing.Point(9, 186);
            this.lblProductosVendidos.Name = "lblProductosVendidos";
            this.lblProductosVendidos.Size = new System.Drawing.Size(168, 20);
            this.lblProductosVendidos.TabIndex = 33;
            this.lblProductosVendidos.Text = "Pantallas Vendidas:";
            // 
            // lblTipoPago
            // 
            this.lblTipoPago.AutoSize = true;
            this.lblTipoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoPago.Location = new System.Drawing.Point(134, 150);
            this.lblTipoPago.Name = "lblTipoPago";
            this.lblTipoPago.Size = new System.Drawing.Size(106, 20);
            this.lblTipoPago.TabIndex = 29;
            this.lblTipoPago.Text = "Tipo de Pago:";
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSucursal.Location = new System.Drawing.Point(414, 74);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(75, 20);
            this.lblSucursal.TabIndex = 25;
            this.lblSucursal.Text = "Sucursal:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.White;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.Location = new System.Drawing.Point(6, 432);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(103, 42);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedor.Location = new System.Drawing.Point(414, 36);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(83, 20);
            this.lblVendedor.TabIndex = 7;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // lblCiNit
            // 
            this.lblCiNit.AutoSize = true;
            this.lblCiNit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCiNit.Location = new System.Drawing.Point(80, 74);
            this.lblCiNit.Name = "lblCiNit";
            this.lblCiNit.Size = new System.Drawing.Size(58, 20);
            this.lblCiNit.TabIndex = 2;
            this.lblCiNit.Text = "CI/NIT:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(80, 36);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(62, 20);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblFechaVenta
            // 
            this.lblFechaVenta.AutoSize = true;
            this.lblFechaVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaVenta.Location = new System.Drawing.Point(163, 115);
            this.lblFechaVenta.Name = "lblFechaVenta";
            this.lblFechaVenta.Size = new System.Drawing.Size(127, 20);
            this.lblFechaVenta.TabIndex = 0;
            this.lblFechaVenta.Text = "Fecha de Venta:";
            // 
            // FrmDetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(677, 572);
            this.Controls.Add(this.lblDetalleVenta);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gbxDatosDeVenta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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

        private System.Windows.Forms.Label lblDetalleVenta;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbxDatosDeVenta;
        private System.Windows.Forms.Label lblTipoPago;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblCiNit;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblFechaVenta;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblProductosVendidos;
        private System.Windows.Forms.DataGridView dgvDetalleVenta;
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