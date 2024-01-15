
namespace VacIT.Models
{
    public interface IVacITPageModel
    {
        DateOnly _currentDate { get; set; }
        List<CandidateApplication> _candidateApplications { get; set; }
        CandidateApplication _candidateApplication { get; set; }
        List<JobOffer> _jobOffers { get; set; }
        JobOffer _jobOffer { get; set; }
        VacITEmployer _vacITEmployer { get; set; }

        void CreateJobOffer(JobOffer jobOffer);
        void DeleteJobOffer(int id);
        void GetCandidateApplicationList();
        public void GetCandidateApplicationsByJobOfferId(int id);
        void SetCurrentDate();
        void SetCurrentEmployer();
        void GetJobOfferById(int id);
        void GetJobOffers();
        void GetJobOffersByUserId();
        void SetUpNewJobOffer();
        void UpdateJobOffer(JobOffer jobOffer);
    }
}