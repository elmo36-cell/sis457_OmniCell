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
    }
}
