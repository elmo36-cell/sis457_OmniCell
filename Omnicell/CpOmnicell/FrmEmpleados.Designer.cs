namespace CpOmnicell
{
    partial class FrmEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmpleados));
            this.gbxDatosEmpleado = new CpOmnicell.GroupBoxOmnicell();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblCelular = new System.Windows.Forms.Label();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cbxSucursal = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPrimerApellido = new System.Windows.Forms.TextBox();
            this.txtCi = new System.Windows.Forms.TextBox();
            this.txtSegundoApellido = new System.Windows.Forms.TextBox();
            this.btnGuardar = new CpOmnicell.BotonOmnicell();
            this.btnCancelar = new CpOmnicell.BotonOmnicell();
            this.lblSegundoApellido = new System.Windows.Forms.Label();
            this.lblCi = new System.Windows.Forms.Label();
            this.lblPrimerApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gbxDatosEmpleado.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxDatosEmpleado
            // 
            this.gbxDatosEmpleado.Controls.Add(this.txtCelular);
            this.gbxDatosEmpleado.Controls.Add(this.txtDireccion);
            this.gbxDatosEmpleado.Controls.Add(this.lblDireccion);
            this.gbxDatosEmpleado.Controls.Add(this.lblCelular);
            this.gbxDatosEmpleado.Controls.Add(this.txtCargo);
            this.gbxDatosEmpleado.Controls.Add(this.lblCargo);
            this.gbxDatosEmpleado.Controls.Add(this.lblMarca);
            this.gbxDatosEmpleado.Controls.Add(this.cbxSucursal);
            this.gbxDatosEmpleado.Controls.Add(this.txtNombre);
            this.gbxDatosEmpleado.Controls.Add(this.txtPrimerApellido);
            this.gbxDatosEmpleado.Controls.Add(this.txtCi);
            this.gbxDatosEmpleado.Controls.Add(this.txtSegundoApellido);
            this.gbxDatosEmpleado.Controls.Add(this.btnGuardar);
            this.gbxDatosEmpleado.Controls.Add(this.btnCancelar);
            this.gbxDatosEmpleado.Controls.Add(this.lblSegundoApellido);
            this.gbxDatosEmpleado.Controls.Add(this.lblCi);
            this.gbxDatosEmpleado.Controls.Add(this.lblPrimerApellido);
            this.gbxDatosEmpleado.Controls.Add(this.lblNombre);
            this.gbxDatosEmpleado.Location = new System.Drawing.Point(5, 108);
            this.gbxDatosEmpleado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxDatosEmpleado.Name = "gbxDatosEmpleado";
            this.gbxDatosEmpleado.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxDatosEmpleado.Size = new System.Drawing.Size(750, 356);
            this.gbxDatosEmpleado.TabIndex = 34;
            this.gbxDatosEmpleado.TabStop = false;
            this.gbxDatosEmpleado.Text = "Datos del Empleado";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(180, 240);
            this.txtCelular.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCelular.MaxLength = 30;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCelular.Size = new System.Drawing.Size(120, 24);
            this.txtCelular.TabIndex = 31;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(180, 200);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDireccion.MaxLength = 30;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Size = new System.Drawing.Size(540, 24);
            this.txtDireccion.TabIndex = 30;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblDireccion.Location = new System.Drawing.Point(24, 200);
            this.lblDireccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblDireccion.Size = new System.Drawing.Size(140, 22);
            this.lblDireccion.TabIndex = 29;
            this.lblDireccion.Text = "Direccion:";
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCelular.Location = new System.Drawing.Point(24, 240);
            this.lblCelular.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblCelular.Size = new System.Drawing.Size(140, 22);
            this.lblCelular.TabIndex = 28;
            this.lblCelular.Text = "Celular:";
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(400, 160);
            this.txtCargo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCargo.MaxLength = 30;
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCargo.Size = new System.Drawing.Size(320, 24);
            this.txtCargo.TabIndex = 27;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCargo.Location = new System.Drawing.Point(320, 160);
            this.lblCargo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblCargo.Size = new System.Drawing.Size(72, 22);
            this.lblCargo.TabIndex = 26;
            this.lblCargo.Text = "Cargo:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblMarca.Location = new System.Drawing.Point(340, 240);
            this.lblMarca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblMarca.Size = new System.Drawing.Size(72, 22);
            this.lblMarca.TabIndex = 25;
            this.lblMarca.Text = "Sucursal:";
            // 
            // cbxSucursal
            // 
            this.cbxSucursal.FormattingEnabled = true;
            this.cbxSucursal.Location = new System.Drawing.Point(430, 240);
            this.cbxSucursal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxSucursal.Name = "cbxSucursal";
            this.cbxSucursal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxSucursal.Size = new System.Drawing.Size(290, 24);
            this.cbxSucursal.TabIndex = 24;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(180, 40);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.MaxLength = 30;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Size = new System.Drawing.Size(540, 24);
            this.txtNombre.TabIndex = 18;
            // 
            // txtPrimerApellido
            // 
            this.txtPrimerApellido.Location = new System.Drawing.Point(180, 80);
            this.txtPrimerApellido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrimerApellido.MaxLength = 30;
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrimerApellido.Size = new System.Drawing.Size(540, 24);
            this.txtPrimerApellido.TabIndex = 17;
            // 
            // txtCi
            // 
            this.txtCi.Location = new System.Drawing.Point(180, 160);
            this.txtCi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCi.MaxLength = 30;
            this.txtCi.Name = "txtCi";
            this.txtCi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCi.Size = new System.Drawing.Size(110, 24);
            this.txtCi.TabIndex = 16;
            // 
            // txtSegundoApellido
            // 
            this.txtSegundoApellido.Location = new System.Drawing.Point(180, 120);
            this.txtSegundoApellido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSegundoApellido.MaxLength = 30;
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSegundoApellido.Size = new System.Drawing.Size(540, 24);
            this.txtSegundoApellido.TabIndex = 14;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(378, 292);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnGuardar.IconoOmnicell = CpOmnicell.Icono.Guardar;
            this.btnGuardar.Size = new System.Drawing.Size(180, 44);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(192, 292);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancelar.IconoOmnicell = CpOmnicell.Icono.Cancelar;
            this.btnCancelar.Size = new System.Drawing.Size(170, 44);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblSegundoApellido
            // 
            this.lblSegundoApellido.AutoSize = true;
            this.lblSegundoApellido.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblSegundoApellido.Location = new System.Drawing.Point(24, 120);
            this.lblSegundoApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblSegundoApellido.Size = new System.Drawing.Size(140, 22);
            this.lblSegundoApellido.TabIndex = 7;
            this.lblSegundoApellido.Text = "Segundo Apellido:";
            // 
            // lblCi
            // 
            this.lblCi.AutoSize = true;
            this.lblCi.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCi.Location = new System.Drawing.Point(24, 160);
            this.lblCi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCi.Name = "lblCi";
            this.lblCi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblCi.Size = new System.Drawing.Size(60, 22);
            this.lblCi.TabIndex = 2;
            this.lblCi.Text = "CI:";
            // 
            // lblPrimerApellido
            // 
            this.lblPrimerApellido.AutoSize = true;
            this.lblPrimerApellido.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPrimerApellido.Location = new System.Drawing.Point(24, 80);
            this.lblPrimerApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrimerApellido.Name = "lblPrimerApellido";
            this.lblPrimerApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblPrimerApellido.Size = new System.Drawing.Size(140, 22);
            this.lblPrimerApellido.TabIndex = 1;
            this.lblPrimerApellido.Text = "Primer Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(24, 40);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblNombre.Size = new System.Drawing.Size(140, 22);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // 
            // cabeceraOmnicell
            // 
            this.cabeceraOmnicell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cabeceraOmnicell.IconoOmnicell = CpOmnicell.Icono.Empleado;
            this.cabeceraOmnicell.Location = new System.Drawing.Point(0, 0);
            this.cabeceraOmnicell.Name = "cabeceraOmnicell";
            this.cabeceraOmnicell.Size = new System.Drawing.Size(793, 76);
            this.cabeceraOmnicell.Subtitulo = "Datos personales, cargo y sucursal";
            this.cabeceraOmnicell.TabIndex = 0;
            this.cabeceraOmnicell.Titulo = "Empleado";
            // FrmEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(760, 478);
            this.Controls.Add(this.gbxDatosEmpleado);
            this.Controls.Add(this.cabeceraOmnicell);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FrmEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: Omnicell - Empleados :::";
            this.Load += new System.EventHandler(this.FrmEmpleados_Load);
            this.gbxDatosEmpleado.ResumeLayout(false);
            this.gbxDatosEmpleado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CpOmnicell.CabeceraOmnicell cabeceraOmnicell;

        private CpOmnicell.GroupBoxOmnicell gbxDatosEmpleado;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cbxSucursal;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPrimerApellido;
        private System.Windows.Forms.TextBox txtCi;
        private System.Windows.Forms.TextBox txtSegundoApellido;
        private CpOmnicell.BotonOmnicell btnGuardar;
        private CpOmnicell.BotonOmnicell btnCancelar;
        private System.Windows.Forms.Label lblSegundoApellido;
        private System.Windows.Forms.Label lblCi;
        private System.Windows.Forms.Label lblPrimerApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.TextBox txtDireccion;
    }
}