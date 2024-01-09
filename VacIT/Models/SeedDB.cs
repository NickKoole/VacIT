using Microsoft.AspNetCore.Identity;

namespace VacIT.Models
{
    public static class SeedDB
    {
        public static async Task Initialize(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

                var roles = new[] { "Admin", "Employer", "Candidate" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole<int>(role));
                }
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<VacITUser>>();

                VacITUser[] users = {   new VacITUser("admin@admin.admin", "Teststraat 1", "1234AB", "Admindam"),
                                        new VacITEmployer("employer@employer.employer", "Testwerkgever", "Teststraat 1", "1234AB", "Testplaats"),
                                        new VacITCandidate("candidate@candidate.candidate", "Testvoornaam", "Testachternaan", "Teststraat 2", "1234AB", "Testplaats")
                                    };
                string password = "Test890!";
                string[] roles = { "Admin", "Employer", "Candidate" };

                int i = 0;
                foreach (VacITUser user in users)
                {
                    if (await userManager.FindByEmailAsync(user.Email) == null)
                    {
                        await userManager.CreateAsync(user, password);
                        await userManager.AddToRoleAsync(user, roles[i]);
                    }
                    i++;
                }
            }

            /*
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<VacITContext>();

                if (!dbContext.JobOffers.Any())
                {
                    DateOnly date = new DateOnly(2024, 1, 1);
                    JobOffer jobOffer = new JobOffer("Testnaam", "Testtitel", "Testbeschrijving", "Windows", "Testlevel", "Teststad", date);
                    dbContext.JobOffers.Add(jobOffer);
                    await dbContext.SaveChangesAsync();

                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<VacITUser>>();

                }
            }
            */

            /*
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<VacITContext>();

                if (!dbContext.JobOffers.Any())
                {
                    DateOnly date = new DateOnly(2024, 1, 1);
                    JobOffer jobOffer = new JobOffer("Testnaam", "Testtitel", "Testbeschrijving", "Windows", "Testlevel", "Teststad", date);
                    dbContext.JobOffers.Add(jobOffer);
                    await dbContext.SaveChangesAsync();
                }
            }
            */
        }
    }
}
