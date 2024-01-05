using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VacIT.Models;

// Add profile data for application users by adding properties to the VacITUser class
public class VacITUser : IdentityUser<int>
{
    [PersonalData]
    [Column(TypeName = "nvarchar(20)")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(20)")]
    public string LastName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(40)")]
    public string Address { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(10)")]
    public string Zipcode { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(20)")]
    public string City { get; set; }

    //One to many relatie met Application wordt in de volgende regel aangemaakt
    public ICollection<Application>? Applications { get; set; } = new List<Application>();

    //One to many relatie met JobOffer wordt in de volgende regel aangemaakt
    public ICollection<JobOffer>? JobOffers { get; set; } = new List<JobOffer>();

    //public string CvPdfFileLocation { get; set; }
}

