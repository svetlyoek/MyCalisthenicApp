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
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Suppliers;

    public class SuppliersService : ISuppliersService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;

        public SuppliersService(MyCalisthenicAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SupplierViewModel>> GetAllSuppliersAsync()
        {
            var suppliers = await this.dbContext.Suppliers
                 .Where(s => s.IsDeleted == false)
                 .ToListAsync();

            var suppliersViewModel = this.mapper.Map<IEnumerable<SupplierViewModel>>(suppliers);

            return suppliersViewModel;
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

            if (supplier == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidSupplierId, inputModel.Id));
            }

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

            if (supplier == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidSupplierId, id));
            }

            var supplierViewModel = this.mapper.Map<SupplierAdminEditViewModel>(supplier);

            return supplierViewModel;
        }

        public async Task CreateSupplierAsync(SupplierAdminCreateViewModel inputModel)
        {
            var supplier = new Supplier
            {
                Name = inputModel.Name,
                PriceToHome = inputModel.PriceToHome,
                PriceToOffice = inputModel.PriceToOffice,
                LogoUrl = inputModel.LogoUrl,
            };

            await this.dbContext.Suppliers.AddAsync(supplier);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
