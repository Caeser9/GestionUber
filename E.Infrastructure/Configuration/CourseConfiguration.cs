using E.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Infrastructure.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            //FK
            builder.HasOne(c => c.Voiture)
                .WithMany(v => v.Courses)
                .HasForeignKey(v => v.VoitreFk);
            builder.HasOne(c => c.Client)
                .WithMany(cl => cl.Courses)
                .HasForeignKey(cl => cl.ClientFk);
            //PK
            builder.HasKey(c => new
            {
                c.VoitreFk,
                c.ClientFk,
                c.DateCourse
            });
        }

    }
}
