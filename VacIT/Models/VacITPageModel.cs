using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using VacIT.Cruds;

namespace VacIT.Models
{
    public class VacITPageModel
    {
        private VacITCrud _vacITCrud;
        private UserManager<VacITUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public List<CandidateApplication> _candidateApplications { get; set; }
        public List<JobOffer> _jobOffers { get; set; }

        public VacITPageModel(VacITCrud candidateApplicationCrud, UserManager<VacITUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _vacITCrud = candidateApplicationCrud;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public void SetCandidateApplicationList()
        {
            var tempUserId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            int userId = int.Parse(tempUserId);
            _candidateApplications = _vacITCrud.ReadAllCandidateApplicationsByCandidateId(userId);
        }

        public void SetJobOffers()
        {
            _jobOffers = _vacITCrud.ReadAllJobOffers();
        }
    }
}
