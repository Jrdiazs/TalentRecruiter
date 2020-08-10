namespace Model
{
    /// <summary>
    /// Modelo input para realizar un paginado
    /// </summary>
    public class PageModelRequest
    {
        /// <summary>
        /// Numero de pagina
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Registros por pagina
        /// </summary>
        public int RowsPerPage { get; set; } = 20;

        /// <summary>
        /// Filtro sql
        /// </summary>
        public string Conditions { get; set; }

        /// <summary>
        /// Ordenamiento sql
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Parametros
        /// </summary>
        public object Parameters { get; set; }
    }
}