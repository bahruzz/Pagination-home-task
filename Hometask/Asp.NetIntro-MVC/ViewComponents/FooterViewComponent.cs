using Asp.NetIntro_MVC.Models;
using Asp.NetIntro_MVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetIntro_MVC.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly ISettingService _settingService;
        public FooterViewComponent(ISocialMediaService socialMediaService, ISettingService settingService)
        {
            _socialMediaService = socialMediaService;
            _settingService = settingService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var datas = new FooterVMVC
            {
                SocialMedias = await _socialMediaService.GetAllAsync(),
                Settings = await _settingService.GetAllAsync(),
            };

            return View(datas);
        }
    }
    public class FooterVMVC
    {
        public IDictionary<string,string> SocialMedias { get; set; }
        public IDictionary<string, string> Settings { get; set; }
    }

}

