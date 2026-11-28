using CadOmnicell;
using CpMinerva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CpOmnicell
{
    // Tareas repetidas sobre las grillas: listados y carrito de venta/compra.
    public static class GrillasOmnicell
    {
        public const string ColumnaNumero = "colNumero";

        internal const int AnchoNumero = 40;

        private const string ColumnaId = "id";

        // ---------- Listados ----------

        // Numera las filas del listado y agrega la columna al inicio la primera vez.
        public static void Numerar(DataGridView grilla, string encabezado)
        {
            if (!grilla.Columns.Contains(ColumnaNumero))
                agregarColumnaNumero(grilla, encabezado);

            int numero = 1;

            foreach (DataGridViewRow fila in grilla.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                fila.Cells[ColumnaNumero].Value = numero;
                numero++;
            }
        }

        private static void agregarColumnaNumero(DataGridView grilla, string encabezado)
        {
            DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn
            {
                Name = ColumnaNumero,
                HeaderText = encabezado,
                ReadOnly = true,
                Width = AnchoNumero,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns.Insert(0, columna);
        }

        public static void Ocultar(DataGridView grilla, params string[] columnas)
        {
            foreach (string columna in columnas)
            {
                if (grilla.Columns.Contains(columna))
                    grilla.Columns[columna].Visible = false;
            }
        }

        // Cambia el encabezado y, si se indica, el formato de una columna del listado.
        public static void Titulo(DataGridView grilla, string columna, string encabezado, string formato = null)
        {
            if (!grilla.Columns.Contains(columna))
                return;

            grilla.Columns[columna].HeaderText = encabezado;

            if (!string.IsNullOrEmpty(formato))
                grilla.Columns[columna].DefaultCellStyle.Format = formato;
        }

        // Id de la fila seleccionada; -1 cuando no hay una selección válida.
        public static int IdSeleccionado(DataGridView grilla)
        {
            DataGridViewRow fila = grilla.CurrentRow;

            if (fila == null || fila.IsNewRow || !grilla.Columns.Contains(ColumnaId))
                return -1;

            object valor = fila.Cells[ColumnaId].Value;

            return valor == null ? -1 : Convert.ToInt32(valor);
        }

        // Deja la grilla del detalle solo para consulta, sin filas nuevas.
        public static void ConfigurarDetalle(DataGridView grilla)
        {
            grilla.AutoGenerateColumns = false;
            grilla.AllowUserToAddRows = false;
            grilla.ReadOnly = true;
            grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grilla.MultiSelect = false;
        }
    }

    public enum TipoCarrito
    {
        Venta,
        Compra
    }

    // Línea del carrito antes de convertirse en detalle de venta o de compra.
    public class LineaCarrito
    {
        public int IdPantalla { get; set; }
        public int IdModelo { get; set; }
        public string Sku { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Calidad { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }

        public decimal Subtotal
        {
            get { return Cantidad * Precio; }
        }
    }

    // Grilla del carrito: columnas, totales y lectura de los detalles.
    public static class CarritoOmnicell
    {
        public const string ColIdPantalla = "colIdPantalla";
        public const string ColIdModelo = "colIdModelo";
        public const string ColSku = "colSku";
        public const string ColDescripcion = "colDescripcion";
        public const string ColMarca = "colMarca";
        public const string ColModelo = "colModelo";
        public const string ColCalidad = "colCalidad";
        public const string ColCantidad = "colCantidad";
        public const string ColPrecio = "colPrecio";
        public const string ColSubtotal = "colSubtotal";

        private const float PesoSku = 65F;
        private const float PesoDescripcion = 200F;
        private const float PesoDato = 75F;
        private const float PesoCantidad = 80F;
        private const float PesoMonto = 90F;

        // Columnas del carrito; en venta solo la cantidad es editable.
        public static void Configurar(DataGridView grilla, TipoCarrito tipo)
        {
            grilla.DataSource = null;
            grilla.Rows.Clear();
            grilla.Columns.Clear();

            grilla.AutoGenerateColumns = false;
            grilla.AllowUserToAddRows = false;
            grilla.AllowUserToDeleteRows = false;
            grilla.RowHeadersVisible = false;
            grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grilla.MultiSelect = false;
            grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewTextBoxColumn numero =
                AgregarColumna(grilla, GrillasOmnicell.ColumnaNumero, "N.º");
            numero.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            numero.Width = GrillasOmnicell.AnchoNumero;
            numero.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            AgregarColumna(grilla, ColIdPantalla, "ID Pantalla").Visible = false;
            AgregarColumna(grilla, ColIdModelo, "ID Modelo").Visible = false;

            AgregarColumna(grilla, ColSku, "SKU", PesoSku);
            AgregarColumna(grilla, ColDescripcion, "Descripción", PesoDescripcion);
            AgregarColumna(grilla, ColMarca, "Marca", PesoDato);
            AgregarColumna(grilla, ColModelo, "Modelo", PesoDato);
            AgregarColumna(grilla, ColCalidad, "Calidad", PesoDato);
            AgregarColumna(grilla, ColCantidad, "Cantidad", PesoCantidad, Formatos.Cantidad);
            AgregarColumna(grilla, ColPrecio,
                tipo == TipoCarrito.Venta ? "P. unitario" : "Costo unit.", PesoMonto, Formatos.Monto);
            AgregarColumna(grilla, ColSubtotal, "Subtotal", PesoMonto, Formatos.Monto);

            if (tipo == TipoCarrito.Compra)
            {
                grilla.ReadOnly = true;
                return;
            }

            // Solo la cantidad se puede editar; los datos del producto quedan protegidos.
            grilla.ReadOnly = false;
            grilla.EditMode = DataGridViewEditMode.EditOnEnter;

            foreach (DataGridViewColumn columna in grilla.Columns)
                columna.ReadOnly = true;

            grilla.Columns[ColCantidad].ReadOnly = false;
        }

        private static DataGridViewTextBoxColumn AgregarColumna(
            DataGridView grilla, string nombre, string encabezado,
            float peso = 100F, string formato = null)
        {
            DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn
            {
                Name = nombre,
                HeaderText = encabezado,
                FillWeight = peso
            };

            if (!string.IsNullOrEmpty(formato))
                columna.DefaultCellStyle.Format = formato;

            grilla.Columns.Add(columna);

            return columna;
        }

        // Fila del carrito con la misma pantalla y modelo, o null si todavía no está.
        public static DataGridViewRow Buscar(DataGridView grilla, int idPantalla, int idModelo)
        {
            return grilla.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(fila => IdPantalla(fila) == idPantalla && IdModelo(fila) == idModelo);
        }

        // Cantidad que ya ocupa una pantalla en el carrito, sin contar una fila.
        public static decimal CantidadEnCarrito(DataGridView grilla, int idPantalla, int filaExcluida = -1)
        {
            return grilla.Rows
                .Cast<DataGridViewRow>()
                .Where(fila => fila.Index != filaExcluida && IdPantalla(fila) == idPantalla)
                .Sum(fila => Cantidad(fila));
        }

        public static void Agregar(DataGridView grilla, LineaCarrito linea)
        {
            grilla.Rows.Add(
                grilla.Rows.Count + 1,
                linea.IdPantalla,
                linea.IdModelo,
                linea.Sku,
                linea.Descripcion,
                linea.Marca,
                linea.Modelo,
                linea.Calidad,
                linea.Cantidad,
                linea.Precio,
                linea.Subtotal);
        }

        public static void Actualizar(DataGridViewRow fila, decimal cantidad, decimal precio)
        {
            fila.Cells[ColCantidad].Value = cantidad;
            fila.Cells[ColPrecio].Value = precio;
            fila.Cells[ColSubtotal].Value = cantidad * precio;
        }

        public static void Renumerar(DataGridView grilla)
        {
            for (int indice = 0; indice < grilla.Rows.Count; indice++)
                grilla.Rows[indice].Cells[GrillasOmnicell.ColumnaNumero].Value = indice + 1;
        }

        public static decimal Total(DataGridView grilla)
        {
            return grilla.Rows.Cast<DataGridViewRow>().Sum(Subtotal);
        }

        public static decimal Cantidad(DataGridViewRow fila)
        {
            return Convert.ToDecimal(fila.Cells[ColCantidad].Value);
        }

        public static decimal Precio(DataGridViewRow fila)
        {
            return Convert.ToDecimal(fila.Cells[ColPrecio].Value);
        }

        public static List<VentaDetalle> LeerDetallesVenta(DataGridView grilla)
        {
            return grilla.Rows.Cast<DataGridViewRow>().Select(fila => new VentaDetalle
            {
                idPantalla = IdPantalla(fila),
                cantidad = Cantidad(fila),
                precioUnitario = Precio(fila),
                subtotal = Subtotal(fila)
            }).ToList();
        }

        public static List<CompraDetalle> LeerDetallesCompra(DataGridView grilla)
        {
            return grilla.Rows.Cast<DataGridViewRow>().Select(fila => new CompraDetalle
            {
                idPantalla = IdPantalla(fila),
                cantidad = Cantidad(fila),
                costoUnitario = Precio(fila),
                subtotal = Subtotal(fila)
            }).ToList();
        }

        private static int IdPantalla(DataGridViewRow fila)
        {
            return Convert.ToInt32(fila.Cells[ColIdPantalla].Value);
        }

        private static int IdModelo(DataGridViewRow fila)
        {
            return Convert.ToInt32(fila.Cells[ColIdModelo].Value);
        }

        private static decimal Subtotal(DataGridViewRow fila)
        {
            return Convert.ToDecimal(fila.Cells[ColSubtotal].Value);
        }
    }
}
