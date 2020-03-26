namespace MyCalisthenicApp.Data.Configurations
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyCalisthenicApp.Models;
    using Newtonsoft.Json;

    public class ProgramConfigurations : IEntityTypeConfiguration<Program>
    {
        public void Configure(EntityTypeBuilder<Program> program)
        {
            program
                .HasMany(p => p.Images)
                .WithOne(i => i.Program)
                .HasForeignKey(i => i.ProgramId)
                .OnDelete(DeleteBehavior.Restrict);

            program
                .HasOne(p => p.Category)
                .WithMany(c => c.Programs)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            program
                .HasMany(p => p.Comments)
                .WithOne(c => c.Program)
                .HasForeignKey(c => c.ProgramId)
                .OnDelete(DeleteBehavior.Restrict);

            program
            .Property(e => e.LikesUsersNames)
           .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
        }
    }
}
