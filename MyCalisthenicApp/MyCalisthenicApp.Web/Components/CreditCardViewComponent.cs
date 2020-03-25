namespace MyCalisthenicApp.Web.Components
{
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name ="CreditCard")]
    public class CreditCardViewComponent : ViewComponent
    {
        public CreditCardViewComponent()
        {
            //TODO
            //Inject service here
        }

        //TODO Async
        public IViewComponentResult Invoke()
        {
            //TODO View-list from latest n count of posts

            return this.View();
        }
    }
}
