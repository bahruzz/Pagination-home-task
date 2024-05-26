using Asp.NetIntro_MVC.Data;
using Asp.NetIntro_MVC.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetIntro_MVC.Services
{
    public class SettingService : ISettingService
    {
        private readonly AppDbContext _context;
            public SettingService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Dictionary<string, string>> GetAllAsync()
        {
            return await _context.Settings.ToDictionaryAsync(m => m.Key, m => m.Value);
        }
    }
}
