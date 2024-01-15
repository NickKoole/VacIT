
namespace VacIT.Models
{
    public interface IVacITPageModel
    {
        DateOnly _currentDate { get; set; }
        string _invited { get; set; }
        List<CandidateApplication> _candidateApplications { get; set; }
        CandidateApplication _candidateApplication { get; set; }
        List<JobOffer> _jobOffers { get; set; }
        JobOffer _jobOffer { get; set; }
        VacITEmployer _vacITEmployer { get; set; }

        void ChangeInvitedStatus(int id, bool invited);
        void CreateJobOffer(JobOffer jobOffer);
        void DeleteJobOffer(int id);
        void GetCandidateApplication(int id);
        void GetCandidateApplicationList();
        public void GetCandidateApplicationsByJobOfferId(int id);
        void GetCurrentDate();
        void GetCurrentEmployer();
        void GetJobOfferById(int id);
        void GetJobOffers();
        void GetJobOffersByUserId();
        void SetUpNewJobOffer();
        void UpdateJobOffer(JobOffer jobOffer);
    }
}