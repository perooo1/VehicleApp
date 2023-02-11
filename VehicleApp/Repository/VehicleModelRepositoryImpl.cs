using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Data;
using VehicleApp.Data.Manufacturer;
using VehicleApp.Data.Model;
using VehicleApp.Service.Models;

namespace VehicleApp.Repository
{
    public class VehicleModelRepositoryImpl : IDatabaseMock<VehicleModel>
    {
        //These repos should implement interface eg. "IRepository" but since it would have the same methods as IDatabaseMock, I decided to reuse that one.

        private ManufacturerDbMockImpl manufacturerDao;
        private IDatabaseMock<VehicleModel> dao = new ModelDbMockImpl(manufacturerDao); //USE DI!

        //ctor and then set manufDao

        public Task<bool> AddItemAsync(VehicleModel item)
        {
            return dao.AddItemAsync(item);
        }

        public Task<ICollection<VehicleModel>> GetAllItemsAsync()
        {
            return dao.GetAllItemsAsync();
        }

        public Task<VehicleModel> GetItemAsync(int id)
        {
            return dao.GetItemAsync(id);
        }

        public Task<bool> RemoveItemAsync(VehicleModel item)
        {
            return dao.RemoveItemAsync(item);
        }

        public Task<bool> UpdateItemAsync(int id)
        {
            return dao.UpdateItemAsync(id);
        }
    }
}
