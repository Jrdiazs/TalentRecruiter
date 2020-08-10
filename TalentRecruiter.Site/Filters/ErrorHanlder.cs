using System.Web.Mvc;

namespace TalentRecruiter.Site.Filters
{
    /// <summary>
    /// Filtro para errores en ajax
    /// </summary>
    public class ErrorHanlder : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new JsonResult
            {
                Data = new { success = false, error = filterContext.Exception.ToString() },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}