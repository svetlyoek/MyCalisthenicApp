namespace MyCalisthenicApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyCalisthenicApp.Models.ShopEntities;

    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> address)
        {
            address
                .HasOne(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            address
                .HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            address
                .HasMany(a => a.Orders)
                .WithOne(o => o.DeliveryAddress)
                .HasForeignKey(o => o.DeliveryAddressId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
