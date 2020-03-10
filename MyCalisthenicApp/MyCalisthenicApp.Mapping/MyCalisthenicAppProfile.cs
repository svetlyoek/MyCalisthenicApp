namespace MyCalisthenicApp.Mapping.MappingConfiguration
{
    using System.Linq;

    using AutoMapper;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Models.TrainingEntities;
    using MyCalisthenicApp.ViewModels.Comments;
    using MyCalisthenicApp.ViewModels.Exercises;
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

            this.CreateMap<Exercise, ExercisesViewModel>()
                .ForMember(x => x.ImageUrl, y => y.MapFrom(src => src.Images.Select(i => i.Url).FirstOrDefault()));
        }
    }
}
