using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            //Table Overrides

            //Primary Key Overrides

            //Property Overrides
            Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            Property(c => c.Id)
                .HasColumnOrder(1);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnOrder(2);

            //Relationship Overrides

            HasRequired(e => e.Cover)
                .WithRequiredPrincipal(e => e.Course);

            HasMany(e => e.Tags)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("CourseTags").MapLeftKey("CourseId").MapRightKey("TagId"));

            }
    }
}
