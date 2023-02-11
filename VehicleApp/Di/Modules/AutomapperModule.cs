using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleApp.DI.Modules
{
    public class AutomapperModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //todo add sth here, probably mapping rules(configuration)
            })).AsSelf().SingleInstance();
        }
    }
}
