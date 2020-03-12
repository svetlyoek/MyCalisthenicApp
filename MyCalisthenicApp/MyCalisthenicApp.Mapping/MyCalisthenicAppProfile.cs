namespace MyCalisthenicApp.Mapping.MappingConfiguration
{
    using System.Linq;

    using AutoMapper;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.Models.TrainingEntities;
    using MyCalisthenicApp.ViewModels.Exercises;
    using MyCalisthenicApp.ViewModels.Memberships;
    using MyCalisthenicApp.ViewModels.Products;
    using MyCalisthenicApp.ViewModels.Programs;

    public class MyCalisthenicAppProfile : Profile
    {
        public MyCalisthenicAppProfile()
        {
            this.CreateMap<Program, HomePopularProgramsViewModel>()
                .ForMember(x => x.ImageUrl, y => y.MapFrom(src => src.Images.Select(i => i.Url).FirstOrDefault()));

            this.CreateMap<Program, ProgramDetailsViewModel>()
                .ForMember(x => x.ImageUrl, y => y.MapFrom(src => src.Images.Select(i => i.Url).FirstOrDefault()))
                .ForMember(x => x.Type, y => y.MapFrom(src => src.Type.ToString()));

            this.CreateMap<Program, ProgramViewModel>()
                .ForMember(x => x.ImageUrl, y => y.MapFrom(src => src.Images.Select(i => i.Url).FirstOrDefault()))
                .ForMember(x => x.Type, y => y.MapFrom(src => src.Type.ToString()));

            this.CreateMap<Exercise, ExercisesViewModel>()
                .ForMember(x => x.ImageUrl, y => y.MapFrom(src => src.Images.Select(i => i.Url).FirstOrDefault()));

            this.CreateMap<Membership, MembershipPlanViewModel>();

            this.CreateMap<Product, ProductsHomePopularViewModel>()
                .ForMember(x => x.ImageUrl, y => y.MapFrom(p => p.Images.Select(i => i.Url).FirstOrDefault()))
                .ForMember(x => x.Category, y => y.MapFrom(p => p.Category.Name));

            this.CreateMap<Product, ProductsViewModel>()
                .ForMember(x => x.ImageUrl, y => y.MapFrom(src => src.Images.Select(i => i.Url).FirstOrDefault()))
                .ForMember(x => x.Category, y => y.MapFrom(src => src.Category.Name))
                .ForMember(x => x.Sort, y => y.MapFrom(src => src.Sort.ToString()));
        }
    }
}
