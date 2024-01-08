using VacIT.Models;

namespace VacIT.Cruds
{
    public class JobOfferCrud
    {
        private VacITContext Context;

        public JobOfferCrud(VacITContext context)
        {
            Context = context;
        }
        public void CreateJobOffer(JobOffer jobOffer)
        {
            try
            {
                Context.JobOffers.Add(jobOffer);
                Context.SaveChanges();
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
                var selectedJobOffer = Context.JobOffers
                    .Where(jobOffer => jobOffer.Id == id)
                    .FirstOrDefault();

                if (selectedJobOffer != null)
                {
                    Context.JobOffers.Remove(selectedJobOffer);
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
                var selectedJobOffer = Context.JobOffers
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
                var jobOffers = Context.JobOffers.ToList();
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
                var jobOffers = Context.JobOffers
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
                Context.JobOffers.Update(jobOffer);
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }
    }
}
