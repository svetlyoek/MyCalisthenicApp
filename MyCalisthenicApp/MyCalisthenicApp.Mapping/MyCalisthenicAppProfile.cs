namespace MyCalisthenicApp.Mapping.MappingConfiguration
{
    using System.Linq;

    using AutoMapper;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.BlogEntities;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.Models.TrainingEntities;
    using MyCalisthenicApp.ViewModels.Exercises;
    using MyCalisthenicApp.ViewModels.Memberships;
    using MyCalisthenicApp.ViewModels.Posts;
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

            this.CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(x => x.Category, y => y.MapFrom(src => src.Category.Name))
                 .ForMember(x => x.Size, y => y.MapFrom(src => src.Size.ToString()))
                 .ForMember(x => x.Color, y => y.MapFrom(src => src.Color.ToString()));

            this.CreateMap<Post, PopularPostsHomeViewModel>()
                .ForMember(x => x.ImageUrl, y => y.MapFrom(src => src.Images.Select(i => i.Url).FirstOrDefault()))
                .ForMember(x => x.AuthorName, y => y.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName));

            this.CreateMap<Post, PostDetailsViewModel>()
                .ForMember(x => x.ImageUrl, y => y.MapFrom(src => src.Images.Select(i => i.Url).FirstOrDefault()))
                .ForMember(x => x.Author, y => y.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName));

            this.CreateMap<Post, PostDetailsSidebarViewModel>()
                .ForMember(x => x.ImageUrl, y => y.MapFrom(src => src.Images.Select(i => i.Url).FirstOrDefault()));

            this.CreateMap<Product, ProductsShoppingBagViewModel>()
                .ForMember(x => x.ImageUrl, y => y.MapFrom(src => src.Images.Select(i => i.Url).FirstOrDefault()))
                .ForMember(x => x.Price, y => y.MapFrom(src => src.Orders.Where(p => p.ProductId == src.Id).Select(p => p.Price).FirstOrDefault()))
                .ForMember(x => x.Quantity, y => y.MapFrom(src => src.Orders.Where(p => p.ProductId == src.Id).Select(p => p.Quantity).FirstOrDefault()));

        }
    }
}
