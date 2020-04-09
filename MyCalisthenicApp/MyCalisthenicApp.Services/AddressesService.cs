namespace MyCalisthenicApp.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Addresses;

    public class AddressesService : IAddressesService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;

        public AddressesService(MyCalisthenicAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task EditAddressAsync(AddressAdminEditViewModel inputModel)
        {
            var city = await this.dbContext.Cities
                .Where(c => c.Id == inputModel.CityId)
                .FirstOrDefaultAsync();

            var address = await this.dbContext.Addresses
                .FirstOrDefaultAsync(a => a.Id == inputModel.Id);

            if (city == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidCityId, inputModel.CityId));
            }

            if (address == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidAddressId, inputModel.Id));
            }

            address.IsDeleted = inputModel.IsDeleted;

            address.DeletedOn = inputModel.DeletedOn;

            address.CreatedOn = inputModel.CreatedOn;

            address.ModifiedOn = inputModel.ModifiedOn;

            address.Street = inputModel.Street;

            address.Country = inputModel.Country;

            address.Description = inputModel.Description;

            address.BuildingNumber = inputModel.BuildingNumber;

            address.CityId = inputModel.CityId;

            address.UserId = inputModel.UserId;

            address.City = city;

            this.dbContext.Update(address);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddressAdminEditViewModel> GetAddressByIdAsync(string id)
        {
            var address = await this.dbContext.Addresses
                .Include(a => a.City)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (address == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidAddressId, id));
            }

            var addressViewModel = this.mapper.Map<AddressAdminEditViewModel>(address);

            return addressViewModel;
        }
    }
}
