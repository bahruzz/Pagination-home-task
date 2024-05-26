using Asp.NetIntro_MVC.Data;
using Asp.NetIntro_MVC.Extensions;
using Asp.NetIntro_MVC.Models;
using Asp.NetIntro_MVC.Services;
using Asp.NetIntro_MVC.Services.Interface;
using Asp.NetIntro_MVC.ViewModels.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Drawing;

namespace Asp.NetIntro_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISliderService _sliderService;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context,ISliderService sliderService, IWebHostEnvironment env)
        {
            _context = context;
            _sliderService = sliderService;
            _env = env; 

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sliders= await _context.Sliders.Select(m=>new SliderVM { Id=m.Id,Image=m.Image}).ToListAsync();
            return View(sliders);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!request.Image.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "Input accept only image format");
                return View();
            }
            if (!request.Image.CheckFileSize(200))
            {
                ModelState.AddModelError("Image", "Image size must be 200 kb");
                return View();
            }

            string fileName=Guid.NewGuid().ToString() + "-" + request.Image.FileName;
            string path =_env.GenerateFilePath ("img",fileName);

            await request.Image.SaveFileToLocalAsync(path);
          

            await _context.Sliders.AddAsync(new Models.Slider { Image = fileName });
            await _context.SaveChangesAsync();  

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var deletedSlider = await _context.Sliders.FindAsync(id);
            if (deletedSlider == null) return NotFound();
            string path =_env.GenerateFilePath( "img", deletedSlider.Image);
            path.DeleteFileFromLocal();
            _context.Sliders.Remove(deletedSlider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();

            return View(new SliderEditVM { Image = slider.Image });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, SliderEditVM request)
        {
            if (id == null) return BadRequest();
            var slider = await _context.Sliders.FindAsync(id);

            if (slider == null) return NotFound();

            if (request.NewImage is null) return RedirectToAction(nameof(Index));

            if (!request.NewImage.CheckFileType("image/"))
            {
                ModelState.AddModelError("NewImage", "Input can accept only image format");
                request.Image = slider.Image;
                return View(request);
            }
            if (!request.NewImage.CheckFileSize(200))
            {
                ModelState.AddModelError("NewImage", "Image size must be max 200 KB");
                request.Image = slider.Image;
                return View();
            }

            string oldPath = _env.GenerateFilePath("img", slider.Image);

            oldPath.DeleteFileFromLocal();

            string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;

            string newPath = _env.GenerateFilePath("img", fileName);

            await request.NewImage.SaveFileToLocalAsync(newPath);

            slider.Image = fileName;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
