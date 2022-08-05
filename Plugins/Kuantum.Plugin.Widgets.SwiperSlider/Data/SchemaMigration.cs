using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using Kuantum.Plugin.Widgets.SwiperSlider.Data.Domain;
using Nop.Data.Extensions;
using Nop.Data.Migrations;

namespace Kuantum.Plugin.Widgets.SwiperSlider.Data
{
    [NopMigration("2022/08/05 09:55:00", "Widgets.SwiperSlider base schema", MigrationProcessType.Installation)]
    public class SchemaMigration : AutoReversingMigration
    {
        public override void Up()
        {
            Create.TableFor<Slider>();
        }
    }
}
