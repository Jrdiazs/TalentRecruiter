using Models;
using System;

namespace Data
{
    /// <summary>
    /// Repositorio para la tabla InterviewType
    /// </summary>
    public class InterviewTypeData : RepositoryGeneric<InterviewType>, IInterviewTypeData, IDisposable
    {
        public InterviewTypeData() : base()
        {
        }
    }

    /// <summary>
    /// Repositorio para la tabla InterviewType
    /// </summary>
    public interface IInterviewTypeData : IRepositoryGeneric<InterviewType>, IDisposable { }
}