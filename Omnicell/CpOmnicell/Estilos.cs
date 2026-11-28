using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace CpOmnicell
{
    public enum Icono
    {
        Buscar,
        Detalles,
        Inicio,
        Editar,
        Eliminar,
        Guardar,
        Cancelar,
        Ingresar,
        Agregar,
        Venta,
        Compra,
        Historial,
        Pantalla,
        Cliente,
        Proveedor,
        Usuarios,
        Empleado,
        Salir
    }

    internal static class Estilos
    {
        internal static readonly Color Primario = Color.FromArgb(31, 78, 156);   // #1F4E9C
        internal static readonly Color Exito = Color.FromArgb(46, 125, 50);      // #2E7D32
        internal static readonly Color Peligro = Color.FromArgb(198, 40, 40);    // #C62828
        internal static readonly Color Neutro = Color.FromArgb(84, 110, 122);    // #546E7A
        internal static readonly Color Marino = Color.FromArgb(15, 42, 88);      // #0F2A58 cabecera
        internal static readonly Color Fondo = Color.FromArgb(236, 240, 245);    // #ECF0F5
        internal static readonly Color Borde = Color.FromArgb(226, 232, 240);    // #E2E8F0
        internal static readonly Color TextoFuerte = Color.FromArgb(31, 41, 55); // #1F2937
        internal static readonly Color TextoSuave = Color.FromArgb(107, 114, 128);
        internal static readonly Color Acento = Color.FromArgb(47, 111, 228);    // #2F6FE4
        internal static readonly Color Cian = Color.FromArgb(0, 131, 143);       // #00838F
        internal static readonly Color Morado = Color.FromArgb(106, 76, 147);   // #6A4C93
        internal static readonly Color Naranja = Color.FromArgb(192, 86, 33);    // #C05621
        internal static readonly Color Pizarra = Color.FromArgb(55, 71, 79);     // #37474F

        // Los glifos se dibujan una vez y se reutilizan en todos los controles.
        private static readonly Dictionary<string, Image> cacheIconos = new Dictionary<string, Image>();

        internal static void PintarBoton(Graphics g, ButtonBase boton, Color color, Icono icono,
            bool hover, bool pulsado, bool textoDerecha)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // Si el botón cuelga de la ventana o de una tarjeta se repinta el
            // fondo tecnológico en su zona, así no queda un rectángulo plano.
            if (!PintarFondoAncestro(g, boton))
            {
                Color fondoPadre = boton.Parent != null ? boton.Parent.BackColor : Fondo;
                if (fondoPadre.A < 255) fondoPadre = Color.White;
                g.Clear(fondoPadre);
            }

            Color baseColor = boton.Enabled ? color : Color.FromArgb(160, 170, 180);
            int desplazamiento = pulsado ? 1 : 0;

            Rectangle r = new Rectangle(0, desplazamiento, boton.Width - 1, boton.Height - 1);

            using (GraphicsPath ruta = RutaRedondeada(r, 7))
            using (LinearGradientBrush degradado = new LinearGradientBrush(
                new Rectangle(r.X, r.Y, r.Width, Math.Max(1, r.Height)),
                ControlPaint.Light(baseColor, hover ? 0.28F : 0.12F),
                ControlPaint.Dark(baseColor, 0.06F),
                LinearGradientMode.Vertical))
            {
                g.FillPath(degradado, ruta);

                // Brillo interior superior: da sensación de relieve.
                using (Pen brillo = new Pen(Color.FromArgb(70, 255, 255, 255), 1F))
                using (GraphicsPath borde = RutaRedondeada(
                    new Rectangle(r.X + 1, r.Y + 1, r.Width - 2, r.Height - 2), 6))
                {
                    g.DrawPath(brillo, borde);
                }

                // Contorno tenue: define el borde del botón sobre el fondo.
                using (Pen contorno = new Pen(Color.FromArgb(110, ControlPaint.Dark(baseColor, 0.35F)), 1F))
                    g.DrawPath(contorno, ruta);
            }

            if (string.IsNullOrEmpty(boton.Text))
            {
                int lado = Math.Max(14, Math.Min(boton.Height - 14, 30));
                g.DrawImage(CrearIcono(icono, lado), (boton.Width - lado) / 2,
                    r.Y + (boton.Height - lado) / 2, lado, lado);
                return;
            }

            const int ladoIcono = 16;
            const int separacion = 7;
            Size tamanoTexto = TextRenderer.MeasureText(boton.Text, boton.Font);
            int x;

            if (textoDerecha)
            {
                x = 12;
                g.DrawImage(CrearIcono(icono, ladoIcono), x,
                    r.Y + (boton.Height - ladoIcono) / 2, ladoIcono, ladoIcono);

                Rectangle areaDerecha = new Rectangle(x + ladoIcono + separacion, r.Y,
                    boton.Width - x - ladoIcono - separacion - 12, boton.Height);

                TextRenderer.DrawText(g, boton.Text, boton.Font, areaDerecha,
                    boton.Enabled ? Color.White : Color.FromArgb(235, 235, 235),
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Right
                    | TextFormatFlags.EndEllipsis);
                return;
            }

            // Icono y texto se centran como un solo bloque y se recortan con
            // puntos suspensivos: así el texto nunca se sale del botón.
            int contenido = ladoIcono + separacion + tamanoTexto.Width;
            x = Math.Max(10, (boton.Width - contenido) / 2);

            g.DrawImage(CrearIcono(icono, ladoIcono), x,
                r.Y + (boton.Height - ladoIcono) / 2, ladoIcono, ladoIcono);

            Rectangle areaTexto = new Rectangle(x + ladoIcono + separacion, r.Y,
                Math.Max(0, boton.Width - x - ladoIcono - separacion - 8), boton.Height);

            TextRenderer.DrawText(g, boton.Text, boton.Font, areaTexto,
                boton.Enabled ? Color.White : Color.FromArgb(235, 235, 235),
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left
                | TextFormatFlags.EndEllipsis);
        }

        // Pestañas de la cinta del menú: conservan siempre el color de su
        // sección y la activa se ve más luminosa, con contorno claro y barra
        // inferior, así se distingue de un vistazo.
        internal static void PintarPestana(Graphics g, ButtonBase boton, Color color, Icono icono,
            bool hover, bool pulsado, bool activo)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            if (!PintarFondoAncestro(g, boton))
            {
                Color fondoPadre = boton.Parent != null ? boton.Parent.BackColor : Fondo;
                if (fondoPadre.A < 255) fondoPadre = Color.White;
                g.Clear(fondoPadre);
            }

            Color baseColor = boton.Enabled ? color : Color.FromArgb(160, 170, 180);
            int desplazamiento = pulsado ? 1 : 0;
            Rectangle r = new Rectangle(0, desplazamiento, boton.Width - 1, boton.Height - 1);

            Color claro = activo
                ? ControlPaint.Light(baseColor, 0.45F)
                : ControlPaint.Light(baseColor, 0.10F);
            Color oscuro = activo
                ? ControlPaint.Dark(baseColor, 0.02F)
                : ControlPaint.Dark(baseColor, 0.18F);

            if (hover)
            {
                claro = ControlPaint.Light(claro, 0.22F);
                oscuro = ControlPaint.Light(oscuro, 0.12F);
            }

            using (GraphicsPath ruta = RutaRedondeada(r, 8))
            using (LinearGradientBrush degradado = new LinearGradientBrush(
                new Rectangle(r.X, r.Y, r.Width, Math.Max(1, r.Height)),
                claro, oscuro, LinearGradientMode.Vertical))
            {
                g.FillPath(degradado, ruta);
            }

            // Brillo interior: se nota sobre todo en la pestaña activa.
            using (Pen brillo = new Pen(Color.FromArgb(activo ? 130 : 45, 255, 255, 255), 1F))
            using (GraphicsPath borde = RutaRedondeada(
                new Rectangle(r.X + 1, r.Y + 1, r.Width - 2, r.Height - 2), 7))
            {
                g.DrawPath(brillo, borde);
            }

            using (Pen contorno = new Pen(activo
                    ? ControlPaint.Light(baseColor, 0.55F)
                    : Color.FromArgb(130, ControlPaint.Dark(baseColor, 0.30F)), 1F))
            using (GraphicsPath ruta = RutaRedondeada(r, 8))
            {
                g.DrawPath(contorno, ruta);
            }

            if (activo)
            {
                // Barra inferior que marca la sección abierta.
                Rectangle barra = new Rectangle(r.X + 12, r.Bottom - 3, Math.Max(1, r.Width - 24), 3);
                using (LinearGradientBrush luz = new LinearGradientBrush(barra,
                    Color.FromArgb(150, 255, 255, 255), Color.White, LinearGradientMode.Horizontal))
                {
                    g.FillRectangle(luz, barra);
                }
            }

            const int ladoIcono = 16;
            const int separacion = 7;
            Size tamanoTexto = TextRenderer.MeasureText(boton.Text, boton.Font);
            int contenido = ladoIcono + separacion + tamanoTexto.Width;
            int x = Math.Max(10, (boton.Width - contenido) / 2);

            g.DrawImage(CrearIcono(icono, ladoIcono), x,
                r.Y + (boton.Height - ladoIcono) / 2, ladoIcono, ladoIcono);

            Rectangle areaTexto = new Rectangle(x + ladoIcono + separacion, r.Y,
                Math.Max(0, boton.Width - x - ladoIcono - separacion - 8), boton.Height);

            TextRenderer.DrawText(g, boton.Text, boton.Font, areaTexto,
                activo ? Color.White : Color.FromArgb(238, 244, 252),
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left
                | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
        }

        // Busca el ancestro que sabe pintar el fondo tecnológico (ventana,
        // tarjeta o panel) y reproduce en el botón el trozo que le toca.
        private static bool PintarFondoAncestro(Graphics g, Control control)
        {
            Point desplazamiento = Point.Empty;
            Control hijo = control;

            for (Control padre = control.Parent; padre != null; padre = padre.Parent)
            {
                desplazamiento.Offset(hijo.Left, hijo.Top);
                Rectangle zona = new Rectangle(desplazamiento, control.Size);

                FormOmnicell ventana = padre as FormOmnicell;
                if (ventana != null)
                {
                    ventana.PintarFondoEn(g, zona);
                    return true;
                }

                GroupBoxOmnicell tarjeta = padre as GroupBoxOmnicell;
                if (tarjeta != null)
                {
                    tarjeta.PintarFondoEn(g, zona);
                    return true;
                }

                TarjetaOmnicell panel = padre as TarjetaOmnicell;
                if (panel != null)
                {
                    panel.PintarFondoEn(g, zona);
                    return true;
                }

                // Contenedores planos (como la cinta de pestañas): su color es
                // el que realmente rodea al botón, así las esquinas redondeadas
                // no muestran el tono de otro fondo.
                if (padre.BackColor.A == 255)
                {
                    g.Clear(padre.BackColor);
                    return true;
                }

                hijo = padre;
            }

            return false;
        }

        internal static void DibujarHero(Graphics g, Rectangle area)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Fondo);

            Rectangle r = new Rectangle(0, 0, area.Width - 1, area.Height - 1);
            if (r.Width < 2 || r.Height < 2) return;

            using (GraphicsPath ruta = RutaRedondeada(r, 16))
            using (LinearGradientBrush degradado = new LinearGradientBrush(
                r, Marino, Primario, LinearGradientMode.Horizontal))
            {
                g.FillPath(degradado, ruta);
            }

            Image banner = Banner;
            if (banner == null) return;

            int anchoImagen = (int)(r.Width * 0.5F);
            Rectangle destino = new Rectangle(r.Right - anchoImagen, r.Top, anchoImagen, r.Height);

            float escala = Math.Max((float)destino.Width / banner.Width, (float)destino.Height / banner.Height);
            int anchoOrigen = (int)(destino.Width / escala);
            int altoOrigen = (int)(destino.Height / escala);
            Rectangle origen = new Rectangle(
                (banner.Width - anchoOrigen) / 2,
                (banner.Height - altoOrigen) / 2,
                anchoOrigen,
                altoOrigen);

            Region anterior = g.Clip;
            using (GraphicsPath ruta = RutaRedondeada(r, 16))
                g.SetClip(ruta);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(banner, destino, origen, GraphicsUnit.Pixel);

            // Funde la imagen con el degradado para que el texto no compita.
            using (LinearGradientBrush velo = new LinearGradientBrush(
                destino,
                Color.FromArgb(255, Marino.R, Marino.G, Marino.B),
                Color.FromArgb(0, Marino.R, Marino.G, Marino.B),
                LinearGradientMode.Horizontal))
            {
                g.FillRectangle(velo, destino);
            }

            g.Clip = anterior;
        }

        internal static void AplicarGrid(DataGridView grilla)
        {
            grilla.BorderStyle = BorderStyle.None;
            grilla.BackgroundColor = Color.White;
            grilla.GridColor = Borde;
            grilla.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grilla.RowHeadersVisible = false;
            grilla.AllowUserToResizeRows = false;
            grilla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grilla.RowTemplate.Height = 32;
            grilla.ColumnHeadersHeight = 36;
            grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grilla.EnableHeadersVisualStyles = false;

            grilla.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Primario,
                ForeColor = Color.White,
                SelectionBackColor = Primario,
                SelectionForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 0, 0)
            };

            grilla.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = TextoFuerte,
                SelectionBackColor = Primario,
                SelectionForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 0, 0)
            };

            grilla.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(246, 249, 253),
                ForeColor = TextoFuerte,
                SelectionBackColor = Primario,
                SelectionForeColor = Color.White,
                Padding = new Padding(8, 0, 0, 0)
            };

            // Ilumina la fila bajo el cursor para que la lista se sienta interactiva.
            grilla.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                DataGridViewRow fila = grilla.Rows[e.RowIndex];
                if (!fila.Selected) fila.DefaultCellStyle.BackColor = Color.FromArgb(226, 236, 250);
            };

            grilla.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                DataGridViewRow fila = grilla.Rows[e.RowIndex];
                if (!fila.Selected) fila.DefaultCellStyle.BackColor = Color.Empty;
            };
        }

        // Fondo tecnológico común a todas las ventanas: degradado claro,
        // retícula de puntos, trama de circuitos y halo de marca.
        internal static void DibujarFondo(Graphics g, Rectangle area)
        {
            if (area.Width < 2 || area.Height < 2) return;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle zona = new Rectangle(0, 0, area.Width, area.Height);

            using (LinearGradientBrush degradado = new LinearGradientBrush(
                zona,
                Color.FromArgb(250, 252, 255),
                Color.FromArgb(220, 231, 245),
                LinearGradientMode.ForwardDiagonal))
            {
                g.FillRectangle(degradado, area);
            }

            using (SolidBrush punto = new SolidBrush(Color.FromArgb(24, 31, 78, 156)))
            {
                for (int y = 13; y < zona.Height; y += 26)
                    for (int x = 13; x < zona.Width; x += 26)
                        g.FillRectangle(punto, x, y, 2, 2);
            }

            using (Pen trazo = new Pen(Color.FromArgb(16, 31, 78, 156), 1F))
            {
                for (int x = -zona.Height; x < zona.Width; x += 84)
                    g.DrawLine(trazo, x, zona.Height, x + zona.Height, 0);
            }

            using (GraphicsPath halo = new GraphicsPath())
            {
                halo.AddEllipse(-260, -300, 660, 660);

                using (PathGradientBrush brillo = new PathGradientBrush(halo))
                {
                    brillo.CenterColor = Color.FromArgb(38, 31, 78, 156);
                    brillo.SurroundColors = new[] { Color.FromArgb(0, 31, 78, 156) };
                    g.FillPath(brillo, halo);
                }
            }
        }

        // Superficie de tarjeta: degradado claro con retícula de plano y
        // trazas de circuito. Se guarda por tamaño para repintar rápido.
        private static readonly Dictionary<string, Bitmap> cacheTarjetas = new Dictionary<string, Bitmap>();

        internal static void DibujarTarjeta(Graphics g, Rectangle area, bool sutil)
        {
            if (area.Width < 4 || area.Height < 4) return;

            string clave = (sutil ? "s:" : "n:") + area.Width + "x" + area.Height;
            Bitmap superficie;

            if (!cacheTarjetas.TryGetValue(clave, out superficie))
            {
                if (cacheTarjetas.Count > 24)
                {
                    foreach (Bitmap vieja in cacheTarjetas.Values) vieja.Dispose();
                    cacheTarjetas.Clear();
                }

                superficie = new Bitmap(area.Width, area.Height);
                using (Graphics lienzo = Graphics.FromImage(superficie))
                    PintarTarjeta(lienzo, new Rectangle(0, 0, area.Width, area.Height), sutil);

                cacheTarjetas[clave] = superficie;
            }

            g.DrawImageUnscaled(superficie, area.Location);
        }

        private static void PintarTarjeta(Graphics g, Rectangle zona, bool sutil)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Color arriba = sutil ? Color.FromArgb(250, 252, 255) : Color.FromArgb(253, 254, 255);
            Color abajo = sutil ? Color.FromArgb(237, 243, 251) : Color.FromArgb(225, 235, 249);

            using (LinearGradientBrush fondo = new LinearGradientBrush(zona, arriba, abajo, LinearGradientMode.Vertical))
                g.FillRectangle(fondo, zona);

            // Retícula de puntos: da textura tecnológica sin competir con los
            // datos ni con las etiquetas.
            int paso = sutil ? 20 : 22;
            using (SolidBrush punto = new SolidBrush(Color.FromArgb(sutil ? 20 : 34, Primario)))
            {
                for (int y = paso - 4; y < zona.Height; y += paso)
                    for (int x = paso - 4; x < zona.Width; x += paso)
                        g.FillRectangle(punto, x, y, 2, 2);
            }

            Rectangle haloArea = new Rectangle(-(zona.Width / 4), -240, (zona.Width * 9 / 10) + 420, 520);
            if (haloArea.Width > 8 && haloArea.Height > 8)
            {
                using (GraphicsPath halo = new GraphicsPath())
                {
                    halo.AddEllipse(haloArea);

                    using (PathGradientBrush brillo = new PathGradientBrush(halo))
                    {
                        brillo.CenterColor = Color.FromArgb(sutil ? 16 : 30, Acento);
                        brillo.SurroundColors = new[] { Color.FromArgb(0, Acento) };
                        g.FillPath(brillo, halo);
                    }
                }
            }

            // Traza de circuito en la esquina superior derecha.
            if (!sutil && zona.Width > 420)
            {
                using (Pen traza = new Pen(Color.FromArgb(40, Acento), 1.3F))
                using (SolidBrush nodo = new SolidBrush(Color.FromArgb(70, Cian)))
                {
                    int x = zona.Width - 210;
                    int y = 20;

                    g.DrawLine(traza, x, y, x + 46, y);
                    g.DrawLine(traza, x + 46, y, x + 46, y + 26);
                    g.DrawLine(traza, x + 46, y + 26, x + 108, y + 26);
                    g.DrawLine(traza, x + 108, y + 26, x + 108, y + 56);
                    g.DrawLine(traza, x + 108, y + 56, x + 174, y + 56);

                    g.FillRectangle(nodo, x - 3, y - 3, 6, 6);
                    g.FillRectangle(nodo, x + 105, y + 23, 6, 6);
                    g.FillRectangle(nodo, x + 171, y + 53, 6, 6);
                }
            }

            using (Pen brillo = new Pen(Color.FromArgb(150, 255, 255, 255), 1F))
                g.DrawLine(brillo, 1, 1, zona.Width - 2, 1);
        }

        // Bloque de marca para el panel lateral del inicio de sesión.
        internal static void DibujarMarca(Graphics g, Rectangle area)
        {
            if (area.Width < 2 || area.Height < 2) return;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle zona = new Rectangle(0, 0, area.Width, area.Height);

            using (LinearGradientBrush degradado = new LinearGradientBrush(
                zona, Marino, Color.FromArgb(38, 92, 178), LinearGradientMode.Vertical))
            {
                g.FillRectangle(degradado, area);
            }

            using (SolidBrush punto = new SolidBrush(Color.FromArgb(30, 255, 255, 255)))
            {
                for (int y = 14; y < zona.Height; y += 28)
                    for (int x = 14; x < zona.Width; x += 28)
                        g.FillRectangle(punto, x, y, 2, 2);
            }

            using (Pen trazo = new Pen(Color.FromArgb(26, 255, 255, 255), 1F))
            {
                for (int x = -zona.Height; x < zona.Width; x += 86)
                    g.DrawLine(trazo, x, zona.Height, x + zona.Height, 0);
            }

            using (GraphicsPath halo = new GraphicsPath())
            {
                halo.AddEllipse(-180, zona.Height - 320, 520, 520);

                using (PathGradientBrush brillo = new PathGradientBrush(halo))
                {
                    brillo.CenterColor = Color.FromArgb(46, 47, 111, 228);
                    brillo.SurroundColors = new[] { Color.FromArgb(0, 47, 111, 228) };
                    g.FillPath(brillo, halo);
                }
            }
        }

        internal static void UbicarBotonBusqueda(ButtonBase boton, TextBox caja)
        {
            if (caja.Parent == null) return;

            boton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            boton.Left = caja.Parent.ClientSize.Width - boton.Width - 9;
            caja.Width = boton.Left - caja.Left - 11;
            boton.Top = caja.Top + (caja.Height - boton.Height) / 2;
        }

        internal static GraphicsPath RutaRedondeada(Rectangle r, int radio)
        {
            GraphicsPath ruta = new GraphicsPath();
            int diametro = Math.Max(1, Math.Min(radio * 2, Math.Min(r.Width, r.Height)));

            ruta.AddArc(r.X, r.Y, diametro, diametro, 180, 90);
            ruta.AddArc(r.Right - diametro, r.Y, diametro, diametro, 270, 90);
            ruta.AddArc(r.Right - diametro, r.Bottom - diametro, diametro, diametro, 0, 90);
            ruta.AddArc(r.X, r.Bottom - diametro, diametro, diametro, 90, 90);
            ruta.CloseFigure();

            return ruta;
        }

        // Imagen de marca incrustada en el ejecutable (Recursos/bannerOmnicell.jpg).
        private static Image banner;
        private static Image Banner
        {
            get
            {
                if (banner == null)
                {
                    System.Reflection.Assembly ensamblado = typeof(Estilos).Assembly;
                    Stream flujo = ensamblado
                        .GetManifestResourceStream("CpOmnicell.Recursos.bannerOmnicell.jpg");

                    // Si el recurso se incrusta con otro nombre, lo busca por terminación.
                    if (flujo == null)
                    {
                        string nombre = Array.Find(ensamblado.GetManifestResourceNames(),
                            n => n.EndsWith("bannerOmnicell.jpg", StringComparison.OrdinalIgnoreCase));

                        if (nombre != null) flujo = ensamblado.GetManifestResourceStream(nombre);
                    }

                    using (flujo)
                    {
                        if (flujo != null)
                        {
                            using (Image temporal = Image.FromStream(flujo))
                                banner = new Bitmap(temporal);
                        }
                    }
                }

                return banner;
            }
        }

        internal static Image CrearIcono(Icono tipo, int tamano)
        {
            string clave = tipo + "_" + tamano;

            if (cacheIconos.TryGetValue(clave, out Image guardado))
                return guardado;

            Bitmap bmp = new Bitmap(tamano, tamano);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.Clear(Color.Transparent);

                float t = tamano;
                float grosor = Math.Max(1.5F, t * 0.085F);

                using (Pen lapiz = new Pen(Color.White, grosor))
                using (Pen fino = new Pen(Color.White, Math.Max(1.1F, grosor * 0.66F)))
                using (SolidBrush pincel = new SolidBrush(Color.White))
                {
                    lapiz.StartCap = LineCap.Round;
                    lapiz.EndCap = LineCap.Round;
                    lapiz.LineJoin = LineJoin.Round;
                    fino.StartCap = LineCap.Round;
                    fino.EndCap = LineCap.Round;

                    switch (tipo)
                    {
                        case Icono.Buscar:
                            g.DrawEllipse(lapiz, t * 0.12F, t * 0.12F, t * 0.52F, t * 0.52F);
                            g.DrawArc(fino, t * 0.22F, t * 0.20F, t * 0.30F, t * 0.30F, 195F, 75F);
                            g.DrawLine(lapiz, t * 0.63F, t * 0.63F, t * 0.90F, t * 0.90F);
                            break;

                        case Icono.Detalles:
                            using (GraphicsPath hoja = RutaRedondeada(
                                new Rectangle((int)(t * 0.16F), (int)(t * 0.10F), (int)(t * 0.68F), (int)(t * 0.80F)),
                                (int)(t * 0.18F)))
                                g.DrawPath(fino, hoja);

                            g.DrawLine(fino, t * 0.30F, t * 0.32F, t * 0.70F, t * 0.32F);
                            g.DrawLine(fino, t * 0.30F, t * 0.48F, t * 0.70F, t * 0.48F);
                            g.DrawLine(fino, t * 0.30F, t * 0.64F, t * 0.56F, t * 0.64F);
                            break;

                        case Icono.Editar:
                            g.FillPolygon(pincel, new[]
                            {
                                new PointF(t * 0.22F, t * 0.80F),
                                new PointF(t * 0.28F, t * 0.62F),
                                new PointF(t * 0.66F, t * 0.18F),
                                new PointF(t * 0.80F, t * 0.30F),
                                new PointF(t * 0.42F, t * 0.74F)
                            });
                            g.FillPolygon(pincel, new[]
                            {
                                new PointF(t * 0.22F, t * 0.80F),
                                new PointF(t * 0.28F, t * 0.62F),
                                new PointF(t * 0.40F, t * 0.72F)
                            });
                            g.DrawLine(fino, t * 0.16F, t * 0.90F, t * 0.84F, t * 0.90F);
                            break;

                        case Icono.Eliminar:
                            g.DrawLine(lapiz, t * 0.14F, t * 0.24F, t * 0.86F, t * 0.24F);
                            g.DrawLine(fino, t * 0.38F, t * 0.24F, t * 0.38F, t * 0.13F);
                            g.DrawLine(fino, t * 0.62F, t * 0.24F, t * 0.62F, t * 0.13F);
                            g.DrawLine(fino, t * 0.38F, t * 0.13F, t * 0.62F, t * 0.13F);
                            using (GraphicsPath cuerpo = RutaRedondeada(
                                new Rectangle((int)(t * 0.24F), (int)(t * 0.31F), (int)(t * 0.52F), (int)(t * 0.56F)),
                                (int)(t * 0.12F)))
                                g.DrawPath(fino, cuerpo);
                            g.DrawLine(fino, t * 0.42F, t * 0.44F, t * 0.42F, t * 0.74F);
                            g.DrawLine(fino, t * 0.58F, t * 0.44F, t * 0.58F, t * 0.74F);
                            break;

                        case Icono.Agregar:
                            g.DrawEllipse(fino, t * 0.10F, t * 0.10F, t * 0.80F, t * 0.80F);
                            g.DrawLine(lapiz, t * 0.50F, t * 0.28F, t * 0.50F, t * 0.72F);
                            g.DrawLine(lapiz, t * 0.28F, t * 0.50F, t * 0.72F, t * 0.50F);
                            break;

                        case Icono.Guardar:
                            using (GraphicsPath disco = RutaRedondeada(
                                new Rectangle((int)(t * 0.12F), (int)(t * 0.12F), (int)(t * 0.76F), (int)(t * 0.76F)),
                                (int)(t * 0.16F)))
                                g.DrawPath(lapiz, disco);

                            g.DrawRectangle(fino, (int)(t * 0.35F), (int)(t * 0.12F), (int)(t * 0.26F), (int)(t * 0.22F));
                            g.DrawRectangle(fino, (int)(t * 0.28F), (int)(t * 0.58F), (int)(t * 0.44F), (int)(t * 0.30F));
                            g.DrawLine(fino, t * 0.34F, t * 0.72F, t * 0.66F, t * 0.72F);
                            break;

                        case Icono.Cancelar:
                            g.DrawEllipse(fino, t * 0.10F, t * 0.10F, t * 0.80F, t * 0.80F);
                            g.DrawLine(lapiz, t * 0.34F, t * 0.34F, t * 0.66F, t * 0.66F);
                            g.DrawLine(lapiz, t * 0.66F, t * 0.34F, t * 0.34F, t * 0.66F);
                            break;

                        case Icono.Ingresar:
                            g.DrawLine(lapiz, t * 0.32F, t * 0.12F, t * 0.16F, t * 0.12F);
                            g.DrawLine(lapiz, t * 0.16F, t * 0.12F, t * 0.16F, t * 0.88F);
                            g.DrawLine(lapiz, t * 0.16F, t * 0.88F, t * 0.32F, t * 0.88F);
                            g.DrawLine(lapiz, t * 0.40F, t * 0.50F, t * 0.88F, t * 0.50F);
                            g.DrawLine(lapiz, t * 0.70F, t * 0.32F, t * 0.88F, t * 0.50F);
                            g.DrawLine(lapiz, t * 0.70F, t * 0.68F, t * 0.88F, t * 0.50F);
                            break;

                        case Icono.Inicio:
                            g.DrawLine(lapiz, t * 0.50F, t * 0.12F, t * 0.13F, t * 0.44F);
                            g.DrawLine(lapiz, t * 0.50F, t * 0.12F, t * 0.87F, t * 0.44F);
                            g.DrawLine(fino, t * 0.23F, t * 0.38F, t * 0.23F, t * 0.86F);
                            g.DrawLine(fino, t * 0.23F, t * 0.86F, t * 0.77F, t * 0.86F);
                            g.DrawLine(fino, t * 0.77F, t * 0.38F, t * 0.77F, t * 0.86F);
                            g.DrawRectangle(fino, (int)(t * 0.43F), (int)(t * 0.60F), (int)(t * 0.14F), (int)(t * 0.26F));
                            break;

                        case Icono.Venta:
                            g.DrawLine(lapiz, t * 0.08F, t * 0.16F, t * 0.20F, t * 0.16F);
                            g.DrawLine(lapiz, t * 0.20F, t * 0.16F, t * 0.32F, t * 0.62F);
                            g.DrawLine(lapiz, t * 0.32F, t * 0.62F, t * 0.78F, t * 0.62F);
                            g.DrawLine(lapiz, t * 0.26F, t * 0.28F, t * 0.86F, t * 0.28F);
                            g.DrawLine(lapiz, t * 0.86F, t * 0.28F, t * 0.78F, t * 0.62F);
                            g.FillEllipse(pincel, t * 0.34F, t * 0.70F, t * 0.14F, t * 0.14F);
                            g.FillEllipse(pincel, t * 0.62F, t * 0.70F, t * 0.14F, t * 0.14F);
                            break;

                        case Icono.Compra:
                            using (GraphicsPath caja = RutaRedondeada(
                                new Rectangle((int)(t * 0.14F), (int)(t * 0.44F), (int)(t * 0.72F), (int)(t * 0.44F)),
                                (int)(t * 0.12F)))
                                g.DrawPath(lapiz, caja);

                            g.DrawLine(lapiz, t * 0.50F, t * 0.08F, t * 0.50F, t * 0.34F);
                            g.DrawLine(lapiz, t * 0.34F, t * 0.20F, t * 0.50F, t * 0.34F);
                            g.DrawLine(lapiz, t * 0.66F, t * 0.20F, t * 0.50F, t * 0.34F);
                            g.DrawLine(fino, t * 0.30F, t * 0.60F, t * 0.70F, t * 0.60F);
                            break;

                        case Icono.Historial:
                            g.DrawEllipse(lapiz, t * 0.13F, t * 0.13F, t * 0.74F, t * 0.74F);
                            g.DrawLine(lapiz, t * 0.50F, t * 0.26F, t * 0.50F, t * 0.52F);
                            g.DrawLine(lapiz, t * 0.50F, t * 0.52F, t * 0.70F, t * 0.62F);
                            g.FillEllipse(pincel, t * 0.45F, t * 0.47F, t * 0.10F, t * 0.10F);
                            break;

                        case Icono.Pantalla:
                            using (GraphicsPath monitor = RutaRedondeada(
                                new Rectangle((int)(t * 0.08F), (int)(t * 0.14F), (int)(t * 0.84F), (int)(t * 0.54F)),
                                (int)(t * 0.16F)))
                                g.DrawPath(lapiz, monitor);

                            g.DrawLine(lapiz, t * 0.50F, t * 0.68F, t * 0.50F, t * 0.84F);
                            g.DrawLine(lapiz, t * 0.28F, t * 0.88F, t * 0.72F, t * 0.88F);
                            g.DrawLine(fino, t * 0.62F, t * 0.24F, t * 0.80F, t * 0.24F);
                            g.DrawLine(fino, t * 0.62F, t * 0.32F, t * 0.72F, t * 0.32F);
                            break;

                        case Icono.Cliente:
                            g.DrawEllipse(lapiz, t * 0.32F, t * 0.12F, t * 0.36F, t * 0.36F);
                            g.DrawArc(lapiz, t * 0.14F, t * 0.52F, t * 0.72F, t * 0.44F, 180F, 180F);
                            g.DrawLine(fino, t * 0.50F, t * 0.58F, t * 0.50F, t * 0.84F);
                            break;

                        case Icono.Proveedor:
                            g.DrawLine(lapiz, t * 0.08F, t * 0.26F, t * 0.08F, t * 0.64F);
                            g.DrawLine(lapiz, t * 0.08F, t * 0.26F, t * 0.52F, t * 0.26F);
                            g.DrawLine(lapiz, t * 0.52F, t * 0.26F, t * 0.52F, t * 0.64F);
                            g.DrawLine(lapiz, t * 0.08F, t * 0.64F, t * 0.66F, t * 0.64F);
                            g.DrawLine(lapiz, t * 0.52F, t * 0.34F, t * 0.68F, t * 0.34F);
                            g.DrawLine(lapiz, t * 0.68F, t * 0.34F, t * 0.86F, t * 0.52F);
                            g.DrawLine(lapiz, t * 0.86F, t * 0.52F, t * 0.86F, t * 0.64F);
                            g.FillEllipse(pincel, t * 0.14F, t * 0.62F, t * 0.16F, t * 0.16F);
                            g.FillEllipse(pincel, t * 0.62F, t * 0.62F, t * 0.16F, t * 0.16F);
                            break;

                        case Icono.Usuarios:
                            g.DrawEllipse(lapiz, t * 0.08F, t * 0.18F, t * 0.28F, t * 0.28F);
                            g.DrawArc(lapiz, t * 0.01F, t * 0.52F, t * 0.42F, t * 0.32F, 180F, 180F);
                            g.DrawEllipse(fino, t * 0.54F, t * 0.22F, t * 0.26F, t * 0.26F);
                            g.DrawArc(fino, t * 0.50F, t * 0.54F, t * 0.40F, t * 0.30F, 180F, 180F);
                            break;

                        case Icono.Empleado:
                            using (GraphicsPath credencial = RutaRedondeada(
                                new Rectangle((int)(t * 0.10F), (int)(t * 0.18F), (int)(t * 0.80F), (int)(t * 0.64F)),
                                (int)(t * 0.14F)))
                                g.DrawPath(lapiz, credencial);

                            g.FillEllipse(pincel, t * 0.20F, t * 0.30F, t * 0.18F, t * 0.18F);
                            g.DrawArc(lapiz, t * 0.14F, t * 0.48F, t * 0.30F, t * 0.20F, 180F, 180F);
                            g.DrawLine(fino, t * 0.48F, t * 0.40F, t * 0.78F, t * 0.40F);
                            g.DrawLine(fino, t * 0.48F, t * 0.54F, t * 0.78F, t * 0.54F);
                            g.DrawLine(fino, t * 0.48F, t * 0.68F, t * 0.68F, t * 0.68F);
                            break;

                        case Icono.Salir:
                            g.DrawLine(lapiz, t * 0.68F, t * 0.12F, t * 0.84F, t * 0.12F);
                            g.DrawLine(lapiz, t * 0.84F, t * 0.12F, t * 0.84F, t * 0.88F);
                            g.DrawLine(lapiz, t * 0.84F, t * 0.88F, t * 0.68F, t * 0.88F);
                            g.DrawLine(lapiz, t * 0.12F, t * 0.50F, t * 0.60F, t * 0.50F);
                            g.DrawLine(lapiz, t * 0.42F, t * 0.32F, t * 0.60F, t * 0.50F);
                            g.DrawLine(lapiz, t * 0.42F, t * 0.68F, t * 0.60F, t * 0.50F);
                            break;
                    }
                }
            }

            cacheIconos[clave] = bmp;
            return bmp;
        }
    }
}
