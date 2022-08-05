﻿using FluentMigrator.Builders.Create.Table;
using Nop.Data.Extensions;
using Nop.Data.Mapping.Builders;

namespace Kuantum.Plugin.Widgets.SwiperSlider.Data.Domain
{
    public class SliderItemBuilder : NopEntityBuilder<SliderItem>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.
                WithColumn(nameof(SliderItem.SliderId)).AsInt32().ForeignKey<Slider>();
        }
    }
}
