using RecruitmentTask.Services.Interfaces;
using RecruitmentTask.ViewModels;
using System.Web.Mvc;

namespace RecruitmentTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult GetReports()
        {
            var response = _homeService.GetReports(null);
            return PartialView("~/Views/Home/Reports.cshtml", response);
        }

        public ActionResult GetFilteredReports(ReportViewModelRequest request)
        {
            var response = _homeService.GetReports(request);
            return PartialView("~/Views/Home/Reports.cshtml", response);
        }
    }
}