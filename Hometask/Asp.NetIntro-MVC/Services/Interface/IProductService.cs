using Asp.NetIntro_MVC.Models;
using Asp.NetIntro_MVC.ViewModels.Products;

namespace Asp.NetIntro_MVC.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllWithImagesAsync();
        Task<Product> GetByIdWithAllDatasAsync(int id);

        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetAllPaginateAsync(int page, int take);
        IEnumerable<ProductVM> GetMappedDatas(IEnumerable<Product> products);
        Task<int> GetCountAsync();

    }
}
