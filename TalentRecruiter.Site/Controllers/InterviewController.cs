using DataTables.Mvc;
using Models;
using Services;
using System;
using System.Web.Mvc;
using TalentRecruiter.Site.Filters;
using TalentRecruiter.Site.Models;

namespace TalentRecruiter.Site.Controllers
{
    /// <summary>
    /// Controlador Interview
    /// </summary>
    [RoutePrefix("Interview")]
    public class InterviewController : Controller
    {
        /// <summary>
        /// Objeto de servicios
        /// </summary>
        private readonly IInterViewServices _services;

        /// <summary>
        /// Instancia un nuevo controlador Interview con el objeto de servicios
        /// </summary>
        /// <param name="services"></param>
        public InterviewController(IInterViewServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <summary>
        /// Inicializa la vista de Interview
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="technoloyDetailId"></param>
        /// <param name="technologyDescription"></param>
        /// <returns></returns>
        public ActionResult Index(string ids = null, int? technoloyDetailId = null, string technologyDescription = null)
        {
            var model = new SelectedCandidatesViewModel()
            {
                CandidatesIds = ids,
                TechnologyDetailId = technoloyDetailId ?? 0,
                TechnologyDescription = technologyDescription
            };

            return View(model);
        }

        /// <summary>
        /// Vista para busqueda de entrevistas
        /// </summary>
        /// <returns></returns>
        public ActionResult Search()
        {
            var model = new SearchInterviewViewModel() { };
            return View(model);
        }

        /// <summary>
        /// Consulta los tipos de entrevistas para cargar en el combo tipo de entrevistas
        /// </summary>
        /// <returns></returns>
        [Route("GetInterviewTypes")]
        [HttpGet]
        public ActionResult GetInterviewTypes()
        {
            try
            {
                var typeInterview = _services.GetInterviewTypes();
                return Json(typeInterview, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta la fecha maxima de final de entrevista y si encuentra alguna le agrega un minutos
        /// </summary>
        /// <returns></returns>
        [Route("MaxTimeFinalInterview")]
        [HttpPost]
        public ActionResult MaxTimeFinalInterview()
        {
            try
            {
                var dateMaxFinalInterView = _services.MaxTimeFinalInterview();
                if (dateMaxFinalInterView.HasValue)
                    dateMaxFinalInterView = dateMaxFinalInterView.Value.AddMinutes(1);

                return Json(dateMaxFinalInterView, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Guarda la entrevista en base de datos
        /// </summary>
        /// <param name="interviewModel"></param>
        /// <returns></returns>
        [ErrorHanlder]
        [Route("SaveInterView")]
        [HttpPost]
        public ActionResult SaveInterView(InterviewViewModel interviewModel)
        {
            ResponseData response = new ResponseData()
            {
                Succes = false
            };
            try
            {
                Interview interview = interviewModel.ViewModelToInterView();
                interview = _services.CreateInterview(interview);
                response.Succes = true;
                response.Value = interview.InterViewToModelView();
                response.MessageInfo = "Entrevista guardada correctamente";
            }
            catch (ValidModelException ex)
            {
                response.Succes = false;
                response.MessageInfo = ex.Message;
            }
            catch (Exception ex)
            {
                response.Succes = false;
                response.MessageInfo = ex.Message;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Consulta las entrevistas por fecha y por tipo de entrevista
        /// </summary>
        /// <param name="interviewModel"></param>
        /// <returns></returns>
        [Route("SearchInterView")]
        [HttpPost]
        public ActionResult SearchInterView([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, SearchInterviewViewModel searchInterviewViewModel)
        {
            try
            {
                var interView = _services.GetInterviews(searchInterviewViewModel.DateInterView, searchInterviewViewModel.TypeInterViewId);
                int count = interView.Count;
                return Json(new DataTablesResponse(requestModel.Draw, interView, count, count), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}