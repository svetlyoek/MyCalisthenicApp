namespace MyCalisthenicApp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Models;
    using System.Reflection;

    public class MyCalisthenicAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyCalisthenicAppDbContext(DbContextOptions options)
            : base(options)
        {
        }








        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
