﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using VacIT.Cruds;

namespace VacIT.Models
{
    public class VacITPageModel : IVacITPageModel
    {
        private IVacITCrud _vacITCrud;
        private UserManager<VacITUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public List<CandidateApplication> _candidateApplications { get; set; }
        public CandidateApplication _candidateApplication { get; set; }
        public List<JobOffer> _jobOffers { get; set; }
        public JobOffer _jobOffer { get; set; }
        public VacITEmployer _vacITEmployer { get; set; }

        public VacITPageModel(IVacITCrud crud, UserManager<VacITUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _vacITCrud = crud;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public void GetCandidateApplicationList()
        {
            var tempUserId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            int userId = int.Parse(tempUserId);
            _candidateApplications = _vacITCrud.ReadCandidateApplicationsByCandidateId(userId);
        }

        public void GetCurrentEmployer()
        {
            _vacITEmployer = (VacITEmployer)_userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
        }

        public void GetJobOfferById(int id)
        {
            _jobOffer = _vacITCrud.ReadJobOffer(id);
        }

        public void GetJobOffers()
        {
            _jobOffers = _vacITCrud.ReadAllJobOffers();
        }
        public void GetJobOffersByUserId()
        {
            var tempUserId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            int userId = int.Parse(tempUserId);
            _jobOffers = _vacITCrud.ReadJobOffersByEmployerId(userId);
        }

        public void UpdateJobOffer(JobOffer jobOffer)
        {
            _vacITCrud.UpdateJobOffer(jobOffer);
        }
    }
}
