using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection.Emit;

namespace VacIT.Models
{
    public class VacITCandidate : VacITUser
    {
        [PersonalData]
        [DisplayName("Voornaam")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required(ErrorMessage = "Er moet een voornaam opgegeven worden.")]
        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string FirstName { get; set; }

        [PersonalData]
        [DisplayName("Achternaam")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required(ErrorMessage = "Er moet een achternaam opgegeven worden.")]
        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string LastName { get; set; }

        //One to many relatie met Application wordt in de volgende regel aangemaakt
        [PersonalData]
        public ICollection<CandidateApplication>? Applications { get; set; } = new List<CandidateApplication>();

        //public string CvPdfFileLocation { get; set; }

        public VacITCandidate()
        {

        }
        public VacITCandidate(string email, string firstName, string lastName, string address, string zipcode, string city)
        {
            UserName = email;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Zipcode = zipcode;
            City = city;
        }
    }
}
