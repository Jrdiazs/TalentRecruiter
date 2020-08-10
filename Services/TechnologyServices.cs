using Data;
using Models;
using System;
using System.Collections.Generic;

namespace Services
{
    /// <summary>
    /// Servicio para repositorios Technology  y TechnologyDetail
    /// </summary>
    public class TechnologyServices : IDisposable, ITechnologyServices
    {
        private readonly ITechnologyData _technologyData;
        private readonly ITechnologyDetailData _technologyDetailData;
        private bool disposedValue;

        /// <summary>
        /// Instancia la clase de servicios TechnologyServices con los repositorios necesarios para ITechnologyData y ITechnologyDetailData
        /// </summary>
        /// <param name="technologyData">repositorios ITechnologyData </param>
        /// <param name="technologyDetailData">repositorio ITechnologyDetailData</param>
        public TechnologyServices(ITechnologyData technologyData, ITechnologyDetailData technologyDetailData)
        {
            _technologyData = technologyData ?? throw new ArgumentNullException(nameof(technologyData));
            _technologyDetailData = technologyDetailData ?? throw new ArgumentNullException(nameof(technologyDetailData));
        }

        /// <summary>
        /// Consulta todas las tecnologias
        /// </summary>
        /// <returns></returns>
        public List<Technology> GetTechnologies()
        {
            try
            {
                return _technologyData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta las tecnologias detalle por id de tecnologia
        /// </summary>
        /// <param name="technologyId">tecnologia id</param>
        /// <returns></returns>
        public List<TechnologyDetail> GetTechnologiesFromByTechnologyId(int technologyId)
        {
            try
            {
                return _technologyDetailData.GetTechnologiesFromByTechnologyId(technologyId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta una tecnologia detalle por id
        /// </summary>
        /// <param name="technologyDetailId">tecnologia detalle por id</param>
        /// <returns></returns>
        public TechnologyDetail GetTechnologyDetailFromById(int technologyDetailId)
        {
            try
            {
                return _technologyDetailData.GetTechnologyDetailFromById(technologyDetailId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta la tecnologia por id
        /// </summary>
        /// <param name="technologyId"></param>
        /// <returns></returns>
        public Technology GetTechnologyFromById(int technologyId)
        {
            try
            {
                return _technologyData.GetFindId(technologyId);
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
                    if (_technologyData != null)
                        _technologyData.Dispose();

                    if (_technologyDetailData != null)
                        _technologyDetailData.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~TecnologyServices()
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
    /// Servicio para repositorios Tecnology y TecnologyDetail
    /// </summary>
    public interface ITechnologyServices : IDisposable
    {
        /// <summary>
        /// Consulta todas las tecnologias
        /// </summary>
        /// <returns></returns>
        List<Technology> GetTechnologies();

        /// <summary>
        /// Consulta las tecnologias detalle por id de tecnologia
        /// </summary>
        /// <param name="technologyId">tecnologia id</param>
        /// <returns></returns>
        List<TechnologyDetail> GetTechnologiesFromByTechnologyId(int technologyId);

        /// <summary>
        /// Consulta una tecnologia detalle por id
        /// </summary>
        /// <param name="technologyDetailId">tecnologia detalle por id</param>
        /// <returns></returns>
        TechnologyDetail GetTechnologyDetailFromById(int technologyDetailId);

        /// <summary>
        /// Consulta la tecnologia por id
        /// </summary>
        /// <param name="technologyId"></param>
        /// <returns></returns>
        Technology GetTechnologyFromById(int technologyId);
    }
}