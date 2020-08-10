using AutoMapper;
using Models;

namespace TalentRecruiter.Site
{
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Registra los mapeos del sitio
        /// </summary>
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
                x.CreateMap<CandidateResponse, Candidate>()
            );
        }
    }
}