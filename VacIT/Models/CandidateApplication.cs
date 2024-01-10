using System.ComponentModel.DataAnnotations.Schema;

namespace VacIT.Models
{
    public class CandidateApplication
    {
        public int Id { get; set; }

        public DateOnly ApplicationDate { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Motivation {  get; set; }

        public bool Invited { get; set; } = false;

        //Many to one relatie wordt hieronder aangemaakt met een VacITCandidate
        public int VacITCandidateId { get; set; }
        public VacITCandidate VacITCandidate { get; set; } = null!;

        //Many to one relatie wordt hieronder aangemaakt met een JobOffer
        public int JobOfferId { get; set; }
        public JobOffer JobOffer { get; set; } = null!;

        public CandidateApplication()
        {

        }

        public CandidateApplication(DateOnly date, string motivation, bool invited, VacITCandidate vacITCandidate, JobOffer jobOffer)
        {
            ApplicationDate = date;
            Motivation = motivation;
            Invited = invited;
            VacITCandidateId = vacITCandidate.Id;
            VacITCandidate = vacITCandidate;
            JobOfferId = jobOffer.Id;
            JobOffer = jobOffer;
        }
    }
}
