using Exams.Core.Models;
using Exams.Repository;
using Indentity.CustomValidation;
using Microsoft.AspNetCore.Identity;

namespace Exam.Configuration
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opts =>
            {
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireDigit = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders()
            .AddPasswordValidator<CustomPasswordValidator>()
            .AddUserValidator<CustomUserValidator>()
            .AddErrorDescriber<CustomIdentityErrorDescriber>(); ;
                   
            return services;
        }
    }
}
