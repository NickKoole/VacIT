using Microsoft.EntityFrameworkCore;
using VacIT.Models;
using static System.Net.Mime.MediaTypeNames;

namespace VacIT.Cruds
{
    public class VacITCrud : IVacITCrud
    {
        private VacITContext _context;

        public VacITCrud(VacITContext context)
        {
            _context = context;
        }

        public void CreateCandidateApplication(CandidateApplication application)
        {
            try
            {
                _context.Applications.Add(application);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }

        public void CreateJobOffer(JobOffer jobOffer)
        {
            try
            {
                _context.JobOffers.Add(jobOffer);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }

        public void DeleteCandidateApplication(int id)
        {
            try
            {
                var selectedApplication = _context.Applications.FirstOrDefault(application => application.Id == id);

                if (selectedApplication != null)
                {
                    _context.Applications.Remove(selectedApplication);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }

        public void DeleteJobOffer(int id)
        {
            try
            {
                var selectedJobOffer = _context.JobOffers
                    .Include(e => e.VacITEmployer)
                    .Include(a =>  a.Applications)
                    .FirstOrDefault(jobOffer => jobOffer.Id == id);

                if (selectedJobOffer != null)
                {
                    _context.JobOffers.Remove(selectedJobOffer);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }

        public CandidateApplication? ReadCandidateApplication(int id)
        {
            try
            {
                var selectedApplication = _context.Applications
                    .Include(c => c.VacITCandidate)
                    .Include(j => j.JobOffer)
                        .ThenInclude(e => e.VacITEmployer)
                    .Where(application => application.Id == id)
                    .FirstOrDefault();
                return selectedApplication;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null;
            }
        }

        public JobOffer? ReadJobOffer(int id)
        {
            try
            {
                var selectedJobOffer = _context.JobOffers
                    .Include(j => j.VacITEmployer)
                    .Where(j => j.Id == id)
                    .FirstOrDefault();
                return selectedJobOffer;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null;
            }
        }

        public List<CandidateApplication>? ReadAllCandidateApplications()
        {
            try
            {
                var candidateApplications = _context.Applications
                    .Include(a => a.VacITCandidate)
                    .Include(a => a.JobOffer)
                        .ThenInclude(j => j.VacITEmployer)
                    .ToList();
                return candidateApplications;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null;
            }
        }

        public List<JobOffer>? ReadAllJobOffers()
        {
            try
            {
                var jobOffers = _context.JobOffers
                    .Include(j => j.VacITEmployer)
                    .ToList();
                return jobOffers;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null;
            }
        }

        public List<CandidateApplication>? ReadCandidateApplicationsByCandidateId(int vacITCandidateId)
        {
            try
            {
                var candidateApplications = _context.Applications
                    .Include(a => a.VacITCandidate)
                    .Include(a => a.JobOffer)
                        .ThenInclude(j => j.VacITEmployer)
                    .Where(candidateApplication => candidateApplication.VacITCandidateId == vacITCandidateId)
                    .ToList();
                return candidateApplications;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null;
            }
        }

        public List<JobOffer>? ReadJobOffersByEmployerId(int vacITEmployerId)
        {
            try
            {
                var jobOffers = _context.JobOffers
                    .Include(j => j.VacITEmployer)
                    .Where(jobOffer => jobOffer.VacITEmployerId == vacITEmployerId)
                    .ToList();
                return jobOffers;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null;
            }
        }

        public void UpdateCandidateApplication(CandidateApplication application)
        {
            try
            {
                _context.Applications.Update(application);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }

        public void UpdateJobOffer(JobOffer jobOffer)
        {
            try
            {
                _context.JobOffers.Update(jobOffer);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }
    }
}
