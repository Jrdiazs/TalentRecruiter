namespace TalentRecruiter.Site.Models
{
    /// <summary>
    /// Tecnologia detalle vista model
    /// </summary>
    public class TechnologyDetailViewModel
    {
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

        /// <summary>
        /// Tecnologia seleccionada JAVA O NET
        /// </summary>
        public int TechnologyId { get; set; }

        /// <summary>
        /// Nombre de la tecnologia seleccionada JAVA o NET
        /// </summary>
        public string TechnologyDescription { get; set; }
    }
}