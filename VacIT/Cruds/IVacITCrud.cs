using VacIT.Models;

namespace VacIT.Cruds
{
    public interface IVacITCrud
    {
        void CreateCandidateApplication(CandidateApplication application);
        int CreateJobOffer(JobOffer jobOffer);
        void DeleteCandidateApplication(int id);
        void DeleteJobOffer(int id);
        List<CandidateApplication>? ReadAllCandidateApplications();
        CandidateApplication? ReadCandidateApplication(int id);
        List<CandidateApplication>? ReadCandidateApplicationsByCandidateId(int vacITCandidateId);
        public List<CandidateApplication>? ReadCandidateApplicationsByJobOfferId(int vacITJobOfferId);
        List<JobOffer>? ReadAllJobOffers();
        JobOffer? ReadJobOffer(int id);
        List<JobOffer>? ReadJobOffersByEmployerId(int vacITEmployerId);
        void UpdateCandidateApplication(CandidateApplication application);
        void UpdateJobOffer(JobOffer jobOffer);
    }
}