using Asp.NetIntro_MVC.Data;
using Asp.NetIntro_MVC.Models;
using Asp.NetIntro_MVC.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetIntro_MVC.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;

        public SliderService(AppDbContext context)
        {
            _context = context;

        }


        public async Task<IEnumerable<Slider>> GetAllAsync()
        {
            return await _context.Sliders.ToListAsync();
            //return await _context.Sliders.IgnoreQueryFilters.ToListAsync();
            //softdelete true gostermek ucun
        }

        public async Task<SliderInfo> GetSliderInfoAsync()
        {
           return await _context.Sliderinfos.Where(m=> !m.SoftDeleted).FirstOrDefaultAsync();    
        }
    }
}
