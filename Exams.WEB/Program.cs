using Autofac;
using Autofac.Extensions.DependencyInjection;
using Exam.Configuration;
using Exam.MiddleWares;
using Exam.ServiceConfigurations;
using Exams.Service.Validations;
using Exams.WEB;
using Exams.WEB.ConfigurationService;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblyContaining<SignUpValidator>();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddControllersWithViews();
builder.Services.AddMapster();
builder.Services.AddIdentity();
builder.Services.AddCookieConfiguration();
builder.Services.AddDbContext(builder);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new AutoFactContainer()));
builder.SerilogCon();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseHttpLogging();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSeriLogAddColumnValue();
RoleSeed.Seed(app);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
