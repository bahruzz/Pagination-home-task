using Asp.NetIntro_MVC.Models;

namespace Asp.NetIntro_MVC.Services.Interface
{
    public interface IExpertService
    {
        Task<IEnumerable<Expert>> GetAllAsync();
    }
}
