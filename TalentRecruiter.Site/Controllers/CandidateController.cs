using DataTables.Mvc;
using Services;
using System;
using System.Web.Hosting;
using System.Web.Mvc;
using TalentRecruiter.Site.Models;

namespace TalentRecruiter.Site.Controllers
{
    /// <summary>
    /// Controlador para consultar candidatos
    /// </summary>
    [RoutePrefix("Candidate")]
    public class CandidateController : Controller
    {
        /// <summary>
        /// Servicio para candidatos
        /// </summary>
        private readonly ICandidateServices _services;

        public CandidateController(ICandidateServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <summary>
        /// Crea la vista inicial de candidatos con la tecnologia seleccionada en la vista TechnologyDetail
        /// </summary>
        /// <param name="technologyOrderId">Identificador de la tecnologia par o impar</param>
        /// <param name="technologyId">tecnologia seleccionada en la vista Technology</param>
        /// <param name="technologyDetailId">Id detalle de tecnologia seleccionada en la vista TechnologyDetail</param>
        /// <param name="technologyDetailDescription">Descripcion de la tecnologia seleccionada en la vista TechnologyDetail</param>
        /// <returns></returns>
        public ActionResult Index(int? technologyOrderId = null, int? technologyId = null, int? technologyDetailId = null, string technologyDetailDescription = null)
        {
            var model = new TechnologyDetailViewModel()
            {
                TechnologyOrderId = technologyOrderId ?? 0,
                TechnologyDetailId = technologyDetailId ?? 0,
                TechnologyId = technologyId ?? 0,
                TechnologyDetailDescription = technologyDetailDescription
            };

            return View(model);
        }

        /// <summary>
        /// Consulta la lista de candidatos del web services http://jsonplaceholder.typicode.com segun el identificador de la tecnologia
        /// par o numero impar
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("GetCandidatesFromByTechnology")]
        [HttpPost]
        public ActionResult GetCandidatesFromByTechnology([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, TechnologyDetailViewModel model)
        {
            try
            {
                int tecnology = model.TechnologyOrderId;
                string pathJson = HostingEnvironment.MapPath("~/json.data.js");
                var candidates = _services.GetCandidatesApiFromByTechnology(tecnology, pathJson);
                int count = candidates.Count;
                return Json(new DataTablesResponse(requestModel.Draw, candidates, count, count), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}