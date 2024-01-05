using System.ComponentModel.DataAnnotations.Schema;

namespace VacIT.Models
{
    public class JobOffer
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Level { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string City { get; set; }

        public DateOnly DateOfPublication { get; set; }

        //One to many relatie met Application wordt in de volgende regel aangemaakt
        public ICollection<Application>? Applications { get; set; } = new List<Application>();

        //Many to one relatie met VacITUser wordt hieronder aangemaakt
        public int VacITUserId { get; set; }
        public VacITUser VacITUser { get; set; } = null!;

        public JobOffer(string name, string title, string description, string level, string city, DateOnly dateOfPublication)
        {
            Name = name;
            Title = title;
            Description = description;
            Level = level;
            City = city;
            DateOfPublication = dateOfPublication;
        }
    }
}
