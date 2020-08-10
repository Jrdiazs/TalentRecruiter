using Models;
using System;

namespace Data
{
    /// <summary>
    /// Repositorio para la tabla Technology
    /// </summary>
    public class TechnologyData : RepositoryGeneric<Technology>, ITechnologyData, IDisposable
    {
        public TechnologyData() : base()
        {
        }
    }

    /// <summary>
    /// Repositorio para la tabla Technology
    /// </summary>
    public interface ITechnologyData : IRepositoryGeneric<Technology>, IDisposable
    {
    }
}