using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VacIT.Cruds;
using VacIT.Models;

namespace VacIT.Controllers
{
    public class PageController : Controller
    {
        private readonly ILogger<PageController> _logger;
        private VacITPageModel _vacITPageModel;

        public PageController(ILogger<PageController> logger, VacITContext context, UserManager<VacITUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            VacITCrud vacITCrud = new VacITCrud(context);
            _vacITPageModel = new VacITPageModel(vacITCrud, userManager, httpContextAccessor);
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Candidate")]
        public IActionResult MijnSollicitaties()
        {
            _vacITPageModel.setCandidateApplicationList();
            return View();
        }

        [Authorize(Roles = "Admin, Employer")]
        public IActionResult MijnVacatures()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Vacatures()
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
