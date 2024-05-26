using Asp.NetIntro_MVC.Data;
using Asp.NetIntro_MVC.Models;
using Asp.NetIntro_MVC.Services.Interface;
using Asp.NetIntro_MVC.ViewModels.Categories;
using Asp.NetIntro_MVC.ViewModels.Products;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetIntro_MVC.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string name)
        {
           return await _context.Categories.AnyAsync(m => m.Name.Trim() == name.Trim());
        }

        public async Task<bool> ExistByIdAsync(int id,string name)
        {
            return await _context.Categories.AnyAsync(m=>m.Name.Trim() == name.Trim() && m.Id!= id);
        }

        public async Task<IEnumerable<CategoryArchiveVM>> GetAllArchiveAsync()
        {
            IEnumerable<Category> categories = await _context.Categories.IgnoreQueryFilters()
                            .Where(m => m.SoftDeleted)
                            .OrderByDescending(m => m.Id)
                            .ToListAsync();
            return categories.Select(m => new CategoryArchiveVM
            {
                Id = m.Id,
                CategoryName = m.Name,             
                CreatedDate = m.CreatedDate.ToString("dd.MM.yyyy"),
            });
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllPaginateAsync(int page, int take)
        {
            return await _context.Categories.Include(m => m.Products)
                                          .Skip((page - 1) * take)
                                          .Take(take)
                                          .ToListAsync(); ;
        }

        public async Task<IEnumerable<CategoryProductVM>> GetAlWithProductCountAsync()
        {
            IEnumerable<Category> categories = await _context.Categories.Include(m => m.Products).OrderByDescending(m=>m.Id)
                                                                         .ToListAsync();
            return categories.Select(m => new CategoryProductVM
            {
                Id = m.Id,
                CategoryName = m.Name,
                CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy"),
                ProductCount = m.Products.Count,
            });
        }

        public async Task<Category> GetByIDAsync(int id)
        {
           return await _context.Categories.FindAsync(id); 
        }

        public async Task<Category> GetByIdForArchiveAsync(int id)
        {
            return await _context.Categories.IgnoreQueryFilters().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Categories.CountAsync();
        }

        public IEnumerable<CategoryProductVM> GetMappedDatas(IEnumerable<Category> categories)
        {
            return categories.Select(m => new CategoryProductVM
            {
                Id = m.Id,
                CategoryName = m.Name,
                CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy"),
                ProductCount = m.Products.Count,
            });
        }
    }
}
