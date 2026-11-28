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
            this.cabeceraOmnicell = new CpOmnicell.CabeceraOmnicell();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientes));
            this.gbxDatosCliente = new CpOmnicell.GroupBoxOmnicell();
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
            this.btnGuardar = new CpOmnicell.BotonOmnicell();
            this.btnCancelar = new CpOmnicell.BotonOmnicell();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.lblCiNit = new System.Windows.Forms.Label();
            this.cbxTipoCliente = new System.Windows.Forms.ComboBox();
            this.lblSegundoApellido = new System.Windows.Forms.Label();
            this.lblPrimerApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gbxDatosCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxDatosCliente
            // 
            this.gbxDatosCliente.BackColor = System.Drawing.Color.White;
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
            this.gbxDatosCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.gbxDatosCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.gbxDatosCliente.Location = new System.Drawing.Point(5, 108);
            this.gbxDatosCliente.Name = "gbxDatosCliente";
            this.gbxDatosCliente.Padding = new System.Windows.Forms.Padding(6, 4, 6, 6);
            this.gbxDatosCliente.Size = new System.Drawing.Size(750, 270);
            this.gbxDatosCliente.TabIndex = 28;
            this.gbxDatosCliente.TabStop = false;
            this.gbxDatosCliente.Text = "Datos de Cliente";
            // 
            // txtTelefono
            // 
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Location = new System.Drawing.Point(162, 154);
            this.txtTelefono.MaxLength = 30;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(190, 24);
            this.txtTelefono.TabIndex = 22;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Location = new System.Drawing.Point(526, 154);
            this.txtDireccion.MaxLength = 30;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(200, 24);
            this.txtDireccion.TabIndex = 21;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRazonSocial.Location = new System.Drawing.Point(162, 114);
            this.txtRazonSocial.MaxLength = 30;
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(190, 24);
            this.txtRazonSocial.TabIndex = 20;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblDireccion.Location = new System.Drawing.Point(386, 157);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(65, 15);
            this.lblDireccion.TabIndex = 19;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Location = new System.Drawing.Point(162, 34);
            this.txtNombre.MaxLength = 30;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(190, 24);
            this.txtNombre.TabIndex = 18;
            // 
            // txtPrimerApellido
            // 
            this.txtPrimerApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrimerApellido.Location = new System.Drawing.Point(526, 34);
            this.txtPrimerApellido.MaxLength = 30;
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Size = new System.Drawing.Size(200, 24);
            this.txtPrimerApellido.TabIndex = 17;
            // 
            // txtSegundoApellido
            // 
            this.txtSegundoApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSegundoApellido.Location = new System.Drawing.Point(162, 74);
            this.txtSegundoApellido.MaxLength = 30;
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(190, 24);
            this.txtSegundoApellido.TabIndex = 16;
            // 
            // txtCINit
            // 
            this.txtCINit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCINit.Location = new System.Drawing.Point(526, 74);
            this.txtCINit.MaxLength = 30;
            this.txtCINit.Name = "txtCINit";
            this.txtCINit.Size = new System.Drawing.Size(200, 24);
            this.txtCINit.TabIndex = 14;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTelefono.Location = new System.Drawing.Point(22, 157);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(60, 15);
            this.lblTelefono.TabIndex = 12;
            this.lblTelefono.Text = "Telefono:";
            // 
            // lblTipoCliente
            // 
            this.lblTipoCliente.AutoSize = true;
            this.lblTipoCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTipoCliente.Location = new System.Drawing.Point(386, 117);
            this.lblTipoCliente.Name = "lblTipoCliente";
            this.lblTipoCliente.Size = new System.Drawing.Size(94, 15);
            this.lblTipoCliente.TabIndex = 11;
            this.lblTipoCliente.Text = "Tipo de Cliente:";
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
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblRazonSocial.Location = new System.Drawing.Point(22, 117);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(81, 15);
            this.lblRazonSocial.TabIndex = 8;
            this.lblRazonSocial.Text = "Razon Social:";
            // 
            // lblCiNit
            // 
            this.lblCiNit.AutoSize = true;
            this.lblCiNit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblCiNit.Location = new System.Drawing.Point(386, 77);
            this.lblCiNit.Name = "lblCiNit";
            this.lblCiNit.Size = new System.Drawing.Size(46, 15);
            this.lblCiNit.TabIndex = 7;
            this.lblCiNit.Text = "CI/NIT:";
            // 
            // cbxTipoCliente
            // 
            this.cbxTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoCliente.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxTipoCliente.FormattingEnabled = true;
            this.cbxTipoCliente.Location = new System.Drawing.Point(526, 114);
            this.cbxTipoCliente.Name = "cbxTipoCliente";
            this.cbxTipoCliente.Size = new System.Drawing.Size(200, 23);
            this.cbxTipoCliente.TabIndex = 3;
            // 
            // lblSegundoApellido
            // 
            this.lblSegundoApellido.AutoSize = true;
            this.lblSegundoApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblSegundoApellido.Location = new System.Drawing.Point(22, 77);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.Size = new System.Drawing.Size(109, 15);
            this.lblSegundoApellido.TabIndex = 2;
            this.lblSegundoApellido.Text = "Segundo Apellido:";
            // 
            // lblPrimerApellido
            // 
            this.lblPrimerApellido.AutoSize = true;
            this.lblPrimerApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblPrimerApellido.Location = new System.Drawing.Point(386, 37);
            this.lblPrimerApellido.Name = "lblPrimerApellido";
            this.lblPrimerApellido.Size = new System.Drawing.Size(98, 15);
            this.lblPrimerApellido.TabIndex = 1;
            this.lblPrimerApellido.Text = "Primer Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblNombre.Location = new System.Drawing.Point(22, 37);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(60, 15);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombres:";
            // 
            // 
            // cabeceraOmnicell
            // 
            this.cabeceraOmnicell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cabeceraOmnicell.IconoOmnicell = CpOmnicell.Icono.Cliente;
            this.cabeceraOmnicell.Location = new System.Drawing.Point(0, 0);
            this.cabeceraOmnicell.Name = "cabeceraOmnicell";
            this.cabeceraOmnicell.Size = new System.Drawing.Size(760, 76);
            this.cabeceraOmnicell.Subtitulo = "Identificación, contacto y tipo de cliente";
            this.cabeceraOmnicell.TabIndex = 0;
            this.cabeceraOmnicell.Titulo = "Clientes";
            // FrmClientes
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
        private CpOmnicell.CabeceraOmnicell cabeceraOmnicell;

        private CpOmnicell.GroupBoxOmnicell gbxDatosCliente;
        private System.Windows.Forms.TextBox txtCINit;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblTipoCliente;
        private CpOmnicell.BotonOmnicell btnGuardar;
        private CpOmnicell.BotonOmnicell btnCancelar;
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
    }
}
