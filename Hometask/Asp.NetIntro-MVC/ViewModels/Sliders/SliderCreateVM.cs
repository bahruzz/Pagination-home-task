using System.ComponentModel.DataAnnotations;

namespace Asp.NetIntro_MVC.ViewModels.Sliders
{
    public class SliderCreateVM
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}
