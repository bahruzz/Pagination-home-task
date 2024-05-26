using Asp.NetIntro_MVC.Data;
using Asp.NetIntro_MVC.Models;
using Asp.NetIntro_MVC.Services.Interface;
using Asp.NetIntro_MVC.ViewModels;
using Asp.NetIntro_MVC.ViewModels.Baskets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Diagnostics.Eventing.Reader;

namespace Asp.NetIntro_MVC.Controllers
{
    public class HomeController:Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IBlogService _blogService;
        private readonly IExpertService _expertService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _accessor;
        public HomeController(ISliderService sliderservice,
                              IBlogService blogService,
                              IExpertService expertService,
                              ICategoryService categoryService,
                              IProductService productService,
                              IHttpContextAccessor accessor)
        {
            _sliderService = sliderservice;
            _blogService = blogService;
            _expertService = expertService;
            _categoryService = categoryService;
            _productService = productService;
            _accessor = accessor;
        }

        public async Task<IActionResult> Index()
        {
            _accessor.HttpContext.Response.Cookies.Append("Name", "Reshad");
            HomeVM model = new HomeVM()
            {
                Blogs=await _blogService.GetAllAsync(3),
                Experts=await _expertService.GetAllAsync(),
                Categories=await _categoryService.GetAllAsync(),    
                Products=await _productService.GetAllWithImagesAsync(),
            };
           
            return View(model);

             
        }

        [HttpPost]
      

        public async Task<IActionResult> AddProductToBasket(int? id)
        {
            if (id is null) return BadRequest();

            var product=await _productService.GetByIdAsync((int)id);  
            
            if (product is null) return NotFound();

            List<BasketVM> basketDatas = new();

            if (_accessor.HttpContext.Request.Cookies["basket"]is not null)
            {
                basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
            }

            var existBasketData=basketDatas.FirstOrDefault(m=>m.Id==id);
            if (existBasketData is not null)
            {
                existBasketData.Count++;

            }
            else
            {
                basketDatas.Add(new BasketVM()
                {
                    Id = (int)id,
                    Price = product.Price,
                    Count = 1
                });


            }


            _accessor.HttpContext.Response.Cookies.Append("basket",JsonConvert.SerializeObject(basketDatas));

            int count=basketDatas.Sum(m=>m.Count);
            decimal totalPrice=basketDatas.Sum(m=>m.Count*m.Price);


            return Ok(new { count, totalPrice });
        }
        

        

        
        
       
    }
}
