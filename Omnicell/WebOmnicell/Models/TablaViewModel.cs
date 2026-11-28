namespace WebOmnicell.Models
{
    /// <summary>
    /// Datos que necesitan las vistas de listado: columnas, filas ya formateadas
    /// y la información de paginación (10 filas por página).
    /// </summary>
    public class TablaViewModel
    {
        public string Titulo { get; set; } = string.Empty;
        public string Accion { get; set; } = string.Empty;
        public string[] Columnas { get; set; } = Array.Empty<string>();
        public List<string[]> Filas { get; set; } = new List<string[]>();
        public string Parametro { get; set; } = string.Empty;
        public int Pagina { get; set; } = 1;
        public int TotalPaginas { get; set; } = 1;
        public int Total { get; set; }

        // Cuando el módulo permite editar, la vista agrega la columna de acciones
        // y el botón para crear un registro nuevo.
        public string? AccionEditar { get; set; }
        public string? TextoNuevo { get; set; }
        public List<int> Ids { get; set; } = new List<int>();

        // Filas marcadas con alerta (en Inventario: stockActual <= stockMinimo).
        // La vista resalta la fila y agrega la etiqueta en la columna indicada.
        public List<bool> Alertas { get; set; } = new List<bool>();
        public int ColumnaAlerta { get; set; } = -1;

        // Filtro opcional del módulo, con la cantidad de registros en alerta.
        public string? FiltroTexto { get; set; }
        public bool FiltroActivo { get; set; }
        public int FiltroTotal { get; set; }
    }
}
