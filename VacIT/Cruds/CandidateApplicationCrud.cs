using VacIT.Models;

namespace VacIT.Cruds
{
    public class CandidateApplicationCrud
    {
        private VacITContext Context;

        public CandidateApplicationCrud(VacITContext context)
        {
            Context = context;
        }

        public void CreateCandidateApplication(CandidateApplication application)
        {
            try
            {
                Context.Applications.Add(application);
                Context.SaveChanges();
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
                var selectedApplication = Context.Applications
                    .Where(application => application.Id == id)
                    .FirstOrDefault();

                if (selectedApplication != null)
                {
                    Context.Applications.Remove(selectedApplication);
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
                var selectedApplication = Context.Applications
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
                var candidateApplications = Context.Applications.ToList();
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
                var candidateApplications = Context.Applications
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
                Context.Applications.Update(application);
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }        
    }
}
