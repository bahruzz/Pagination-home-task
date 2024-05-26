
using Asp.NetIntro_MVC.Models;
using Asp.NetIntro_MVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetIntro_MVC.Controllers
{
    public class ProductController : Controller
    {
     private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index(int? id)
        { if(id is null)
            {
                return BadRequest();
            }
           Product product = await _productService.GetByIdWithAllDatasAsync((int)id);
            if (product == null) return NotFound();
            return View(product);
        }
    }
}
