using Data;
using Models;
using System;
using System.Collections.Generic;

namespace Services
{
    /// <summary>
    /// Servicios para el repositorio IInterviewData,ICandidateData,IInterviewTypeData
    /// </summary>
    public class InterViewServices : IInterViewServices, IDisposable
    {
        /// <summary>
        /// Repositorio para candidatos
        /// </summary>
        private readonly ICandidateData _candidateData;

        /// <summary>
        /// Repositorio para entrevistas
        /// </summary>
        private readonly IInterviewData _interviewData;

        /// <summary>
        /// Repositorios para tipos de entrevistas
        /// </summary>
        private readonly IInterviewTypeData _interviewTypeData;

        private bool disposedValue;

        /// <summary>
        /// Crea una nueva instancia del servicio InterViewServices con los repositorios necesarios para la creacion de entrevistas
        /// ICandidateData,IInterviewData,IInterviewTypeData
        /// </summary>
        /// <param name="candidateData">ICandidateData</param>
        /// <param name="interviewData">IInterviewData</param>
        /// <param name="interviewTypeData">IInterviewTypeData</param>
        public InterViewServices(ICandidateData candidateData, IInterviewData interviewData, IInterviewTypeData interviewTypeData)
        {
            _candidateData = candidateData ?? throw new ArgumentNullException(nameof(candidateData));
            _interviewData = interviewData ?? throw new ArgumentNullException(nameof(interviewData));
            _interviewTypeData = interviewTypeData ?? throw new ArgumentNullException(nameof(interviewTypeData));
        }

        /// <summary>
        /// Crea una nueva entrevista para el candidato
        /// </summary>
        /// <param name="interview">Interview</param>
        /// <returns>Interview</returns>
        public Interview CreateInterview(Interview interview)
        {
            try
            {
                if (interview.InterviewFinalTime <= interview.InterviewStartTime)
                    throw new ValidModelException($"La fecha final de entrevista debe ser mayor que la fecha inicial");

                if (interview.InterviewFinalTime.Date != interview.InterviewStartTime.Date)
                    throw new ValidModelException($"La entrevista tiene que realizarse en el mismo día");

                if (interview.InterviewId == 0)
                {
                    if (interview.InterviewStartTime.Date < DateTime.Now.Date)
                        throw new ValidModelException($"No puede crear entrevistas para dias pasados");
                }

                _interviewData.Connection = _candidateData.Connection;

                Candidate candidate = interview.Candidate;

                using (var connection = _candidateData.Connection)
                {
                    connection.Open();
                    using (var transact = _candidateData.Connection.BeginTransaction())
                    {
                        try
                        {
                            ///verifica si existe una entrevista en este rango
                            if (_interviewData.ExisteInterview(interview, transact))
                                throw new ValidModelException($"Ya existe una entrevista para esta hora  entre {interview.InterviewStartTime} y {interview.InterviewFinalTime}");

                            ///Si no existe el candidato lo crea si no modifica sus datos
                            if (!_candidateData.ExistCandidate(candidate, transact))
                                _candidateData.Insert<int>(candidate, transact);
                            else
                                _candidateData.Update(candidate, transact);

                            //fecha de creacion
                            interview.DateCreation = DateTime.Now;
                            ///Si ya existe la entrevista la modifica si no la crea
                            int interviewId = 0;
                            if (!_interviewData.ExistInterviewFromById(interview, transact))
                            {
                                interviewId = _interviewData.Insert<int>(interview, transact);
                                interview = _interviewData.GetCompleteInfoInterViewFromById(interviewId, transact);
                            }
                            else
                            {
                                interview = _interviewData.UpdateInterView(interview, transact);
                                interview = _interviewData.GetCompleteInfoInterViewFromById(interview.InterviewId, transact);
                            }

                            //Transaccion comit

                            transact.Commit();
                        }
                        catch (Exception)
                        {
                            transact.Rollback();
                            throw;
                        }
                    }
                }

                return interview;
            }
            catch (ValidModelException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta todos los tipo de entrevistas
        /// </summary>
        /// <returns></returns>
        public List<InterviewType> GetInterviewTypes()
        {
            try
            {
                return _interviewTypeData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta la maxima fecha del campo InterviewFinalTime
        /// </summary>
        /// <returns></returns>
        public DateTime? MaxTimeFinalInterview()
        {
            try
            {
                return _interviewData.MaxTimeFinalInterview();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta las entrevistas realizadas por fecha y por tipo de entrevista
        /// </summary>
        /// <param name="interviewTime">fecha de entrevista</param>
        /// <param name="typeInterview">tipo de entrevista</param>
        /// <returns></returns>
        public List<Interview> GetInterviews(DateTime? interviewTime, int? typeInterview)
        {
            try
            {
                return _interviewData.GetInterviews(interviewTime, typeInterview, null, null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region [Dispose]

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (_candidateData != null)
                        _candidateData.Dispose();

                    if (_interviewData != null)
                        _interviewData.Dispose();

                    if (_interviewTypeData != null)
                        _interviewTypeData.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CandidateServices()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion [Dispose]
    }

    /// <summary>
    /// Servicios para el repositorio IInterviewData,ICandidateData,IInterviewTypeData
    /// </summary>
    public interface IInterViewServices : IDisposable
    {
        /// <summary>
        /// Crea una nueva entrevista con el candidato seleccionado
        /// </summary>
        /// <param name="interview">Interview</param>
        /// <returns>Interview</returns>
        Interview CreateInterview(Interview interview);

        /// <summary>
        /// Consulta todos los tipo de entrevistas
        /// </summary>
        /// <returns></returns>
        List<InterviewType> GetInterviewTypes();

        /// <summary>
        /// Consulta la maxima fecha del campo InterviewFinalTime
        /// </summary>
        /// <returns></returns>

        DateTime? MaxTimeFinalInterview();

        /// <summary>
        /// Consulta las entrevistas realizadas por fecha y por tipo de entrevista
        /// </summary>
        /// <param name="interviewTime">fecha de entrevista</param>
        /// <param name="typeInterview">tipo de entrevista</param>
        /// <returns></returns>
        List<Interview> GetInterviews(DateTime? interviewTime, int? typeInterview);
    }
}