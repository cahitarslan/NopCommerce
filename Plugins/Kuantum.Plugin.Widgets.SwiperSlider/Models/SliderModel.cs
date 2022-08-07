using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Stores;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Kuantum.Plugin.Widgets.SwiperSlider.Models
{
    public record SliderModel : BaseNopEntityModel, IAclSupportedModel, IAclSupported
    {
        public SliderModel()
        {
            AvailableCustomerRoles = new List<SelectListItem>();
            AvailableStores = new List<SelectListItem>();
        }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public bool Published { get; set; }


        [NopResourceDisplayName("Kuantum.Plugin.Widgets.SwiperSlider.Sliders.Fields.AclCustomerRoles")]
        public IList<int> SelectedCustomerRoleIds { get; set; }
        public IList<SelectListItem> AvailableCustomerRoles { get; set; }


        [NopResourceDisplayName("Kuantum.Plugin.Widgets.SwiperSlider.Sliders.Fields.LimitedToStores")]
        public IList<int> SelectedStoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }
        public bool SubjectToAcl { get; set; }
    }
}