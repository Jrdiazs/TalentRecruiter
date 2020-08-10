using Models;
using Models.CandidateUtil;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tools;
using Tools.String;

namespace Services
{
    /// <summary>
    /// Servicio para el repositorio de Candidate
    /// </summary>
    public class CandidateServices : ICandidateServices, IDisposable
    {
        private bool disposedValue;

        /// <summary>
        /// Obtiene el listado de candidatos del api http://jsonplaceholder.typicode.com segun la tecnologia seleccionado si es numero par o impar
        /// </summary>
        /// <param name="tecnolgySelect"></param>
        /// <param name="pathJson">recurso json</param>
        /// <returns>List Candidate</returns>
        public List<Candidate> GetCandidatesApiFromByTechnology(int tecnolgySelect, string pathJson = null)
        {
            try
            {
                if (tecnolgySelect <= 0)
                    return new List<Candidate>();

                bool esPar = tecnolgySelect % 2 == 0;
                var query = new List<CandidateResponse>();

                RestClient client = new RestClient()
                {
                    BaseUrl = new Uri("UrlServicesCandidates".ReadAppConfig())
                };

                RestRequest request = new RestRequest()
                {
                    RequestFormat = DataFormat.Json,
                    Method = Method.GET,
                    Resource = "/users"
                };

                var response = client.Execute(request);

                //si la respuesta del api es fallida carga el recurso del archivo json.data.js
                if (!response.IsSuccessful)
                    query = Mapping.DeserializeJson<List<CandidateResponse>>(File.ReadAllText(pathJson));
                else
                    query = Mapping.DeserializeJson<List<CandidateResponse>>(response.Content);

                query = esPar ? query.Where(x => x.CandidateId % 2 == 0).ToList() : query.Where(x => x.CandidateId % 2 != 0).ToList();

                List<Candidate> candidates = query.CandidateResponseToCandidate();

                return candidates;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta los candidatos por id
        /// </summary>
        /// <param name="candidatesIds">candidatos por id</param>
        /// <returns></returns>
        public List<Candidate> GetCandidatesApiFromById(List<int> candidatesIds)
        {
            try
            {
                var query = new List<CandidateResponse>();

                RestClient client = new RestClient()
                {
                    BaseUrl = new Uri("UrlServicesCandidates".ReadAppConfig())
                };

                RestRequest request = new RestRequest()
                {
                    RequestFormat = DataFormat.Json,
                    Method = Method.GET,
                    Resource = "/users"
                };

                var response = client.Execute(request);
                query = Mapping.DeserializeJson<List<CandidateResponse>>(response.Content);

                query = query.Where(x => candidatesIds.Contains(x.CandidateId)).ToList();

                List<Candidate> candidates = query.CandidateResponseToCandidate();

                return candidates;
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
    /// Servicio para el repositorio de Candidate
    /// </summary>
    public interface ICandidateServices : IDisposable
    {
        /// <summary>
        /// Obtiene el listado de candidatos del api http://jsonplaceholder.typicode.com segun la tecnologia seleccionado si es numero par o impar,
        /// si la url no responde obtiene el json del path del sitio guardado en json.data.js
        /// </summary>
        /// <param name="tecnolgySelect">numero par o impar de la tecnologia</param>
        /// <param name="pathJson">recurso json</param>
        /// <returns>List Candidate</returns>
        List<Candidate> GetCandidatesApiFromByTechnology(int tecnolgySelect, string pathJson = null);

        /// <summary>
        /// Consulta los candidatos por id
        /// </summary>
        /// <param name="candidatesIds">candidatos por id</param>
        /// <returns></returns>
        List<Candidate> GetCandidatesApiFromById(List<int> candidatesIds);
    }
}