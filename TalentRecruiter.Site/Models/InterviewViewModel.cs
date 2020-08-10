using Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace TalentRecruiter.Site.Models
{
    /// <summary>
    /// Vista modelo para la creacion de las entrevistas con el candidato seleccionado
    /// </summary>
    public class InterviewViewModel
    {
        /// <summary>
        /// Id de entrevista
        /// </summary>

        public int InterviewId { get; set; }

        /// <summary>
        /// Id candidato
        /// </summary>
        [Required]
        public int CandidateId { get; set; }

        /// <summary>
        /// Tecnologia seleccionada
        /// </summary>
        [Required]
        public int TechnologyDetailId { get; set; }

        /// <summary>
        /// Fecha de inicio de entrevista
        /// </summary>
        [Required]
        public DateTime? InterviewStartTime { get; set; }

        /// <summary>
        /// Fecha final de entrevista
        /// </summary>
        [Required]
        public DateTime? InterviewFinalTime { get; set; }

        /// <summary>
        /// Tipo de entrevista
        /// </summary>
        [Required]
        public int TypeInterviewId { get; set; }

        /// <summary>
        /// Observacion de la entrevista
        /// </summary>

        public string Observation { get; set; }

        /// <summary>
        /// Tecnologia descripcion seleccionada
        /// </summary>
        public string TechnologyDetailDescription { get; set; }

        /// <summary>
        /// Nombre candidato
        /// </summary>

        public string CandidateName { get; set; }

        /// <summary>
        /// Nombre de usuario del candidato
        /// </summary>

        public string UserName { get; set; }

        /// <summary>
        /// Correo del candidato
        /// </summary>

        public string CandidateEmail { get; set; }

        /// <summary>
        /// Direccion del candidato
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Suite del candidato
        /// </summary>
        public string Suite { get; set; }

        /// <summary>
        /// Ciudad del candidato
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Zip Code candidato
        /// </summary>

        public string ZipCode { get; set; }

        /// <summary>
        /// Geo Lat Candidato
        /// </summary>
        public string GeoLat { get; set; }

        /// <summary>
        /// Geo Ing Candidato
        /// </summary>

        public string GeoIng { get; set; }

        /// <summary>
        /// Telefono candidato
        /// </summary>

        public string Phone { get; set; }

        /// <summary>
        /// web Site candidato
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// Compañia del candidato
        /// </summary>
        public string CompanyName { get; set; }

        public string CompanyCatchPhrase { get; set; }

        public string CompanyBs { get; set; }
    }

    /// <summary>
    /// Utilidades para el candidato
    /// </summary>
    public static class CandidateUtil
    {
        /// <summary>
        /// Convierte el objeto de base de datos de entrevista al objeto modelo de la vista
        /// </summary>
        /// <param name="interview">entrevista</param>
        /// <returns></returns>
        public static InterviewViewModel InterViewToModelView(this Interview interview)
        {
            Candidate candidate = interview.Candidate;
            return new InterviewViewModel()
            {
                ZipCode = candidate.ZipCode,
                CandidateEmail = candidate.CandidateEmail,
                CandidateId = candidate.CandidateId,
                CandidateName = candidate.CandidateName,
                City = candidate.City,
                CompanyBs = candidate.CompanyBs,
                CompanyCatchPhrase = candidate.CompanyCatchPhrase,
                CompanyName = candidate.CompanyName,
                GeoIng = candidate.GeoIng,
                GeoLat = candidate.GeoLat,
                InterviewFinalTime = interview.InterviewFinalTime,
                InterviewId = interview.InterviewId,
                InterviewStartTime = interview.InterviewStartTime,
                Observation = interview.Observation,
                Phone = candidate.Phone,
                Street = candidate.Street,
                Suite = candidate.Suite,
                TechnologyDetailDescription = interview.TechnologyDetail.TechnologyDescription,
                TechnologyDetailId = interview.TechnologyDetailId,
                TypeInterviewId = interview.TypeInterviewId,
                UserName = candidate.UserName,
                Website = candidate.Website
            };
        }

        /// <summary>
        /// Mapea los datos de un InterviewModel aun Interview
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public static Interview ViewModelToInterView(this InterviewViewModel interview)
        {
            return new Interview()
            {
                Candidate = new Candidate()
                {
                    CandidateEmail = interview.CandidateEmail,
                    CandidateId = interview.CandidateId,
                    CandidateName = interview.CandidateName,
                    City = interview.City,
                    CompanyBs = interview.CompanyBs,
                    CompanyCatchPhrase = interview.CompanyCatchPhrase,
                    CompanyName = interview.CompanyName,
                    GeoIng = interview.GeoIng,
                    GeoLat = interview.GeoLat,
                    Phone = interview.Phone,
                    Street = interview.Street,
                    Suite = interview.Suite,
                    UserName = interview.UserName,
                    Website = interview.Website,
                    ZipCode = interview.ZipCode
                },
                CandidateId = interview.CandidateId,
                InterviewFinalTime = interview.InterviewFinalTime ?? DateTime.Now,
                InterviewId = interview.InterviewId,
                InterviewStartTime = interview.InterviewStartTime ?? DateTime.Now,
                Observation = interview.Observation,
                TechnologyDetailId = interview.TechnologyDetailId,
                InterviewType = new InterviewType(),
                TechnologyDetail = new TechnologyDetail(),
                TypeInterviewId = interview.TypeInterviewId
            };
        }
    }
}