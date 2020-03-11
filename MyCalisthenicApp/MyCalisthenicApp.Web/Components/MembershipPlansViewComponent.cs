namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    [ViewComponent(Name = "MembershipPlans")]
    public class MembershipPlansViewComponent : ViewComponent
    {
        private readonly IMembershipsService membershipsService;

        public MembershipPlansViewComponent(IMembershipsService membershipsService)
        {
            this.membershipsService = membershipsService;
        }

        public IViewComponentResult Invoke()
        {
            var memberships = this.membershipsService
                .GetAllMembershipPlans()
                .GetAwaiter()
                .GetResult();

            return this.View(memberships);
        }
    }
}
