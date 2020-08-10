namespace TalentRecruiter.Site.Models
{
    /// <summary>
    /// Modelo para la seleccion de tecnologias de la vista
    /// </summary>
    public class TechnologyViewModelSelect
    {
        /// <summary>
        /// Tecnologia id
        /// </summary>
        public int TechnologyId { get; set; }

        /// <summary>
        /// Descripcion de la tecnologia
        /// </summary>
        public string TechnologyDescription { get; set; }

        /// <summary>
        /// Numero par o impar de la tecnologia detalle seleccionada
        /// </summary>
        public int TechnologyOrderId { get; set; }

        /// <summary>
        /// Tecnologia detalle id seleccionada
        /// </summary>
        public int TechnologyDetailId { get; set; }

        /// <summary>
        /// Tecnologia detalle descripcion
        /// </summary>
        public string TechnologyDetailDescription { get; set; }
    }
}