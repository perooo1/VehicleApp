
using Autofac;
using VehicleApp.Repository;

namespace VehicleApp.DI.VehicleManufacturerModule
{
    public class ManufacturerRepoModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ManufacturerRepositoryImpl>().AsSelf().SingleInstance();
        }
    }
}
