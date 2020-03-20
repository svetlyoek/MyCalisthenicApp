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
    using MyCalisthenicApp.Services.Common;
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

        public async Task ChangeQuantity(string id, int quantity)
        {
            var userId = this.GetLoggedUserId();

            var order = await this.dbContext.Orders
                .Include(p => p.Products)
                .Where(o => o.UserId == userId)
                .Where(o => o.IsDeleted == false)
                .FirstOrDefaultAsync();

            var orderProduct = await this.dbContext.OrderProducts
                .Where(o => o.OrderId == order.Id)
                .Where(p => p.ProductId == id)
                .FirstOrDefaultAsync();

            var productToCompare = await this.dbContext
                .Products.Where(p => p.IsDeleted == false)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (quantity > orderProduct.Quantity)
            {
                orderProduct.Quantity = quantity;

                orderProduct.Price += productToCompare.Price;

                order.TotalPrice += productToCompare.Price;
            }
            else if (quantity < orderProduct.Quantity && quantity > 0)
            {
                orderProduct.Quantity = quantity;

                orderProduct.Price -= productToCompare.Price;

                order.TotalPrice -= productToCompare.Price;
            }

            this.dbContext.Update(orderProduct);

            this.dbContext.Update(order);

            await this.dbContext.SaveChangesAsync();
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
                        Quantity = ServicesConstants.DefaultShoppingBagAddedQuantity,
                        Price = product.Price,
                    };

                    currentOrder.Products.Add(orderProduct);

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

                var orderProduct = new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = ServicesConstants.DefaultShoppingBagAddedQuantity,
                    Price = product.Price,
                };

                order.Products.Add(orderProduct);

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
