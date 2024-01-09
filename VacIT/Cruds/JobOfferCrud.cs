using VacIT.Models;

namespace VacIT.Cruds
{
    public class JobOfferCrud
    {
        private VacITContext _context;

        public JobOfferCrud(VacITContext context)
        {
            _context = context;
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

        public void DeleteJobOffer(int id)
        {
            try
            {
                var selectedJobOffer = _context.JobOffers
                    .Where(jobOffer => jobOffer.Id == id)
                    .FirstOrDefault();

                if (selectedJobOffer != null)
                {
                    _context.JobOffers.Remove(selectedJobOffer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }

        public JobOffer? ReadJobOffer(int id)
        {
            try
            {
                var selectedJobOffer = _context.JobOffers
                    .Where(jobOffer => jobOffer.Id == id)
                    .FirstOrDefault();
                return selectedJobOffer;
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
                var jobOffers = _context.JobOffers.ToList();
                return jobOffers;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null;
            }
        }

        public List<JobOffer>? ReadAllJobOffersByEmployerId(int vacITEmployerId)
        {
            try
            {
                var jobOffers = _context.JobOffers
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
