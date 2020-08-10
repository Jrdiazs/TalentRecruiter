using Services;
using System;
using System.Web.Mvc;

namespace TalentRecruiter.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITechnologyServices _services;

        public HomeController(ITechnologyServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public ActionResult Index()
        {
            try
            {
                var tecnologies = _services.GetTechnologies();
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}