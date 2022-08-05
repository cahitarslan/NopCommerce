using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;

namespace Kuantum.Plugin.Widgets.SwiperSlider.Components
{
    [ViewComponent(Name = "WidgetsSwiperSlider")]
    public class WidgetsSwiperSliderViewComponent : NopViewComponent
    {
        #region Fields
        private readonly SwiperSliderSettings _swiperSliderSettings;
        #endregion

        #region Ctor
        public WidgetsSwiperSliderViewComponent( SwiperSliderSettings swiperSliderSettings)
        {
            _swiperSliderSettings = swiperSliderSettings;
        }

        #endregion


        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            return View("~/Plugins/Widgets.SwiperSlider/Views/PublicInfo.cshtml", _swiperSliderSettings);
        }
    }
}
