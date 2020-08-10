using System;

namespace TalentRecruiter.Site.Models
{
    /// <summary>
    /// Modelo para buscar entrevistas por fecha de entrevista y tipo de entrevistas
    /// </summary>
    public class SearchInterviewViewModel
    {
        /// <summary>
        /// Dia de entrevista
        /// </summary>
        public DateTime? DateInterView { get; set; }

        /// <summary>
        /// Tipo de entrevista
        /// </summary>
        public int TypeInterViewId { get; set; }
    }
}