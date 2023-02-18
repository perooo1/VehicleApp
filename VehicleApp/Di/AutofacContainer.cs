using Autofac;
using Autofac.Features.ResolveAnything;
using VehicleApp.DI.Modules;
using VehicleApp.DI.VehicleManufacturerModule;
using VehicleApp.DI.VehicleModelModule;

namespace VehicleApp.DI
{
    public class AutofacContainer
    {
        private static IContainer container;
        public static IContainer Container 
        {
            get
            {
                if (container == null)
                    container = Configure();

                return container;
            }
        }

        private static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<AutomapperModule>();
            builder.RegisterModule<ManufacturerRepoModule>();
            builder.RegisterModule<ModelRepoModule>();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            return builder.Build();
        }
    }
}
