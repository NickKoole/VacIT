
namespace VacIT.Models
{
    public interface IVacITPageModel
    {
        List<CandidateApplication> _candidateApplications { get; set; }
        CandidateApplication _candidateApplication { get; set; }
        List<JobOffer> _jobOffers { get; set; }
        JobOffer _jobOffer { get; set; }
        VacITEmployer _vacITEmployer { get; set; }

        void DeleteJobOffer(int id);
        void GetCandidateApplicationList();
        void GetCurrentEmployer();
        void GetJobOfferById(int id);
        void GetJobOffers();
        void GetJobOffersByUserId();
        void UpdateJobOffer(JobOffer jobOffer);
    }
}