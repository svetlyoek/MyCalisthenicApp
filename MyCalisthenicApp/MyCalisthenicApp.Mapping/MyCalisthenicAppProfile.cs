namespace MyCalisthenicApp.Mapping.MappingConfiguration
{
    using AutoMapper;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.ViewModels.Home;
    using MyCalisthenicApp.ViewModels.Programs;
    using System.Linq;

    public class MyCalisthenicAppProfile : Profile
    {
        public MyCalisthenicAppProfile()
        {
            this.CreateMap<ContactRequestInputViewModel, UserRequest>();

            this.CreateMap<Program, HomePopularProgramsViewModel>()
                .ForMember(x => x.ImageUrl, y => y.MapFrom(src => src.Images.Select(i => i.Url).FirstOrDefault()));

        }
    }
}
