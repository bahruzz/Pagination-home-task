
using Asp.NetIntro_MVC.Models;
using Asp.NetIntro_MVC.ViewModels.Blog;

namespace Asp.NetIntro_MVC.ViewModels
{
    public class HomeVM
    {
     
       
        public IEnumerable<BlogVM> Blogs { get; set; }

        public IEnumerable<Expert> Experts { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Product> Products { get; set; }





    }
}
