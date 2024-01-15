using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacIT.Models
{
    public class CandidateApplication
    {
        public int Id { get; set; }

        [DisplayName("Sollicitatiedatum")]
        public DateOnly ApplicationDate { get; set; }

        [DisplayName("Motivatie")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9\s]*$")]
        [Required(ErrorMessage = "Er moet een motivatie opgegeven worden.")]
        [StringLength(1000)]
        [Column(TypeName = "nvarchar(max)")]
        public string Motivation {  get; set; }

        [DisplayName("Uitgenodigd")]
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
