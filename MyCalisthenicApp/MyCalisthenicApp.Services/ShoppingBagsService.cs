namespace MyCalisthenicApp.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.ShoppingBags;

    public class ShoppingBagsService : IShoppingBagsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;

        public ShoppingBagsService(MyCalisthenicAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ShoppingBagIndexProductsCountViewModel> ShoppingBagProducts()
        {
            var orderProducts = await this.dbContext.Orders
                .Include(o => o.Products)
                  .Where(s => s.IsDeleted == false)
                .ToListAsync();

            var orderProductsViewModel = this.mapper.Map<ShoppingBagIndexProductsCountViewModel>(orderProducts);

            return orderProductsViewModel;
        }
    }
}
