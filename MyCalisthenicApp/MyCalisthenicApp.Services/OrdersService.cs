namespace MyCalisthenicApp.Services
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.Models.ShopEntities.Enums;
    using MyCalisthenicApp.Services.Contracts;

    public class OrdersService : IOrdersService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public OrdersService(MyCalisthenicAppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateOrderAsync(Product product)
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userFromDb = await this.dbContext.Users.FindAsync(userId);

            if (this.dbContext.Orders.Any(o => o.UserId == userId))
            {
                var currentOrder = await this.dbContext.Orders.FirstOrDefaultAsync(o => o.UserId == userId);

                currentOrder.TotalPrice += product.Price;

                currentOrder.Products.Add(new OrderProduct
                {
                    OrderId = currentOrder.Id,
                    ProductId = product.Id,
                    Quantity = 1,
                    Price = product.Price,
                });

                this.dbContext.Update(currentOrder);
                await this.dbContext.SaveChangesAsync();
            }
            else
            {
                var order = new Order
                {
                    PaymentStatus = PaymentStatus.Unpaid,
                    TotalPrice = product.Price,
                    User = userFromDb,
                    UserId = userId,
                };

                order.Products.Add(new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = 1,
                    Price = product.Price,
                });

                await this.dbContext.Orders.AddAsync(order);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<int> ShoppingBagProducts()
        {
            var productsCount = await this.dbContext.OrderProducts
                .CountAsync();

            return productsCount;
        }
    }
}
