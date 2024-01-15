using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VacIT.Models;

public class VacITUser : IdentityUser<int>
{
    [PersonalData]
    [DisplayName("Stad")]
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9\s]*$")]
    [Required(ErrorMessage = "Er moet een adres opgegeven worden.")]
    [StringLength(20)]
    [Column(TypeName = "nvarchar(40)")]
    public string Address { get; set; }

    [PersonalData]
    [DisplayName("Postcode")]
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9\s]*$")]
    [Required(ErrorMessage = "Er moet een postcode opgegeven worden.")]
    [StringLength(20)]
    [Column(TypeName = "nvarchar(10)")]
    public string Zipcode { get; set; }

    [PersonalData]
    [DisplayName("Stad")]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required(ErrorMessage = "Er moet een stad opgegeven worden.")]
    [StringLength(20)]
    [Column(TypeName = "nvarchar(20)")]
    public string City { get; set; }

    public VacITUser()
    {

    }

    public VacITUser(string email, string address, string zipcode, string city)
    {
        UserName = email;
        Email = email;
        Address = address;
        Zipcode = zipcode;
        City = city;
    }
}

