using Asp.NetIntro_MVC.Models;
using Asp.NetIntro_MVC.ViewModels.Categories;
using Asp.NetIntro_MVC.ViewModels.Products;

namespace Asp.NetIntro_MVC.Services.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<CategoryProductVM>> GetAlWithProductCountAsync();
        Task<Category> GetByIDAsync(int id);
        Task<bool> ExistAsync(string name);
        Task CreateAsync(Category category);
        Task DeleteAsync(Category category);
        Task<bool> ExistByIdAsync(int id,string name);
        Task<IEnumerable<CategoryArchiveVM>> GetAllArchiveAsync();

        Task<IEnumerable<Category>> GetAllPaginateAsync(int page, int take);
        IEnumerable<CategoryProductVM> GetMappedDatas(IEnumerable<Category> categories);
        Task<int> GetCountAsync();
        Task<Category> GetByIdForArchiveAsync(int id);

    }
}

