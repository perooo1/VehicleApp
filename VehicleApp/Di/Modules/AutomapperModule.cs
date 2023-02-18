using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.Service.Models;

namespace VehicleApp.DI.Modules
{
    public class AutomapperModule: Module
    {
        /*
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<VehicleModelProfile>();
            })).As<IMapper>()
            .InstancePerLifetimeScope();
        }
        */
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<VehicleModelProfile>();
            })).AsSelf()
            .SingleInstance();

            builder.Register(
                c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();

        }

    }

    internal class VehicleModelProfile: Profile
    {
        public VehicleModelProfile()
        {
            CreateMap<VehicleManufacturer, VehicleModel>()
                .ForMember(dest => dest.ManufacturerId, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.Abrv, options => options.MapFrom(src => src.Abrv));
        }
    }
}
