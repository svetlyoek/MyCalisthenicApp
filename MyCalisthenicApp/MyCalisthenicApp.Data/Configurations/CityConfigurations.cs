namespace MyCalisthenicApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyCalisthenicApp.Models.ShopEntities;

    public class CityConfigurations : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> city)
        {
            city
                 .HasMany(c => c.Addresses)
                 .WithOne(a => a.City)
                 .HasForeignKey(a => a.CityId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
