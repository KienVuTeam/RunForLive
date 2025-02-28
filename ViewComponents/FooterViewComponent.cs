using Microsoft.AspNetCore.Mvc;

namespace RunForLive.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}


