namespace MyCalisthenicApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyCalisthenicApp.Models.TrainingEntities;

    public class ProgramSubCategoryConfigurations : IEntityTypeConfiguration<ProgramSubCategory>
    {
        public void Configure(EntityTypeBuilder<ProgramSubCategory> programSubCategory)
        {
            programSubCategory
                .HasOne(psc => psc.ProgramCategory)
                .WithMany(pc => pc.SubCategories)
                .HasForeignKey(psc => psc.ProgramCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            programSubCategory
                .HasMany(psc => psc.Exercises)
                .WithOne(e => e.ProgramSubCategory)
                .HasForeignKey(e => e.ProgramSubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
