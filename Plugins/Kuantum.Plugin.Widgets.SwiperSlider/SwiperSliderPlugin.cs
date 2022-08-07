using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Kuantum.Plugin.Widgets.SwiperSlider
{
    public class SwiperSliderPlugin : BasePlugin, IWidgetPlugin
    {
        #region Fields
        private readonly IWebHelper _webHelper;
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;
        #endregion


        #region Ctor
        public SwiperSliderPlugin(ILocalizationService localizationService, ISettingService settingService, IWebHelper webHelper)
        {
            _webHelper = webHelper;
            _settingService = settingService;
            _localizationService = localizationService;
        }
        #endregion


        #region BasePlugin Overrides
        public override async Task InstallAsync()
        {
            var settings = new SwiperSliderSettings
            {
                SwiperCssSelector = ".swiper",
                PaginationCssSelector = ".swiper-pagination",
                NavigationNextCssSelector = ".swiper-button-next",
                NavigationPrevCssSelector = ".swiper-button-prev",
                ScrollBarCssSelector = ".swiper-scrollbar",
                Direction = Direction.Horizontal,
                InitialSlide = 0,
                Speed = 300,
                Loop = true,
                NavigationEnabled = true,
                PaginationEnabled = true,
                ScrollBarEnabled = false,
                PaginationClickableEnabled = true,
                AutoPlayEnabled = false,
                
            };
            await _settingService.SaveSettingAsync(settings);

            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.SwiperCssSelector", "Swiper Css Selector");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.SwiperCssSelector.Hint", "Swiper Slider kapsayan html elementine ait css selector girin. Id için #selector, class için  .selector!");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.PaginationCssSelector", "Pagination Css Selector");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.NavigationNextCssSelector", "Navigation Next Css Selector");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.NavigationPrevCssSelector", "Navigation Prev Css Selector");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.ScrollBarCssSelector", "Scroll Bar Css Selector");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.Direction", "Direction");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.InitialSlide", "Initial Slide");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.Speed", "Speed");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.Loop", "Loop");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.LoopFillGroupWithBlankEnabled", "Loop Fill Group With Blank");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.PaginationEnabled", "Pagination Enabled");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.PaginationClickableEnabled", "Pagination Clickable Enabled");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.NavigationEnabled", "Navigation Enabled");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.ScrollBarEnabled", "Scroll Bar Enabled");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.AutoPlayEnabled", "Auto Play Enabled");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.AutoPlayDelay", "Auto Play Delay");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.AutoPlayDisableOnInteraction", "Auto Play Disable On Interaction");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.SlidesPerGroup", "Slides Per Group");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.SpaceBetween", "Space Between");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.SlidesPerView", "Slides Per View");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.FreeModeEnabled", "Free Mode Enabled");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.GridRows", "Grid Rows");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.CenteredSlidesEnabled", "Centered Slides Enabled");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Kuantum.Plugin.Widgets.SwiperSlider.Models.DynamicBulletsEnabled", "Dynamic Bullets Enabled");
        }

        public override async Task UninstallAsync()
        {
            await _settingService.DeleteSettingAsync<SwiperSliderSettings>();
            await _localizationService.DeleteLocaleResourcesAsync("Kuantum.Plugin.Widgets.SwiperSlider");
        }

        public override async Task PreparePluginToUninstallAsync()
        {
            await _localizationService.DeleteLocaleResourcesAsync("Kuantum.Plugin.Widgets.SwiperSlider");
        }

        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/SwiperSlider/Configure";
        }

        #endregion


        #region IWidgetPlugin

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageTop, PublicWidgetZones.ProductDetailsTop });
        }

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsSwiperSlider";
        }

        public bool HideInWidgetList => false;


        #endregion
    }
}
