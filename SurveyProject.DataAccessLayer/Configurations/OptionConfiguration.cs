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
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable("option");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("int");
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("varchar(255)");
            builder.Property(x => x.Order).HasColumnName("order").HasColumnType("int");
            builder.Property(x => x.Type).HasColumnName("type").HasColumnType("varchar(50)").HasDefaultValue("checkbox");

            builder.HasOne(x => x.Survey).WithMany(x => x.Options);
        }
    }
}
