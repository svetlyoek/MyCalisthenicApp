namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    [ViewComponent(Name = "HomePopularPrograms")]
    public class HomePopularProgramsViewComponent : ViewComponent
    {
        private readonly IProgramsService programsService;

        public HomePopularProgramsViewComponent(IProgramsService programsService)
        {
            this.programsService = programsService;
        }

        public IViewComponentResult Invoke()
        {
            var programs = this.programsService.GetFivePopularProgramsAsync()
                .GetAwaiter()
                .GetResult();

            return this.View(programs);
        }
    }
}
