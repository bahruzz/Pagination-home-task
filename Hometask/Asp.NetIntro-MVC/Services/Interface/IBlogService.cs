using Asp.NetIntro_MVC.Models;
using Asp.NetIntro_MVC.ViewModels.Blog;

namespace Asp.NetIntro_MVC.Services.Interface
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogVM>> GetAllAsync(int? take=null);

        Task<Blog> GetByIDAsync(int id);
        Task<bool> ExistAsync(string title);
        Task CreateAsync(Blog blog);
        Task DeleteAsync(Blog blog);

        Task<bool> ExistByIdAsync(int id, string title);
    }
}
