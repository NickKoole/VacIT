using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection.Emit;

namespace VacIT.Models
{
    public class VacITCandidate : VacITUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(20)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(20)")]
        public string LastName { get; set; }

        //One to many relatie met Application wordt in de volgende regel aangemaakt
        [PersonalData]
        public ICollection<Application>? Applications { get; set; } = new List<Application>();

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
