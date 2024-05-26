using Asp.NetIntro_MVC.Data;
using Asp.NetIntro_MVC.Models;
using Asp.NetIntro_MVC.Services.Interface;
using Asp.NetIntro_MVC.ViewModels.Blog;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace Asp.NetIntro_MVC.Services
{
    public class BlogService : IBlogService

    {
        private readonly AppDbContext _context;

        public BlogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Blog blog)
        {
            await _context.AddAsync(blog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Blog blog)
        {
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string title)
        {
            return await _context.Blogs.AnyAsync(m => m.Title.Trim() == title.Trim());
        }

        public async Task<bool> ExistByIdAsync(int id, string title)
        {
            return await _context.Blogs.AnyAsync(m => m.Title.Trim() == title.Trim() && m.Id != id);
        }

        public async Task<IEnumerable<BlogVM>> GetAllAsync(int? take=null)
        {
            IEnumerable<Blog> blogs;
            if (take is null)
            {
                blogs=await _context.Blogs.ToListAsync();
            }
            else
            {
                blogs=await _context.Blogs.Take((int) take).ToListAsync();  
            }

            return blogs.Select(m => new BlogVM {Id=m.Id, Title = m.Title, Description = m.Description, Image = m.Image, CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy") });


        }

        public async Task<Blog> GetByIDAsync(int id)
        {
            var a= await _context.Blogs.Where(m=>m.Id==id).FirstOrDefaultAsync();
            return a;
        }
    }
}
