using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Data;
using VehicleApp.Data.Manufacturer;
using VehicleApp.Service.Models;

namespace VehicleApp.Repository
{
    public class ManufacturerRepositoryImpl : IDatabaseMock<VehicleManufacturer>
    {
        //These repos should implement interface eg. "IRepository" but since it would have the same methods as IDatabaseMock, I decided to reuse that one.

        private IDatabaseMock<VehicleManufacturer> dao; 

        //constructor injection!!
        public ManufacturerRepositoryImpl(IContainer container)
        {
            this.dao = container.Resolve<IDatabaseMock<VehicleManufacturer>>();
        }

        public Task<bool> AddItemAsync(VehicleManufacturer item)
        {
            return dao.AddItemAsync(item);
        }

        public Task<ICollection<VehicleManufacturer>> GetAllItemsAsync()
        {
            return dao.GetAllItemsAsync();
        }

        public Task<VehicleManufacturer> GetItemAsync(string id)
        {
            return dao.GetItemAsync(id);
        }

        public Task<bool> RemoveItemAsync(VehicleManufacturer item)
        {
            return dao.RemoveItemAsync(item);
        }

        public Task<bool> UpdateItemAsync(VehicleManufacturer item)
        {
            return dao.UpdateItemAsync(item);
        }
    }
}
