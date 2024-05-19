using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SurveyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.DataAccessLayer.Configurations
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("survey");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(x => x.Question).HasColumnName("question").HasColumnType("text");
            builder.Property(x => x.CreatedDate).HasColumnName("created_date").HasColumnType("date");
            builder.Property(x => x.CreatedBy).HasColumnName("created_by").HasColumnType("varchar(50)");
            builder.Property(x => x.DueDate).HasColumnName("due_date").HasColumnType("date");
            builder.Property(x => x.Setting).HasColumnName("settings").HasColumnType("jsonb");


            builder.HasMany(x => x.Options).WithOne(x => x.Survey);
        }
    }
}
