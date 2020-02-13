namespace MyCalisthenicApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyCalisthenicApp.Models.ShopEntities;

    public class ShoppingCartProductConfigurations : IEntityTypeConfiguration<ShoppingCartProduct>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartProduct> shoppingCartProduct)
        {
            shoppingCartProduct
                 .HasKey(scp => new
                 {
                     scp.ProductId,
                     scp.ShoppingCartId
                 });

            shoppingCartProduct
                .HasOne(scp => scp.ShoppingCart)
                .WithMany(sc => sc.Products)
                .HasForeignKey(scp => scp.ShoppingCartId)
                .OnDelete(DeleteBehavior.Restrict);

            shoppingCartProduct
                .HasOne(scp => scp.Product)
                .WithMany(p => p.ShoppingCarts)
                .HasForeignKey(scp => scp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
