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
                .HasMany(e => e.Images)
                .WithOne(i => i.Exercise)
                .HasForeignKey(i=>i.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            exercise
                .HasOne(e => e.ProgramCategory)
                .WithMany(sc => sc.Exercises)
                .HasForeignKey(e => e.ProgramCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
