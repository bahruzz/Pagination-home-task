namespace Asp.NetIntro_MVC.Services.Interface
{
    public interface ISocialMediaService
    {
        Task<Dictionary<string, string>> GetAllAsync();
    }
}
