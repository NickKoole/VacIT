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
        List<CandidateApplication>? ReadCandidateApplicationsByCandidateId(int vacITCandidateId);
        List<JobOffer>? ReadAllJobOffers();
        List<JobOffer>? ReadJobOffersByEmployerId(int vacITEmployerId);
        CandidateApplication? ReadCandidateApplication(int id);
        JobOffer? ReadJobOffer(int id);
        void UpdateCandidateApplication(CandidateApplication application);
        void UpdateJobOffer(JobOffer jobOffer);
    }
}