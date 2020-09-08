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
        public ActionResult GetRaports()
        {
            var response = _homeService.GetRaports(null);
            return PartialView("~/Views/Home/Raports.cshtml", response);
        }
        public ActionResult GetFilteredRecords(RaportViewModelRequest request)
        {
            var response = _homeService.GetRaports(request);
            return PartialView("~/Views/Home/Raports.cshtml", response);
        }
    }
}