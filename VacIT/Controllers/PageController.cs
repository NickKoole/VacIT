using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VacIT.Cruds;
using VacIT.Models;

namespace VacIT.Controllers
{
    public class PageController : Controller
    {
        private readonly ILogger<PageController> _logger;
        private CandidateApplicationCrud CandidateApplicationCrud;

        public PageController(ILogger<PageController> logger)
        {
            _logger = logger;
            CandidateApplicationCrud = new CandidateApplicationCrud();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sollicitaties()
        {
            CandidateApplication candidateApplication = new CandidateApplication();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
