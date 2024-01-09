using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace VacIT.Models;

public class VacITContext : IdentityDbContext<VacITUser, IdentityRole<int>, int>
{
    public DbSet<JobOffer> JobOffers { get; set; }
    public DbSet<CandidateApplication> Applications { get; set; }
    public VacITContext(DbContextOptions<VacITContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
