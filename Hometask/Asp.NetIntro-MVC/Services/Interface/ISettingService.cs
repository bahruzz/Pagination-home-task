namespace Asp.NetIntro_MVC.Services.Interface
{
    public interface ISettingService
    {
        Task<Dictionary<string, string>> GetAllAsync();
    }
}
