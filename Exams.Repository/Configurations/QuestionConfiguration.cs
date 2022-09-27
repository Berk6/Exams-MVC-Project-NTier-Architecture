using Exams.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams.Repository.Configurations
{
    //public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    //{
    //    public void Configure(EntityTypeBuilder<Question> builder)
    //    {
    //        builder.HasKey(x => x.Id).Metadata.IsPrimaryKey();
    //        builder.Property(x => x.User.Id).IsRequired();
    //        builder.Property(x => x.Quest).HasColumnType("NVarchar(3000)");
    //        builder.Property(x => x.Answer1).HasColumnType("NVarchar(3000)");
    //        builder.Property(x => x.Answer2).HasColumnType("NVarchar(3000)");
    //        builder.Property(x => x.Answer3).HasColumnType("NVarchar(3000)");
    //        builder.Property(x => x.Answer4).HasColumnType("NVarchar(3000)");
    //        builder.Property(x => x.Answer5).HasColumnType("NVarchar(3000)");
    //    }
    //}
}
