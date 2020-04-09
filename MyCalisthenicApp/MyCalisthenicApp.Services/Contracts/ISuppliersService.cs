namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.Suppliers;

    public interface ISuppliersService
    {
        Task<IEnumerable<SupplierViewModel>> GetAllSuppliersAsync();

        Task<IList<SupplierAdminViewModel>> GetAllSuppliersForAdminAsync();

        Task<SupplierAdminEditViewModel> GetSupplierByIdAsync(string id);

        Task EditSupplierAsync(SupplierAdminEditViewModel inputModel);

        Task CreateSupplierAsync(SupplierAdminCreateViewModel inputModel);
    }
}
