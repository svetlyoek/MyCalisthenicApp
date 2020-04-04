namespace MyCalisthenicApp.Mapping.MappingConfiguration
{
    using System.Linq;

    using AutoMapper;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.BlogEntities;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.Models.TrainingEntities;
    using MyCalisthenicApp.ViewModels.Addresses;
    using MyCalisthenicApp.ViewModels.Cities;
    using MyCalisthenicApp.ViewModels.Comments;
    using MyCalisthenicApp.ViewModels.Exercises;
    using MyCalisthenicApp.ViewModels.Images;
    using MyCalisthenicApp.ViewModels.Memberships;
    using MyCalisthenicApp.ViewModels.OrderProducts;
    using MyCalisthenicApp.ViewModels.Orders;
    using MyCalisthenicApp.ViewModels.Posts;
    using MyCalisthenicApp.ViewModels.Products;
    using MyCalisthenicApp.ViewModels.Programs;
    using MyCalisthenicApp.ViewModels.Requests;
    using MyCalisthenicApp.ViewModels.Suppliers;
    using MyCalisthenicApp.ViewModels.Users;

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

            this.CreateMap<Supplier, SupplierViewModel>();

            this.CreateMap<Order, OrderCheckoutViewModel>();

            this.CreateMap<Address, AddressAdminEditViewModel>();

            this.CreateMap<Address, AddressesAdminViewModel>();

            this.CreateMap<City, CityAdminViewModel>();

            this.CreateMap<CityAdminViewModel, City>();

            this.CreateMap<OrderProduct, OrderProductsAdminViewModel>();

            this.CreateMap<Order, OrdersAdminViewModel>()
                .ForMember(x => x.Status, y => y.MapFrom(src => src.Status.ToString()))
                .ForMember(x => x.PaymentStatus, y => y.MapFrom(src => src.PaymentStatus.ToString()))
                .ForMember(x => x.PaymentType, y => y.MapFrom(src => src.PaymentType.ToString()));

            this.CreateMap<Order, OrderAdminEditViewModel>()
                .ForMember(x => x.Status, y => y.MapFrom(src => src.Status.ToString()))
                .ForMember(x => x.PaymentStatus, y => y.MapFrom(src => src.PaymentStatus.ToString()))
                .ForMember(x => x.PaymentType, y => y.MapFrom(src => src.PaymentType.ToString()));

            this.CreateMap<Product, OrderProductViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(src => src.Name));

            this.CreateMap<ApplicationUser, UsersAdminViewModel>();

            this.CreateMap<Comment, CommentAdminViewModel>()
                .ForMember(x => x.AuthorName, y => y.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName));

            this.CreateMap<Product, ProductsAdminViewModel>()
              .ForMember(x => x.Size, y => y.MapFrom(src => src.Size.ToString()))
              .ForMember(x => x.Color, y => y.MapFrom(src => src.Color.ToString()))
              .ForMember(x => x.Sort, y => y.MapFrom(src => src.Sort.ToString()))
              .ForMember(x => x.Type, y => y.MapFrom(src => src.Type.ToString()))
              .ForMember(x => x.ImagesUrl, y => y.MapFrom(src => src.Images.Select(i => i.Url).ToList()));

            this.CreateMap<Post, PostsAdminViewModel>()
                .ForMember(x => x.AuthorName, y => y.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName))
                .ForMember(x => x.Type, y => y.MapFrom(src => src.Type.ToString()))
                .ForMember(x => x.ImagesUrl, y => y.MapFrom(src => src.Images.Select(i => i.Url).ToList()));

            this.CreateMap<Program, ProgramsAdminViewModel>()
               .ForMember(x => x.MembershipType, y => y.MapFrom(src => src.MembershipType.ToString()))
               .ForMember(x => x.Type, y => y.MapFrom(src => src.Type.ToString()))
               .ForMember(x => x.ImagesUrl, y => y.MapFrom(src => src.Images.Select(i => i.Url).ToList()));

            this.CreateMap<Exercise, ExercisesAdminViewModel>()
                  .ForMember(x => x.ImagesUrl, y => y.MapFrom(src => src.Images.Select(i => i.Url).ToList()));

            this.CreateMap<UserRequest, RequestsAdminViewModel>();

            this.CreateMap<Membership, MembershipsAdminViewModel>();

            this.CreateMap<ApplicationUser, UserAdminEditViewModel>();

            this.CreateMap<OrderProductAdminEditViewModel, OrderProduct>();

            this.CreateMap<OrderProduct, OrderProductAdminEditViewModel>();

            this.CreateMap<Comment, CommentAdminEditViewModel>();

            this.CreateMap<Product, ProductAdminEditViewModel>()
                   .ForMember(x => x.Size, y => y.MapFrom(src => src.Size.ToString()))
                   .ForMember(x => x.Color, y => y.MapFrom(src => src.Color.ToString()))
                   .ForMember(x => x.Sort, y => y.MapFrom(src => src.Sort.ToString()))
                   .ForMember(x => x.Type, y => y.MapFrom(src => src.Type.ToString()));

            this.CreateMap<Supplier, SupplierAdminViewModel>();

            this.CreateMap<Supplier, SupplierAdminEditViewModel>();

        }
    }
}
