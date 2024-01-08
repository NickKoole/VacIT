using System.ComponentModel.DataAnnotations.Schema;

namespace VacIT.Models
{
    public class CandidateApplication
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Motivation {  get; set; }

        public bool Invited { get; set; } = false;

        //Many to one relatie wordt hieronder aangemaakt met een VacITCandidate
        public int VacItCandidateId { get; set; }
        public VacITCandidate VacITCandidate { get; set; } = null!;

        //Many to one relatie wordt hieronder aangemaakt met een JobOffer
        public int JobOfferId { get; set; }
        public JobOffer JobOffer { get; set; } = null!;

        public CandidateApplication()
        {

        }

        public CandidateApplication(int id, string motivation, bool invited, int vacItCandidateId, VacITCandidate vacITCandidate, int jobOfferId, JobOffer jobOffer)
        {
            Id = id;
            Motivation = motivation;
            Invited = invited;
            VacItCandidateId = vacItCandidateId;
            VacITCandidate = vacITCandidate;
            JobOfferId = jobOfferId;
            JobOffer = jobOffer;
        }
    }
}
