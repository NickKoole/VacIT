using System.ComponentModel.DataAnnotations.Schema;

namespace VacIT.Models
{
    public class JobOffer
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Technology { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Level { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string City { get; set; }

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
