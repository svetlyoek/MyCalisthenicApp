namespace MyCalisthenicApp.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.Models.ShopEntities.Enums;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Orders;
    using MyCalisthenicApp.ViewModels.Suppliers;

    public class OrdersService : IOrdersService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public OrdersService(MyCalisthenicAppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
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

        public async Task CreateMembershipToOrder(decimal? price)
        {
            var userId = this.GetLoggedUserId();

            var userFromDb = await this.GetLoggedUserById(userId);

            if (userFromDb.HasMembership)
            {
                return;
            }

            var orderFromDb = await this.dbContext.Orders
                .Where(o => o.UserId == userId)
                .Where(o => o.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (orderFromDb == null)
            {
                var order = new Order
                {
                    PaymentStatus = PaymentStatus.Unpaid,
                    Status = OrderStatus.Processing,
                    TotalPrice = 0M,
                    User = userFromDb,
                    UserId = userId,
                    MembershipPrice = price,
                };

                await this.dbContext.Orders.AddAsync(order);

                await this.dbContext.SaveChangesAsync();
            }
            else
            {
                orderFromDb.MembershipPrice = price;

                this.dbContext.Update(orderFromDb);

                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task CreateOrderAsync(Product product)
        {
            if (product.IsSoldOut)
            {
                return;
            }

            var userId = this.GetLoggedUserId();

            var userFromDb = await this.GetLoggedUserById(userId);

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

        public async Task CreateAddressToOrder(AddressInputViewModel inputModel)
        {
            var userId = this.GetLoggedUserId();

            var userFromDb = await this.GetLoggedUserById(userId);

            var order = await this.dbContext.Orders
                .Where(o => o.IsDeleted == false)
                .FirstOrDefaultAsync(o => o.UserId == userId);

            if (order == null)
            {
                var newOrder = new Order
                {
                    UserId = userId,
                    PaymentStatus = PaymentStatus.Unpaid,
                };

                await this.dbContext.Orders.AddAsync(newOrder);

                await this.dbContext.SaveChangesAsync();

                order = newOrder;
            }

            var currentAddress = await this.GetAddress(inputModel, userId);

            if (order.DeliveryAddressId == null || currentAddress == null)
            {
                var city = new City();

                if (!this.dbContext.Cities.Any(c => c.PostCode == inputModel.PostCode
                 && c.Name == inputModel.City))
                {
                    city = new City
                    {
                        Name = inputModel.City,
                        PostCode = inputModel.PostCode,
                    };

                    await this.dbContext.Cities.AddAsync(city);

                    await this.dbContext.SaveChangesAsync();
                }
                else
                {
                    city = await this.dbContext.Cities
                        .FirstOrDefaultAsync(c => c.Name == inputModel.City
                        && c.PostCode == inputModel.PostCode);
                }

                var address = new Address
                {
                    Country = inputModel.Country,
                    Description = inputModel.DeliveryInstructions,
                    Street = inputModel.Address,
                    BuildingNumber = inputModel.BuildingNumber,
                    CityId = city.Id,
                    UserId = userId,
                };

                await this.dbContext.Addresses.AddAsync(address);

                await this.dbContext.SaveChangesAsync();

                userFromDb.Addresses.Add(address);

                address.Orders.Add(order);

                order.DeliveryAddressId = address.Id;

                this.dbContext.Update(order);

                city.Addresses.Add(address);

                this.dbContext.Update(address);

                this.dbContext.Update(city);

                this.dbContext.Update(userFromDb);

                await this.dbContext.SaveChangesAsync();

                return;
            }
            else if (currentAddress != null && inputModel.DeliveryInstructions != null)
            {
                currentAddress.Description = inputModel.DeliveryInstructions;

                this.dbContext.Update(currentAddress);

                await this.dbContext.SaveChangesAsync();

                return;
            }
            else if (currentAddress != null)
            {
                return;
            }
        }

        public async Task SetDeliveryPriceToOrderAsync(decimal deliveryPrice)
        {
            var userId = this.GetLoggedUserId();

            var order = await this.dbContext.Orders
                  .Where(o => o.IsDeleted == false)
                  .FirstOrDefaultAsync(o => o.UserId == userId);

            order.DeliveryPrice = deliveryPrice;

            this.dbContext.Update(order);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SupplierViewModel>> GetAllSuppliersAsync()
        {
            var suppliers = await this.dbContext.Suppliers
                 .Where(s => s.IsDeleted == false)
                 .ToListAsync();

            var suppliersViewModel = this.mapper.Map<IEnumerable<SupplierViewModel>>(suppliers);

            return suppliersViewModel;
        }

        private string GetLoggedUserId()
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }

        private async Task<ApplicationUser> GetLoggedUserById(string userId)
        {
            var userFromDb = await this.dbContext.Users.
                Where(u => u.IsDeleted == false)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return userFromDb;
        }

        private async Task<Address> GetAddress(AddressInputViewModel inputModel, string userId)
        {
            var address = await this.dbContext.Addresses
                    .Where(a => a.IsDeleted == false)
                    .Where(a => a.UserId == userId)
                    .Where(a => a.Country == inputModel.Country)
                    .Where(a => a.City.Name == inputModel.City)
                    .Where(a => a.BuildingNumber == inputModel.BuildingNumber)
                    .Where(a => a.City.PostCode == inputModel.PostCode)
                    .Where(a => a.Street == inputModel.Address)
                    .FirstOrDefaultAsync();

            return address;
        }


    }
}
