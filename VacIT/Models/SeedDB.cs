using Microsoft.AspNetCore.Identity;
using static System.Formats.Asn1.AsnWriter;

namespace VacIT.Models
{
    public static class SeedDB
    {
        public static async Task Initialize(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                //Create Roles
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

                var roles = new[] { "Admin", "Employer", "Candidate" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole<int>(role));
                }
            
                //Create users
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<VacITUser>>();

                VacITUser adminUser = new VacITUser("admin@admin.admin", "Teststraat 1", "1234AB", "Admindam");

                VacITEmployer[] employerUsers = { new VacITEmployer("test@employer.employer", "Educom", "Teststraat 1", "1234AB", "Utrecht"),
                                                  new VacITEmployer("dsmsittard@employer.employer", "DSM Sittard", "Testlaan 2", "4321AB", "Sittard"),
                                                  new VacITEmployer("hostnetbv@employer.employer", "Hostnet BV", "Testweg 3", "1234CD", "Groningen"),
                                                };

                VacITCandidate[] candidateUsers = { new VacITCandidate("test@candidate.candidate", "Jan", "Jansma", "Teststraat 5", "5678AB", "Amsterdam"),
                                                    new VacITCandidate("tinatinusma@candidate.candidate", "Tina", "Tinusma", "Testlaan 17", "1224UV", "Tilburg"),
                                                    new VacITCandidate("bertbertusma@candidate.candidate", "Bert", "Bertusma", "Testweg 34", "2448XY", "Rotterdam")
                                                  };
                string password = "Test890!";

                if (await userManager.FindByEmailAsync(adminUser.Email) == null)
                    {
                        await userManager.CreateAsync(adminUser, password);
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }

                foreach (VacITUser user in employerUsers)
                {
                    if (await userManager.FindByEmailAsync(user.Email) == null)
                    {
                        await userManager.CreateAsync(user, password);
                        await userManager.AddToRoleAsync(user, "Employer");
                    }
                }

                foreach (VacITUser user in candidateUsers)
                {
                    if (await userManager.FindByEmailAsync(user.Email) == null)
                    {
                        await userManager.CreateAsync(user, password);
                        await userManager.AddToRoleAsync(user, "Candidate");
                    }
                }

                //Create Joboffers
                var dbContext = scope.ServiceProvider.GetRequiredService<VacITContext>();

                if (!dbContext.JobOffers.Any())
                {
                    DateOnly[] dates = { new DateOnly(2024, 1, 1),
                                         new DateOnly(2022, 5, 27),
                                         new DateOnly(2023, 8, 5),
                                         new DateOnly(2023, 12, 12)
                                       };

                    JobOffer[] jobOffers = { new JobOffer("Applicatiebeheerder", "Applicatiebeheerder voor Educom Utrecht", "Testbeschrijving", "Windows", "Senior", "Utrecht", dates[0], employerUsers[0]),
                                             new JobOffer("Netwerkbeheerder", "Netwerkbeheerder voor Educom Arnhem", "Testbeschrijving", "Linux", "Junior", "Arnhem", dates[1], employerUsers[0]),
                                             new JobOffer("Docent", "Docent voor Educom Eindhoven", "Testbeschrijving", "Diversen", "Senior", "Eindhoven", dates[2], employerUsers[0]),
                                             new JobOffer("Tester", "Tester voor Hostnet BV", "Testbeschrijving", "SAP", "Medior", "Groningen", dates[3], employerUsers[2])
                                           };

                    dbContext.JobOffers.AddRange(jobOffers);
                    await dbContext.SaveChangesAsync();

                    if (!dbContext.Applications.Any())
                    {
                        DateOnly date = new DateOnly(2024, 1, 10);
                        CandidateApplication[] candidateApplications = { new CandidateApplication(date, "Ik ben zeer geschikt voor deze baan.", false, candidateUsers[0], jobOffers[0]),
                                                                         new CandidateApplication(date, "Ik ben heb veel werkervaring op dit gebied.", true, candidateUsers[1], jobOffers[0]),
                                                                         new CandidateApplication(date, "Werken vind ik stom.", false, candidateUsers[2], jobOffers[0]),
                                                                         new CandidateApplication(date, "Ik vind studenten begeleiden erg leuk.", false, candidateUsers[0], jobOffers[2]),
                                                                         new CandidateApplication(date, "Ik ben een expert op dit gebied.", true, candidateUsers[0], jobOffers[3])
                                                                       };
                        dbContext.Applications.AddRange(candidateApplications);
                        await dbContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
