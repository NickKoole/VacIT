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
    [Column(TypeName = "nvarchar(40)")]
    public string Address { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(10)")]
    public string Zipcode { get; set; }

    [PersonalData]
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

