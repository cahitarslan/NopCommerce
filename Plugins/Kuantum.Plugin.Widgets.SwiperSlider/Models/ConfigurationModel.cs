using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Kuantum.Plugin.Widgets.SwiperSlider.Models 
{
    public record ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Kuantum.Plugin.Widgets.SwiperSlider.Models.SwiperCssSelector")]
        public string SwiperCssSelector { get; set; }

        [NopResourceDisplayName("Kuantum.Plugin.Widgets.SwiperSlider.Models.PaginationCssSelector")]
        public string PaginationCssSelector { get; set; }

        [NopResourceDisplayName("Kuantum.Plugin.Widgets.SwiperSlider.Models.NavigationNextCssSelector")]
        public string NavigationNextCssSelector { get; set; }

        [NopResourceDisplayName("Kuantum.Plugin.Widgets.SwiperSlider.Models.NavigationPrevCssSelector")]
        public string NavigationPrevCssSelector { get; set; }

        [NopResourceDisplayName("Kuantum.Plugin.Widgets.SwiperSlider.Models.ScrollBarCssSelector")]
        public string ScrollBarCssSelector { get; set; }

        [NopResourceDisplayName("Kuantum.Plugin.Widgets.SwiperSlider.Models.Direction")]
        public int DirectionId { get; set; }

        [NopResourceDisplayName("Kuantum.Plugin.Widgets.SwiperSlider.Models.Direction")]
        public Direction Direction { get; set; }

        [NopResourceDisplayName("Kuantum.Plugin.Widgets.SwiperSlider.Models.InitialSlide")]
        public int InitialSlide { get; set; }

        [NopResourceDisplayName("Kuantum.Plugin.Widgets.SwiperSlider.Models.Speed")]
        public int Speed { get; set; }

        [NopResourceDisplayName("Kuantum.Plugin.Widgets.SwiperSlider.Models.Loop")]
        public bool Loop { get; set; }

        [NopResourceDisplayName("Kuantum.Plugin.Widgets.SwiperSlider.Models.PaginationEnabled")]
        public bool PaginationEnabled { get; set; }

        [NopResourceDisplayName("Kuantum.Plugin.Widgets.SwiperSlider.Models.NavigationEnabled")]
        public bool NavigationEnabled { get; set; }

        [NopResourceDisplayName("Kuantum.Plugin.Widgets.SwiperSlider.Models.ScrollBarEnabled")]
        public bool ScrollBarEnabled { get; set; }
    }
}
