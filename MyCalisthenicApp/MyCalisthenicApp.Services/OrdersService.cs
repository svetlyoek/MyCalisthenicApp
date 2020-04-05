namespace MyCalisthenicApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.Models.ShopEntities.Enums;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Addresses;
    using MyCalisthenicApp.ViewModels.Orders;
    using MyCalisthenicApp.ViewModels.Suppliers;

    public class OrdersService : IOrdersService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;

        public OrdersService(MyCalisthenicAppDbContext dbContext, IMapper mapper, IUsersService usersService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.usersService = usersService;
        }

        public async Task ChangeQuantityAsync(string id, int quantity)
        {
            var userId = this.usersService.GetLoggedUserId();

            var order = await this.dbContext.Orders
                .Include(p => p.Products)
                .Where(o => o.UserId == userId)
                .Where(o => o.IsDeleted == false)
                .Where(o => o.Status != OrderStatus.Sent)
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

        public async Task CreateMembershipToOrderAsync(decimal? price)
        {
            var userId = this.usersService.GetLoggedUserId();

            var userFromDb = await this.usersService.GetLoggedUserByIdAsync(userId);

            if (userFromDb.HasMembership)
            {
                return;
            }

            var orderFromDb = await this.dbContext.Orders
                .Where(o => o.UserId == userId)
                .Where(o => o.IsDeleted == false)
                .Where(o => o.Status != OrderStatus.Sent)
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

                userFromDb.Orders.Add(order);

                this.dbContext.Update(userFromDb);

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

        public async Task<bool> CreateOrderAsync(Product product)
        {
            decimal discount = ServicesConstants.ProductsDiscountPercentage;

            var price = product.Price - (product.Price * discount);

            if (product.IsSoldOut)
            {
                return false;
            }

            var userId = this.usersService.GetLoggedUserId();

            var userFromDb = await this.usersService.GetLoggedUserByIdAsync(userId);

            if (this.dbContext.Orders.Any(o => o.UserId == userId && o.Status != OrderStatus.Sent))
            {
                var currentOrder = await this.dbContext.Orders
                    .Where(o => o.Status != OrderStatus.Sent)
                    .Where(o => o.UserId == userId)
                    .FirstOrDefaultAsync();

                if (userFromDb.HasCoupon)
                {
                    currentOrder.TotalPrice += price;
                }
                else
                {
                    currentOrder.TotalPrice += product.Price;
                }

                if (!this.dbContext.OrderProducts.Any(o => o.OrderId == currentOrder.Id
                 && o.ProductId == product.Id))
                {
                    var orderProduct = new OrderProduct
                    {
                        OrderId = currentOrder.Id,
                        ProductId = product.Id,
                        Quantity = ServicesConstants.DefaultShoppingBagAddedQuantity,
                        Price = userFromDb.HasCoupon == true ? price : product.Price,
                    };

                    currentOrder.Products.Add(orderProduct);

                    await this.dbContext.OrderProducts.AddAsync(orderProduct);
                    await this.dbContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                var order = new Order
                {
                    PaymentStatus = PaymentStatus.Unpaid,
                    Status = OrderStatus.Processing,
                    TotalPrice = userFromDb.HasCoupon == true ? price : product.Price,
                    User = userFromDb,
                    UserId = userId,
                };

                var orderProduct = new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = ServicesConstants.DefaultShoppingBagAddedQuantity,
                    Price = userFromDb.HasCoupon == true ? price : product.Price,
                };

                order.Products.Add(orderProduct);

                await this.dbContext.Orders.AddAsync(order);
                await this.dbContext.SaveChangesAsync();

                return true;
            }
        }

        public async Task<int> ShoppingBagProductsCountAsync()
        {
            var userId = this.usersService.GetLoggedUserId();

            if (userId != null)
            {
                var order = await this.dbContext.Orders
                   .Where(o => o.IsDeleted == false)
                   .Where(o => o.Status != OrderStatus.Sent)
                   .FirstOrDefaultAsync(o => o.UserId == userId);

                if (order == null || order.Status == OrderStatus.Sent)
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

        public async Task CreateAddressToOrderAsync(AddressInputViewModel inputModel)
        {
            var userId = this.usersService.GetLoggedUserId();

            var userFromDb = await this.usersService.GetLoggedUserByIdAsync(userId);

            var order = await this.dbContext.Orders
                .Where(o => o.IsDeleted == false)
                .Where(o => o.Status != OrderStatus.Sent)
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
            var userId = this.usersService.GetLoggedUserId();

            var order = await this.dbContext.Orders
                  .Where(o => o.IsDeleted == false)
                  .Where(o => o.Status != OrderStatus.Sent)
                  .FirstOrDefaultAsync(o => o.UserId == userId);

            if (order == null)
            {
                return;
            }

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

        public async Task<OrderCheckoutViewModel> GetOrderToSendAsync()
        {
            var userId = this.usersService.GetLoggedUserId();

            var order = await this.dbContext.Orders
                .Where(o => o.IsDeleted == false)
                .Where(o => o.UserId == userId)
                .Where(o => o.Status != OrderStatus.Sent)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                var orderModel = new OrderCheckoutViewModel();

                return orderModel;
            }

            var orderViewModel = this.mapper.Map<OrderCheckoutViewModel>(order);

            return orderViewModel;
        }

        public async Task<bool> SendOrderAsync(string id)
        {
            var userId = this.usersService.GetLoggedUserId();

            var userFromDb = await this.usersService.GetLoggedUserByIdAsync(userId);

            var order = await this.dbContext.Orders
                .Where(o => o.IsDeleted == false)
                .Where(o => o.Status != OrderStatus.Sent)
                .Where(o => o.UserId == userId)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return false;
            }

            if (order.MembershipPrice != null && order != null)
            {
                userFromDb.HasMembership = true;

                userFromDb.MembershipExpirationDate = DateTime.UtcNow.AddYears(1);

                this.dbContext.Update(userFromDb);

                await this.dbContext.SaveChangesAsync();
            }

            if (order.TotalPrice > 0 && order.DeliveryAddressId != null && order.DeliveryPrice != null)
            {
                order.DisptachDate = DateTime.UtcNow.AddDays(1);

                order.PaymentStatus = PaymentStatus.Unpaid;

                order.PaymentType = PaymentType.CashOnDelivery;

                order.Status = OrderStatus.Sent;

                this.dbContext.Update(order);

                await this.dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                order.PaymentStatus = PaymentStatus.Denied;

                this.dbContext.Update(order);

                await this.dbContext.SaveChangesAsync();

                return false;
            }
        }

        public async Task<OrderAdminEditViewModel> GetOrderByIdAsync(string id)
        {
            var order = await this.dbContext.Orders
                 .FirstOrDefaultAsync(o => o.Id == id);

            var orderViewModel = this.mapper.Map<OrderAdminEditViewModel>(order);

            return orderViewModel;
        }

        public async Task EditOrderAsync(OrderAdminEditViewModel inputModel)
        {
            var order = await this.dbContext.Orders
                .Where(c => c.Id == inputModel.Id)
                .FirstOrDefaultAsync();

            Enum.TryParse(inputModel.PaymentStatus, true, out PaymentStatus paymentStatus);

            Enum.TryParse(inputModel.Status, true, out OrderStatus orderStatus);

            Enum.TryParse(inputModel.PaymentType, true, out PaymentType paymentType);

            order.IsDeleted = inputModel.IsDeleted;

            order.DeletedOn = inputModel.DeletedOn;

            order.ModifiedOn = inputModel.ModifiedOn;

            order.CreatedOn = inputModel.CreatedOn;

            order.MembershipPrice = inputModel.MembershipPrice;

            order.PaymentStatus = paymentStatus;

            order.Status = orderStatus;

            order.PaymentType = paymentType;

            order.EstimatedDeliveryDate = inputModel.EstimatedDeliveryDate;

            order.DisptachDate = inputModel.DisptachDate;

            order.TotalPrice = inputModel.TotalPrice;

            order.Discount = inputModel.Discount;

            order.DeliveryPrice = inputModel.DeliveryPrice;

            order.EasyPayNumber = inputModel.EasyPayNumber;

            order.EasyPayNumber = inputModel.EasyPayNumber;

            order.UserId = inputModel.UserId;

            order.DeliveryAddressId = inputModel.DeliveryAddressId;

            this.dbContext.Update(order);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IList<SupplierAdminViewModel>> GetAllSuppliersForAdminAsync()
        {
            var suppliers = await this.dbContext.Suppliers
                .ToListAsync();

            var suppliersViewModel = this.mapper.Map<IList<SupplierAdminViewModel>>(suppliers);

            return suppliersViewModel;
        }

        public async Task EditSupplierAsync(SupplierAdminEditViewModel inputModel)
        {
            var supplier = await this.dbContext.Suppliers
                .FirstOrDefaultAsync(a => a.Id == inputModel.Id);

            supplier.IsDeleted = inputModel.IsDeleted;

            supplier.DeletedOn = inputModel.DeletedOn;

            supplier.CreatedOn = inputModel.CreatedOn;

            supplier.ModifiedOn = inputModel.ModifiedOn;

            supplier.Name = inputModel.Name;

            supplier.PriceToHome = inputModel.PriceToHome;

            supplier.PriceToOffice = inputModel.PriceToOffice;

            supplier.LogoUrl = inputModel.LogoUrl;

            supplier.IsDefault = inputModel.IsDefault;

            this.dbContext.Update(supplier);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<SupplierAdminEditViewModel> GetSupplierByIdAsync(string id)
        {
            var supplier = await this.dbContext.Suppliers
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            var supplierViewModel = this.mapper.Map<SupplierAdminEditViewModel>(supplier);

            return supplierViewModel;
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
