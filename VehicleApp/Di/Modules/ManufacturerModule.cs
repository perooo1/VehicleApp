
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.Data;
using VehicleApp.Repository;

namespace VehicleApp.DI.VehicleManufacturerModule
{
    public class ManufacturerModule: Module //ovdje mu dajem repository
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ManufacturerRepositoryImpl>().As<IDatabaseMock<ManufacturerRepositoryImpl>>().SingleInstance();
            //builder.RegisterType<ManufacturerRepositoryImpl>().AsSelf().SingleInstance();
        }
    }
}
