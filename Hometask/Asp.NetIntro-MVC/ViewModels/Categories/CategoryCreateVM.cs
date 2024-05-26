using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace Asp.NetIntro_MVC.ViewModels.Categories
{
    public class CategoryCreateVM
    {
        [Required(ErrorMessage ="This input can't be empty")]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
