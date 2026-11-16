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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPantalla));
            this.lblTituloPantalla = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbxDatosCliente = new System.Windows.Forms.GroupBox();
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
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
            // lblTituloPantalla
            // 
            this.lblTituloPantalla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloPantalla.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPantalla.Image = ((System.Drawing.Image)(resources.GetObject("lblTituloPantalla.Image")));
            this.lblTituloPantalla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTituloPantalla.Location = new System.Drawing.Point(100, 15);
            this.lblTituloPantalla.Name = "lblTituloPantalla";
            this.lblTituloPantalla.Size = new System.Drawing.Size(249, 36);
            this.lblTituloPantalla.TabIndex = 33;
            this.lblTituloPantalla.Text = "Nueva Pantalla";
            this.lblTituloPantalla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(5, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(81, 22);
            this.lblTitulo.TabIndex = 32;
            this.lblTitulo.Text = "Omnicell";
            // 
            // gbxDatosCliente
            // 
            this.gbxDatosCliente.BackColor = System.Drawing.Color.DodgerBlue;
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
            this.gbxDatosCliente.Location = new System.Drawing.Point(9, 54);
            this.gbxDatosCliente.Name = "gbxDatosCliente";
            this.gbxDatosCliente.Size = new System.Drawing.Size(439, 383);
            this.gbxDatosCliente.TabIndex = 31;
            this.gbxDatosCliente.TabStop = false;
            this.gbxDatosCliente.Text = "Datos de Pantalla";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(291, 215);
            this.txtModelo.MaxLength = 30;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(121, 20);
            this.txtModelo.TabIndex = 27;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.Location = new System.Drawing.Point(222, 213);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(72, 20);
            this.lblModelo.TabIndex = 26;
            this.lblModelo.Text = "Modelo:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(19, 213);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(63, 20);
            this.lblMarca.TabIndex = 25;
            this.lblMarca.Text = "Marca:";
            // 
            // cbxMarca
            // 
            this.cbxMarca.FormattingEnabled = true;
            this.cbxMarca.Location = new System.Drawing.Point(88, 212);
            this.cbxMarca.Name = "cbxMarca";
            this.cbxMarca.Size = new System.Drawing.Size(121, 21);
            this.cbxMarca.TabIndex = 24;
            // 
            // nudPrecioVenta
            // 
            this.nudPrecioVenta.Location = new System.Drawing.Point(156, 172);
            this.nudPrecioVenta.Name = "nudPrecioVenta";
            this.nudPrecioVenta.Size = new System.Drawing.Size(78, 20);
            this.nudPrecioVenta.TabIndex = 23;
            // 
            // nudStockTotal
            // 
            this.nudStockTotal.Location = new System.Drawing.Point(344, 171);
            this.nudStockTotal.Name = "nudStockTotal";
            this.nudStockTotal.Size = new System.Drawing.Size(68, 20);
            this.nudStockTotal.TabIndex = 22;
            // 
            // txtSku
            // 
            this.txtSku.Location = new System.Drawing.Point(72, 61);
            this.txtSku.MaxLength = 30;
            this.txtSku.Name = "txtSku";
            this.txtSku.Size = new System.Drawing.Size(122, 20);
            this.txtSku.TabIndex = 18;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(130, 95);
            this.txtDescripcion.MaxLength = 30;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(282, 20);
            this.txtDescripcion.TabIndex = 17;
            // 
            // txtCalidad
            // 
            this.txtCalidad.Location = new System.Drawing.Point(279, 60);
            this.txtCalidad.MaxLength = 30;
            this.txtCalidad.Name = "txtCalidad";
            this.txtCalidad.Size = new System.Drawing.Size(133, 20);
            this.txtCalidad.TabIndex = 16;
            // 
            // txtTecnologia
            // 
            this.txtTecnologia.Location = new System.Drawing.Point(129, 134);
            this.txtTecnologia.MaxLength = 30;
            this.txtTecnologia.Name = "txtTecnologia";
            this.txtTecnologia.Size = new System.Drawing.Size(283, 20);
            this.txtTecnologia.TabIndex = 14;
            // 
            // lblStockTotal
            // 
            this.lblStockTotal.AutoSize = true;
            this.lblStockTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockTotal.Location = new System.Drawing.Point(235, 172);
            this.lblStockTotal.Name = "lblStockTotal";
            this.lblStockTotal.Size = new System.Drawing.Size(105, 20);
            this.lblStockTotal.TabIndex = 11;
            this.lblStockTotal.Text = "Stock Total:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(203, 302);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(119, 42);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(79, 302);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(118, 42);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioVenta.Location = new System.Drawing.Point(8, 171);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(142, 20);
            this.lblPrecioVenta.TabIndex = 8;
            this.lblPrecioVenta.Text = "Precio de Venta:";
            // 
            // lblTecnologia
            // 
            this.lblTecnologia.AutoSize = true;
            this.lblTecnologia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTecnologia.Location = new System.Drawing.Point(21, 133);
            this.lblTecnologia.Name = "lblTecnologia";
            this.lblTecnologia.Size = new System.Drawing.Size(101, 20);
            this.lblTecnologia.TabIndex = 7;
            this.lblTecnologia.Text = "Tecnología:";
            // 
            // lblCalidad
            // 
            this.lblCalidad.AutoSize = true;
            this.lblCalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalidad.Location = new System.Drawing.Point(200, 61);
            this.lblCalidad.Name = "lblCalidad";
            this.lblCalidad.Size = new System.Drawing.Size(74, 20);
            this.lblCalidad.TabIndex = 2;
            this.lblCalidad.Text = "Calidad:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(19, 94);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(108, 20);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblSku
            // 
            this.lblSku.AutoSize = true;
            this.lblSku.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSku.Location = new System.Drawing.Point(21, 61);
            this.lblSku.Name = "lblSku";
            this.lblSku.Size = new System.Drawing.Size(45, 20);
            this.lblSku.TabIndex = 0;
            this.lblSku.Text = "Sku:";
            // 
            // FrmPantalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(456, 446);
            this.Controls.Add(this.lblTituloPantalla);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gbxDatosCliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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

        private System.Windows.Forms.Label lblTituloPantalla;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbxDatosCliente;
        private System.Windows.Forms.TextBox txtSku;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCalidad;
        private System.Windows.Forms.TextBox txtTecnologia;
        private System.Windows.Forms.Label lblStockTotal;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
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