using Asp.NetIntro_MVC.Data;
using Asp.NetIntro_MVC.Models;
using Asp.NetIntro_MVC.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetIntro_MVC.Services
{
    public class ExpertService : IExpertService
    {
        private readonly AppDbContext _context;

        public ExpertService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Expert>> GetAllAsync()
        {
            return await _context.Experts.ToListAsync();  
        }
    }
}
