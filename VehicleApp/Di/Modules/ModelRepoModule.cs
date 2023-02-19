using Autofac;
using VehicleApp.Repository;

namespace VehicleApp.DI.VehicleModelModule
{
    public class ModelRepoModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<VehicleModelRepositoryImpl>().AsSelf().SingleInstance();
        }
    }
}
