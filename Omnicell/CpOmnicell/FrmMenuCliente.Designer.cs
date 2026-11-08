namespace CpOmnicell
{
    partial class FrmMenuCliente
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuCliente));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new C1.Win.C1Input.C1Button();
            this.c1TextBox1 = new C1.Win.C1Input.C1TextBox();
            this.btnCarrito = new C1.Win.C1Input.C1Button();
            this.btnSalir = new C1.Win.C1Input.C1Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.gbxEncabezado = new System.Windows.Forms.GroupBox();
            this.gbxBuscador = new System.Windows.Forms.GroupBox();
            this.gbxMenu = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            this.gbxEncabezado.SuspendLayout();
            this.gbxBuscador.SuspendLayout();
            this.gbxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.RoyalBlue;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBuscar.Location = new System.Drawing.Point(687, 16);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(115, 21);
            this.btnBuscar.TabIndex = 21;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // c1TextBox1
            // 
            this.c1TextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c1TextBox1.Location = new System.Drawing.Point(3, 16);
            this.c1TextBox1.Name = "c1TextBox1";
            this.c1TextBox1.NullText = "Buscar por Marca, Modelo o Compatibillidad ...";
            this.c1TextBox1.Size = new System.Drawing.Size(668, 18);
            this.c1TextBox1.TabIndex = 22;
            this.c1TextBox1.Tag = "Buscar por Marca, Modelo o Compatibillidad ...";
            // 
            // btnCarrito
            // 
            this.btnCarrito.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCarrito.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCarrito.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCarrito.Location = new System.Drawing.Point(3, 16);
            this.btnCarrito.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnCarrito.Name = "btnCarrito";
            this.btnCarrito.Size = new System.Drawing.Size(166, 23);
            this.btnCarrito.TabIndex = 24;
            this.btnCarrito.Text = "Carrito";
            this.btnCarrito.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSalir.Location = new System.Drawing.Point(3, 319);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(166, 23);
            this.btnSalir.TabIndex = 25;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(64, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(121, 31);
            this.lblTitulo.TabIndex = 26;
            this.lblTitulo.Text = "Omnicell";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(715, 16);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(87, 25);
            this.lblUsuario.TabIndex = 27;
            this.lblUsuario.Text = "Invitado";
            // 
            // gbxEncabezado
            // 
            this.gbxEncabezado.Controls.Add(this.lblUsuario);
            this.gbxEncabezado.Controls.Add(this.lblTitulo);
            this.gbxEncabezado.Controls.Add(this.pictureBox1);
            this.gbxEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxEncabezado.Location = new System.Drawing.Point(0, 0);
            this.gbxEncabezado.Name = "gbxEncabezado";
            this.gbxEncabezado.Padding = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.gbxEncabezado.Size = new System.Drawing.Size(805, 61);
            this.gbxEncabezado.TabIndex = 28;
            this.gbxEncabezado.TabStop = false;
            // 
            // gbxBuscador
            // 
            this.gbxBuscador.BackColor = System.Drawing.Color.Transparent;
            this.gbxBuscador.Controls.Add(this.c1TextBox1);
            this.gbxBuscador.Controls.Add(this.btnBuscar);
            this.gbxBuscador.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxBuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxBuscador.Location = new System.Drawing.Point(0, 61);
            this.gbxBuscador.Name = "gbxBuscador";
            this.gbxBuscador.Padding = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.gbxBuscador.Size = new System.Drawing.Size(805, 47);
            this.gbxBuscador.TabIndex = 29;
            this.gbxBuscador.TabStop = false;
            // 
            // gbxMenu
            // 
            this.gbxMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxMenu.Controls.Add(this.btnCarrito);
            this.gbxMenu.Controls.Add(this.btnSalir);
            this.gbxMenu.Location = new System.Drawing.Point(0, 101);
            this.gbxMenu.Name = "gbxMenu";
            this.gbxMenu.Size = new System.Drawing.Size(172, 345);
            this.gbxMenu.TabIndex = 30;
            this.gbxMenu.TabStop = false;
            // 
            // FrmMenuCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(805, 450);
            this.Controls.Add(this.gbxBuscador);
            this.Controls.Add(this.gbxEncabezado);
            this.Controls.Add(this.gbxMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMenuCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "::: Omnicell ::: - Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            this.gbxEncabezado.ResumeLayout(false);
            this.gbxEncabezado.PerformLayout();
            this.gbxBuscador.ResumeLayout(false);
            this.gbxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private C1.Win.C1Input.C1Button btnBuscar;
        private C1.Win.C1Input.C1TextBox c1TextBox1;
        private C1.Win.C1Input.C1Button btnCarrito;
        private C1.Win.C1Input.C1Button btnSalir;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.GroupBox gbxEncabezado;
        private System.Windows.Forms.GroupBox gbxBuscador;
        private System.Windows.Forms.GroupBox gbxMenu;
    }
}

