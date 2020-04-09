namespace MyCalisthenicApp.Services.Contracts
{
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.Addresses;

    public interface IAddressesService
    {
        Task<AddressAdminEditViewModel> GetAddressByIdAsync(string id);

        Task EditAddressAsync(AddressAdminEditViewModel inputModel);
    }
}
