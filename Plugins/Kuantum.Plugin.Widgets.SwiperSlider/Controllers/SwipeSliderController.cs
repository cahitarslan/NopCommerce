using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kuantum.Plugin.Widgets.SwiperSlider.Models;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Kuantum.Plugin.Widgets.SwiperSlider.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class SwipeSliderController : BasePluginController
    {
        #region Fields
        private readonly ISettingService _settingService;
        private readonly INotificationService _notificationService;
        private readonly SwiperSliderSettings _swiperSliderSettings;
        private readonly ILocalizationService _localizationService;
        #endregion

        #region Ctor
        public SwipeSliderController(
            ISettingService settingService,
            SwiperSliderSettings swiperSliderSettings, 
            INotificationService notificationService,
            ILocalizationService localizationService)
        {
            _settingService = settingService;
            _notificationService = notificationService;
            _swiperSliderSettings = swiperSliderSettings;
            _localizationService = localizationService;
        }
        #endregion


        public async Task<IActionResult> Configure()
        {
            var model = new ConfigurationModel
            {
                SwiperCssSelector = _swiperSliderSettings.SwiperCssSelector,
                PaginationCssSelector = _swiperSliderSettings.PaginationCssSelector,
                NavigationNextCssSelector = _swiperSliderSettings.NavigationNextCssSelector,
                NavigationPrevCssSelector = _swiperSliderSettings.NavigationPrevCssSelector,
                ScrollBarCssSelector = _swiperSliderSettings.ScrollBarCssSelector,
                Direction = _swiperSliderSettings.Direction,
                DirectionId = Convert.ToInt32(_swiperSliderSettings.Direction),
                InitialSlide = _swiperSliderSettings.InitialSlide,
                Speed = _swiperSliderSettings.Speed,
                Loop = _swiperSliderSettings.Loop,
                PaginationEnabled = _swiperSliderSettings.PaginationEnabled,
                NavigationEnabled = _swiperSliderSettings.NavigationEnabled,
                ScrollBarEnabled = _swiperSliderSettings.ScrollBarEnabled
            };
             return View("~/Plugins/Widgets.SwiperSlider/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            _swiperSliderSettings.SwiperCssSelector = model.SwiperCssSelector;
            _swiperSliderSettings.PaginationCssSelector = model.PaginationCssSelector;
            _swiperSliderSettings.NavigationNextCssSelector = model.NavigationNextCssSelector;
            _swiperSliderSettings.NavigationPrevCssSelector = model.NavigationPrevCssSelector;
            _swiperSliderSettings.ScrollBarCssSelector = model.ScrollBarCssSelector;
            _swiperSliderSettings.Direction = (Direction)Enum.Parse(typeof(Direction), model.DirectionId.ToString());
            _swiperSliderSettings.InitialSlide = model.InitialSlide;
            _swiperSliderSettings.Speed = model.Speed;
            _swiperSliderSettings.Loop = model.Loop;
            _swiperSliderSettings.PaginationEnabled = model.PaginationEnabled;
            _swiperSliderSettings.NavigationEnabled = model.NavigationEnabled;
            _swiperSliderSettings.ScrollBarEnabled = model.ScrollBarEnabled;

            await _settingService.SaveSettingAsync(_swiperSliderSettings);
            await _settingService.ClearCacheAsync();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return await Configure();
        }
    }
}
