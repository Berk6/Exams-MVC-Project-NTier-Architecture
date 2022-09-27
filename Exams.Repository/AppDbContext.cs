using Exams.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;

namespace Exams.Repository
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> TestModels { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
            builder.Entity<Question>()
                            .HasMany(x => x.Tests).WithMany(x => x.Question)
                            .UsingEntity<Dictionary<string, object>>("TestQuestionManyToMany",
                            x => x.HasOne<Test>().WithMany().HasForeignKey("TestId").HasConstraintName("TestFK"),
                            x => x.HasOne<Question>().WithMany().HasForeignKey("QuestionId").HasConstraintName("QuestionFK"));
            builder.Entity<AppUser>()
                .HasMany(x => x.Exams).WithMany(x => x.Users)
                .UsingEntity<Dictionary<string, object>>("ExamUserManyToMany",
                x => x.HasOne<Test>().WithMany().HasForeignKey("ExamId").HasConstraintName("ExamFK"),
                x => x.HasOne<AppUser>().WithMany().HasForeignKey("UserId").HasConstraintName("UserFK"));
            builder.Entity<AppUser>().HasMany(x => x.MainUser).WithMany(x => x.UserConnection).UsingEntity<Dictionary<string, object>>("UsersConnections",
                x => x.HasOne<AppUser>().WithMany().HasForeignKey("MainUserId"),
                x => x.HasOne<AppUser>().WithMany().HasForeignKey("ConnectedUserId"));
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }
        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            public DateOnlyConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                    d => DateOnly.FromDateTime(d))
            { }
        }

    }
}
