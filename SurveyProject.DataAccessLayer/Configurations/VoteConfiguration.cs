using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.DataAccessLayer.Configurations
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable("vote");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(x => x.User).HasColumnName("user").HasColumnType("varchar(50)");

            builder.HasOne(x => x.Survey)
            .WithMany(x => x.Votes)
            .HasForeignKey(x => x.SurveyId); // SurveyId'ye göre ilişki kuruyoruz.

            builder.HasMany(x => x.Options).WithMany(x => x.Votes);
        }
    }
}
