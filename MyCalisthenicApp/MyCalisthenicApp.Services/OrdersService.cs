namespace MyCalisthenicApp.Services
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

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
            var userId = this.GetLoggedUserId();
            var userFromDb = await this.dbContext.Users.FindAsync(userId);

            if (this.dbContext.Orders.Any(o => o.UserId == userId))
            {
                var currentOrder = await this.dbContext.Orders.FirstOrDefaultAsync(o => o.UserId == userId);

                currentOrder.TotalPrice += product.Price;

                if (!this.dbContext.OrderProducts.Any(o => o.OrderId == currentOrder.Id
                 && o.ProductId == product.Id))
                {
                    var orderProduct = new OrderProduct
                    {
                        OrderId = currentOrder.Id,
                        ProductId = product.Id,
                        Quantity = 1,
                        Price = product.Price,
                    };

                    await this.dbContext.OrderProducts.AddAsync(orderProduct);
                    await this.dbContext.SaveChangesAsync();
                }
            }
            else
            {
                var order = new Order
                {
                    PaymentStatus = PaymentStatus.Unpaid,
                    Status = OrderStatus.Processing,
                    TotalPrice = product.Price,
                    User = userFromDb,
                    UserId = userId,
                };

                userFromDb.Orders.Add(order);

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

        public async Task<int> ShoppingBagProductsCount()
        {
            var userId = this.GetLoggedUserId();

            if (userId != null)
            {
                var order = await this.dbContext.Orders
                   .Where(o => o.IsDeleted == false)
                   .FirstOrDefaultAsync(o => o.UserId == userId);

                if (order == null)
                {
                    return 0;
                }
                else
                {
                    var products = await this.dbContext.OrderProducts
                   .Where(op => op.OrderId == order.Id)
                   .ToListAsync();

                    var productsCount = products.Count;
                    return productsCount;
                }
            }
            else
            {
                return 0;
            }
        }

        private string GetLoggedUserId()
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
