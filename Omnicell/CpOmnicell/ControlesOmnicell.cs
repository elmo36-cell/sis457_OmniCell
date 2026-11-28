using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CpOmnicell
{
    // Base de todas las ventanas: pinta el fondo tecnológico también en el
    // diseñador, así lo que se ve al diseñar es lo que sale al ejecutar.
    public class FormOmnicell : Form
    {
        public FormOmnicell()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.ResizeRedraw, true);

            DoubleBuffered = true;
            BackColor = Estilos.Fondo;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Estilos.DibujarFondo(e.Graphics, ClientRectangle);
        }

        // Repinta el fondo de la ventana dentro de un control hijo (lo usan
        // los botones que cuelgan directo del formulario).
        internal void PintarFondoEn(Graphics g, Rectangle destino)
        {
            GraphicsState estado = g.Save();
            g.TranslateTransform(-destino.X, -destino.Y);
            Estilos.DibujarFondo(g, ClientRectangle);
            g.Restore(estado);
        }
    }

    [ToolboxItem(true)]
    public class BotonOmnicell : Button
    {
        private Icono iconoOmnicell = Icono.Detalles;
        private bool textoDerechaOmnicell;
        private bool pestanaOmnicell;
        private bool activoOmnicell = true;
        private bool hover;
        private bool pulsado;

        public BotonOmnicell()
        {
            SetStyle(ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            AutoSize = false;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            UseVisualStyleBackColor = false;
            ForeColor = Color.White;
            BackColor = Estilos.Primario;
            Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
            Cursor = Cursors.Hand;
        }

        // El color del botón es su BackColor, el mismo que se ve en el
        // diseñador. Se conserva la propiedad como alias por compatibilidad.
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ColorOmnicell
        {
            get { return BackColor; }
            set { BackColor = value; Invalidate(); }
        }

        [Category("OmniCell")]
        [DefaultValue(Icono.Detalles)]
        public Icono IconoOmnicell
        {
            get { return iconoOmnicell; }
            set { iconoOmnicell = value; Invalidate(); }
        }

        [Category("OmniCell")]
        [DefaultValue(false)]
        public bool TextoDerechaOmnicell
        {
            get { return textoDerechaOmnicell; }
            set { textoDerechaOmnicell = value; Invalidate(); }
        }

        // Marca el botón como pestaña de la cinta: se pinta con su color de
        // sección y resalta cuando está activo.
        [Category("OmniCell")]
        [DefaultValue(false)]
        public bool PestanaOmnicell
        {
            get { return pestanaOmnicell; }
            set { pestanaOmnicell = value; Invalidate(); }
        }

        // Solo aplica a las pestañas: la sección que está abierta.
        [Category("OmniCell")]
        [DefaultValue(true)]
        public bool ActivoOmnicell
        {
            get { return activoOmnicell; }
            set { activoOmnicell = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Color color = BackColor.A < 255 || BackColor == Color.White
                ? Estilos.Primario : BackColor;

            if (pestanaOmnicell)
                Estilos.PintarPestana(pevent.Graphics, this, color, iconoOmnicell,
                    hover, pulsado, activoOmnicell);
            else
                Estilos.PintarBoton(pevent.Graphics, this, color, iconoOmnicell,
                    hover, pulsado, textoDerechaOmnicell);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            hover = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            hover = false;
            pulsado = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            pulsado = true;
            Invalidate();
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            pulsado = false;
            Invalidate();
            base.OnMouseUp(mevent);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            Invalidate();
            base.OnEnabledChanged(e);
        }
    }

    [ToolboxItem(true)]
    public class GroupBoxOmnicell : GroupBox
    {
        private bool sutil;

        public GroupBoxOmnicell()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            DoubleBuffered = true;
            AplicarEstilo();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Estilos.DibujarTarjeta(e.Graphics, ClientRectangle, sutil);
        }

        // Las etiquetas van sin fondo propio para que se vea la superficie
        // tecnologica de la tarjeta y no queden recuadros blancos.
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            if (e.Control is Label || e.Control is CheckBox || e.Control is RadioButton)
                e.Control.BackColor = Color.Transparent;

            foreach (Control hijo in e.Control.Controls)
                PrepararHijos(hijo);
        }

        private static void PrepararHijos(Control control)
        {
            if (control is Label || control is CheckBox || control is RadioButton)
                control.BackColor = Color.Transparent;

            foreach (Control hijo in control.Controls)
                PrepararHijos(hijo);
        }

        // Repinta la superficie de la tarjeta dentro de un hijo (lo usan los
        // botones, para que sus esquinas redondeadas no queden en blanco).
        internal void PintarFondoEn(Graphics g, Rectangle destino)
        {
            GraphicsState estado = g.Save();
            g.TranslateTransform(-destino.X, -destino.Y);
            Estilos.DibujarTarjeta(g, ClientRectangle, sutil);
            g.Restore(estado);
        }

        [Category("OmniCell")]
        [DefaultValue(false)]
        public bool Sutil
        {
            get { return sutil; }
            set { sutil = value; AplicarEstilo(); Invalidate(); }
        }

        private void AplicarEstilo()
        {
            if (sutil)
            {
                BackColor = Color.FromArgb(247, 249, 252);
                ForeColor = Estilos.TextoSuave;
                Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                Padding = new Padding(4, 2, 4, 4);
            }
            else
            {
                BackColor = Color.White;
                ForeColor = Estilos.Primario;
                Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                Padding = new Padding(6, 4, 6, 6);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!sutil)
            {
                // Franja inferior con el degradado de la marca.
                using (LinearGradientBrush acento = new LinearGradientBrush(
                    new Rectangle(0, Height - 3, Math.Max(1, Width), 3),
                    Estilos.Primario, Estilos.Cian, LinearGradientMode.Horizontal))
                    e.Graphics.FillRectangle(acento, 0, Height - 3, Width, 3);

                using (Pen borde = new Pen(Estilos.Borde))
                    e.Graphics.DrawRectangle(borde, 0, 0, Width - 1, Height - 1);
            }
        }
    }

    // Panel con la misma superficie tecnológica de las tarjetas: se usa para
    // los bloques que no son GroupBox (tarjeta de acceso, cinta de acciones).
    [ToolboxItem(true)]
    public class TarjetaOmnicell : Panel
    {
        public TarjetaOmnicell()
        {
            SetStyle(ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            DoubleBuffered = true;
            BackColor = Estilos.Fondo;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Estilos.DibujarTarjeta(e.Graphics, ClientRectangle, false);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            if (e.Control is Label || e.Control is CheckBox || e.Control is RadioButton)
                e.Control.BackColor = Color.Transparent;

            foreach (Control hijo in e.Control.Controls)
                PrepararHijos(hijo);
        }

        private static void PrepararHijos(Control control)
        {
            if (control is Label || control is CheckBox || control is RadioButton)
                control.BackColor = Color.Transparent;

            foreach (Control hijo in control.Controls)
                PrepararHijos(hijo);
        }

        internal void PintarFondoEn(Graphics g, Rectangle destino)
        {
            GraphicsState estado = g.Save();
            g.TranslateTransform(-destino.X, -destino.Y);
            Estilos.DibujarTarjeta(g, ClientRectangle, false);
            g.Restore(estado);
        }
    }

    [ToolboxItem(true)]
    public class GrillaOmnicell : DataGridView
    {
        public GrillaOmnicell()
        {
            Estilos.AplicarGrid(this);
        }
    }

    [ToolboxItem(true)]
    public class HeroOmnicell : Panel
    {
        public HeroOmnicell()
        {
            SetStyle(ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            DoubleBuffered = true;
            BackColor = Estilos.Fondo;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Estilos.DibujarHero(e.Graphics, ClientRectangle);
        }
    }

    [ToolboxItem(true)]
    public class TarjetaAccesoOmnicell : Panel
    {
        private static readonly Font fuenteTitulo = new Font("Segoe UI", 11.5F, FontStyle.Bold);
        private static readonly Font fuenteDetalle = new Font("Segoe UI", 8.75F, FontStyle.Regular);

        private Color colorOmnicell = Estilos.Primario;
        private Icono iconoOmnicell = Icono.Venta;
        private string titulo = "Acceso rápido";
        private string detalle = "Descripción de la acción.";
        private bool hover;

        public TarjetaAccesoOmnicell()
        {
            SetStyle(ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            DoubleBuffered = true;
            BackColor = Estilos.Fondo;
            Cursor = Cursors.Hand;
        }

        [Category("OmniCell")]
        [DefaultValue(typeof(Color), "31, 78, 156")]
        public Color ColorOmnicell
        {
            get { return colorOmnicell; }
            set { colorOmnicell = value; Invalidate(); }
        }

        [Category("OmniCell")]
        [DefaultValue(Icono.Venta)]
        public Icono IconoOmnicell
        {
            get { return iconoOmnicell; }
            set { iconoOmnicell = value; Invalidate(); }
        }

        [Category("OmniCell")]
        [DefaultValue("Acceso rápido")]
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; Invalidate(); }
        }

        [Category("OmniCell")]
        [DefaultValue("Descripción de la acción.")]
        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.Clear(BackColor);

            Rectangle r = new Rectangle(0, hover ? 2 : 4, Width - 1, Height - 5);
            if (r.Width < 20 || r.Height < 20) return;

            using (GraphicsPath ruta = Estilos.RutaRedondeada(r, 12))
            {
                Region anterior = g.Clip;
                g.SetClip(ruta);
                Estilos.DibujarTarjeta(g, r, false);
                g.Clip = anterior;

                using (Pen borde = new Pen(hover ? colorOmnicell : Estilos.Borde, hover ? 2F : 1.2F))
                    g.DrawPath(borde, ruta);
            }

            using (SolidBrush circulo = new SolidBrush(colorOmnicell))
                g.FillEllipse(circulo, r.Left + 18, r.Top + 16, 44, 44);

            g.DrawImage(Estilos.CrearIcono(iconoOmnicell, 22), r.Left + 29, r.Top + 27, 22, 22);

            TextRenderer.DrawText(g, titulo, fuenteTitulo,
                new Rectangle(r.Left + 18, r.Top + 70, r.Width - 36, 24),
                Estilos.TextoFuerte,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            TextRenderer.DrawText(g, detalle, fuenteDetalle,
                new Rectangle(r.Left + 18, r.Top + 96, r.Width - 36, 42),
                Estilos.TextoSuave,
                TextFormatFlags.Left | TextFormatFlags.WordBreak);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            hover = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            hover = false;
            Invalidate();
            base.OnMouseLeave(e);
        }
    }

    [ToolboxItem(true)]
    public class LogoOmnicell : Control
    {
        public LogoOmnicell()
        {
            SetStyle(ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            Size = new Size(44, 44);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Parent != null ? Parent.BackColor : Estilos.Marino);

            Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
            if (r.Width < 8 || r.Height < 8) return;

            using (GraphicsPath ruta = Estilos.RutaRedondeada(r, 13))
            {
                using (LinearGradientBrush degradado = new LinearGradientBrush(
                    r, Color.FromArgb(86, 158, 255), Estilos.Primario, LinearGradientMode.ForwardDiagonal))
                    g.FillPath(degradado, ruta);

                using (Pen borde = new Pen(Color.FromArgb(130, 255, 255, 255)))
                    g.DrawPath(borde, ruta);
            }

            int lado = (int)(Math.Min(Width, Height) * 0.56F);
            g.DrawImage(Estilos.CrearIcono(Icono.Pantalla, lado),
                (Width - lado) / 2, (Height - lado) / 2, lado, lado);
        }
    }

    // Cabecera de módulo de las ventanas de trabajo: mismo lenguaje visual
    // que la barra del menú (marca, título y acento).
    [ToolboxItem(true)]
    public class CabeceraOmnicell : Control
    {
        private static readonly Font fuenteTitulo = new Font("Segoe UI", 14.75F, FontStyle.Bold);
        private static readonly Font fuenteSubtitulo = new Font("Segoe UI", 8.75F, FontStyle.Regular);
        private static readonly Font fuenteMarca = new Font("Segoe UI", 8.25F, FontStyle.Bold);

        private string titulo = "Módulo";
        private string subtitulo = "";
        private Icono iconoOmnicell = Icono.Detalles;

        public CabeceraOmnicell()
        {
            SetStyle(ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            Size = new Size(600, 76);
            BackColor = Estilos.Marino;
        }

        [Category("OmniCell")]
        [DefaultValue("Módulo")]
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; Invalidate(); }
        }

        [Category("OmniCell")]
        [DefaultValue("")]
        public string Subtitulo
        {
            get { return subtitulo; }
            set { subtitulo = value; Invalidate(); }
        }

        [Category("OmniCell")]
        [DefaultValue(Icono.Detalles)]
        public Icono IconoOmnicell
        {
            get { return iconoOmnicell; }
            set { iconoOmnicell = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Estilos.DibujarMarca(g, ClientRectangle);

            Rectangle placa = new Rectangle(18, 18, 40, 40);

            using (GraphicsPath ruta = Estilos.RutaRedondeada(placa, 12))
            {
                using (LinearGradientBrush degradado = new LinearGradientBrush(
                    placa, Color.FromArgb(86, 158, 255), Estilos.Primario, LinearGradientMode.ForwardDiagonal))
                    g.FillPath(degradado, ruta);

                using (Pen borde = new Pen(Color.FromArgb(130, 255, 255, 255)))
                    g.DrawPath(borde, ruta);
            }

            g.DrawImage(Estilos.CrearIcono(iconoOmnicell, 22), placa.X + 9, placa.Y + 9, 22, 22);

            TextRenderer.DrawText(g, titulo, fuenteTitulo,
                new Rectangle(70, 13, Math.Max(0, Width - 210), 30),
                Color.White,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            if (!string.IsNullOrEmpty(subtitulo))
            {
                TextRenderer.DrawText(g, subtitulo, fuenteSubtitulo,
                    new Rectangle(72, 44, Math.Max(0, Width - 220), 18),
                    Color.FromArgb(186, 206, 232),
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }

            TextRenderer.DrawText(g, "OMNICELL", fuenteMarca,
                new Rectangle(Math.Max(0, Width - 150), 22, 130, 16),
                Color.FromArgb(126, 164, 216),
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter);

            using (SolidBrush acento = new SolidBrush(Estilos.Acento))
                g.FillRectangle(acento, 0, Height - 3, Width, 3);
        }
    }

    [ToolboxItem(true)]
    public class PanelMarcaOmnicell : Panel
    {
        public PanelMarcaOmnicell()
        {
            SetStyle(ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            BackColor = Estilos.Marino;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Estilos.DibujarMarca(e.Graphics, ClientRectangle);
        }
    }
}
