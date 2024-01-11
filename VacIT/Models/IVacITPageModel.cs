
namespace VacIT.Models
{
    public interface IVacITPageModel
    {
        List<CandidateApplication> _candidateApplications { get; set; }
        CandidateApplication _candidateApplication { get; set; }
        List<JobOffer> _jobOffers { get; set; }
        JobOffer _jobOffer { get; set; }

        void GetCandidateApplicationList();
        void GetJobOfferById(int id);
        void GetJobOffers();
        void GetJobOffersByUserId();
    }
}