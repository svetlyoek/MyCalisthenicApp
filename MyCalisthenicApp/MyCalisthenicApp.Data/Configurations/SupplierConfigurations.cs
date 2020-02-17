namespace MyCalisthenicApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyCalisthenicApp.Models.ShopEntities;

    public class SupplierConfigurations : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> supplier)
        {
            supplier
                   .Property(s => s.PriceToOffice).HasColumnType("decimal(5,2)");

            supplier
                   .Property(s => s.PriceToHome).HasColumnType("decimal(5,2)");
        }
    }
}
