namespace MyCalisthenicApp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.BlogEntities;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.Models.TrainingEntities;
    using System.Reflection;

    public class MyCalisthenicAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyCalisthenicAppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public MyCalisthenicAppDbContext()
        {
        }

        public DbSet<BlogCategory> BlogCategories { get; set; }

        public DbSet<Post> Post { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<UserRequest> UserRequests { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<Program> Programs { get; set; }

        public DbSet<ProgramCategory> ProgramCategories { get; set; }

        public DbSet<ProgramSubCategory> ProgramSubCategories { get; set; }

        public DbSet<Comment> Comments { get; set; }


        //TODO-Remove that connection and use appsettings.json

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=DESKTOP-JH4M4M9\MSSQLSERVER01;Database=MyCalisthenicApp;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

    }
}
