using System.ComponentModel.DataAnnotations.Schema;

namespace VacIT.Models
{
    public class Application
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Motivation {  get; set; }

        //Many to one relatie wordt hieronder aangemaakt met een VacITUser
        public int VacItUserId { get; set; }
        public VacITUser VacITUser { get; set; } = null!;

        //Many to one relatie wordt hieronder aangemaakt met een JobOffer
        public int JobOfferId { get; set; }
        public JobOffer JobOffer { get; set; } = null!;
    }
}
