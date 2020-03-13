namespace MyCalisthenicApp.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Services.Contracts;

    public class ImagesService : IImagesService
    {
        private readonly MyCalisthenicAppDbContext dbCotext;

        public ImagesService(MyCalisthenicAppDbContext dbCotext)
        {
            this.dbCotext = dbCotext;
        }

        public async Task<IEnumerable<string>> GetImagesByProductIdAsync(string id)
        {
            var images = await this.dbCotext
                .Images.Where(i => i.ProductId == id)
                .Select(i => i.Url)
                .ToListAsync();

            return images;
        }
    }
}
