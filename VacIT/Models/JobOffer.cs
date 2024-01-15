using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacIT.Models
{
    public class JobOffer
    {
        public int Id { get; set; }

        [DisplayName("Naam")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required(ErrorMessage = "Er moet een naam opgegeven worden.")]
        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        [DisplayName("Titel")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required(ErrorMessage = "Er moet een titel opgegeven worden.")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }

        [DisplayName("Beschrijving")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required(ErrorMessage = "Er moet een beschrijving opgegeven worden.")]
        [StringLength(1000)]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [DisplayName("Technologie")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required(ErrorMessage = "Er moet een technologie opgegeven worden.")]
        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string Technology { get; set; }

        [DisplayName("Niveau")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required(ErrorMessage = "Er moet een niveau opgegeven worden.")]
        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string Level { get; set; }

        [DisplayName("Stad")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required(ErrorMessage = "Er moet een stad opgegeven worden.")]
        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string City { get; set; }

        [DisplayName("Publicatiedatum")]
        public DateOnly DateOfPublication { get; set; }

        //One to many relatie met Application wordt in de volgende regel aangemaakt
        public ICollection<CandidateApplication>? Applications { get; set; } = new List<CandidateApplication>();

        //Many to one relatie met VacITEmployer wordt hieronder aangemaakt
        public int VacITEmployerId { get; set; }
        public VacITEmployer VacITEmployer { get; set; } = null!;

        public JobOffer()
        {

        }

        public JobOffer(string name, string title, string description, string technology, string level, string city, DateOnly dateOfPublication, VacITEmployer vacITEmployer)
        {
            Name = name;
            Title = title;
            Description = description;
            Technology = technology;
            Level = level;
            City = city;
            DateOfPublication = dateOfPublication;
            VacITEmployerId = vacITEmployer.Id;
            VacITEmployer = vacITEmployer;
        }
    }
}
