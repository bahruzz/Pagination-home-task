using Asp.NetIntro_MVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetIntro_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArchiveController : Controller
    {
        private readonly ICategoryService _categoryService;

        public ArchiveController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> CategoryArchive()
        {
            return View(await _categoryService.GetAllArchiveAsync());
        }
    }
}
