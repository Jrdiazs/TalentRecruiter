using DataTables.Mvc;
using Services;
using System;
using System.Web.Mvc;
using TalentRecruiter.Site.Models;

namespace TalentRecruiter.Site.Controllers
{
    /// <summary>
    /// Controlador TechnologyDetail
    /// </summary>
    [RoutePrefix("TechnologyDetail")]
    public class TechnologyDetailController : Controller
    {
        /// <summary>
        /// Servicios para el repositorio TechnologyDetail
        /// </summary>
        private readonly ITechnologyServices _services;

        /// <summary>
        /// Inicia el controlador con el objeto de servicios
        /// </summary>
        /// <param name="services"></param>
        public TechnologyDetailController(ITechnologyServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <summary>
        /// Vista inicial de tecnologia detalle
        /// </summary>
        /// <param name="technologyId">tecnologia id seleccionada</param>
        /// <param name="technologyDescription">tecnologia descripcion</param>
        /// <returns></returns>
        public ActionResult Index(int? technologyId = null, string technologyDescription = null)
        {
            var model = new TechnologyDetailViewModel()
            {
                TechnologyId = technologyId ?? 0,
                TechnologyDescription = technologyDescription,
                TechnologyDetailDescription = string.Empty,
                TechnologyDetailId = 0,
                TechnologyOrderId = 0
            };
            return View(model);
        }

        /// <summary>
        /// Consulta para cargar el grid de detalle de tecnologias
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("GetTechnologiesFromByTechnologyId")]
        [HttpGet]
        public ActionResult GetTechnologiesFromByTechnologyId([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, TechnologyDetailViewModel model)
        {
            try
            {
                //Tecnologia seleccionada
                int technologyId = model.TechnologyId;
                ///Consulta las tecnologias segun el id de tecnologia selecciado
                var technologies = _services.GetTechnologiesFromByTechnologyId(technologyId);
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