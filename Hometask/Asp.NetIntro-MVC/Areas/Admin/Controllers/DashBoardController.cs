using Microsoft.AspNetCore.Mvc;

namespace Asp.NetIntro_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashBoardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
