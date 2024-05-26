using System.ComponentModel.DataAnnotations;

namespace Asp.NetIntro_MVC.ViewModels.Blog
{
    public class BlogEditVM
    {
        public string Description { get; set; }
        [Required(ErrorMessage = "This input can't be empty")]
        [StringLength(20)]
        public string Title { get; set; }

        public string Image { get; set; }

        public IFormFile NewImage { get; set; }
    }
}

