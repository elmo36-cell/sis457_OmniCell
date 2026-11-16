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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmpleados));
            this.lblTituloEmpleado = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbxDatosEmpleado = new System.Windows.Forms.GroupBox();
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblSegundoApellido = new System.Windows.Forms.Label();
            this.lblCi = new System.Windows.Forms.Label();
            this.lblPrimerApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gbxDatosEmpleado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloEmpleado
            // 
            this.lblTituloEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloEmpleado.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("lblTituloEmpleado.Image")));
            this.lblTituloEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTituloEmpleado.Location = new System.Drawing.Point(148, 17);
            this.lblTituloEmpleado.Name = "lblTituloEmpleado";
            this.lblTituloEmpleado.Size = new System.Drawing.Size(291, 36);
            this.lblTituloEmpleado.TabIndex = 36;
            this.lblTituloEmpleado.Text = "Nuevo Empleado";
            this.lblTituloEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(8, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(81, 22);
            this.lblTitulo.TabIndex = 35;
            this.lblTitulo.Text = "Omnicell";
            // 
            // gbxDatosEmpleado
            // 
            this.gbxDatosEmpleado.BackColor = System.Drawing.Color.LightSteelBlue;
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
            this.gbxDatosEmpleado.Location = new System.Drawing.Point(12, 56);
            this.gbxDatosEmpleado.Name = "gbxDatosEmpleado";
            this.gbxDatosEmpleado.Size = new System.Drawing.Size(571, 383);
            this.gbxDatosEmpleado.TabIndex = 34;
            this.gbxDatosEmpleado.TabStop = false;
            this.gbxDatosEmpleado.Text = "Datos del Empleado";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(388, 237);
            this.txtCelular.MaxLength = 30;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(116, 20);
            this.txtCelular.TabIndex = 31;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(140, 202);
            this.txtDireccion.MaxLength = 30;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(364, 20);
            this.txtDireccion.TabIndex = 30;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(50, 200);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(89, 20);
            this.lblDireccion.TabIndex = 29;
            this.lblDireccion.Text = "Direccion:";
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCelular.Location = new System.Drawing.Point(319, 238);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(70, 20);
            this.lblCelular.TabIndex = 28;
            this.lblCelular.Text = "Celular:";
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(324, 162);
            this.txtCargo.MaxLength = 30;
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(180, 20);
            this.txtCargo.TabIndex = 27;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.Location = new System.Drawing.Point(255, 160);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(62, 20);
            this.lblCargo.TabIndex = 26;
            this.lblCargo.Text = "Cargo:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(50, 236);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(84, 20);
            this.lblMarca.TabIndex = 25;
            this.lblMarca.Text = "Sucursal:";
            // 
            // cbxSucursal
            // 
            this.cbxSucursal.FormattingEnabled = true;
            this.cbxSucursal.Location = new System.Drawing.Point(140, 236);
            this.cbxSucursal.Name = "cbxSucursal";
            this.cbxSucursal.Size = new System.Drawing.Size(177, 21);
            this.cbxSucursal.TabIndex = 24;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(140, 55);
            this.txtNombre.MaxLength = 30;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(364, 20);
            this.txtNombre.TabIndex = 18;
            // 
            // txtPrimerApellido
            // 
            this.txtPrimerApellido.Location = new System.Drawing.Point(186, 91);
            this.txtPrimerApellido.MaxLength = 30;
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Size = new System.Drawing.Size(318, 20);
            this.txtPrimerApellido.TabIndex = 17;
            // 
            // txtCi
            // 
            this.txtCi.Location = new System.Drawing.Point(88, 162);
            this.txtCi.MaxLength = 30;
            this.txtCi.Name = "txtCi";
            this.txtCi.Size = new System.Drawing.Size(164, 20);
            this.txtCi.TabIndex = 16;
            // 
            // txtSegundoApellido
            // 
            this.txtSegundoApellido.Location = new System.Drawing.Point(210, 124);
            this.txtSegundoApellido.MaxLength = 30;
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(294, 20);
            this.txtSegundoApellido.TabIndex = 14;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(279, 325);
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
            this.btnCancelar.Location = new System.Drawing.Point(155, 325);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(118, 42);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // lblSegundoApellido
            // 
            this.lblSegundoApellido.AutoSize = true;
            this.lblSegundoApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSegundoApellido.Location = new System.Drawing.Point(50, 123);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.Size = new System.Drawing.Size(155, 20);
            this.lblSegundoApellido.TabIndex = 7;
            this.lblSegundoApellido.Text = "Segundo Apellido:";
            // 
            // lblCi
            // 
            this.lblCi.AutoSize = true;
            this.lblCi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCi.Location = new System.Drawing.Point(50, 160);
            this.lblCi.Name = "lblCi";
            this.lblCi.Size = new System.Drawing.Size(32, 20);
            this.lblCi.TabIndex = 2;
            this.lblCi.Text = "CI:";
            // 
            // lblPrimerApellido
            // 
            this.lblPrimerApellido.AutoSize = true;
            this.lblPrimerApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrimerApellido.Location = new System.Drawing.Point(50, 90);
            this.lblPrimerApellido.Name = "lblPrimerApellido";
            this.lblPrimerApellido.Size = new System.Drawing.Size(134, 20);
            this.lblPrimerApellido.TabIndex = 1;
            this.lblPrimerApellido.Text = "Primer Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(49, 55);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(76, 20);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // FrmEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(595, 450);
            this.Controls.Add(this.lblTituloEmpleado);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gbxDatosEmpleado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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

        private System.Windows.Forms.Label lblTituloEmpleado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbxDatosEmpleado;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cbxSucursal;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPrimerApellido;
        private System.Windows.Forms.TextBox txtCi;
        private System.Windows.Forms.TextBox txtSegundoApellido;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
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