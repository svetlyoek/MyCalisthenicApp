namespace MyCalisthenicApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyCalisthenicApp.Models;

    public class ProgramCategoryConfigurations : IEntityTypeConfiguration<ProgramCategory>
    {
        public void Configure(EntityTypeBuilder<ProgramCategory> programCategory)
        {
            programCategory
                .HasMany(pc => pc.Exercises)
                .WithOne(sc => sc.ProgramCategory)
                .HasForeignKey(sc => sc.ProgramCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            programCategory
                .HasMany(pc => pc.Comments)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
