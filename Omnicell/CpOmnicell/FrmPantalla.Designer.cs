namespace CpOmnicell
{
    partial class FrmPantalla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPantalla));
            this.gbxDatosCliente = new CpOmnicell.GroupBoxOmnicell();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cbxMarca = new System.Windows.Forms.ComboBox();
            this.nudPrecioVenta = new System.Windows.Forms.NumericUpDown();
            this.nudStockTotal = new System.Windows.Forms.NumericUpDown();
            this.txtSku = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCalidad = new System.Windows.Forms.TextBox();
            this.txtTecnologia = new System.Windows.Forms.TextBox();
            this.lblStockTotal = new System.Windows.Forms.Label();
            this.btnGuardar = new CpOmnicell.BotonOmnicell();
            this.btnCancelar = new CpOmnicell.BotonOmnicell();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.lblTecnologia = new System.Windows.Forms.Label();
            this.lblCalidad = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblSku = new System.Windows.Forms.Label();
            this.gbxDatosCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStockTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxDatosCliente
            // 
            this.gbxDatosCliente.BackColor = System.Drawing.Color.White;
            this.gbxDatosCliente.Controls.Add(this.txtModelo);
            this.gbxDatosCliente.Controls.Add(this.lblModelo);
            this.gbxDatosCliente.Controls.Add(this.lblMarca);
            this.gbxDatosCliente.Controls.Add(this.cbxMarca);
            this.gbxDatosCliente.Controls.Add(this.nudPrecioVenta);
            this.gbxDatosCliente.Controls.Add(this.nudStockTotal);
            this.gbxDatosCliente.Controls.Add(this.txtSku);
            this.gbxDatosCliente.Controls.Add(this.txtDescripcion);
            this.gbxDatosCliente.Controls.Add(this.txtCalidad);
            this.gbxDatosCliente.Controls.Add(this.txtTecnologia);
            this.gbxDatosCliente.Controls.Add(this.lblStockTotal);
            this.gbxDatosCliente.Controls.Add(this.btnGuardar);
            this.gbxDatosCliente.Controls.Add(this.btnCancelar);
            this.gbxDatosCliente.Controls.Add(this.lblPrecioVenta);
            this.gbxDatosCliente.Controls.Add(this.lblTecnologia);
            this.gbxDatosCliente.Controls.Add(this.lblCalidad);
            this.gbxDatosCliente.Controls.Add(this.lblDescripcion);
            this.gbxDatosCliente.Controls.Add(this.lblSku);
            this.gbxDatosCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.gbxDatosCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.gbxDatosCliente.Location = new System.Drawing.Point(5, 108);
            this.gbxDatosCliente.Name = "gbxDatosCliente";
            this.gbxDatosCliente.Padding = new System.Windows.Forms.Padding(6, 4, 6, 6);
            this.gbxDatosCliente.Size = new System.Drawing.Size(750, 270);
            this.gbxDatosCliente.TabIndex = 31;
            this.gbxDatosCliente.TabStop = false;
            this.gbxDatosCliente.Text = "Datos de Pantalla";
            // 
            // txtModelo
            // 
            this.txtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelo.Location = new System.Drawing.Point(526, 114);
            this.txtModelo.MaxLength = 30;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(200, 24);
            this.txtModelo.TabIndex = 27;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblModelo.Location = new System.Drawing.Point(386, 117);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(51, 15);
            this.lblModelo.TabIndex = 26;
            this.lblModelo.Text = "Modelo:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblMarca.Location = new System.Drawing.Point(22, 117);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(44, 15);
            this.lblMarca.TabIndex = 25;
            this.lblMarca.Text = "Marca:";
            // 
            // cbxMarca
            // 
            this.cbxMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMarca.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxMarca.FormattingEnabled = true;
            this.cbxMarca.Location = new System.Drawing.Point(162, 114);
            this.cbxMarca.Name = "cbxMarca";
            this.cbxMarca.Size = new System.Drawing.Size(190, 23);
            this.cbxMarca.TabIndex = 24;
            // 
            // nudPrecioVenta
            // 
            this.nudPrecioVenta.Location = new System.Drawing.Point(162, 154);
            this.nudPrecioVenta.Name = "nudPrecioVenta";
            this.nudPrecioVenta.Size = new System.Drawing.Size(190, 24);
            this.nudPrecioVenta.TabIndex = 23;
            // 
            // nudStockTotal
            // 
            this.nudStockTotal.Location = new System.Drawing.Point(526, 154);
            this.nudStockTotal.Name = "nudStockTotal";
            this.nudStockTotal.Size = new System.Drawing.Size(200, 24);
            this.nudStockTotal.TabIndex = 22;
            // 
            // txtSku
            // 
            this.txtSku.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSku.Location = new System.Drawing.Point(162, 34);
            this.txtSku.MaxLength = 30;
            this.txtSku.Name = "txtSku";
            this.txtSku.Size = new System.Drawing.Size(190, 24);
            this.txtSku.TabIndex = 18;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Location = new System.Drawing.Point(526, 34);
            this.txtDescripcion.MaxLength = 30;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(200, 24);
            this.txtDescripcion.TabIndex = 17;
            // 
            // txtCalidad
            // 
            this.txtCalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCalidad.Location = new System.Drawing.Point(162, 74);
            this.txtCalidad.MaxLength = 30;
            this.txtCalidad.Name = "txtCalidad";
            this.txtCalidad.Size = new System.Drawing.Size(190, 24);
            this.txtCalidad.TabIndex = 16;
            // 
            // txtTecnologia
            // 
            this.txtTecnologia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTecnologia.Location = new System.Drawing.Point(526, 74);
            this.txtTecnologia.MaxLength = 30;
            this.txtTecnologia.Name = "txtTecnologia";
            this.txtTecnologia.Size = new System.Drawing.Size(200, 24);
            this.txtTecnologia.TabIndex = 14;
            // 
            // lblStockTotal
            // 
            this.lblStockTotal.AutoSize = true;
            this.lblStockTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblStockTotal.Location = new System.Drawing.Point(386, 157);
            this.lblStockTotal.Name = "lblStockTotal";
            this.lblStockTotal.Size = new System.Drawing.Size(74, 15);
            this.lblStockTotal.TabIndex = 11;
            this.lblStockTotal.Text = "Stock Total:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconoOmnicell = CpOmnicell.Icono.Guardar;
            this.btnGuardar.Location = new System.Drawing.Point(380, 205);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 42);
            this.btnGuardar.TabIndex = 10;
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
            this.btnCancelar.Location = new System.Drawing.Point(250, 205);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 42);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblPrecioVenta.Location = new System.Drawing.Point(22, 157);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(92, 15);
            this.lblPrecioVenta.TabIndex = 8;
            this.lblPrecioVenta.Text = "Precio de Venta:";
            // 
            // lblTecnologia
            // 
            this.lblTecnologia.AutoSize = true;
            this.lblTecnologia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTecnologia.Location = new System.Drawing.Point(386, 77);
            this.lblTecnologia.Name = "lblTecnologia";
            this.lblTecnologia.Size = new System.Drawing.Size(75, 15);
            this.lblTecnologia.TabIndex = 7;
            this.lblTecnologia.Text = "Tecnología:";
            // 
            // lblCalidad
            // 
            this.lblCalidad.AutoSize = true;
            this.lblCalidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblCalidad.Location = new System.Drawing.Point(22, 77);
            this.lblCalidad.Name = "lblCalidad";
            this.lblCalidad.Size = new System.Drawing.Size(55, 15);
            this.lblCalidad.TabIndex = 2;
            this.lblCalidad.Text = "Calidad:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblDescripcion.Location = new System.Drawing.Point(386, 37);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(75, 15);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblSku
            // 
            this.lblSku.AutoSize = true;
            this.lblSku.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblSku.Location = new System.Drawing.Point(22, 37);
            this.lblSku.Name = "lblSku";
            this.lblSku.Size = new System.Drawing.Size(32, 15);
            this.lblSku.TabIndex = 0;
            this.lblSku.Text = "SKU:";
            // 
            // 
            // cabeceraOmnicell
            // 
            this.cabeceraOmnicell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cabeceraOmnicell.IconoOmnicell = CpOmnicell.Icono.Pantalla;
            this.cabeceraOmnicell.Location = new System.Drawing.Point(0, 0);
            this.cabeceraOmnicell.Name = "cabeceraOmnicell";
            this.cabeceraOmnicell.Size = new System.Drawing.Size(760, 76);
            this.cabeceraOmnicell.Subtitulo = "Modelo, marca, tecnología y stock";
            this.cabeceraOmnicell.TabIndex = 0;
            this.cabeceraOmnicell.Titulo = "Pantalla";
            // FrmPantalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(760, 392);
            this.Controls.Add(this.gbxDatosCliente);
            this.Controls.Add(this.cabeceraOmnicell);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPantalla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: Omnicell - Pantallas :::";
            this.Load += new System.EventHandler(this.FrmPantalla_Load);
            this.gbxDatosCliente.ResumeLayout(false);
            this.gbxDatosCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStockTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CpOmnicell.CabeceraOmnicell cabeceraOmnicell;

        private CpOmnicell.GroupBoxOmnicell gbxDatosCliente;
        private System.Windows.Forms.TextBox txtSku;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCalidad;
        private System.Windows.Forms.TextBox txtTecnologia;
        private System.Windows.Forms.Label lblStockTotal;
        private CpOmnicell.BotonOmnicell btnGuardar;
        private CpOmnicell.BotonOmnicell btnCancelar;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.Label lblTecnologia;
        private System.Windows.Forms.Label lblCalidad;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblSku;
        private System.Windows.Forms.NumericUpDown nudPrecioVenta;
        private System.Windows.Forms.NumericUpDown nudStockTotal;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cbxMarca;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblModelo;
    }
}
