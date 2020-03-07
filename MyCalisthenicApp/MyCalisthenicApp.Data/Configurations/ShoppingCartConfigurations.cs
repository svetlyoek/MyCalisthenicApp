namespace MyCalisthenicApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyCalisthenicApp.Models.ShopEntities;

    public class ShoppingCartConfigurations : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> shoppingCart)
        {
            shoppingCart
                .HasMany(sc => sc.Products)
                .WithOne(scp => scp.ShoppingCart)
                .HasForeignKey(scp => scp.ShoppingCartId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
