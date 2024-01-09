using VacIT.Models;

namespace VacIT.Cruds
{
    public class CandidateApplicationCrud
    {
        private VacITContext _context;

        public CandidateApplicationCrud(VacITContext context)
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

        public void DeleteCandidateApplication(int id)
        {
            try
            {
                var selectedApplication = _context.Applications
                    .Where(application => application.Id == id)
                    .FirstOrDefault();

                if (selectedApplication != null)
                {
                    _context.Applications.Remove(selectedApplication);
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

        public List<CandidateApplication>? ReadAllCandidateApplications()
        {
            try
            {
                var candidateApplications = _context.Applications.ToList();
                return candidateApplications;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null;
            }
        }

        public List<CandidateApplication>? ReadAllCandidateApplicationsByCandidateId(int vacITCandidateId)
        {
            try
            {
                var candidateApplications = _context.Applications
                    .Where(candidateApplication => candidateApplication.VacItCandidateId == vacITCandidateId)
                    .ToList();
                return candidateApplications;
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
    }
}
