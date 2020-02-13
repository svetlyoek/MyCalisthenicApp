namespace MyCalisthenicApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyCalisthenicApp.Models.TrainingEntities;

    public class ExerciseConfigurations : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> exercise)
        {
            exercise
                .HasOne(e => e.Image)
                .WithOne(i => i.Exercise)
                .HasForeignKey<Exercise>(e => e.ImageId);

            exercise
                .HasOne(e => e.ProgramSubCategory)
                .WithMany(sc => sc.Exercises)
                .HasForeignKey(e => e.ProgramSubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
