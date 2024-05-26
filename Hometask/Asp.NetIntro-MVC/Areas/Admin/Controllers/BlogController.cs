using Asp.NetIntro_MVC.Data;
using Asp.NetIntro_MVC.Extensions;
using Asp.NetIntro_MVC.Models;
using Asp.NetIntro_MVC.Services;
using Asp.NetIntro_MVC.Services.Interface;
using Asp.NetIntro_MVC.ViewModels.Blog;
using Asp.NetIntro_MVC.ViewModels.Categories;
using Asp.NetIntro_MVC.ViewModels.Sliders;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetIntro_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BlogController(IBlogService blogService,
                                  AppDbContext context,
                              IWebHostEnvironment env)
        {
            _blogService = blogService;
            _context = context;
            _env = env;
            
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _blogService.GetAllAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCreateVM blog) //model bounding adlanir
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool existBlog = await _blogService.ExistAsync(blog.Title);
            if (existBlog)
            {
                ModelState.AddModelError("Title", "This title already exist");
                return View();
            }
            if (!blog.Image.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "Input accept only image format");
                return View();
            }
            if (!blog.Image.CheckFileSize(200))
            {
                ModelState.AddModelError("Image", "Image size must be 200 kb");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "-" + blog.Image.FileName;
            string path = _env.GenerateFilePath("img", fileName);

            await blog.Image.SaveFileToLocalAsync(path);
            await _blogService.CreateAsync(new Blog { Title = blog.Title,Description=blog.Description, Image = fileName});

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            var blog = await _blogService.GetByIDAsync((int)id);
            if (blog is null) return NotFound();
            string path =_env.GenerateFilePath ( "img", blog.Image);
            path.DeleteFileFromLocal();
            await _blogService.DeleteAsync(blog);
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            Blog blog = await _blogService.GetByIDAsync((int)id);

           
            return View(blog);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return NotFound();

            return View(new BlogEditVM { Image = blog.Image });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, BlogEditVM request)
        {
            if (id == null) return BadRequest();
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null) return NotFound();

            if (request.NewImage is null) return RedirectToAction(nameof(Index));

            if (!request.NewImage.CheckFileType("image/"))
            {
                ModelState.AddModelError("NewImage", "Input can accept only image format");
                request.Image = blog.Image;
                return View(request);
            }
            if (!request.NewImage.CheckFileSize(200))
            {
                ModelState.AddModelError("NewImage", "Image size must be max 200 KB");
                request.Image = blog.Image;
                return View();
            }

            string oldPath = _env.GenerateFilePath("img", blog.Image);

            oldPath.DeleteFileFromLocal();

            string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;

            string newPath = _env.GenerateFilePath("img", fileName);

            await request.NewImage.SaveFileToLocalAsync(newPath);

            blog.Image = fileName;
            blog.Title=request.Title;
            blog.Description=request.Description;
               

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }

}
