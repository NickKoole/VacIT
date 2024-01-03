using Microsoft.AspNetCore.Identity;
using VacIT.Areas.Identity.Data;
using VacIT.Data;

namespace VacIT.Models
{
    public static class SeedDB
    {
        public static async Task Initialize(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Admin", "Employer", "Candidate" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<VacITUser>>();

                string[] emails = { "admin@admin.admin", "employer@employer.employer", "candidate@candidate.candidate" };
                string password = "Test890!";
                string firstName = "Test";
                string lastName = "Test";
                string address = "Teststraat 1";
                string zipcode = "1234AB";
                string city = "Admindam";
                string[] roles = { "Admin", "Employer", "Candidate" };
                int i = 0;

                foreach (string email in emails)
                {
                    if (await userManager.FindByEmailAsync(email) == null)
                    {
                        var user = new VacITUser();
                        user.UserName = email;
                        user.Email = email;
                        user.Password = password;
                        user.FirstName = firstName;
                        user.LastName = lastName;
                        user.Address = address;
                        user.Zipcode = zipcode;
                        user.City = city;

                        await userManager.CreateAsync(user, password);

                        await userManager.AddToRoleAsync(user, roles[0]);
                        i++;
                    }
                }
            }
        }
    }
}
