using Asp.NetIntro_MVC.Data;
using Asp.NetIntro_MVC.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetIntro_MVC.Services
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly AppDbContext _context;
        public SocialMediaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Dictionary<string, string>> GetAllAsync()
        {
            return await _context.SocialMedias.ToDictionaryAsync(m => m.Name, m => m.Url);
        }
    }
}
