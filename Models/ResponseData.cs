namespace Models
{
    /// <summary>
    /// Objeto para enviar respuestas de menssajes
    /// </summary>
    public class ResponseData
    {
        /// <summary>
        /// Mensaje de advertencia o error
        /// </summary>
        public string MessageInfo { get; set; }

        /// <summary>
        /// Identifica si la respuesta fue exitosa o fallida
        /// </summary>
        public bool Succes { get; set; }

        /// <summary>
        /// Objeto a enviar
        /// </summary>
        public object Value { get; set; }
    }
}