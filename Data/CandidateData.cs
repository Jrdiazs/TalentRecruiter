using Models;
using System;
using System.Data;

namespace Data
{
    /// <summary>
    /// Repositorio para la tabla candidato
    /// </summary>
    public class CandidateData : RepositoryGeneric<Candidate>, ICandidateData, IDisposable
    {
        public CandidateData() : base()
        {
        }

        /// <summary>
        /// Verifica si existe un candidato por id
        /// </summary>
        /// <param name="candidate">candidato</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>

        public bool ExistCandidate(Candidate candidate, IDbTransaction transaction = null)
        {
            try
            {
                int count = Count("where CandidateId = @id", new { id = candidate.CandidateId }, transaction);
                return count > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Repositorio para la tabla candidato
    /// </summary>
    public interface ICandidateData : IRepositoryGeneric<Candidate>, IDisposable
    {
        /// <summary>
        /// Verifica si existe un candidato por id
        /// </summary>
        /// <param name="candidate">candidato</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        bool ExistCandidate(Candidate candidate, IDbTransaction transaction = null);
    }
}