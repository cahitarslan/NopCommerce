using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Stores;

namespace Kuantum.Plugin.Widgets.SwiperSlider.Data.Domain
{
    public class Slider : BaseEntity, IStoreMappingSupported, IAclSupported
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public bool Published { get; set; }
        public bool LimitedToStores { get; set; }
        public bool SubjectToAcl { get; set; }

        /*
         * Bir slider içerisinde birden fazla resim yani slider bulunur. 
         */
    }
}
