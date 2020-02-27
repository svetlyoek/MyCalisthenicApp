namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.Web.ViewModels.Programs;
    using System.Linq;

    [ViewComponent(Name = "HomePopularPrograms")]
    public class HomePopularProgramsViewComponent : ViewComponent
    {
        private readonly IProgramsService programsService;

        public HomePopularProgramsViewComponent(IProgramsService programsService)
        {
            this.programsService = programsService;

        }

        //TODO Async
        public IViewComponentResult Invoke()
        {
            var programs = this.programsService.GetFivePopularPrograms()
                .Select(p => new HomePopularProgramsViewModel
                {
                    Title = p.Title,
                    ImageUrl = p.Image.Url
                })
                .ToList();

            return this.View(programs);
        }
    }
}
