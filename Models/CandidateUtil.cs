using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Models.CandidateUtil
{
    public static class CandidateUtil
    {
        /// <summary>
        /// Convierte un CandidateResponse a un Candidate
        /// </summary>
        /// <param name="candidateResponse">CandidateResponse</param>
        /// <returns></returns>
        public static Candidate CandidateResponseToCandidate(this CandidateResponse candidateResponse)
        {
            try
            {
                return Mapping.ConverModelTo<CandidateResponse, Candidate>(candidateResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Convierte un List CandidateResponse a un List Candidate
        /// </summary>
        /// <param name="candidateResponse">List CandidateResponse</param>
        /// <returns>List To CandidateResponse</returns>
        public static List<Candidate> CandidateResponseToCandidate(this List<CandidateResponse> candidateResponse)
        {
            try
            {
                var query = candidateResponse.Select(x => CandidateResponseToCandidate(x)).ToList() ?? new List<Candidate>();
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}