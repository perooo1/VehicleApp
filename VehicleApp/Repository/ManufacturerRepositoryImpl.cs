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
        
        private IDatabaseMock<VehicleManufacturer> dao = new ManufacturerDbMockImpl();   //NEED TO USE DI!!

        public Task<bool> AddItemAsync(VehicleManufacturer item)
        {
            return dao.AddItemAsync(item);
        }

        public Task<ICollection<VehicleManufacturer>> GetAllItemsAsync()
        {
            return dao.GetAllItemsAsync();
        }

        public Task<VehicleManufacturer> GetItemAsync(int id)
        {
            return dao.GetItemAsync(id);
        }

        public Task<bool> RemoveItemAsync(VehicleManufacturer item)
        {
            return dao.RemoveItemAsync(item);
        }

        public Task<bool> UpdateItemAsync(int id)
        {
            return dao.UpdateItemAsync(id);
        }
    }
}
