namespace CpOmnicell
{
    partial class FrmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.panelMarca = new CpOmnicell.PanelMarcaOmnicell();
            this.logoOmnicell = new CpOmnicell.LogoOmnicell();
            this.lblTilOmnicell = new System.Windows.Forms.Label();
            this.lblMarcaSub = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMarcaPie = new System.Windows.Forms.Label();
            this.panelMarcoForm = new System.Windows.Forms.Panel();
            this.panelForm = new CpOmnicell.TarjetaOmnicell();
            this.lblInicioSesion = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuarios = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnInicioSesion = new CpOmnicell.BotonOmnicell();
            this.btnSalir = new CpOmnicell.BotonOmnicell();
            this.erpUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpClave = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelMarca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMarcoForm.SuspendLayout();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpClave)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMarca
            // 
            this.panelMarca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMarca.Controls.Add(this.logoOmnicell);
            this.panelMarca.Controls.Add(this.lblTilOmnicell);
            this.panelMarca.Controls.Add(this.lblMarcaSub);
            this.panelMarca.Controls.Add(this.pictureBox1);
            this.panelMarca.Controls.Add(this.lblMarcaPie);
            this.panelMarca.Location = new System.Drawing.Point(0, 0);
            this.panelMarca.Name = "panelMarca";
            this.panelMarca.Size = new System.Drawing.Size(372, 520);
            this.panelMarca.TabIndex = 0;
            // 
            // logoOmnicell
            // 
            this.logoOmnicell.Location = new System.Drawing.Point(44, 54);
            this.logoOmnicell.Name = "logoOmnicell";
            this.logoOmnicell.Size = new System.Drawing.Size(58, 58);
            this.logoOmnicell.TabIndex = 0;
            // 
            // lblTilOmnicell
            // 
            this.lblTilOmnicell.AutoSize = true;
            this.lblTilOmnicell.BackColor = System.Drawing.Color.Transparent;
            this.lblTilOmnicell.Font = new System.Drawing.Font("Segoe UI", 25.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTilOmnicell.ForeColor = System.Drawing.Color.White;
            this.lblTilOmnicell.Location = new System.Drawing.Point(42, 128);
            this.lblTilOmnicell.Name = "lblTilOmnicell";
            this.lblTilOmnicell.Size = new System.Drawing.Size(175, 46);
            this.lblTilOmnicell.TabIndex = 1;
            this.lblTilOmnicell.Text = "OmniCell";
            // 
            // lblMarcaSub
            // 
            this.lblMarcaSub.AutoSize = true;
            this.lblMarcaSub.BackColor = System.Drawing.Color.Transparent;
            this.lblMarcaSub.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarcaSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(199)))), ((int)(((byte)(231)))));
            this.lblMarcaSub.Location = new System.Drawing.Point(46, 186);
            this.lblMarcaSub.Name = "lblMarcaSub";
            this.lblMarcaSub.Size = new System.Drawing.Size(203, 38);
            this.lblMarcaSub.TabIndex = 2;
            this.lblMarcaSub.Text = "Sistema de inventario,\r\nventas y pantallas";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(44, 248);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblMarcaPie
            // 
            this.lblMarcaPie.AutoSize = true;
            this.lblMarcaPie.BackColor = System.Drawing.Color.Transparent;
            this.lblMarcaPie.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarcaPie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))));
            this.lblMarcaPie.Location = new System.Drawing.Point(46, 470);
            this.lblMarcaPie.Name = "lblMarcaPie";
            this.lblMarcaPie.Size = new System.Drawing.Size(219, 13);
            this.lblMarcaPie.TabIndex = 4;
            this.lblMarcaPie.Text = "© 2026 OmniCell · Tecnología y servicio";
            // 
            // panelMarcoForm
            // 
            this.panelMarcoForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.panelMarcoForm.Controls.Add(this.panelForm);
            this.panelMarcoForm.Location = new System.Drawing.Point(416, 64);
            this.panelMarcoForm.Name = "panelMarcoForm";
            this.panelMarcoForm.Padding = new System.Windows.Forms.Padding(1);
            this.panelMarcoForm.Size = new System.Drawing.Size(424, 392);
            this.panelMarcoForm.TabIndex = 1;
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Controls.Add(this.lblInicioSesion);
            this.panelForm.Controls.Add(this.lblBienvenida);
            this.panelForm.Controls.Add(this.lblUsuario);
            this.panelForm.Controls.Add(this.txtUsuarios);
            this.panelForm.Controls.Add(this.lblContraseña);
            this.panelForm.Controls.Add(this.txtClave);
            this.panelForm.Controls.Add(this.btnInicioSesion);
            this.panelForm.Controls.Add(this.btnSalir);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(1, 1);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(422, 390);
            this.panelForm.TabIndex = 0;
            // 
            // lblInicioSesion
            // 
            this.lblInicioSesion.AutoSize = true;
            this.lblInicioSesion.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicioSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.lblInicioSesion.Location = new System.Drawing.Point(32, 26);
            this.lblInicioSesion.Name = "lblInicioSesion";
            this.lblInicioSesion.Size = new System.Drawing.Size(154, 30);
            this.lblInicioSesion.TabIndex = 0;
            this.lblInicioSesion.Text = "Iniciar sesión";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblBienvenida.Location = new System.Drawing.Point(34, 64);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(244, 15);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "Ingresa tus credenciales para continuar.";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblUsuario.Location = new System.Drawing.Point(32, 106);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(55, 15);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuarios
            // 
            this.txtUsuarios.BackColor = System.Drawing.Color.White;
            this.txtUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuarios.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.txtUsuarios.Location = new System.Drawing.Point(32, 128);
            this.txtUsuarios.Name = "txtUsuarios";
            this.txtUsuarios.Size = new System.Drawing.Size(358, 26);
            this.txtUsuarios.TabIndex = 3;
            this.txtUsuarios.TextChanged += new System.EventHandler(this.txtUsuarios_TextChanged);
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblContraseña.Location = new System.Drawing.Point(32, 172);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(73, 15);
            this.lblContraseña.TabIndex = 4;
            this.lblContraseña.Text = "Contraseña";
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.White;
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.txtClave.Location = new System.Drawing.Point(32, 194);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(358, 26);
            this.txtClave.TabIndex = 5;
            this.txtClave.TextChanged += new System.EventHandler(this.txtClave_TextChanged);
            // 
            // btnInicioSesion
            // 
            this.btnInicioSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(156)))));
            this.btnInicioSesion.IconoOmnicell = CpOmnicell.Icono.Ingresar;
            this.btnInicioSesion.Location = new System.Drawing.Point(32, 246);
            this.btnInicioSesion.Name = "btnInicioSesion";
            this.btnInicioSesion.Size = new System.Drawing.Size(358, 46);
            this.btnInicioSesion.TabIndex = 6;
            this.btnInicioSesion.Text = "Iniciar sesión";
            this.btnInicioSesion.Click += new System.EventHandler(this.btnInicioSesion_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSalir.IconoOmnicell = CpOmnicell.Icono.Salir;
            this.btnSalir.Location = new System.Drawing.Point(32, 302);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(358, 40);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // erpUsuario
            // 
            this.erpUsuario.ContainerControl = this;
            // 
            // erpClave
            // 
            this.erpClave.ContainerControl = this;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(880, 520);
            this.Controls.Add(this.panelMarcoForm);
            this.Controls.Add(this.panelMarca);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Omnicell ::: Inicio De Sesion";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.panelMarca.ResumeLayout(false);
            this.panelMarca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMarcoForm.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpClave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CpOmnicell.PanelMarcaOmnicell panelMarca;
        private CpOmnicell.LogoOmnicell logoOmnicell;
        private System.Windows.Forms.Label lblTilOmnicell;
        private System.Windows.Forms.Label lblMarcaSub;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMarcaPie;
        private System.Windows.Forms.Panel panelMarcoForm;
        private CpOmnicell.TarjetaOmnicell panelForm;
        private System.Windows.Forms.Label lblInicioSesion;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuarios;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox txtClave;
        private CpOmnicell.BotonOmnicell btnInicioSesion;
        private CpOmnicell.BotonOmnicell btnSalir;
        private System.Windows.Forms.ErrorProvider erpUsuario;
        private System.Windows.Forms.ErrorProvider erpClave;
    }
}
