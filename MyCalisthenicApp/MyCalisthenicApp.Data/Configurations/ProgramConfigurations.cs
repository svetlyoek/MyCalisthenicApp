namespace MyCalisthenicApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyCalisthenicApp.Models;

    public class ProgramConfigurations : IEntityTypeConfiguration<Program>
    {
        public void Configure(EntityTypeBuilder<Program> program)
        {
            program
                .HasOne(p => p.Image)
                .WithOne(i => i.Program)
                .HasForeignKey<Program>(p => p.ImageId);

            program
                .HasOne(p => p.Category)
                .WithOne(c => c.Program)
                .HasForeignKey<Program>(p => p.CategoryId);


        }
    }
}
