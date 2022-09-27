using Exams.Core.Models;
using Exams.Repository;
namespace Exams.WEB
{
    public static class RoleSeed
    {
        public static void Seed(WebApplication application)
        {
            using (var serviceScope = application.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new AppRole { Name = "Admin", NormalizedName = "ADMIN" },
        new AppRole { Name = "User", NormalizedName = "USER" });
                    context.SaveChanges();
                }
            }
        }
    }
}
