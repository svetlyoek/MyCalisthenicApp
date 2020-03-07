namespace MyCalisthenicApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyCalisthenicApp.Models.ShopEntities;

    public class ImageConfigurations : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> image)
        {
            image
                 .HasOne(i => i.Product)
                 .WithMany(p => p.Images)
                 .HasForeignKey(i => i.ProductId)
                 .OnDelete(DeleteBehavior.Restrict);

            image
                .HasOne(i => i.Post)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            image
               .HasOne(i => i.Exercise)
               .WithMany(p => p.Images)
               .HasForeignKey(i => i.ExerciseId)
               .OnDelete(DeleteBehavior.Restrict);

            image
               .HasOne(i => i.Program)
               .WithMany(p => p.Images)
               .HasForeignKey(i => i.ProgramId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
