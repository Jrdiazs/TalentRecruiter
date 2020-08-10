using Data;
using Ninject.Modules;

namespace Services
{
    /// <summary>
    /// Contenedor repositorios y servicios
    /// </summary>
    public class ContainerRecruiter : NinjectModule
    {
        public override void Load()
        {
            ///Repositorios
            Bind<ICandidateData>().To<CandidateData>();
            Bind<ITechnologyData>().To<TechnologyData>();
            Bind<ITechnologyDetailData>().To<TechnologyDetailData>();
            Bind<IInterviewData>().To<InterviewData>();
            Bind<IInterviewTypeData>().To<InterviewTypeData>();

            ///Servicios
            Bind<ICandidateServices>().To<CandidateServices>();
            Bind<IInterViewServices>().To<InterViewServices>();
            Bind<ITechnologyServices>().To<TechnologyServices>();
        }
    }
}