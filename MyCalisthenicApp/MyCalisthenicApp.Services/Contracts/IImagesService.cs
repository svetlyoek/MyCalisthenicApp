namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.Images;

    public interface IImagesService
    {
        Task<IEnumerable<string>> GetImagesByProductIdAsync(string id);

        Task<IList<ImagesAdminViewModel>> GetAllImagesForAdminAsync();

        Task<ImageAdminEditViewModel> GetImageByIdAsync(string id);

        Task EditImageAsync(ImageAdminEditViewModel inputModel);
    }
}
