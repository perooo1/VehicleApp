using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.Data.Manufacturer;
using VehicleApp.Data.Model;
using VehicleApp.Repository;

namespace VehicleApp.DI.Modules
{
    public class VehicleManufacturerDbMockModule: Module
    {
        //this exists only because of synchronous GetManufacturers() method in mock db.
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ManufacturerDbMockImpl>().AsSelf();
        }
    }
}
