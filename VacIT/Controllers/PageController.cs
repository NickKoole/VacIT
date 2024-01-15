using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Diagnostics;
using VacIT.Cruds;
using VacIT.Models;

namespace VacIT.Controllers
{
    public class PageController : Controller
    {
        private readonly ILogger<PageController> _logger;
        private IVacITPageModel _vacITPageModel;

        public PageController(ILogger<PageController> logger, IVacITPageModel pageModel)
        {
            _logger = logger;
            _vacITPageModel = pageModel;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public IActionResult DeleteVacature(int id)
        {
            _vacITPageModel.DeleteJobOffer(id);
            return RedirectToAction("MijnVacatures");
        }

        [Authorize(Roles = "Employer")]
        public IActionResult EditVacature(int id)
        {
            _vacITPageModel.GetJobOfferById(id);
            return View(_vacITPageModel._jobOffer);
        }

        [HttpPost]
        [Authorize(Roles = "Employer")]
        public IActionResult EditVacature(JobOffer jobOffer)
        {
            _vacITPageModel.GetCurrentEmployer();
            jobOffer.VacITEmployer = _vacITPageModel._vacITEmployer;

            //De error omtrent de VacITEmployer wordt eruit gehaald door middel van de onderstaande regel, deze error is irrelevant nu VacITEmployer hierboven in het object wordt gezet
            ModelState.Remove(nameof(JobOffer.VacITEmployer));

            if (ModelState.IsValid)
            {
                _vacITPageModel.UpdateJobOffer(jobOffer);
                return RedirectToAction("Vacature", new { id = jobOffer.Id });
            }
            return View(jobOffer);
        }

        [Authorize(Roles = "Candidate")]
        public IActionResult MijnSollicitaties()
        {
            _vacITPageModel.GetCandidateApplicationList();
            return View(_vacITPageModel);
        }

        [Authorize(Roles = "Employer")]
        public IActionResult MijnVacatures()
        {
            _vacITPageModel.GetJobOffersByUserId();
            return View(_vacITPageModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Vacature(int id)
        {
            _vacITPageModel.GetJobOfferById(id);
            return View(_vacITPageModel);
        }

        public IActionResult Vacatures()
        {
            _vacITPageModel.GetJobOffers();
            return View(_vacITPageModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
