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

        //Many to one relatie met Application wordt in de volgende regel aangemaakt
        public ICollection<Application> Applications { get; set; } = new List<Application>();

        public JobOffer(int id, string name, string title, string description, string level, string city, DateOnly dateOfPublication)
        {
            Id = id;
            Name = name;
            Title = title;
            Description = description;
            Level = level;
            City = city;
            DateOfPublication = dateOfPublication;
        }
    }
}
