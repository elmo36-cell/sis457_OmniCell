namespace CpOmnicell
{
    partial class FrmDetalleCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetalleCompra));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDetalleVenta = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbxDatosDeVenta = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNumeroCompra = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblContacto = new System.Windows.Forms.Label();
            this.lblNumeroVenta = new System.Windows.Forms.Label();
            this.dgvDetalleCompra = new System.Windows.Forms.DataGridView();
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
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblFactura = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblFechaCompra = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbxDatosDeVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDetalleVenta
            // 
            this.lblDetalleVenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetalleVenta.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleVenta.Image = ((System.Drawing.Image)(resources.GetObject("lblDetalleVenta.Image")));
            this.lblDetalleVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDetalleVenta.Location = new System.Drawing.Point(173, 26);
            this.lblDetalleVenta.Name = "lblDetalleVenta";
            this.lblDetalleVenta.Size = new System.Drawing.Size(352, 36);
            this.lblDetalleVenta.TabIndex = 42;
            this.lblDetalleVenta.Text = "Detalles de la Compra";
            this.lblDetalleVenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(67, -59);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(81, 22);
            this.lblTitulo.TabIndex = 41;
            this.lblTitulo.Text = "Omnicell";
            // 
            // gbxDatosDeVenta
            // 
            this.gbxDatosDeVenta.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gbxDatosDeVenta.Controls.Add(this.pictureBox1);
            this.gbxDatosDeVenta.Controls.Add(this.lblNumeroCompra);
            this.gbxDatosDeVenta.Controls.Add(this.label9);
            this.gbxDatosDeVenta.Controls.Add(this.label8);
            this.gbxDatosDeVenta.Controls.Add(this.label6);
            this.gbxDatosDeVenta.Controls.Add(this.label5);
            this.gbxDatosDeVenta.Controls.Add(this.label4);
            this.gbxDatosDeVenta.Controls.Add(this.label3);
            this.gbxDatosDeVenta.Controls.Add(this.label2);
            this.gbxDatosDeVenta.Controls.Add(this.label1);
            this.gbxDatosDeVenta.Controls.Add(this.lblContacto);
            this.gbxDatosDeVenta.Controls.Add(this.lblNumeroVenta);
            this.gbxDatosDeVenta.Controls.Add(this.dgvDetalleCompra);
            this.gbxDatosDeVenta.Controls.Add(this.lblTotal);
            this.gbxDatosDeVenta.Controls.Add(this.lblProductosVendidos);
            this.gbxDatosDeVenta.Controls.Add(this.lblTelefono);
            this.gbxDatosDeVenta.Controls.Add(this.lblFactura);
            this.gbxDatosDeVenta.Controls.Add(this.btnCerrar);
            this.gbxDatosDeVenta.Controls.Add(this.lblEmpleado);
            this.gbxDatosDeVenta.Controls.Add(this.lblPais);
            this.gbxDatosDeVenta.Controls.Add(this.lblProveedor);
            this.gbxDatosDeVenta.Controls.Add(this.lblFechaCompra);
            this.gbxDatosDeVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDatosDeVenta.Location = new System.Drawing.Point(12, 78);
            this.gbxDatosDeVenta.Name = "gbxDatosDeVenta";
            this.gbxDatosDeVenta.Size = new System.Drawing.Size(653, 482);
            this.gbxDatosDeVenta.TabIndex = 40;
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
            // lblNumeroCompra
            // 
            this.lblNumeroCompra.AutoSize = true;
            this.lblNumeroCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroCompra.Location = new System.Drawing.Point(331, 150);
            this.lblNumeroCompra.Name = "lblNumeroCompra";
            this.lblNumeroCompra.Size = new System.Drawing.Size(100, 20);
            this.lblNumeroCompra.TabIndex = 50;
            this.lblNumeroCompra.Text = "Nº Compra:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 20);
            this.label9.TabIndex = 49;
            this.label9.Text = "Teléfono:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 20);
            this.label8.TabIndex = 48;
            this.label8.Text = "Pais:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(344, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 46;
            this.label6.Text = "Contacto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(343, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 45;
            this.label5.Text = "Factura:";
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
            this.label3.Location = new System.Drawing.Point(335, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "Empleado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "Proveedor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Fecha de Compra:";
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContacto.Location = new System.Drawing.Point(433, 112);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(78, 20);
            this.lblContacto.TabIndex = 40;
            this.lblContacto.Text = "Contacto:";
            // 
            // lblNumeroVenta
            // 
            this.lblNumeroVenta.AutoSize = true;
            this.lblNumeroVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroVenta.Location = new System.Drawing.Point(433, 150);
            this.lblNumeroVenta.Name = "lblNumeroVenta";
            this.lblNumeroVenta.Size = new System.Drawing.Size(77, 20);
            this.lblNumeroVenta.TabIndex = 38;
            this.lblNumeroVenta.Text = "Nº Venta:";
            // 
            // dgvDetalleCompra
            // 
            this.dgvDetalleCompra.AllowUserToAddRows = false;
            this.dgvDetalleCompra.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDetalleCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSku,
            this.colMarca,
            this.colModelo,
            this.colDescripcion,
            this.colCalidad,
            this.colTegnologia,
            this.colCantidad,
            this.colPrecio,
            this.colSubtotal});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalleCompra.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDetalleCompra.Location = new System.Drawing.Point(6, 213);
            this.dgvDetalleCompra.Name = "dgvDetalleCompra";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleCompra.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDetalleCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleCompra.Size = new System.Drawing.Size(641, 198);
            this.dgvDetalleCompra.TabIndex = 36;
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
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(90, 149);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(75, 20);
            this.lblTelefono.TabIndex = 29;
            this.lblTelefono.Text = "Telefono:";
            // 
            // lblFactura
            // 
            this.lblFactura.AutoSize = true;
            this.lblFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFactura.Location = new System.Drawing.Point(433, 74);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(68, 20);
            this.lblFactura.TabIndex = 25;
            this.lblFactura.Text = "Factura:";
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
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleado.Location = new System.Drawing.Point(433, 36);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(85, 20);
            this.lblEmpleado.TabIndex = 7;
            this.lblEmpleado.Text = "Empleado:";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPais.Location = new System.Drawing.Point(80, 74);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(43, 20);
            this.lblPais.TabIndex = 2;
            this.lblPais.Text = "Pais:";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(108, 36);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(85, 20);
            this.lblProveedor.TabIndex = 1;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // lblFechaCompra
            // 
            this.lblFechaCompra.AutoSize = true;
            this.lblFechaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCompra.Location = new System.Drawing.Point(163, 115);
            this.lblFechaCompra.Name = "lblFechaCompra";
            this.lblFechaCompra.Size = new System.Drawing.Size(118, 20);
            this.lblFechaCompra.TabIndex = 0;
            this.lblFechaCompra.Text = "Fecha Compra:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 22);
            this.label7.TabIndex = 43;
            this.label7.Text = "Omnicell";
            // 
            // FrmDetalleCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(677, 572);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblDetalleVenta);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gbxDatosDeVenta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDetalleCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: Omnicell - Detalle Compra :::";
            this.Load += new System.EventHandler(this.FrmDetalleCompra_Load);
            this.gbxDatosDeVenta.ResumeLayout(false);
            this.gbxDatosDeVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDetalleVenta;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbxDatosDeVenta;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNumeroCompra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.Label lblNumeroVenta;
        private System.Windows.Forms.DataGridView dgvDetalleCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSku;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTegnologia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblProductosVendidos;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblFechaCompra;
        private System.Windows.Forms.Label label7;
    }
}