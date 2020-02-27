namespace MyCalisthenicApp.Web.MappingConfiguration
{
    using AutoMapper;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Web.ViewModels.Home;
    using MyCalisthenicApp.Web.ViewModels.Programs;

    public class MyCalisthenicAppProfile : Profile
    {
        public MyCalisthenicAppProfile()
        {
            this.CreateMap<ContactRequestInputViewModel, UserRequest>();

            this.CreateMap<Program, HomePopularProgramsViewModel>();

        }
    }
}
