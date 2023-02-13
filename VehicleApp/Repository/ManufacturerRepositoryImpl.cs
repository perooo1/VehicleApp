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

        private IDatabaseMock<VehicleManufacturer> db; 

        public ManufacturerRepositoryImpl(IContainer container)
        {
            this.db = container.Resolve<IDatabaseMock<VehicleManufacturer>>();
        }

        public Task<bool> AddItemAsync(VehicleManufacturer item)
        {
            return db.AddItemAsync(item);
        }

        public Task<ICollection<VehicleManufacturer>> GetAllItemsAsync()
        {
            return db.GetAllItemsAsync();
        }

        public Task<VehicleManufacturer> GetItemAsync(string id)
        {
            return db.GetItemAsync(id);
        }

        public Task<bool> RemoveItemAsync(VehicleManufacturer item)
        {
            return db.RemoveItemAsync(item);
        }

        public Task<bool> UpdateItemAsync(VehicleManufacturer item)
        {
            return db.UpdateItemAsync(item);
        }
    }
}
