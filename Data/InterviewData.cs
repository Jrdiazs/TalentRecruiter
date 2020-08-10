using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data
{
    /// <summary>
    /// Repositorio de datos para la tabla Interview
    /// </summary>
    public class InterviewData : RepositoryGeneric<Interview>, IInterviewData, IDisposable
    {
        public InterviewData() : base()
        {
        }

        /// <summary>
        /// Verifica si existe una entrevisa en el rango seleccionado
        /// </summary>
        /// <param name = "interview" > Interview </ param >
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        public bool ExisteInterview(Interview interview, IDbTransaction transaction = null)
        {
            try
            {
                if (interview.InterviewId > 0)
                {
                    Interview oldInterView = GetFindId(interview.InterviewId, transaction);
                    bool changeDates = interview.InterviewStartTime != oldInterView.InterviewStartTime || interview.InterviewFinalTime != oldInterView.InterviewFinalTime;
                    if (!changeDates) return false;

                    int count = Count("WHERE InterviewStartTime >= @startTime AND InterviewFinalTime <= @endTime AND InterviewId <> @id",
                        new
                        {
                            id = interview.InterviewId,
                            startTime = interview.InterviewStartTime,
                            endTime = interview.InterviewFinalTime
                        },
                        transaction);

                    return count > 0;
                }
                else
                {
                    //Consulta la maxima fecha del campo InterviewFinalTime
                    var datemax = MaxTimeFinalInterview(transaction: transaction);
                    if (datemax != null)
                    {
                        DateTime dateMax = (DateTime)datemax;

                        if (interview.InterviewStartTime <= dateMax)
                            return true;
                        else
                            return false;
                    }
                    else return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta la maxima fecha del campo InterviewFinalTime
        /// </summary>
        /// <param name="transaction">transaccion sql</param>
        /// <param name="nowValue">fecha actual</param>
        /// <returns></returns>
        public DateTime? MaxTimeFinalInterview(DateTime? nowValue = null, IDbTransaction transaction = null)
        {
            try
            {
                var queryMaxTime = "SELECT MAX(i.InterviewFinalTime) InterviewFinalTime FROM Interview i WHERE (CAST(i.InterviewFinalTime AS DATE) = CAST(@now AS DATE) OR @now IS NULL)";
                var datemax = Connection.ExecuteScalar(queryMaxTime, param: new { now = nowValue }, transaction: transaction, commandType: CommandType.Text);
                if (datemax == null) return null;
                return (DateTime?)datemax;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Actualiza los datos basicos de una entrevista
        /// </summary>
        /// <param name="interview">Interview</param>
        /// <param name="transaction">transaction</param>
        /// <returns></returns>
        public Interview UpdateInterView(Interview interview, IDbTransaction transaction = null)
        {
            try
            {
                Interview oldInterView = GetFindId(interview.InterviewId, transaction);

                oldInterView.InterviewFinalTime = interview.InterviewFinalTime;
                oldInterView.InterviewStartTime = interview.InterviewStartTime;
                oldInterView.Observation = interview.Observation;
                oldInterView.TechnologyDetailId = interview.TechnologyDetailId;
                oldInterView.DateUpdate = DateTime.Now;
                oldInterView.TypeInterviewId = interview.TypeInterviewId;

                Update(oldInterView, transaction);
                return oldInterView;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica si existe la entrevista por id
        /// </summary>
        /// <param name="interview">entrevista</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        public bool ExistInterviewFromById(Interview interview, IDbTransaction transaction = null)
        {
            try
            {
                int count = Count("WHERE InterviewId = @id", new { id = interview.InterviewId }, transaction);
                return count > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta las entrevistas segun el dia y el tipo de entrevistas
        /// </summary>
        /// <param name="interviewTime">fecha de entrevistas</param>
        /// <param name="typeInterview">tipo de entrevistas</param>
        /// <param name="interviewId">id de entrevista</param>
        /// <returns></returns>
        public List<Interview> GetInterviews(DateTime? interviewTime, int? typeInterview, int? interviewId, IDbTransaction transaction = null)
        {
            try
            {
                var query = new List<Interview>();

                query = Connection.Query<Interview, Candidate, InterviewType, TechnologyDetail, Technology, Interview>(
                    sql: "TalentRecruiter_InterviewSearch",
                    map: (i, c, it, td, t) =>
                    {
                        i.Candidate = c; i.InterviewType = it; i.TechnologyDetail = td;
                        td.Technology = t;
                        return i;
                    },
                    param: new { InterviewTime = interviewTime, TypeInterviewId = typeInterview, InterviewId = interviewId },
                    splitOn: "split", commandType:
                    CommandType.StoredProcedure,
                    transaction: transaction).ToList();

                return query ?? new List<Interview>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta la informacion completa de una entrevista por ida
        /// </summary>
        /// <param name="interviewId">entrevista id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        public Interview GetCompleteInfoInterViewFromById(int interviewId, IDbTransaction transaction = null)
        {
            try
            {
                var query = GetInterviews(null, null, interviewId, transaction);
                return query.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Repositorio de datos para la tabla Interview
    /// </summary>
    public interface IInterviewData : IRepositoryGeneric<Interview>, IDisposable
    {
        /// <summary>
        /// Verifica si existe una entrevisa en el rango seleccionado
        /// </summary>
        /// <param name="interview">Interview</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        bool ExisteInterview(Interview interview, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta las entrevistas segun el dia y el tipo de entrevistas
        /// </summary>
        /// <param name="interviewTime">fecha de entrevistas</param>
        /// <param name="typeInterview">tipo de entrevistas</param>
        /// <param name="interviewId">id de entrevista</param>
        /// <returns></returns>
        List<Interview> GetInterviews(DateTime? interviewTime, int? typeInterview, int? interviewId, IDbTransaction transaction = null);

        /// <summary>
        /// Verifica si existe la entrevista por id
        /// </summary>
        /// <param name="interview">entrevista</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        bool ExistInterviewFromById(Interview interview, IDbTransaction transaction = null);

        /// <summary>
        /// Actualiza los datos basicos de una entrevista
        /// </summary>
        /// <param name="interview">Interview</param>
        /// <param name="transaction">transaction</param>
        /// <returns></returns>
        Interview UpdateInterView(Interview interview, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta la informacion completa de una entrevista por id
        /// </summary>
        /// <param name="interviewId">entrevista id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        Interview GetCompleteInfoInterViewFromById(int interviewId, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta la maxima fecha del campo InterviewFinalTime
        /// </summary>
        /// <param name="nowValue">fecha actual</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        DateTime? MaxTimeFinalInterview(DateTime? nowValue = null, IDbTransaction transaction = null);
    }
}