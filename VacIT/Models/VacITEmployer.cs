using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection.Emit;

namespace VacIT.Models
{
    public class VacITEmployer : VacITUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }

        //One to many relatie met JobOffer wordt in de volgende regel aangemaakt
        [PersonalData]
        public ICollection<JobOffer>? JobOffers { get; set; } = new List<JobOffer>();

        public VacITEmployer(string email, string name, string address, string zipcode, string city)
        {
            UserName = email;
            Email = email;
            Name = name;
            Address = address;
            Zipcode = zipcode;
            City = city;
        }
    }
}
