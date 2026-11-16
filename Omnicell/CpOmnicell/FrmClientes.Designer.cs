namespace CpOmnicell
{
    partial class FrmClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientes));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbxDatosCliente = new System.Windows.Forms.GroupBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPrimerApellido = new System.Windows.Forms.TextBox();
            this.txtSegundoApellido = new System.Windows.Forms.TextBox();
            this.txtCINit = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblTipoCliente = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.lblCiNit = new System.Windows.Forms.Label();
            this.cbxTipoCliente = new System.Windows.Forms.ComboBox();
            this.lblSegundoApellido = new System.Windows.Forms.Label();
            this.lblPrimerApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTituloCliente = new System.Windows.Forms.Label();
            this.gbxDatosCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(3, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(81, 22);
            this.lblTitulo.TabIndex = 29;
            this.lblTitulo.Text = "Omnicell";
            // 
            // gbxDatosCliente
            // 
            this.gbxDatosCliente.BackColor = System.Drawing.Color.DodgerBlue;
            this.gbxDatosCliente.Controls.Add(this.txtTelefono);
            this.gbxDatosCliente.Controls.Add(this.txtDireccion);
            this.gbxDatosCliente.Controls.Add(this.txtRazonSocial);
            this.gbxDatosCliente.Controls.Add(this.lblDireccion);
            this.gbxDatosCliente.Controls.Add(this.txtNombre);
            this.gbxDatosCliente.Controls.Add(this.txtPrimerApellido);
            this.gbxDatosCliente.Controls.Add(this.txtSegundoApellido);
            this.gbxDatosCliente.Controls.Add(this.txtCINit);
            this.gbxDatosCliente.Controls.Add(this.lblTelefono);
            this.gbxDatosCliente.Controls.Add(this.lblTipoCliente);
            this.gbxDatosCliente.Controls.Add(this.btnGuardar);
            this.gbxDatosCliente.Controls.Add(this.btnCancelar);
            this.gbxDatosCliente.Controls.Add(this.lblRazonSocial);
            this.gbxDatosCliente.Controls.Add(this.lblCiNit);
            this.gbxDatosCliente.Controls.Add(this.cbxTipoCliente);
            this.gbxDatosCliente.Controls.Add(this.lblSegundoApellido);
            this.gbxDatosCliente.Controls.Add(this.lblPrimerApellido);
            this.gbxDatosCliente.Controls.Add(this.lblNombre);
            this.gbxDatosCliente.Location = new System.Drawing.Point(7, 53);
            this.gbxDatosCliente.Name = "gbxDatosCliente";
            this.gbxDatosCliente.Size = new System.Drawing.Size(419, 383);
            this.gbxDatosCliente.TabIndex = 28;
            this.gbxDatosCliente.TabStop = false;
            this.gbxDatosCliente.Text = "Datos de Cliente";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(91, 225);
            this.txtTelefono.MaxLength = 30;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(323, 20);
            this.txtTelefono.TabIndex = 22;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(90, 254);
            this.txtDireccion.MaxLength = 30;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(323, 20);
            this.txtDireccion.TabIndex = 21;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(95, 156);
            this.txtRazonSocial.MaxLength = 30;
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(318, 20);
            this.txtRazonSocial.TabIndex = 20;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(18, 257);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 19;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(79, 22);
            this.txtNombre.MaxLength = 30;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(333, 20);
            this.txtNombre.TabIndex = 18;
            // 
            // txtPrimerApellido
            // 
            this.txtPrimerApellido.Location = new System.Drawing.Point(103, 57);
            this.txtPrimerApellido.MaxLength = 30;
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Size = new System.Drawing.Size(311, 20);
            this.txtPrimerApellido.TabIndex = 17;
            // 
            // txtSegundoApellido
            // 
            this.txtSegundoApellido.Location = new System.Drawing.Point(116, 92);
            this.txtSegundoApellido.MaxLength = 30;
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(297, 20);
            this.txtSegundoApellido.TabIndex = 16;
            // 
            // txtCINit
            // 
            this.txtCINit.Location = new System.Drawing.Point(80, 125);
            this.txtCINit.MaxLength = 30;
            this.txtCINit.Name = "txtCINit";
            this.txtCINit.Size = new System.Drawing.Size(333, 20);
            this.txtCINit.TabIndex = 14;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(16, 232);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 12;
            this.lblTelefono.Text = "Telefono:";
            // 
            // lblTipoCliente
            // 
            this.lblTipoCliente.AutoSize = true;
            this.lblTipoCliente.Location = new System.Drawing.Point(16, 195);
            this.lblTipoCliente.Name = "lblTipoCliente";
            this.lblTipoCliente.Size = new System.Drawing.Size(81, 13);
            this.lblTipoCliente.TabIndex = 11;
            this.lblTipoCliente.Text = "Tipo de Cliente:";
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
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Location = new System.Drawing.Point(16, 159);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(73, 13);
            this.lblRazonSocial.TabIndex = 8;
            this.lblRazonSocial.Text = "Razon Social:";
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
            // cbxTipoCliente
            // 
            this.cbxTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoCliente.FormattingEnabled = true;
            this.cbxTipoCliente.Location = new System.Drawing.Point(110, 190);
            this.cbxTipoCliente.Name = "cbxTipoCliente";
            this.cbxTipoCliente.Size = new System.Drawing.Size(303, 21);
            this.cbxTipoCliente.TabIndex = 3;
            // 
            // lblSegundoApellido
            // 
            this.lblSegundoApellido.AutoSize = true;
            this.lblSegundoApellido.Location = new System.Drawing.Point(18, 95);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.Size = new System.Drawing.Size(93, 13);
            this.lblSegundoApellido.TabIndex = 2;
            this.lblSegundoApellido.Text = "Segundo Apellido:";
            // 
            // lblPrimerApellido
            // 
            this.lblPrimerApellido.AutoSize = true;
            this.lblPrimerApellido.Location = new System.Drawing.Point(18, 61);
            this.lblPrimerApellido.Name = "lblPrimerApellido";
            this.lblPrimerApellido.Size = new System.Drawing.Size(79, 13);
            this.lblPrimerApellido.TabIndex = 1;
            this.lblPrimerApellido.Text = "Primer Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(18, 25);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(52, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombres:";
            // 
            // lblTituloCliente
            // 
            this.lblTituloCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloCliente.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCliente.Image = ((System.Drawing.Image)(resources.GetObject("lblTituloCliente.Image")));
            this.lblTituloCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTituloCliente.Location = new System.Drawing.Point(104, 14);
            this.lblTituloCliente.Name = "lblTituloCliente";
            this.lblTituloCliente.Size = new System.Drawing.Size(248, 36);
            this.lblTituloCliente.TabIndex = 30;
            this.lblTituloCliente.Text = "Nuevo Cliente";
            this.lblTituloCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(433, 446);
            this.Controls.Add(this.lblTituloCliente);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gbxDatosCliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: Omnicell - Clientes :::";
            this.Load += new System.EventHandler(this.FrmClientes_Load);
            this.gbxDatosCliente.ResumeLayout(false);
            this.gbxDatosCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbxDatosCliente;
        private System.Windows.Forms.TextBox txtCINit;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblTipoCliente;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.Label lblCiNit;
        private System.Windows.Forms.ComboBox cbxTipoCliente;
        private System.Windows.Forms.Label lblSegundoApellido;
        private System.Windows.Forms.Label lblPrimerApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPrimerApellido;
        private System.Windows.Forms.TextBox txtSegundoApellido;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label lblTituloCliente;
    }
}