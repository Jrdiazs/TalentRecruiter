using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data
{
    /// <summary>
    /// Repositorio para la tabla TechnologyDetail
    /// </summary>
    public class TechnologyDetailData : RepositoryGeneric<TechnologyDetail>, ITechnologyDetailData, IDisposable
    {
        public TechnologyDetailData() : base()
        {
        }

        /// <summary>
        /// Obtiene las categorias por tecnologia id
        /// </summary>
        /// <param name="technologyId">id tecnologia java o .net</param>
        /// <returns></returns>

        public List<TechnologyDetail> GetTechnologiesFromByTechnologyId(int technologyId)
        {
            try
            {
                var query = new List<TechnologyDetail>();
                query = GetList("WHERE TechnologyId = @technology", new { technology = technologyId });
                return query;
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
                var query = Connection.Query<TechnologyDetail, Technology, TechnologyDetail>
                    (sql: "TalentRecruiter_TechnologyDetailFromById",
                    map: (td, t) => { td.Technology = t; return td; },
                    splitOn: "split",
                    commandType: CommandType.StoredProcedure,
                    param: new { TechnologyDetailId = technologyDetailId }).ToList();

                query = query ?? new List<TechnologyDetail>();
                return query.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Repositorio para la tabla TechnologyDetail
    /// </summary>
    public interface ITechnologyDetailData : IRepositoryGeneric<TechnologyDetail>, IDisposable
    {
        /// <summary>
        /// Obtiene las categorias por tecnologia id
        /// </summary>
        /// <param name="technologyId">id tecnologia java o .net</param>
        /// <returns></returns>
        List<TechnologyDetail> GetTechnologiesFromByTechnologyId(int technologyId);

        /// <summary>
        /// Consulta una tecnologia detalle por id
        /// </summary>
        /// <param name="technologyDetailId">tecnologia detalle por id</param>
        /// <returns></returns>
        TechnologyDetail GetTechnologyDetailFromById(int technologyDetailId);
    }
}