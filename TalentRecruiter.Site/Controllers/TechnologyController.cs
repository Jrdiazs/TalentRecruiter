using DataTables.Mvc;
using Services;
using System;
using System.Web.Mvc;

namespace TalentRecruiter.Site.Controllers
{
    /// <summary>
    /// Controlador inicial inicial
    /// </summary>
    [RoutePrefix("Technology")]
    public class TechnologyController : Controller
    {
        /// <summary>
        /// Servicio para Technology ITecnologyServices
        /// </summary>
        private readonly ITechnologyServices _services;

        /// <summary>
        /// Controlador para Technology
        /// </summary>
        /// <param name="services">Servicio ITecnologyServices</param>
        public TechnologyController(ITechnologyServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <summary>
        /// Vista sin modelo para tecnlogia
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Consulta todas las tecnologias y las muestra en la tabla datatable
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [Route("GetTechnologies")]
        [HttpGet]
        public ActionResult GetTechnologies([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            try
            {
                var technologies = _services.GetTechnologies();
                int count = technologies.Count;
                return Json(new DataTablesResponse(requestModel.Draw, technologies, count, count), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}