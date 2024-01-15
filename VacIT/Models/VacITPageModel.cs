using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using VacIT.Cruds;

namespace VacIT.Models
{
    public class VacITPageModel : IVacITPageModel
    {
        private readonly IVacITCrud _vacITCrud;
        private readonly UserManager<VacITUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DateOnly _currentDate { get; set; }
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

        public void CreateJobOffer(JobOffer jobOffer)
        {
            int id = _vacITCrud.CreateJobOffer(jobOffer);
            
            if (id != -1)
            {
                GetJobOfferById(id);
            }
        }

        public void DeleteJobOffer(int id)
        {
            _vacITCrud.DeleteJobOffer(id);
        }

        public void GetCandidateApplicationsByJobOfferId(int id)
        {
            _candidateApplications = _vacITCrud.ReadCandidateApplicationsByJobOfferId(id);
            if (_candidateApplications.Any())
            {
                _jobOffer = _candidateApplications[0].JobOffer;
            } else
            {
                _jobOffer = _vacITCrud.ReadJobOffer(id);
            }
        }

        public void GetCandidateApplicationList()
        {
            var tempUserId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            int userId = int.Parse(tempUserId);
            _candidateApplications = _vacITCrud.ReadCandidateApplicationsByCandidateId(userId);
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

        public void SetCurrentDate()
        {
            _currentDate = DateOnly.FromDateTime(DateTime.Now);
        }

        public void SetCurrentEmployer()
        {
            _vacITEmployer = (VacITEmployer)_userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
        }

        public void SetUpNewJobOffer()
        {
            SetCurrentDate();
            SetCurrentEmployer();
            _jobOffer = new JobOffer(_currentDate, _vacITEmployer);
        }

        public void UpdateJobOffer(JobOffer jobOffer)
        {
            _vacITCrud.UpdateJobOffer(jobOffer);
        }
    }
}
