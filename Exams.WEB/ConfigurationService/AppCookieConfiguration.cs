namespace Exam.Configuration
{
    public static class AppCookieConfiguration
    {
        public static IServiceCollection AddCookieConfiguration(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = new PathString("/Login");
                opts.LogoutPath = new PathString("/Login");
                opts.SlidingExpiration = true;
                opts.ExpireTimeSpan = TimeSpan.FromDays(10);
                opts.Cookie = new CookieBuilder
                {
                    Name = "ExamCookie",
                    HttpOnly = false,
                    SecurePolicy = CookieSecurePolicy.None,
                    SameSite = SameSiteMode.Lax
                };
                opts.AccessDeniedPath = new PathString("/Guest/Index");
            });

            return services;
        }
    }
}
