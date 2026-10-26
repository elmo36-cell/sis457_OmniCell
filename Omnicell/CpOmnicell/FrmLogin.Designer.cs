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
            this.tbFondo = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblInicioSesion = new System.Windows.Forms.Label();
            this.txtUsuarios = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnInicioSesion = new System.Windows.Forms.Button();
            this.lblTilOmnicell = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbFondo)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFondo
            // 
            this.tbFondo.BackColor = System.Drawing.Color.RoyalBlue;
            this.tbFondo.Location = new System.Drawing.Point(-7, -8);
            this.tbFondo.Name = "tbFondo";
            this.tbFondo.Size = new System.Drawing.Size(425, 509);
            this.tbFondo.TabIndex = 0;
            this.tbFondo.TabStop = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(485, 198);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 10;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(485, 258);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(61, 13);
            this.lblContraseña.TabIndex = 11;
            this.lblContraseña.Text = "Contraseña";
            // 
            // lblInicioSesion
            // 
            this.lblInicioSesion.AutoSize = true;
            this.lblInicioSesion.BackColor = System.Drawing.Color.Transparent;
            this.lblInicioSesion.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicioSesion.Location = new System.Drawing.Point(517, 123);
            this.lblInicioSesion.Name = "lblInicioSesion";
            this.lblInicioSesion.Size = new System.Drawing.Size(203, 31);
            this.lblInicioSesion.TabIndex = 12;
            this.lblInicioSesion.Text = "Inicio de Sesion";
            this.lblInicioSesion.Click += new System.EventHandler(this.lblInicioSesion_Click);
            // 
            // txtUsuarios
            // 
            this.txtUsuarios.BackColor = System.Drawing.Color.SteelBlue;
            this.txtUsuarios.ForeColor = System.Drawing.Color.White;
            this.txtUsuarios.Location = new System.Drawing.Point(488, 214);
            this.txtUsuarios.Name = "txtUsuarios";
            this.txtUsuarios.Size = new System.Drawing.Size(258, 20);
            this.txtUsuarios.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(488, 274);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 20);
            this.textBox1.TabIndex = 14;
            // 
            // btnInicioSesion
            // 
            this.btnInicioSesion.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnInicioSesion.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnInicioSesion.FlatAppearance.BorderSize = 10;
            this.btnInicioSesion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInicioSesion.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicioSesion.Location = new System.Drawing.Point(537, 334);
            this.btnInicioSesion.Name = "btnInicioSesion";
            this.btnInicioSesion.Size = new System.Drawing.Size(153, 37);
            this.btnInicioSesion.TabIndex = 15;
            this.btnInicioSesion.Text = "Iniciar Sesion";
            this.btnInicioSesion.UseVisualStyleBackColor = false;
            // 
            // lblTilOmnicell
            // 
            this.lblTilOmnicell.AutoSize = true;
            this.lblTilOmnicell.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblTilOmnicell.Font = new System.Drawing.Font("Microsoft YaHei", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTilOmnicell.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTilOmnicell.Location = new System.Drawing.Point(54, 93);
            this.lblTilOmnicell.Name = "lblTilOmnicell";
            this.lblTilOmnicell.Size = new System.Drawing.Size(320, 86);
            this.lblTilOmnicell.TabIndex = 16;
            this.lblTilOmnicell.Text = "Omnicell";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTilOmnicell);
            this.Controls.Add(this.btnInicioSesion);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtUsuarios);
            this.Controls.Add(this.lblInicioSesion);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.tbFondo);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Omnicell ::: Inicio De Sesion";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbFondo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox tbFondo;
        private Krypton.Toolkit.KryptonLabel lblOmnicell;
        private Krypton.Toolkit.KryptonTextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblInicioSesion;
        private System.Windows.Forms.TextBox txtUsuarios;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnInicioSesion;
        private System.Windows.Forms.Label lblTilOmnicell;
    }
}